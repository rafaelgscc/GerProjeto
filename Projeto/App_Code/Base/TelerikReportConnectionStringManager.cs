using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Telerik.Reporting;

namespace PROJETO
{
	/// <summary>
	/// Summary description for TelerikReportConnectionStringManager
	/// </summary>
	public class TelerikReportConnectionStringManager
	{

		private Dictionary<string, Dictionary<string, string>> DataSourcesConnectionStrings;

		public TelerikReportConnectionStringManager(Dictionary<string, Dictionary<string, string>> dataSourcesConnectionStrings)
		{
			this.DataSourcesConnectionStrings = dataSourcesConnectionStrings;
		}

		public ReportSource UpdateReportSource(ReportSource sourceReportSource)
		{
			return UpdateReportSource(sourceReportSource, null);
		}

		public ReportSource UpdateReportSource(ReportSource sourceReportSource, Dictionary<string, Dictionary<string, string>> DataSources)
		{
			if (sourceReportSource is UriReportSource)
			{
				var uriReportSource = (UriReportSource)sourceReportSource;
                if (uriReportSource.Uri.StartsWith("#(~") && uriReportSource.Uri.EndsWith(")"))
                {
                    uriReportSource.Uri = HttpContext.Current.Server.MapPath(uriReportSource.Uri.Substring(2, uriReportSource.Uri.Length - 3));
                }
				var reportInstance = DeserializeReport(uriReportSource);
				ValidateReportSource(uriReportSource.Uri);
				this.SetConnectionString(reportInstance);
				return CreateInstanceReportSource(reportInstance, uriReportSource);
			}

			if (sourceReportSource is XmlReportSource)
			{
				var xml = (XmlReportSource)sourceReportSource;
				ValidateReportSource(xml.Xml);
				var reportInstance = this.DeserializeReport(xml);
				this.SetConnectionString(reportInstance);
				return CreateInstanceReportSource(reportInstance, xml);
			}

			if (sourceReportSource is InstanceReportSource)
			{
				var instanceReportSource = (InstanceReportSource)sourceReportSource;
                if (instanceReportSource.ReportDocument is ReportBook)
                {
                    foreach (var item in ((ReportBook)instanceReportSource.ReportDocument).Reports)
                    {
                        this.SetConnectionString(item);
                    }
                }
                else
                {
                    this.SetConnectionString((ReportItemBase)instanceReportSource.ReportDocument);
                }
				return instanceReportSource;
			}

			if (sourceReportSource is TypeReportSource)
			{
				var typeReportSource = (TypeReportSource)sourceReportSource;
				var typeName = typeReportSource.TypeName;
				ValidateReportSource(typeName);
				var reportType = Type.GetType(typeName);
				var reportInstance = (Report)Activator.CreateInstance(reportType);
				this.SetConnectionString((ReportItemBase)reportInstance);
				return CreateInstanceReportSource(reportInstance, typeReportSource);
			}

			throw new NotImplementedException("Handler for the used ReportSource type is not implemented.");
		}

		ReportSource CreateInstanceReportSource(IReportDocument report, ReportSource originalReportSource)
		{
			var instanceReportSource = new InstanceReportSource { ReportDocument = report };
			instanceReportSource.Parameters.AddRange(originalReportSource.Parameters);
			return instanceReportSource;
		}

		void ValidateReportSource(string value)
		{
			if (value.Trim().StartsWith("="))
			{
				throw new InvalidOperationException("Expressions for ReportSource are not supported when changing the connection string dynamically");
			}
		}

		Report DeserializeReport(UriReportSource uriReportSource)
		{
			var settings = new System.Xml.XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			using (var xmlReader = System.Xml.XmlReader.Create(uriReportSource.Uri, settings))
			{
				var xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
				var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);
				return report;
			}
		}

		Report DeserializeReport(XmlReportSource xmlReportSource)
		{
			var settings = new System.Xml.XmlReaderSettings();
			settings.IgnoreWhitespace = true;
			var textReader = new System.IO.StringReader(xmlReportSource.Xml);
			using (var xmlReader = System.Xml.XmlReader.Create(textReader, settings))
			{
				var xmlSerializer = new Telerik.Reporting.XmlSerialization.ReportXmlSerializer();
				var report = (Telerik.Reporting.Report)xmlSerializer.Deserialize(xmlReader);
				return report;
			}
		}

		void SetConnectionString(ReportItemBase reportItemBase)
		{
			if (reportItemBase.Items.Count < 1)
				return;

			if (reportItemBase is Report)
			{
				var report = (Report)reportItemBase;

				if (report.DataSource is SqlDataSource)
				{
					var sqlDataSource = (SqlDataSource)report.DataSource;
					sqlDataSource.ConnectionString = DataSourcesConnectionStrings[sqlDataSource.ConnectionString][sqlDataSource.Name]; // connectionString;
					sqlDataSource.CommandTimeout = 900;
					if (sqlDataSource.ConnectionString.IndexOf("|") != -1)
					{
						sqlDataSource.ProviderName = sqlDataSource.ConnectionString.Split('|')[1];
						sqlDataSource.ConnectionString = sqlDataSource.ConnectionString.Split('|')[0];
					}
				}
				foreach (var parameter in report.ReportParameters)
				{
					if (parameter.AvailableValues.DataSource is SqlDataSource)
					{
						var sqlDataSource = (SqlDataSource)parameter.AvailableValues.DataSource;
						sqlDataSource.CommandTimeout = 900;
						if (DataSourcesConnectionStrings.ContainsKey(sqlDataSource.ConnectionString))
						{
							sqlDataSource.ConnectionString = DataSourcesConnectionStrings[sqlDataSource.ConnectionString][sqlDataSource.Name]; // connectionString;
							if (sqlDataSource.ConnectionString.IndexOf("|") != -1)
							{
								sqlDataSource.ProviderName = sqlDataSource.ConnectionString.Split('|')[1];
								sqlDataSource.ConnectionString = sqlDataSource.ConnectionString.Split('|')[0];
							}
						}
					}
				}
			}

			foreach (var item in reportItemBase.Items)
			{
				//recursively set the connection string to the items from the Items collection
				SetConnectionString(item);

				//set the drillthrough report connection strings
				var drillThroughAction = item.Action as NavigateToReportAction;
				if (null != drillThroughAction)
				{
					var updatedReportInstance = this.UpdateReportSource(drillThroughAction.ReportSource);
					drillThroughAction.ReportSource = updatedReportInstance;
				}

				if (item is SubReport)
				{
					var subReport = (SubReport)item;
					if (subReport.ReportSource is UriReportSource)
					{
						List<Parameter> Params = subReport.ReportSource.Parameters.ToList();
						UriReportSource NewDataSource = new UriReportSource { Uri = HttpContext.Current.Server.MapPath(subReport.ReportSource.ToString()) };
						NewDataSource.Parameters.AddRange(Params);
						subReport.ReportSource = this.UpdateReportSource(NewDataSource, DataSourcesConnectionStrings);
					}
					continue;
				}

				//Covers all data items(Crosstab, Table, List, Graph, Map and Chart)
				if (item is DataItem)
				{
					var dataItem = (DataItem)item;
					if (dataItem.DataSource is SqlDataSource)
					{
						var sqlDataSource = (SqlDataSource)dataItem.DataSource;
						sqlDataSource.CommandTimeout = 900;
						if (DataSourcesConnectionStrings.ContainsKey(sqlDataSource.ConnectionString))
						{
							sqlDataSource.ConnectionString = DataSourcesConnectionStrings[sqlDataSource.ConnectionString][sqlDataSource.Name]; // connectionString;
							if (sqlDataSource.ConnectionString.IndexOf("|") != -1)
							{
								sqlDataSource.ProviderName = sqlDataSource.ConnectionString.Split('|')[1];
								sqlDataSource.ConnectionString = sqlDataSource.ConnectionString.Split('|')[0];
							}
						}
						continue;
					}
				}
				else if (item is Telerik.Reporting.PictureBox)
                {
                    foreach (var bitem in ((Telerik.Reporting.PictureBox)item).Bindings)
                    {
                        if (bitem.Expression.StartsWith("#(") && bitem.Expression.EndsWith(")"))
                        {
                            bitem.Expression = String.Format("=Replace({0}, \"~/\", \"./\")", bitem.Expression.Substring(2, bitem.Expression.Length - 3));
                        }
                    }
                }
			}
		}
	}
}

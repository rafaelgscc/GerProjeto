using System;
using System.Collections.Generic;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using Telerik.Reporting;
using COMPONENTS;
using COMPONENTS.Configuration;

namespace PROJETO.Reports
{
	public partial class RelatorioMetas : Page
	{
		protected override void OnLoad(EventArgs e)
		{
			try
			{
				Utility.CheckAuthentication(this,true);
			}
			catch (Exception ex)
			{
			}
		}

		protected override void OnInit(EventArgs e)
		{
			
			Dictionary<string, Dictionary<string, string>> DataSourcesConnections = new Dictionary<string, Dictionary<string, string>>();
			DataSourcesConnections.Add("RelatorioMetas.trdx", new Dictionary<string, string>());
			DataSourcesConnections["RelatorioMetas.trdx"].Add("GV_DS_", Settings.GetConnectionString((((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"])).Connection);
				
			var connectionStringHandler = new TelerikReportConnectionStringManager(DataSourcesConnections);
			var reportSource = connectionStringHandler.UpdateReportSource(new UriReportSource { Uri = Server.MapPath("~/Pages/Relatórios/RelatorioMetas.trdx") });


			TelerikReportViewer1.ReportSource = reportSource;
			TelerikReportViewer1.RefreshReport();
		}
		
	}

}

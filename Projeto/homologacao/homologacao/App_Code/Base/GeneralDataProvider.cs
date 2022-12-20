using System;
using System.Collections.Generic;
using System.Web;
using COMPONENTS.Data;
using System.Resources;
using COMPONENTS.Configuration;
using COMPONENTS;
using System.Data;
using System.Linq;
using Newtonsoft.Json; 

namespace PROJETO.DataProviders
{

	public enum ParameterType
	{
		Select,
		Update,
		Delete,
		Relation
	}

	public struct ParameterStruct
	{
		public string Name;
		public Parameter Parameter;
		public bool Select;
		public bool Update;
		public bool Delete;
		public bool Relation;

		public ParameterStruct(string Name, Parameter Param, bool Select, bool Update, bool Delete, bool Relation)
		{
			this.Name = Name;
			this.Parameter = Param;
			this.Select = Select;
			this.Update = Update;
			this.Delete = Delete;
			this.Relation = Relation;
		}
	}

	public abstract class GeneralDataProvider : RecordDataProviderBase
	{
		public string Name = "";
		protected IGeneralDataProvider BasePage;

		private GeneralProvider _PageProvider;
		public GeneralProvider PageProvider
		{
			get
			{
				return _PageProvider;
			}
			set
			{
				_PageProvider = value;
			}
		}

		public GeneralDataProviderItem Item;
		protected ResourceManager rm = (ResourceManager)HttpContext.Current.Application["rm"];
		public Parameter _KeyParameter;
		public Parameter _KeyParameterNull;
		public int PageNumber = 1;
		public int PageCount;
		public DataCommand SelectCommand; 
		
		public delegate void CreatingParametersEventHandler(object sender);
		public event CreatingParametersEventHandler CreatingParameters;
		public void RaiseCreatingParameters(object sender)
		{
			if (CreatingParameters != null)
			{
				CreatingParameters(sender);
			}
		}

		public delegate void CreatingUniqueParametersEventHandler(object sender);
		public event CreatingUniqueParametersEventHandler CreatingUniqueParameters;
		public void RaiseCreatingUniqueParameters(object sender)
		{
			if (CreatingUniqueParameters != null)
			{
				CreatingUniqueParameters(sender);
			}
		}
		
		public string vgFormID
		{
			get
			{
				return BasePage.FormID;
			}
		}
		
		private string _IndexName;	
		public string IndexName
		{
			get
			{
			   return _IndexName;
			}
			set
			{
				_IndexName = value;
				// vamos encher lista de par??metros
				PrepareSelectCountCommands();
			}
		}
		
		private bool _IsView;
		public bool IsView
		{
			get
			{
				return _IsView;
			}
			set
			{
				_IsView = value;
			}
		}

		private bool _IsVirtual;
		public bool IsVirtual
		{
			get
			{
				return _IsVirtual;
			}
			set
			{
				_IsVirtual = value;
			}
		}

		public bool IsParameterTable
        {
            get
            {
                if ((PageCount == 1) && (!Parameters.Any()))
                {
                    return true;
                }

                return false;
            }
        }

		private string _SqlFrom;
		public string SqlFrom
		{
			get
			{
				return _SqlFrom;
			}
			set
			{
				_SqlFrom = value;
			}
		}
		
		private string _TableName;
		public string TableName
		{
			get
			{
				return _TableName;
			}
			set
			{
				_TableName = value;
			}
		}
	  
		private string _StartFilter;
		public string StartFilter
		{
			get
			{
				return _StartFilter;
			}
			set
			{
				_StartFilter = value;
			}

		} 
		
		private string _DataBaseName;
		public string DataBaseName
		{
			get
			{
				return _DataBaseName;
			}
			set
			{
				_DataBaseName = value;
			}
		}

		private DataAccessObject _Dao;
		public DataAccessObject Dao
		{
			get 
			{ 
				if (_Dao == null) _Dao = Utility.GetDAO(DataBaseName);
				return _Dao;
			}
			set
			{
				_Dao = value;
			}
		}
		
		private Dictionary<string, ParameterStruct> _Parameters;
		public Dictionary<string, ParameterStruct> Parameters
		{
			get
			{
				return _Parameters;
			}
			set
			{
				_Parameters = value;
			}
		}

		public static void GeneralCreatingParameters(object sender)
		{
			GeneralDataProvider Provider = (GeneralDataProvider)sender;
			if (!String.IsNullOrEmpty(Provider.FilterFields) && !string.IsNullOrEmpty(Provider.FiltroAtual))
			{
				Provider.Parameters.Clear();
				foreach (var field in Provider.FilterFields.Split(','))
				{
					Provider.CreateParameter(field);
					GetParameterByName(Provider.Parameters, field).SetValue(Provider.FiltroAtual);
				}
				Provider.FiltroAtual = "";
			}
		}

		public static Parameter GetParameterByName(Dictionary<string, ParameterStruct> Parameters, string FieldName)
		{
			foreach (ParameterStruct parameter in Parameters.Values)
			{
				if (parameter.Name == FieldName)
				{
					return parameter.Parameter;
				}
			}
			return null;
		}

		public FieldBase GetFieldByName(Dictionary<string, FieldBase> Item, string FieldName)
		{
			foreach (FieldBase field in Item.Values)
			{
				if (field.Name == FieldName)
				{
					return field;
				}	
			}
			return null;
		}

		private string GetFieldAlias(Dictionary<string, FieldBase> Item, string FieldName)
		{
			foreach (string field in Item.Keys)
			{
				if (Item[field].Name == FieldName)
				{
					return field; //alias
				}
			}
			return null;
		}

		public void CreateParameter(params string[] FieldNames)
		{
			Dictionary<string, FieldBase> Item = CreateItemFields();
			foreach (string fieldname in FieldNames)
			{
				FieldBase Field = GetFieldByName(Item, fieldname);
				string alias = GetFieldAlias(Item, fieldname);
				if (Field != null)
				{
					switch (Field.FieldType)
					{
						case FieldType.Boolean:
							Parameters.Add(alias, new ParameterStruct(fieldname, new BooleanParameter(), true, true, true, true));
							break;
						case FieldType.Date:
							Parameters.Add(alias, new ParameterStruct(fieldname, new DateParameter(), true, true, true, true));
							break;
						case FieldType.Decimal:
							Parameters.Add(alias, new ParameterStruct(fieldname, new DecimalParameter(), true, true, true, true));
							break;
						case FieldType.Integer:
							Parameters.Add(alias, new ParameterStruct(fieldname, new IntegerParameter(), true, true, true, true));
							break;
						case FieldType.Long:
							Parameters.Add(alias, new ParameterStruct(fieldname, new LongParameter(), true, true, true, true));
							break;
						case FieldType.Text:
							Parameters.Add(alias, new ParameterStruct(fieldname, new TextParameter(), true, true, true, true));
							break;
						default:
							break;
					}
				}
			}
		}

		public virtual Dictionary<string, FieldBase> CreateItemFields()
		{
			return null;
		}

		public virtual void CreateUniqueParameter()
		{
		}

		public virtual bool Criticize
		{
			get
			{
				return false;
			}
		}

		public virtual string CriticizeMessage
		{
			get
			{
				return "";
			}
		}
		
		public string _FilterFields;
		public string FilterFields
		{
			get
			{
				return _FilterFields;
			}
			set
			{
				_FilterFields = value;
				PrepareSelectCountCommands();
			}
		}

		public virtual void CreateParameters()
		{
			if (!IsView)
			{
				RaiseCreatingParameters(this);
			}
		}

		public GeneralDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name):this(BasePage, TableName, DataBaseName, IndexName, Name, "")
		{

		}
		
		public GeneralDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name, string SqlFrom) : this(BasePage, TableName, DataBaseName, IndexName, Name, SqlFrom, false)
		{

		}

		public GeneralDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string Name, string SqlFrom, bool IsVirtual)
		{
			this.Name = Name;
			InitializeDataProvider(BasePage, TableName, DataBaseName, IndexName, SqlFrom, IsVirtual);
		}
		
		private void InitializeDataProvider(IGeneralDataProvider BasePage, string TableName, string DataBaseName, string IndexName, string SqlFrom, bool IsVirtual)
		{
			this.TableName = TableName;
			this.DataBaseName = DataBaseName;
			this.BasePage = BasePage;
			this.IndexName = IndexName;		
			if (IsVirtual)
            {
				this.IsVirtual = true;
            }
			else if (SqlFrom != null && SqlFrom != "")
			{
				IsView = true;
				this.SqlFrom = "(" + SqlFrom + ") " + TableName;
			}
			else
			{
				IsView = false;
				this.SqlFrom = Dao.PoeColAspas(TableName);
			}

			// vamos encher lista de par??metros
			PrepareSelectCountCommands();
			this.SelectCommand = Select; 
			if (BasePage != null)
			{
				Item = BasePage.GetDataProviderItem(this);
			}

		}

		/// <summary>
		/// Testa se parametro esta null ou nao
		/// </summary>
		/// <returns>retorna se o parametro esta null ou nao</returns>
		protected bool CheckParameters()
		{
			if (!IsView && !IsParameterTable)
			{
				bool HasParameters = false;
				foreach (ParameterStruct Param in Parameters.Values)
				{
					if (!Param.Parameter.IsNull)
					{
						HasParameters = true;
						break;
					}
				}
				return HasParameters;
			}
			return true;
		}

		private string[] GetParametersNames(ParameterType ParamType)
		{
			List<string> RetVal = new List<string>();
			foreach (string ParamKey in Parameters.Keys)
			{
				ParameterStruct Param = Parameters[ParamKey];
				if ((ParamType == ParameterType.Select && Param.Select) ||
						(ParamType == ParameterType.Update && Param.Update) ||
						(ParamType == ParameterType.Delete && Param.Delete) ||
						(ParamType == ParameterType.Relation && Param.Relation)
					 )
				{
					if (RetVal.Count > 0)
					{
						if (string.IsNullOrEmpty(this.FilterFields))
						{
							RetVal.Add("AND");
						}
						else
						{
							RetVal.Add("OR");
						}
					}
					RetVal.Add(Dao.PoeColAspas(ParamKey));
				}
			}
			return RetVal.ToArray();
		}

		private void SetParameters(TableCommand Command, ParameterType ParamType, bool KeepCurrentRecord, GeneralDataProvider Provider)
		{
			if (BasePage != null)
			{
				BasePage.GetParameters(KeepCurrentRecord, Provider);
			}
			SetParameters(Command, ParamType);
		}
		
		protected void SetParameters(TableCommand Command, ParameterType ParamType)
		{
			foreach (string ParamKey in _Parameters.Keys)
			{
				ParameterStruct Param = _Parameters[ParamKey];
				if ((ParamType == ParameterType.Select && Param.Select) ||
						(ParamType == ParameterType.Update && Param.Update) ||
						(ParamType == ParameterType.Delete && Param.Delete) ||
						(ParamType == ParameterType.Relation && Param.Relation || ParamType == ParameterType.Relation && Param.Select))
				{
					string paramformat = "";
					if (Param.Parameter is DateParameter)
					{
						paramformat = Select.DateFormat;
					}
					Command.AddParameter(ParamKey, Param.Parameter, paramformat, Dao.PoeColAspas(Param.Name), string.IsNullOrEmpty(this.FilterFields) ? Condition.Equal : Condition.Contains, false);
				}
			}
		}
		
		// <summary>
		/// Retorna a Quantidade de registros
		/// </summary>
		/// <returns>Retorna Inteiro com a Quantidade de Registros</returns>
		public int GetExistRecords()
		{
			return ExecuteCount();
		}
		
		public void LocateRecord(GeneralDataProviderItem Item)
		{
			LocateRecord(Item, true);
		}

		public void LocateRecord(GeneralDataProviderItem Item, bool UpdateFromUI)
		{
			this.Item = Item;
			if (BasePage != null)
			{
				BasePage.OnSelectedItem(this, Item, UpdateFromUI);
			}
		}

		public void LocateRecordByRow(DataRow Row)
		{
			LocateRecordByRow(Row, true);
		}

		public void LocateRecordByRow(DataRow Row, bool CreateItem)
		{
			if (CreateItem) Item = BasePage.GetDataProviderItem(this);
			foreach (string Key in Item.Fields.Keys)
			{
				FieldBase Field = Item.Fields[Key];
				string FieldName = Field.Name;
				string format = (Item.Fields[Key].FieldType == FieldType.Date ? Select.DateFormat : "");
				Item.Fields[Key].SetValue(Row[FieldName], format);
			}
			LocateRecord(Item);
		}

		public void FindRecord(Dictionary<string, object> Params)
		{
			if (Item == null) Item = BasePage.GetDataProviderItem(this);
			string selectList = "";
			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}
			DataTable dt = new DataTable();
			if (this.IsVirtual)
			{
				dt = SelectJsonItem(Params);
			}
			else
			{
				this.IndexName = IndexName;
				Select.SqlQuery.Replace("{SQL_Select}", selectList.TrimEnd(','));
				int ParamIndex = 0;
				this.Parameters.Clear();
				List<string> ParamsKeys = new List<string>();
				Dictionary<string, FieldBase> ItemField = CreateItemFields();
				foreach (string ParamKey in Params.Keys)
				{
					string aliasName = GetFieldAlias(ItemField, ParamKey);
					if (String.IsNullOrEmpty(aliasName))
					{
						aliasName = ParamKey;
					}

                    if (ParamsKeys.Count > 0)
						ParamsKeys.Add("AND");

					CreateParameter(ItemField[aliasName].Name);

					this.Parameters[aliasName].Parameter.SetValue(Params[ParamKey]);
					string paramformat = "";
					if (this.Parameters[aliasName].Parameter is DateParameter)
					{
						paramformat = Select.DateFormat;
					}
					((TableCommand)Select).AddParameter(ParamKey, this.Parameters[aliasName].Parameter, paramformat, Dao.PoeColAspas(this.Parameters[aliasName].Name), Condition.Equal, false);
					ParamIndex++;
					ParamsKeys.Add(ParamKey);
				}
				
				((TableCommand)Select).WhereTemplate = ParamsKeys.ToArray();
				SetWhere(FiltroAtual);
				PageCount = ExecuteCount();
				PageNumber = 1;
				if (PageNumber < 1) PageNumber = 1;
				if (PageNumber > PageCount) this.PageNumber = PageCount;
				if (PageCount > 0)
				{
					var ds = ExecuteSelect(0, 1);
					if (ds != null) dt = ds.Tables[0];
				}
			}
			if (dt != null && dt.Rows.Count > 0)
			{
				LocateRecordByRow(dt.Rows[0], false);
			}
			else
			{
				PageNumber = 0;
			}
		}
		
		public void FindRecord(string IndexName, params object[] Parameters)
		{
			FindRecord(IndexName, true, Parameters);
		}

		public void FindRecord(string IndexName, bool ShouldLocateRecord, params object[] Parameters)
		{
			this.IndexName = IndexName;
			Item = BasePage.GetDataProviderItem(this);
			string selectList = "";
			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}

			Select.SqlQuery.Replace("{SQL_Select}", selectList.TrimEnd(','));
			RaiseCreatingUniqueParameters(this);
			int ParamIndex = 0;
			List<string> ParamsKeys = new List<string>();
			foreach (string ParamKey in this.Parameters.Keys)
			{
				if (ParamsKeys.Count > 0)
					ParamsKeys.Add("AND");
				this.Parameters[ParamKey].Parameter.SetValue(Parameters[ParamIndex]);
				string paramformat = "";
				if (this.Parameters[ParamKey].Parameter is DateParameter)
				{
					paramformat = Select.DateFormat;
				}
				((TableCommand)Select).AddParameter(ParamKey, this.Parameters[ParamKey].Parameter, paramformat, Dao.PoeColAspas(this.Parameters[ParamKey].Name), Condition.Equal, false);
				ParamIndex++;
				ParamsKeys.Add(ParamKey);
			}

			((TableCommand)Select).WhereTemplate = ParamsKeys.ToArray();
			PageCount = ExecuteCount();
			PageNumber = 1;

			if (PageNumber < 1) PageNumber = 1;
			if (PageNumber > PageCount) this.PageNumber = PageCount;
			DataSet ds = null;
			if (PageCount > 0)
			{
				ds = ExecuteSelect(0, 1);
			}
			if (ds != null && ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];

				foreach (string Key in Item.Fields.Keys)
				{
					FieldBase Field = Item.Fields[Key];
					string FieldName = Field.Name;
					string format = (Item.Fields[Key].FieldType == FieldType.Date ? Select.DateFormat : "");
					Item.Fields[Key].SetValue(dr[FieldName], format);
				}
				RaiseCreatingParameters(this);
				if (ShouldLocateRecord) LocateRecord(Item);
			}
			else
			{
				PageNumber = 0;
			}
		}
		
		public bool PTab(string Filter)
		{
			DataSet ds = new DataSet();
			string selectList = "";
			Item = BasePage.GetDataProviderItem(this);
			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}
			ds = Dao.RunSql("select " + selectList.TrimEnd(',') + " from " + Dao.PoeColAspas(TableName) + (Filter != "" ? " where " + Filter : ""), 0, 1);

			if (ds != null && ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
				foreach (string Key in Item.Fields.Keys)
				{
					FieldBase Field = Item.Fields[Key];
					string FieldName = Field.Name;
					string format = (Item.Fields[Key].FieldType == FieldType.Date ? Select.DateFormat : "");
					Item.Fields[Key].SetValue(dr[FieldName], format);
				}
				LocateRecord(Item);
				return true;
			}
			else
			{
				LocateRecord(Item);
				PageNumber = 0;
				return false;
			}
		}
		
		public DataSet SelectAllItems()
		{
			return SelectAllItems(null);
		}
		
		/// <summary>
		/// Efetua o select no banco de acordo com o filtro
		/// </summary>
		public DataSet SelectAllItems(GeneralDataProviderItem GeneralItem)
		{

			//Zerando todos os parametros antes de usar novamente pois estava pegando os parametros dos selects feitos anteriormente
			Select.Parameters.Clear();
			Select.Dao = Dao;
			Count.Dao = Dao;

			string selectList = "";

			if (GeneralItem == null)
				Item = BasePage.GetDataProviderItem(this);
			else
				Item = GeneralItem;

			Select.FiltroWhere = FiltroAtual;
			SetWhere(FiltroAtual);

			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}

			Select.SqlQuery.Replace("{SQL_Select}", selectList.TrimEnd(','));
			Select.OrderBy = SelectCommand.OrderBy;

			if (Select.OrderBy.Length == 0 && OrderBy != null)
            {
                Select.OrderBy = OrderBy;
            }

			if (Parameters.Count > 0)
			{
				SetParameters((TableCommand)Select, ParameterType.Select, false, this);
			}
			return ExecuteSelect();
		}

		/// <summary>
		/// Efetua o select no banco de acordo com o filtro
		/// </summary>
		public List<GeneralDataProviderItem> SelectAllItems(bool retList)
		{
			DataSet ds = SelectAllItems();
			List<GeneralDataProviderItem> List = new List<GeneralDataProviderItem>();
			if (ds != null && ds.Tables.Count > 0)
			{
				foreach (DataRow dr in ds.Tables[0].Rows)
				{
					GeneralDataProviderItem itm = BasePage.GetDataProviderItem(this);
					foreach (string Key in Item.Fields.Keys)
					{
						FieldBase Field = itm.Fields[Key];
						string FieldName = Field.Name;
						string format = (itm.Fields[Key].FieldType == FieldType.Date ? Select.DateFormat : "");
						itm.Fields[Key].SetValue(dr[FieldName], format);
					}
					List.Add(itm);
				}
			}
			return List;
		}

		public GeneralDataProviderItem SelectItem(int CurrentPageNumber, FormPositioningEnum Positioning, bool ForceRelation)
		{
			return SelectItem(CurrentPageNumber, Positioning, ForceRelation, BasePage.GetDataProviderItem(this));
		}

		/// <summary>
		/// Efetua o select no banco de acordo com o filtro e numero da pagina, USADA NA FILLAUXILIARTABLES
		/// </summary>
		/// <returns>Retorna item com o conteudo da celula que retornou no select</returns>
		public GeneralDataProviderItem SelectItem(int CurrentPageNumber, FormPositioningEnum Positioning, bool ForceRelation, GeneralDataProviderItem ProviderItem)
		{
			//Zerando todos os parametros antes de usar novamente pois estava pegando os parametros dos selects feitos anteriormente
			bool hasParameter = false;
			Select.Parameters.Clear();
			string selectList = "";

			Item = ProviderItem;
			//vamos igualar os objetos de DAO para a mesma transacao
			Select.Dao = Dao;
			Count.Dao = Dao;

			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}

			Select.SqlQuery.Replace("{SQL_Select}", selectList.TrimEnd(','));
			SetParameters((TableCommand)Select, ParameterType.Select, (Positioning == FormPositioningEnum.Current), this);

			foreach (string ValuesParameters in Select.Parameters.AllValues)
			{
				if (ValuesParameters.Length > 0)
				{
					hasParameter = true;
					break;
				}

			}

			if (!hasParameter && ForceRelation)
			{
				return null;
			}

			SetWhere(FiltroAtual);
			PageCount = ExecuteCount();

			switch (Positioning)
			{
				case FormPositioningEnum.None:
					PageNumber = CurrentPageNumber;
					break;
				case FormPositioningEnum.Current:
					PageNumber = CurrentPageNumber;
					break;
				case FormPositioningEnum.First:
					PageNumber = 1;
					break;
				case FormPositioningEnum.Previous:
					PageNumber = CurrentPageNumber - 1;

					break;
				case FormPositioningEnum.Next:
					PageNumber = CurrentPageNumber + 1;
					break;
				case FormPositioningEnum.Last:
					PageNumber = PageCount;
					break;
				default:
					PageNumber = CurrentPageNumber;
					break;
			}

			if (PageNumber < 1) PageNumber = 1;
			if (PageNumber > PageCount) this.PageNumber = PageCount;

			DataSet ds = null;

			if (PageCount > 0)
			{
				if (Positioning == FormPositioningEnum.Current)
				{
					ds = ExecuteSelect(0, 1);
				}
				else
				{
					ds = ExecuteSelect(PageNumber - 1, 1);
				}
			}
			if (ds != null && ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];

				foreach (string Key in Item.Fields.Keys)
				{
					FieldBase Field = Item.Fields[Key];
					string FieldName = Field.Name;
					string format = (Item.Fields[Key].FieldType == FieldType.Date ? Select.DateFormat : "");
					Item.Fields[Key].SetValue(dr[FieldName], format);
				}

				LocateRecord(Item);

				return Item;
			}
			else
			{
				PageNumber = 0;
				return null;
			}
		}

		public DataTable SelectItems(int CurrentPageIndex, int PageSize, out int TotalRecords)
		{
			if (IsVirtual)
            {
				return SelectJsonItem(CurrentPageIndex, PageSize, out TotalRecords);
            }

			//Zerando todos os parametros antes de usar novamente pois estava pegando os parametros dos selects feitos anteriormente
			Select.Parameters.Clear();
			string selectList = "";

			Item = BasePage.GetDataProviderItem(this);
			
			//vamos igualar os objetos de DAO para a mesma transacao
			Select.Dao = Dao;
			Count.Dao = Dao;

			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}

			Select.SqlQuery.Replace("{SQL_Select}", selectList.TrimEnd(','));
			SetParameters((TableCommand)Select, ParameterType.Select, false, this);
			SetWhere(FiltroAtual);
			if (OrderBy != null)
			{
				Select.OrderBy = OrderBy;
			}
			PageCount = ExecuteCount();
			TotalRecords = PageCount;

            if (CurrentPageIndex == -1)
            {
                CurrentPageIndex = (int)Math.Ceiling((decimal)TotalRecords / (decimal)PageSize) - 1;
            }

			PageNumber = CurrentPageIndex;

			if (PageCount > 0)
			{
				return ExecuteSelect(PageNumber * PageSize, PageSize).Tables[0];
			}
			return new DataTable();
		}

		private DataTable SelectJsonItem(Dictionary<string, object> Params)
		{
			var json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/VirtualData/" + TableName));
			DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
			string filter = "";
			if (Params.Count > 0)
			{
				foreach (string ParamKey in Params.Keys)
				{
					if (filter.Length > 0)
					{
						filter += " or ";
					}
					filter += string.Format("{0} like '%{1}%'", this.Item[ParamKey].Name, Params[ParamKey].ToString().Replace("'", "''").Replace("%", "").Replace("{", "").Replace("}", ""));
				}
			}
			var d = dt.Clone();
			d.Rows.Clear();
			foreach (DataRow row in dt.Select(filter, "", DataViewRowState.CurrentRows))
			{
				d.ImportRow(row);
			}
			return d;
		}

        private DataTable SelectJsonItem(int CurrentPageIndex, int PageSize, out int TotalRecords)
        {
			var json = System.IO.File.ReadAllText(HttpContext.Current.Server.MapPath("~/App_Data/VirtualData/" + TableName));
			DataTable dt = (DataTable)JsonConvert.DeserializeObject(json, (typeof(DataTable)));
			string filter = "";
			if (!string.IsNullOrEmpty(this.FiltroAtual) && !string.IsNullOrEmpty(this.FilterFields))
            {
                foreach (var Field in this.FilterFields.Split(','))
				{
					filter += Field + string.Format(" like '%{0}%' or ", this.FiltroAtual.Replace("'", "''").Replace("%","").Replace("{", "").Replace("}", ""));
				}
				filter = filter.Substring(0,filter.Length - 3);
			}
			var d = dt.Clone();
			d.Rows.Clear();
            foreach (DataRow row in dt.Select(filter, "", DataViewRowState.CurrentRows).Skip(PageSize * CurrentPageIndex).Take(PageSize))
            {
				d.ImportRow(row);
            }
			TotalRecords = dt.Rows.Count;
			return d;
		}

		public GeneralDataProviderItem SelectItem(int CurrentPageNumber, FormPositioningEnum Positioning)
		{
			return SelectItem(true, CurrentPageNumber, Positioning);
		}

		public GeneralDataProviderItem SelectItem(bool ShouldLocateRecord, int CurrentPageNumber, FormPositioningEnum Positioning)
		{	
			return SelectItem(ShouldLocateRecord, CurrentPageNumber, Positioning, true);
		}

		public GeneralDataProviderItem SelectItem(bool ShouldLocateRecord, int CurrentPageNumber, FormPositioningEnum Positioning, bool UpdateFromUI)
		{
			//Zerando todos os parametros antes de usar novamente pois estava pegando os parametros dos selects feitos anteriormente
			Select.Parameters.Clear();
			string selectList = "";

			Item = BasePage.GetDataProviderItem(this);
			//vamos igualar os objetos de DAO para a mesma transacao
			Select.Dao = Dao;
			Count.Dao = Dao;

			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				selectList += Select.Dao.PoeColAspas(FieldName) + ",";
			}

			Select.SqlQuery.Replace("{SQL_Select}", selectList.TrimEnd(','));
			SetParameters((TableCommand)Select, ParameterType.Select, (Positioning == FormPositioningEnum.Current), this);
			SetWhere(FiltroAtual);
			PageCount = ExecuteCount();

			switch (Positioning)
			{
				case FormPositioningEnum.None:
					PageNumber = CurrentPageNumber;
					break;
				case FormPositioningEnum.Current:
					PageNumber = CurrentPageNumber;
					break;
				case FormPositioningEnum.First:
					PageNumber = 1;
					break;
				case FormPositioningEnum.Previous:
					PageNumber = CurrentPageNumber - 1;

					break;
				case FormPositioningEnum.Next:
					PageNumber = CurrentPageNumber + 1;
					break;
				case FormPositioningEnum.Last:
					PageNumber = PageCount;
					break;
				default:
					PageNumber = CurrentPageNumber;
					break;
			}

			if (PageNumber < 1) PageNumber = 1;
			if (PageNumber > PageCount) this.PageNumber = PageCount;

			DataSet ds = null;

			if (PageCount > 0)
			{
				if (Positioning == FormPositioningEnum.Current)
				{
					ds = ExecuteSelect(0, 1);
				}
				else
				{
					ds = ExecuteSelect(PageNumber - 1, 1);
				}
			}
			if (ds != null && ds.Tables[0].Rows.Count > 0)
			{
				DataRow dr = ds.Tables[0].Rows[0];
				
				foreach (string Key in Item.Fields.Keys)
				{
					FieldBase Field = Item.Fields[Key];
					string FieldName = Field.Name;
					string format = (Item.Fields[Key].FieldType == FieldType.Date ? Select.DateFormat : "");
					Item.Fields[Key].SetValue(dr[FieldName], format);
					Item.Fields[Key].SettedValue = false;
				}
				
				if (ShouldLocateRecord) LocateRecord(Item, UpdateFromUI);
				
				return Item;
			}
			else
			{
				PageNumber = 0;
				return null;
			}
		}

		/// <summary>
		/// Prepara para executar o insert
		/// </summary>
		override protected void PrepareInsert()
		{
			CmdExecution = true;
		}
		
		/// <summary>
		/// Efetua o select no banco de acordo com o filtro e numero da pagina
		/// </summary>
		/// <returns>Retorna item com o conteudo da celula que retornou no select</returns>
		public int InsertItem(GeneralDataProviderItem Item)
		{
			if (IsView)
				return 0;
			this.Item = Item;
			this.Item.IsNew = true;
			string fieldsList = "";
			string valuesList = "";
			Insert = new TableCommand("INSERT INTO " + Dao.PoeColAspas(TableName) + "{Fields}{Values}", new string[0], Dao);

			foreach (FieldBase Field in Item.Fields.Values)
			{
				string FieldName = Field.Name;
				string format = (Field.FieldType == FieldType.Date ? Insert.DateFormat : "");
				if (Field.FieldType == FieldType.Boolean) format = Insert.BoolFormat;
				string ProcessedValue = "";
				if (PageProvider != null)
					ProcessedValue = PageProvider.CreateProcessBeforeInsert(FieldName);
				if (!Field.IsEmpty && Field.IsUpdatable && (!string.IsNullOrEmpty(ProcessedValue) || Field is BinaryField || Insert.Dao.ToSql(Field.GetFormattedValue(format), Field.FieldType, Field.AllowEmpty) != "NULL"))
				{
					if (!(Field is BinaryField) || ((BinaryField)Field).BinaryValue != null)
					{
						fieldsList += Dao.PoeColAspas(FieldName) + ",";
					}	
					if (Field is BinaryField)
					{
						if (((BinaryField)Field).BinaryValue != null)
						{
							valuesList += Dao.ParameterDelimiter + Utility.PoeUnderLines(FieldName).ToUpper() + ",";
							Insert.Images.Add(Utility.PoeUnderLines(FieldName).ToUpper(), (byte[])((BinaryField)Field).BinaryValue);
						}	
					}
					else
					{
						if (string.IsNullOrEmpty(ProcessedValue))
						{
							valuesList += Insert.Dao.ToSql(Field.GetFormattedValue(format), Field.FieldType, Field.AllowEmpty) + ",";	
						}
						else
						{
							//if(ProcessedValue.StartsWith("\'") && ProcessedValue.EndsWith("\'"))
								//Field.SetValue(ProcessedValue.Trim('\'').TrimEnd('\''));
							//else
								//Field.SetValue(ProcessedValue.Replace(".", ","));
							Field.SetValue(Insert.Dao.ToRawValue(ProcessedValue, Field.FieldType));
							valuesList += ProcessedValue + ","; 
						}
					}
				}
			}
			if (fieldsList.Length > 0)
			{
				Insert.SqlQuery.Replace("{Fields}", "(" + fieldsList.TrimEnd(',') + ")");
				Insert.SqlQuery.Replace("{Values}", " VALUES (" + valuesList.TrimEnd(',') + ")");
			}
			else
			{
				Insert.SqlQuery.Replace("{Fields}{Values}", " DEFAULT VALUES");
			}

			object result = 0;
			bool InTransaction = false;
			try
			{
				Dao.OpenConnection();
				if (Dao.Transaction == null)
				{
					Dao.BeginTrans();
					InTransaction = true;
				}	
				result = ExecuteInsert();
				int i = 0;
				if (PageProvider != null)
				{
					do
					{
						PageProvider.GetTableIdentity();
						BasePage.SetOldParameters(this.Item);
						string ValueField = "";
						PageProvider.FillAuxiliarTables();
						PageProvider.CreateProcess(i);
						if (PageProvider.Process != null && PageProvider.Process.Count > 0)
						{
							List<Process> ProcList = new List<Process>(PageProvider.Process.Values.Where(p => p.Position == i && !p.BeforeUpdate));
							if (ProcList.Count > 0) DataProcessEntry.ExecuteProcess(ProcList, Insert.Dao);
						}
						i++;			
					} while (i <= PageProvider.GetMaxProcessLanc());
				}
				if (InTransaction) 
				{
					BasePage.OnCommiting();
					Dao.CommitTrans(); 
				}
			}
			catch (Exception e)
			{
				if (InTransaction)
				{
					BasePage.OnRollbacking();
					Dao.RollBack(); 
				}
				throw (e);
			}
			finally
			{
				Dao.CloseConnection();
			}

			return (int)result;
		}

		/// <summary>
		/// Prepara para executar Comandos de Select e Count
		/// </summary>
		public void PrepareSelectCountCommands()
		{
			_Parameters = new Dictionary<string, ParameterStruct>();
			CreateParameters();
			Select = new TableCommand("SELECT {SQL_Select} FROM " + SqlFrom + " {SQL_Where} {SQL_OrderBy}", GetParametersNames(ParameterType.Select), Dao);
			Count = new TableCommand("SELECT COUNT(*) FROM " + SqlFrom, new string[] { }, Dao);
		}

		/// <summary>
		/// Prepara para executar o Update
		/// </summary>
		override protected void PrepareUpdate()
		{
			CmdExecution = true;
			IsParametersPassed = CheckParameters();
		}
		
		protected void PrepareUpdateCommand()
		{
			Update = new TableCommand("UPDATE " + Dao.PoeColAspas(TableName) + " SET {Values}", GetParametersNames(ParameterType.Update), Dao);
		}

		/// <summary>
		/// Efetua update de um registro no banco
		/// </summary>
		/// <param name="item">Recebe o item com as informa??oes que seram atualizadas no banco</param>
		/// <returns>Retorna se o update funcionou ou nao</returns>
		public int UpdateItem(GeneralDataProviderItem Item)
		{
			if (IsView)
				return 0;
			this.Item = Item;
			PrepareUpdateCommand();
			SetParameters((TableCommand)Update, ParameterType.Update, true, this);
			return DoUpdateItem();
		}

		/// <summary>
		/// Efetua update de um registro no banco
		/// </summary>
		/// <returns>Retorna se o update funcionou ou nao</returns>
		protected int DoUpdateItem()
		{
			if (IsView) return 0;
			object result = 0;
			bool InTransaction = false;
			try
			{
				Dao.OpenConnection();
				if (Dao.Transaction == null) 
				{
					Dao.BeginTrans();
					InTransaction = true;
				}

				GeneralDataProviderItem NewItem = Item;
				bool ShouldReposition = false;

				// executa processos inversos (nao ha processo inverso para processos marcados como executar antes de update)
				if (PageProvider != null)
				{
					// preenche item com valores atuais do banco para execu????o dos processos inversos
					SelectItem(false, 0, FormPositioningEnum.Current);

					for (int i = 0; i <= PageProvider.GetMaxProcessLanc(); i++)
					{
						PageProvider.CreateReverseProcess(i, "Update");
						if (PageProvider.ReverseProcess != null && PageProvider.ReverseProcess.Count > 0)
						{
							List<Process> ProcList = new List<Process>(PageProvider.ReverseProcess.Values.Where(p => p.Position == i && !p.BeforeUpdate));
							if (ProcList.Count > 0)
							{
								DataProcessEntry.ExecuteProcess(ProcList, Update.Dao);
								ShouldReposition = true;
							}
						}
					}
				}

				// restaura o item que esta atualizado com valores da tela
				Item = NewItem;

				if (ShouldReposition)
				{
					PageProvider.PositionParentsProvider();
					LocateRecord(Item);
				}

				// prepara para o update
				string valuesList = "";

				foreach (FieldBase Field in Item.Fields.Values)
				{
					string FieldName = Field.Name;
					string format = (Field.FieldType == FieldType.Date ? Update.DateFormat : "");
					if (Field.FieldType == FieldType.Boolean) format = Update.BoolFormat;
					string ProcessedValue = "";
					if (PageProvider != null) ProcessedValue = PageProvider.CreateProcessBeforeInsert(FieldName);
					if (Field.IsUpdatable && (!string.IsNullOrEmpty(ProcessedValue) || Field.SettedValue))
					{
						if (Field is BinaryField)
						{
							if (((BinaryField)Field).BinaryValue != null && !String.IsNullOrEmpty(((BinaryField)Field).BinaryValue.ToString()))
							{
								valuesList += Dao.PoeColAspas(FieldName) + "=" + Dao.ParameterDelimiter + Utility.PoeUnderLines(FieldName).ToUpper() + ",";
								Update.Images.Add(Utility.PoeUnderLines(FieldName).ToUpper(), (byte[])((BinaryField)Field).BinaryValue);
							}
							else
							{
								valuesList += Dao.PoeColAspas(FieldName) + "= null,";
							}
						}
						else
						{
							if (string.IsNullOrEmpty(ProcessedValue))
							{
								if (Field.AllowEmpty && (Field.FieldType == FieldType.Text || Field.FieldType == FieldType.Decimal || Field.FieldType == FieldType.Integer || Field.FieldType == FieldType.Long) && (Field.GetValue() == null || Field.GetValue().ToString() == "" || Field.GetValue() is DBNull))
								{
									if (Field.FieldType == FieldType.Text)
									{
										valuesList += Dao.PoeColAspas(FieldName) + "= '',";
									}
									else
									{
										valuesList += Dao.PoeColAspas(FieldName) + "= 0,";
									}
								}
								else
								{
									valuesList += Dao.PoeColAspas(FieldName) + "=" + Update.Dao.ToSql(Field.GetFormattedValue(format), Field.FieldType) + ",";
								}
							}
							else
							{
								//if(ProcessedValue.StartsWith("\'") && ProcessedValue.EndsWith("\'"))
								//	Field.SetValue(ProcessedValue.Trim('\'').TrimEnd('\''));
								//else
								//	Field.SetValue(ProcessedValue.Replace(".", ","));
								Field.SetValue(Update.Dao.ToRawValue(ProcessedValue, Field.FieldType));
								valuesList += Dao.PoeColAspas(FieldName) + "=" + ProcessedValue + ","; 
							}
						}
					}
				}
				if (!CheckParameters())
				{
					throw new Exception("Erro em Parametros Indice nao definido Tabela, Pagina ou Grid");
				}
				Update.SqlQuery.Replace("{Values}", valuesList.TrimEnd(','));

				result = ExecuteUpdate();

				if (PageProvider != null && PageProvider.MainProvider != null) PageProvider.MainProvider.SetOldParameters(NewItem);
				if (PageProvider != null)
				{
					// restaura o item que esta atualizado com valores da tela
					Item = NewItem;

					// reposiciona todas as tabelas auxiliares
					PageProvider.PositionParentsProvider();
					int i = 0;
					do
					{
						Item = NewItem; //this.SelectItem(PageNumber, FormPositioningEnum.Current);
						PageProvider.FillAuxiliarTables();
						PageProvider.CreateProcess(i); //so podemos criar estes processos depois que os lancamentos estao ok.
						if (PageProvider.Process != null && PageProvider.Process.Count > 0)
						{
							List<Process> ProcList = new List<Process>(PageProvider.Process.Values.Where(p => p.Position == i && !p.BeforeUpdate));
							if (ProcList.Count > 0)
								DataProcessEntry.ExecuteProcess(ProcList, Update.Dao);

						}
						i++;
					} while (i <= PageProvider.GetMaxProcessLanc());
				}
				if (InTransaction)
				{
					BasePage.OnCommiting();
					Dao.CommitTrans(); 
				}
			}
			catch (Exception e)
			{
				if (InTransaction)
				{
				BasePage.OnRollbacking();
					Dao.RollBack(); 
				}
				throw (e);
			}
			finally
			{
				Dao.CloseConnection(); 
			}
			return (int)result;
		}

		/// <summary>
		/// Prepara para dar um delete em algum registro
		/// </summary>
		override protected void PrepareDelete()
		{
			CmdExecution = true;
			IsParametersPassed = CheckParameters();
		}

		protected void PrepareDeleteCommand()
		{
			Delete = new TableCommand("DELETE FROM " + Dao.PoeColAspas(TableName), GetParametersNames(ParameterType.Delete), Dao);
		}

		public int DeleteItem(GeneralDataProviderItem Item)
		{
			if (IsView)
				return 0;
			this.Item = Item;
			PrepareDeleteCommand();
			SetParameters((TableCommand)Delete, ParameterType.Delete, true, this);
			return DoDeleteItem();
		}

		public int DeleteItem(GeneralDataProviderItem Item, bool isPreDef)
		{
			if (!isPreDef)
				return DeleteItem(Item);
			if (IsView)
				return 0;
			this.Item = Item;
			PrepareDeleteCommand();
			foreach (string ParamKey in Parameters.Keys)
			{
				Parameters[ParamKey].Parameter.SetValue(Item[ParamKey].GetValue());
			}
			SetParameters((TableCommand)Delete, ParameterType.Delete);
			return (int)ExecuteDelete();
		}

		/// <summary>
		/// Efetua o delete de um registro no banco
		/// </summary>
		/// <returns>Retorna se o delete funcionou ou n????o</returns>
		public int DoDeleteItem()
		{
			if (IsView)
				return 0;
			object result = 0;
			bool InTransaction = false;
			try
			{
				Dao.OpenConnection();
				if (Dao.Transaction == null)
				{
					Dao.BeginTrans();
					InTransaction = true;
				}
				if (PageProvider != null)
				{
					if (!CheckParameters())
					{
						throw new Exception("Erro em Par??metros");
					}
					Item = this.SelectItem(PageNumber, FormPositioningEnum.Current);			
					int i = 0;
					do
					{
						//PageProvider.CreateReverseProcess(i);			
						
						PageProvider.CreateReverseProcess(i, "Delete");			
						if (PageProvider.ReverseProcess != null && PageProvider.ReverseProcess.Count > 0)
						{
							List<Process> ProcList = new List<Process>(PageProvider.ReverseProcess.Values.Where(p => p.Position == i));
							if (ProcList.Count > 0)
								DataProcessEntry.ExecuteProcess(ProcList, Delete.Dao);
						}
						Item = this.SelectItem(PageNumber, FormPositioningEnum.Current);
						BasePage.SetOldParameters(Item);
						PageProvider.PositionParentsProvider();
					i++;
					} while (i <= PageProvider.GetMaxProcessLanc());
				}
				result = ExecuteDelete();	
				if (InTransaction) Dao.CommitTrans(); 			
			}
			catch (Exception e)
			{
				if (InTransaction) Dao.RollBack(); 
				throw (e);
			}
			finally
			{
				Dao.CloseConnection(); 
			}
			return (int)result;
		}

		public virtual string ProviderFilterExpression()
		{
			return null;
		}

		public virtual string[] GetUniqueKeyFields()
		{
			return null;
		}

		public string GetFilterExpression(Dictionary<string, FieldBase> TempItem)
		{
			string FilterExpression = "";
			foreach (KeyValuePair<string, FieldBase> Field in TempItem)
			{
				if (Field.Value.FieldType == FieldType.Date)
				{
					FilterExpression += Dao.PoeColAspas(Item[Field.Key].Name) + " = " + Dao.ToSql(new DateField(SelectCommand.DateFormat, Item[Field.Key].GetValue()).GetFormattedValue(SelectCommand.DateFormat), Item[Field.Key].FieldType, Item[Field.Key].AllowEmpty) + " AND ";
				}
				else
				{
					FilterExpression += Dao.PoeColAspas(Item[Field.Key].Name) + " = " + Dao.ToSql(Item[Field.Key].GetValue().ToString(), Item[Field.Key].FieldType, Item[Field.Key].AllowEmpty) + " AND ";
				}
			}
			if (FilterExpression.Length > 5) FilterExpression = FilterExpression.Remove(FilterExpression.Length - 4);
			return FilterExpression;
		}
	}
}

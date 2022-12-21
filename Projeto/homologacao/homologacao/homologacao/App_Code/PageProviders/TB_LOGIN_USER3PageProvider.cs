using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Data;
using System.Globalization;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Security;
using COMPONENTS.Configuration;
using System.IO;
using System.Web;
using System.Web.UI;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;


namespace PROJETO.DataProviders
{
	/// <summary>
	/// Classe de provider usada para a tabela auxiliar
	/// </summary>
	public class TB_LOGIN_USER3PageProvider : GeneralProvider
	{
		public PesquisarUsuario_Grid1GridDataProvider PesquisarUsuario_Grid1Provider;

		public TB_LOGIN_USER3PageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_LOGIN_USERDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "LOGIN_USER_PK", "TB_LOGIN_USER3");
			MainProvider.DataProvider.PageProvider = this;
			PesquisarUsuario_Grid1Provider = new PesquisarUsuario_Grid1GridDataProvider(this);
			PesquisarUsuario_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(PesquisarUsuario_Grid1Provider_SetRelationFields);
		}


		private void PesquisarUsuario_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				PesquisarUsuario_Grid1Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_LOGIN_USERItem(MainProvider.DatabaseName);
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		return null;
		}

		public override void FillAuxiliarTables()
		{
		}

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("LOGIN_USER_PK", false,new string[] { MainProvider.DataProvider.Item["LOGIN_USER_LOGIN"].GetFormattedValue() });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void ExecuteSingleProcess(string ProcessName)
        {
            CreateProcess(ProcessName, false);
            List<Process> ProcList = new List<Process>(Process.Values);
            if (ProcList.Count > 0)
                DataProcessEntry.ExecuteProcess(ProcList, MainProvider.DataProvider.Dao);
        }
		
		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
		}

		public override void CreateReverseProcess(int Pos , string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}


		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class PesquisarUsuario_Grid1GridDataProvider : GeneralGridProvider
	{
		public string LOGIN_GROUP_NAMEField;
		public string LOGIN_USER_LOGINField;
		public string LOGIN_USER_COORDENACAOField;
		public string LOGIN_USER_PASSWORDField;
		public string LOGIN_USER_NAMEField;
		public string LOGIN_USER_OBSField;
		public string LOGIN_USER_EMAILField;
		public string LOGIN_USER_PHONEField;
		
		public DBGERPROJETO_TB_COORDENACAODataProvider GridColumn8Provider;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private DBGERPROJETO_TB_LOGIN_USERDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_LOGIN_USERDataProvider;
			}
		}

		public TB_LOGIN_USER3PageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_LOGIN_USER"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32768"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public PesquisarUsuario_Grid1GridDataProvider(TB_LOGIN_USER3PageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_LOGIN_USERDataProvider(this, TableName, DatabaseName, "LOGIN_USER_PK", "PesquisarUsuario_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
			GridColumn8Provider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, "TB_COORDENACAO", "DBGERPROJETO", "", "TB_LOGIN_USER3_GridColumn8ProviderAlias");
			GridColumn8Provider.PageProvider = this;
			GridColumn8Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
		}
		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
		if (Provider == GridColumn8Provider)
		{
			if (Item != null)
			{
				return Provider.Item["siglaCoordenacao"].GetFormattedValue();
			}
		}
			return "";
		}

		
		public override string GetGridComboText(string GridColumnId, string FieldId)
		{
			if (string.IsNullOrEmpty(FieldId)) return "";
			DataTable dt;
			DataAccessObject Dao;
			Dictionary<string, object> filter;
			switch (GridColumnId)
			{
				case "GridColumn8":
					filter = new Dictionary<string, object>() { { "siglaCoordenacao", FieldId } };
					Dao = Utility.GetDAO("DBGERPROJETO");
					GridColumn8Provider.FindRecord(filter);
					if (GridColumn8Provider.PageNumber != 0)
					{
						var retval = "";
						if (GridColumn8Provider.Item["siglaCoordenacao"].Value != null) retval +=  GridColumn8Provider.Item["siglaCoordenacao"].Value.ToString();
						return System.Net.WebUtility.HtmlEncode(retval);
					}
					return "";
				default:
					return "";
			}
		}

		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == GridColumn8Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaCoordenacao", Value } });
					return Provider.Item;
				}
			
			}
			catch
			{
			}
			return null;
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			return FillCombo(Provider, ComboBox, NumberOfItems, TextFilter, AllowFilter, null);
		}
		
		public bool FillCombo(GeneralDataProvider Provider, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter, Dictionary<string, object> ClientFields)
		{
			try
			{
			var Dao = Provider.Dao;
				if (Provider == GridColumn8Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "siglaCoordenacao";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaCoordenacao", " siglaCoordenacao", false);
					return Total > 0;
				}
			}
			catch
			{
			}
			return false;
		}
		
		public bool FillCombo(List<RadComboBoxDataItem> ComboBoxDataItem, RadComboBox ComboBox, int NumberOfItems, string TextFilter, bool AllowFilter)
		{
			if (AllowFilter && !String.IsNullOrEmpty(TextFilter))
			{
				return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem.FindAll(c => c.Text.ToLower().Contains(TextFilter.ToLower())));
			}
			return Utility.FillComboBoxItems(ComboBox, 15, ComboBoxDataItem);
		}

		public DBGERPROJETO_TB_LOGIN_USERItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_LOGIN_USERItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "PesquisarUsuario_Grid1")
			{
				return new DBGERPROJETO_TB_LOGIN_USERItem(DatabaseName);
			}
			else if (Provider.Name == "TB_LOGIN_USER3_GridColumn8ProviderAlias")
			{
				return new DBGERPROJETO_TB_COORDENACAOItem(MainProvider.DatabaseName, "siglaCoordenacao");
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (TB_LOGIN_USER3PageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			LOGIN_GROUP_NAMEField = Convert.ToString(Item["LOGIN_GROUP_NAME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_GROUP_NAMEField"))
			{
				AliasVariables["LOGIN_GROUP_NAMEField"] = LOGIN_GROUP_NAMEField;
			}
			else
			{
				AliasVariables.Add("LOGIN_GROUP_NAMEField" ,LOGIN_GROUP_NAMEField);
			}
			LOGIN_USER_LOGINField = Convert.ToString(Item["LOGIN_USER_LOGIN"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_LOGINField"))
			{
				AliasVariables["LOGIN_USER_LOGINField"] = LOGIN_USER_LOGINField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_LOGINField" ,LOGIN_USER_LOGINField);
			}
			LOGIN_USER_COORDENACAOField = Convert.ToString(Item["LOGIN_USER_COORDENACAO"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_COORDENACAOField"))
			{
				AliasVariables["LOGIN_USER_COORDENACAOField"] = LOGIN_USER_COORDENACAOField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_COORDENACAOField" ,LOGIN_USER_COORDENACAOField);
			}
			LOGIN_USER_PASSWORDField = Convert.ToString(Item["LOGIN_USER_PASSWORD"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_PASSWORDField"))
			{
				AliasVariables["LOGIN_USER_PASSWORDField"] = LOGIN_USER_PASSWORDField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_PASSWORDField" ,LOGIN_USER_PASSWORDField);
			}
			LOGIN_USER_NAMEField = Convert.ToString(Item["LOGIN_USER_NAME"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_NAMEField"))
			{
				AliasVariables["LOGIN_USER_NAMEField"] = LOGIN_USER_NAMEField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_NAMEField" ,LOGIN_USER_NAMEField);
			}
			LOGIN_USER_OBSField = Convert.ToString(Item["LOGIN_USER_OBS"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_OBSField"))
			{
				AliasVariables["LOGIN_USER_OBSField"] = LOGIN_USER_OBSField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_OBSField" ,LOGIN_USER_OBSField);
			}
			LOGIN_USER_EMAILField = Convert.ToString(Item["LOGIN_USER_EMAIL"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_EMAILField"))
			{
				AliasVariables["LOGIN_USER_EMAILField"] = LOGIN_USER_EMAILField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_EMAILField" ,LOGIN_USER_EMAILField);
			}
			LOGIN_USER_PHONEField = Convert.ToString(Item["LOGIN_USER_PHONE"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("LOGIN_USER_PHONEField"))
			{
				AliasVariables["LOGIN_USER_PHONEField"] = LOGIN_USER_PHONEField;
			}
			else
			{
				AliasVariables.Add("LOGIN_USER_PHONEField" ,LOGIN_USER_PHONEField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("LOGIN_USER_PK", false,new string[] { MainProvider.DataProvider.Item["LOGIN_USER_LOGIN"].GetFormattedValue() });
		}

		public override string CreateProcessBeforeInsert(string FieldName)
		{
			return "";
		}

		public override void CreateProcess(int Pos)
		{
			CreateProcess("",true, Pos);
		}

		public void CreateProcess(string ProcessName, bool AllProcess)
		{
			CreateProcess(ProcessName, AllProcess, -1);
		}

		public void CreateProcess(string ProcessName, bool AllProcess, int Pos)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			GeneralDataProviderItem Item;
			Process = new Dictionary<string, Process>();
			Process.Clear();
			InitializeAlias(MainProvider.DataProvider.Item);
		}

		public override void CreateReverseProcess(int Pos, string SituationProcess)
		{
			CreateReverseProcess("", true, Pos, SituationProcess);
		}

		public void CreateReverseProcess(string ProcessName, bool AllProcess, int Pos, string SituationProcess)
		{
			string RelationField = "";
			object ValueField = "";
			object RawValue = "";
			ReverseProcess = new Dictionary<string, Process>();
			ReverseProcess.Clear();
			var situationP = new Dictionary<string, bool>();
		}

	}

}

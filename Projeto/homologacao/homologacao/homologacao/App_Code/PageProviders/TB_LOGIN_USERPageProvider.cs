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
	public class TB_LOGIN_USERPageProvider : GeneralProvider
	{
		public DBGERPROJETO_TB_LOGIN_GROUPDataProvider ComboBox2Provider;
		public DBGERPROJETO_TB_COORDENACAODataProvider ComboBox3Provider;

		public TB_LOGIN_USERPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_LOGIN_USERDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "LOGIN_USER_PK", "TB_LOGIN_USER");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox2Provider = new DBGERPROJETO_TB_LOGIN_GROUPDataProvider(MainProvider, "TB_LOGIN_GROUP", "DBGERPROJETO", "", "TB_LOGIN_USER_ComboBox2ProviderAlias");
			ComboBox2Provider.PageProvider = this;
			ComboBox2Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox3Provider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, "TB_COORDENACAO", "DBGERPROJETO", "", "TB_LOGIN_USER_ComboBox3ProviderAlias");
			ComboBox3Provider.PageProvider = this;
			ComboBox3Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_LOGIN_USERItem(MainProvider.DatabaseName);
			}
			if (Provider == ComboBox2Provider)
			{
				return new DBGERPROJETO_TB_LOGIN_GROUPItem(Provider.DataBaseName, "LOGIN_GROUP_NAME");
			}
			else if (Provider == ComboBox3Provider)
			{
				return new DBGERPROJETO_TB_COORDENACAOItem(Provider.DataBaseName, "siglaCoordenacao");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox2Provider)
			{
				return Crypt.Decripta(Item["LOGIN_GROUP_NAME"].GetValue().ToString());
			}
			else if (Provider == ComboBox3Provider)
			{
				return Item["siglaCoordenacao"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox2Provider)
			{
				return Item["LOGIN_GROUP_NAME"].GetValue();
			}
			else if (Provider == ComboBox3Provider)
			{
				return Item["siglaCoordenacao"].GetValue();
			}
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
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox2Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "LOGIN_GROUP_NAME", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox3Provider && !string.IsNullOrEmpty(Value))
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
				if (Provider == ComboBox2Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "LOGIN_GROUP_NAME";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "LOGIN_GROUP_NAME", " LOGIN_GROUP_NAME", true);
					return Total > 0;
				}
				else if (Provider == ComboBox3Provider)
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



		/// <summary>
		/// Valida se todos os campos foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da p?gina</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["LOGIN_USER_OBSField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox7", "Observações não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}

}

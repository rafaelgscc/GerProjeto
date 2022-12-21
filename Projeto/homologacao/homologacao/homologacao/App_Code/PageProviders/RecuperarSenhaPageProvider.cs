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
	public class RecuperarSenhaPageProvider : GeneralProvider
	{
		public DBGERPROJETO_TB_LOGIN_USERDataProvider AUX_TB_LOGIN_USERProvider;

		public RecuperarSenhaPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_LOGIN_USERDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "LOGIN_USER_PK", "RecuperarSenha");
			MainProvider.DataProvider.PageProvider = this;
			AUX_TB_LOGIN_USERProvider = new DBGERPROJETO_TB_LOGIN_USERDataProvider(MainProvider, "TB_LOGIN_USER", "DBGERPROJETO", "", "AUX_TB_LOGIN_USER");
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_LOGIN_USERItem(MainProvider.DatabaseName, "LOGIN_USER_LOGIN", "LOGIN_USER_COORDENACAO");
			}
			else if (Provider.Name == "AUX_TB_LOGIN_USER")
			{
				return new DBGERPROJETO_TB_LOGIN_USERItem("DBGERPROJETOSystem.Collections.ObjectModel.ObservableCollection`1[GAS.TableField]");
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
			MainProvider.SetParametersValues(AUX_TB_LOGIN_USERProvider);
			AUX_TB_LOGIN_USERProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_TB_LOGIN_USERProvider.SelectItem(1, FormPositioningEnum.First,false);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
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

}

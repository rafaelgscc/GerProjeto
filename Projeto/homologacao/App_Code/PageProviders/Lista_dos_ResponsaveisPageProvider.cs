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
	public class Lista_dos_ResponsaveisPageProvider : GeneralProvider
	{
		public Lista_dos_Responsaveis_Grid1GridDataProvider Lista_dos_Responsaveis_Grid1Provider;

		public Lista_dos_ResponsaveisPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_PARAMETRODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "", "Lista_dos_Responsaveis");
			MainProvider.DataProvider.PageProvider = this;
			Lista_dos_Responsaveis_Grid1Provider = new Lista_dos_Responsaveis_Grid1GridDataProvider(this);
			Lista_dos_Responsaveis_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Lista_dos_Responsaveis_Grid1Provider_SetRelationFields);
		}


		private void Lista_dos_Responsaveis_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Lista_dos_Responsaveis_Grid1Provider.AliasVariables = new Dictionary<string, object>();
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_PARAMETROItem(MainProvider.DatabaseName);
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
	public class Lista_dos_Responsaveis_Grid1GridDataProvider : GeneralGridProvider
	{
		public string siglaDiretoriaField;
		public string siglaCoordenacaoField;
		public string nomeResponsavelField;
		public string ramalResponsavelField;
		public string contatoResponsavelField;
		public string salaResponsavelField;
		public long codigoField;
		public string nomeSobrenomeField;
		public string usuarioCadastroField;
		public DateTime dataCadastroField;
		public string siglaSetorialField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private DBGERPROJETO_TB_RESPONSAVELDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_RESPONSAVELDataProvider;
			}
		}

		public Lista_dos_ResponsaveisPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_RESPONSAVEL"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32730"; } }
		
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

		public Lista_dos_Responsaveis_Grid1GridDataProvider(Lista_dos_ResponsaveisPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_RESPONSAVELDataProvider(this, TableName, DatabaseName, "PK_TB_RESPONSAVEL", "Lista_dos_Responsaveis_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public DBGERPROJETO_TB_RESPONSAVELItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_RESPONSAVELItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Lista_dos_Responsaveis_Grid1")
			{
				return new DBGERPROJETO_TB_RESPONSAVELItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Lista_dos_ResponsaveisPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			siglaDiretoriaField = Convert.ToString(Item["siglaDiretoria"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("siglaDiretoriaField"))
			{
				AliasVariables["siglaDiretoriaField"] = siglaDiretoriaField;
			}
			else
			{
				AliasVariables.Add("siglaDiretoriaField" ,siglaDiretoriaField);
			}
			siglaCoordenacaoField = Convert.ToString(Item["siglaCoordenacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("siglaCoordenacaoField"))
			{
				AliasVariables["siglaCoordenacaoField"] = siglaCoordenacaoField;
			}
			else
			{
				AliasVariables.Add("siglaCoordenacaoField" ,siglaCoordenacaoField);
			}
			nomeResponsavelField = Convert.ToString(Item["nomeResponsavel"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nomeResponsavelField"))
			{
				AliasVariables["nomeResponsavelField"] = nomeResponsavelField;
			}
			else
			{
				AliasVariables.Add("nomeResponsavelField" ,nomeResponsavelField);
			}
			ramalResponsavelField = Convert.ToString(Item["ramalResponsavel"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("ramalResponsavelField"))
			{
				AliasVariables["ramalResponsavelField"] = ramalResponsavelField;
			}
			else
			{
				AliasVariables.Add("ramalResponsavelField" ,ramalResponsavelField);
			}
			contatoResponsavelField = Convert.ToString(Item["contatoResponsavel"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("contatoResponsavelField"))
			{
				AliasVariables["contatoResponsavelField"] = contatoResponsavelField;
			}
			else
			{
				AliasVariables.Add("contatoResponsavelField" ,contatoResponsavelField);
			}
			salaResponsavelField = Convert.ToString(Item["salaResponsavel"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("salaResponsavelField"))
			{
				AliasVariables["salaResponsavelField"] = salaResponsavelField;
			}
			else
			{
				AliasVariables.Add("salaResponsavelField" ,salaResponsavelField);
			}
			codigoField = Convert.ToInt64(Item["codigo"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("codigoField"))
			{
				AliasVariables["codigoField"] = codigoField;
			}
			else
			{
				AliasVariables.Add("codigoField" ,codigoField);
			}
			nomeSobrenomeField = Convert.ToString(Item["nomeSobrenome"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nomeSobrenomeField"))
			{
				AliasVariables["nomeSobrenomeField"] = nomeSobrenomeField;
			}
			else
			{
				AliasVariables.Add("nomeSobrenomeField" ,nomeSobrenomeField);
			}
			usuarioCadastroField = Convert.ToString(Item["usuarioCadastro"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("usuarioCadastroField"))
			{
				AliasVariables["usuarioCadastroField"] = usuarioCadastroField;
			}
			else
			{
				AliasVariables.Add("usuarioCadastroField" ,usuarioCadastroField);
			}
			dataCadastroField = Convert.ToDateTime(Item["dataCadastro"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("dataCadastroField"))
			{
				AliasVariables["dataCadastroField"] = dataCadastroField;
			}
			else
			{
				AliasVariables.Add("dataCadastroField" ,dataCadastroField);
			}
			siglaSetorialField = Convert.ToString(Item["siglaSetorial"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("siglaSetorialField"))
			{
				AliasVariables["siglaSetorialField"] = siglaSetorialField;
			}
			else
			{
				AliasVariables.Add("siglaSetorialField" ,siglaSetorialField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_RESPONSAVEL", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "codigo") });
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

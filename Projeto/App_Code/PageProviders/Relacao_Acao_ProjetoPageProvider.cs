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
	public class Relacao_Acao_ProjetoPageProvider : GeneralProvider
	{
		public RelacaoAcaoProjeto_Grid1GridDataProvider RelacaoAcaoProjeto_Grid1Provider;

		public Relacao_Acao_ProjetoPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_PROJETODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_PROJETO", "Relacao_Acao_Projeto");
			MainProvider.DataProvider.PageProvider = this;
			RelacaoAcaoProjeto_Grid1Provider = new RelacaoAcaoProjeto_Grid1GridDataProvider(this);
			RelacaoAcaoProjeto_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(RelacaoAcaoProjeto_Grid1Provider_SetRelationFields);
		}


		private void RelacaoAcaoProjeto_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				RelacaoAcaoProjeto_Grid1Provider.AliasVariables = new Dictionary<string, object>();
				RelacaoAcaoProjeto_Grid1Provider.AliasVariables.Add("nomeProjetoField", MainProvider.DataProvider.Item["nomeProjeto"].Value);
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_PROJETOItem(MainProvider.DatabaseName);
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
			MainProvider.DataProvider.FindRecord("PK_TB_PROJETO", false,new string[] { MainProvider.DataProvider.Dao.GetIdentity(MainProvider.TableName , "codigo") });
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
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nomeProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox1", "Nome do Projeto não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class RelacaoAcaoProjeto_Grid1GridDataProvider : GeneralGridProvider
	{
		public long projetoField;
		public int itemProjetoField;
		public string nomeAcaoField;
		public string statusAcaoField;
		public string siglaCoordenacaoField;
		public DateTime inicioPrevistoField;
		public DateTime inicioRealizadoField;
		public DateTime terminoPrevistoField;
		public DateTime terminoRealizadoField;
		public double percentualExecutadoField;
		public string situacaoField;
		public string nomeSobrenomeField;
		public string responsavelSubstitutoField;
		public string observacaoField;
		public string usuarioCadastroField;
		public DateTime dataCadastroField;
		public string siglaSetorialField;
		public double custoAcaoField;
		public int DiasPrevistosField;
		public int DiasRealizadosField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 1;
		}
		private DBGERPROJETO_TB_ITENS_PROJETODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_ITENS_PROJETODataProvider;
			}
		}

		public Relacao_Acao_ProjetoPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_ITENS_PROJETO"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32763"; } }
		
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

		public RelacaoAcaoProjeto_Grid1GridDataProvider(Relacao_Acao_ProjetoPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(this, TableName, DatabaseName, "PK_TB_ITENS_PROJETO", "RelacaoAcaoProjeto_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
		}
		public DBGERPROJETO_TB_ITENS_PROJETOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_ITENS_PROJETOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "RelacaoAcaoProjeto_Grid1")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Relacao_Acao_ProjetoPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			projetoField = Convert.ToInt64(Item["projeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("projetoField"))
			{
				AliasVariables["projetoField"] = projetoField;
			}
			else
			{
				AliasVariables.Add("projetoField" ,projetoField);
			}
			itemProjetoField = Convert.ToInt32(Item["itemProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("itemProjetoField"))
			{
				AliasVariables["itemProjetoField"] = itemProjetoField;
			}
			else
			{
				AliasVariables.Add("itemProjetoField" ,itemProjetoField);
			}
			nomeAcaoField = Convert.ToString(Item["nomeAcao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nomeAcaoField"))
			{
				AliasVariables["nomeAcaoField"] = nomeAcaoField;
			}
			else
			{
				AliasVariables.Add("nomeAcaoField" ,nomeAcaoField);
			}
			statusAcaoField = Convert.ToString(Item["statusAcao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("statusAcaoField"))
			{
				AliasVariables["statusAcaoField"] = statusAcaoField;
			}
			else
			{
				AliasVariables.Add("statusAcaoField" ,statusAcaoField);
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
			inicioPrevistoField = Convert.ToDateTime(Item["inicioPrevisto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("inicioPrevistoField"))
			{
				AliasVariables["inicioPrevistoField"] = inicioPrevistoField;
			}
			else
			{
				AliasVariables.Add("inicioPrevistoField" ,inicioPrevistoField);
			}
			inicioRealizadoField = Convert.ToDateTime(Item["inicioRealizado"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("inicioRealizadoField"))
			{
				AliasVariables["inicioRealizadoField"] = inicioRealizadoField;
			}
			else
			{
				AliasVariables.Add("inicioRealizadoField" ,inicioRealizadoField);
			}
			terminoPrevistoField = Convert.ToDateTime(Item["terminoPrevisto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("terminoPrevistoField"))
			{
				AliasVariables["terminoPrevistoField"] = terminoPrevistoField;
			}
			else
			{
				AliasVariables.Add("terminoPrevistoField" ,terminoPrevistoField);
			}
			terminoRealizadoField = Convert.ToDateTime(Item["terminoRealizado"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("terminoRealizadoField"))
			{
				AliasVariables["terminoRealizadoField"] = terminoRealizadoField;
			}
			else
			{
				AliasVariables.Add("terminoRealizadoField" ,terminoRealizadoField);
			}
			try{percentualExecutadoField = Convert.ToDouble(Item["percentualExecutado"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("percentualExecutadoField"))
			{
				AliasVariables["percentualExecutadoField"] = percentualExecutadoField;
			}
			else
			{
				AliasVariables.Add("percentualExecutadoField" ,percentualExecutadoField);
			}
			situacaoField = Convert.ToString(Item["situacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("situacaoField"))
			{
				AliasVariables["situacaoField"] = situacaoField;
			}
			else
			{
				AliasVariables.Add("situacaoField" ,situacaoField);
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
			responsavelSubstitutoField = Convert.ToString(Item["responsavelSubstituto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("responsavelSubstitutoField"))
			{
				AliasVariables["responsavelSubstitutoField"] = responsavelSubstitutoField;
			}
			else
			{
				AliasVariables.Add("responsavelSubstitutoField" ,responsavelSubstitutoField);
			}
			observacaoField = Convert.ToString(Item["observacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("observacaoField"))
			{
				AliasVariables["observacaoField"] = observacaoField;
			}
			else
			{
				AliasVariables.Add("observacaoField" ,observacaoField);
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
			try{custoAcaoField = Convert.ToDouble(Item["custoAcao"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("custoAcaoField"))
			{
				AliasVariables["custoAcaoField"] = custoAcaoField;
			}
			else
			{
				AliasVariables.Add("custoAcaoField" ,custoAcaoField);
			}
			DiasPrevistosField = Convert.ToInt32(Item["DiasPrevistos"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DiasPrevistosField"))
			{
				AliasVariables["DiasPrevistosField"] = DiasPrevistosField;
			}
			else
			{
				AliasVariables.Add("DiasPrevistosField" ,DiasPrevistosField);
			}
			DiasRealizadosField = Convert.ToInt32(Item["DiasRealizados"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DiasRealizadosField"))
			{
				AliasVariables["DiasRealizadosField"] = DiasRealizadosField;
			}
			else
			{
				AliasVariables.Add("DiasRealizadosField" ,DiasRealizadosField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_ITENS_PROJETO", false,new string[] { MainProvider.DataProvider.Item["projeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue() });
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

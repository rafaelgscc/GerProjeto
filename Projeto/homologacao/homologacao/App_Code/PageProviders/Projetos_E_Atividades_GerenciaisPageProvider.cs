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
	public class Projetos_E_Atividades_GerenciaisPageProvider : GeneralProvider
	{
		public TB_ITENS_PROJETO2_Grid2GridDataProvider TB_ITENS_PROJETO2_Grid2Provider;
		public DBGERPROJETO_TB_PROCESSOSDataProvider AUX_TB_ITENS_PROJETO3_TB_PROCESSOSProvider;

		public Projetos_E_Atividades_GerenciaisPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_ITENS_PROJETO", "Projetos_E_Atividades_Gerenciais");
			MainProvider.DataProvider.PageProvider = this;
			AUX_TB_ITENS_PROJETO3_TB_PROCESSOSProvider = new DBGERPROJETO_TB_PROCESSOSDataProvider(MainProvider, "TB_PROCESSOS", "DBGERPROJETO", "PK_TB_PROCESSOS", "AUX_TB_ITENS_PROJETO3_TB_PROCESSOS");
			TB_ITENS_PROJETO2_Grid2Provider = new TB_ITENS_PROJETO2_Grid2GridDataProvider(this);
			TB_ITENS_PROJETO2_Grid2Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_ITENS_PROJETO2_Grid2Provider_SetRelationFields);
			TB_ITENS_PROJETO2_Grid2Provider.SetRelationParameters += new GeneralGridProvider.SetRelationParametersEventHandler(TB_ITENS_PROJETO2_Grid2Provider_SetRelationParameters);
		}


		private void TB_ITENS_PROJETO2_Grid2Provider_SetRelationParameters(object sender)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_ITENS_PROJETO2_Grid2Provider.DataProvider.Parameters["projeto"].Parameter.SetValue(MainProvider.DataProvider.Item["projeto"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.DataProvider.Parameters["itemProjeto"].Parameter.SetValue(MainProvider.DataProvider.Item["itemProjeto"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void TB_ITENS_PROJETO2_Grid2Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Item.SetFieldValue(Item["projeto"], MainProvider.DataProvider.Item["projeto"].Value);
				Item.SetFieldValue(Item["itemProjeto"], MainProvider.DataProvider.Item["itemProjeto"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables = new Dictionary<string, object>();
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("projetoField", MainProvider.DataProvider.Item["projeto"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("itemProjetoField", MainProvider.DataProvider.Item["itemProjeto"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("nomeAcaoField", MainProvider.DataProvider.Item["nomeAcao"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("siglaCoordenacaoField", MainProvider.DataProvider.Item["siglaCoordenacao"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("siglaSetorialField", MainProvider.DataProvider.Item["siglaSetorial"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("DiasPrevistosField", MainProvider.DataProvider.Item["DiasPrevistos"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("nomeSobrenomeField", MainProvider.DataProvider.Item["nomeSobrenome"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("percentualExecutadoField", MainProvider.DataProvider.Item["percentualExecutado"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("statusAcaoField", MainProvider.DataProvider.Item["statusAcao"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("inicioPrevistoField", MainProvider.DataProvider.Item["inicioPrevisto"].Value);
				TB_ITENS_PROJETO2_Grid2Provider.AliasVariables.Add("terminoPrevistoField", MainProvider.DataProvider.Item["terminoPrevisto"].Value);
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_ITENS_PROJETOItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "AUX_TB_ITENS_PROJETO3_TB_PROCESSOS")
			{
				return new DBGERPROJETO_TB_PROCESSOSItem("DBGERPROJETOSystem.Collections.ObjectModel.ObservableCollection`1[GAS.TableField]");
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
			MainProvider.SetParametersValues(AUX_TB_ITENS_PROJETO3_TB_PROCESSOSProvider);
			AUX_TB_ITENS_PROJETO3_TB_PROCESSOSProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_TB_ITENS_PROJETO3_TB_PROCESSOSProvider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["inicioPrevistoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker1", "Início Previsto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["terminoPrevistoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker2", "Fim Previsto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["statusAcaoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox11", "Data do Cadastro não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class TB_ITENS_PROJETO2_Grid2GridDataProvider : GeneralGridProvider
	{
		public int itemProcessoField;
		public string nomeProcessoField;
		public DateTime inicioPrevistoField;
		public DateTime terminoPrevistoField;
		public string siglaSetorialField;
		public string nomeSobrenomeField;
		public double percentualExecutadoField;
		public string situacaoField;
		public string situacaoProjetoField;
		public long projetoField;
		public int itemProjetoField;
		public DateTime inicioRealizadoField;
		public DateTime terminoRealizadoField;
		public string siglaCoordenacaoField;
		public int DiasPrevistosField;
		public int DiasRealizadosField;
		public string responsavelSubstitutoField;
		public DateTime dataCadastroField;
		public string usuarioCadastroField;

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 2;
		}
		private DBGERPROJETO_TB_PROCESSOSDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_PROCESSOSDataProvider;
			}
		}

		public Projetos_E_Atividades_GerenciaisPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_PROCESSOS"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32778"; } }
		
		public override void SetOldParameters(GeneralDataProviderItem Item)
		{
		}

		/// <summary>
		/// Valida se todos os campos do GRID foram preenchidos corretamente
		/// </summary>
		/// <param name="provider">Provider que vai ser usado para carregar os itens da página</param>
		public override bool Validate(GeneralDataProviderItem ProviderItem)
		{
			bool Accepted = false;
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["terminoPrevistoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn11", "Término Previsto não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_ITENS_PROJETO2_Grid2GridDataProvider(Projetos_E_Atividades_GerenciaisPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_PROCESSOSDataProvider(this, TableName, DatabaseName, "PK_TB_PROCESSOS", "TB_ITENS_PROJETO2_Grid2");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public DBGERPROJETO_TB_PROCESSOSItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_PROCESSOSItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_ITENS_PROJETO2_Grid2")
			{
				return new DBGERPROJETO_TB_PROCESSOSItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Projetos_E_Atividades_GerenciaisPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
			}
			itemProcessoField = Convert.ToInt32(Item["itemProcesso"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("itemProcessoField"))
			{
				AliasVariables["itemProcessoField"] = itemProcessoField;
			}
			else
			{
				AliasVariables.Add("itemProcessoField" ,itemProcessoField);
			}
			nomeProcessoField = Convert.ToString(Item["nomeProcesso"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nomeProcessoField"))
			{
				AliasVariables["nomeProcessoField"] = nomeProcessoField;
			}
			else
			{
				AliasVariables.Add("nomeProcessoField" ,nomeProcessoField);
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
			terminoPrevistoField = Convert.ToDateTime(Item["terminoPrevisto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("terminoPrevistoField"))
			{
				AliasVariables["terminoPrevistoField"] = terminoPrevistoField;
			}
			else
			{
				AliasVariables.Add("terminoPrevistoField" ,terminoPrevistoField);
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
			nomeSobrenomeField = Convert.ToString(Item["nomeSobrenome"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nomeSobrenomeField"))
			{
				AliasVariables["nomeSobrenomeField"] = nomeSobrenomeField;
			}
			else
			{
				AliasVariables.Add("nomeSobrenomeField" ,nomeSobrenomeField);
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
			situacaoProjetoField = Convert.ToString(Item["situacaoProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("situacaoProjetoField"))
			{
				AliasVariables["situacaoProjetoField"] = situacaoProjetoField;
			}
			else
			{
				AliasVariables.Add("situacaoProjetoField" ,situacaoProjetoField);
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
			inicioRealizadoField = Convert.ToDateTime(Item["inicioRealizado"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("inicioRealizadoField"))
			{
				AliasVariables["inicioRealizadoField"] = inicioRealizadoField;
			}
			else
			{
				AliasVariables.Add("inicioRealizadoField" ,inicioRealizadoField);
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
			siglaCoordenacaoField = Convert.ToString(Item["siglaCoordenacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("siglaCoordenacaoField"))
			{
				AliasVariables["siglaCoordenacaoField"] = siglaCoordenacaoField;
			}
			else
			{
				AliasVariables.Add("siglaCoordenacaoField" ,siglaCoordenacaoField);
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
			responsavelSubstitutoField = Convert.ToString(Item["responsavelSubstituto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("responsavelSubstitutoField"))
			{
				AliasVariables["responsavelSubstitutoField"] = responsavelSubstitutoField;
			}
			else
			{
				AliasVariables.Add("responsavelSubstitutoField" ,responsavelSubstitutoField);
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
			usuarioCadastroField = Convert.ToString(Item["usuarioCadastro"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("usuarioCadastroField"))
			{
				AliasVariables["usuarioCadastroField"] = usuarioCadastroField;
			}
			else
			{
				AliasVariables.Add("usuarioCadastroField" ,usuarioCadastroField);
			}
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_PROCESSOS", false,new string[] { MainProvider.DataProvider.Item["projeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProcesso"].GetFormattedValue() });
		}

		public override void PositionParentsProvider()
        {
			ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
            ParentPageProvider.MainProvider.DataProvider.SelectItem(ParentPageProvider.MainProvider.DataProvider.PageNumber, FormPositioningEnum.Current);
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

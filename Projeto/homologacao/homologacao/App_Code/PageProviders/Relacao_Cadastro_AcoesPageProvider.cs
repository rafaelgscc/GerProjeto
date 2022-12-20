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
	public class Relacao_Cadastro_AcoesPageProvider : GeneralProvider
	{
		public TB_PROJETO1_Grid1GridDataProvider TB_PROJETO1_Grid1Provider;
		public DBGERPROJETO_TB_DIRETORIADataProvider ComboBox3Provider;
		public DBGERPROJETO_TB_COORDENACAODataProvider ComboBox4Provider;
		public List<RadComboBoxDataItem> ComboBox1Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "SIM"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem2").ToString(), "NÃO"),
				};
			}
		}
		public List<RadComboBoxDataItem> ComboBox2Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem5").ToString(), "ATIVO"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)MainProvider).AppRelativeVirtualPath, "GComboBoxItem6").ToString(), "SUSPENSO"),
				};
			}
		}
		

		public Relacao_Cadastro_AcoesPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_PROJETODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_PROJETO", "Relacao_Cadastro_Acoes");
			MainProvider.DataProvider.PageProvider = this;
			ComboBox3Provider = new DBGERPROJETO_TB_DIRETORIADataProvider(MainProvider, "TB_DIRETORIA", "DBGERPROJETO", "", "Relacao_Cadastro_Acoes_ComboBox3ProviderAlias");
			ComboBox3Provider.PageProvider = this;
			ComboBox3Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox4Provider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, "TB_COORDENACAO", "DBGERPROJETO", "", "Relacao_Cadastro_Acoes_ComboBox4ProviderAlias");
			ComboBox4Provider.PageProvider = this;
			ComboBox4Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			TB_PROJETO1_Grid1Provider = new TB_PROJETO1_Grid1GridDataProvider(this);
			TB_PROJETO1_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(TB_PROJETO1_Grid1Provider_SetRelationFields);
			TB_PROJETO1_Grid1Provider.SetRelationParameters += new GeneralGridProvider.SetRelationParametersEventHandler(TB_PROJETO1_Grid1Provider_SetRelationParameters);
		}


		private void TB_PROJETO1_Grid1Provider_SetRelationParameters(object sender)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				TB_PROJETO1_Grid1Provider.DataProvider.Parameters["projeto"].Parameter.SetValue(MainProvider.DataProvider.Item["codigo"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void TB_PROJETO1_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Item.SetFieldValue(Item["projeto"], MainProvider.DataProvider.Item["codigo"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables = new Dictionary<string, object>();
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("nomeProjetoField", MainProvider.DataProvider.Item["nomeProjeto"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("codigoField", MainProvider.DataProvider.Item["codigo"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("DiasDeProjetoField", MainProvider.DataProvider.Item["DiasDeProjeto"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("situacaoField", MainProvider.DataProvider.Item["situacao"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("percentualExecutadoField", MainProvider.DataProvider.Item["percentualExecutado"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("DiretrizField", MainProvider.DataProvider.Item["Diretriz"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("statusProjetoField", MainProvider.DataProvider.Item["statusProjeto"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("siglaDiretoriaField", MainProvider.DataProvider.Item["siglaDiretoria"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("siglaCoordenacaoField", MainProvider.DataProvider.Item["siglaCoordenacao"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("inicioPrevistoField", MainProvider.DataProvider.Item["inicioPrevisto"].Value);
				TB_PROJETO1_Grid1Provider.AliasVariables.Add("terminoPrevistoField", MainProvider.DataProvider.Item["terminoPrevisto"].Value);
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
			if (Provider == ComboBox3Provider)
			{
				return new DBGERPROJETO_TB_DIRETORIAItem(Provider.DataBaseName, "siglaDiretoria");
			}
			else if (Provider == ComboBox4Provider)
			{
				return new DBGERPROJETO_TB_COORDENACAOItem(Provider.DataBaseName, "siglaCoordenacao");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox3Provider)
			{
				return Item["siglaDiretoria"].GetValue().ToString();
			}
			else if (Provider == ComboBox4Provider)
			{
				return Item["siglaCoordenacao"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == ComboBox3Provider)
			{
				return Item["siglaDiretoria"].GetValue();
			}
			else if (Provider == ComboBox4Provider)
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
		public override GeneralDataProviderItem GetComboItem(GeneralDataProvider Provider, string Value)
		{
			try
			{
				var Dao = Provider.Dao;
				if (Provider == ComboBox3Provider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaDiretoria", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox4Provider && !string.IsNullOrEmpty(Value))
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
				if (Provider == ComboBox3Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "siglaDiretoria";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaDiretoria", " siglaDiretoria", false);
					return Total > 0;
				}
				else if (Provider == ComboBox4Provider)
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["nomeProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:RadTextBox1", "Nome do Projeto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["DiretrizField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox1", "Diretriz não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["statusProjetoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox2", "Status do Projeto não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["siglaDiretoriaField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox3", "Sigla da Diretoria não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["siglaCoordenacaoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:ComboBox4", "Coordenação não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class TB_PROJETO1_Grid1GridDataProvider : GeneralGridProvider
	{
		public int itemProjetoField;
		public string nomeAcaoField;
		public DateTime inicioPrevistoField;
		public DateTime terminoPrevistoField;
		public int DiasPrevistosField;
		public double percentualExecutadoField;
		public DateTime terminoRealizadoField;
		public string nomeSobrenomeField;
		public string situacaoField;
		public long projetoField;
		public string responsavelSubstitutoField;
		public string observacaoField;
		public string usuarioCadastroField;
		public DateTime dataCadastroField;
		public string siglaCoordenacaoField;
		public string siglaSetorialField;
		public string statusAcaoField;
		public DateTime inicioRealizadoField;
		public double custoAcaoField;
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

		public Relacao_Cadastro_AcoesPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_ITENS_PROJETO"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32736"; } }
		
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["inicioPrevistoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn3", "Data de Inicio não pode ser vazio!");}
			try
			{
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["terminoPrevistoField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:GridColumn4", "Data do Fim não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}		
		
		#endregion

		public TB_PROJETO1_Grid1GridDataProvider(Relacao_Cadastro_AcoesPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(this, TableName, DatabaseName, "PK_TB_ITENS_PROJETO", "TB_PROJETO1_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public DBGERPROJETO_TB_ITENS_PROJETOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_ITENS_PROJETOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "TB_PROJETO1_Grid1")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Relacao_Cadastro_AcoesPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
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
			DiasPrevistosField = Convert.ToInt32(Item["DiasPrevistos"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DiasPrevistosField"))
			{
				AliasVariables["DiasPrevistosField"] = DiasPrevistosField;
			}
			else
			{
				AliasVariables.Add("DiasPrevistosField" ,DiasPrevistosField);
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
			terminoRealizadoField = Convert.ToDateTime(Item["terminoRealizado"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("terminoRealizadoField"))
			{
				AliasVariables["terminoRealizadoField"] = terminoRealizadoField;
			}
			else
			{
				AliasVariables.Add("terminoRealizadoField" ,terminoRealizadoField);
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
			situacaoField = Convert.ToString(Item["situacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("situacaoField"))
			{
				AliasVariables["situacaoField"] = situacaoField;
			}
			else
			{
				AliasVariables.Add("situacaoField" ,situacaoField);
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
			siglaCoordenacaoField = Convert.ToString(Item["siglaCoordenacao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("siglaCoordenacaoField"))
			{
				AliasVariables["siglaCoordenacaoField"] = siglaCoordenacaoField;
			}
			else
			{
				AliasVariables.Add("siglaCoordenacaoField" ,siglaCoordenacaoField);
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
			statusAcaoField = Convert.ToString(Item["statusAcao"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("statusAcaoField"))
			{
				AliasVariables["statusAcaoField"] = statusAcaoField;
			}
			else
			{
				AliasVariables.Add("statusAcaoField" ,statusAcaoField);
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
			try{custoAcaoField = Convert.ToDouble(Item["custoAcao"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("custoAcaoField"))
			{
				AliasVariables["custoAcaoField"] = custoAcaoField;
			}
			else
			{
				AliasVariables.Add("custoAcaoField" ,custoAcaoField);
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

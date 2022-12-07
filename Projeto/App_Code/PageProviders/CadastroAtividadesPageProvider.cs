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
	public class CadastroAtividadesPageProvider : GeneralProvider
	{
		public CadastroAtividades_Grid1GridDataProvider CadastroAtividades_Grid1Provider;
		public DBGERPROJETO_TB_ITENS_PROJETODataProvider AUX_CadastroAtividades_TB_ITENS_PROJETOProvider;
		public DBGERPROJETO_TB_COORDENACAODataProvider cmbSiglaCoordenacaoProvider;
		public DBGERPROJETO_TB_SETORIALDataProvider cmbSiglaSetorialProvider;
		public DBGERPROJETO_TB_RESPONSAVELDataProvider ComboBox3Provider;
		public DBGERPROJETO_TB_RESPONSAVELDataProvider ComboBox4Provider;

		public CadastroAtividadesPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_PROCESSOSDataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_PROCESSOS", "CadastroAtividades");
			MainProvider.DataProvider.PageProvider = this;
			AUX_CadastroAtividades_TB_ITENS_PROJETOProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(MainProvider, "TB_ITENS_PROJETO", "DBGERPROJETO", "PK_TB_ITENS_PROJETO", "AUX_CadastroAtividades_TB_ITENS_PROJETO");
			cmbSiglaCoordenacaoProvider = new DBGERPROJETO_TB_COORDENACAODataProvider(MainProvider, "TB_COORDENACAO", "DBGERPROJETO", "", "CadastroAtividades_cmbSiglaCoordenacaoProviderAlias");
			cmbSiglaCoordenacaoProvider.PageProvider = this;
			cmbSiglaCoordenacaoProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			cmbSiglaSetorialProvider = new DBGERPROJETO_TB_SETORIALDataProvider(MainProvider, "TB_SETORIAL", "DBGERPROJETO", "", "CadastroAtividades_cmbSiglaSetorialProviderAlias");
			cmbSiglaSetorialProvider.PageProvider = this;
			cmbSiglaSetorialProvider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox3Provider = new DBGERPROJETO_TB_RESPONSAVELDataProvider(MainProvider, "TB_RESPONSAVEL", "DBGERPROJETO", "", "CadastroAtividades_ComboBox3ProviderAlias");
			ComboBox3Provider.PageProvider = this;
			ComboBox3Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			ComboBox4Provider = new DBGERPROJETO_TB_RESPONSAVELDataProvider(MainProvider, "TB_RESPONSAVEL", "DBGERPROJETO", "", "CadastroAtividades_ComboBox4ProviderAlias");
			ComboBox4Provider.PageProvider = this;
			ComboBox4Provider.CreatingParameters += GeneralDataProvider.GeneralCreatingParameters;
			CadastroAtividades_Grid1Provider = new CadastroAtividades_Grid1GridDataProvider(this);
			CadastroAtividades_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(CadastroAtividades_Grid1Provider_SetRelationFields);
			CadastroAtividades_Grid1Provider.SetRelationParameters += new GeneralGridProvider.SetRelationParametersEventHandler(CadastroAtividades_Grid1Provider_SetRelationParameters);
		}


		private void CadastroAtividades_Grid1Provider_SetRelationParameters(object sender)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				CadastroAtividades_Grid1Provider.DataProvider.Parameters["projeto"].Parameter.SetValue(MainProvider.DataProvider.Item["projeto"].Value);
				CadastroAtividades_Grid1Provider.DataProvider.Parameters["itemProjeto"].Parameter.SetValue(MainProvider.DataProvider.Item["itemProjeto"].Value);
				CadastroAtividades_Grid1Provider.DataProvider.Parameters["itemProcesso"].Parameter.SetValue(MainProvider.DataProvider.Item["itemProcesso"].Value);
			}
			catch (Exception)
			{
			}
		}

		private void CadastroAtividades_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Item.SetFieldValue(Item["projeto"], MainProvider.DataProvider.Item["projeto"].Value);
				Item.SetFieldValue(Item["itemProjeto"], MainProvider.DataProvider.Item["itemProjeto"].Value);
				Item.SetFieldValue(Item["itemProcesso"], MainProvider.DataProvider.Item["itemProcesso"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables = new Dictionary<string, object>();
				CadastroAtividades_Grid1Provider.AliasVariables.Add("projetoField", MainProvider.DataProvider.Item["projeto"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("itemProjetoField", MainProvider.DataProvider.Item["itemProjeto"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("itemProcessoField", MainProvider.DataProvider.Item["itemProcesso"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("nomeProcessoField", MainProvider.DataProvider.Item["nomeProcesso"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("DiasPrevistosField", MainProvider.DataProvider.Item["DiasPrevistos"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("DiasRealizadosField", MainProvider.DataProvider.Item["DiasRealizados"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("situacaoField", MainProvider.DataProvider.Item["situacao"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("percentualExecutadoField", MainProvider.DataProvider.Item["percentualExecutado"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("usuarioCadastroField", MainProvider.DataProvider.Item["usuarioCadastro"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("siglaCoordenacaoField", MainProvider.DataProvider.Item["siglaCoordenacao"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("siglaSetorialField", MainProvider.DataProvider.Item["siglaSetorial"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("nomeSobrenomeField", MainProvider.DataProvider.Item["nomeSobrenome"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("responsavelSubstitutoField", MainProvider.DataProvider.Item["responsavelSubstituto"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("inicioPrevistoField", MainProvider.DataProvider.Item["inicioPrevisto"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("terminoPrevistoField", MainProvider.DataProvider.Item["terminoPrevisto"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("inicioRealizadoField", MainProvider.DataProvider.Item["inicioRealizado"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("terminoRealizadoField", MainProvider.DataProvider.Item["terminoRealizado"].Value);
				CadastroAtividades_Grid1Provider.AliasVariables.Add("dataCadastroField", MainProvider.DataProvider.Item["dataCadastro"].Value);
			}
			catch (Exception)
			{
			}
		}



		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider == MainProvider.DataProvider)
			{ 
				return new DBGERPROJETO_TB_PROCESSOSItem(MainProvider.DatabaseName);
			}
			else if (Provider.Name == "AUX_CadastroAtividades_TB_ITENS_PROJETO")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem("DBGERPROJETOSystem.Collections.ObjectModel.ObservableCollection`1[GAS.TableField]");
			}
			if (Provider == cmbSiglaCoordenacaoProvider)
			{
				return new DBGERPROJETO_TB_COORDENACAOItem(Provider.DataBaseName, "siglaCoordenacao");
			}
			else if (Provider == cmbSiglaSetorialProvider)
			{
				return new DBGERPROJETO_TB_SETORIALItem(Provider.DataBaseName, "siglaSetorial");
			}
			else if (Provider == ComboBox3Provider)
			{
				return new DBGERPROJETO_TB_RESPONSAVELItem(Provider.DataBaseName, "nomeSobrenome");
			}
			else if (Provider == ComboBox4Provider)
			{
				return new DBGERPROJETO_TB_RESPONSAVELItem(Provider.DataBaseName, "nomeSobrenome");
			}
			return null;
		}

		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == cmbSiglaCoordenacaoProvider)
			{
				return Item["siglaCoordenacao"].GetValue().ToString();
			}
			else if (Provider == cmbSiglaSetorialProvider)
			{
				return Item["siglaSetorial"].GetValue().ToString();
			}
			else if (Provider == ComboBox3Provider)
			{
				return Item["nomeSobrenome"].GetValue().ToString();
			}
			else if (Provider == ComboBox4Provider)
			{
				return Item["nomeSobrenome"].GetValue().ToString();
			}
		return "";
		}
		
		public override object GetItemValue(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
			if (Provider == cmbSiglaCoordenacaoProvider)
			{
				return Item["siglaCoordenacao"].GetValue();
			}
			else if (Provider == cmbSiglaSetorialProvider)
			{
				return Item["siglaSetorial"].GetValue();
			}
			else if (Provider == ComboBox3Provider)
			{
				return Item["nomeSobrenome"].GetValue();
			}
			else if (Provider == ComboBox4Provider)
			{
				return Item["nomeSobrenome"].GetValue();
			}
		return null;
		}

		public override void FillAuxiliarTables()
		{
			MainProvider.SetParametersValues(AUX_CadastroAtividades_TB_ITENS_PROJETOProvider);
			AUX_CadastroAtividades_TB_ITENS_PROJETOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_CadastroAtividades_TB_ITENS_PROJETOProvider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
		}
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_PROCESSOS", false,new string[] { MainProvider.DataProvider.Item["projeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProcesso"].GetFormattedValue() });
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
				if (Provider == cmbSiglaCoordenacaoProvider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaCoordenacao", Value } });
					return Provider.Item;
				}
			
				else if (Provider == cmbSiglaSetorialProvider && !string.IsNullOrEmpty(Value))
				{
					Provider.FindRecord(new Dictionary<string, object>() { { "siglaSetorial", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox3Provider && !string.IsNullOrEmpty(Value))
				{
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(AliasVariables["siglaCoordenacaoField"].ToString(), FieldType.Text);
					}
					catch { }
					Provider.FindRecord(new Dictionary<string, object>() { { "nomeSobrenome", Value } });
					return Provider.Item;
				}
			
				else if (Provider == ComboBox4Provider && !string.IsNullOrEmpty(Value))
				{
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(AliasVariables["siglaCoordenacaoField"].ToString(), FieldType.Text);
					}
					catch { }
					Provider.FindRecord(new Dictionary<string, object>() { { "nomeSobrenome", Value } });
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
				if (Provider == cmbSiglaCoordenacaoProvider)
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
				else if (Provider == cmbSiglaSetorialProvider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "siglaSetorial";
					}
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "siglaSetorial", " siglaSetorial", false);
					return Total > 0;
				}
				else if (Provider == ComboBox3Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "nomeSobrenome";
					}
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(ClientFields["cmbSiglaCoordenacao"].ToString(), FieldType.Text);
					}
					catch { }
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "nomeSobrenome", " nomeSobrenome", false);
					return Total > 0;
				}
				else if (Provider == ComboBox4Provider)
				{
					if (AllowFilter)
					{
						Provider.FiltroAtual = TextFilter;
						Provider.FilterFields = "nomeSobrenome";
					}
					try
					{
						Provider.StartFilter = Provider.Dao.PoeColAspas("siglaCoordenacao") + " = " + Provider.Dao.ToSql(ClientFields["cmbSiglaCoordenacao"].ToString(), FieldType.Text);
					}
					catch { }
					int Total;
					var data = Provider.SelectItems(0, 100, out Total);
					var dt = Utility.FillComboBoxItems(ComboBox, 100, data, "nomeSobrenome", " nomeSobrenome", false);
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
				Accepted =(ServerValidation.CheckNotEmpty(AliasVariables["dataCadastroField"]));
			}
			catch (Exception)
			{
				Accepted = false;
			}
			if (!Accepted) { ProviderItem.Errors.Add("ServerValidationError:DatePicker5", "Data do Cadastro não pode ser vazio!");}
			return (ProviderItem.Errors.Count == 0);
		}
		
		private int DiferencaPrevista()
			// Rotina para cálculo de dias do projeto, baseado na data de início previsto com a data de fim previsto
		{
			TimeSpan Diferenca = Convert.ToDateTime(AliasVariables["terminoPrevistoField"]) - Convert.ToDateTime(AliasVariables["inicioPrevistoField"]);
			return Diferenca.Days;
		}

	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class CadastroAtividades_Grid1GridDataProvider : GeneralGridProvider
	{
		public long projetoField;
		public int itemProjetoField;
		public int itemProcessoField;
		public DateTime dataLancamentoField;
		public int JustificativaField;
		public double percentualExecutadoField;
		public string observacaoField;
		public string usuarioCadastroField;
		public DateTime dataCadastroField;
		
		public List<RadComboBoxDataItem> GridColumn5Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "1"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "2"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "GComboBoxItem1").ToString(), "3"),
				};
			}
		}

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 2;
		}
		private DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider;
			}
		}

		public CadastroAtividadesPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_HIST_EXECUCAO_ATIVIDADE"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32776"; } }
		
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

		public CadastroAtividades_Grid1GridDataProvider(CadastroAtividadesPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEDataProvider(this, TableName, DatabaseName, "PK_TB_HIST_EXECUCAO_ATIVIDADE", "CadastroAtividades_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
ParentPageProvider.MainProvider.DataProvider.Dao = MainProvider.DataProvider.Dao;
		}
		public override string GetItemText(GeneralDataProvider Provider, GeneralDataProviderItem Item)
		{
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
				case "GridColumn5":
					RadComboBoxDataItem GridColumn5Item = Utility.FindComboBoxItem(GridColumn5Items, FieldId);
					if (GridColumn5Item != null) return GridColumn5Item.Text;
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

		public DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "CadastroAtividades_Grid1")
			{
				return new DBGERPROJETO_TB_HIST_EXECUCAO_ATIVIDADEItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (CadastroAtividadesPageProvider)ParentProvider;
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
			itemProcessoField = Convert.ToInt32(Item["itemProcesso"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("itemProcessoField"))
			{
				AliasVariables["itemProcessoField"] = itemProcessoField;
			}
			else
			{
				AliasVariables.Add("itemProcessoField" ,itemProcessoField);
			}
			dataLancamentoField = Convert.ToDateTime(Item["dataLancamento"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("dataLancamentoField"))
			{
				AliasVariables["dataLancamentoField"] = dataLancamentoField;
			}
			else
			{
				AliasVariables.Add("dataLancamentoField" ,dataLancamentoField);
			}
			JustificativaField = Convert.ToInt32(Item["Justificativa"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("JustificativaField"))
			{
				AliasVariables["JustificativaField"] = JustificativaField;
			}
			else
			{
				AliasVariables.Add("JustificativaField" ,JustificativaField);
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
			FillAuxiliarTables();
		}
		
		
		public override void GetTableIdentity()
		{
			MainProvider.DataProvider.FindRecord("PK_TB_HIST_EXECUCAO_ATIVIDADE", false,new string[] { MainProvider.DataProvider.Item["projeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue(),MainProvider.DataProvider.Item["itemProcesso"].GetFormattedValue(),MainProvider.DataProvider.Item["dataLancamento"].GetFormattedValue(),MainProvider.DataProvider.Item["Justificativa"].GetFormattedValue() });
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

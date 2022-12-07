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
	public class Relacao_de_DiretrizPageProvider : GeneralProvider
	{
		public Relacao_de_Projetos_Grid1GridDataProvider Relacao_de_Projetos_Grid1Provider;
		public DBGERPROJETO_TB_ITENS_PROJETODataProvider AUX_Relacao_de_Projetos_TB_ITENS_PROJETOProvider;

		public Relacao_de_DiretrizPageProvider(IGeneralDataProvider Provider)
		{
			MainProvider = Provider;
			MainProvider.DataProvider = new DBGERPROJETO_TB_PROJETODataProvider(MainProvider, MainProvider.TableName, MainProvider.DatabaseName, "PK_TB_PROJETO", "Relacao_de_Diretriz");
			MainProvider.DataProvider.PageProvider = this;
			AUX_Relacao_de_Projetos_TB_ITENS_PROJETOProvider = new DBGERPROJETO_TB_ITENS_PROJETODataProvider(MainProvider, "TB_ITENS_PROJETO", "DBGERPROJETO", "PK_TB_ITENS_PROJETO", "AUX_Relacao_de_Projetos_TB_ITENS_PROJETO");
			Relacao_de_Projetos_Grid1Provider = new Relacao_de_Projetos_Grid1GridDataProvider(this);
			Relacao_de_Projetos_Grid1Provider.SetRelationFields += new GeneralGridProvider.SetRelationFieldsEventHandler(Relacao_de_Projetos_Grid1Provider_SetRelationFields);
		}


		private void Relacao_de_Projetos_Grid1Provider_SetRelationFields(object sender, GeneralDataProviderItem Item)
		{
			try
			{
				if (MainProvider.DataProvider.Item == null)
				{
					MainProvider.DataProvider.Item = MainProvider.LoadItemFromControl(false);
				}
				Relacao_de_Projetos_Grid1Provider.AliasVariables = new Dictionary<string, object>();
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
			else if (Provider.Name == "AUX_Relacao_de_Projetos_TB_ITENS_PROJETO")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem("DBGERPROJETOSystem.Collections.ObjectModel.ObservableCollection`1[GAS.TableField]");
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
			MainProvider.SetParametersValues(AUX_Relacao_de_Projetos_TB_ITENS_PROJETOProvider);
			AUX_Relacao_de_Projetos_TB_ITENS_PROJETOProvider.Dao = MainProvider.DataProvider.Dao;
			AUX_Relacao_de_Projetos_TB_ITENS_PROJETOProvider.SelectItem(1, FormPositioningEnum.First,true);
		}

		public override int GetMaxProcessLanc()
		{
			return 2;
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
			return (ProviderItem.Errors.Count == 0);
		}
		


	}
	/// <summary>
	/// Classe de provider usada para acessar a tabela principal do grid
	/// </summary>
	public class Relacao_de_Projetos_Grid1GridDataProvider : GeneralGridProvider
	{
		public long codigoField;
		public int anoProjetoField;
		public string siglaCoordenacaoField;
		public string siglaSetorialField;
		public string nomeProjetoField;
		public string DiretrizField;
		public string statusProjetoField;
		public DateTime inicioPrevistoField;
		public DateTime terminoPrevistoField;
		public long DiasDeProjetoField;
		public double percentualExecutadoField;
		public string situacaoField;
		public string usuarioCadastroField;
		public DateTime dataCadastroField;
		public DateTime terminoRealizadoField;
		public double custoProjetoField;
		public string nivelProjetoField;
		public string siglaDiretoriaField;
		
		public List<RadComboBoxDataItem> GridColumn3Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "SIM").ToString(), "SIM"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "NAO").ToString(), "NÃO"),
				};
			}
		}
		public List<RadComboBoxDataItem> GridColumn4Items
		{
			get
			{
				return new List<RadComboBoxDataItem>()
				{
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "ATIVO").ToString(), "ATIVO"),
					new RadComboBoxDataItem(HttpContext.GetLocalResourceObject(((Page)ParentPageProvider.MainProvider).AppRelativeVirtualPath, "SUSPENSO").ToString(), "SUSPENSO"),
				};
			}
		}
		

		#region GeneralGridProvider Members

		public override int GetMaxProcessLanc()
		{
			return 2;
		}
		private DBGERPROJETO_TB_PROJETODataProvider _DataProvider;
		
		public override GeneralDataProvider DataProvider
		{
			get
			{
				return _DataProvider;
			}
			set
			{
				_DataProvider = value as DBGERPROJETO_TB_PROJETODataProvider;
			}
		}

		public Relacao_de_DiretrizPageProvider ParentPageProvider;
		
		public override string TableName { get { return "TB_PROJETO"; } }

		public override string DatabaseName { get { return "DBGERPROJETO"; } }

		public override string FormID { get { return "32732"; } }
		
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

		public Relacao_de_Projetos_Grid1GridDataProvider(Relacao_de_DiretrizPageProvider ParentProvider)
		{
			ParentPageProvider = ParentProvider;
			DataProvider = new DBGERPROJETO_TB_PROJETODataProvider(this, TableName, DatabaseName, "PK_TB_PROJETO", "Relacao_de_Projetos_Grid1");
			MainProvider = this;
			MainProvider.DataProvider.PageProvider = this;
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
				case "GridColumn3":
					RadComboBoxDataItem GridColumn3Item = Utility.FindComboBoxItem(GridColumn3Items, FieldId);
					if (GridColumn3Item != null) return GridColumn3Item.Text;
					return "";
				case "GridColumn4":
					RadComboBoxDataItem GridColumn4Item = Utility.FindComboBoxItem(GridColumn4Items, FieldId);
					if (GridColumn4Item != null) return GridColumn4Item.Text;
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

		public DBGERPROJETO_TB_PROJETOItem GetDataProviderItem()
		{
			return GetDataProviderItem(MainProvider.DataProvider) as DBGERPROJETO_TB_PROJETOItem;
		}

		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "Relacao_de_Projetos_Grid1")
			{
				return new DBGERPROJETO_TB_PROJETOItem(DatabaseName);
			}
			return null;
		}

		public override void RefreshParentProvider(GeneralProvider ParentProvider)
		{
		ParentPageProvider = (Relacao_de_DiretrizPageProvider)ParentProvider;
		}

		public override void InitializeAlias(GeneralDataProviderItem Item)
		{
			if (AliasVariables == null)
			{
				AliasVariables = new Dictionary<string, object>();
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
			anoProjetoField = Convert.ToInt32(Item["anoProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("anoProjetoField"))
			{
				AliasVariables["anoProjetoField"] = anoProjetoField;
			}
			else
			{
				AliasVariables.Add("anoProjetoField" ,anoProjetoField);
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
			nomeProjetoField = Convert.ToString(Item["nomeProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nomeProjetoField"))
			{
				AliasVariables["nomeProjetoField"] = nomeProjetoField;
			}
			else
			{
				AliasVariables.Add("nomeProjetoField" ,nomeProjetoField);
			}
			DiretrizField = Convert.ToString(Item["Diretriz"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DiretrizField"))
			{
				AliasVariables["DiretrizField"] = DiretrizField;
			}
			else
			{
				AliasVariables.Add("DiretrizField" ,DiretrizField);
			}
			statusProjetoField = Convert.ToString(Item["statusProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("statusProjetoField"))
			{
				AliasVariables["statusProjetoField"] = statusProjetoField;
			}
			else
			{
				AliasVariables.Add("statusProjetoField" ,statusProjetoField);
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
			DiasDeProjetoField = Convert.ToInt64(Item["DiasDeProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("DiasDeProjetoField"))
			{
				AliasVariables["DiasDeProjetoField"] = DiasDeProjetoField;
			}
			else
			{
				AliasVariables.Add("DiasDeProjetoField" ,DiasDeProjetoField);
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
			terminoRealizadoField = Convert.ToDateTime(Item["terminoRealizado"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("terminoRealizadoField"))
			{
				AliasVariables["terminoRealizadoField"] = terminoRealizadoField;
			}
			else
			{
				AliasVariables.Add("terminoRealizadoField" ,terminoRealizadoField);
			}
			try{custoProjetoField = Convert.ToDouble(Item["custoProjeto"].GetValue().ToString().Replace(".", ",") ,CultureInfo.CurrentCulture);}catch (Exception){}
			if (AliasVariables.ContainsKey("custoProjetoField"))
			{
				AliasVariables["custoProjetoField"] = custoProjetoField;
			}
			else
			{
				AliasVariables.Add("custoProjetoField" ,custoProjetoField);
			}
			nivelProjetoField = Convert.ToString(Item["nivelProjeto"].GetValue(),CultureInfo.CurrentCulture);
			if (AliasVariables.ContainsKey("nivelProjetoField"))
			{
				AliasVariables["nivelProjetoField"] = nivelProjetoField;
			}
			else
			{
				AliasVariables.Add("nivelProjetoField" ,nivelProjetoField);
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
			FillAuxiliarTables();
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

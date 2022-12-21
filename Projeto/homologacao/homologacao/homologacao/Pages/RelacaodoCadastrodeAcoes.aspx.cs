using System;
using System.Collections;
using System.Collections.Specialized;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
using System.Web;
using System.IO;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.HtmlControls;
using System.Web.Security;
using System.Text.RegularExpressions;
using System.Globalization;
using System.Configuration;
using System.Linq;
using PROJETO;
using COMPONENTS;
using COMPONENTS.Data;
using COMPONENTS.Configuration;
using COMPONENTS.Security;
using PROJETO.DataProviders;
using PROJETO.DataPages;
using Telerik.Web.UI;

namespace PROJETO.DataPages
{
	public partial class RelacaodoCadastrodeAcoes : GeneralDataPage
	{
		protected Relacao_Cadastro_AcoesPageProvider PageProvider;
	

		public string nomeProjetoField = "";
		public string DiretrizField = "";
		public string statusProjetoField = "";
		public long codigoField = 0;
		public long DiasDeProjetoField = 0;
		public DateTime ? inicioPrevistoField;
		public DateTime ? terminoPrevistoField;
		public string siglaDiretoriaField = "";
		public string siglaCoordenacaoField = "";
		public string situacaoField = "";
		public double percentualExecutadoField = 0;
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField = null;
		public DateTime ? terminoRealizadoField = null;
		public double custoProjetoField = 0;
		public string nivelProjetoField = "";
		public string siglaSetorialField = "";
		public int anoProjetoField = 0;
		
		public override string FormID { get { return "32736"; } }
		public override string TableName { get { return "TB_PROJETO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "RelacaodoCadastrodeAcoes.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		


		public string ParamCodigo_Projeto = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCodigo_Projeto))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCodigo_Projeto.ToString(), FieldType.Integer);
				}
				else
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
				}
			}
			catch
			{
				PageProvider.MainProvider.DataProvider.StartFilter = "1 = 2";
			}
		}
		public override string GetStartFilterPosition()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCodigo_Projeto))
				{
					return Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCodigo_Projeto.ToString(), FieldType.Integer);
				}
				else
				{
					return "1 = 2";
				}
			}
			catch
			{
				return "1 = 2";
			}
		}
		
		public override void CreateProvider()
		{
			PageProvider = new Relacao_Cadastro_AcoesPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}

		public override void GridRebind()
		{
			Grid1.CurrentPageIndex = 0;
			Grid1.DataSource = null;
			Grid1.Rebind();
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamCodigo_Projeto = HttpContext.Current.Request.QueryString["ParamCodigo_Projeto"];
			try { if (string.IsNullOrEmpty(ParamCodigo_Projeto)) ParamCodigo_Projeto = HttpContext.Current.Session["ParamCodigo_Projeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCodigo_Projeto)) ParamCodigo_Projeto = "0";
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
			AjaxPanel.ResponseScripts.Add("setTimeout(\"RegisterClientValidateScript();\",100);");
			ErrorLabel = labError;
			if (!PageInsert )
				DisableEnableContros(false);

			base.OnInit(e);
		}
		

		/// <summary>
		/// Carrega os objetos de Item de acordo com os controles
		/// </summary>
		public override void UpdateItemFromControl(GeneralDataProviderItem  Item)
		{
			// só vamos permitir a carga dos itens de acordo com os controles de tela caso esteja ocorrendo
			// um postback pois em caso contrário a página está sendo aberta em modo de inclusão/edição
			// e dessa forma não teve alteração de usuário nos dados do formulário
			if (PageState != FormStateEnum.Navigation && this.IsPostBack)
			{
				Item.SetFieldValue(Item["nomeProjeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["Diretriz"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["statusProjeto"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["DiasDeProjeto"], RadTextBox4.Text, false);
				if (DatePicker2.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], DatePicker2.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (DatePicker3.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], DatePicker3.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox3.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["situacao"], RadTextBox5.Text, false);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox6.Text, false);
			}
			InitializeAlias(Item);
		}

		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da página
		/// </summary>

		public override GeneralDataProviderItem LoadItemFromControl(bool EnableValidation)
		{
			GeneralDataProviderItem Item = PageProvider.GetDataProviderItem(DataProvider);
			if (PageState != FormStateEnum.Navigation)
			{
				Item.SetFieldValue(Item["nomeProjeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["Diretriz"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["statusProjeto"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["DiasDeProjeto"], RadTextBox4.Text, false);
				if (DatePicker2.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], DatePicker2.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (DatePicker3.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], DatePicker3.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox3.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["situacao"], RadTextBox5.Text, false);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox6.Text, false);
			}
			else
			{
				Item = PageProvider.MainProvider.DataProvider.SelectItem(PageNumber, FormPositioningEnum.Current);
			}
			if (EnableValidation)
			{
				InitializeAlias(Item);
				if (PageState == FormStateEnum.Insert)
				{
					FillAuxiliarTables();
				}
				PageProvider.Validate(Item); 
			}
			if (Item!=null) PageErrors.Add(Item.Errors);
			return Item;
		}
		

		/// <summary>
		/// Define a Máscara para cada campo na tela
		/// </summary>
		public override void DefineMask()
		{
			Mask.SetMask(RadTextBox1, "@!", 255, false);
			Mask.SetMask(RadTextBox3, "9999999999", 10, true);
			Mask.SetMask(RadTextBox4, "9999999999", 10, true);
			Mask.SetMask(DatePicker2.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(DatePicker3.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox5, "@!", 20, false);
			Mask.SetMask(RadTextBox6, "999,99", 6, true);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(ComboBox2);
			Utility.SetControlTabOnEnter(ComboBox3);
			Utility.SetControlTabOnEnter(ComboBox4);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox1.Enabled = Action;
			ComboBox1.Enabled = Action;
			ComboBox2.Enabled = Action;
			DatePicker2.Enabled = Action;
			DatePicker3.Enabled = Action;
			ComboBox3.Enabled = Action;
			ComboBox4.Enabled = Action;
			RadTextBox5.Enabled = Action;
			RadTextBox6.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox3.Text = "";
			if (ShouldClearFields)
			{
				RadTextBox1.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				RadTextBox4.Text = "";
				DatePicker2.SelectedDate = null;
				DatePicker3.SelectedDate = null;
				ComboBox3.SelectedIndex = -1;
				ComboBox3.Text = "";
				ComboBox4.SelectedIndex = -1;
				ComboBox4.Text = "";
				RadTextBox5.Text = "";
				RadTextBox6.Text = "";
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			DatePicker2.SelectedDate = null;
			DatePicker3.SelectedDate = null;
		}

		public override void PageEdit()
		{
			DisableEnableContros(true); 
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
			Label3.Text = Label3.Text.Replace("<", "&lt;");
			Label3.Text = Label3.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
			Label10.Text = Label10.Text.Replace("<", "&lt;");
			Label10.Text = Label10.Text.Replace(">", "&gt;");
			Label11.Text = Label11.Text.Replace("<", "&lt;");
			Label11.Text = Label11.Text.Replace(">", "&gt;");
			Label12.Text = Label12.Text.Replace("<", "&lt;");
			Label12.Text = Label12.Text.Replace(">", "&gt;");
			Label13.Text = Label13.Text.Replace("<", "&lt;");
			Label13.Text = Label13.Text.Replace(">", "&gt;");
			Label14.Text = Label14.Text.Replace("<", "&lt;");
			Label14.Text = Label14.Text.Replace(">", "&gt;");
			Label15.Text = Label15.Text.Replace("<", "&lt;");
			Label15.Text = Label15.Text.Replace(">", "&gt;");
			Label16.Text = Label16.Text.Replace("<", "&lt;");
			Label16.Text = Label16.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			try
			{
				if (Item != null)
				{
					RadTextBox1.Text = Item["nomeProjeto"].GetFormattedValue();
				}
				else
				{
					RadTextBox1.Text = "" ;
				}
			}
			catch
			{
				RadTextBox1.Text = "" ;
			}
			try
			{
				string Val = Item["Diretriz"].GetFormattedValue();
				RadComboBoxDataItem ComboBox1item = Utility.FindComboBoxItem(PageProvider.ComboBox1Items, Val);
				ComboBox1.Text = ComboBox1item.Text;
				ComboBox1.SelectedValue = ComboBox1item.Value;
				ComboBox1.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox1.SelectedValue = "";
				ComboBox1.Text = "";
			}
			try
			{
				string Val = Item["statusProjeto"].GetFormattedValue();
				RadComboBoxDataItem ComboBox2item = Utility.FindComboBoxItem(PageProvider.ComboBox2Items, Val);
				ComboBox2.Text = ComboBox2item.Text;
				ComboBox2.SelectedValue = ComboBox2item.Value;
				ComboBox2.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox2.SelectedValue = "";
				ComboBox2.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox3.Text = Item["codigo"].GetFormattedValue();
				}
				else
				{
					RadTextBox3.Text = "" ;
				}
			}
			catch
			{
				RadTextBox3.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox4.Text = Item["DiasDeProjeto"].GetFormattedValue();
				}
				else
				{
					RadTextBox4.Text = "" ;
				}
			}
			catch
			{
				RadTextBox4.Text = "" ;
			}
			try { DatePicker2.SelectedDate = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker2.SelectedDate = null; }
			try { DatePicker3.SelectedDate = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker3.SelectedDate = null; }
			try
			{
				string Val = Item["siglaDiretoria"].GetFormattedValue();
				SelectComboItem(ComboBox3, PageProvider.ComboBox3Provider, Val);
				ComboBox3.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox3.SelectedValue = "";
				ComboBox3.Text = "";
			}
			try
			{
				string Val = Item["siglaCoordenacao"].GetFormattedValue();
				SelectComboItem(ComboBox4, PageProvider.ComboBox4Provider, Val);
				ComboBox4.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox4.SelectedValue = "";
				ComboBox4.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox5.Text = Item["situacao"].GetFormattedValue();
				}
				else
				{
					RadTextBox5.Text = "" ;
				}
			}
			catch
			{
				RadTextBox5.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox6.Text = Item["percentualExecutado"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					RadTextBox6.Text = "" ;
				}
			}
			catch
			{
				RadTextBox6.Text = "" ;
			}
			ApplyMasks(RadTextBox1);
			ApplyMasks(RadTextBox3);
			ApplyMasks(RadTextBox4);
			ApplyMasks(DatePicker2);
			ApplyMasks(DatePicker3);
			ApplyMasks(RadTextBox5);
			ApplyMasks(RadTextBox6);
			InitializePageContent();
			base.DefinePageContent(Item);
		}
		private void SelectComboItem(RadComboBox Combo, GeneralDataProvider Provider, string Value)
        {
			if (Combo.Items.Count == 0 && !string.IsNullOrEmpty(Value))
			{
				GeneralDataProviderItem item = PageProvider.GetComboItem(Provider, Value);
				Combo.Text = PageProvider.GetItemText(Provider, item);
				Combo.SelectedValue = PageProvider.GetItemValue(Provider, item).ToString();
				Combo.Attributes.Add("AllowFilter", "False");
			}
			else
            {
				Combo.Text = null;
				Combo.SelectedValue = null;
			}
		}

		/// <summary>
		/// Define apelidos da Página
		/// </summary>
		public override void InitializeAlias(GeneralDataProviderItem Item)
        {
			PageProvider.AliasVariables = new Dictionary<string, object>();
			PageProvider.AliasVariables.Clear();
			
			try
			{
				if (Item != null)
				{
					nomeProjetoField = Item["nomeProjeto"].GetFormattedValue();
				}
				else
				{
					nomeProjetoField = "";
				}
			}
			catch
			{
				nomeProjetoField = "";
			}
			try
			{
				DiretrizField = Item["Diretriz"].GetFormattedValue();
			}
			catch
			{
				DiretrizField = "";
			}
			try
			{
				statusProjetoField = Item["statusProjeto"].GetFormattedValue();
			}
			catch
			{
				statusProjetoField = "";
			}
			try
			{
				if (Item != null)
				{
					codigoField = long.Parse(Item["codigo"].GetFormattedValue());
				}
				else
				{
					codigoField = 0;
				}
			}
			catch
			{
				codigoField = 0;
			}
			try
			{
				if (Item != null)
				{
					DiasDeProjetoField = long.Parse(Item["DiasDeProjeto"].GetFormattedValue());
				}
				else
				{
					DiasDeProjetoField = 0;
				}
			}
			catch
			{
				DiasDeProjetoField = 0;
			}
			try
			{
				inicioPrevistoField = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				inicioPrevistoField = null;
			}
			try
			{
				terminoPrevistoField = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				terminoPrevistoField = null;
			}
			try
			{
				siglaDiretoriaField = Item["siglaDiretoria"].GetFormattedValue();
			}
			catch
			{
				siglaDiretoriaField = "";
			}
			try
			{
				siglaCoordenacaoField = Item["siglaCoordenacao"].GetFormattedValue();
			}
			catch
			{
				siglaCoordenacaoField = "";
			}
			try
			{
				if (Item != null)
				{
					situacaoField = Item["situacao"].GetFormattedValue();
				}
				else
				{
					situacaoField = "";
				}
			}
			catch
			{
				situacaoField = "";
			}
			try
			{
				if (Item != null)
				{
					percentualExecutadoField = double.Parse(Item["percentualExecutado"].GetFormattedValue().Replace(".",","));
				}
				else
				{
					percentualExecutadoField = 0;
				}
			}
			catch
			{
				percentualExecutadoField = 0;
			}
			try
			{
				if (Item != null)
				{
					usuarioCadastroField = Item["usuarioCadastro"].GetFormattedValue();
				}
				else
				{
				usuarioCadastroField = "";
				}
			}
			catch
			{
				usuarioCadastroField = "";
			}
			try
			{
				if (Item != null)
				{
					dataCadastroField = DateTime.Parse(Item["dataCadastro"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				dataCadastroField = null;
				}
			}
			catch
			{
				dataCadastroField = null;
			}
			try
			{
				if (Item != null)
				{
					terminoRealizadoField = DateTime.Parse(Item["terminoRealizado"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				terminoRealizadoField = null;
				}
			}
			catch
			{
				terminoRealizadoField = null;
			}
			try
			{
				if (Item != null)
				{
					custoProjetoField = double.Parse(Item["custoProjeto"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				custoProjetoField = 0;
				}
			}
			catch
			{
				custoProjetoField = 0;
			}
			try
			{
				if (Item != null)
				{
					nivelProjetoField = Item["nivelProjeto"].GetFormattedValue();
				}
				else
				{
				nivelProjetoField = "";
				}
			}
			catch
			{
				nivelProjetoField = "";
			}
			try
			{
				if (Item != null)
				{
					siglaSetorialField = Item["siglaSetorial"].GetFormattedValue();
				}
				else
				{
				siglaSetorialField = "";
				}
			}
			catch
			{
				siglaSetorialField = "";
			}
			try
			{
				if (Item != null)
				{
					anoProjetoField = int.Parse(Item["anoProjeto"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				anoProjetoField = 0;
				}
			}
			catch
			{
				anoProjetoField = 0;
			}
			PageProvider.AliasVariables.Add("nomeProjetoField", nomeProjetoField);
			PageProvider.AliasVariables.Add("DiretrizField", DiretrizField);
			PageProvider.AliasVariables.Add("statusProjetoField", statusProjetoField);
			PageProvider.AliasVariables.Add("codigoField", codigoField);
			PageProvider.AliasVariables.Add("DiasDeProjetoField", DiasDeProjetoField);
			PageProvider.AliasVariables.Add("inicioPrevistoField", inicioPrevistoField);
			PageProvider.AliasVariables.Add("terminoPrevistoField", terminoPrevistoField);
			PageProvider.AliasVariables.Add("siglaDiretoriaField", siglaDiretoriaField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("situacaoField", situacaoField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("terminoRealizadoField", terminoRealizadoField);
			PageProvider.AliasVariables.Add("custoProjetoField", custoProjetoField);
			PageProvider.AliasVariables.Add("nivelProjetoField", nivelProjetoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("anoProjetoField", anoProjetoField);
			PageProvider.AliasVariables.Add("ParamCodigo_Projeto", ParamCodigo_Projeto);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_LoadCompleted()
		{
			bool ActionSucceeded_1 = true;
			try
			{
				AtualizaSituacaoAcaoProcessProvider PreDefProvider = new AtualizaSituacaoAcaoProcessProvider(this);
				PreDefProvider.AliasVariables = new Dictionary<string, object>();
				PreDefProvider.AliasVariables.Clear();
				PreDefProvider.ExecutePreDefinedProcess();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
			bool ActionSucceeded_2 = true;
			try
			{
				Form1_LoadCompleted();
			}
			catch (Exception ex)
			{
				ActionSucceeded_2 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
			bool ActionSucceeded_3 = true;
			try
			{
				Form1_LoadCompleted_1();
			}
			catch (Exception ex)
			{
				ActionSucceeded_3 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		
		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da grid
		/// </summary>
		public override GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string GridId)
		{
			GeneralDataProviderItem Item = null;
			switch (GridId)
			{
				case "Grid1":
					if (PageProvider.TB_PROJETO1_Grid1Provider.DataProvider.Item == null)
						Item = PageProvider.TB_PROJETO1_Grid1Provider.GetDataProviderItem();
					else
						Item = PageProvider.TB_PROJETO1_Grid1Provider.DataProvider.Item;
					PageProvider.TB_PROJETO1_Grid1Provider.RaiseSetRelationFields(PageProvider.TB_PROJETO1_Grid1Provider, Item);
					Item.SetFieldValue(Item["itemProjeto"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["itemProjeto"]);
					Item.SetFieldValue(Item["nomeAcao"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["nomeAcao"]);
					Item.SetFieldValue(Item["inicioPrevisto"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["inicioPrevisto"]);
					Item.SetFieldValue(Item["terminoPrevisto"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["terminoPrevisto"]);
					Item.SetFieldValue(Item["DiasPrevistos"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["DiasPrevistos"]);
					Item.SetFieldValue(Item["percentualExecutado"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["percentualExecutado"]);
					Item.SetFieldValue(Item["terminoRealizado"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["terminoRealizado"]);
					Item.SetFieldValue(Item["nomeSobrenome"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["nomeSobrenome"]);
					Item.SetFieldValue(Item["situacao"], PageProvider.TB_PROJETO1_Grid1Provider.GridData["situacao"]);
					PageProvider.TB_PROJETO1_Grid1Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.TB_PROJETO1_Grid1Provider.Validate(Item);
					}
					break;
			}

			return Item;
		}

		public override void setGridPerm()
		{
			if (!PageOperations.AllowInsert)
			{
				Grid1.MasterTableView.CommandItemDisplay = GridCommandItemDisplay.None;
			}
			if (Grid1.Columns[0] is GridEditCommandColumn && !PageOperations.AllowUpdate)
			{
				Grid1.Columns[0].Visible = false;
			}
			if (Grid1.Columns.Count != 0 && Grid1.Columns[Grid1.Columns.Count - 1] is GridButtonColumn && (Grid1.Columns[Grid1.Columns.Count - 1] as GridButtonColumn).CommandName == "Delete" && !PageOperations.AllowDelete)
			{
				Grid1.Columns[Grid1.Columns.Count - 1].Visible = false;
			}
		}

		protected void Grid1_ItemCreated(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridEditableItem && (e.Item.IsInEditMode))
			{
				if (Grid1.Columns[0].ColumnType == "GridEditCommandColumn" && PageOperations.AllowUpdate)
				{
					if (Grid1.Columns[0].HeaderStyle.Width == 20 && Grid1.Columns[0].Visible == true)
					{
						Grid1.Columns[0].HeaderStyle.Width = 70; 
					}
					else
					{
						Grid1.Columns[0].HeaderStyle.Width = 20; 
					}
				}
				GridEditableItem editableItem = (GridEditableItem)e.Item;
				TextBox txt;
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn1") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 30;
				Mask.SetMask(txt, "99999", 5, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn2") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 531;
				Mask.SetMask(txt, "@!", 255, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				RadDatePicker dtp;
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn3") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 58;
				dtp.DateInput.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn3_Validation]]");
				dtp.DateInput.Attributes.Add("data-validation-message", "Data de Inicio não pode ser vazio!");
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn4") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 58;
				dtp.DateInput.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn4_Validation]]");
				dtp.DateInput.Attributes.Add("data-validation-message", "Data do Fim não pode ser vazio!");
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn12") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "999", 3, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn9") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 58;
				Mask.SetMask(txt, "999,99", 6, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn5") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 58;
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn6") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 128;
				Mask.SetMask(txt, "@!", 50, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn11") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "@!", 20, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				AjaxPanel.ResponseScripts.Add("jQuery(\"#Grid1\").validationEngine();");
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		
		
		protected void Grid1_ItemDataBound(object sender, GridItemEventArgs e)
		{
			if (e.Item is GridPagerItem)
			{
				GridPagerItem pager = (GridPagerItem)e.Item;
				RadComboBox PageSizeComboBox = (RadComboBox)pager.FindControl("PageSizeComboBox");
				PageSizeComboBox.Visible = false;
				Label ChangePageSizeLabel = (Label)pager.FindControl("ChangePageSizeLabel");
				ChangePageSizeLabel.Visible = false;
			}
		}
		
		protected void Grid1_ItemCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
			if (e.CommandName == RadGrid.InitInsertCommandName)// If insert mode, disallow edit
			{
				Grid.MasterTableView.ClearEditItems();
			}
			if (e.CommandName == RadGrid.EditCommandName) // If edit mode, disallow insert
			{
				e.Item.OwnerTableView.IsItemInserted = false;
			}
			if (e.CommandName == RadGrid.ExpandCollapseCommandName) // Allow Expand/Collapse one row at a time
			{
				foreach (GridItem item in e.Item.OwnerTableView.Items)
				{
					if (item.Expanded && item != e.Item)
					{
						item.Expanded = false;
					}
				}
			}
			if (e.CommandName == Telerik.Web.UI.RadGrid.ExportToWordCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToPdfCommandName ||
				e.CommandName == Telerik.Web.UI.RadGrid.ExportToExcelCommandName || e.CommandName == Telerik.Web.UI.RadGrid.ExportToCsvCommandName)
			{
				Grid.AllowPaging = false;
				Grid.ExportSettings.IgnorePaging = true;
				Grid.ExportSettings.OpenInNewWindow = true;
			}
			if (e.Item is GridDataItem && !(e.Item is GridDataInsertItem) && e.CommandName != "Cancel" && e.CommandName != "Update" && e.CommandName != "Insert")
			{
				GeneralGridProvider Provider = GetGridProvider(Grid);
				Hashtable CurrentValues = new Hashtable();
				GridDataItem item = (GridDataItem)e.Item;
				if (e.CommandArgument != null && e.CommandArgument.ToString() != "")
				{
					int index = 0;
					if (int.TryParse(e.CommandArgument.ToString(), out index)) item = e.Item.OwnerTableView.Items[index];
				}
				item.ExtractValues(CurrentValues);
				foreach (string key in item.OwnerTableView.DataKeyNames)
				{
					if(Provider.DataProvider.Item.GetFieldAliasByFieldName(key) != "")
						CurrentValues[Provider.DataProvider.Item.GetFieldAliasByFieldName(key)] = item.GetDataKeyValue(key);
					else
						CurrentValues[key] = item.GetDataKeyValue(key);
				}
				Provider.SelectItem(this, Grid.ID, CurrentValues);
		
				switch (e.CommandName)
				{
					case "GridColumn7":
						bool ActionSucceeded_GridColumn7_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/TB_ITENS_PROJETO.aspx?ParamCodigoProjeto={ParamCodigoProjeto}&ParamItemProjeto={ParamItemProjeto}&ParamCoordenacao={ParamCoordenacao}&ParamNomeProjeto={ParamNomeProjeto}");
							UrlPage = UrlPage.Replace("{ParamCodigoProjeto}", (Convert.ToInt32(Provider.DataProvider.Item["projeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamItemProjeto}", (Convert.ToInt32(Provider.DataProvider.Item["itemProjeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamCoordenacao}", "");
							UrlPage = UrlPage.Replace("{ParamNomeProjeto}", (Convert.ToString(PageProvider.AliasVariables["nomeProjetoField"])).ToString());
							try
							{
								AjaxPanel.ResponseScripts.Add("Navigate('" + UrlPage + "', true, null, { Modal: true, Center: true });");
							}
							catch(Exception ex)
							{
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn7_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
					break;
					case "GridColumn10":
						bool ActionSucceeded_GridColumn10_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/ProjetosAtividades.aspx?ParamProjeto={ParamProjeto}&ParamItemProjeto={ParamItemProjeto}");
							UrlPage = UrlPage.Replace("{ParamProjeto}", (Convert.ToInt32(Provider.DataProvider.Item["projeto"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamItemProjeto}", (Convert.ToInt32(Provider.DataProvider.Item["itemProjeto"].GetValue())).ToString());
							try
							{
								AjaxPanel.ResponseScripts.Add("Navigate('" + UrlPage + "', true, null, { Modal: true, Center: true });");
							}
							catch(Exception ex)
							{
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn10_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
					break;
				}
			}
		}

		public override void RefreshOnNavigation()
		{
			Grid1.MasterTableView.ClearEditItems();
			Grid1.MasterTableView.IsItemInserted = false;
		}

		protected void Grid_Init(object sender, EventArgs e)
		{
			RadGrid Grid = (RadGrid)sender;
			GridFilterMenu menu = Grid.FilterMenu;
			int i = 0;
			while (i < menu.Items.Count)
			{
				if (menu.Items[i].Value == "Between" || menu.Items[i].Value == "NotBetween")
				{
					menu.Items.RemoveAt(i);
				}
				else
				{
					i++;
				}
			}
		}

		protected void Grid_NeedDataSource(object source, GridNeedDataSourceEventArgs e)
		{
			int TotalRecords = 0;
			string GridFilter = "";
			RadGrid Grid = (RadGrid)source;

			InitializeGridData(Grid);

			
			if (Grid.MasterTableView.SortExpressions.Count > 0)
			{
				string orderBy = "";
				foreach (GridSortExpression sort in Grid.MasterTableView.SortExpressions)
				{
					orderBy += GetGridProvider(Grid).DataProvider.Dao.PoeColAspas(sort.FieldName) + " " + sort.SortOrderAsString() + ", ";
				}
				GetGridProvider(Grid).DataProvider.OrderBy = orderBy.Remove(orderBy.Length - 2);
			}
			Grid.DataSource = GetGridProvider(Grid).DataProvider.SelectItems(Grid.CurrentPageIndex, Grid.PageSize, out TotalRecords);
			Grid.VirtualItemCount = TotalRecords;
		}
		 
		protected void Grid_UpdateCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Tuple<Hashtable, Hashtable> GridValues = FillGridValues(editableItem, Grid);
			GetGridProvider(Grid).UpdateItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, GridValues.Item1), GridValues.Item2);
			 if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			Grid.DataSource = null;
            Grid.Rebind();
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_InsertCommand(object source, GridCommandEventArgs e)
		{
			var editableItem = (GridEditableItem)e.Item;
			RadGrid Grid = (RadGrid)source;
			Hashtable newValues = new Hashtable();
			e.Item.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			GetGridProvider(Grid).InsertItem(this, Grid.ID, DefineGridInsertValues(Grid.ID, newValues));
			if (GetGridProvider(Grid).PageErrors != null)
            {
                e.Canceled = true;
                PageErrors.Add(GetGridProvider(Grid).PageErrors);
                return;
            }
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		protected void Grid_DeleteCommand(object source, GridCommandEventArgs e)
		{
			RadGrid Grid = (RadGrid)source;
            DeleteGrid(Grid, false, (GridEditableItem)e.Item);
			if (GetGridProvider(Grid).PageErrors != null)
			{
				e.Canceled = true;
				PageErrors.Add(GetGridProvider(Grid).PageErrors);
				return;
			}
			PageShow(FormPositioningEnum.Current, true, false, false);
		}

		public override void DeleteChildItens()
        {
			DeleteGrid(Grid1, true, null);
            base.DeleteChildItens();
        }

		public void DeleteGrid(RadGrid Grid, bool DeleteAllItems, GridEditableItem SingleItem)
        {
			int StartIndex = 0;
            if (!DeleteAllItems) StartIndex = SingleItem.ItemIndex;
            else
            {
                Grid.DataSource = null;
                Grid.CurrentPageIndex = 0;
                Grid.Rebind();
            }
            while (Grid.Items.Count != 0 && PageErrors.Count == 0)
            {
                for (int i = StartIndex; Grid.MasterTableView.Items.Count > i; i++)
                {
                    switch (Grid.ID)
                    {
					}
                    Tuple<Hashtable, Hashtable> GridValues = FillGridValues(Grid.MasterTableView.Items[i], Grid);
                    GetGridProvider(Grid).DeleteItem(this, Grid.ID, GridValues.Item1, GridValues.Item2);
					if(GetGridProvider(Grid).PageErrors != null) PageErrors.Add(GetGridProvider(Grid).PageErrors);
                    if (!DeleteAllItems) break;
                }
				Grid.DataSource = null;
				if (DeleteAllItems) Grid.CurrentPageIndex = 0;
                if (!DeleteAllItems && Grid.Items.Count == 1 && Grid.CurrentPageIndex > 0) Grid.CurrentPageIndex--;
                Grid.Rebind();
				if (!DeleteAllItems) break;
            }
		}

		private Tuple<Hashtable, Hashtable> FillGridValues(GridEditableItem editableItem, RadGrid Grid)
		{
			Hashtable newValues = new Hashtable();
			editableItem.OwnerTableView.ExtractValuesFromItem(newValues, editableItem);
			Hashtable oldValues = newValues.Clone() as Hashtable;
			foreach (string key in Grid.MasterTableView.DataKeyNames)
			{
				string FdAlias = (from f in GetGridProvider(Grid).DataProvider.Item.Fields where f.Value.Name == key select f.Key).FirstOrDefault();
				if (!newValues.ContainsKey(key)) newValues.Add(key, editableItem.GetDataKeyValue(key));
				if (!oldValues.ContainsKey(FdAlias))
				{
					oldValues.Add(FdAlias, editableItem.GetDataKeyValue(key));
				}
				else
				{
					oldValues[FdAlias] = editableItem.GetDataKeyValue(key);
				}
			}
			return new Tuple<Hashtable, Hashtable>(newValues, oldValues);
		}
		
		private void InitializeGridData(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					try
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["codigo"].GetFormattedValue(), FieldType.Integer);
					}
					catch
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = "1 = 2";
					}
					Grid.Enabled = true;
					if (PageProvider.MainProvider.DataProvider.Item == null || PageProvider.MainProvider.DataProvider.Item["codigo"].GetValue() == null)
					{
						Grid.Enabled = false;
					}
					break;
			}
		}
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					return PageProvider.TB_PROJETO1_Grid1Provider;
			}
			return null;
		}
		public override GeneralDataProviderItem GetDataProviderItem(GeneralDataProvider Provider)
		{
			if (Provider.Name == "AtualizaAcao")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem("DBGERPROJETO");
			}
			if (Provider.Name == "AtualizaAcao")
			{
				return new DBGERPROJETO_TB_ITENS_PROJETOItem("DBGERPROJETO");
			}
			return base.GetDataProviderItem(Provider);
		}
		
		protected void ___ComboBox1_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox1Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox2_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox2Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox3_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox3Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox4_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox4Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		protected override void OnLoadComplete(EventArgs e)
		{
			___Form1_LoadCompleted();
			base.OnLoadComplete(e);
		}
#region CÓDIGO DE USUARIO

		protected void Form1_LoadCompleted()
		{
			/*
			try
            {
				// Atualiza Situação na Tabela de Atividades
				string sql = "UPDATE TB_PROCESSOS SET TB_PROCESSOS.situacao = CASE 	WHEN (percentualExecutado = 100) THEN 'CONCLUÍDO' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is not Null and percentualExecutado < 100) THEN 'VERIFICAR %' " +
							"WHEN(terminoPrevisto < GETDATE() AND inicioRealizado is null and terminoRealizado is Null and percentualExecutado = 0) THEN 'ATRASADO' " +
							"WHEN(inicioRealizado IS NULL  AND inicioPrevisto < GETDATE() AND percentualExecutado = 0) THEN 'ATRASADO' " +
							//"WHEN(inicioRealizado IS NULL AND terminoRealizado is null AND percentualExecutado > 0) THEN 'VERIFICAR INICIO' " +
							"WHEN(inicioRealizado IS NULL AND terminoRealizado is null) THEN 'A INICIAR' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE() > terminoPrevisto) THEN 'ATRASADO' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is null and percentualExecutado < 100 and GETDATE() - 15 < terminoPrevisto) THEN 'EM DIA' END";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}
			
			// **************************************************************************** //
			// **************************************************************************** //			
			// BLOCO DE ATUALIZAÇÃO DA SITUAÇÃO DE EXECUÇÃO DAS DIRETRIZES E AÇÕES
		
			// BLOCO DAS DIRETRIZES //
			try
            {
				// Atualiza Diretriz "EM DIA"
				string sql2 = "UPDATE TB_PROJETO SET SITUACAO = 'EM DIA' FROM TB_PROJETO A JOIN TB_PROCESSOS C ON A.codigo = C.projeto AND A.percentualExecutado < 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql2));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}	
			// ATUALIZA DIRETRIZ "ATRASADO"
			try
            {
				// Atualiza Diretriz "EM DIA"
				string sql3 = "UPDATE TB_PROJETO SET SITUACAO = 'ATRASADO' FROM TB_PROJETO A JOIN TB_PROCESSOS C ON A.codigo = C.projeto AND C.situacao = 'ATRASADO' AND A.percentualExecutado < 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql3));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}	
			// ATUALIZA DIRETRIZ "CONCLUÍDO"
			try
            {
				// Atualiza Diretriz "EM DIA"
				string sql4 = "UPDATE TB_PROJETO SET SITUACAO = 'CONCLUÍDO' FROM TB_PROJETO A WHERE A.percentualExecutado = 100	";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql4));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}	

			// BLOCO DAS AÇÕES //

			try
            {
				// Atualiza Diretriz "EM DIA"
				string sql5 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'EM DIA' FROM TB_ITENS_PROJETO A JOIN TB_PROCESSOS C ON A.projeto = C.projeto and A.itemProjeto = c.itemProjeto AND A.percentualExecutado < 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql5));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}					
			// ************************************************************************ //
			try
            {
				// Atualiza Ação "ATRASADO"
				string sql6 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'ATRASADO' FROM TB_ITENS_PROJETO B JOIN TB_PROCESSOS C ON B.projeto = C.projeto and b.itemProjeto = c.itemProjeto AND C.situacao = 'ATRASADO'";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql6));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}				
			// ************************************************************************ //
			try
            {
				// Atualiza Ação "CONCLUÍDO"
				string sql7 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'CONCLUÍDO' FROM TB_ITENS_PROJETO A WHERE A.percentualExecutado = 100";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql7));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}
			*/
		}

		protected void Form1_LoadCompleted_1()
		{
			try
            {
				// Atualiza Ação "CONCLUÍDO"
				string sql = "UPDATE TB_ITENS_PROJETO SET DIASPREVISTOS = DATEDIFF(day,inicioPrevisto,terminoPrevisto) FROM TB_ITENS_PROJETO";

				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql));
			}
			catch(Exception ex)
            {
				throw ex;
            }
			finally
            {
				Dao.CloseConnection();
				Dao.Dispose();
			}						
		}
#endregion
	}
}

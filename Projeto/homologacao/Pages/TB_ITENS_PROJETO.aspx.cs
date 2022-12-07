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
	public partial class TB_ITENS_PROJETO : GeneralDataPage
	{
		protected TB_ITENS_PROJETOPageProvider PageProvider;
	

		public string btnSalvarField = "btnSalvar";
		public int itemProjetoField = 0;
		public string nomeAcaoField = "";
		public DateTime ? terminoPrevistoField;
		public DateTime ? terminoRealizadoField;
		public string nomeSobrenomeField = "";
		public string responsavelSubstitutoField = "";
		public string observacaoField = "";
		public string siglaCoordenacaoField = "";
		public string siglaSetorialField = "";
		public double percentualExecutadoField = 0;
		public DateTime ? inicioRealizadoField;
		public DateTime ? inicioPrevistoField;
		public long projetoField = 0;
		public int DiasPrevistosField = 0;
		public int DiasRealizadosField = 0;
		public string statusAcaoField = "";
		public string situacaoField = "";
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField;
		public double custoAcaoField = 0;
		
		public override string FormID { get { return "32735"; } }
		public override string TableName { get { return "TB_ITENS_PROJETO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "TB_ITENS_PROJETO.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamCodigoProjeto = "";
		public string ParamItemProjeto = "";
		public string ParamCoordenacao = "";
		public string ParamNomeProjeto = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCodigoProjeto) && !String.IsNullOrEmpty(ParamItemProjeto))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "(" + Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(ParamCodigoProjeto.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(ParamItemProjeto.ToString(), FieldType.Integer);
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
		
		public override void CreateProvider()
		{
			PageProvider = new TB_ITENS_PROJETOPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamCodigoProjeto = HttpContext.Current.Request.QueryString["ParamCodigoProjeto"];
			try { if (string.IsNullOrEmpty(ParamCodigoProjeto)) ParamCodigoProjeto = HttpContext.Current.Session["ParamCodigoProjeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCodigoProjeto)) ParamCodigoProjeto = "0";
			ParamItemProjeto = HttpContext.Current.Request.QueryString["ParamItemProjeto"];
			try { if (string.IsNullOrEmpty(ParamItemProjeto)) ParamItemProjeto = HttpContext.Current.Session["ParamItemProjeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamItemProjeto)) ParamItemProjeto = "0";
			ParamCoordenacao = HttpContext.Current.Request.QueryString["ParamCoordenacao"];
			try { if (string.IsNullOrEmpty(ParamCoordenacao)) ParamCoordenacao = HttpContext.Current.Session["ParamCoordenacao"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCoordenacao)) ParamCoordenacao = "";
			ParamNomeProjeto = HttpContext.Current.Request.QueryString["ParamNomeProjeto"];
			try { if (string.IsNullOrEmpty(ParamNomeProjeto)) ParamNomeProjeto = HttpContext.Current.Session["ParamNomeProjeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamNomeProjeto)) ParamNomeProjeto = "";
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
				Item.SetFieldValue(Item["itemProjeto"], txtItemProjeto.Text, false);
				Item.SetFieldValue(Item["nomeAcao"], RadTextBox3.Text, false);
				if (txtTerminoPrevisto.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], txtTerminoPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				if (DatePicker3.SelectedDate != null) Item.SetFieldValue(Item["terminoRealizado"], DatePicker3.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoRealizado"], DBNull.Value);
				Item.SetFieldValue(Item["nomeSobrenome"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["responsavelSubstituto"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["observacao"], RadTextBox6.Text, false);
				Item.SetFieldValue(Item["siglaCoordenacao"], cmbSiglaCoordenacao.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox8.Text, false);
				if (DatePicker5.SelectedDate != null) Item.SetFieldValue(Item["inicioRealizado"], DatePicker5.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioRealizado"], DBNull.Value);
				if (txtInicioPrevisto.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], txtInicioPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["projeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["DiasPrevistos"], RadTextBox9.Text, false);
				Item.SetFieldValue(Item["DiasRealizados"], RadTextBox10.Text, false);
				Item.SetFieldValue(Item["statusAcao"], ComboBox5.SelectedValue);
				Item.SetFieldValue(Item["situacao"], RadTextBox13.Text, false);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox7.Text, false);
				if (DatePicker4.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker4.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
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
				Item.SetFieldValue(Item["itemProjeto"], txtItemProjeto.Text, false);
				Item.SetFieldValue(Item["nomeAcao"], RadTextBox3.Text, false);
				if (txtTerminoPrevisto.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], txtTerminoPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				if (DatePicker3.SelectedDate != null) Item.SetFieldValue(Item["terminoRealizado"], DatePicker3.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoRealizado"], DBNull.Value);
				Item.SetFieldValue(Item["nomeSobrenome"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["responsavelSubstituto"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["observacao"], RadTextBox6.Text, false);
				Item.SetFieldValue(Item["siglaCoordenacao"], cmbSiglaCoordenacao.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox8.Text, false);
				if (DatePicker5.SelectedDate != null) Item.SetFieldValue(Item["inicioRealizado"], DatePicker5.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioRealizado"], DBNull.Value);
				if (txtInicioPrevisto.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], txtInicioPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["projeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["DiasPrevistos"], RadTextBox9.Text, false);
				Item.SetFieldValue(Item["DiasRealizados"], RadTextBox10.Text, false);
				Item.SetFieldValue(Item["statusAcao"], ComboBox5.SelectedValue);
				Item.SetFieldValue(Item["situacao"], RadTextBox13.Text, false);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox7.Text, false);
				if (DatePicker4.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker4.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
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
			Mask.SetMask(txtItemProjeto, "99999", 5, true);
			Mask.SetMask(RadTextBox3, "@!", 255, false);
			Mask.SetMask(txtTerminoPrevisto.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(DatePicker3.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox8, "999,99", 6, true);
			Mask.SetMask(DatePicker5.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtInicioPrevisto.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox1, "9999999999", 10, true);
			Mask.SetMask(RadTextBox9, "999", 3, true);
			Mask.SetMask(RadTextBox10, "999", 3, true);
			Mask.SetMask(RadTextBox13, "@!", 20, false);
			Mask.SetMask(RadTextBox7, "@!", 50, false);
			Mask.SetMask(DatePicker4.DateInput, "99/99/9999", 10, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(ComboBox2);
			Utility.SetControlTabOnEnter(RadTextBox6);
			Utility.SetControlTabOnEnter(cmbSiglaCoordenacao);
			Utility.SetControlTabOnEnter(ComboBox4);
			Utility.SetControlTabOnEnter(ComboBox5);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox3.Attributes.Add("EnableEdit", "True");
			DatePicker3.Attributes.Add("EnableEdit", "True");
			ComboBox1.Attributes.Add("EnableEdit", "True");
			ComboBox2.Attributes.Add("EnableEdit", "True");
			RadTextBox6.Attributes.Add("EnableEdit", "True");
			ComboBox4.Attributes.Add("EnableEdit", "True");
			DatePicker5.Attributes.Add("EnableEdit", "True");
			ComboBox5.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				txtItemProjeto.Text = "";
				RadTextBox3.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				cmbSiglaCoordenacao.SelectedIndex = -1;
				cmbSiglaCoordenacao.Text = "";
				ComboBox4.SelectedIndex = -1;
				ComboBox4.Text = "";
				RadTextBox8.Text = "";
				RadTextBox1.Text = "";
				RadTextBox9.Text = "";
				RadTextBox10.Text = "";
				ComboBox5.SelectedIndex = -1;
				ComboBox5.Text = "";
				RadTextBox13.Text = "";
				RadTextBox7.Text = "";
			if (ShouldClearFields)
			{
				txtTerminoPrevisto.SelectedDate = null;
				DatePicker3.SelectedDate = null;
				RadTextBox6.Text = "";
				DatePicker5.SelectedDate = null;
				txtInicioPrevisto.SelectedDate = null;
				DatePicker4.SelectedDate = null;
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			txtTerminoPrevisto.SelectedDate = null;
			DatePicker3.SelectedDate = null;
			try
			{
				SelectComboItem(cmbSiglaCoordenacao, PageProvider.cmbSiglaCoordenacaoProvider, ParamCoordenacao.ToString());
			}
			catch (Exception e)
			{
				cmbSiglaCoordenacao.SelectedValue = "";
				cmbSiglaCoordenacao.Text = "";
			}
			DatePicker5.SelectedDate = null;
			txtInicioPrevisto.SelectedDate = null;
			try
			{
				RadTextBox1.Text = (int.Parse(ParamCodigoProjeto)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				RadTextBox7.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
			}
			catch (Exception e)
			{
			}
			DatePicker4.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDate.ToString("dd/MM/yyyy"));
		}

		public override void PageEdit()
		{
			base.PageEdit(); 
		}

		public override void ShowFormulas()
		{
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
			Label3.Text = Label3.Text.Replace("<", "&lt;");
			Label3.Text = Label3.Text.Replace(">", "&gt;");
			Label5.Text = Label5.Text.Replace("<", "&lt;");
			Label5.Text = Label5.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
			Label8.Text = Label8.Text.Replace("<", "&lt;");
			Label8.Text = Label8.Text.Replace(">", "&gt;");
			Label9.Text = Label9.Text.Replace("<", "&lt;");
			Label9.Text = Label9.Text.Replace(">", "&gt;");
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
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label17.Text = Label17.Text.Replace("<", "&lt;");
			Label17.Text = Label17.Text.Replace(">", "&gt;");
			Label18.Text = Label18.Text.Replace("<", "&lt;");
			Label18.Text = Label18.Text.Replace(">", "&gt;");
			Label23.Text = Label23.Text.Replace("<", "&lt;");
			Label23.Text = Label23.Text.Replace(">", "&gt;");
			Label24.Text = Label24.Text.Replace("<", "&lt;");
			Label24.Text = Label24.Text.Replace(">", "&gt;");
			Label10.Text = Label10.Text.Replace("<", "&lt;");
			Label10.Text = Label10.Text.Replace(">", "&gt;");
			Label11.Text = Label11.Text.Replace("<", "&lt;");
			Label11.Text = Label11.Text.Replace(">", "&gt;");
			Label21.Text = Label21.Text.Replace("<", "&lt;");
			Label21.Text = Label21.Text.Replace(">", "&gt;");
			try { Label22.Text = (ParamNomeProjeto).ToString(); }
			catch { Label22.Text = ""; }
			Label22.Text = Label22.Text.Replace(double.NaN.ToString(), "");
			Label22.Text = Label22.Text.Replace("<", "&lt;");
			Label22.Text = Label22.Text.Replace(">", "&gt;");
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
					txtItemProjeto.Text = Item["itemProjeto"].GetFormattedValue();
				}
				else
				{
					txtItemProjeto.Text = "" ;
				}
			}
			catch
			{
				txtItemProjeto.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox3.Text = Item["nomeAcao"].GetFormattedValue();
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
			try { txtTerminoPrevisto.SelectedDate = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtTerminoPrevisto.SelectedDate = null; }
			try { DatePicker3.SelectedDate = Convert.ToDateTime(Item["terminoRealizado"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker3.SelectedDate = null; }
			try
			{
				string Val = Item["nomeSobrenome"].GetFormattedValue();
				SelectComboItem(ComboBox1, PageProvider.ComboBox1Provider, Val);
				ComboBox1.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox1.SelectedValue = "";
				ComboBox1.Text = "";
			}
			try
			{
				string Val = Item["responsavelSubstituto"].GetFormattedValue();
				SelectComboItem(ComboBox2, PageProvider.ComboBox2Provider, Val);
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
					RadTextBox6.Text = Item["observacao"].GetFormattedValue();
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
			try
			{
				string Val = Item["siglaCoordenacao"].GetFormattedValue();
				SelectComboItem(cmbSiglaCoordenacao, PageProvider.cmbSiglaCoordenacaoProvider, Val);
				cmbSiglaCoordenacao.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				cmbSiglaCoordenacao.SelectedValue = "";
				cmbSiglaCoordenacao.Text = "";
			}
			try
			{
				string Val = Item["siglaSetorial"].GetFormattedValue();
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
					RadTextBox8.Text = Item["percentualExecutado"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					RadTextBox8.Text = "" ;
				}
			}
			catch
			{
				RadTextBox8.Text = "" ;
			}
			try { DatePicker5.SelectedDate = Convert.ToDateTime(Item["inicioRealizado"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker5.SelectedDate = null; }
			try { txtInicioPrevisto.SelectedDate = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtInicioPrevisto.SelectedDate = null; }
			try
			{
				if (Item != null)
				{
					RadTextBox1.Text = Item["projeto"].GetFormattedValue();
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
				if (Item != null)
				{
					RadTextBox9.Text = Item["DiasPrevistos"].GetFormattedValue();
				}
				else
				{
					RadTextBox9.Text = "" ;
				}
			}
			catch
			{
				RadTextBox9.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox10.Text = Item["DiasRealizados"].GetFormattedValue();
				}
				else
				{
					RadTextBox10.Text = "" ;
				}
			}
			catch
			{
				RadTextBox10.Text = "" ;
			}
			try
			{
				string Val = Item["statusAcao"].GetFormattedValue();
				SelectComboItem(ComboBox5, PageProvider.ComboBox5Provider, Val);
				ComboBox5.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox5.SelectedValue = "";
				ComboBox5.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox13.Text = Item["situacao"].GetFormattedValue();
				}
				else
				{
					RadTextBox13.Text = "" ;
				}
			}
			catch
			{
				RadTextBox13.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox7.Text = Item["usuarioCadastro"].GetFormattedValue();
				}
				else
				{
					RadTextBox7.Text = "" ;
				}
			}
			catch
			{
				RadTextBox7.Text = "" ;
			}
			try { DatePicker4.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker4.SelectedDate = null; }
			ApplyMasks(txtItemProjeto);
			ApplyMasks(RadTextBox3);
			ApplyMasks(txtTerminoPrevisto);
			ApplyMasks(DatePicker3);
			ApplyMasks(RadTextBox6);
			ApplyMasks(RadTextBox8);
			ApplyMasks(DatePicker5);
			ApplyMasks(txtInicioPrevisto);
			ApplyMasks(RadTextBox1);
			ApplyMasks(RadTextBox9);
			ApplyMasks(RadTextBox10);
			ApplyMasks(RadTextBox13);
			ApplyMasks(RadTextBox7);
			ApplyMasks(DatePicker4);
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
					itemProjetoField = int.Parse(Item["itemProjeto"].GetFormattedValue());
				}
				else
				{
					itemProjetoField = 0;
				}
			}
			catch
			{
				itemProjetoField = 0;
			}
			try
			{
				if (Item != null)
				{
					nomeAcaoField = Item["nomeAcao"].GetFormattedValue();
				}
				else
				{
					nomeAcaoField = "";
				}
			}
			catch
			{
				nomeAcaoField = "";
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
				terminoRealizadoField = Convert.ToDateTime(Item["terminoRealizado"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				terminoRealizadoField = null;
			}
			try
			{
				nomeSobrenomeField = Item["nomeSobrenome"].GetFormattedValue();
			}
			catch
			{
				nomeSobrenomeField = "";
			}
			try
			{
				responsavelSubstitutoField = Item["responsavelSubstituto"].GetFormattedValue();
			}
			catch
			{
				responsavelSubstitutoField = "";
			}
			try
			{
				if (Item != null)
				{
					observacaoField = Item["observacao"].GetFormattedValue();
				}
				else
				{
					observacaoField = "";
				}
			}
			catch
			{
				observacaoField = "";
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
				siglaSetorialField = Item["siglaSetorial"].GetFormattedValue();
			}
			catch
			{
				siglaSetorialField = "";
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
				inicioRealizadoField = Convert.ToDateTime(Item["inicioRealizado"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				inicioRealizadoField = null;
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
				if (Item != null)
				{
					projetoField = long.Parse(Item["projeto"].GetFormattedValue());
				}
				else
				{
					projetoField = 0;
				}
			}
			catch
			{
				projetoField = 0;
			}
			try
			{
				if (Item != null)
				{
					DiasPrevistosField = int.Parse(Item["DiasPrevistos"].GetFormattedValue());
				}
				else
				{
					DiasPrevistosField = 0;
				}
			}
			catch
			{
				DiasPrevistosField = 0;
			}
			try
			{
				if (Item != null)
				{
					DiasRealizadosField = int.Parse(Item["DiasRealizados"].GetFormattedValue());
				}
				else
				{
					DiasRealizadosField = 0;
				}
			}
			catch
			{
				DiasRealizadosField = 0;
			}
			try
			{
				statusAcaoField = Item["statusAcao"].GetFormattedValue();
			}
			catch
			{
				statusAcaoField = "";
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
				dataCadastroField = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				dataCadastroField = null;
			}
			try
			{
				if (Item != null)
				{
					custoAcaoField = double.Parse(Item["custoAcao"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				custoAcaoField = 0;
				}
			}
			catch
			{
				custoAcaoField = 0;
			}
			PageProvider.AliasVariables.Add("itemProjetoField", itemProjetoField);
			PageProvider.AliasVariables.Add("nomeAcaoField", nomeAcaoField);
			PageProvider.AliasVariables.Add("terminoPrevistoField", terminoPrevistoField);
			PageProvider.AliasVariables.Add("terminoRealizadoField", terminoRealizadoField);
			PageProvider.AliasVariables.Add("nomeSobrenomeField", nomeSobrenomeField);
			PageProvider.AliasVariables.Add("responsavelSubstitutoField", responsavelSubstitutoField);
			PageProvider.AliasVariables.Add("observacaoField", observacaoField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("inicioRealizadoField", inicioRealizadoField);
			PageProvider.AliasVariables.Add("inicioPrevistoField", inicioPrevistoField);
			PageProvider.AliasVariables.Add("projetoField", projetoField);
			PageProvider.AliasVariables.Add("DiasPrevistosField", DiasPrevistosField);
			PageProvider.AliasVariables.Add("DiasRealizadosField", DiasRealizadosField);
			PageProvider.AliasVariables.Add("statusAcaoField", statusAcaoField);
			PageProvider.AliasVariables.Add("situacaoField", situacaoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("custoAcaoField", custoAcaoField);
			PageProvider.AliasVariables.Add("ParamCodigoProjeto", ParamCodigoProjeto);
			PageProvider.AliasVariables.Add("ParamItemProjeto", ParamItemProjeto);
			PageProvider.AliasVariables.Add("ParamCoordenacao", ParamCoordenacao);
			PageProvider.AliasVariables.Add("ParamNomeProjeto", ParamNomeProjeto);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				Form1_OnSaveSucceeded(Item);
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
					AjaxPanel.Alert("Item Salvo!");
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
				AjaxPanel.ResponseScripts.Add("try { GetRadWindow().Caller.Refresh();} catch (e) {}");
			}
			catch (Exception ex)
			{
				ActionSucceeded_3 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}

		protected void ___Form1_OnRemoveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
					AjaxPanel.Alert("Item Removido do Projeto!");
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
				AjaxPanel.ResponseScripts.Add("try { GetRadWindow().Caller.Refresh();} catch (e) {}");
			}
			catch (Exception ex)
			{
				ActionSucceeded_2 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}

		protected void ___Form1_LoadCompleted()
		{
			bool ActionSucceeded_1 = true;
			try
			{
				Form1_LoadCompleted();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}




		public override void ExecuteServerCommandRequest(string CommandName, string TargetName, string[] Parameters)
		{
			ExecuteLocalCommandRequest(CommandName, TargetName, Parameters);
		}		
		protected void ___ComboBox1_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			Dictionary<string, object> ClientFields = e.Context["ClientFields"] as Dictionary<string, object>;
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox1Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter, ClientFields);
		}
		
		protected void ___ComboBox2_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			Dictionary<string, object> ClientFields = e.Context["ClientFields"] as Dictionary<string, object>;
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox2Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter, ClientFields);
		}
		
		protected void ___cmbSiglaCoordenacao_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.cmbSiglaCoordenacaoProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox4_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox4Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox5_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox5Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		protected override void OnLoadComplete(EventArgs e)
		{
			___Form1_LoadCompleted();
			base.OnLoadComplete(e);
		}
		public override void OnRemoveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnRemoveSucceeded(Item);
		}
		public override void SaveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnSaveSucceeded(Item);
		}
#region CÓDIGO DE USUARIO
		private double nTotalProjetos;
		private double nSomaTotal;
		private double nPercentual;
		
		protected void Form1_LoadCompleted()
		{
			if (PageState == FormStateEnum.Insert)
			{
				string sql = "SELECT TOP 1 (ITEMPROJETO) FROM TB_ITENS_PROJETO WHERE PROJETO = " + ParamCodigoProjeto + " ORDER BY ITEMPROJETO DESC";
				// Função que faz select no BD e traz o último registro baseado no documento escolhido
				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				DataTable DT = Dao.RunSql(String.Format(sql)).Tables[0];

				if (DT.Rows.Count > 0) //Se tiver registros no banco 
				{
					int ultimoDoc = Convert.ToInt32(DT.Rows[0][0]);
					txtItemProjeto.Text = Convert.ToString(ultimoDoc + 1);
				}
				else
				{
					txtItemProjeto.Text = "1";
				}

				cmbSiglaCoordenacao.SelectedValue = ParamCoordenacao;
				siglaCoordenacaoField = ParamCoordenacao;

				Dao.CloseConnection();
				Dao.Dispose();
			}
		}

		protected void Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			// Percentual das Diretrizes
			string sql3 = "SELECT COUNT(PROJETO) FROM TB_ITENS_PROJETO A WHERE A.PROJETO =  " + projetoField.ToString() + " AND A.STATUSACAO != 'SUSPENSO'";
			DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);	
			Dao.OpenConnection();
			
			DataTable DT3 = Dao.RunSql(String.Format(sql3)).Tables[0];

			if (DT3.Rows.Count > 0) //Se tiver registros no banco 
			{
				nTotalProjetos = Convert.ToInt32(DT3.Rows[0][0].ToString());
			}
			Dao.CloseConnection();
			Dao.Dispose();
		
			string sql4 = "SELECT SUM(PERCENTUALEXECUTADO) FROM TB_ITENS_PROJETO B WHERE B.PROJETO =  " + projetoField.ToString() + " AND B.STATUSACAO != 'SUSPENSO'";

			Dao.OpenConnection();

			DataTable DT4 = Dao.RunSql(String.Format(sql4)).Tables[0];

			if (DT4.Rows.Count > 0) //Se tiver registros no banco 
			{
				nSomaTotal = Convert.ToDouble(DT4.Rows[0][0].ToString());
			}

			nPercentual = (nSomaTotal / nTotalProjetos);
			
			string sql6 = "UPDATE TB_PROJETO SET TB_PROJETO.percentualExecutado = "+ nPercentual.ToString("C",CultureInfo.CreateSpecificCulture("en-US")) + " WHERE TB_PROJETO.codigo = "+ projetoField.ToString();			
            Dao.ExecuteNonQuery(String.Format(sql6));
			
			Dao.CloseConnection();
			Dao.Dispose();
			
			// ************************************************************************ //
			try
            {
				// Atualiza Ação "SUSPENSO"
				string sql7 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'SUSPENSO' FROM TB_ITENS_PROJETO A WHERE A.STATUSACAO = 'SUSPENSO'";

				//DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
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
		}
#endregion
	}
}

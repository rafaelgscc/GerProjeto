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
	public partial class CadastroDiretriz : GeneralDataPage
	{
		protected CadastroDeDiretrizPageProvider PageProvider;
	

		public string btnSalvarField = "btnSalvar";
		public string nomeProjetoField = "";
		public string DiretrizField = "";
		public string statusProjetoField = "";
		public double percentualExecutadoField = 0;
		public double custoProjetoField = 0;
		public long codigoField = 0;
		public DateTime ? inicioPrevistoField;
		public DateTime ? terminoPrevistoField;
		public long DiasDeProjetoField = 0;
		public DateTime ? terminoRealizadoField;
		public string nivelProjetoField = "";
		public string siglaDiretoriaField = "";
		public string siglaSetorialField = "";
		public string siglaCoordenacaoField = "";
		public string situacaoField = "";
		public int anoProjetoField = 0;
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField;
		
		public override string FormID { get { return "32734"; } }
		public override string TableName { get { return "TB_PROJETO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "CadastroDiretriz.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamCod_Projeto = "";
		public string ParamCoordenacao = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCod_Projeto))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCod_Projeto.ToString(), FieldType.Integer);
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
				if (!String.IsNullOrEmpty(ParamCod_Projeto))
				{
					return Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCod_Projeto.ToString(), FieldType.Integer);
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
			PageProvider = new CadastroDeDiretrizPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamCod_Projeto = HttpContext.Current.Request.QueryString["ParamCod_Projeto"];
			try { if (string.IsNullOrEmpty(ParamCod_Projeto)) ParamCod_Projeto = HttpContext.Current.Session["ParamCod_Projeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCod_Projeto)) ParamCod_Projeto = "0";
			ParamCoordenacao = HttpContext.Current.Request.QueryString["ParamCoordenacao"];
			try { if (string.IsNullOrEmpty(ParamCoordenacao)) ParamCoordenacao = HttpContext.Current.Session["ParamCoordenacao"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCoordenacao)) ParamCoordenacao = "";
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
				Item.SetFieldValue(Item["nomeProjeto"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["Diretriz"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["statusProjeto"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["custoProjeto"], RadTextBox5.Text, false);
				if (txtInicioPrevisto.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], txtInicioPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (txtTerminoPrevisto.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], txtTerminoPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["DiasDeProjeto"], txtDiasDeProjeto.Text, false);
				if (DatePicker4.SelectedDate != null) Item.SetFieldValue(Item["terminoRealizado"], DatePicker4.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoRealizado"], DBNull.Value);
				Item.SetFieldValue(Item["nivelProjeto"], ComboBox3.SelectedValue);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], ComboBox6.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox7.SelectedValue);
				Item.SetFieldValue(Item["situacao"], RadTextBox6.Text, false);
				Item.SetFieldValue(Item["anoProjeto"], ComboBox8.SelectedValue);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox3.Text, false);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
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
				Item.SetFieldValue(Item["nomeProjeto"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["Diretriz"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["statusProjeto"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["custoProjeto"], RadTextBox5.Text, false);
				if (txtInicioPrevisto.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], txtInicioPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (txtTerminoPrevisto.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], txtTerminoPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				Item.SetFieldValue(Item["DiasDeProjeto"], txtDiasDeProjeto.Text, false);
				if (DatePicker4.SelectedDate != null) Item.SetFieldValue(Item["terminoRealizado"], DatePicker4.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoRealizado"], DBNull.Value);
				Item.SetFieldValue(Item["nivelProjeto"], ComboBox3.SelectedValue);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], ComboBox6.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox7.SelectedValue);
				Item.SetFieldValue(Item["situacao"], RadTextBox6.Text, false);
				Item.SetFieldValue(Item["anoProjeto"], ComboBox8.SelectedValue);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox3.Text, false);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
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
			Mask.SetMask(RadTextBox2, "@!", 255, false);
			Mask.SetMask(RadTextBox4, "999,99", 6, true);
			Mask.SetMask(RadTextBox5, "99.999.999.999,99", 17, true);
			Mask.SetMask(RadTextBox1, "9999999999", 10, true);
			Mask.SetMask(txtInicioPrevisto.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtTerminoPrevisto.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtDiasDeProjeto, "9999999999", 10, true);
			Mask.SetMask(DatePicker4.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox6, "@!", 20, false);
			Mask.SetMask(RadTextBox3, "@!", 50, false);
			Mask.SetMask(DatePicker1.DateInput, "99/99/9999", 10, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(ComboBox2);
			Utility.SetControlTabOnEnter(ComboBox3);
			Utility.SetControlTabOnEnter(ComboBox4);
			Utility.SetControlTabOnEnter(ComboBox6);
			Utility.SetControlTabOnEnter(ComboBox7);
			Utility.SetControlTabOnEnter(ComboBox8);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox2.Attributes.Add("EnableEdit", "True");
			ComboBox1.Attributes.Add("EnableEdit", "True");
			ComboBox2.Attributes.Add("EnableEdit", "True");
			RadTextBox5.Attributes.Add("EnableEdit", "True");
			ComboBox3.Attributes.Add("EnableEdit", "True");
			ComboBox4.Attributes.Add("EnableEdit", "True");
			ComboBox6.Attributes.Add("EnableEdit", "True");
			ComboBox7.Attributes.Add("EnableEdit", "True");
			ComboBox8.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox1.Text = "";
			if (ShouldClearFields)
			{
				RadTextBox2.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				RadTextBox4.Text = "";
				RadTextBox5.Text = "";
				txtInicioPrevisto.SelectedDate = null;
				txtTerminoPrevisto.SelectedDate = null;
				txtDiasDeProjeto.Text = "";
				DatePicker4.SelectedDate = null;
				ComboBox3.SelectedIndex = -1;
				ComboBox3.Text = "";
				ComboBox4.SelectedIndex = -1;
				ComboBox4.Text = "";
				ComboBox6.SelectedIndex = -1;
				ComboBox6.Text = "";
				ComboBox7.SelectedIndex = -1;
				ComboBox7.Text = "";
				RadTextBox6.Text = "";
				ComboBox8.SelectedIndex = -1;
				ComboBox8.Text = "";
				RadTextBox3.Text = "";
				DatePicker1.SelectedDate = null;
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			try
			{
				RadTextBox1.Text = (int.Parse(ParamCod_Projeto)).ToString();
			}
			catch (Exception e)
			{
			}
			txtInicioPrevisto.SelectedDate = null;
			txtTerminoPrevisto.SelectedDate = null;
			DatePicker4.SelectedDate = null;
			try
			{
				RadTextBox3.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
			}
			catch (Exception e)
			{
			}
			DatePicker1.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDate.ToString("dd/MM/yyyy"));
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
			Label4.Text = Label4.Text.Replace("<", "&lt;");
			Label4.Text = Label4.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
			Label8.Text = Label8.Text.Replace("<", "&lt;");
			Label8.Text = Label8.Text.Replace(">", "&gt;");
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label9.Text = Label9.Text.Replace("<", "&lt;");
			Label9.Text = Label9.Text.Replace(">", "&gt;");
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
			Label17.Text = Label17.Text.Replace("<", "&lt;");
			Label17.Text = Label17.Text.Replace(">", "&gt;");
			Label19.Text = Label19.Text.Replace("<", "&lt;");
			Label19.Text = Label19.Text.Replace(">", "&gt;");
			Label5.Text = Label5.Text.Replace("<", "&lt;");
			Label5.Text = Label5.Text.Replace(">", "&gt;");
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
					RadTextBox2.Text = Item["nomeProjeto"].GetFormattedValue();
				}
				else
				{
					RadTextBox2.Text = "" ;
				}
			}
			catch
			{
				RadTextBox2.Text = "" ;
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
					RadTextBox4.Text = Item["percentualExecutado"].GetFormattedValue().Replace(".",",");
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
			try
			{
				if (Item != null)
				{
					RadTextBox5.Text = Item["custoProjeto"].GetFormattedValue().Replace(".",",");
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
					RadTextBox1.Text = Item["codigo"].GetFormattedValue();
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
			try { txtInicioPrevisto.SelectedDate = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtInicioPrevisto.SelectedDate = null; }
			try { txtTerminoPrevisto.SelectedDate = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtTerminoPrevisto.SelectedDate = null; }
			try
			{
				if (Item != null)
				{
					txtDiasDeProjeto.Text = Item["DiasDeProjeto"].GetFormattedValue();
				}
				else
				{
					txtDiasDeProjeto.Text = "" ;
				}
			}
			catch
			{
				txtDiasDeProjeto.Text = "" ;
			}
			try { DatePicker4.SelectedDate = Convert.ToDateTime(Item["terminoRealizado"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker4.SelectedDate = null; }
			try
			{
				string Val = Item["nivelProjeto"].GetFormattedValue();
				RadComboBoxDataItem ComboBox3item = Utility.FindComboBoxItem(PageProvider.ComboBox3Items, Val);
				ComboBox3.Text = ComboBox3item.Text;
				ComboBox3.SelectedValue = ComboBox3item.Value;
				ComboBox3.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox3.SelectedValue = "";
				ComboBox3.Text = "";
			}
			try
			{
				string Val = Item["siglaDiretoria"].GetFormattedValue();
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
				string Val = Item["siglaSetorial"].GetFormattedValue();
				SelectComboItem(ComboBox6, PageProvider.ComboBox6Provider, Val);
				ComboBox6.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox6.SelectedValue = "";
				ComboBox6.Text = "";
			}
			try
			{
				string Val = Item["siglaCoordenacao"].GetFormattedValue();
				SelectComboItem(ComboBox7, PageProvider.ComboBox7Provider, Val);
				ComboBox7.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox7.SelectedValue = "";
				ComboBox7.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox6.Text = Item["situacao"].GetFormattedValue();
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
				string Val = Item["anoProjeto"].GetFormattedValue();
				GeneralDataProviderItem item = PageProvider.GetComboItem(PageProvider.ComboBox8Provider, Val);
				ComboBox8.Text = item["ano"].Value.ToString();
				ComboBox8.SelectedValue = Val;
				ComboBox8.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox8.SelectedValue = "";
				ComboBox8.Text = "";
			}
			try
			{
				if (Item != null)
				{
					RadTextBox3.Text = Item["usuarioCadastro"].GetFormattedValue();
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
			try { DatePicker1.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker1.SelectedDate = null; }
			ApplyMasks(RadTextBox2);
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox5);
			ApplyMasks(RadTextBox1);
			ApplyMasks(txtInicioPrevisto);
			ApplyMasks(txtTerminoPrevisto);
			ApplyMasks(txtDiasDeProjeto);
			ApplyMasks(DatePicker4);
			ApplyMasks(RadTextBox6);
			ApplyMasks(RadTextBox3);
			ApplyMasks(DatePicker1);
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
					custoProjetoField = double.Parse(Item["custoProjeto"].GetFormattedValue().Replace(".",","));
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
				terminoRealizadoField = Convert.ToDateTime(Item["terminoRealizado"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				terminoRealizadoField = null;
			}
			try
			{
				nivelProjetoField = Item["nivelProjeto"].GetFormattedValue();
			}
			catch
			{
				nivelProjetoField = "";
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
				siglaSetorialField = Item["siglaSetorial"].GetFormattedValue();
			}
			catch
			{
				siglaSetorialField = "";
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
				anoProjetoField = int.Parse(Item["anoProjeto"].GetFormattedValue());
			}
			catch
			{
				anoProjetoField = 0;
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
			PageProvider.AliasVariables.Add("nomeProjetoField", nomeProjetoField);
			PageProvider.AliasVariables.Add("DiretrizField", DiretrizField);
			PageProvider.AliasVariables.Add("statusProjetoField", statusProjetoField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("custoProjetoField", custoProjetoField);
			PageProvider.AliasVariables.Add("codigoField", codigoField);
			PageProvider.AliasVariables.Add("inicioPrevistoField", inicioPrevistoField);
			PageProvider.AliasVariables.Add("terminoPrevistoField", terminoPrevistoField);
			PageProvider.AliasVariables.Add("DiasDeProjetoField", DiasDeProjetoField);
			PageProvider.AliasVariables.Add("terminoRealizadoField", terminoRealizadoField);
			PageProvider.AliasVariables.Add("nivelProjetoField", nivelProjetoField);
			PageProvider.AliasVariables.Add("siglaDiretoriaField", siglaDiretoriaField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("situacaoField", situacaoField);
			PageProvider.AliasVariables.Add("anoProjetoField", anoProjetoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("ParamCod_Projeto", ParamCod_Projeto);
			PageProvider.AliasVariables.Add("ParamCoordenacao", ParamCoordenacao);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
					AjaxPanel.Alert("Registro Salvo!");
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

		protected void ___Form1_OnRemoveSucceeded(GeneralDataProviderItem Item)
		{
			bool ActionSucceeded_1 = true;
			try
			{
					AjaxPanel.Alert("Registro APAGADO!");
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
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox3Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox4_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox4Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox6_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox6Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox7_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox7Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox8_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox8Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		public override void OnRemoveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnRemoveSucceeded(Item);
		}
		public override void SaveSucceeded(GeneralDataProviderItem Item)
		{
			___Form1_OnSaveSucceeded(Item);
		}
	}
}

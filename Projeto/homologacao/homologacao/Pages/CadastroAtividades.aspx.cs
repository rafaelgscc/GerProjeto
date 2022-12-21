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
	public partial class CadastroAtividades : GeneralDataPage
	{
		protected CadastroAtividadesPageProvider PageProvider;
	

		public string btnSalvarField = "btnSalvar";
		public long projetoField = 0;
		public int itemProjetoField = 0;
		public int itemProcessoField = 0;
		public string nomeProcessoField = "";
		public int DiasPrevistosField = 0;
		public int DiasRealizadosField = 0;
		public string siglaCoordenacaoField = "";
		public string siglaSetorialField = "";
		public string nomeSobrenomeField = "";
		public string responsavelSubstitutoField = "";
		public string situacaoField = "";
		public DateTime ? inicioPrevistoField;
		public DateTime ? terminoPrevistoField;
		public DateTime ? inicioRealizadoField;
		public DateTime ? terminoRealizadoField;
		public double percentualExecutadoField = 0;
		public string situacaoProjetoField = "";
		public DateTime ? dataCadastroField;
		public string usuarioCadastroField = "";
		
		public override string FormID { get { return "32776"; } }
		public override string TableName { get { return "TB_PROCESSOS"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "CadastroAtividades.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamProjeto = "";
		public string ParamAcao = "";
		public string ParamAtividade = "";
		public string ParamCoordenacao = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamProjeto) && !String.IsNullOrEmpty(ParamAcao) && !String.IsNullOrEmpty(ParamAtividade))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = "((" + Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(ParamProjeto.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(ParamAcao.ToString(), FieldType.Integer) + " ) and " + Dao.PoeColAspas("itemProcesso") + " = " + Dao.ToSql(ParamAtividade.ToString(), FieldType.Integer);
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
			PageProvider = new CadastroAtividadesPageProvider(this);
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
			ParamProjeto = HttpContext.Current.Request.QueryString["ParamProjeto"];
			try { if (string.IsNullOrEmpty(ParamProjeto)) ParamProjeto = HttpContext.Current.Session["ParamProjeto"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamProjeto)) ParamProjeto = "0";
			ParamAcao = HttpContext.Current.Request.QueryString["ParamAcao"];
			try { if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = HttpContext.Current.Session["ParamAcao"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamAcao)) ParamAcao = "0";
			ParamAtividade = HttpContext.Current.Request.QueryString["ParamAtividade"];
			try { if (string.IsNullOrEmpty(ParamAtividade)) ParamAtividade = HttpContext.Current.Session["ParamAtividade"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamAtividade)) ParamAtividade = "0";
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
		/// Define os Parâmetros para acesso às tabelas auxiliares
		/// </summary>
		public override void SetParametersValues(GeneralDataProvider Provider)
		{
			try
			{
				if (Provider == PageProvider.AUX_CadastroAtividades_TB_ITENS_PROJETOProvider && Provider.IndexName == "PK_TB_ITENS_PROJETO")
				{
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["projeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["projeto"].GetValue()));
					}
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["itemProjeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetValue()));
					}
				}
			}
			catch
			{
			}
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
				Item.SetFieldValue(Item["projeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["itemProjeto"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["itemProcesso"], txtItemProcesso.Text, false);
				Item.SetFieldValue(Item["nomeProcesso"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["DiasPrevistos"], RadTextBox7.Text, false);
				Item.SetFieldValue(Item["DiasRealizados"], RadTextBox8.Text, false);
				Item.SetFieldValue(Item["siglaCoordenacao"], cmbSiglaCoordenacao.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], cmbSiglaSetorial.SelectedValue);
				Item.SetFieldValue(Item["nomeSobrenome"], ComboBox3.SelectedValue);
				Item.SetFieldValue(Item["responsavelSubstituto"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["situacao"], txtSituacao.Text, false);
				if (txtInicioPrevisto.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], txtInicioPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (txtTerminoPrevisto.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], txtTerminoPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				if (txtInicioRealizado.SelectedDate != null) Item.SetFieldValue(Item["inicioRealizado"], txtInicioRealizado.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioRealizado"], DBNull.Value);
				if (txtTerminoRealizado.SelectedDate != null) Item.SetFieldValue(Item["terminoRealizado"], txtTerminoRealizado.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoRealizado"], DBNull.Value);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox12.Text, false);
				Item.SetFieldValue(Item["situacaoProjeto"], CbxSituacaoStatus.SelectedValue);
				if (DatePicker5.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker5.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox11.Text, false);
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
				Item.SetFieldValue(Item["projeto"], RadTextBox1.Text, false);
				Item.SetFieldValue(Item["itemProjeto"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["itemProcesso"], txtItemProcesso.Text, false);
				Item.SetFieldValue(Item["nomeProcesso"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["DiasPrevistos"], RadTextBox7.Text, false);
				Item.SetFieldValue(Item["DiasRealizados"], RadTextBox8.Text, false);
				Item.SetFieldValue(Item["siglaCoordenacao"], cmbSiglaCoordenacao.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], cmbSiglaSetorial.SelectedValue);
				Item.SetFieldValue(Item["nomeSobrenome"], ComboBox3.SelectedValue);
				Item.SetFieldValue(Item["responsavelSubstituto"], ComboBox4.SelectedValue);
				Item.SetFieldValue(Item["situacao"], txtSituacao.Text, false);
				if (txtInicioPrevisto.SelectedDate != null) Item.SetFieldValue(Item["inicioPrevisto"], txtInicioPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioPrevisto"], DBNull.Value);
				if (txtTerminoPrevisto.SelectedDate != null) Item.SetFieldValue(Item["terminoPrevisto"], txtTerminoPrevisto.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoPrevisto"], DBNull.Value);
				if (txtInicioRealizado.SelectedDate != null) Item.SetFieldValue(Item["inicioRealizado"], txtInicioRealizado.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["inicioRealizado"], DBNull.Value);
				if (txtTerminoRealizado.SelectedDate != null) Item.SetFieldValue(Item["terminoRealizado"], txtTerminoRealizado.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["terminoRealizado"], DBNull.Value);
				Item.SetFieldValue(Item["percentualExecutado"], RadTextBox12.Text, false);
				Item.SetFieldValue(Item["situacaoProjeto"], CbxSituacaoStatus.SelectedValue);
				if (DatePicker5.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker5.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox11.Text, false);
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
			Mask.SetMask(RadTextBox1, "9999999999", 10, true);
			Mask.SetMask(RadTextBox2, "99999", 5, true);
			Mask.SetMask(txtItemProcesso, "99999", 5, true);
			Mask.SetMask(RadTextBox4, "@!", 255, false);
			Mask.SetMask(RadTextBox7, "999", 3, true);
			Mask.SetMask(RadTextBox8, "999", 3, true);
			Mask.SetMask(txtSituacao, "@!", 20, false);
			Mask.SetMask(txtInicioPrevisto.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtTerminoPrevisto.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtInicioRealizado.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(txtTerminoRealizado.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox12, "999,99", 6, true);
			Mask.SetMask(DatePicker5.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox11, "@!", 50, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(cmbSiglaCoordenacao);
			Utility.SetControlTabOnEnter(cmbSiglaSetorial);
			Utility.SetControlTabOnEnter(ComboBox3);
			Utility.SetControlTabOnEnter(ComboBox4);
			Utility.SetControlTabOnEnter(CbxSituacaoStatus);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox4.Attributes.Add("EnableEdit", "True");
			cmbSiglaSetorial.Attributes.Add("EnableEdit", "True");
			ComboBox3.Attributes.Add("EnableEdit", "True");
			ComboBox4.Attributes.Add("EnableEdit", "True");
			txtInicioPrevisto.Attributes.Add("EnableEdit", "True");
			txtTerminoPrevisto.Attributes.Add("EnableEdit", "True");
			txtInicioRealizado.Attributes.Add("EnableEdit", "True");
			txtTerminoRealizado.Attributes.Add("EnableEdit", "True");
			CbxSituacaoStatus.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox1.Text = "";
				RadTextBox2.Text = "";
				txtItemProcesso.Text = "";
				RadTextBox4.Text = "";
				RadTextBox7.Text = "";
				RadTextBox8.Text = "";
				cmbSiglaCoordenacao.SelectedIndex = -1;
				cmbSiglaCoordenacao.Text = "";
				cmbSiglaSetorial.SelectedIndex = -1;
				cmbSiglaSetorial.Text = "";
				ComboBox3.SelectedIndex = -1;
				ComboBox3.Text = "";
				ComboBox4.SelectedIndex = -1;
				ComboBox4.Text = "";
				txtSituacao.Text = "";
				RadTextBox12.Text = "";
				CbxSituacaoStatus.SelectedIndex = -1;
				CbxSituacaoStatus.Text = "";
				RadTextBox11.Text = "";
			if (ShouldClearFields)
			{
				txtInicioPrevisto.SelectedDate = null;
				txtTerminoPrevisto.SelectedDate = null;
				txtInicioRealizado.SelectedDate = null;
				txtTerminoRealizado.SelectedDate = null;
				DatePicker5.SelectedDate = null;
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
				RadTextBox1.Text = (int.Parse(ParamProjeto)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				RadTextBox2.Text = (int.Parse(ParamAcao)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				txtItemProcesso.Text = (int.Parse(ParamAtividade)).ToString();
			}
			catch (Exception e)
			{
			}
			try
			{
				SelectComboItem(cmbSiglaCoordenacao, PageProvider.cmbSiglaCoordenacaoProvider, ParamCoordenacao.ToString());
			}
			catch (Exception e)
			{
				cmbSiglaCoordenacao.SelectedValue = "";
				cmbSiglaCoordenacao.Text = "";
			}
			txtInicioPrevisto.SelectedDate = null;
			txtTerminoPrevisto.SelectedDate = null;
			txtInicioRealizado.SelectedDate = null;
			txtTerminoRealizado.SelectedDate = null;
			DatePicker5.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDate.ToString("dd/MM/yyyy"));
			try
			{
				RadTextBox11.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
			}
			catch (Exception e)
			{
			}
		}

		public override void PageEdit()
		{
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
			Label4.Text = Label4.Text.Replace("<", "&lt;");
			Label4.Text = Label4.Text.Replace(">", "&gt;");
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
			Label17.Text = Label17.Text.Replace("<", "&lt;");
			Label17.Text = Label17.Text.Replace(">", "&gt;");
			Label18.Text = Label18.Text.Replace("<", "&lt;");
			Label18.Text = Label18.Text.Replace(">", "&gt;");
			LblStatusSituacao.Text = LblStatusSituacao.Text.Replace("<", "&lt;");
			LblStatusSituacao.Text = LblStatusSituacao.Text.Replace(">", "&gt;");
			Label15.Text = Label15.Text.Replace("<", "&lt;");
			Label15.Text = Label15.Text.Replace(">", "&gt;");
			Label16.Text = Label16.Text.Replace("<", "&lt;");
			Label16.Text = Label16.Text.Replace(">", "&gt;");
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
					RadTextBox2.Text = Item["itemProjeto"].GetFormattedValue();
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
				if (Item != null)
				{
					txtItemProcesso.Text = Item["itemProcesso"].GetFormattedValue();
				}
				else
				{
					txtItemProcesso.Text = "" ;
				}
			}
			catch
			{
				txtItemProcesso.Text = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox4.Text = Item["nomeProcesso"].GetFormattedValue();
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
					RadTextBox7.Text = Item["DiasPrevistos"].GetFormattedValue();
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
			try
			{
				if (Item != null)
				{
					RadTextBox8.Text = Item["DiasRealizados"].GetFormattedValue();
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
				SelectComboItem(cmbSiglaSetorial, PageProvider.cmbSiglaSetorialProvider, Val);
				cmbSiglaSetorial.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				cmbSiglaSetorial.SelectedValue = "";
				cmbSiglaSetorial.Text = "";
			}
			try
			{
				string Val = Item["nomeSobrenome"].GetFormattedValue();
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
				string Val = Item["responsavelSubstituto"].GetFormattedValue();
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
					txtSituacao.Text = Item["situacao"].GetFormattedValue();
				}
				else
				{
					txtSituacao.Text = "" ;
				}
			}
			catch
			{
				txtSituacao.Text = "" ;
			}
			try { txtInicioPrevisto.SelectedDate = Convert.ToDateTime(Item["inicioPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtInicioPrevisto.SelectedDate = null; }
			try { txtTerminoPrevisto.SelectedDate = Convert.ToDateTime(Item["terminoPrevisto"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtTerminoPrevisto.SelectedDate = null; }
			try { txtInicioRealizado.SelectedDate = Convert.ToDateTime(Item["inicioRealizado"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtInicioRealizado.SelectedDate = null; }
			try { txtTerminoRealizado.SelectedDate = Convert.ToDateTime(Item["terminoRealizado"].GetFormattedValue("dd/MM/yyyy")); }
			catch { txtTerminoRealizado.SelectedDate = null; }
			try
			{
				if (Item != null)
				{
					RadTextBox12.Text = Item["percentualExecutado"].GetFormattedValue().Replace(".",",");
				}
				else
				{
					RadTextBox12.Text = "" ;
				}
			}
			catch
			{
				RadTextBox12.Text = "" ;
			}
			try
			{
				string Val = Item["situacaoProjeto"].GetFormattedValue();
				GeneralDataProviderItem item = PageProvider.GetComboItem(PageProvider.CbxSituacaoStatusProvider, Val);
				CbxSituacaoStatus.Text = item["situacao_projeto"].Value.ToString();
				CbxSituacaoStatus.SelectedValue = Val;
				CbxSituacaoStatus.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				CbxSituacaoStatus.SelectedValue = "";
				CbxSituacaoStatus.Text = "";
			}
			try { DatePicker5.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker5.SelectedDate = null; }
			try
			{
				if (Item != null)
				{
					RadTextBox11.Text = Item["usuarioCadastro"].GetFormattedValue();
				}
				else
				{
					RadTextBox11.Text = "" ;
				}
			}
			catch
			{
				RadTextBox11.Text = "" ;
			}
			ApplyMasks(RadTextBox1);
			ApplyMasks(RadTextBox2);
			ApplyMasks(txtItemProcesso);
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox7);
			ApplyMasks(RadTextBox8);
			ApplyMasks(txtSituacao);
			ApplyMasks(txtInicioPrevisto);
			ApplyMasks(txtTerminoPrevisto);
			ApplyMasks(txtInicioRealizado);
			ApplyMasks(txtTerminoRealizado);
			ApplyMasks(RadTextBox12);
			ApplyMasks(DatePicker5);
			ApplyMasks(RadTextBox11);
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
					itemProcessoField = int.Parse(Item["itemProcesso"].GetFormattedValue());
				}
				else
				{
					itemProcessoField = 0;
				}
			}
			catch
			{
				itemProcessoField = 0;
			}
			try
			{
				if (Item != null)
				{
					nomeProcessoField = Item["nomeProcesso"].GetFormattedValue();
				}
				else
				{
					nomeProcessoField = "";
				}
			}
			catch
			{
				nomeProcessoField = "";
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
				inicioRealizadoField = Convert.ToDateTime(Item["inicioRealizado"].GetFormattedValue("dd/MM/yyyy"));
			}
			catch
			{
				inicioRealizadoField = null;
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
				situacaoProjetoField = Item["situacaoProjeto"].GetFormattedValue();
			}
			catch
			{
				situacaoProjetoField = "";
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
			PageProvider.AliasVariables.Add("projetoField", projetoField);
			PageProvider.AliasVariables.Add("itemProjetoField", itemProjetoField);
			PageProvider.AliasVariables.Add("itemProcessoField", itemProcessoField);
			PageProvider.AliasVariables.Add("nomeProcessoField", nomeProcessoField);
			PageProvider.AliasVariables.Add("DiasPrevistosField", DiasPrevistosField);
			PageProvider.AliasVariables.Add("DiasRealizadosField", DiasRealizadosField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("nomeSobrenomeField", nomeSobrenomeField);
			PageProvider.AliasVariables.Add("responsavelSubstitutoField", responsavelSubstitutoField);
			PageProvider.AliasVariables.Add("situacaoField", situacaoField);
			PageProvider.AliasVariables.Add("inicioPrevistoField", inicioPrevistoField);
			PageProvider.AliasVariables.Add("terminoPrevistoField", terminoPrevistoField);
			PageProvider.AliasVariables.Add("inicioRealizadoField", inicioRealizadoField);
			PageProvider.AliasVariables.Add("terminoRealizadoField", terminoRealizadoField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("situacaoProjetoField", situacaoProjetoField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("ParamProjeto", ParamProjeto);
			PageProvider.AliasVariables.Add("ParamAcao", ParamAcao);
			PageProvider.AliasVariables.Add("ParamAtividade", ParamAtividade);
			PageProvider.AliasVariables.Add("ParamCoordenacao", ParamCoordenacao);
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
				Form1_OnSaveSucceeded_1(Item);
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
				Form1_OnSaveSucceeded_3(Item);
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
				Form1_OnRemoveSucceeded(Item);
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
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
		
		/// <summary>
		/// Carrega os objetos de tela para o Item Provider da grid
		/// </summary>
		public override GeneralDataProviderItem LoadItemFromGridControl(bool EnableValidation, string GridId)
		{
			GeneralDataProviderItem Item = null;
			switch (GridId)
			{
				case "Grid1":
					if (PageProvider.CadastroAtividades_Grid1Provider.DataProvider.Item == null)
						Item = PageProvider.CadastroAtividades_Grid1Provider.GetDataProviderItem();
					else
						Item = PageProvider.CadastroAtividades_Grid1Provider.DataProvider.Item;
					PageProvider.CadastroAtividades_Grid1Provider.RaiseSetRelationFields(PageProvider.CadastroAtividades_Grid1Provider, Item);
					Item.SetFieldValue(Item["dataLancamento"], PageProvider.CadastroAtividades_Grid1Provider.GridData["dataLancamento"]);
					Item.SetFieldValue(Item["Justificativa"], PageProvider.CadastroAtividades_Grid1Provider.GridData["justificativa"]);
					Item.SetFieldValue(Item["percentualExecutado"], PageProvider.CadastroAtividades_Grid1Provider.GridData["percentualExecutado"]);
					Item.SetFieldValue(Item["observacao"], PageProvider.CadastroAtividades_Grid1Provider.GridData["observacao"]);
					Item.SetFieldValue(Item["usuarioCadastro"], PageProvider.CadastroAtividades_Grid1Provider.GridData["usuarioCadastro"]);
					Item.SetFieldValue(Item["dataCadastro"], PageProvider.CadastroAtividades_Grid1Provider.GridData["dataCadastro"]);
					PageProvider.CadastroAtividades_Grid1Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.CadastroAtividades_Grid1Provider.Validate(Item);
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
				txt.Width = 78;
				Mask.SetMask(txt, "9999999999", 10, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn2") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "99999", 5, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn3") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "99999", 5, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				RadDatePicker dtp;
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn4") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 78;
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn6") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "999,99", 6, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn7") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn8") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "@!", 50, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn9") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 78;
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		
		private void PrepareCombo(RadComboBox cbo, string FieldTextName, string FieldValueName, DataRow row, bool AutoCryptDecript)
		{
			if (row != null)
			{
				cbo.SelectedValue = row[FieldValueName].ToString();
				var _text = "";
				var i = 0;
				foreach (var item in FieldTextName.Split('+'))
				{
					var _field = item.Replace("[", "").Replace("]", "").Trim();
					if (i % 2 == 0)
					{
						if (!AutoCryptDecript)
							_text += row[_field].ToString();
						else
							_text += Crypt.Decripta(row[_field].ToString());
					}
					else
					{
						_text += _field.Substring(1, 1);
					}
					i++;
				}
				cbo.Text = _text;
			}
			cbo.Attributes.Add("AllowFilter", "False");
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
			if (e.Item.IsInEditMode)
			{
				GridEditableItem item = (GridEditableItem)e.Item;
				if (!(item is IGridInsertItem))
				{
					Utility.SelectGridComboItem(PageProvider.CadastroAtividades_Grid1Provider.GridColumn5Items, item, "GridColumn5", "justificativa");
				}
			}
			if (e.Item is GridDataInsertItem && e.Item.OwnerTableView.IsItemInserted)
			{
				GridDataInsertItem insertItem = (GridDataInsertItem)e.Item;
				if (Grid1.Columns.Count > 0 && insertItem[Grid1.Columns[1]].Controls.Count > 0)
				{
					insertItem[Grid1.Columns[1]].Controls[0].Focus();
				}
			}
		}
		private void FillGridComboValues(string GridId, Hashtable newValues, GridTableRow item)
		{
			RadComboBox cbo;
			switch (GridId)
			{
				case "Grid1":
					cbo = (RadComboBox)item.FindControl("GridColumn5_ComboBox");
					newValues["justificativa"] = cbo.SelectedValue;
					break;
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
			FillGridComboValues(Grid.ID, GridValues.Item1, e.Item);
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
			FillGridComboValues(Grid.ID, newValues, e.Item);
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
						GetGridProvider(Grid).DataProvider.FiltroAtual = Dao.PoeColAspas("projeto") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["projeto"].GetFormattedValue(), FieldType.Integer) + " AND " + Dao.PoeColAspas("itemProjeto") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetFormattedValue(), FieldType.Integer) + " AND " + Dao.PoeColAspas("itemProcesso") + " = " + Dao.ToSql(PageProvider.MainProvider.DataProvider.Item["itemProcesso"].GetFormattedValue(), FieldType.Integer);
					}
					catch
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = "1 = 2";
					}
					Grid.Enabled = true;
					if (PageProvider.MainProvider.DataProvider.Item == null || PageProvider.MainProvider.DataProvider.Item["projeto"].GetValue() == null || PageProvider.MainProvider.DataProvider.Item["itemProjeto"].GetValue() == null || PageProvider.MainProvider.DataProvider.Item["itemProcesso"].GetValue() == null)
					{
						Grid.Enabled = false;
					}
					GetGridProvider(Grid).DataProvider.OrderBy = "[dataLancamento] Desc, [dataCadastro] Desc";
					break;
			}
		}
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					return PageProvider.CadastroAtividades_Grid1Provider;
			}
			return null;
		}
		protected void ___cmbSiglaCoordenacao_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.cmbSiglaCoordenacaoProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___cmbSiglaSetorial_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.cmbSiglaSetorialProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox3_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			Dictionary<string, object> ClientFields = e.Context["ClientFields"] as Dictionary<string, object>;
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox3Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter, ClientFields);
		}
		
		protected void ___ComboBox4_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			Dictionary<string, object> ClientFields = e.Context["ClientFields"] as Dictionary<string, object>;
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox4Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter, ClientFields);
		}
		
		protected void ___CbxSituacaoStatus_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.CbxSituacaoStatusProvider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		protected void ___Grid1_GridColumn5_ComboBox_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			RadComboBoxItem item = new RadComboBoxItem("Todos");
			item.Font.Bold = true;
			if (((RadComboBox)sender).ID.EndsWith("Filter")) ((RadComboBox)sender).Items.Add(item);
			e.EndOfItems = PageProvider.CadastroAtividades_Grid1Provider.FillCombo(PageProvider.CadastroAtividades_Grid1Provider.GridColumn5Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
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
		private DateTime dMenorData;
		private DateTime dMaiorData;
		
		private DateTime dMenorDataDiretriz;
		private DateTime dMaiorDataDiretriz;
		
		private DateTime dMenorDataAcao;
		private DateTime dMaiorDataAcao;
		
		private double nTotalProjetosAT;
		private double nSomaTotalAT;
		private double nPercentualAT;
		
		private double nTotalProjetos;
		private double nSomaTotal;
		private double nPercentual;		
		
		protected void Form1_LoadCompleted()
		{
			if (PageState == FormStateEnum.Insert)
			{			
				string sql = "SELECT TOP 1 (ITEMPROCESSO) FROM TB_PROCESSOS WHERE PROJETO = " + ParamProjeto +" AND ITEMPROJETO  = " + ParamAcao + " ORDER BY ITEMPROCESSO DESC";
				// Função que faz select no BD e traz o último registro baseado no documento escolhido
				DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				DataTable DT = Dao.RunSql(String.Format(sql)).Tables[0];
	
				if (DT.Rows.Count > 0) //Se tiver registros no banco 
				{
					int ultimoDoc = Convert.ToInt32(DT.Rows[0][0]);
					txtItemProcesso.Text = Convert.ToString(ultimoDoc + 1);
				}
				else
				{
					txtItemProcesso.Text = "1";
				}
				cmbSiglaCoordenacao.SelectedValue = ParamCoordenacao;
				situacaoField = "A INICIAR";
				
				Dao.CloseConnection();
				Dao.Dispose();			
			}
			if (PageState == FormStateEnum.Edit)
			{
				ParamCoordenacao = EnvironmentVariable.LoggedNameGroup.ToString();
				if (ParamCoordenacao == "ADMINISTRAÇÃO" || ParamCoordenacao == "DIRETORIA" || ParamCoordenacao == "ASSESSORIA")
				{
					txtInicioPrevisto.Enabled = true;
					txtTerminoPrevisto.Enabled = true;					
				}
				else
				{
					txtInicioPrevisto.Enabled = false;
					txtTerminoPrevisto.Enabled = false;
				}
			}
		}

		protected void Form1_OnSaveSucceeded(GeneralDataProviderItem Item)
		{
			try
            {
				// Atualiza Data início na tabela de Ação
				string sql = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.inicioPrevisto = "+
							 "CASE 	"+
									"WHEN (A.inicioPrevisto IS NULL) THEN B.inicioPrevisto "+
									"WHEN (B.inicioPrevisto < A.inicioPrevisto) THEN B.inicioPrevisto "+
									"WHEN (B.inicioPrevisto = A.inicioPrevisto) THEN B.inicioPrevisto "+
							 "END "+
							 "FROM TB_ITENS_PROJETO A "+
							 "INNER JOIN TB_PROCESSOS B ON A.PROJETO = B.PROJETO AND A.ITEMPROJETO = B.ITEMPROJETO";

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
			
			// ****************************************************************************************************************** //
			try
            {
				// Atualiza Data Término na Tabela de Ação
				string sql = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.terminoPrevisto = "+
							 "CASE 	"+
									"WHEN (A.terminoPrevisto IS NULL) THEN B.terminoPrevisto "+
									"WHEN (B.terminoPrevisto > A.terminoPrevisto) THEN B.terminoPrevisto "+
									"WHEN (B.terminoPrevisto = A.terminoPrevisto) THEN B.terminoPrevisto "+
							 "END "+
							 "FROM TB_ITENS_PROJETO A "+
							 "INNER JOIN TB_PROCESSOS B ON A.PROJETO = B.PROJETO AND A.ITEMPROJETO = B.ITEMPROJETO";

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
			

		protected void Form1_OnRemoveSucceeded(GeneralDataProviderItem Item)
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
			// Banco local está em português e servidor de homologação está em Inglês, portanto, deve-se alterar quando for homologar
			string sql6 = "UPDATE TB_PROJETO SET TB_PROJETO.percentualExecutado = "+ nPercentual.ToString("C",CultureInfo.CreateSpecificCulture("pt-BR")) + " WHERE TB_PROJETO.codigo = "+ projetoField.ToString();			
			//string sql6 = "UPDATE TB_PROJETO SET TB_PROJETO.percentualExecutado = "+ nPercentual.ToString("C",CultureInfo.CreateSpecificCulture("en-US")) + " WHERE TB_PROJETO.codigo = "+ projetoField.ToString();			
            Dao.ExecuteNonQuery(String.Format(sql6));
			
			Dao.CloseConnection();
			Dao.Dispose();							
		}

		protected void Form1_OnSaveSucceeded_2(GeneralDataProviderItem Item)
		{
			try
            {
				// Atualiza Situação na Tabela de Atividades
				string sql = "UPDATE TB_PROCESSOS SET TB_PROCESSOS.situacao = CASE 	WHEN (percentualExecutado = 100) THEN 'CONCLUÍDO' " +
							"WHEN(inicioRealizado is not null and terminoRealizado is not Null and percentualExecutado < 100) THEN 'VERIFICAR %' " +
							"WHEN(terminoPrevisto < GETDATE() AND inicioRealizado is null and terminoRealizado is Null and percentualExecutado = 0) THEN 'ATRASADO' " +
							"WHEN(inicioRealizado IS NULL  AND inicioPrevisto < GETDATE() AND percentualExecutado = 0) THEN 'ATRASADO' " +
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
			// ************************************************************************ //
			try
            {
				// Atualiza Ação "SUSPENSO"
				string sql8 = "UPDATE TB_ITENS_PROJETO SET SITUACAO = 'SUSPENSO' FROM TB_ITENS_PROJETO A WHERE A.STATUSACAO = 'SUSPENSO'";

				//DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
				Dao.OpenConnection();
				Dao.ExecuteNonQuery(String.Format(sql8));
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

		protected void Form1_OnSaveSucceeded_1(GeneralDataProviderItem Item)
		{
			// Datas de início e término das ações e diretrizes / metas
			string sql = "SELECT MIN(INICIOPREVISTO), MAX(TERMINOPREVISTO) FROM TB_PROCESSOS A WHERE A.PROJETO =  " + projetoField.ToString()+ " AND ITEMPROJETO = " +itemProjetoField.ToString();
			DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);	
			Dao.OpenConnection();
			
			DataTable DT = Dao.RunSql(String.Format(sql)).Tables[0];
			
			if (DT.Rows.Count > 0) //Se tiver registros no banco 
			{
				dMenorData = Convert.ToDateTime(DT.Rows[0][0]);
				dMaiorData = Convert.ToDateTime(DT.Rows[0][1]);
			}

			string sql1 = "SELECT MIN(INICIOPREVISTO), MAX(TERMINOPREVISTO) FROM TB_ITENS_PROJETO B WHERE B.PROJETO =  " + projetoField.ToString() + " AND ITEMPROJETO = " + itemProjetoField.ToString();
			DataTable DT1 = Dao.RunSql(String.Format(sql1)).Tables[0];
			if (DT1.Rows.Count > 0) //Se tiver registros no banco 
			{
				if (Convert.ToString(DT1.Rows[0][0]) == "" && Convert.ToString(DT1.Rows[0][1]) == "")
				{
					dMenorDataAcao = DateTime.Today;
					dMaiorDataAcao = DateTime.Today;
				}
				else if (Convert.ToString(DT1.Rows[0][0]) == "")
				{
					dMenorDataAcao = DateTime.Today;
					dMaiorDataAcao = Convert.ToDateTime(DT1.Rows[0][1]);					
				}							
				else if (Convert.ToString(DT1.Rows[0][1]) == "")
				{
					dMenorDataAcao = Convert.ToDateTime(DT1.Rows[0][0]);					
					dMaiorDataAcao = DateTime.Today;
				}
				else
				{
					dMenorDataAcao = Convert.ToDateTime(DT1.Rows[0][0]);
					dMaiorDataAcao = Convert.ToDateTime(DT1.Rows[0][1]);
				}
			}
			
			string sql2 = "SELECT MIN(INICIOPREVISTO), MAX(TERMINOPREVISTO) FROM TB_PROJETO C WHERE C.CODIGO =  " + projetoField.ToString();
			DataTable DT2 = Dao.RunSql(String.Format(sql2)).Tables[0];
			
			if (DT2.Rows.Count > 0) //Se tiver registros no banco 
			{
				if (Convert.ToString(DT2.Rows[0][0]) == "" && Convert.ToString(DT2.Rows[0][1]) == "")
                {
					dMenorDataDiretriz = DateTime.Today;
					dMaiorDataDiretriz = DateTime.Today;
				}				
				else if (Convert.ToString(DT2.Rows[0][0]) == "")
				{
					dMenorDataDiretriz = DateTime.Today;
					dMaiorDataDiretriz = Convert.ToDateTime(DT2.Rows[0][1]);					
				}
				else if (Convert.ToString(DT2.Rows[0][1]) == "")
                {
					dMenorDataDiretriz = Convert.ToDateTime(DT2.Rows[0][0]);					
					dMaiorDataDiretriz = DateTime.Today;
				}
				else if (Convert.ToString(DT2.Rows[0][0]) == "" && Convert.ToString(DT2.Rows[0][1]) == "")
                {
					dMenorDataDiretriz = DateTime.Today;
					dMaiorDataDiretriz = DateTime.Today;
				}
				else
				{
					dMenorDataDiretriz = Convert.ToDateTime(DT2.Rows[0][0]);
					dMaiorDataDiretriz = Convert.ToDateTime(DT2.Rows[0][1]);
				}
			}
			// Atualiza datas na tabela de diretrizes
			if (dMenorData < dMenorDataDiretriz)
			{
				//string sql3 = "UPDATE TB_PROJETO SET TB_PROJETO.inicioprevisto = '"+ dMenorData.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR")) + "' WHERE TB_PROJETO.codigo = "+ projetoField.ToString();
				string sql3 = "UPDATE TB_PROJETO SET TB_PROJETO.inicioprevisto = '"+ dMenorData.ToString("d", CultureInfo.CreateSpecificCulture("en-US")) + "' WHERE TB_PROJETO.codigo = "+ projetoField.ToString();
	            Dao.ExecuteNonQuery(String.Format(sql3));					
			}
			if (dMaiorData > dMaiorDataDiretriz)
			{
				//string sql4 = "UPDATE TB_PROJETO SET TB_PROJETO.terminoprevisto = '"+ dMaiorData.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR")) + "' WHERE TB_PROJETO.codigo = "+ projetoField.ToString();
				string sql4 = "UPDATE TB_PROJETO SET TB_PROJETO.terminoprevisto = '"+ dMaiorData.ToString("d", CultureInfo.CreateSpecificCulture("en-US")) + "' WHERE TB_PROJETO.codigo = "+ projetoField.ToString();
	            Dao.ExecuteNonQuery(String.Format(sql4));					
			}			

			// Atualiza datas na tabela de ações
			if (dMenorData < dMenorDataAcao)
			{
				//string sql5 = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.inicioprevisto = '"+ dMenorData.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR")) + "' WHERE TB_ITENS_PROJETO.projeto = "+ projetoField.ToString() + " AND ITEMPROJETO = "+itemProjetoField.ToString();				
				string sql5 = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.inicioprevisto = '"+ dMenorData.ToString("d", CultureInfo.CreateSpecificCulture("en-US")) + "' WHERE TB_ITENS_PROJETO.projeto = "+ projetoField.ToString() + " AND ITEMPROJETO = "+itemProjetoField.ToString();
	            Dao.ExecuteNonQuery(String.Format(sql5));					
			}
			if (dMaiorData > dMaiorDataAcao)
			{
				//string sql6 = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.terminoprevisto = '"+ dMaiorData.ToString("d", CultureInfo.CreateSpecificCulture("pt-BR")) + "' WHERE TB_ITENS_PROJETO.projeto = "+ projetoField.ToString() + " AND ITEMPROJETO = "+itemProjetoField.ToString();
				string sql6 = "UPDATE TB_ITENS_PROJETO SET TB_ITENS_PROJETO.terminoprevisto = '"+ dMaiorData.ToString("d", CultureInfo.CreateSpecificCulture("en-US")) + "' WHERE TB_ITENS_PROJETO.projeto = "+ projetoField.ToString() + " AND ITEMPROJETO = "+itemProjetoField.ToString();
	            Dao.ExecuteNonQuery(String.Format(sql6));					
			}			
			Dao.CloseConnection();
			Dao.Dispose();		
		}

		protected void Form1_OnSaveSucceeded_3(GeneralDataProviderItem Item)
		{
			try
            {
				// Atualiza Ação "CONCLUÍDO"
				string sql = "UPDATE TB_PROCESSOS SET DIASPREVISTOS = DATEDIFF(day,inicioPrevisto,terminoPrevisto) FROM TB_PROCESSOS";

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

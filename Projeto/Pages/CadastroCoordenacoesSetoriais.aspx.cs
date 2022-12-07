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
	public partial class CadastroCoordenacoesSetoriais : GeneralDataPage
	{
		protected CadastroCoordenacoesSetoriaisPageProvider PageProvider;
	

		public long codigoField = 0;
		public string siglaSetorialField = "";
		public string nomeSetorialField = "";
		public string siglaDiretoriaField = "";
		public string siglaCoordenacaoField = "";
		public DateTime ? dataCadastroField;
		public string usuarioCadastroField = "";
		
		public override string FormID { get { return "32729"; } }
		public override string TableName { get { return "TB_SETORIAL"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "CadastroCoordenacoesSetoriais.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamCodigo_Set = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCodigo_Set))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCodigo_Set.ToString(), FieldType.Integer);
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
			PageProvider = new CadastroCoordenacoesSetoriaisPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamCodigo_Set = HttpContext.Current.Request.QueryString["ParamCodigo_Set"];
			try { if (string.IsNullOrEmpty(ParamCodigo_Set)) ParamCodigo_Set = HttpContext.Current.Session["ParamCodigo_Set"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCodigo_Set)) ParamCodigo_Set = "0";
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
				Item.SetFieldValue(Item["siglaSetorial"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["nomeSetorial"], RadTextBox5.Text, false);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox2.SelectedValue);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox6.Text, false);
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
				Item.SetFieldValue(Item["siglaSetorial"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["nomeSetorial"], RadTextBox5.Text, false);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox2.SelectedValue);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox6.Text, false);
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
			Mask.SetMask(RadTextBox4, "@!", 10, false);
			Mask.SetMask(RadTextBox5, "@!", 100, false);
			Mask.SetMask(DatePicker1.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox6, "@!", 50, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(ComboBox2);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox4.Attributes.Add("EnableEdit", "True");
			RadTextBox5.Attributes.Add("EnableEdit", "True");
			ComboBox1.Attributes.Add("EnableEdit", "True");
			ComboBox2.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox1.Text = "";
			if (ShouldClearFields)
			{
				RadTextBox4.Text = "";
				RadTextBox5.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				DatePicker1.SelectedDate = null;
				RadTextBox6.Text = "";
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
			DatePicker1.SelectedDate = DateTime.Parse(EnvironmentVariable.ActualDate.ToString("dd/MM/yyyy"));
			try
			{
				RadTextBox6.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
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
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
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
			try
			{
				if (Item != null)
				{
					RadTextBox4.Text = Item["siglaSetorial"].GetFormattedValue();
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
					RadTextBox5.Text = Item["nomeSetorial"].GetFormattedValue();
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
				string Val = Item["siglaDiretoria"].GetFormattedValue();
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
				string Val = Item["siglaCoordenacao"].GetFormattedValue();
				SelectComboItem(ComboBox2, PageProvider.ComboBox2Provider, Val);
				ComboBox2.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox2.SelectedValue = "";
				ComboBox2.Text = "";
			}
			try { DatePicker1.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker1.SelectedDate = null; }
			try
			{
				if (Item != null)
				{
					RadTextBox6.Text = Item["usuarioCadastro"].GetFormattedValue();
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
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox5);
			ApplyMasks(DatePicker1);
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
					nomeSetorialField = Item["nomeSetorial"].GetFormattedValue();
				}
				else
				{
					nomeSetorialField = "";
				}
			}
			catch
			{
				nomeSetorialField = "";
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
			PageProvider.AliasVariables.Add("codigoField", codigoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("nomeSetorialField", nomeSetorialField);
			PageProvider.AliasVariables.Add("siglaDiretoriaField", siglaDiretoriaField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("ParamCodigo_Set", ParamCodigo_Set);
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
					AjaxPanel.Alert("Registro EXCLUÍDO!");
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
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox1Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox2_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox2Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
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

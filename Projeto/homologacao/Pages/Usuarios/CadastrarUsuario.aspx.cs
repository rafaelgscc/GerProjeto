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
	public partial class CadastrarUsuario : GeneralDataPage
	{
		protected TB_LOGIN_USERPageProvider PageProvider;
	

		public string LOGIN_USER_LOGINField = "";
		public string LOGIN_USER_PASSWORDField = "";
		public string LOGIN_USER_NAMEField = "";
		public string LOGIN_USER_EMAILField = "";
		public string LOGIN_USER_PHONEField = "";
		public string LOGIN_USER_OBSField = "";
		public string LOGIN_GROUP_NAMEField = "";
		public string LOGIN_USER_COORDENACAOField = "";
		
		public override string FormID { get { return "32764"; } }
		public override string TableName { get { return "TB_LOGIN_USER"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "CadastrarUsuario.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		



		
		public override void CreateProvider()
		{
			PageProvider = new TB_LOGIN_USERPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
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
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], Crypt.Encripta(RadTextBox2.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_PASSWORD"], Crypt.Encripta(RadTextBox3.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_NAME"], Crypt.Encripta(RadTextBox4.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_EMAIL"], Crypt.Encripta(RadTextBox5.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_PHONE"], Crypt.Encripta(RadTextBox6.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_OBS"], Crypt.Encripta(RadTextBox7.Text), false);
				Item.SetFieldValue(Item["LOGIN_GROUP_NAME"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["LOGIN_USER_COORDENACAO"], ComboBox3.SelectedValue);
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
				Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], Crypt.Encripta(RadTextBox2.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_PASSWORD"], Crypt.Encripta(RadTextBox3.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_NAME"], Crypt.Encripta(RadTextBox4.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_EMAIL"], Crypt.Encripta(RadTextBox5.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_PHONE"], Crypt.Encripta(RadTextBox6.Text), false);
				Item.SetFieldValue(Item["LOGIN_USER_OBS"], Crypt.Encripta(RadTextBox7.Text), false);
				Item.SetFieldValue(Item["LOGIN_GROUP_NAME"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["LOGIN_USER_COORDENACAO"], ComboBox3.SelectedValue);
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
			Mask.SetMask(RadTextBox2, "@!", 40, false);
			Mask.SetMask(RadTextBox3, "@!", 40, false);
			Mask.SetMask(RadTextBox4, "@!", 60, false);
			Mask.SetMask(RadTextBox6, "(99) 99999-9999", 15, false);
			Mask.SetMask(RadTextBox7, "@!", 0, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(RadTextBox5);
			Utility.SetControlTabOnEnter(ComboBox2);
			Utility.SetControlTabOnEnter(ComboBox3);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox2.Enabled = Action;
			RadTextBox3.Enabled = Action;
			RadTextBox4.Enabled = Action;
			RadTextBox5.Enabled = Action;
			RadTextBox6.Enabled = Action;
			RadTextBox7.Enabled = Action;
			ComboBox2.Enabled = Action;
			ComboBox3.Enabled = Action;
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox2.Text = "";
				RadTextBox3.Attributes["Value"] = "";
				RadTextBox4.Text = "";
				RadTextBox5.Text = "";
				RadTextBox6.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				ComboBox3.SelectedIndex = -1;
				ComboBox3.Text = "";
			if (ShouldClearFields)
			{
				RadTextBox7.Text = "";
			}
			if (!PageInsert && PageState == FormStateEnum.Navigation)
				DisableEnableContros(false);				
			else
				DisableEnableContros(true);				
		}		

		public override void ShowInitialValues()
		{
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
			Label4.Text = Label4.Text.Replace("<", "&lt;");
			Label4.Text = Label4.Text.Replace(">", "&gt;");
			Label5.Text = Label5.Text.Replace("<", "&lt;");
			Label5.Text = Label5.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
			Label8.Text = Label8.Text.Replace("<", "&lt;");
			Label8.Text = Label8.Text.Replace(">", "&gt;");
			Label9.Text = Label9.Text.Replace("<", "&lt;");
			Label9.Text = Label9.Text.Replace(">", "&gt;");
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
					RadTextBox2.Text = Crypt.Decripta(Item["LOGIN_USER_LOGIN"].GetFormattedValue());
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
					RadTextBox3.Attributes["value"] = Crypt.Decripta(Item["LOGIN_USER_PASSWORD"].GetFormattedValue());
				}
				else
				{
					RadTextBox3.Attributes["value"] = "" ;
				}
			}
			catch
			{
				RadTextBox3.Attributes["value"] = "" ;
			}
			try
			{
				if (Item != null)
				{
					RadTextBox4.Text = Crypt.Decripta(Item["LOGIN_USER_NAME"].GetFormattedValue());
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
					RadTextBox5.Text = Crypt.Decripta(Item["LOGIN_USER_EMAIL"].GetFormattedValue());
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
					RadTextBox6.Text = Crypt.Decripta(Item["LOGIN_USER_PHONE"].GetFormattedValue());
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
				if (Item != null)
				{
					RadTextBox7.Text = Crypt.Decripta(Item["LOGIN_USER_OBS"].GetFormattedValue());
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
				string Val = Item["LOGIN_GROUP_NAME"].GetFormattedValue();
				ComboBox2.Attributes["Encrypt"] = "False";
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
				string Val = Item["LOGIN_USER_COORDENACAO"].GetFormattedValue();
				SelectComboItem(ComboBox3, PageProvider.ComboBox3Provider, Val);
				ComboBox3.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox3.SelectedValue = "";
				ComboBox3.Text = "";
			}
			ApplyMasks(RadTextBox2);
			ApplyMasks(RadTextBox3);
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox5);
			ApplyMasks(RadTextBox6);
			ApplyMasks(RadTextBox7);
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
					LOGIN_USER_LOGINField = Item["LOGIN_USER_LOGIN"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_LOGINField = "";
				}
			}
			catch
			{
				LOGIN_USER_LOGINField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_PASSWORDField = Item["LOGIN_USER_PASSWORD"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_PASSWORDField = "";
				}
			}
			catch
			{
				LOGIN_USER_PASSWORDField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_NAMEField = Item["LOGIN_USER_NAME"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_NAMEField = "";
				}
			}
			catch
			{
				LOGIN_USER_NAMEField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_EMAILField = Item["LOGIN_USER_EMAIL"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_EMAILField = "";
				}
			}
			catch
			{
				LOGIN_USER_EMAILField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_PHONEField = Item["LOGIN_USER_PHONE"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_PHONEField = "";
				}
			}
			catch
			{
				LOGIN_USER_PHONEField = "";
			}
			try
			{
				if (Item != null)
				{
					LOGIN_USER_OBSField = Item["LOGIN_USER_OBS"].GetFormattedValue();
				}
				else
				{
					LOGIN_USER_OBSField = "";
				}
			}
			catch
			{
				LOGIN_USER_OBSField = "";
			}
			try
			{
				LOGIN_GROUP_NAMEField = Item["LOGIN_GROUP_NAME"].GetFormattedValue();
			}
			catch
			{
				LOGIN_GROUP_NAMEField = "";
			}
			try
			{
				LOGIN_USER_COORDENACAOField = Item["LOGIN_USER_COORDENACAO"].GetFormattedValue();
			}
			catch
			{
				LOGIN_USER_COORDENACAOField = "";
			}
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("LOGIN_USER_PASSWORDField", LOGIN_USER_PASSWORDField);
			PageProvider.AliasVariables.Add("LOGIN_USER_NAMEField", LOGIN_USER_NAMEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_EMAILField", LOGIN_USER_EMAILField);
			PageProvider.AliasVariables.Add("LOGIN_USER_PHONEField", LOGIN_USER_PHONEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_OBSField", LOGIN_USER_OBSField);
			PageProvider.AliasVariables.Add("LOGIN_GROUP_NAMEField", LOGIN_GROUP_NAMEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_COORDENACAOField", LOGIN_USER_COORDENACAOField);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___FormCadastrarUsuario_LoadCompleted()
		{
			bool ActionSucceeded_1 = true;
			try
			{
				FormCadastrarUsuario_LoadCompleted();
			}
			catch (Exception ex)
			{
				ActionSucceeded_1 = false;
				PageErrors.Add("Error", ex.Message);
				ShowErrors();
			}
		}

		protected void ___btnPesquisar_OnClick(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
				string UrlPage = ResolveUrl("~/Pages/Usuarios/PesquisarUsuario.aspx?ParamOrigem={ParamOrigem}");
				UrlPage = UrlPage.Replace("{ParamOrigem}", ("CadastrarUsuario").ToString());
				try
				{
					AjaxPanel.ResponseScripts.Add("Navigate('" + UrlPage + "', true, null, { Modal: false, Center: false });");
				}
				catch(Exception ex)
				{
				}
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
		protected void ___ComboBox2_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox2Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___ComboBox3_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox3Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		protected override void OnLoadComplete(EventArgs e)
		{
			___FormCadastrarUsuario_LoadCompleted();
			base.OnLoadComplete(e);
		}
#region CÓDIGO DE USUARIO

		protected void Form1_LoadCompleted()
		{
			
		}

		protected void FormCadastrarUsuario_LoadCompleted()
		{
			
		}
#endregion
	}
}

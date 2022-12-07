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
	public partial class TB_RESPONSAVEL : GeneralDataPage
	{
		protected TB_RESPONSAVELPageProvider PageProvider;
	

		public long codigoField = 0;
		public string nomeSobrenomeField = "";
		public string contatoResponsavelField = "";
		public string salaResponsavelField = "";
		public string ramalResponsavelField = "";
		public string nomeResponsavelField = "";
		public string siglaDiretoriaField = "";
		public string siglaCoordenacaoField = "";
		public string siglaSetorialField = "";
		public DateTime ? dataCadastroField;
		public string usuarioCadastroField = "";
		
		public override string FormID { get { return "32731"; } }
		public override string TableName { get { return "TB_RESPONSAVEL"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "TB_RESPONSAVEL.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamCodigo_Pes = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCodigo_Pes))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCodigo_Pes.ToString(), FieldType.Integer);
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
			PageProvider = new TB_RESPONSAVELPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamCodigo_Pes = HttpContext.Current.Request.QueryString["ParamCodigo_Pes"];
			try { if (string.IsNullOrEmpty(ParamCodigo_Pes)) ParamCodigo_Pes = HttpContext.Current.Session["ParamCodigo_Pes"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCodigo_Pes)) ParamCodigo_Pes = "0";
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
				Item.SetFieldValue(Item["nomeSobrenome"], RadTextBox3.Text, false);
				Item.SetFieldValue(Item["contatoResponsavel"], RadTextBox5.Text, false);
				Item.SetFieldValue(Item["salaResponsavel"], RadTextBox6.Text, false);
				Item.SetFieldValue(Item["ramalResponsavel"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["nomeResponsavel"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], ComboBox3.SelectedValue);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox7.Text, false);
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
				Item.SetFieldValue(Item["nomeSobrenome"], RadTextBox3.Text, false);
				Item.SetFieldValue(Item["contatoResponsavel"], RadTextBox5.Text, false);
				Item.SetFieldValue(Item["salaResponsavel"], RadTextBox6.Text, false);
				Item.SetFieldValue(Item["ramalResponsavel"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["nomeResponsavel"], RadTextBox2.Text, false);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["siglaCoordenacao"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["siglaSetorial"], ComboBox3.SelectedValue);
				if (DatePicker1.SelectedDate != null) Item.SetFieldValue(Item["dataCadastro"], DatePicker1.SelectedDate.Value.ToString("dd/MM/yyyy"));
				else Item.SetFieldValue(Item["dataCadastro"], DBNull.Value);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox7.Text, false);
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
			Mask.SetMask(RadTextBox3, "@!", 50, false);
			Mask.SetMask(RadTextBox5, "(99) 99999-9999", 15, false);
			Mask.SetMask(RadTextBox6, "@!", 10, false);
			Mask.SetMask(RadTextBox4, "@!", 10, false);
			Mask.SetMask(RadTextBox2, "@!", 100, false);
			Mask.SetMask(DatePicker1.DateInput, "99/99/9999", 10, false);
			Mask.SetMask(RadTextBox7, "@!", 50, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(ComboBox2);
			Utility.SetControlTabOnEnter(ComboBox3);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox3.Attributes.Add("EnableEdit", "True");
			RadTextBox5.Attributes.Add("EnableEdit", "True");
			RadTextBox6.Attributes.Add("EnableEdit", "True");
			RadTextBox4.Attributes.Add("EnableEdit", "True");
			RadTextBox2.Attributes.Add("EnableEdit", "True");
			ComboBox1.Attributes.Add("EnableEdit", "True");
			ComboBox2.Attributes.Add("EnableEdit", "True");
			ComboBox3.Attributes.Add("EnableEdit", "True");
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
				RadTextBox1.Text = "";
			if (ShouldClearFields)
			{
				RadTextBox3.Text = "";
				RadTextBox5.Text = "";
				RadTextBox6.Text = "";
				RadTextBox4.Text = "";
				RadTextBox2.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				ComboBox3.SelectedIndex = -1;
				ComboBox3.Text = "";
				DatePicker1.SelectedDate = null;
				RadTextBox7.Text = "";
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
				RadTextBox7.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
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
			Label3.Text = Label3.Text.Replace("<", "&lt;");
			Label3.Text = Label3.Text.Replace(">", "&gt;");
			Label5.Text = Label5.Text.Replace("<", "&lt;");
			Label5.Text = Label5.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
			Label4.Text = Label4.Text.Replace("<", "&lt;");
			Label4.Text = Label4.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
			Label9.Text = Label9.Text.Replace("<", "&lt;");
			Label9.Text = Label9.Text.Replace(">", "&gt;");
			Label10.Text = Label10.Text.Replace("<", "&lt;");
			Label10.Text = Label10.Text.Replace(">", "&gt;");
			Label11.Text = Label11.Text.Replace("<", "&lt;");
			Label11.Text = Label11.Text.Replace(">", "&gt;");
			Label8.Text = Label8.Text.Replace("<", "&lt;");
			Label8.Text = Label8.Text.Replace(">", "&gt;");
			Label7.Text = Label7.Text.Replace("<", "&lt;");
			Label7.Text = Label7.Text.Replace(">", "&gt;");
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
					RadTextBox3.Text = Item["nomeSobrenome"].GetFormattedValue();
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
					RadTextBox5.Text = Item["contatoResponsavel"].GetFormattedValue();
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
					RadTextBox6.Text = Item["salaResponsavel"].GetFormattedValue();
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
					RadTextBox4.Text = Item["ramalResponsavel"].GetFormattedValue();
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
					RadTextBox2.Text = Item["nomeResponsavel"].GetFormattedValue();
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
			try
			{
				string Val = Item["siglaSetorial"].GetFormattedValue();
				SelectComboItem(ComboBox3, PageProvider.ComboBox3Provider, Val);
				ComboBox3.Attributes.Add("AllowFilter", "False");
			}
			catch
			{
				ComboBox3.SelectedValue = "";
				ComboBox3.Text = "";
			}
			try { DatePicker1.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker1.SelectedDate = null; }
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
			ApplyMasks(RadTextBox1);
			ApplyMasks(RadTextBox3);
			ApplyMasks(RadTextBox5);
			ApplyMasks(RadTextBox6);
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox2);
			ApplyMasks(DatePicker1);
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
					nomeSobrenomeField = Item["nomeSobrenome"].GetFormattedValue();
				}
				else
				{
					nomeSobrenomeField = "";
				}
			}
			catch
			{
				nomeSobrenomeField = "";
			}
			try
			{
				if (Item != null)
				{
					contatoResponsavelField = Item["contatoResponsavel"].GetFormattedValue();
				}
				else
				{
					contatoResponsavelField = "";
				}
			}
			catch
			{
				contatoResponsavelField = "";
			}
			try
			{
				if (Item != null)
				{
					salaResponsavelField = Item["salaResponsavel"].GetFormattedValue();
				}
				else
				{
					salaResponsavelField = "";
				}
			}
			catch
			{
				salaResponsavelField = "";
			}
			try
			{
				if (Item != null)
				{
					ramalResponsavelField = Item["ramalResponsavel"].GetFormattedValue();
				}
				else
				{
					ramalResponsavelField = "";
				}
			}
			catch
			{
				ramalResponsavelField = "";
			}
			try
			{
				if (Item != null)
				{
					nomeResponsavelField = Item["nomeResponsavel"].GetFormattedValue();
				}
				else
				{
					nomeResponsavelField = "";
				}
			}
			catch
			{
				nomeResponsavelField = "";
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
				siglaSetorialField = Item["siglaSetorial"].GetFormattedValue();
			}
			catch
			{
				siglaSetorialField = "";
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
			PageProvider.AliasVariables.Add("nomeSobrenomeField", nomeSobrenomeField);
			PageProvider.AliasVariables.Add("contatoResponsavelField", contatoResponsavelField);
			PageProvider.AliasVariables.Add("salaResponsavelField", salaResponsavelField);
			PageProvider.AliasVariables.Add("ramalResponsavelField", ramalResponsavelField);
			PageProvider.AliasVariables.Add("nomeResponsavelField", nomeResponsavelField);
			PageProvider.AliasVariables.Add("siglaDiretoriaField", siglaDiretoriaField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("ParamCodigo_Pes", ParamCodigo_Pes);
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
		
		protected void ___ComboBox3_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			e.EndOfItems = PageProvider.FillCombo(PageProvider.ComboBox3Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
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

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
	public partial class CadastroCoordenacoesGerais : GeneralDataPage
	{
		protected CadastroCoordenacoesGeraisPageProvider PageProvider;
	

		public long codigoField = 0;
		public string siglaCoordenacaoField = "";
		public string nomeCoordenacaoField = "";
		public string siglaDiretoriaField = "";
		public string nomeCoordenadorField = "";
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField;
		
		public override string FormID { get { return "32727"; } }
		public override string TableName { get { return "TB_COORDENACAO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "CadastroCoordenacoesGerais.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return true;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return true; } }
		


		public string ParamCodigo_Coord = "";

		public override void SetStartFilter()
		{
			try
			{
				if (!String.IsNullOrEmpty(ParamCodigo_Coord))
				{
					PageProvider.MainProvider.DataProvider.StartFilter = Dao.PoeColAspas("codigo") + " = " + Dao.ToSql(ParamCodigo_Coord.ToString(), FieldType.Integer);
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
			PageProvider = new CadastroCoordenacoesGeraisPageProvider(this);
		}
		
		private void InitializePageContent()
		{
		}


		/// <summary>
        /// onInit Vamos Carregar o Painel de Ajax e Label de erros da página
        /// </summary>
		protected override void OnInit(EventArgs e)
		{
			ParamCodigo_Coord = HttpContext.Current.Request.QueryString["ParamCodigo_Coord"];
			try { if (string.IsNullOrEmpty(ParamCodigo_Coord)) ParamCodigo_Coord = HttpContext.Current.Session["ParamCodigo_Coord"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamCodigo_Coord)) ParamCodigo_Coord = "0";
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
				Item.SetFieldValue(Item["siglaCoordenacao"], RadTextBox3.Text, false);
				Item.SetFieldValue(Item["nomeCoordenacao"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["nomeCoordenador"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox6.Text, false);
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
				Item.SetFieldValue(Item["siglaCoordenacao"], RadTextBox3.Text, false);
				Item.SetFieldValue(Item["nomeCoordenacao"], RadTextBox4.Text, false);
				Item.SetFieldValue(Item["siglaDiretoria"], ComboBox1.SelectedValue);
				Item.SetFieldValue(Item["nomeCoordenador"], ComboBox2.SelectedValue);
				Item.SetFieldValue(Item["usuarioCadastro"], RadTextBox6.Text, false);
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
			Mask.SetMask(RadTextBox1, "9999999999", 10, true);
			Mask.SetMask(RadTextBox3, "@!", 10, false);
			Mask.SetMask(RadTextBox6, "@!", 50, false);
			Mask.SetMask(DatePicker1.DateInput, "99/99/9999", 10, false);
		}

		public override void DefineStartScripts()
		{
			Utility.SetControlTabOnEnter(RadTextBox4);
			Utility.SetControlTabOnEnter(ComboBox1);
			Utility.SetControlTabOnEnter(ComboBox2);
		}
		
		public override void DisableEnableContros(bool Action)
		{
			RadTextBox3.Attributes.Add("EnableEdit", "True");
			RadTextBox4.Attributes.Add("EnableEdit", "True");
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
				RadTextBox3.Text = "";
				RadTextBox4.Text = "";
				ComboBox1.SelectedIndex = -1;
				ComboBox1.Text = "";
				ComboBox2.SelectedIndex = -1;
				ComboBox2.Text = "";
				RadTextBox6.Text = "";
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
				RadTextBox6.Text = (EnvironmentVariable.LoggedLoginUser.ToString()).ToString();
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
			Label1.Text = Label1.Text.Replace("<", "&lt;");
			Label1.Text = Label1.Text.Replace(">", "&gt;");
			Label3.Text = Label3.Text.Replace("<", "&lt;");
			Label3.Text = Label3.Text.Replace(">", "&gt;");
			Label2.Text = Label2.Text.Replace("<", "&lt;");
			Label2.Text = Label2.Text.Replace(">", "&gt;");
			Label4.Text = Label4.Text.Replace("<", "&lt;");
			Label4.Text = Label4.Text.Replace(">", "&gt;");
			Label5.Text = Label5.Text.Replace("<", "&lt;");
			Label5.Text = Label5.Text.Replace(">", "&gt;");
			Label6.Text = Label6.Text.Replace("<", "&lt;");
			Label6.Text = Label6.Text.Replace(">", "&gt;");
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
					RadTextBox3.Text = Item["siglaCoordenacao"].GetFormattedValue();
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
					RadTextBox4.Text = Item["nomeCoordenacao"].GetFormattedValue();
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
				string Val = Item["nomeCoordenador"].GetFormattedValue();
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
			try { DatePicker1.SelectedDate = Convert.ToDateTime(Item["dataCadastro"].GetFormattedValue("dd/MM/yyyy")); }
			catch { DatePicker1.SelectedDate = null; }
			ApplyMasks(RadTextBox1);
			ApplyMasks(RadTextBox3);
			ApplyMasks(RadTextBox4);
			ApplyMasks(RadTextBox6);
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
					siglaCoordenacaoField = Item["siglaCoordenacao"].GetFormattedValue();
				}
				else
				{
					siglaCoordenacaoField = "";
				}
			}
			catch
			{
				siglaCoordenacaoField = "";
			}
			try
			{
				if (Item != null)
				{
					nomeCoordenacaoField = Item["nomeCoordenacao"].GetFormattedValue();
				}
				else
				{
					nomeCoordenacaoField = "";
				}
			}
			catch
			{
				nomeCoordenacaoField = "";
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
				nomeCoordenadorField = Item["nomeCoordenador"].GetFormattedValue();
			}
			catch
			{
				nomeCoordenadorField = "";
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
			PageProvider.AliasVariables.Add("codigoField", codigoField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("nomeCoordenacaoField", nomeCoordenacaoField);
			PageProvider.AliasVariables.Add("siglaDiretoriaField", siglaDiretoriaField);
			PageProvider.AliasVariables.Add("nomeCoordenadorField", nomeCoordenadorField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("ParamCodigo_Coord", ParamCodigo_Coord);
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

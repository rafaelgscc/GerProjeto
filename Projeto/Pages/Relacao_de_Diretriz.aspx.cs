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
	public partial class Relacao_de_Diretriz : GeneralDataPage
	{
		protected Relacao_de_DiretrizPageProvider PageProvider;
	

		public long codigoField = 0;
		public string nomeProjetoField = "";
		public string DiretrizField = "";
		public string statusProjetoField = "";
		public string usuarioCadastroField = "";
		public DateTime ? dataCadastroField = null;
		public DateTime ? terminoRealizadoField = null;
		public long DiasDeProjetoField = 0;
		public double percentualExecutadoField = 0;
		public DateTime ? inicioPrevistoField = null;
		public DateTime ? terminoPrevistoField = null;
		public double custoProjetoField = 0;
		public string nivelProjetoField = "";
		public string siglaDiretoriaField = "";
		public string siglaCoordenacaoField = "";
		public string siglaSetorialField = "";
		public string situacaoField = "";
		public int anoProjetoField = 0;
		
		public override string FormID { get { return "32732"; } }
		public override string TableName { get { return "TB_PROJETO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "Relacao_de_Diretriz.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		


		public string ParamCoordenacao = "";

		
		public override void CreateProvider()
		{
			PageProvider = new Relacao_de_DiretrizPageProvider(this);
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
				if (Provider == PageProvider.AUX_Relacao_de_Projetos_TB_ITENS_PROJETOProvider && Provider.IndexName == "PK_TB_ITENS_PROJETO")
				{
					if (PageProvider.MainProvider.DataProvider.Item != null)
					{
						Provider.Parameters["projeto"].Parameter.SetValue(Utility.FixValue<double>(PageProvider.MainProvider.DataProvider.Item["codigo"].GetValue()));
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
		}

		public override void DefineStartScripts()
		{
		}
		
		public override void DisableEnableContros(bool Action)
		{
		}

		/// <summary>
		/// Limpa Campos na tela
		/// </summary>
		public override void ClearFields(bool ShouldClearFields)
		{
			if (ShouldClearFields)
			{
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
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			InitializePageContent();
			base.DefinePageContent(Item);
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
					codigoField = long.Parse(Item["codigo"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
				if (Item != null)
				{
					DiretrizField = Item["Diretriz"].GetFormattedValue();
				}
				else
				{
				DiretrizField = "";
				}
			}
			catch
			{
				DiretrizField = "";
			}
			try
			{
				if (Item != null)
				{
					statusProjetoField = Item["statusProjeto"].GetFormattedValue();
				}
				else
				{
				statusProjetoField = "";
				}
			}
			catch
			{
				statusProjetoField = "";
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
					DiasDeProjetoField = long.Parse(Item["DiasDeProjeto"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
				if (Item != null)
				{
					percentualExecutadoField = double.Parse(Item["percentualExecutado"].GetFormattedValue(), CultureInfo.CurrentCulture);
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
					inicioPrevistoField = DateTime.Parse(Item["inicioPrevisto"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				inicioPrevistoField = null;
				}
			}
			catch
			{
				inicioPrevistoField = null;
			}
			try
			{
				if (Item != null)
				{
					terminoPrevistoField = DateTime.Parse(Item["terminoPrevisto"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				terminoPrevistoField = null;
				}
			}
			catch
			{
				terminoPrevistoField = null;
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
					siglaDiretoriaField = Item["siglaDiretoria"].GetFormattedValue();
				}
				else
				{
				siglaDiretoriaField = "";
				}
			}
			catch
			{
				siglaDiretoriaField = "";
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
			PageProvider.AliasVariables.Add("codigoField", codigoField);
			PageProvider.AliasVariables.Add("nomeProjetoField", nomeProjetoField);
			PageProvider.AliasVariables.Add("DiretrizField", DiretrizField);
			PageProvider.AliasVariables.Add("statusProjetoField", statusProjetoField);
			PageProvider.AliasVariables.Add("usuarioCadastroField", usuarioCadastroField);
			PageProvider.AliasVariables.Add("dataCadastroField", dataCadastroField);
			PageProvider.AliasVariables.Add("terminoRealizadoField", terminoRealizadoField);
			PageProvider.AliasVariables.Add("DiasDeProjetoField", DiasDeProjetoField);
			PageProvider.AliasVariables.Add("percentualExecutadoField", percentualExecutadoField);
			PageProvider.AliasVariables.Add("inicioPrevistoField", inicioPrevistoField);
			PageProvider.AliasVariables.Add("terminoPrevistoField", terminoPrevistoField);
			PageProvider.AliasVariables.Add("custoProjetoField", custoProjetoField);
			PageProvider.AliasVariables.Add("nivelProjetoField", nivelProjetoField);
			PageProvider.AliasVariables.Add("siglaDiretoriaField", siglaDiretoriaField);
			PageProvider.AliasVariables.Add("siglaCoordenacaoField", siglaCoordenacaoField);
			PageProvider.AliasVariables.Add("siglaSetorialField", siglaSetorialField);
			PageProvider.AliasVariables.Add("situacaoField", situacaoField);
			PageProvider.AliasVariables.Add("anoProjetoField", anoProjetoField);
			PageProvider.AliasVariables.Add("ParamCoordenacao", ParamCoordenacao);
			PageProvider.AliasVariables.Add("BasePage", this);
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
					if (PageProvider.Relacao_de_Projetos_Grid1Provider.DataProvider.Item == null)
						Item = PageProvider.Relacao_de_Projetos_Grid1Provider.GetDataProviderItem();
					else
						Item = PageProvider.Relacao_de_Projetos_Grid1Provider.DataProvider.Item;
					PageProvider.Relacao_de_Projetos_Grid1Provider.RaiseSetRelationFields(PageProvider.Relacao_de_Projetos_Grid1Provider, Item);
					Item.SetFieldValue(Item["codigo"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["codigo"]);
					Item.SetFieldValue(Item["anoProjeto"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["anoProjeto"]);
					Item.SetFieldValue(Item["siglaCoordenacao"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["siglaCoordenacao"]);
					Item.SetFieldValue(Item["siglaSetorial"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["siglaSetorial"]);
					Item.SetFieldValue(Item["nomeProjeto"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["nomeProjeto"]);
					Item.SetFieldValue(Item["Diretriz"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["Diretriz"]);
					Item.SetFieldValue(Item["statusProjeto"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["statusProjeto"]);
					Item.SetFieldValue(Item["inicioPrevisto"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["inicioPrevisto"]);
					Item.SetFieldValue(Item["terminoPrevisto"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["terminoPrevisto"]);
					Item.SetFieldValue(Item["DiasDeProjeto"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["DiasDeProjeto"]);
					Item.SetFieldValue(Item["percentualExecutado"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["percentualExecutado"]);
					Item.SetFieldValue(Item["situacao"], PageProvider.Relacao_de_Projetos_Grid1Provider.GridData["situacao"]);
					PageProvider.Relacao_de_Projetos_Grid1Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.Relacao_de_Projetos_Grid1Provider.Validate(Item);
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
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn12") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 31;
				Mask.SetMask(txt, "9999999999", 10, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn16") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 29;
				txt.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn16_Validation]]");
				txt.Attributes.Add("data-validation-message", "anoProjeto não pode ser vazio!");
				Mask.SetMask(txt, "9999", 4, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn10") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				txt.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn10_Validation]]");
				txt.Attributes.Add("data-validation-message", "Coordenação não pode ser vazio!");
				Mask.SetMask(txt, "@!", 10, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn11") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 41;
				Mask.SetMask(txt, "@!", 10, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn2") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 369;
				Mask.SetMask(txt, "@!", 255, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				RadDatePicker dtp;
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn7") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 61;
				dtp.DateInput.Attributes.Add("data-validation-engine", "validate[funcCall[GridColumn7_Validation]]");
				dtp.DateInput.Attributes.Add("data-validation-message", "Data do Cadastro não pode ser vazio!");
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				dtp = (editableItem.EditManager.GetColumnEditor("GridColumn8") as GridDateTimeColumnEditor).PickerControl;
				dtp.Width = 51;
				Mask.SetMask(dtp.DateInput, "dd/MM/yyyy", 10, false);
				dtp.DateInput.Attributes.Add("onblur", "OnMaskBlur();");
				dtp.DateInput.Attributes.Add("isGrid", "true");
				ApplyMasks(dtp.DateInput);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn9") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 22;
				Mask.SetMask(txt, "9999999999", 10, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn14") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "999,99", 6, true);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn13") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "@!", 20, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				AjaxPanel.ResponseScripts.Add("jQuery(\"#Grid1\").validationEngine();");
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
					Utility.SelectGridComboItem(PageProvider.Relacao_de_Projetos_Grid1Provider.GridColumn3Items, item, "GridColumn3", "Diretriz");
					Utility.SelectGridComboItem(PageProvider.Relacao_de_Projetos_Grid1Provider.GridColumn4Items, item, "GridColumn4", "statusProjeto");
				}
			}
		}
		private void FillGridComboValues(string GridId, Hashtable newValues, GridTableRow item)
		{
			RadComboBox cbo;
			switch (GridId)
			{
				case "Grid1":
					cbo = (RadComboBox)item.FindControl("GridColumn3_ComboBox");
					newValues["Diretriz"] = cbo.SelectedValue;
					cbo = (RadComboBox)item.FindControl("GridColumn4_ComboBox");
					newValues["statusProjeto"] = cbo.SelectedValue;
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
				Label lab;
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
					case "GridColumn5":
						bool ActionSucceeded_GridColumn5_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/CadastroDiretriz.aspx?ParamCod_Projeto={ParamCod_Projeto}&ParamCoordenacao={ParamCoordenacao}");
							UrlPage = UrlPage.Replace("{ParamCod_Projeto}", (Convert.ToInt32(Provider.DataProvider.Item["codigo"].GetValue())).ToString());
							UrlPage = UrlPage.Replace("{ParamCoordenacao}", (Convert.ToString(Provider.DataProvider.Item["siglaCoordenacao"].GetValue())).ToString());
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
							ActionSucceeded_GridColumn5_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
					break;
					case "GridColumn6":
						bool ActionSucceeded_GridColumn6_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/RelacaodoCadastrodeAcoes.aspx?ParamCodigo_Projeto={ParamCodigo_Projeto}");
							UrlPage = UrlPage.Replace("{ParamCodigo_Projeto}", (Convert.ToInt32(Provider.DataProvider.Item["codigo"].GetValue())).ToString());
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
							ActionSucceeded_GridColumn6_1 = false;
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
						if(GetGridProvider(Grid).DataProvider.FiltroAtual != null && GetGridProvider(Grid).DataProvider.FiltroAtual.Trim().Length > 0)
						{
							GetGridProvider(Grid).DataProvider.FiltroAtual = "(" + GetGridProvider(Grid).DataProvider.FiltroAtual + ") AND (" + FiltroGrid() + ")";
						}
						else
						{
							GetGridProvider(Grid).DataProvider.FiltroAtual = FiltroGrid();
						}
					}
					catch
					{
						GetGridProvider(Grid).DataProvider.FiltroAtual = "1 = 2";
					}
					GetGridProvider(Grid).DataProvider.OrderBy = "[siglaCoordenacao] Asc, [nomeProjeto] Asc";
					break;
			}
		}
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					return PageProvider.Relacao_de_Projetos_Grid1Provider;
			}
			return null;
		}
		protected void ___Grid1_GridColumn3_ComboBox_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			RadComboBoxItem item = new RadComboBoxItem("Todos");
			item.Font.Bold = true;
			if (((RadComboBox)sender).ID.EndsWith("Filter")) ((RadComboBox)sender).Items.Add(item);
			e.EndOfItems = PageProvider.Relacao_de_Projetos_Grid1Provider.FillCombo(PageProvider.Relacao_de_Projetos_Grid1Provider.GridColumn3Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		
		protected void ___Grid1_GridColumn4_ComboBox_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			RadComboBoxItem item = new RadComboBoxItem("Todos");
			item.Font.Bold = true;
			if (((RadComboBox)sender).ID.EndsWith("Filter")) ((RadComboBox)sender).Items.Add(item);
			e.EndOfItems = PageProvider.Relacao_de_Projetos_Grid1Provider.FillCombo(PageProvider.Relacao_de_Projetos_Grid1Provider.GridColumn4Items, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
		protected override void OnLoadComplete(EventArgs e)
		{
			___Form1_LoadCompleted();
			base.OnLoadComplete(e);
		}
#region CÓDIGO DE USUARIO
		private string cSituacao1;
		private string cSituacao2;

		protected string FiltroGrid()
        {
			string filtro = "1=2";
			string cGrupo = EnvironmentVariable.LoggedNameGroup.ToString();

			DataAccessObject Dao = Settings.GetDataAccessObject(((Databases)HttpContext.Current.Application["Databases"])["DBGERPROJETO"]);
            DataTable DT = Dao.RunSql(String.Format("SELECT [LOGIN_USER_COORDENACAO] FROM [DBO].[TB_LOGIN_USER] WHERE [LOGIN_USER_LOGIN] = '" + Crypt.Encripta(EnvironmentVariable.LoggedLoginUser.ToString()) + "'")).Tables[0];
            if (DT.Rows.Count > 0) //Se tiver registros no banco para este tipo de documento, admite valor 1 para o número do documento
            {
                ParamCoordenacao = Convert.ToString(DT.Rows[0][0].ToString());
            }
			else
            {
                ParamCoordenacao = "";
            }
			Dao.CloseConnection();
			Dao.Dispose();
			
			// Checar se o usuário tem privilégio de diretor, assessor ou administrador com isso mostrar todos os dados, ou filtrar por coordenação
			
			if (cGrupo == "ADMINISTRAÇÃO" || cGrupo == "DIRETORIA" || cGrupo == "ASSESSORIA")
            {
				filtro = "("  + Dao.PoeColAspas("codigo") + " > " + Dao.ToSql("0", FieldType.Text) + ")";
			}
			else			
			{
				filtro = filtro = "("  + Dao.PoeColAspas("siglaCoordenacao") + " = " + Dao.ToSql(ParamCoordenacao, FieldType.Text) + ")";
			}
				
			return filtro;
	    }					

		protected void Form1_LoadCompleted()
		{
			try
            {
				// Atualiza Ação "CONCLUÍDO"
				string sql = "UPDATE TB_PROJETO SET DIASDEPROJETO = DATEDIFF(day,inicioPrevisto,terminoPrevisto) FROM TB_PROJETO";

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

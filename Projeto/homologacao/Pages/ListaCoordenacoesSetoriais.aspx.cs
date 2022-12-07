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
	public partial class ListaCoordenacoesSetoriais : GeneralDataPage
	{
		protected Lista_Coordenacoes_SetoriaisPageProvider PageProvider;
	

		public string HDEmailField = "";
		public string HDNomeField = "";
		public int HDPortaField = 0;
		public string HDSMTPField = "";
		public string HDSSLField = "";
		public int HDExpiraSenhaField = 0;
		public DateTime ? HD_AtualizacaoField = null;
		
		public override string FormID { get { return "32728"; } }
		public override string TableName { get { return "TB_PARAMETRO"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "ListaCoordenacoesSetoriais.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "true"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		



		
		public override void CreateProvider()
		{
			PageProvider = new Lista_Coordenacoes_SetoriaisPageProvider(this);
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
			AjaxPanel = MainAjaxPanel;
			if (IsPostBack)
			{
				AjaxPanel.ResponseScripts.Add("setTimeout(\"InitializeClient();\",100);");
			}
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
					HDEmailField = Item["HDEmail"].GetFormattedValue();
				}
				else
				{
				HDEmailField = "";
				}
			}
			catch
			{
				HDEmailField = "";
			}
			try
			{
				if (Item != null)
				{
					HDNomeField = Item["HDNome"].GetFormattedValue();
				}
				else
				{
				HDNomeField = "";
				}
			}
			catch
			{
				HDNomeField = "";
			}
			try
			{
				if (Item != null)
				{
					HDPortaField = int.Parse(Item["HDPorta"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				HDPortaField = 0;
				}
			}
			catch
			{
				HDPortaField = 0;
			}
			try
			{
				if (Item != null)
				{
					HDSMTPField = Item["HDSMTP"].GetFormattedValue();
				}
				else
				{
				HDSMTPField = "";
				}
			}
			catch
			{
				HDSMTPField = "";
			}
			try
			{
				if (Item != null)
				{
					HDSSLField = Item["HDSSL"].GetFormattedValue();
				}
				else
				{
				HDSSLField = "";
				}
			}
			catch
			{
				HDSSLField = "";
			}
			try
			{
				if (Item != null)
				{
					HDExpiraSenhaField = int.Parse(Item["HDExpiraSenha"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				HDExpiraSenhaField = 0;
				}
			}
			catch
			{
				HDExpiraSenhaField = 0;
			}
			try
			{
				if (Item != null)
				{
					HD_AtualizacaoField = DateTime.Parse(Item["HD_Atualizacao"].GetFormattedValue(), CultureInfo.CurrentCulture);
				}
				else
				{
				HD_AtualizacaoField = null;
				}
			}
			catch
			{
				HD_AtualizacaoField = null;
			}
			PageProvider.AliasVariables.Add("HDEmailField", HDEmailField);
			PageProvider.AliasVariables.Add("HDNomeField", HDNomeField);
			PageProvider.AliasVariables.Add("HDPortaField", HDPortaField);
			PageProvider.AliasVariables.Add("HDSMTPField", HDSMTPField);
			PageProvider.AliasVariables.Add("HDSSLField", HDSSLField);
			PageProvider.AliasVariables.Add("HDExpiraSenhaField", HDExpiraSenhaField);
			PageProvider.AliasVariables.Add("HD_AtualizacaoField", HD_AtualizacaoField);
			PageProvider.AliasVariables.Add("BasePage", this);
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
					if (PageProvider.Lista_de_Setoriais_Grid1Provider.DataProvider.Item == null)
						Item = PageProvider.Lista_de_Setoriais_Grid1Provider.GetDataProviderItem();
					else
						Item = PageProvider.Lista_de_Setoriais_Grid1Provider.DataProvider.Item;
					PageProvider.Lista_de_Setoriais_Grid1Provider.RaiseSetRelationFields(PageProvider.Lista_de_Setoriais_Grid1Provider, Item);
					Item.SetFieldValue(Item["siglaDiretoria"], PageProvider.Lista_de_Setoriais_Grid1Provider.GridData["siglaDiretoria"]);
					Item.SetFieldValue(Item["siglaCoordenacao"], PageProvider.Lista_de_Setoriais_Grid1Provider.GridData["siglaCoordenacao"]);
					Item.SetFieldValue(Item["siglaSetorial"], PageProvider.Lista_de_Setoriais_Grid1Provider.GridData["siglaSetorial"]);
					Item.SetFieldValue(Item["nomeSetorial"], PageProvider.Lista_de_Setoriais_Grid1Provider.GridData["nomeSetorial"]);
					PageProvider.Lista_de_Setoriais_Grid1Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.Lista_de_Setoriais_Grid1Provider.Validate(Item);
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
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn2") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 46;
				Mask.SetMask(txt, "@!", 10, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn3") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 108;
				Mask.SetMask(txt, "@!", 10, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn4") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 139;
				Mask.SetMask(txt, "@!", 10, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn5") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 166;
				Mask.SetMask(txt, "@!", 100, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
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
					case "GridColumn6":
						bool ActionSucceeded_GridColumn6_1 = true;
						try
						{
							string UrlPage = ResolveUrl("~/Pages/CadastroCoordenacoesSetoriais.aspx?ParamCodigo_Set={ParamCodigo_Set}");
							UrlPage = UrlPage.Replace("{ParamCodigo_Set}", (Convert.ToInt32(Provider.DataProvider.Item["codigo"].GetValue())).ToString());
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
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					return PageProvider.Lista_de_Setoriais_Grid1Provider;
			}
			return null;
		}
	}
}

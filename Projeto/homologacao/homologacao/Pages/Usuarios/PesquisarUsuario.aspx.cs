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
	public partial class PesquisarUsuario : GeneralDataPage
	{
		protected TB_LOGIN_USER3PageProvider PageProvider;
	

		public string LOGIN_GROUP_NAMEField = "";
		public string LOGIN_USER_LOGINField = "";
		public string LOGIN_USER_PASSWORDField = "";
		public string LOGIN_USER_NAMEField = "";
		public string LOGIN_USER_OBSField = "";
		public string LOGIN_USER_EMAILField = "";
		public string LOGIN_USER_PHONEField = "";
		public string LOGIN_USER_COORDENACAOField = "";
		
		public override string FormID { get { return "32768"; } }
		public override string TableName { get { return "TB_LOGIN_USER"; } }
		public override string DatabaseName { get { return "DBGERPROJETO"; } }
		public override string PageName { get { return "PesquisarUsuario.aspx"; } }
		public override string ProjectID { get { return "328917AC"; } }
		public override string TableParameters { get { return "false"; } }
		public override bool PageInsert { get { return false;}}
		public override bool CanEdit { get { return true && UpdateValidation(); }}
		public override bool CanInsert  { get { return true && InsertValidation(); } }
		public override bool CanDelete { get { return true && DeleteValidation(); } }
		public override bool CanView { get { return true; } }
		public override bool OpenInEditMode { get { return false; } }
		


		public string ParamOrigem = "";

		
		public override void CreateProvider()
		{
			PageProvider = new TB_LOGIN_USER3PageProvider(this);
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
			ParamOrigem = HttpContext.Current.Request.QueryString["ParamOrigem"];
			try { if (string.IsNullOrEmpty(ParamOrigem)) ParamOrigem = HttpContext.Current.Session["ParamOrigem"].ToString();} catch {} 
			if (string.IsNullOrEmpty(ParamOrigem)) ParamOrigem = "";
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
		
		public void FillOrRefreshControls()
		{
		}
		
		public void FillOrRefreshControls(object Control, bool ForceRefresh)
		{
			if(Control == Grid1)
			{
				Grid1.Rebind();
				
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
			Utility.SetControlTabOnEnter(txtPesquisar);
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
			FillOrRefreshControls();		
		}
		
		/// <summary>
		/// Define conteudo dos objetos de Tela
		/// </summary>
		public override void DefinePageContent(GeneralDataProviderItem Item)
		{
			ApplyMasks(txtPesquisar);
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
					LOGIN_GROUP_NAMEField = Item["LOGIN_GROUP_NAME"].GetFormattedValue();
				}
				else
				{
				LOGIN_GROUP_NAMEField = "";
				}
			}
			catch
			{
				LOGIN_GROUP_NAMEField = "";
			}
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
					LOGIN_USER_COORDENACAOField = Item["LOGIN_USER_COORDENACAO"].GetFormattedValue();
				}
				else
				{
				LOGIN_USER_COORDENACAOField = "";
				}
			}
			catch
			{
				LOGIN_USER_COORDENACAOField = "";
			}
			PageProvider.AliasVariables.Add("LOGIN_GROUP_NAMEField", LOGIN_GROUP_NAMEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_LOGINField", LOGIN_USER_LOGINField);
			PageProvider.AliasVariables.Add("LOGIN_USER_PASSWORDField", LOGIN_USER_PASSWORDField);
			PageProvider.AliasVariables.Add("LOGIN_USER_NAMEField", LOGIN_USER_NAMEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_OBSField", LOGIN_USER_OBSField);
			PageProvider.AliasVariables.Add("LOGIN_USER_EMAILField", LOGIN_USER_EMAILField);
			PageProvider.AliasVariables.Add("LOGIN_USER_PHONEField", LOGIN_USER_PHONEField);
			PageProvider.AliasVariables.Add("LOGIN_USER_COORDENACAOField", LOGIN_USER_COORDENACAOField);
			PageProvider.AliasVariables.Add("ParamOrigem", ParamOrigem);
			PageProvider.AliasVariables.Add("BasePage", this);
        }

		protected void ___txtPesquisar_TextChanged(object sender, EventArgs e)
		{
			bool ActionSucceeded_1 = true;
			try
			{
					FillOrRefreshControls(Grid1, true);
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
					if (PageProvider.PesquisarUsuario_Grid1Provider.DataProvider.Item == null)
						Item = PageProvider.PesquisarUsuario_Grid1Provider.GetDataProviderItem();
					else
						Item = PageProvider.PesquisarUsuario_Grid1Provider.DataProvider.Item;
					PageProvider.PesquisarUsuario_Grid1Provider.RaiseSetRelationFields(PageProvider.PesquisarUsuario_Grid1Provider, Item);
					if (PageProvider.PesquisarUsuario_Grid1Provider.GridData["LOGIN_GROUP_NAME"] != null) Item.SetFieldValue(Item["LOGIN_GROUP_NAME"], Crypt.Encripta(PageProvider.PesquisarUsuario_Grid1Provider.GridData["LOGIN_GROUP_NAME"].ToString()));
					if (PageProvider.PesquisarUsuario_Grid1Provider.GridData["LOGIN_USER_LOGIN"] != null) Item.SetFieldValue(Item["LOGIN_USER_LOGIN"], Crypt.Encripta(PageProvider.PesquisarUsuario_Grid1Provider.GridData["LOGIN_USER_LOGIN"].ToString()));
					Item.SetFieldValue(Item["LOGIN_USER_COORDENACAO"], PageProvider.PesquisarUsuario_Grid1Provider.GridData["LOGIN_USER_COORDENACAO"]);
					PageProvider.PesquisarUsuario_Grid1Provider.InitializeAlias(Item);
					if (EnableValidation)
					{
						PageProvider.PesquisarUsuario_Grid1Provider.Validate(Item);
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
				Mask.SetMask(txt, "@!", 60, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				txt = (editableItem.EditManager.GetColumnEditor("GridColumn2") as GridTextBoxColumnEditor).TextBoxControl;
				txt.Width = 78;
				Mask.SetMask(txt, "@!", 40, false);
				txt.Attributes.Add("onblur", "OnMaskBlur();");
				txt.Attributes.Add("isGrid", "true");
				ApplyMasks(txt);
				GridItemCreatedFinished(sender, e);
			}
		}
		
		
		private void PrepareCombo(RadComboBox cbo, string FieldTextName, string FieldValueName, GeneralDataProviderItem row, bool AutoCryptDecript)
		{
			if (row != null)
			{
				cbo.SelectedValue = row[FieldValueName].Value.ToString();
				var _text = "";
				var i = 0;
				foreach (var item in FieldTextName.Split('+'))
				{
					var _field = item.Replace("[", "").Replace("]", "").Trim();
					if (i % 2 == 0)
					{
						if (row[_field].Value != null)
						{
							if (!AutoCryptDecript)
								_text += row[_field].Value.ToString();
							else
								_text += Crypt.Decripta(row[_field].Value.ToString());
						}
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
			if (e.Item is GridDataItem && !e.Item.IsInEditMode)
			{
				(e.Item as GridDataItem)["GridColumn1"].Text = Crypt.Decripta((e.Item as GridDataItem)["GridColumn1"].Text);
				(e.Item as GridDataItem)["GridColumn2"].Text = Crypt.Decripta((e.Item as GridDataItem)["GridColumn2"].Text);
			}
			if (e.Item.IsInEditMode)
			{
				GridEditableItem item = (GridEditableItem)e.Item;
				if (!(item is IGridInsertItem))
				{
					Utility.SelectGridComboItem(PageProvider.PesquisarUsuario_Grid1Provider.GridColumn8Provider, item, "GridColumn8", "LOGIN_USER_COORDENACAO");
				}
			}
		}
		private void FillGridComboValues(string GridId, Hashtable newValues, GridTableRow item)
		{
			RadComboBox cbo;
			switch (GridId)
			{
				case "Grid1":
					cbo = (RadComboBox)item.FindControl("GridColumn8_ComboBox");
					newValues["LOGIN_USER_COORDENACAO"] = cbo.SelectedValue;
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
				lab = item["GridColumn8"].FindControl("GridColumn8_Label") as Label;
				CurrentValues["siglaCoordenacao"] = lab.Attributes["Value"];
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
					case "GridColumn9":
						bool ActionSucceeded_GridColumn9_1 = true;
						try
						{
							if ((ParamOrigem == "CadastrarUsuario"))
							{
								string UrlPage = ResolveUrl("~/Pages/Usuarios/CadastrarUsuario.aspx");
								try
								{
									Response.Redirect(UrlPage);
								}
								catch(Exception ex)
								{
								}
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn9_1 = false;
							PageErrors.Add("Error", ex.Message);
							ShowErrors();
						}
						bool ActionSucceeded_GridColumn9_2 = true;
						try
						{
							if ((ParamOrigem == "EditarUsuario"))
							{
								string UrlPage = ResolveUrl("~/Pages/Usuarios/EditarUsuario.aspx");
								try
								{
									Response.Redirect(UrlPage);
								}
								catch(Exception ex)
								{
								}
							}
						}
						catch (Exception ex)
						{
							ActionSucceeded_GridColumn9_2 = false;
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
		
		public override GeneralGridProvider GetGridProvider(RadGrid Grid)
		{
			switch (Grid.ID)
			{
				case "Grid1":
					return PageProvider.PesquisarUsuario_Grid1Provider;
			}
			return null;
		}
		protected void ___Grid1_GridColumn8_ComboBox_OnItemsRequested(object sender, RadComboBoxItemsRequestedEventArgs e)
		{
			KeyValuePair<string, object> AllowFilterContext = e.Context.FirstOrDefault(c => c.Key == "AllowFilter");
			bool AllowFilter = false;
			if (AllowFilterContext.Value != null) AllowFilter = Convert.ToBoolean(AllowFilterContext.Value);
		
			int ItemsCount = Convert.ToInt32(e.Context["ItemsCount"]);
			RadComboBoxItem item = new RadComboBoxItem("Todos");
			item.Font.Bold = true;
			if (((RadComboBox)sender).ID.EndsWith("Filter")) ((RadComboBox)sender).Items.Add(item);
			e.EndOfItems = PageProvider.PesquisarUsuario_Grid1Provider.FillCombo(PageProvider.PesquisarUsuario_Grid1Provider.GridColumn8Provider, sender as RadComboBox, e.NumberOfItems, e.Text, AllowFilter);
		}
	}
}

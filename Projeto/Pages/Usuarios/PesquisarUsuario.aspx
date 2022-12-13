<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="PesquisarUsuario.aspx.cs" Inherits="PROJETO.DataPages.PesquisarUsuario" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/PesquisarUsuario.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="../../Styles/animate.min.css" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="../../Styles/all.min.css" type="text/css" media="screen" title="no title"/>  	
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="../../JS/jquery.js" ></script>
		<script type="text/javascript" src="../../JS/iframeResizer.min.js" ></script>
		<script type="text/javascript" src="../../JS/iframeResizer.contentWindow.min.js" ></script>
		<script type="text/javascript" src="../../JS/wow.min.js" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="../../JS/Page.js"></script>
		<script type="text/javascript" src="../../JS/Common.js"></script>
		<script type="text/javascript" src="../../JS/Functions.js"></script>
		<script src='../../JS/Mask.js' type="text/javascript"></script>
		<script type="text/javascript" src="../../JS/RadComboBoxHelper.js"></script>
		<script type="text/javascript" src="../../JS/PesquisarUsuario_USER.js?sv=v1.0.11_20221213104600"></script>

		<script type="text/javascript">
			function OnLoginSucceded()
			{
				if(getParentPage() != self && getParentPage() != null)
				{
					getParentPage().OnLoginSucceded();
				}
			}
			function TryLogin(PageToRedirect, RefreshControlsID)
			{
				TryParentLogin(PageToRedirect, RefreshControlsID, false, '<%= ResolveUrl("~/Pages/StartPage.aspx") %>');
			}
			currentPath = "<%= Page.Request.Path %>";
		</script>
	</telerik:RadCodeBlock>
	<script type="text/javascript">	   
		
	</script>
    <script type="text/javascript">
	</script>
	<script type="text/javascript">
		function ___Form1_OnResponseEnd(sender, args)
		{
			OnResponseEnd(sender,args);
		}
		function ___Form1_OnRequestStart(sender, args)
		{
			OnRequestStart(sender,args);
		}
		function ___Button4_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___txtPesquisar_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___txtPesquisar_OnBlur()
		{
			ExecuteCommandRequest("ApplyFilter","","","continue:___txtPesquisar_OnBlur_Action1();");
			args.set_cancel(true);
			return false;
		}
		function ___txtPesquisar_OnBlur_Action1()
		{
			Refresh(this);
		}
		function ___txtPesquisar_OnTextBoxButtonClick(sender, args)
		{
		}
		function ___Button5_OnClientClick(sender, args)
		{
			Refresh(this);
			args.set_cancel(true);
			return false;
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
							OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button4 %>">
						</telerik:RadButton>
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Pesquisar Usuario" />
					</div>
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" EnableEmbeddedSkins="True" EnableHeaderContextMenu="False"
							EnableLinqExpressions="false" ExportFileName="GGrid" OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init"
							OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand" OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound"
							OnNeedDataSource="Grid_NeedDataSource" OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False"
							ShowGroupPanel="False" TabIndex="2" TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="LOGIN_USER_LOGIN" EditMode="InPlace">
								<Columns>
									<telerik:GridBoundColumn UniqueName="GridColumn1" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="LOGIN_GROUP_NAME" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn1" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn1 %>" ItemStyle-CssClass="c_GridColumn1" ItemStyle-Width="86" MaxLength="60" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="LOGIN_USER_LOGIN" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="86" MaxLength="40" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridTemplateColumn UniqueName="GridColumn8" runat="server" AllowFiltering="True" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="LOGIN_USER_COORDENACAO" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always"
										GroupByExpression="LOGIN_USER_COORDENACAO LOGIN_USER_COORDENACAO Group By LOGIN_USER_COORDENACAO" HeaderStyle-CssClass="c_GridColumn8"
										HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn8 %>" ItemStyle-CssClass="c_GridColumn8" ItemStyle-Width="86" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" SortExpression="LOGIN_USER_COORDENACAO">
										<EditItemTemplate>
											<telerik:RadComboBox ID="GridColumn8_ComboBox" runat="server" MarkFirstMatch="True" AllowCustomText="False" 
												 AutoPostBack="False" EnableLoadOnDemand="True" EnableVirtualScrolling="True" MaxHeight="100"
												OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" DropDownAutoWidth ="Enabled"
												OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___Grid1_GridColumn8_ComboBox_OnItemsRequested" ItemsPerRequest="15"
												Width="78" ClientIDMode="Static" />
										</EditItemTemplate>
										<ItemTemplate> 
											<asp:Label runat="server" ID="GridColumn8_Label" Text='<%#PageProvider.PesquisarUsuario_Grid1Provider.GetGridComboText("GridColumn8", Eval("LOGIN_USER_COORDENACAO").ToString())%>' Value='<%#Eval("LOGIN_USER_COORDENACAO").ToString()%>'/>
										</ItemTemplate> 
									</telerik:GridTemplateColumn>
									<telerik:GridButtonColumn UniqueName="GridColumn9" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn9" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn9" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn9 %>" ItemStyle-CssClass="c_GridColumn9"
										ItemStyle-Width="86" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn9_1 %>" />
									<telerik:GridTemplateColumn Exportable="false" AllowFiltering="false"></telerik:GridTemplateColumn>
								</Columns>
								<CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
							</MasterTableView>
							<PagerStyle Mode="NextPrevAndNumeric" />
							<ClientSettings EnableRowHoverStyle="true">
								<ClientEvents />
							</ClientSettings>
						</telerik:RadGrid>
					</div>
					<telerik:RadTextBox id="txtPesquisar" runat="server" AutoPostBack="False" CssClass="c_txtPesquisar"
						ClientEvents-OnButtonClick="___txtPesquisar_OnTextBoxButtonClick" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True"
						ForeColor="#000000" MaxLength="0" onblur="___txtPesquisar_OnBlur();" onkeydown="___txtPesquisar_onkeydown();"
						OnTextChanged="___txtPesquisar_TextChanged" ReadOnly="False" RenderMode="Lightweight" TabIndex="3" TextMode="SingleLine"
						WrapperCssClass="c_txtPesquisar_wrapper" />
					<telerik:RadButton id="Button5" runat="server" ButtonType="SkinnedButton" CssClass="c_Button5" CommandName="Button5"
						OnClientClicking="___Button5_OnClientClick" RenderMode="Lightweight" TabIndex="4" Text="<%$ Resources: Button5 %>">
					</telerik:RadButton>
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
				</div>
			<telerik:RadAjaxLoadingPanel ID="___Form1_AjaxLoading" runat="server">
			</telerik:RadAjaxLoadingPanel>
			</telerik:RadAjaxPanel>
		</form>
		
	</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
	<script type="text/javascript">
		var $j = jQuery.noConflict();
		$j(document).ready(SetFocusFirstField());
		function SetFocusFirstField()
		{
			try
			{
				{
					window.focus();
					setTimeout("var $j = jQuery.noConflict();$j('#Button4').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


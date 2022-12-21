<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="ListaCoordenacoesSetoriais.aspx.cs" Inherits="PROJETO.DataPages.ListaCoordenacoesSetoriais" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/ListaCoordenacoesSetoriais.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="../Styles/animate.min.css" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="../Styles/bootstrap.min.css" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="../Styles/all.min.css" type="text/css" media="screen" title="no title"/>  	
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		


		<script type="text/javascript" src="../JS/jquery.js" ></script>
		<script type="text/javascript" src="../JS/iframeResizer.min.js" ></script>
		<script type="text/javascript" src="../JS/iframeResizer.contentWindow.min.js" ></script>
		<script type="text/javascript" src="../JS/wow.min.js" ></script>
		<script type="text/javascript"> new WOW().init(); </script>
		<script type="text/javascript" src="../JS/Page.js"></script>
		<script type="text/javascript" src="../JS/Common.js"></script>
		<script type="text/javascript" src="../JS/Functions.js"></script>
		<script src='../JS/Mask.js' type="text/javascript"></script>
		<script type="text/javascript" src="../JS/ListaCoordenacoesSetoriais_USER.js?sv=v1.0.12_20221220102703"></script>

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
		function ___Button3_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/CadastroCoordenacoesSetoriais.aspx?ParamCodigo_Set={ParamCodigo_Set}") %>';
			UrlPage = UrlPage.replace('{ParamCodigo_Set}', '');
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button1_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___WSSetorial_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSSetorial_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSSetorial_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<telerik:RadWindowManager id="WSSetorial" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSSetorial" DestroyOnClose="True"
						EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSSetorial_OnClientClose"
						OnClientPageLoad="___WSSetorial_OnClientPageLoad" OnClientShow="___WSSetorial_OnClientShow" PreserveClientState="True" RenderMode="Classic"
						RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="True" VisibleTitlebar="True" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Lista de Coordenção ou Setorial" />
						<telerik:RadButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3" CommandName="Button3"
							OnClientClicking="___Button3_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button3 %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="2" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
					<div id="DivGrid" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_DivGrid">
						<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" EnableEmbeddedSkins="True" EnableHeaderContextMenu="False"
							EnableLinqExpressions="false" ExportFileName="GGrid" OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init"
							OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand" OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound"
							OnNeedDataSource="Grid_NeedDataSource" OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False"
							ShowGroupPanel="False" TabIndex="3" TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="codigo" EditMode="InPlace">
								<Columns>
									<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaDiretoria" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="26"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="61"
										HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="54" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn3" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaCoordenacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="88"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn3" HeaderStyle-Width="123"
										HeaderText="<%$ Resources: GridColumn3 %>" ItemStyle-CssClass="c_GridColumn3" ItemStyle-Width="116" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn4" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaSetorial" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="119"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn4" HeaderStyle-Width="154"
										HeaderText="<%$ Resources: GridColumn4 %>" ItemStyle-CssClass="c_GridColumn4" ItemStyle-Width="147" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn5" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="nomeSetorial" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="146"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn5" HeaderStyle-Width="181"
										HeaderText="<%$ Resources: GridColumn5 %>" ItemStyle-CssClass="c_GridColumn5" ItemStyle-Width="174" MaxLength="100" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridButtonColumn UniqueName="GridColumn6" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn6" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn6" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn6 %>" ItemStyle-CssClass="c_GridColumn6"
										ItemStyle-Width="86" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn6_1 %>" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#Button3').first().focus();", 200);
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


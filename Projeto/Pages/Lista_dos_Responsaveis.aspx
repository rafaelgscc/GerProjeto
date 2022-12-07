<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="Lista_dos_Responsaveis.aspx.cs" Inherits="PROJETO.DataPages.Lista_dos_Responsaveis" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Lista_dos_Responsaveis.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="../Styles/validationEngine.jquery.css" type="text/css" media="screen" title="no title"/>
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
		<script type="text/javascript" src="../JS/Lista_dos_Responsaveis_USER.js?sv=v1.0.11_20221207165304"></script>
		<script type="text/javascript" src="../JS/jquery.validationEngine-pt_BR.js"></script>
		<script type="text/javascript" src="../JS/jquery.validationEngine.js"></script>
		<script type="text/javascript" src="../JS/validation.js"></script>

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
		function RegisterClientValidateScript()
		{
			var $j = jQuery.noConflict();
			$j(document).ready(function() 
			{
				$j("#Form1").validationEngine()
			});
		}
		RegisterClientValidateScript();
		
	</script>
    <script type="text/javascript">
		var HasValidation = true;
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
			var UrlPage = '<%= ResolveUrl("~/Pages/TB_RESPONSAVEL.aspx?ParamCodigo_Pes={ParamCodigo_Pes}") %>';
			UrlPage = UrlPage.replace('{ParamCodigo_Pes}', '');
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
		function ___WSResponsavel_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSResponsavel_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSResponsavel_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function GridColumn10_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<telerik:RadWindowManager id="WSResponsavel" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSResponsavel" DestroyOnClose="True"
						EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSResponsavel_OnClientClose"
						OnClientPageLoad="___WSResponsavel_OnClientPageLoad" OnClientShow="___WSResponsavel_OnClientShow" PreserveClientState="True"
						RenderMode="Classic" RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="True"
						VisibleTitlebar="True" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Lista dos Responsáveis" />
						<telerik:RadButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3" CommandName="Button3"
							OnClientClicking="___Button3_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button3 %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
					<div id="DivGrid" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_DivGrid">
						<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="True" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" ClientSettings-ClientEvents-OnCommand="CheckValidation"
							EnableEmbeddedSkins="True" EnableHeaderContextMenu="False" EnableLinqExpressions="false" ExportFileName="GGrid"
							OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init" OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand"
							OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource"
							OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False" ShowGroupPanel="False" TabIndex="2"
							TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="codigo" EditMode="InPlace">
								<Columns>
									<telerik:GridBoundColumn UniqueName="GridColumn10" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaDiretoria" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="19"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn10" HeaderStyle-Width="54"
										HeaderText="<%$ Resources: GridColumn10 %>" ItemStyle-CssClass="c_GridColumn10" ItemStyle-Width="47" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn11" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaCoordenacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn11" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn11 %>" ItemStyle-CssClass="c_GridColumn11" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="nomeResponsavel" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="258"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="293"
										HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="286" MaxLength="100" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn4" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="ramalResponsavel" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn4" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn4 %>" ItemStyle-CssClass="c_GridColumn4" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn5" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="contatoResponsavel" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="108"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn5" HeaderStyle-Width="143"
										HeaderText="<%$ Resources: GridColumn5 %>" ItemStyle-CssClass="c_GridColumn5" ItemStyle-Width="136" MaxLength="15" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn6" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="salaResponsavel" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="78"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn6" HeaderStyle-Width="113"
										HeaderText="<%$ Resources: GridColumn6 %>" ItemStyle-CssClass="c_GridColumn6" ItemStyle-Width="106" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
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


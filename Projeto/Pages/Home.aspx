<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="Home.aspx.cs" Inherits="PROJETO.DataPages.Home" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Home.css" OrderIndex="2"/>
			<telerik:StyleSheetReference Path="~/Styles/GridAPPProjeto.css" />
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="../Styles/validationEngine.jquery.css" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="../Styles/animate.min.css" type="text/css" media="screen" title="no title"/>
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
		<script type="text/javascript" src="../JS/RadComboBoxHelper.js"></script>
<script type="text/javascript">
		alert("Atualização:\nVersão 1.0.11: Adicionado barra ANO em diretriz\nVersão 1.0.12: Adicionado item STATUS em ação");
</script>
		<script type="text/javascript" src="../JS/Home_USER.js?sv=v1.0.12_20221213161348"></script>
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
		function ___Button1_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Relacao_de_Diretriz.aspx?ParamCoordenacao={ParamCoordenacao}") %>';
			UrlPage = UrlPage.replace('{ParamCoordenacao}', '');
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button2_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Lista_das_Diretorias.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button3_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Coordenacao_Geral.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button4_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/ListaCoordenacoesSetoriais.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button5_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Lista_dos_Responsaveis.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button7_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Access.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___Button8_OnClientClick(sender, args)
		{
			localStorage.removeItem('SSI_F'); localStorage.removeItem('SSI_T'); Logoff();
			args.set_cancel(true);
			return false;
		}
		function ___Button9_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Relatórios/RelatorioMetas.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___MenuItem2_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Usuarios/CadastrarUsuario.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
		}
		function ___MenuItem3_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Usuarios/EditarUsuario.aspx") %>';
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
		}
		function ___cmbCoordenacao_OnClientSelectionChanged()
		{
			Refresh(this);
		}
		function ___WSPrincipal_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSPrincipal_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSPrincipal_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function ___WSRelatorio_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSRelatorio_OnClientShow(sender, args)
		{
			OnClientShow(sender);
			document.getElementById('WSRelatorio').control.GetActiveWindow().maximize();
		}
		function ___WSRelatorio_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function GridColumn26_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function GridColumn24_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function GridColumn29_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function GridColumn28_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<telerik:RadWindowManager id="WSRelatorio" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSRelatorio" DestroyOnClose="True"
						EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSRelatorio_OnClientClose"
						OnClientPageLoad="___WSRelatorio_OnClientPageLoad" OnClientShow="___WSRelatorio_OnClientShow" PreserveClientState="True"
						RenderMode="Lightweight" RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="True"
						VisibleTitlebar="True" />
					<telerik:RadWindowManager id="WSPrincipal" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSPrincipal" DestroyOnClose="True"
						EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSPrincipal_OnClientClose"
						OnClientPageLoad="___WSPrincipal_OnClientPageLoad" OnClientShow="___WSPrincipal_OnClientShow" PreserveClientState="True" RenderMode="Classic"
						RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="False" VisibleTitlebar="False" />
					<div id="DivPrincipal" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_DivPrincipal">
						<div id="DivMenu" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_DivMenu">
							<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
								OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button1 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button5" runat="server" ButtonType="SkinnedButton" CssClass="c_Button5" CommandName="Button5"
								OnClientClicking="___Button5_OnClientClick" RenderMode="Lightweight" TabIndex="5" Text="<%$ Resources: Button5 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
								OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="4" Text="<%$ Resources: Button4 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3" CommandName="Button3"
								OnClientClicking="___Button3_OnClientClick" RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: Button3 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2" CommandName="Button2"
								OnClientClicking="___Button2_OnClientClick" RenderMode="Lightweight" TabIndex="2" Text="<%$ Resources: Button2 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button7" runat="server" ButtonType="SkinnedButton" CssClass="c_Button7" CommandName="Button7"
								OnClientClicking="___Button7_OnClientClick" RenderMode="Lightweight" TabIndex="6" Text="<%$ Resources: Button7 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button9" runat="server" ButtonType="SkinnedButton" CssClass="c_Button9" CommandName="Button9"
								OnClientClicking="___Button9_OnClientClick" RenderMode="Lightweight" TabIndex="9" Text="<%$ Resources: Button9 %>">
							</telerik:RadButton>
							<telerik:RadButton id="Button8" runat="server" ButtonType="SkinnedButton" CssClass="c_Button8" CommandName="Button8"
								OnClientClicking="___Button8_OnClientClick" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: Button8 %>">
							</telerik:RadButton>
							<telerik:RadMenu id="mnAdministracao" runat="server" CssClass="c_mnAdministracao" ClickToOpen="False" CollapseAnimation-Duration="200"
								CollapseAnimation-Type="OutQuint" ExpandAnimation-Duration="200" ExpandAnimation-Type="OutQuint" Flow="Horizontal"
								OnClientItemClicked="___mnAdministracaoClickHandler" RenderMode="Classic">
								<Items>
									<telerik:RadMenuItem id="mnAdm" runat="server" CssClass="c_mnAdm" Text="<%$ Resources: mnAdm %>" Value="mnAdm">
										<Items>
											<telerik:RadMenuItem id="MenuItem2" runat="server" CssClass="c_MenuItem2" Text="<%$ Resources: MenuItem2 %>" Value="MenuItem2" />
											<telerik:RadMenuItem id="MenuItem3" runat="server" CssClass="c_MenuItem3" Text="<%$ Resources: MenuItem3 %>" Value="MenuItem3" />
										</Items>
									</telerik:RadMenuItem>
								</Items>
							</telerik:RadMenu>
						</div>
						<div id="DivProjetos" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_DivProjetos GridAPPProjeto">
							<telerik:RadGrid id="Grid2" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
								AutoGenerateColumns="false" CssClass="c_Grid2" CleanLayoutNoRecord="False" ClientSettings-ClientEvents-OnCommand="CheckValidation"
								EnableEmbeddedSkins="True" EnableHeaderContextMenu="False" EnableLinqExpressions="false" ExportFileName="GGrid"
								OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init" OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid2_ItemCommand"
								OnItemCreated="Grid2_ItemCreated" OnItemDataBound="Grid2_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource"
								OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False" ShowGroupPanel="False" TabIndex="7"
								TableLayout="Fixed">
								<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="codigo" EditMode="InPlace">
									<Columns>
										<telerik:GridBoundColumn UniqueName="GridColumn16" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="codigo" DataFormatString="{0:#########0}" EnableHeaderContextMenu="True" Exportable="True"
											FilterControlWidth="8" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn16" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="43"
											HeaderText="<%$ Resources: GridColumn16 %>" ItemStyle-CssClass="c_GridColumn16" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="36"
											MaxLength="10" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn26" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="siglaCoordenacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn26" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn26 %>" ItemStyle-CssClass="c_GridColumn26" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn27" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="siglaSetorial" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn27" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn27 %>" ItemStyle-CssClass="c_GridColumn27" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn17" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="nomeProjeto" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="665"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn17" HeaderStyle-Width="700"
											HeaderText="<%$ Resources: GridColumn17 %>" ItemStyle-CssClass="c_GridColumn17" ItemStyle-Width="693" MaxLength="255" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn18" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="Diretriz" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="8"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn18" HeaderStyle-Width="43"
											HeaderText="<%$ Resources: GridColumn18 %>" ItemStyle-CssClass="c_GridColumn18" ItemStyle-Width="36" MaxLength="3" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn24" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="nivelProjeto" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="5"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn24" HeaderStyle-Width="40"
											HeaderText="<%$ Resources: GridColumn24 %>" ItemStyle-CssClass="c_GridColumn24" ItemStyle-Width="33" MaxLength="1" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridDateTimeColumn UniqueName="GridColumn23" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="inicioPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
											EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn23" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn23 %>"
											ItemStyle-CssClass="c_GridColumn23" ItemStyle-Width="86" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True"
											ShowSortIcon="True" />
										<telerik:GridDateTimeColumn UniqueName="GridColumn22" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="terminoPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
											EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn22" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn22 %>"
											ItemStyle-CssClass="c_GridColumn22" ItemStyle-Width="86" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True"
											ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn29" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="DiasDeProjeto" DataFormatString="{0:#########0}" EnableHeaderContextMenu="True"
											Exportable="True" FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn29" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn29 %>" ItemStyle-CssClass="c_GridColumn29" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn21" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="percentualExecutado" DataFormatString="{0:##0.00}" EnableHeaderContextMenu="True"
											Exportable="True" FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn21" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn21 %>" ItemStyle-CssClass="c_GridColumn21" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86"
											MaxLength="6" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn19" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="statusProjeto" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn19" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn19 %>" ItemStyle-CssClass="c_GridColumn19" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn28" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="situacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn28" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn28 %>" ItemStyle-CssClass="c_GridColumn28" ItemStyle-Width="86" MaxLength="20" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridButtonColumn UniqueName="GridColumn25" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
											CommandName="GridColumn25" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
											HeaderStyle-CssClass="c_GridColumn25" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn25 %>"
											ItemStyle-CssClass="c_GridColumn25" ItemStyle-Width="86" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn25_1 %>"
											/>
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
						<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
							<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
							<telerik:RadComboBox id="cmbCoordenacao" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_cmbCoordenacao"
								CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
								EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
								LoadingMessage="<%$ Resources: cmbCoordenacao %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
								OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
								OnClientSelectedIndexChanged="___cmbCoordenacao_OnClientSelectionChanged" OnItemsRequested="___cmbCoordenacao_OnItemsRequested"
								RenderMode="Lightweight" TabIndex="10" />
						</div>
					</div>
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
					setTimeout("var $j = jQuery.noConflict();$j('#Button1').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function ___mnAdministracaoClickHandler(sender, args)
		{
			var ClickedItem = args.get_item();
			if (HasValue(ClickedItem))
			{
				sender.close(true);
				switch (ClickedItem.get_value())
				{
					case "MenuItem2":
						___MenuItem2_OnClick(sender, args);
					break;
					case "MenuItem3":
						___MenuItem3_OnClick(sender, args);
					break;
				}
			}
		}
		function __cmbCoordenacao() { return $find("<%= cmbCoordenacao.ClientID %>").get_value(); }
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="RelacaodoCadastrodeAcoes.aspx.cs" Inherits="PROJETO.DataPages.RelacaodoCadastrodeAcoes" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/RelacaodoCadastrodeAcoes.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/RelacaodoCadastrodeAcoes_USER.js?sv=v1.0.12_20221220102702"></script>
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
		function Grid1Created(sender, args) {
			var $j = jQuery.noConflict();
			if (($j("#Grid1ShouldDisable")[0] && $j("#Grid1ShouldDisable")[0].value == "True") || ($j("#__PAGESTATE")[0] && $j("#__PAGESTATE")[0].value == "Insert"))
				DisableGrid(sender);
		}
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
		function ___Button4_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___RadTextBox1_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___ComboBox1_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___ComboBox2_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox3_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox4_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___ComboBox3_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___ComboBox4_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox5_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox6_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___WSItensProjeto_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSItensProjeto_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSItensProjeto_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function ___Button3_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/TB_ITENS_PROJETO.aspx?ParamCodigoProjeto={ParamCodigoProjeto}&ParamItemProjeto={ParamItemProjeto}&ParamCoordenacao={ParamCoordenacao}&ParamNomeProjeto={ParamNomeProjeto}") %>';
			UrlPage = UrlPage.replace('{ParamCodigoProjeto}', codigo());
			UrlPage = UrlPage.replace('{ParamItemProjeto}', '');
			UrlPage = UrlPage.replace('{ParamCoordenacao}', siglaCoordenacao());
			UrlPage = UrlPage.replace('{ParamNomeProjeto}', nomeProjeto());
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function GridColumn3_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function GridColumn4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox2_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox3_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<telerik:RadWindowManager id="WSItensProjeto" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSItensProjeto"
						DestroyOnClose="True" EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSItensProjeto_OnClientClose"
						OnClientPageLoad="___WSItensProjeto_OnClientPageLoad" OnClientShow="___WSItensProjeto_OnClientShow" PreserveClientState="True"
						RenderMode="Classic" RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="False" VisibleStatusbar="False"
						VisibleTitlebar="False" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Relação do Cadastro de Ações" />
						<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
							OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: Button4 %>">
						</telerik:RadButton>
					</div>
					<div id="Div2" runat="server" AutoExpandToContent="True" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadTextBox id="RadTextBox1" runat="server" AutoPostBack="False" CssClass="c_RadTextBox1"
							data-validation-engine="validate[funcCall[RadTextBox1_Validation]]" data-validation-message="Nome do Projeto não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="255"
							onkeydown="___RadTextBox1_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox1_wrapper" />
						<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
						<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" Text="<%$ Resources: Label7 %>" />
						<telerik:RadComboBox id="ComboBox1" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox1" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox1_Validation]]" data-validation-message="Diretriz não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox1 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox1_OnBlur"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox1_OnItemsRequested" RenderMode="Classic" TabIndex="2" />
						<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
						<telerik:RadComboBox id="ComboBox2" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox2" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox2_Validation]]" data-validation-message="Status do Projeto não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox2 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox2_OnBlur"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox2_OnItemsRequested" RenderMode="Lightweight" TabIndex="3" />
						<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
						<telerik:RadTextBox id="RadTextBox3" runat="server" AutoPostBack="False" CssClass="c_RadTextBox3" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox3_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="10" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox3_wrapper" />
						<telerik:RadTextBox id="RadTextBox4" runat="server" AutoPostBack="False" CssClass="c_RadTextBox4" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox4_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="6" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox4_wrapper" />
						<telerik:RadLabel id="Label10" runat="server" CssClass="c_Label10" Text="<%$ Resources: Label10 %>" />
						<telerik:RadDatePicker id="DatePicker2" runat="server" CssClass="c_DatePicker2" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="4" Width="124">
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label11" runat="server" CssClass="c_Label11" Text="<%$ Resources: Label11 %>" />
						<telerik:RadDatePicker id="DatePicker3" runat="server" CssClass="c_DatePicker3" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="5" Width="124">
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" Text="<%$ Resources: Label12 %>" />
						<telerik:RadComboBox id="ComboBox3" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox3" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox3_Validation]]" data-validation-message="Sigla da Diretoria não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox3 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox3_OnBlur"
							OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox3_OnItemsRequested" RenderMode="Lightweight" TabIndex="11" />
						<telerik:RadLabel id="Label13" runat="server" CssClass="c_Label13" Text="<%$ Resources: Label13 %>" />
						<telerik:RadComboBox id="ComboBox4" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox4" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox4_Validation]]" data-validation-message="Coordenação não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox4 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox4_OnBlur"
							OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox4_OnItemsRequested" RenderMode="Lightweight" TabIndex="12" />
						<telerik:RadLabel id="Label14" runat="server" CssClass="c_Label14" Text="<%$ Resources: Label14 %>" />
						<telerik:RadTextBox id="RadTextBox5" runat="server" AutoPostBack="False" CssClass="c_RadTextBox5" EnabledStyle-HorizontalAlign="Left"
							EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="20" onkeydown="___RadTextBox5_onkeydown();" ReadOnly="False"
							RenderMode="Lightweight" TabIndex="13" TextMode="SingleLine" WrapperCssClass="c_RadTextBox5_wrapper" />
						<telerik:RadLabel id="Label15" runat="server" CssClass="c_Label15" Text="<%$ Resources: Label15 %>" />
						<telerik:RadTextBox id="RadTextBox6" runat="server" AutoPostBack="False" CssClass="c_RadTextBox6" EnabledStyle-HorizontalAlign="Right"
							EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="6" onkeydown="___RadTextBox6_onkeydown();" ReadOnly="False"
							RenderMode="Lightweight" TabIndex="14" TextMode="SingleLine" WrapperCssClass="c_RadTextBox6_wrapper" />
						<telerik:RadLabel id="Label16" runat="server" CssClass="c_Label16" Text="<%$ Resources: Label16 %>" />
					</div>
					<div id="Div4" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div4">
						<telerik:RadButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3" CommandName="Button3"
							OnClientClicking="___Button3_OnClientClick" RenderMode="Lightweight" TabIndex="9" Text="<%$ Resources: Button3 %>">
						</telerik:RadButton>
						<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
						<div id="DivGrid" runat="server" AutoExpandToContent="True" AutoExpandToContentMargin="10" class="c_DivGrid">
							<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
								AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" ClientSettings-ClientEvents-OnCommand="CheckValidation"
								EnableEmbeddedSkins="True" EnableHeaderContextMenu="False" EnableLinqExpressions="false" ExportFileName="GGrid"
								OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init" OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand"
								OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource"
								OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False" ShowGroupPanel="False" TabIndex="7"
								TableLayout="Fixed">
								<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="projeto,itemProjeto" EditMode="InPlace">
									<Columns>
										<telerik:GridBoundColumn UniqueName="GridColumn1" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="itemProjeto" DataFormatString="{0:####0}" EnableHeaderContextMenu="True" Exportable="True"
											FilterControlWidth="10" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn1" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="45" HeaderText="<%$ Resources: GridColumn1 %>"
											ItemStyle-CssClass="c_GridColumn1" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="38" MaxLength="5" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="nomeAcao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="511"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="546"
											HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="539" MaxLength="255" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridDateTimeColumn UniqueName="GridColumn3" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="inicioPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
											EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn3" HeaderStyle-Width="73" HeaderText="<%$ Resources: GridColumn3 %>" ItemStyle-CssClass="c_GridColumn3"
											ItemStyle-Width="66" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridDateTimeColumn UniqueName="GridColumn4" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="terminoPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
											EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn4" HeaderStyle-Width="73" HeaderText="<%$ Resources: GridColumn4 %>" ItemStyle-CssClass="c_GridColumn4"
											ItemStyle-Width="66" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn12" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="DiasPrevistos" DataFormatString="{0:##0}" EnableHeaderContextMenu="True" Exportable="True"
											FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn12" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn12 %>" ItemStyle-CssClass="c_GridColumn12" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86"
											MaxLength="3" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn9" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="percentualExecutado" DataFormatString="{0:##0.00}" EnableHeaderContextMenu="True"
											Exportable="True" FilterControlWidth="38" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn9" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="73" HeaderText="<%$ Resources: GridColumn9 %>"
											ItemStyle-CssClass="c_GridColumn9" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="66" MaxLength="6" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridDateTimeColumn UniqueName="GridColumn5" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="terminoRealizado" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
											EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
											HeaderStyle-CssClass="c_GridColumn5" HeaderStyle-Width="73" HeaderText="<%$ Resources: GridColumn5 %>" ItemStyle-CssClass="c_GridColumn5"
											ItemStyle-Width="66" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn6" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="nomeSobrenome" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="108"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn6" HeaderStyle-Width="143"
											HeaderText="<%$ Resources: GridColumn6 %>" ItemStyle-CssClass="c_GridColumn6" ItemStyle-Width="136" MaxLength="50" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridBoundColumn UniqueName="GridColumn11" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
											ConvertEmptyStringToNull="False" DataField="situacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
											FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn11" HeaderStyle-Width="93"
											HeaderText="<%$ Resources: GridColumn11 %>" ItemStyle-CssClass="c_GridColumn11" ItemStyle-Width="86" MaxLength="20" ReadOnly="False"
											ShowFilterIcon="True" ShowSortIcon="True" />
										<telerik:GridButtonColumn UniqueName="GridColumn7" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
											CommandName="GridColumn7" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
											HeaderStyle-CssClass="c_GridColumn7" HeaderStyle-Width="53" HeaderText="<%$ Resources: GridColumn7 %>" ItemStyle-CssClass="c_GridColumn7"
											ItemStyle-Width="46" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn7_1 %>" />
										<telerik:GridButtonColumn UniqueName="GridColumn10" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
											CommandName="GridColumn10" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
											HeaderStyle-CssClass="c_GridColumn10" HeaderStyle-Width="63" HeaderText="<%$ Resources: GridColumn10 %>"
											ItemStyle-CssClass="c_GridColumn10" ItemStyle-Width="56" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn10_1 %>"
											/>
										<telerik:GridTemplateColumn Exportable="false" AllowFiltering="false"></telerik:GridTemplateColumn>
									</Columns>
									<CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
								</MasterTableView>
								<PagerStyle Mode="NextPrevAndNumeric" />
								<ClientSettings EnableRowHoverStyle="true">
									<ClientEvents OnGridCreated="Grid1Created" />
								</ClientSettings>
							</telerik:RadGrid>
						</div>
					</div>
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox1').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function nomeProjeto() { return document.getElementById('RadTextBox1').value; }
		function Diretriz() { return $find("<%= ComboBox1.ClientID %>").get_value(); }
		function statusProjeto() { return $find("<%= ComboBox2.ClientID %>").get_value(); }
		function codigo() { return document.getElementById('RadTextBox3').value; }
		function DiasDeProjeto() { return document.getElementById('RadTextBox4').value; }
		function inicioPrevisto() { return document.getElementById('DatePicker2').value; }
		function terminoPrevisto() { return document.getElementById('DatePicker3').value; }
		function siglaDiretoria() { return $find("<%= ComboBox3.ClientID %>").get_value(); }
		function siglaCoordenacao() { return $find("<%= ComboBox4.ClientID %>").get_value(); }
		function situacao() { return document.getElementById('RadTextBox5').value; }
		function percentualExecutado() { return document.getElementById('RadTextBox6').value; }
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="CadastroAtividades.aspx.cs" Inherits="PROJETO.DataPages.CadastroAtividades" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/CadastroAtividades.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/CadastroAtividades_USER.js?sv=v1.0.11_20221213104557"></script>
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

		function GetAditionalFields(senderName) 
		{
			var AditionalFields;
			switch (senderName) 
			{
				case "ComboBox3":
					AditionalFields = 
					{
						"cmbSiglaCoordenacao" : jQuery("#cmbSiglaCoordenacao")[0].control.get_value(),
					};
					break;
				case "ComboBox4":
					AditionalFields = 
					{
						"cmbSiglaCoordenacao" : jQuery("#cmbSiglaCoordenacao")[0].control.get_value(),
					};
					break;
			}
			return AditionalFields;
		}

		function ClientRefreshCombos(sender, args) 
		{
			var senderID = FindIdInObject(sender);
			switch (senderID)
			{
				case "cmbSiglaCoordenacao":
					PrepareAndRequestItems(new Array("ComboBox3"));
					break;
			}
		}
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
		function ___btnSalvar_OnClientClick(sender, args)
		{
			ExecuteCommandRequest("Save","","","continue:___btnSalvar_OnClientClick_Action1");
			args.set_cancel(true);
			return false;
		}
		function ___btnSalvar_OnClientClick_Action1(sender, args)
		{
			alert('Registro Salvo com Sucesso!');
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___Button4_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			ExecuteCommandRequest("Refresh","","","continue:___Button4_OnClientClick_Action2");
			args.set_cancel(true);
			return false;
		}
		function ___Button4_OnClientClick_Action2(sender, args)
		{
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___Button1_OnClientClick(sender, args)
		{
			ExecuteCommandRequest("Remove","","","continue:___Button1_OnClientClick_Action1");
			args.set_cancel(true);
			return false;
		}
		function ___Button1_OnClientClick_Action1(sender, args)
		{
			alert('Registro APAGADO!');
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___RadTextBox1_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox2_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___txtItemProcesso_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox4_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox7_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox8_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___cmbSiglaCoordenacao_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___ComboBox3_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___txtSituacao_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox12_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox11_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function DatePicker5_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox11_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox2_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function txtItemProcesso_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function cmbSiglaCoordenacao_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox3_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastro de Atividades das Ações" />
						<telerik:RadButton id="btnSalvar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnSalvar" CommandName="btnSalvar"
							OnClientClicking="___btnSalvar_OnClientClick" RenderMode="Lightweight" TabIndex="11" Text="<%$ Resources: btnSalvar %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
							OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="12" Text="<%$ Resources: Button4 %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="19" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadComboBox id="CbxSituacaoStatus" runat="server" AllowCustomText="False" AutoPostBack="False"
							CssClass="c_CbxSituacaoStatus combobox-primary" CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True"
							EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#36485B"
							LoadingMessage="<%$ Resources: CbxSituacaoStatus %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___CbxSituacaoStatus_OnItemsRequested" RenderMode="Lightweight" TabIndex="23" />
						<telerik:RadTextBox id="RadTextBox1" runat="server" AutoPostBack="False" CssClass="c_RadTextBox1"
							data-validation-engine="validate[funcCall[RadTextBox1_Validation]]" data-validation-message="Código do Projeto não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox1_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="13" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox1_wrapper" />
						<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
						<telerik:RadTextBox id="RadTextBox2" runat="server" AutoPostBack="False" CssClass="c_RadTextBox2"
							data-validation-engine="validate[funcCall[RadTextBox2_Validation]]" data-validation-message="Item do Projeto não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="5"
							onkeydown="___RadTextBox2_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="14" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox2_wrapper" />
						<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
						<telerik:RadTextBox id="txtItemProcesso" runat="server" AutoPostBack="False" CssClass="c_txtItemProcesso"
							data-validation-engine="validate[funcCall[txtItemProcesso_Validation]]" data-validation-message="itemProcesso não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="5"
							onkeydown="___txtItemProcesso_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="10" TextMode="SingleLine"
							WrapperCssClass="c_txtItemProcesso_wrapper" />
						<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
						<telerik:RadTextBox id="RadTextBox4" runat="server" AutoPostBack="False" CssClass="c_RadTextBox4"
							data-validation-engine="validate[funcCall[RadTextBox4_Validation]]" data-validation-message="Processo não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="255"
							onkeydown="___RadTextBox4_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox4_wrapper" />
						<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" Text="<%$ Resources: Label4 %>" />
						<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" Text="<%$ Resources: Label5 %>" />
						<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
						<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" Text="<%$ Resources: Label7 %>" />
						<telerik:RadLabel id="Label8" runat="server" CssClass="c_Label8" Text="<%$ Resources: Label8 %>" />
						<telerik:RadLabel id="Label9" runat="server" CssClass="c_Label9" Text="<%$ Resources: Label9 %>" />
						<telerik:RadLabel id="Label10" runat="server" CssClass="c_Label10" Text="<%$ Resources: Label10 %>" />
						<telerik:RadTextBox id="RadTextBox7" runat="server" AutoPostBack="False" CssClass="c_RadTextBox7" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="3"
							onkeydown="___RadTextBox7_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="15" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox7_wrapper" />
						<telerik:RadLabel id="Label11" runat="server" CssClass="c_Label11" Text="<%$ Resources: Label11 %>" />
						<telerik:RadTextBox id="RadTextBox8" runat="server" AutoPostBack="False" CssClass="c_RadTextBox8" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="3"
							onkeydown="___RadTextBox8_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="16" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox8_wrapper" />
						<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" Text="<%$ Resources: Label12 %>" />
						<telerik:RadLabel id="Label13" runat="server" CssClass="c_Label13" Text="<%$ Resources: Label13 %>" />
						<telerik:RadLabel id="Label14" runat="server" CssClass="c_Label14" Text="<%$ Resources: Label14 %>" />
						<telerik:RadComboBox id="cmbSiglaCoordenacao" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_cmbSiglaCoordenacao" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[cmbSiglaCoordenacao_Validation]]" data-validation-message="Coordenação não pode ser vazio!"
							enabled="false" EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300"
							ExpandAnimation-Type="None" ForeColor="#000000" LoadingMessage="<%$ Resources: cmbSiglaCoordenacao %>" MarkFirstMatch="true" MaxHeight="100"
							OnClientBlur="___cmbSiglaCoordenacao_OnBlur" OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting"
							OnClientKeyPressing="Combo_HandleKeyPress" OnClientSelectedIndexChanged="ClientRefreshCombos"
							OnItemsRequested="___cmbSiglaCoordenacao_OnItemsRequested" RenderMode="Lightweight" TabIndex="9" />
						<telerik:RadComboBox id="cmbSiglaSetorial" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_cmbSiglaSetorial"
							CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
							EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
							LoadingMessage="<%$ Resources: cmbSiglaSetorial %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___cmbSiglaSetorial_OnItemsRequested" RenderMode="Lightweight" TabIndex="6" />
						<telerik:RadComboBox id="ComboBox3" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox3" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox3_Validation]]" data-validation-message="Responsável não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox3 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox3_OnBlur"
							OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox3_OnItemsRequested" RenderMode="Lightweight" TabIndex="7" />
						<telerik:RadComboBox id="ComboBox4" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_ComboBox4"
							CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
							EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
							LoadingMessage="<%$ Resources: ComboBox4 %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox4_OnItemsRequested" RenderMode="Lightweight" TabIndex="8" />
						<telerik:RadTextBox id="txtSituacao" runat="server" AutoPostBack="False" CssClass="c_txtSituacao" enabled="false"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="20"
							onkeydown="___txtSituacao_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="20" TextMode="SingleLine"
							WrapperCssClass="c_txtSituacao_wrapper" />
						<telerik:RadLabel id="Label17" runat="server" CssClass="c_Label17" Text="<%$ Resources: Label17 %>" />
						<telerik:RadDatePicker id="txtInicioPrevisto" runat="server" CssClass="c_txtInicioPrevisto" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="2" Width="171">
						</telerik:RadDatePicker>
						<telerik:RadDatePicker id="txtTerminoPrevisto" runat="server" CssClass="c_txtTerminoPrevisto" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="3" Width="156">
						</telerik:RadDatePicker>
						<telerik:RadDatePicker id="txtInicioRealizado" runat="server" CssClass="c_txtInicioRealizado" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="4" Width="154">
						</telerik:RadDatePicker>
						<telerik:RadDatePicker id="txtTerminoRealizado" runat="server" CssClass="c_txtTerminoRealizado"
							ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
							EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight"
							ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="5" Width="153">
						</telerik:RadDatePicker>
						<telerik:RadTextBox id="RadTextBox12" runat="server" AutoPostBack="False" CssClass="c_RadTextBox12" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="6"
							onkeydown="___RadTextBox12_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="22" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox12_wrapper" />
						<telerik:RadLabel id="Label18" runat="server" CssClass="c_Label18" Text="<%$ Resources: Label18 %>" />
						<telerik:RadLabel id="LblStatusSituacao" runat="server" CssClass="c_LblStatusSituacao" Text="<%$ Resources: LblStatusSituacao %>" />
					</div>
					<div id="Div3" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div3">
						<telerik:RadDatePicker id="DatePicker5" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation" CssClass="c_DatePicker5"
							ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
							enabled="false" EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900"
							PopupDirection="BottomRight" ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="17"
							Width="147">
							<DateInput data-validation-engine="validate[funcCall[DatePicker5_Validation]]" data-validation-message="Data do Cadastro não pode ser vazio!" />
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label15" runat="server" CssClass="c_Label15" Text="<%$ Resources: Label15 %>" />
						<telerik:RadTextBox id="RadTextBox11" runat="server" AutoPostBack="False" CssClass="c_RadTextBox11"
							data-validation-engine="validate[funcCall[RadTextBox11_Validation]]" data-validation-message="Cadastrado por não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="50"
							onkeydown="___RadTextBox11_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="18" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox11_wrapper" />
						<telerik:RadLabel id="Label16" runat="server" CssClass="c_Label16" Text="<%$ Resources: Label16 %>" />
					</div>
					<div id="Div4" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div4">
						<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" EnableEmbeddedSkins="True" EnableHeaderContextMenu="False"
							EnableLinqExpressions="false" ExportFileName="GGrid" OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init"
							OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand" OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound"
							OnNeedDataSource="Grid_NeedDataSource" OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False"
							ShowGroupPanel="False" TabIndex="21" TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="projeto,itemProjeto,itemProcesso,dataLancamento,justificativa" EditMode="InPlace">
								<Columns>
									<telerik:GridEditCommandColumn Exportable="false" ButtonType="ImageButton" HeaderStyle-Width="50" ItemStyle-CssClass="Grid1_EditColumn" UniqueName="Grid1_EditColumn"/>
									<telerik:GridBoundColumn UniqueName="GridColumn1" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="projeto" DataFormatString="{0:#########0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn1" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn1 %>"
										ItemStyle-CssClass="c_GridColumn1" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="itemProjeto" DataFormatString="{0:####0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn2 %>"
										ItemStyle-CssClass="c_GridColumn2" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="5" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn3" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="itemProcesso" DataFormatString="{0:####0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn3" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn3 %>"
										ItemStyle-CssClass="c_GridColumn3" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="5" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn4" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="dataLancamento" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn4" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn4 %>" ItemStyle-CssClass="c_GridColumn4"
										ItemStyle-Width="86" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridTemplateColumn UniqueName="GridColumn5" runat="server" AllowFiltering="True" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="justificativa" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" GroupByExpression="justificativa justificativa Group By justificativa"
										HeaderStyle-CssClass="c_GridColumn5" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn5 %>" ItemStyle-CssClass="c_GridColumn5"
										ItemStyle-Width="86" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" SortExpression="justificativa">
										<EditItemTemplate>
											<telerik:RadComboBox ID="GridColumn5_ComboBox" runat="server" MarkFirstMatch="True" AllowCustomText="False" 
												 AutoPostBack="False" EnableLoadOnDemand="True" EnableVirtualScrolling="True" MaxHeight="100"
												OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" DropDownAutoWidth ="Enabled"
												OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___Grid1_GridColumn5_ComboBox_OnItemsRequested" ItemsPerRequest="15"
												Width="78" ClientIDMode="Static" />
										</EditItemTemplate>
										<ItemTemplate> 
											<asp:Label runat="server" ID="GridColumn5_Label" Text='<%#PageProvider.CadastroAtividades_Grid1Provider.GetGridComboText("GridColumn5", Eval("justificativa").ToString())%>' Value='<%#Eval("justificativa").ToString()%>'/>
										</ItemTemplate> 
									</telerik:GridTemplateColumn>
									<telerik:GridBoundColumn UniqueName="GridColumn6" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="percentualExecutado" DataFormatString="{0:##0.00}" EnableHeaderContextMenu="True"
										Exportable="True" FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn6" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn6 %>"
										ItemStyle-CssClass="c_GridColumn6" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="6" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn7" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="observacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn7" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn7 %>" ItemStyle-CssClass="c_GridColumn7" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn8" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="usuarioCadastro" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn8" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn8 %>" ItemStyle-CssClass="c_GridColumn8" ItemStyle-Width="86" MaxLength="50" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn9" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="dataCadastro" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn9" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn9 %>" ItemStyle-CssClass="c_GridColumn9"
										ItemStyle-Width="86" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridTemplateColumn Exportable="false" AllowFiltering="false"></telerik:GridTemplateColumn>
									<telerik:GridButtonColumn Exportable="false" HeaderStyle-Width="25" ConfirmText="Deseja excluir o registro?" ConfirmDialogType="RadWindow" ConfirmTitle="Deletar" ButtonType="ImageButton" CommandName="Delete" UniqueName="Grid1_DeleteColumn"/>
								</Columns>
								<EditFormSettings>
									<EditColumn ButtonType="ImageButton" />
								</EditFormSettings>
								<CommandItemSettings ShowAddNewRecordButton="True" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
							</MasterTableView>
							<PagerStyle Mode="NextPrevAndNumeric" />
							<ClientSettings EnableRowHoverStyle="true">
								<ClientEvents OnGridCreated="Grid1Created" />
							</ClientSettings>
						</telerik:RadGrid>
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox4').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function projeto() { return document.getElementById('RadTextBox1').value; }
		function itemProjeto() { return document.getElementById('RadTextBox2').value; }
		function itemProcesso() { return document.getElementById('txtItemProcesso').value; }
		function nomeProcesso() { return document.getElementById('RadTextBox4').value; }
		function DiasPrevistos() { return document.getElementById('RadTextBox7').value; }
		function DiasRealizados() { return document.getElementById('RadTextBox8').value; }
		function siglaCoordenacao() { return $find("<%= cmbSiglaCoordenacao.ClientID %>").get_value(); }
		function siglaSetorial() { return $find("<%= cmbSiglaSetorial.ClientID %>").get_value(); }
		function nomeSobrenome() { return $find("<%= ComboBox3.ClientID %>").get_value(); }
		function responsavelSubstituto() { return $find("<%= ComboBox4.ClientID %>").get_value(); }
		function situacao() { return document.getElementById('txtSituacao').value; }
		function inicioPrevisto() { return document.getElementById('txtInicioPrevisto').value; }
		function terminoPrevisto() { return document.getElementById('txtTerminoPrevisto').value; }
		function inicioRealizado() { return document.getElementById('txtInicioRealizado').value; }
		function terminoRealizado() { return document.getElementById('txtTerminoRealizado').value; }
		function percentualExecutado() { return document.getElementById('RadTextBox12').value; }
		function situacaoProjeto() { return $find("<%= CbxSituacaoStatus.ClientID %>").get_value(); }
		function dataCadastro() { return document.getElementById('DatePicker5').value; }
		function usuarioCadastro() { return document.getElementById('RadTextBox11').value; }
		function EnableButtons()
		{
				try
				{
					var __PAGESTATE = "";
					var __PAGENUMBER = 0;
					var __PAGECOUNT = 0;
					var __ISPARAMETER = "";
					var __PERMISSION = "";
					var __ALLOWINSERT = "true";
					var __ALLOWUPDATE = "true";
					var __ALLOWREMOVE = "true";
					try { __ISPARAMETER = document.getElementById("__TABLEPARAMETER").value.toLowerCase(); } catch (e) { }
					try { __PERMISSION = document.getElementById("__PERMISSION").value; } catch (e) { }
					try { __ALLOWINSERT = __PERMISSION.toString().substr(__PERMISSION.indexOf("Insert:") + 7, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Insert:")) - __PERMISSION.indexOf("Insert:") - 7).toLowerCase(); } catch (e) { }
					try { __ALLOWUPDATE = __PERMISSION.toString().substr(__PERMISSION.indexOf("Edit:") + 5, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Edit:")) - __PERMISSION.indexOf("Edit:") - 5).toLowerCase(); } catch (e) { }
					try { __ALLOWREMOVE = __PERMISSION.toString().substr(__PERMISSION.indexOf("Remove:") + 7, __PERMISSION.indexOf(";", __PERMISSION.indexOf("Remove:")) - __PERMISSION.indexOf("Remove:") - 7).toLowerCase(); } catch (e) { }
					try { __PAGESTATE = document.getElementById("__PAGESTATE").value.toLowerCase(); } catch (e) { }
					try { __PAGENUMBER = parseInt(document.getElementById("__PAGENUMBER").value); } catch (e) { }
					try { __PAGECOUNT = parseInt(document.getElementById("__PAGECOUNT").value); } catch (e) { }
						$find("btnSalvar").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"))));
						$find("Button1").set_enabled(!(IsAjaxProcessing || !(__PAGECOUNT > 0 && __ALLOWREMOVE == "true" && __ISPARAMETER == "false")));
					try
					{
						if (getParentPage() != null && getParentPage() != self)
						{
							getParentPage().EnableButtons();
						}
					}
					catch (ex)
					{
					}
				}
				catch (ex)
				{
				}
		}

		function LoadEditAuto() {
				$j("#RadTextBox1").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox2").bind("keydown", InitiateEditAuto);
				$j("#txtItemProcesso").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox4").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox7").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox8").bind("keydown", InitiateEditAuto);
				$j("#txtSituacao").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox12").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox11").bind("keydown", InitiateEditAuto);
				$j("#cmbSiglaCoordenacao").bind("change", InitiateEditAuto);
				$j("#cmbSiglaSetorial").bind("change", InitiateEditAuto);
				$j("#ComboBox3").bind("change", InitiateEditAuto);
				$j("#ComboBox4").bind("change", InitiateEditAuto);
				$j("#CbxSituacaoStatus").bind("change", InitiateEditAuto);
				$j("#txtInicioPrevisto").bind("change", InitiateEditAuto);
				$j("#txtInicioPrevisto_dateInput").bind("keydown", InitiateEditAuto);
				$j("#txtTerminoPrevisto").bind("change", InitiateEditAuto);
				$j("#txtTerminoPrevisto_dateInput").bind("keydown", InitiateEditAuto);
				$j("#txtInicioRealizado").bind("change", InitiateEditAuto);
				$j("#txtInicioRealizado_dateInput").bind("keydown", InitiateEditAuto);
				$j("#txtTerminoRealizado").bind("change", InitiateEditAuto);
				$j("#txtTerminoRealizado_dateInput").bind("keydown", InitiateEditAuto);
				$j("#DatePicker5").bind("change", InitiateEditAuto);
				$j("#DatePicker5_dateInput").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


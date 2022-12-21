<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="TB_ITENS_PROJETO.aspx.cs" Inherits="PROJETO.DataPages.TB_ITENS_PROJETO" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/TB_ITENS_PROJETO.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/TB_ITENS_PROJETO_USER.js?sv=v1.0.12_20221213161346"></script>
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

		function GetAditionalFields(senderName) 
		{
			var AditionalFields;
			switch (senderName) 
			{
				case "ComboBox1":
					AditionalFields = 
					{
						"cmbSiglaCoordenacao" : jQuery("#cmbSiglaCoordenacao")[0].control.get_value(),
					};
					break;
				case "ComboBox2":
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
					PrepareAndRequestItems(new Array("ComboBox1"));
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
		function ___Button4_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___btnSalvar_OnClientClick(sender, args)
		{
			ExecuteCommandRequest("Save","","","continue:___btnSalvar_OnClientClick_Action1");
			args.set_cancel(true);
			return false;
		}
		function ___btnSalvar_OnClientClick_Action1(sender, args)
		{
			btnSalvar_OnClientClick();
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___Button1_OnClientClick(sender, args)
		{
			Remove(sender,true);
			args.set_cancel(true);
			return false;
		}
		function ___txtItemProjeto_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox3_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___ComboBox1_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox6_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___cmbSiglaCoordenacao_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___RadTextBox8_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox1_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox9_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox10_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox13_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox7_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function txtItemProjeto_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox7_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox3_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function DatePicker4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function ComboBox1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function cmbSiglaCoordenacao_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox1_Validation(field, rules, i, options) {
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
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastro de Metas / Ações" />
						<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
							OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="18" Text="<%$ Resources: Button4 %>">
						</telerik:RadButton>
						<telerik:RadButton id="btnSalvar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnSalvar" CommandName="btnSalvar"
							OnClientClicking="___btnSalvar_OnClientClick" RenderMode="Lightweight" TabIndex="19" Text="<%$ Resources: btnSalvar %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="20" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadTextBox id="txtItemProjeto" runat="server" AutoPostBack="False" CssClass="c_txtItemProjeto"
							data-validation-engine="validate[funcCall[txtItemProjeto_Validation]]" data-validation-message="Item do Projeto não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="5"
							onkeydown="___txtItemProjeto_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="8" TextMode="SingleLine"
							WrapperCssClass="c_txtItemProjeto_wrapper" />
						<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
						<telerik:RadTextBox id="RadTextBox3" runat="server" AutoPostBack="False" CssClass="c_RadTextBox3"
							data-validation-engine="validate[funcCall[RadTextBox3_Validation]]" data-validation-message="Nome da Ação não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="255"
							onkeydown="___RadTextBox3_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="3" TextMode="MultiLine"
							WrapperCssClass="c_RadTextBox3_wrapper" />
						<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
						<telerik:RadDatePicker id="txtTerminoPrevisto" runat="server" CssClass="c_txtTerminoPrevisto" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" enabled="false" EnableEmbeddedSkins="True"
							Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="11" Width="169">
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" Text="<%$ Resources: Label5 %>" />
						<telerik:RadDatePicker id="DatePicker3" runat="server" CssClass="c_DatePicker3" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="13" Width="169">
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
						<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" Text="<%$ Resources: Label7 %>" />
						<telerik:RadLabel id="Label8" runat="server" CssClass="c_Label8" Text="<%$ Resources: Label8 %>" />
						<telerik:RadComboBox id="ComboBox1" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox1" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox1_Validation]]" data-validation-message="Nome Sobrenome não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox1 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox1_OnBlur"
							OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox1_OnItemsRequested" RenderMode="Lightweight" TabIndex="5" />
						<telerik:RadComboBox id="ComboBox2" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_ComboBox2"
							CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
							EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
							LoadingMessage="<%$ Resources: ComboBox2 %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox2_OnItemsRequested" RenderMode="Lightweight" TabIndex="6" />
						<telerik:RadTextBox id="RadTextBox6" runat="server" AutoPostBack="False" CssClass="c_RadTextBox6" EnabledStyle-HorizontalAlign="Left"
							EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" onkeydown="___RadTextBox6_onkeydown();" ReadOnly="False"
							RenderMode="Lightweight" TabIndex="7" TextMode="MultiLine" WrapperCssClass="c_RadTextBox6_wrapper" />
						<telerik:RadLabel id="Label9" runat="server" CssClass="c_Label9" Text="<%$ Resources: Label9 %>" />
						<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" Text="<%$ Resources: Label12 %>" />
						<telerik:RadLabel id="Label13" runat="server" CssClass="c_Label13" Text="<%$ Resources: Label13 %>" />
						<telerik:RadComboBox id="cmbSiglaCoordenacao" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_cmbSiglaCoordenacao" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[cmbSiglaCoordenacao_Validation]]" data-validation-message="Sigla da Coordenacao não pode ser vazio!"
							enabled="false" EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300"
							ExpandAnimation-Type="None" ForeColor="#000000" LoadingMessage="<%$ Resources: cmbSiglaCoordenacao %>" MarkFirstMatch="true" MaxHeight="100"
							OnClientBlur="___cmbSiglaCoordenacao_OnBlur" OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting"
							OnClientKeyPressing="Combo_HandleKeyPress" OnClientSelectedIndexChanged="ClientRefreshCombos"
							OnItemsRequested="___cmbSiglaCoordenacao_OnItemsRequested" RenderMode="Lightweight" TabIndex="9" />
						<telerik:RadComboBox id="ComboBox4" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_ComboBox4"
							CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
							EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
							LoadingMessage="<%$ Resources: ComboBox4 %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox4_OnItemsRequested" RenderMode="Lightweight" TabIndex="1" />
						<telerik:RadTextBox id="RadTextBox8" runat="server" AutoPostBack="False" CssClass="c_RadTextBox8" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="6"
							onkeydown="___RadTextBox8_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="21" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox8_wrapper" />
						<telerik:RadLabel id="Label14" runat="server" CssClass="c_Label14" Text="<%$ Resources: Label14 %>" />
						<telerik:RadDatePicker id="DatePicker5" runat="server" CssClass="c_DatePicker5" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" EnableEmbeddedSkins="True" Height="32"
							HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="4" Width="190">
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label15" runat="server" CssClass="c_Label15" Text="<%$ Resources: Label15 %>" />
						<telerik:RadDatePicker id="txtInicioPrevisto" runat="server" CssClass="c_txtInicioPrevisto" ClientEvents-OnDateSelected="setDatePickerFocus"
							DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date" enabled="false" EnableEmbeddedSkins="True"
							Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight" ReadOnly="False"
							RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="10" Width="179">
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label16" runat="server" CssClass="c_Label16" Text="<%$ Resources: Label16 %>" />
						<telerik:RadTextBox id="RadTextBox1" runat="server" AutoPostBack="False" CssClass="c_RadTextBox1"
							data-validation-engine="validate[funcCall[RadTextBox1_Validation]]" data-validation-message="Código do Projeto não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox1_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="17" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox1_wrapper" />
						<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
						<telerik:RadTextBox id="RadTextBox9" runat="server" AutoPostBack="False" CssClass="c_RadTextBox9" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="3"
							onkeydown="___RadTextBox9_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="12" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox9_wrapper" />
						<telerik:RadLabel id="Label17" runat="server" CssClass="c_Label17" Text="<%$ Resources: Label17 %>" />
						<telerik:RadTextBox id="RadTextBox10" runat="server" AutoPostBack="False" CssClass="c_RadTextBox10" enabled="false"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="3"
							onkeydown="___RadTextBox10_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="14" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox10_wrapper" />
						<telerik:RadLabel id="Label18" runat="server" CssClass="c_Label18" Text="<%$ Resources: Label18 %>" />
						<telerik:RadComboBox id="ComboBox5" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_ComboBox5"
							CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
							EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
							LoadingMessage="<%$ Resources: ComboBox5 %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
							OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox5_OnItemsRequested" RenderMode="Lightweight" TabIndex="2" />
						<telerik:RadLabel id="Label23" runat="server" CssClass="c_Label23" Text="<%$ Resources: Label23 %>" />
						<telerik:RadTextBox id="RadTextBox13" runat="server" AutoPostBack="False" CssClass="c_RadTextBox13" enabled="false"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="20"
							onkeydown="___RadTextBox13_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="22" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox13_wrapper" />
						<telerik:RadLabel id="Label24" runat="server" CssClass="c_Label24" Text="<%$ Resources: Label24 %>" />
					</div>
					<div id="Div3" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div3">
						<telerik:RadLabel id="Label10" runat="server" CssClass="c_Label10" Text="<%$ Resources: Label10 %>" />
						<telerik:RadTextBox id="RadTextBox7" runat="server" AutoPostBack="False" CssClass="c_RadTextBox7"
							data-validation-engine="validate[funcCall[RadTextBox7_Validation]]" data-validation-message="Cadastrado por não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="50"
							onkeydown="___RadTextBox7_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="15" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox7_wrapper" />
						<telerik:RadLabel id="Label11" runat="server" CssClass="c_Label11" Text="<%$ Resources: Label11 %>" />
						<telerik:RadDatePicker id="DatePicker4" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation" CssClass="c_DatePicker4"
							ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
							enabled="false" EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900"
							PopupDirection="BottomRight" ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="16"
							Width="170">
							<DateInput data-validation-engine="validate[funcCall[DatePicker4_Validation]]" data-validation-message="Data do Cadastro não pode ser vazio!" />
						</telerik:RadDatePicker>
					</div>
					<div id="Div4" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div4">
						<telerik:RadLabel id="Label21" runat="server" CssClass="c_Label21" Text="<%$ Resources: Label21 %>" />
						<telerik:RadLabel id="Label22" runat="server" CssClass="c_Label22" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#ComboBox4_Input').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function itemProjeto() { return document.getElementById('txtItemProjeto').value; }
		function nomeAcao() { return document.getElementById('RadTextBox3').value; }
		function terminoPrevisto() { return document.getElementById('txtTerminoPrevisto').value; }
		function terminoRealizado() { return document.getElementById('DatePicker3').value; }
		function nomeSobrenome() { return $find("<%= ComboBox1.ClientID %>").get_value(); }
		function responsavelSubstituto() { return $find("<%= ComboBox2.ClientID %>").get_value(); }
		function observacao() { return document.getElementById('RadTextBox6').value; }
		function siglaCoordenacao() { return $find("<%= cmbSiglaCoordenacao.ClientID %>").get_value(); }
		function siglaSetorial() { return $find("<%= ComboBox4.ClientID %>").get_value(); }
		function percentualExecutado() { return document.getElementById('RadTextBox8').value; }
		function inicioRealizado() { return document.getElementById('DatePicker5').value; }
		function inicioPrevisto() { return document.getElementById('txtInicioPrevisto').value; }
		function projeto() { return document.getElementById('RadTextBox1').value; }
		function DiasPrevistos() { return document.getElementById('RadTextBox9').value; }
		function DiasRealizados() { return document.getElementById('RadTextBox10').value; }
		function statusAcao() { return $find("<%= ComboBox5.ClientID %>").get_value(); }
		function situacao() { return document.getElementById('RadTextBox13').value; }
		function usuarioCadastro() { return document.getElementById('RadTextBox7').value; }
		function dataCadastro() { return document.getElementById('DatePicker4').value; }
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
				$j("#txtItemProjeto").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox3").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox6").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox8").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox1").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox9").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox10").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox13").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox7").bind("keydown", InitiateEditAuto);
				$j("#ComboBox1").bind("change", InitiateEditAuto);
				$j("#ComboBox2").bind("change", InitiateEditAuto);
				$j("#cmbSiglaCoordenacao").bind("change", InitiateEditAuto);
				$j("#ComboBox4").bind("change", InitiateEditAuto);
				$j("#ComboBox5").bind("change", InitiateEditAuto);
				$j("#txtTerminoPrevisto").bind("change", InitiateEditAuto);
				$j("#txtTerminoPrevisto_dateInput").bind("keydown", InitiateEditAuto);
				$j("#DatePicker3").bind("change", InitiateEditAuto);
				$j("#DatePicker3_dateInput").bind("keydown", InitiateEditAuto);
				$j("#DatePicker5").bind("change", InitiateEditAuto);
				$j("#DatePicker5_dateInput").bind("keydown", InitiateEditAuto);
				$j("#txtInicioPrevisto").bind("change", InitiateEditAuto);
				$j("#txtInicioPrevisto_dateInput").bind("keydown", InitiateEditAuto);
				$j("#DatePicker4").bind("change", InitiateEditAuto);
				$j("#DatePicker4_dateInput").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


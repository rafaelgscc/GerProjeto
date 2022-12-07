<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="CadastroCoordenacoesSetoriais.aspx.cs" Inherits="PROJETO.DataPages.CadastroCoordenacoesSetoriais" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/CadastroCoordenacoesSetoriais.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/RadComboBoxHelper.js"></script>
		<script type="text/javascript" src="../JS/CadastroCoordenacoesSetoriais_USER.js?sv=v1.0.11_20221207165304"></script>
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
		function ___Button2_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___Button3_OnClientClick(sender, args)
		{
			Save(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button1_OnClientClick(sender, args)
		{
			Remove(sender,true);
			args.set_cancel(true);
			return false;
		}
		function ___RadTextBox1_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox4_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox5_onkeydown(event,vgWin)
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
		function ___RadTextBox6_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function DatePicker1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox6_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox5_Validation(field, rules, i, options) {
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
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastro de Setoriais" />
						<telerik:RadButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2" CommandName="Button2"
							OnClientClicking="___Button2_OnClientClick" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: Button2 %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3" CommandName="Button3"
							OnClientClicking="___Button3_OnClientClick" RenderMode="Lightweight" TabIndex="9" Text="<%$ Resources: Button3 %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="10" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<telerik:RadTextBox id="RadTextBox1" runat="server" AutoPostBack="False" CssClass="c_RadTextBox1" enabled="false"
						EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
						onkeydown="___RadTextBox1_onkeydown();" ReadOnly="True" RenderMode="Lightweight" TextMode="SingleLine" WrapperCssClass="c_RadTextBox1_wrapper" />
					<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
						<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
						<telerik:RadTextBox id="RadTextBox4" runat="server" AutoPostBack="False" CssClass="c_RadTextBox4"
							data-validation-engine="validate[funcCall[RadTextBox4_Validation]]" data-validation-message="Sigla do Setor não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox4_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="3" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox4_wrapper" />
						<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" Text="<%$ Resources: Label4 %>" />
						<telerik:RadTextBox id="RadTextBox5" runat="server" AutoPostBack="False" CssClass="c_RadTextBox5"
							data-validation-engine="validate[funcCall[RadTextBox5_Validation]]" data-validation-message="Nome do Setor não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="100"
							onkeydown="___RadTextBox5_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="4" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox5_wrapper" />
						<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" Text="<%$ Resources: Label5 %>" />
						<telerik:RadComboBox id="ComboBox1" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox1" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox1_Validation]]" data-validation-message="Sigla da Diretoria não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox1 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox1_OnBlur"
							OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox1_OnItemsRequested" RenderMode="Lightweight" TabIndex="1" />
						<telerik:RadComboBox id="ComboBox2" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
							CssClass="c_ComboBox2" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
							data-validation-engine="validate[funcCall[ComboBox2_Validation]]" data-validation-message="Sigla da Coordenacao não pode ser vazio!"
							EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
							ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox2 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox2_OnBlur"
							OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
							OnItemsRequested="___ComboBox2_OnItemsRequested" RenderMode="Lightweight" TabIndex="2" />
					</div>
					<div id="Div3" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div3">
						<telerik:RadDatePicker id="DatePicker1" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation" CssClass="c_DatePicker1"
							ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
							enabled="false" EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900"
							PopupDirection="BottomRight" ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="6"
							Width="168">
							<DateInput data-validation-engine="validate[funcCall[DatePicker1_Validation]]" data-validation-message="Data do Cadastro não pode ser vazio!" />
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" Text="<%$ Resources: Label7 %>" />
						<telerik:RadTextBox id="RadTextBox6" runat="server" AutoPostBack="False" CssClass="c_RadTextBox6"
							data-validation-engine="validate[funcCall[RadTextBox6_Validation]]" data-validation-message="Cadastrado por não pode ser vazio!"
							enabled="false" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="50"
							onkeydown="___RadTextBox6_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="5" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox6_wrapper" />
						<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#ComboBox1_Input').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function codigo() { return document.getElementById('RadTextBox1').value; }
		function siglaSetorial() { return document.getElementById('RadTextBox4').value; }
		function nomeSetorial() { return document.getElementById('RadTextBox5').value; }
		function siglaDiretoria() { return $find("<%= ComboBox1.ClientID %>").get_value(); }
		function siglaCoordenacao() { return $find("<%= ComboBox2.ClientID %>").get_value(); }
		function dataCadastro() { return document.getElementById('DatePicker1').value; }
		function usuarioCadastro() { return document.getElementById('RadTextBox6').value; }
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
						$find("Button3").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"))));
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
				$j("#RadTextBox4").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox5").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox6").bind("keydown", InitiateEditAuto);
				$j("#ComboBox1").bind("change", InitiateEditAuto);
				$j("#ComboBox2").bind("change", InitiateEditAuto);
				$j("#DatePicker1").bind("change", InitiateEditAuto);
				$j("#DatePicker1_dateInput").bind("keydown", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


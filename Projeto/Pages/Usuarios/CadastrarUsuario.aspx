<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="CadastrarUsuario.aspx.cs" Inherits="PROJETO.DataPages.CadastrarUsuario" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: FormCadastrarUsuario %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/CadastrarUsuario.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="../../Styles/validationEngine.jquery.css" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="../../Styles/animate.min.css" type="text/css" media="screen" title="no title"/>
		<link rel="stylesheet" href="../../Styles/all.min.css" type="text/css" media="screen" title="no title"/>  	
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="FormCadastrarUsuario_body" style="margin-left:auto;margin-right:auto;">
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
		<script type="text/javascript" src="../../JS/CadastrarUsuario_USER.js?sv=v1.0.12_20221213161348"></script>
		<script type="text/javascript" src="../../JS/jquery.validationEngine-pt_BR.js"></script>
		<script type="text/javascript" src="../../JS/jquery.validationEngine.js"></script>
		<script type="text/javascript" src="../../JS/validation.js"></script>

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
		function ___FormCadastrarUsuario_OnResponseEnd(sender, args)
		{
			OnResponseEnd(sender,args);
		}
		function ___FormCadastrarUsuario_OnRequestStart(sender, args)
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
		function ___RadTextBox2_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox3_onkeydown(event,vgWin)
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
		function ___RadTextBox6_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox6_OnBlur()
		{
			OnMaskBlur();
		}
		function ___RadTextBox7_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___ComboBox2_OnBlur(sender)
		{
			ValidateCombo(sender);
		}
		function ___btnNovo_OnClientClick(sender, args)
		{
			New(this);
			args.set_cancel(true);
			return false;
		}
		function ___btnSalvar_OnClientClick(sender, args)
		{
			Save(this);
			args.set_cancel(true);
			return false;
		}
		function ___btnCancelar_OnClientClick(sender, args)
		{
			Cancel(this);
			args.set_cancel(true);
			return false;
		}
		function ___btnExcluir_OnClientClick(sender, args)
		{
			Remove(sender,true);
			args.set_cancel(true);
			return false;
		}
		function ___WindowSettings1_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WindowSettings1_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WindowSettings1_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function RadTextBox2_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox3_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox7_Validation(field, rules, i, options) {
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
		
		<form id="FormCadastrarUsuario" runat="server" class="c_FormCadastrarUsuario">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___FormCadastrarUsuario_OnRequestStart" ClientEvents-OnResponseEnd="___FormCadastrarUsuario_OnResponseEnd" LoadingPanelID="___FormCadastrarUsuario_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<telerik:RadWindowManager id="WindowSettings1" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WindowSettings1"
						DestroyOnClose="True" EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False"
						OnClientClose="___WindowSettings1_OnClientClose" OnClientPageLoad="___WindowSettings1_OnClientPageLoad"
						OnClientShow="___WindowSettings1_OnClientShow" PreserveClientState="True" RenderMode="Classic" RestrictionZoneID="__MainDiv"
						ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="True" VisibleTitlebar="True" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
							OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="7" Text="<%$ Resources: Button4 %>">
						</telerik:RadButton>
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Cadastrar Usuário" />
					</div>
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<div id="Div3" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div3">
							<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
							<telerik:RadTextBox id="RadTextBox2" runat="server" AutoPostBack="False" CssClass="c_RadTextBox2"
								data-validation-engine="validate[funcCall[RadTextBox2_Validation]]" data-validation-message="Login não pode ser vazio!"
								EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="40"
								onkeydown="___RadTextBox2_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
								WrapperCssClass="c_RadTextBox2_wrapper" />
							<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
							<telerik:RadTextBox id="RadTextBox3" runat="server" AutoPostBack="False" CssClass="c_RadTextBox3"
								data-validation-engine="validate[funcCall[RadTextBox3_Validation]]" data-validation-message="Senha não pode ser vazio!"
								EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="40"
								onkeydown="___RadTextBox3_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="2" TextMode="Password"
								WrapperCssClass="c_RadTextBox3_wrapper" />
							<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
							<telerik:RadTextBox id="RadTextBox4" runat="server" AutoPostBack="False" CssClass="c_RadTextBox4"
								data-validation-engine="validate[funcCall[RadTextBox4_Validation]]" data-validation-message="Nome do usuário não pode ser vazio!"
								EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="60"
								onkeydown="___RadTextBox4_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="3" TextMode="SingleLine"
								WrapperCssClass="c_RadTextBox4_wrapper" />
							<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" Text="<%$ Resources: Label4 %>" />
							<telerik:RadTextBox id="RadTextBox5" runat="server" AutoPostBack="False" CssClass="c_RadTextBox5" EnabledStyle-HorizontalAlign="Left"
								EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="60" onkeydown="___RadTextBox5_onkeydown();" ReadOnly="False"
								RenderMode="Lightweight" TabIndex="4" TextMode="SingleLine" WrapperCssClass="c_RadTextBox5_wrapper" />
							<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" Text="<%$ Resources: Label5 %>" />
							<telerik:RadTextBox id="RadTextBox6" runat="server" AutoPostBack="False" CssClass="c_RadTextBox6" EnabledStyle-HorizontalAlign="Left"
								EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="15" onblur="___RadTextBox6_OnBlur();" onkeydown="___RadTextBox6_onkeydown();"
								ReadOnly="False" RenderMode="Lightweight" Skin="Default" TabIndex="5" TextMode="SingleLine" WrapperCssClass="c_RadTextBox6_wrapper" />
							<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" Text="<%$ Resources: Label6 %>" />
							<telerik:RadTextBox id="RadTextBox7" runat="server" AutoPostBack="False" CssClass="c_RadTextBox7"
								data-validation-engine="validate[funcCall[RadTextBox7_Validation]]" data-validation-message="Observações não pode ser vazio!"
								EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0"
								onkeydown="___RadTextBox7_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="6" TextMode="MultiLine"
								WrapperCssClass="c_RadTextBox7_wrapper" />
							<telerik:RadLabel id="Label8" runat="server" CssClass="c_Label8" Text="<%$ Resources: Label8 %>" />
							<telerik:RadComboBox id="ComboBox2" runat="server" disable-data-validation-onblur AllowCustomText="False" AutoPostBack="False"
								CssClass="c_ComboBox2" CollapseAnimation-Duration="300" CollapseAnimation-Type="None"
								data-validation-engine="validate[funcCall[ComboBox2_Validation]]" data-validation-message="Nome do grupo não pode ser vazio!"
								EnableEmbeddedSkins="True" EnableLoadOnDemand="True" EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None"
								ForeColor="#000000" LoadingMessage="<%$ Resources: ComboBox2 %>" MarkFirstMatch="true" MaxHeight="100" OnClientBlur="___ComboBox2_OnBlur"
								OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
								OnItemsRequested="___ComboBox2_OnItemsRequested" RenderMode="Lightweight" TabIndex="14" />
							<telerik:RadComboBox id="ComboBox3" runat="server" AllowCustomText="False" AutoPostBack="False" CssClass="c_ComboBox3"
								CollapseAnimation-Duration="300" CollapseAnimation-Type="None" EnableEmbeddedSkins="True" EnableLoadOnDemand="True"
								EnableVirtualScrolling="True" ExpandAnimation-Duration="300" ExpandAnimation-Type="None" ForeColor="#000000"
								LoadingMessage="<%$ Resources: ComboBox3 %>" MarkFirstMatch="true" MaxHeight="100" OnClientItemsRequested="CheckComboItems"
								OnClientItemsRequesting="Combo_OnClientItemsRequesting" OnClientKeyPressing="Combo_HandleKeyPress"
								OnItemsRequested="___ComboBox3_OnItemsRequested" RenderMode="Lightweight" TabIndex="15" />
							<telerik:RadLabel id="Label9" runat="server" CssClass="c_Label9" Text="<%$ Resources: Label9 %>" />
						</div>
						<telerik:RadButton id="btnNovo" runat="server" ButtonType="SkinnedButton" CssClass="c_btnNovo" CommandName="btnNovo"
							OnClientClicking="___btnNovo_OnClientClick" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: btnNovo %>">
						</telerik:RadButton>
						<telerik:RadButton id="btnSalvar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnSalvar" CommandName="btnSalvar"
							OnClientClicking="___btnSalvar_OnClientClick" RenderMode="Lightweight" TabIndex="9" Text="<%$ Resources: btnSalvar %>">
						</telerik:RadButton>
						<telerik:RadButton id="btnCancelar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnCancelar" CommandName="btnCancelar"
							OnClientClicking="___btnCancelar_OnClientClick" RenderMode="Lightweight" TabIndex="10" Text="<%$ Resources: btnCancelar %>">
						</telerik:RadButton>
						<telerik:RadButton id="btnExcluir" runat="server" ButtonType="SkinnedButton" CssClass="c_btnExcluir" CommandName="btnExcluir"
							OnClientClicking="___btnExcluir_OnClientClick" RenderMode="Lightweight" TabIndex="11" Text="<%$ Resources: btnExcluir %>">
						</telerik:RadButton>
						<telerik:RadButton id="btnPesquisar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnPesquisar" CommandName="btnPesquisar"
							OnClick="___btnPesquisar_OnClick" RenderMode="Lightweight" TabIndex="12" Text="<%$ Resources: btnPesquisar %>">
						</telerik:RadButton>
						<telerik:RadButton id="btnFiltrar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnFiltrar" CommandName="btnFiltrar"
							RenderMode="Lightweight" TabIndex="13" Text="<%$ Resources: btnFiltrar %>">
						</telerik:RadButton>
					</div>
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
				</div>
			<telerik:RadAjaxLoadingPanel ID="___FormCadastrarUsuario_AjaxLoading" runat="server">
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox2').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function LOGIN_USER_LOGIN() { return document.getElementById('RadTextBox2').value; }
		function LOGIN_USER_PASSWORD() { return document.getElementById('RadTextBox3').value; }
		function LOGIN_USER_NAME() { return document.getElementById('RadTextBox4').value; }
		function LOGIN_USER_EMAIL() { return document.getElementById('RadTextBox5').value; }
		function LOGIN_USER_PHONE() { return document.getElementById('RadTextBox6').value; }
		function LOGIN_USER_OBS() { return document.getElementById('RadTextBox7').value; }
		function LOGIN_GROUP_NAME() { return $find("<%= ComboBox2.ClientID %>").get_value(); }
		function LOGIN_USER_COORDENACAO() { return $find("<%= ComboBox3.ClientID %>").get_value(); }
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
						$find("btnNovo").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE == "navigation" && __ALLOWINSERT == "true" && __ISPARAMETER == "false")));
						$find("btnSalvar").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE != "" && __PAGESTATE != "navigation" && (__ALLOWINSERT == "true" || __ALLOWUPDATE == "true"))));
						$find("btnCancelar").set_enabled(!(IsAjaxProcessing || !(__PAGESTATE != "" && __PAGESTATE != "navigation")));
						$find("btnExcluir").set_enabled(!(IsAjaxProcessing || !(__PAGECOUNT > 0 && __ALLOWREMOVE == "true" && __ISPARAMETER == "false")));
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
				$j("#RadTextBox2").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox3").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox4").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox5").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox6").bind("keydown", InitiateEditAuto);
				$j("#RadTextBox7").bind("keydown", InitiateEditAuto);
				$j("#ComboBox2").bind("change", InitiateEditAuto);
				$j("#ComboBox3").bind("change", InitiateEditAuto);
		}
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


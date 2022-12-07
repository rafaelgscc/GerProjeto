<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="True" ValidateRequest="false" CodeFile="StartPage.aspx.cs" Inherits="PROJETO.StartPage" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>


	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/StartPage.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
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
		
		<script type="text/javascript" src="../JS/Common.js"></script>
		<script type="text/javascript" src="../JS/Functions.js"></script>

		<script src='../JS/Mask.js' type="text/javascript"></script>
			<script type="text/javascript" src="../JS/StartPage_USER.js?sv=v1.0.11_20221207165305"></script>
		<script type="text/javascript">
			function OnLoginSucceded()
			{
				 ___Form1_OnLoginSucceded();
			}
			function TryLogin(PageToRedirect, RefreshControlsID)
			{
				document.forms[0].RefreshControlsIDHidden.value = RefreshControlsID;
				document.forms[0].PageToRedirectHidden.value = PageToRedirect;
			}
			currentPath = "<%= Page.Request.Path %>";
		</script>
	</telerik:RadCodeBlock>
		
	<script type="text/javascript">
		function ___Form1_OnLoginSucceded()
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Home.aspx") %>';
			Navigate(UrlPage, false);
			return false;
		}
		function ___txtLoginUser_onkeydown(event,vgWin)
		{
		}
		function ___txtLoginPassword_onkeydown(event,vgWin)
		{
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
		}
	</script>
		<form id="Form1" runat="server" class="c_Form1">
		<input type="hidden" name="PageToRedirectHidden" value="" />
		<input type="hidden" name="RefreshControlsIDHidden" value="" />
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
				<telerik:RadAjaxPanel id="ajxMainAjaxPanel" runat="server" CssClass="c_ajxMainAjaxPanel" LoadingPanelID="___ajxMainAjaxPanel_AjaxLoading">
					<telerik:RadWindowManager id="WindowSettings1" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WindowSettings1"
						DestroyOnClose="True" EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False"
						OnClientClose="___WindowSettings1_OnClientClose" OnClientPageLoad="___WindowSettings1_OnClientPageLoad"
						OnClientShow="___WindowSettings1_OnClientShow" PreserveClientState="True" RenderMode="Classic" RestrictionZoneID="__MainDiv"
						ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="False" VisibleTitlebar="False" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadTextBox id="txtLoginUser" runat="server" AutoPostBack="False" CssClass="c_txtLoginUser" EmptyMessageStyle-ForeColor="#828282"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0"
							placeholder="<%$ Resources: txtLoginUser %>" ReadOnly="False" RenderMode="Classic" TabIndex="1" TextMode="SingleLine"
							WrapperCssClass="c_txtLoginUser_wrapper" />
						<telerik:RadButton id="butDoLogin" runat="server" ButtonType="SkinnedButton" CssClass="c_butDoLogin" CommandName="butDoLogin"
							OnClick="___butDoLogin_OnClick" RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: butDoLogin %>">
						</telerik:RadButton>
						<telerik:RadTextBox id="txtLoginPassword" runat="server" AutoPostBack="False" CssClass="c_txtLoginPassword"
							EmptyMessageStyle-ForeColor="#828282" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0"
							placeholder="<%$ Resources: txtLoginPassword %>" ReadOnly="False" RenderMode="Classic" TabIndex="2" TextMode="Password"
							WrapperCssClass="c_txtLoginPassword_wrapper" />
						<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
						<asp:Image id="Image1" runat="server" class="c_Image1" ImageUrl="../Images/Projetos/checklist-g0a6759856_640.png" />
						<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
					</div>
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadLabel id="ProjectVersion" runat="server" CssClass="c_ProjectVersion" Text="v1.0.11" />
						<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
						<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
						<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" Text="<%$ Resources: Label4 %>" />
						<telerik:RadLabel id="DeveloperName" runat="server" CssClass="c_DeveloperName" Text="Rafael Gomes da Silva" />
					</div>
					<telerik:RadAjaxLoadingPanel ID="___ajxMainAjaxPanel_AjaxLoading" runat="server">
					</telerik:RadAjaxLoadingPanel>
				</telerik:RadAjaxPanel>
			</div>
		</form>
		
</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
<script type="text/javascript">
	ShowClientFormulas();

	function ShowClientFormulas()
	{
	}
	var $j = jQuery.noConflict();
	$j(document).ready(SetFocusFirstField());
	function SetFocusFirstField()
	{
		try
		{
			{
				window.focus();
				setTimeout("var $j = jQuery.noConflict();$j('#txtLoginUser').first().focus();", 200);
			}
		}
		catch (e)
		{
		}
	}

</script>
</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

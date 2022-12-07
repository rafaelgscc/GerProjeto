<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="True" ValidateRequest="false" CodeFile="AboutPage.aspx.cs" Inherits="PROJETO.AboutPage" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>


	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/AboutPage.css" OrderIndex="2"/>
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
			<script type="text/javascript" src="../JS/AboutPage_USER.js?sv=v1.0.11_20221207165306"></script>
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
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
				<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
					<div id="Div4" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div4">
						<telerik:RadLabel id="labSolutionTitle" runat="server" CssClass="c_labSolutionTitle" Text="GerProjeto" />
						<telerik:RadLabel id="ProjectVersion" runat="server" CssClass="c_ProjectVersion" Text="v1.0.11" />
					</div>
					<asp:Panel id="Panel1" runat="server" BorderStyle="Solid" BorderWidth="1" class="c_Panel1" ScrollBars="Auto">
						<telerik:RadLabel id="labProjectTitle" runat="server" CssClass="c_labProjectTitle" Text="GerProjeto - Gerenciamento de Atividades" />
						<telerik:RadLabel id="CompanyName" runat="server" CssClass="c_CompanyName" Text="DNIT - Departamento Nacional de Infraestrutura de Transporte"
							/>
						<telerik:RadLabel id="DeveloperName" runat="server" CssClass="c_DeveloperName" Text="Rafael Gomes da Silva" />
					</asp:Panel>
					<telerik:RadLabel id="ProjectCopyright" runat="server" CssClass="c_ProjectCopyright" Text="Todos os direitos reservados" />
				</div>
			</div>
		</form>
		
</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
<script type="text/javascript">
	ShowClientFormulas();

	function ShowClientFormulas()
	{
	}

</script>
</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

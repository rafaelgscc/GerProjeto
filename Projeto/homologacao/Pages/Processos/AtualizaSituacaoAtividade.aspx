<%@ Page Language="C#" AutoEventWireup="true" CodeFile="AtualizaSituacaoAtividade.aspx.cs" EnableEventValidation="True" Inherits="PROJETO.DataPages.AtualizaSituacaoAtividade" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/AtualizaSituacaoAtividade.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">

	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		<script type="text/javascript" src="../../JS/jquery.js" ></script>
		<script type="text/javascript" src="../../JS/iframeResizer.min.js" ></script>
		<script type="text/javascript" src="../../JS/iframeResizer.contentWindow.min.js" ></script>
		<script type="text/javascript" src="../../JS/Mask.js" ></script>
		<script type="text/javascript" src="../../JS/Functions.js"></script>
		<script type="text/javascript" src="../../JS/Common.js"></script>
	<script type="text/javascript" src="../../JS/AtualizaSituacaoAtividade_USER.js?sv=v1.0.11_20221207155647"></script>

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
	function Navigate(Url, isWindow)
	{
		try
		{
			if(isWindow)
			{
				Gasopen(Url);
			}
			else
			{
				document.location.href = Url;
			}
		}
		catch(ex)
		{
		}
	}
	try
	{
		if(getParentPage() != self)
		{
			getParentPage().EnableButtons();
		}
	}
	catch (e)
	{
	}
</script>

	</telerik:RadCodeBlock>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
			</div>
		</form>
</body>
<telerik:RadCodeBlock ID="EndCodeBlock" runat="server">
</telerik:RadCodeBlock>
</html>

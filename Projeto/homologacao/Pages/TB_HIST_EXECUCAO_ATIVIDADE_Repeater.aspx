<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="TB_HIST_EXECUCAO_ATIVIDADE_Repeater.aspx.cs" Inherits="PROJETO.DataPages.TB_HIST_EXECUCAO_ATIVIDADE_Repeater" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<meta name="viewport" content="width=device-width, initial-scale=1.0, maximum-scale=1.0, user-scalable=0" />
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Web_Blue_Div_div_raised_surface.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/TB_HIST_EXECUCAO_ATIVIDADE_Repeater.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
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
		<script type="text/javascript" src="../JS/TB_HIST_EXECUCAO_ATIVIDADE_Repeater_USER.js?sv=v1.0.12_20221213161345"></script>

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
    <script type="text/javascript">
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
		function ___btnFechar_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Relação de Execução da Atividade" />
						<telerik:RadButton id="btnFechar" runat="server" ButtonType="SkinnedButton" CssClass="c_btnFechar" CommandName="btnFechar"
							OnClientClicking="___btnFechar_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: btnFechar %>">
						</telerik:RadButton>
					</div>
					<div runat="server"  style="position:absolute !important;left:20px;top:68px;width:925px;height:351px;background-color:#FFFFFF;border-color:#DBD6D6;border-style:Solid;border-width:1px;overflow:auto" AutoExpandToContent="False" AutoExpandToContentMargin="0" EquateRepeaterRegionsWidth="True">
						<asp:Repeater id="Repeater1" runat="server" ClientIDMode="Static">
							<HeaderTemplate>
								<div id="GRepeaterHeader1" runat="server" AutoExpandWidth="True" class="c_GRepeaterHeader1">
									<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" ClientIDMode="Static" Text="<%$ Resources: Label2 %>" />
									<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" ClientIDMode="Static" Text="<%$ Resources: Label5 %>" />
									<telerik:RadLabel id="Label8" runat="server" CssClass="c_Label8" ClientIDMode="Static" Text="<%$ Resources: Label8 %>" />
									<telerik:RadLabel id="Label11" runat="server" CssClass="c_Label11" ClientIDMode="Static" Text="<%$ Resources: Label11 %>" />
									<telerik:RadLabel id="Label14" runat="server" CssClass="c_Label14" ClientIDMode="Static" Text="<%$ Resources: Label14 %>" />
									<telerik:RadLabel id="Label17" runat="server" CssClass="c_Label17" ClientIDMode="Static" Text="<%$ Resources: Label17 %>" />
									<telerik:RadLabel id="Label20" runat="server" CssClass="c_Label20" ClientIDMode="Static" Text="<%$ Resources: Label20 %>" />
									<telerik:RadLabel id="Label23" runat="server" CssClass="c_Label23" ClientIDMode="Static" Text="<%$ Resources: Label23 %>" />
								</div>
							</HeaderTemplate>
							<ItemTemplate>
								<div id="GRepeaterBody1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" AutoExpandWidth="True"
									class="c_GRepeaterBody1">
									<div id="GRepeaterBody1ChildLocator" runat="server" clientidmode="AutoID"></div>
									<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" ClientIDMode="Static" Text="<%$ Resources: Label3 %>" />
									<telerik:RadLabel id="Label6" runat="server" CssClass="c_Label6" ClientIDMode="Static" Text="<%$ Resources: Label6 %>" />
									<telerik:RadLabel id="Label9" runat="server" CssClass="c_Label9" ClientIDMode="Static" Text="<%$ Resources: Label9 %>" />
									<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" ClientIDMode="Static" Text="<%$ Resources: Label12 %>" />
									<telerik:RadLabel id="Label15" runat="server" CssClass="c_Label15" ClientIDMode="Static" Text="<%$ Resources: Label15 %>" />
									<telerik:RadLabel id="Label18" runat="server" CssClass="c_Label18" ClientIDMode="Static" Text="<%$ Resources: Label18 %>" />
									<telerik:RadLabel id="Label21" runat="server" CssClass="c_Label21" ClientIDMode="Static" Text="<%$ Resources: Label21 %>" />
									<telerik:RadLabel id="Label24" runat="server" CssClass="c_Label24" ClientIDMode="Static" Text="<%$ Resources: Label24 %>" />
								</div>
							</ItemTemplate>
							<AlternatingItemTemplate>
								<div id="GRepeaterBodyAlt1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" AutoExpandWidth="True"
									class="c_GRepeaterBodyAlt1">
									<div id="GRepeaterBodyAlt1ChildLocator" runat="server" clientidmode="AutoID"></div>
									<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" ClientIDMode="Static" Text="<%$ Resources: Label4 %>" />
									<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" ClientIDMode="Static" Text="<%$ Resources: Label7 %>" />
									<telerik:RadLabel id="Label10" runat="server" CssClass="c_Label10" ClientIDMode="Static" Text="<%$ Resources: Label10 %>" />
									<telerik:RadLabel id="Label13" runat="server" CssClass="c_Label13" ClientIDMode="Static" Text="<%$ Resources: Label13 %>" />
									<telerik:RadLabel id="Label16" runat="server" CssClass="c_Label16" ClientIDMode="Static" Text="<%$ Resources: Label16 %>" />
									<telerik:RadLabel id="Label19" runat="server" CssClass="c_Label19" ClientIDMode="Static" Text="<%$ Resources: Label19 %>" />
									<telerik:RadLabel id="Label22" runat="server" CssClass="c_Label22" ClientIDMode="Static" Text="<%$ Resources: Label22 %>" />
									<telerik:RadLabel id="Label25" runat="server" CssClass="c_Label25" ClientIDMode="Static" Text="<%$ Resources: Label25 %>" />
								</div>
							</AlternatingItemTemplate>
						</asp:Repeater>
					</div>
					<asp:Panel id="Pager1" runat="server" class="c_Pager1" HorizontalAlign="Left">
						<asp:Button id="__Pager1__Button1" runat="server" CommandName="Button1" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button2" runat="server" CommandName="Button2" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button3" runat="server" CommandName="Button3" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button4" runat="server" CommandName="Button4" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button5" runat="server" CommandName="Button5" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button6" runat="server" CommandName="Button6" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button7" runat="server" CommandName="Button7" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button8" runat="server" CommandName="Button8" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
						<asp:Button id="__Pager1__Button9" runat="server" CommandName="Button9" ForeColor="#000000" OnClick="__Pager1__Click"
							style="margin-left:0px;cursor:Inherit;position:relative;top:5px;width:30px;height:20px;background-color:#FFFFFF;border-color:#000000;border-width:1px"/>
					</asp:Panel>
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2 div-raised-surface">
						<telerik:RadLabel id="Label26" runat="server" CssClass="c_Label26" Text="<%$ Resources: Label26 %>" />
						<telerik:RadLabel id="Label27" runat="server" CssClass="c_Label27" Text="<%$ Resources: Label27 %>" />
						<telerik:RadLabel id="Label28" runat="server" CssClass="c_Label28" Text="<%$ Resources: Label28 %>" />
						<telerik:RadLabel id="Label29" runat="server" CssClass="c_Label29" Text="<%$ Resources: Label29 %>" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#btnFechar').first().focus();", 200);
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


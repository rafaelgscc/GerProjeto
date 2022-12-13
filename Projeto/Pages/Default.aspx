<%@ Page Language="C#" AutoEventWireup="true" EnableEventValidation="True" ValidateRequest="false" CodeFile="Default.aspx.cs" Inherits="PROJETO.Default" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>


	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Default.css" OrderIndex="2"/>
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
			<script type="text/javascript" src="../JS/Default_USER.js?sv=v1.0.11_20221213104559"></script>
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
		function ___MenuItem15_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/Access.aspx") %>';
			document.getElementById('IFrame1').src = UrlPage;
		}
		function ___MenuItem16_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("") %>';
			document.getElementById('IFrame1').src = UrlPage;
		}
		function ___MenuItem17_OnClick(sender, args)
		{
			localStorage.removeItem('SSI_F'); localStorage.removeItem('SSI_T'); Logoff();
		}
		function ___MenuItem18_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).New(this);
		}
		function ___MenuItem19_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Save(this);
		}
		function ___MenuItem20_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Cancel(this);
		}
		function ___MenuItem21_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Remove(sender,true);
		}
		function ___MenuItem22_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).First(this);
		}
		function ___MenuItem23_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Previous(this);
		}
		function ___MenuItem24_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Next(this);
		}
		function ___MenuItem25_OnClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Last(this);
		}
		function ___MenuItem26_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("") %>';
			document.getElementById('IFrame1').src = UrlPage;
		}
		function ___MenuItem27_OnClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/AboutPage.aspx") %>';
			document.getElementById('IFrame1').src = UrlPage;
		}
		function ___Button1_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).New(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button2_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Save(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button3_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Cancel(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button4_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Remove(sender,true);
			args.set_cancel(true);
			return false;
		}
		function ___Button5_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).First(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button6_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Previous(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button7_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Next(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button8_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Last(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button9_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Filter();
			args.set_cancel(true);
			return false;
		}
		function ___Button10_OnClientClick(sender, args)
		{
			GetTargetWindow(document.getElementById('IFrame1')).Edit(this);
			args.set_cancel(true);
			return false;
		}
		function ___Button11_OnClientClick(sender, args)
		{
			localStorage.removeItem('SSI_F'); localStorage.removeItem('SSI_T'); Logoff();
			args.set_cancel(true);
			return false;
		}
	</script>
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="ToParent">
				<telerik:RadAjaxPanel id="ajxMainAjaxPanel" runat="server" CssClass="c_ajxMainAjaxPanel" LoadingPanelID="___ajxMainAjaxPanel_AjaxLoading">
					<div style="position:absolute !important;left:100px;top:63px;width:770px;height:689px" id="ParentDiv_IFrame1">
						<iframe id="IFrame1" runat="server" AllowTransparency="True" AutoExpandToContent="True" class="c_IFrame1" DefaultHeight="689" frameborder="0"
							name="IFrame1" scrolling="no" src="BlankPage.aspx" />
					</div>
					<telerik:RadMenu id="mnuMainMenu" runat="server" CssClass="c_mnuMainMenu" ClickToOpen="False" CollapseAnimation-Duration="200"
						CollapseAnimation-Type="OutQuint" ExpandAnimation-Duration="200" ExpandAnimation-Type="OutQuint" Flow="Vertical"
						OnClientItemClicked="___mnuMainMenuClickHandler" RenderMode="Classic">
						<Items>
							<telerik:RadMenuItem id="MenuItem1" runat="server" CssClass="c_MenuItem1" Text="<%$ Resources: MenuItem1 %>" Value="MenuItem1">
								<Items>
									<telerik:RadMenuItem id="MenuItem15" runat="server" CssClass="c_MenuItem15" Text="<%$ Resources: MenuItem15 %>" Value="MenuItem15" />
									<telerik:RadMenuItem id="MenuItem16" runat="server" CssClass="c_MenuItem16" Text="<%$ Resources: MenuItem16 %>" Value="MenuItem16" />
									<telerik:RadMenuItem id="MenuItem17" runat="server" CssClass="c_MenuItem17" Text="<%$ Resources: MenuItem17 %>" Value="MenuItem17" />
								</Items>
							</telerik:RadMenuItem>
							<telerik:RadMenuItem id="MenuItem5" runat="server" CssClass="c_MenuItem5" Text="<%$ Resources: MenuItem5 %>" Value="MenuItem5">
								<Items>
									<telerik:RadMenuItem id="MenuItem18" runat="server" CssClass="c_MenuItem18" Text="<%$ Resources: MenuItem18 %>" Value="MenuItem18" />
									<telerik:RadMenuItem id="MenuItem19" runat="server" CssClass="c_MenuItem19" Text="<%$ Resources: MenuItem19 %>" Value="MenuItem19" />
									<telerik:RadMenuItem id="MenuItem20" runat="server" CssClass="c_MenuItem20" Text="<%$ Resources: MenuItem20 %>" Value="MenuItem20" />
									<telerik:RadMenuItem id="MenuItem21" runat="server" CssClass="c_MenuItem21" Text="<%$ Resources: MenuItem21 %>" Value="MenuItem21" />
									<telerik:RadMenuItem id="MenuItem22" runat="server" CssClass="c_MenuItem22" Text="<%$ Resources: MenuItem22 %>" Value="MenuItem22" />
									<telerik:RadMenuItem id="MenuItem23" runat="server" CssClass="c_MenuItem23" Text="<%$ Resources: MenuItem23 %>" Value="MenuItem23" />
									<telerik:RadMenuItem id="MenuItem24" runat="server" CssClass="c_MenuItem24" Text="<%$ Resources: MenuItem24 %>" Value="MenuItem24" />
									<telerik:RadMenuItem id="MenuItem25" runat="server" CssClass="c_MenuItem25" Text="<%$ Resources: MenuItem25 %>" Value="MenuItem25" />
								</Items>
							</telerik:RadMenuItem>
							<telerik:RadMenuItem id="MenuItem14" runat="server" CssClass="c_MenuItem14" Text="<%$ Resources: MenuItem14 %>" Value="MenuItem14">
								<Items>
									<telerik:RadMenuItem id="MenuItem26" runat="server" CssClass="c_MenuItem26" Text="<%$ Resources: MenuItem26 %>" Value="MenuItem26" />
									<telerik:RadMenuItem id="MenuItem27" runat="server" CssClass="c_MenuItem27" Text="<%$ Resources: MenuItem27 %>" Value="MenuItem27" />
								</Items>
							</telerik:RadMenuItem>
						</Items>
					</telerik:RadMenu>
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labProjectTitle" runat="server" CssClass="c_labProjectTitle" Text="GerProjeto - Gerenciamento de Atividades" />
						<div id="Line1" class="c_Line1">
						</div>
					</div>
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadToolBar id="tbMain" runat="server" CssClass="c_tbMain" EnableRoundedCorners="True" EnableShadows="True"
							OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999">
							<Items>
								<telerik:RadToolBarButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1 Button1" CommandArgument="Button1"
									CommandName="Button1" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button1 %>" ToolTip="Cria novo registro">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 Button2" CommandArgument="Button2"
									CommandName="Button2" RenderMode="Lightweight" TabIndex="2" Text="<%$ Resources: Button2 %>" ToolTip="Grava alterações do registro atual">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3 Button3" CommandArgument="Button3"
									CommandName="Button3" RenderMode="Lightweight" TabIndex="3" Text="<%$ Resources: Button3 %>" ToolTip="Cancela modificações no registro atual">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4 Button4" CommandArgument="Button4"
									CommandName="Button4" RenderMode="Lightweight" TabIndex="4" Text="<%$ Resources: Button4 %>" ToolTip="Excluir registro atual">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button5" runat="server" ButtonType="SkinnedButton" CssClass="c_Button5 Button5" CommandArgument="Button5"
									CommandName="Button5" RenderMode="Lightweight" TabIndex="5" Text="<%$ Resources: Button5 %>" ToolTip="Mover para o primeiro registro">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button6" runat="server" ButtonType="SkinnedButton" CssClass="c_Button6 Button6" CommandArgument="Button6"
									CommandName="Button6" RenderMode="Lightweight" TabIndex="6" Text="<%$ Resources: Button6 %>" ToolTip="Mover para o registro anterior">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button7" runat="server" ButtonType="SkinnedButton" CssClass="c_Button7 Button7" CommandArgument="Button7"
									CommandName="Button7" RenderMode="Lightweight" TabIndex="7" Text="<%$ Resources: Button7 %>" ToolTip="Mover para o próximo registro">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button8" runat="server" ButtonType="SkinnedButton" CssClass="c_Button8 Button8" CommandArgument="Button8"
									CommandName="Button8" RenderMode="Lightweight" TabIndex="8" Text="<%$ Resources: Button8 %>" ToolTip="Mover para o próximo registro">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button9" runat="server" ButtonType="SkinnedButton" CssClass="c_Button9 Button9" CommandArgument="Button9"
									CommandName="Button9" RenderMode="Lightweight" TabIndex="9" Text="<%$ Resources: Button9 %>" ToolTip="Especifica expressão de filtragem">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button10" runat="server" ButtonType="SkinnedButton" CssClass="c_Button10 Button10" CommandArgument="Button10"
									CommandName="Button10" RenderMode="Lightweight" TabIndex="10" Text="<%$ Resources: Button10 %>" ToolTip="Inicia edição no registro atual">
								</telerik:RadToolBarButton>
								<telerik:RadToolBarButton id="Button11" runat="server" ButtonType="SkinnedButton" CssClass="c_Button11 Button11" CommandArgument="Button11"
									CommandName="Button11" RenderMode="Lightweight" TabIndex="11" Text="<%$ Resources: Button11 %>" ToolTip="Encerra sessão atual">
								</telerik:RadToolBarButton>
							</Items>
						</telerik:RadToolBar>
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
				setTimeout("var $j = jQuery.noConflict();$j('#Button1').first().focus();", 200);
			}
		}
		catch (e)
		{
		}
	}
		function ___mnuMainMenuClickHandler(sender, args)
		{
			var ClickedItem = args.get_item();
			if (HasValue(ClickedItem))
			{
				sender.close(true);
				switch (ClickedItem.get_value())
				{
					case "MenuItem15":
						___MenuItem15_OnClick(sender, args);
					break;
					case "MenuItem16":
						___MenuItem16_OnClick(sender, args);
					break;
					case "MenuItem17":
						___MenuItem17_OnClick(sender, args);
					break;
					case "MenuItem18":
						___MenuItem18_OnClick(sender, args);
					break;
					case "MenuItem19":
						___MenuItem19_OnClick(sender, args);
					break;
					case "MenuItem20":
						___MenuItem20_OnClick(sender, args);
					break;
					case "MenuItem21":
						___MenuItem21_OnClick(sender, args);
					break;
					case "MenuItem22":
						___MenuItem22_OnClick(sender, args);
					break;
					case "MenuItem23":
						___MenuItem23_OnClick(sender, args);
					break;
					case "MenuItem24":
						___MenuItem24_OnClick(sender, args);
					break;
					case "MenuItem25":
						___MenuItem25_OnClick(sender, args);
					break;
					case "MenuItem26":
						___MenuItem26_OnClick(sender, args);
					break;
					case "MenuItem27":
						___MenuItem27_OnClick(sender, args);
					break;
				}
			}
		}
		function ToolbarClickHandler(sender, args)
		{
			var CommandArgument = args.get_item().get_commandArgument();
			switch (CommandArgument)
			{
				case "Button1":
					___Button1_OnClientClick(sender, args);
				break;
				case "Button2":
					___Button2_OnClientClick(sender, args);
				break;
				case "Button3":
					___Button3_OnClientClick(sender, args);
				break;
				case "Button4":
					___Button4_OnClientClick(sender, args);
				break;
				case "Button5":
					___Button5_OnClientClick(sender, args);
				break;
				case "Button6":
					___Button6_OnClientClick(sender, args);
				break;
				case "Button7":
					___Button7_OnClientClick(sender, args);
				break;
				case "Button8":
					___Button8_OnClientClick(sender, args);
				break;
				case "Button9":
					___Button9_OnClientClick(sender, args);
				break;
				case "Button10":
					___Button10_OnClientClick(sender, args);
				break;
				case "Button11":
					___Button11_OnClientClick(sender, args);
				break;
			}
		}
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
				var IFrame1__PAGESTATE = "";
				var IFrame1__PAGENUMBER = 0;
				var IFrame1__PAGECOUNT = 0;
				var IFrame1__ISPARAMETER = "";
				var IFrame1__PERMISSION = "";
				var IFrame1__ALLOWINSERT = "true";
				var IFrame1__ALLOWUPDATE = "true";
				var IFrame1__ALLOWREMOVE = "true";
				try { IFrame1__ISPARAMETER = GetTargetWindow(document.getElementById('IFrame1')).document.getElementById("__TABLEPARAMETER").value.toLowerCase(); } catch (e) { }
				try { IFrame1__PERMISSION = GetTargetWindow(document.getElementById('IFrame1')).document.getElementById("__PERMISSION").value; } catch (e) { }
				try { IFrame1__ALLOWINSERT = IFrame1__PERMISSION.toString().substr(IFrame1__PERMISSION.indexOf("Insert:") + 7, IFrame1__PERMISSION.indexOf(";", IFrame1__PERMISSION.indexOf("Insert:")) - IFrame1__PERMISSION.indexOf("Insert:") - 7).toLowerCase(); } catch (e) { }
				try { IFrame1__ALLOWUPDATE = IFrame1__PERMISSION.toString().substr(IFrame1__PERMISSION.indexOf("Edit:") + 5, IFrame1__PERMISSION.indexOf(";", IFrame1__PERMISSION.indexOf("Edit:")) - IFrame1__PERMISSION.indexOf("Edit:") - 5).toLowerCase(); } catch (e) { }
				try { IFrame1__ALLOWREMOVE = IFrame1__PERMISSION.toString().substr(IFrame1__PERMISSION.indexOf("Remove:") + 7, IFrame1__PERMISSION.indexOf(";", IFrame1__PERMISSION.indexOf("Remove:")) - IFrame1__PERMISSION.indexOf("Remove:") - 7).toLowerCase(); } catch (e) { }
				try { IFrame1__PAGESTATE = GetTargetWindow(document.getElementById('IFrame1')).document.getElementById("__PAGESTATE").value.toLowerCase(); } catch (e) { }
				try { IFrame1__PAGENUMBER = parseInt(GetTargetWindow(document.getElementById('IFrame1')).document.getElementById("__PAGENUMBER").value); } catch (e) { }
				try { IFrame1__PAGECOUNT = parseInt(GetTargetWindow(document.getElementById('IFrame1')).document.getElementById("__PAGECOUNT").value); } catch (e) { }
					EnableDisableMenuItem(mnuMainMenu,"MenuItem18",!IsAjaxProcessing &&IFrame1__PAGESTATE == "navigation" && IFrame1__ALLOWINSERT == "true" && IFrame1__ISPARAMETER == "false");
					EnableDisableMenuItem(mnuMainMenu,"MenuItem19",!IsAjaxProcessing &&IFrame1__PAGESTATE != "" && IFrame1__PAGESTATE != "navigation" && (IFrame1__ALLOWINSERT == "true" || IFrame1__ALLOWUPDATE == "true"));
					EnableDisableMenuItem(mnuMainMenu,"MenuItem20",!IsAjaxProcessing &&IFrame1__PAGESTATE != "" && IFrame1__PAGESTATE != "navigation");
					EnableDisableMenuItem(mnuMainMenu,"MenuItem21",!IsAjaxProcessing &&IFrame1__PAGECOUNT > 0 && IFrame1__ALLOWREMOVE == "true" && IFrame1__ISPARAMETER == "false");
					EnableDisableMenuItem(mnuMainMenu,"MenuItem22",!IsAjaxProcessing &&IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER > 1 && IFrame1__ISPARAMETER == "false");
					EnableDisableMenuItem(mnuMainMenu,"MenuItem23",!IsAjaxProcessing &&IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER > 1 && IFrame1__ISPARAMETER == "false");
					EnableDisableMenuItem(mnuMainMenu,"MenuItem24",!IsAjaxProcessing &&IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER < IFrame1__PAGECOUNT && IFrame1__ISPARAMETER == "false");
					EnableDisableMenuItem(mnuMainMenu,"MenuItem25",!IsAjaxProcessing &&IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER < IFrame1__PAGECOUNT && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button1",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__ALLOWINSERT == "true" && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button2",!IsAjaxProcessing && IFrame1__PAGESTATE != "" && IFrame1__PAGESTATE != "navigation" && (IFrame1__ALLOWINSERT == "true" || IFrame1__ALLOWUPDATE == "true"));
					EnableDisableToolbarButtons(tbMain.id,"Button3",!IsAjaxProcessing && IFrame1__PAGESTATE != "" && IFrame1__PAGESTATE != "navigation");
					EnableDisableToolbarButtons(tbMain.id,"Button4",!IsAjaxProcessing && IFrame1__PAGECOUNT > 0 && IFrame1__ALLOWREMOVE == "true" && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button5",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER > 1 && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button6",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER > 1 && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button7",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER < IFrame1__PAGECOUNT && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button8",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__PAGECOUNT > 0 && IFrame1__PAGENUMBER < IFrame1__PAGECOUNT && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button9",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__ISPARAMETER == "false");
					EnableDisableToolbarButtons(tbMain.id,"Button10",!IsAjaxProcessing && IFrame1__PAGESTATE == "navigation" && IFrame1__PAGENUMBER > 0 && IFrame1__PAGECOUNT > 0 && IFrame1__ALLOWUPDATE == "true");
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

	var ifs = document.getElementsByTagName("iframe");
	var iframes = [];
	for (let i = 0; i < ifs.length; i++) {
        if (ifs[i].getAttribute("AutoExpandToContent") == "True") {
			iframes.push(ifs[i]);
		}
	}

	if (iframes.length > 0) {

		iframeResize = [];
		parent_iframeResize = [];

		if (iframes.length == 1) {
			iframeResize.push(`#${iframes[0].id}`);
            parent_iframeResize.push(`#ParentDiv_${iframes[0].id}`);
		}
		else {
            for (let i = 0; i < iframes.length; i++) {
				iframeResize.push(`#${iframes[i].id}`)
				parent_iframeResize.push(`#ParentDiv_${iframes[i].id}`);
				multiResize(iframeResize[i], parent_iframeResize[i]);
			}
		}
	}
</script>
</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>

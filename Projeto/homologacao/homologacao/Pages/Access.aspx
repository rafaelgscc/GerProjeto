<%@ Page Language="C#" EnableEventValidation="True" ValidateRequest="false" AutoEventWireup="true" CodeFile="Access.aspx.cs" Inherits="PROJETO.Access" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html>
<head runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Access.css" OrderIndex="2"/>
		</StyleSheets>
	</telerik:RadStyleSheetManager>
	<telerik:RadCodeBlock ID="HeaderCodeBlock" runat="server">
		<link rel="stylesheet" href="../Styles/all.min.css" type="text/css" media="screen" title="no title"/>  
	</telerik:RadCodeBlock>
</head>
<body onload="InitializeClient();" id="Form1_body" style="margin-left:auto;margin-right:auto;">
	<telerik:RadCodeBlock ID="BodyCodeBlock" runat="server">
		<script type="text/javascript" src="../JS/jquery.js" ></script>
		<script type="text/javascript" src="../JS/iframeResizer.min.js" ></script>
		<script type="text/javascript" src="../JS/iframeResizer.contentWindow.min.js" ></script>
		<script type="text/javascript" src="../JS/Common.js"></script>
		<script type="text/javascript" src="../JS/Functions.js"></script>

		<script src='../JS/Mask.js' type="text/javascript"></script>

		<script type ="text/javascript" >

			function openAlert(string) 
			{
				this.parent.parent.GAlert(string);
			}
			function TreeViewChanged()
			{
				var obj = window.event.srcElement;
				var treeNodeFound = false;
				var checkedState;
				if (obj.tagName == "INPUT" && obj.type == "checkbox")
				{
					//AcessosBar.EnableButton('Salvar');
					//AcessosBar.EnableButton('Cancelar');
					var treeNode = obj;
					checkedState = treeNode.checked;
					if (checkedState == true && obj.id == "MenuPermTvn0CheckBox")
					{
						return;
					}
					do 
					{
						obj = obj.parentElement;
					}
					while (obj.tagName != "TABLE")
					var parentTreeLevel = obj.rows[0].cells.length;
					var parentTreeNode = obj.rows[0].cells[0];
					var tables = obj.parentElement.getElementsByTagName("TABLE");
					var numTables = tables.length
					if (numTables >= 1)
					{
						for (i = 0; i < numTables; i++) 
						{
							if (tables[i] == obj) 
							{
								treeNodeFound = true;
								i++;
								if (i == numTables) 
								{
									return;
								}
							}
							if (treeNodeFound == true)
							{
								var childTreeLevel = tables[i].rows[0].cells.length;
								if (childTreeLevel > parentTreeLevel) 
								{
									var cell = tables[i].rows[0].cells[childTreeLevel - 1];
									var inputs = cell.getElementsByTagName("INPUT");
									inputs[0].checked = checkedState;
								}
								else 
								{
									return;
								}
							}
						}
					}
				}
			}
			function ___txtActualPassword_onkeydown(event,vgWin)
			{
			}
			function ___txtNewPassword_onkeydown(event,vgWin)
			{
			}
			function ___txtNewPasswordConfirm_onkeydown(event,vgWin)
			{
			}
			function ___TextBox6_onkeydown(event,vgWin)
			{
			}
			function ___TextBox7_onkeydown(event,vgWin)
			{
			}
			function ___TextBox8_onkeydown(event,vgWin)
			{
			}
			function ___TextBox9_onkeydown(event,vgWin)
			{
			}
			function ___TextBox10_onkeydown(event,vgWin)
			{
			}
			function ___TextBox11_onkeydown(event,vgWin)
			{
			}
			function ___Button7_OnClientClick(sender, args)
			{
				try { GetRadWindow().close(); } catch (ex) {} 
				args.set_cancel(true);
				return false;
			}
		</script>

		
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
	<script type="text/javascript" src="../JS/Access_USER.js?sv=v1.0.12_20221213161348"></script>
	</telerik:RadCodeBlock>
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
				<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
					<div id="Div3" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div3">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Controle de acesso" />
					</div>
					<telerik:RadAjaxPanel id="AjaxPanel1" runat="server" CssClass="c_AjaxPanel1" LoadingPanelID="___AjaxPanel1_AjaxLoading">
						<div style="position:absolute !important;left:5px;top:33px;width:554px;height:409px;border-bottom-left-radius:0px;border-bottom-right-radius:0px;border-top-left-radius:0px;border-top-right-radius:0px">
							<telerik:RadTabStrip id="TabControl5" runat="server" Align="Left" AutoPostBack="False" CssClass="c_TabControl5"
								MultiPageID="TabControl5MultiPage" PerTabScrolling="False" RenderMode="Classic" ScrollButtonsPosition="Middle" ScrollChildren="True">
								<Tabs>
									<telerik:RadTab id="TabItem1" runat="server" CssClass="c_TabItem1" Selected="true" Text="<%$ Resources: TabPage1 %>">
									</telerik:RadTab>
									<telerik:RadTab id="TabItem2" runat="server" CssClass="c_TabItem2" Text="<%$ Resources: TabPage2 %>">
									</telerik:RadTab>
									<telerik:RadTab id="TabItem3" runat="server" CssClass="c_TabItem3" Text="<%$ Resources: TabPage3 %>">
									</telerik:RadTab>
								</Tabs>
							</telerik:RadTabStrip>
							<telerik:RadMultiPage runat="server" ID="TabControl5MultiPage" BorderColor="#000000" BorderWidth="1" BorderStyle="Solid" SelectedIndex="0" Width="100%" Height="383px">
								<telerik:RadPageView id="TabPage1" runat="server" BackColor="#FFFFFF" CssClass="c_TabPage1">
										<telerik:RadTextBox id="txtActualPassword" runat="server" AutoPostBack="False" CssClass="c_txtActualPassword"
											EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False"
											RenderMode="Classic" TabIndex="1" TextMode="Password" WrapperCssClass="c_txtActualPassword_wrapper" />
										<telerik:RadTextBox id="txtNewPassword" runat="server" AutoPostBack="False" CssClass="c_txtNewPassword" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="2" TextMode="Password"
											WrapperCssClass="c_txtNewPassword_wrapper" />
										<telerik:RadTextBox id="txtNewPasswordConfirm" runat="server" AutoPostBack="False" CssClass="c_txtNewPasswordConfirm"
											EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False"
											RenderMode="Classic" TabIndex="3" TextMode="Password" WrapperCssClass="c_txtNewPasswordConfirm_wrapper" />
										<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
										<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
										<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
										<telerik:RadToolBar id="tbSavePw" runat="server" CssClass="c_tbSavePw" EnableRoundedCorners="True" EnableShadows="True"
											OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999" Width="25">
											<Items>
												<telerik:RadToolBarButton id="butPWSave" runat="server" ButtonType="SkinnedButton" CssClass="c_butPWSave butPWSave"
													CommandArgument="butPWSave" CommandName="butPWSave" RenderMode="Lightweight" TabIndex="4">
												</telerik:RadToolBarButton>
											</Items>
										</telerik:RadToolBar>
								</telerik:RadPageView>
								<telerik:RadPageView id="TabPage2" runat="server" BackColor="#FFFFFF" CssClass="c_TabPage2">
										<telerik:RadLabel id="Label25" runat="server" CssClass="c_Label25" Text="<%$ Resources: Label25 %>" />
										<telerik:RadListBox id="ListBox3" runat="server" AutoPostBack="True" CssClass="c_ListBox3" ForeColor="#000000" Height="157"
											OnSelectedIndexChanged="___ListBox3_OnSelectedIndexChanged" RenderMode="Classic" SelectionMode="Single" TabIndex="5" Width="187" />
										<telerik:RadLabel id="Label28" runat="server" CssClass="c_Label28" Text="<%$ Resources: Label28 %>" />
										<telerik:RadListBox id="ListBox4" runat="server" AutoPostBack="True" CssClass="c_ListBox4" ForeColor="#000000" Height="157"
											OnSelectedIndexChanged="___ListBox4_OnSelectedIndexChanged" RenderMode="Classic" SelectionMode="Single" TabIndex="6" Width="191" />
										<telerik:RadCheckBox id="CheckBox2" runat="server" AutoPostBack="True" Checked="False" CssClass="CheckBox2 c_CheckBox2"
											RenderMode="Classic" TabIndex="7" Text="<%$ Resources: CheckBox2 %>" />
										<telerik:RadCheckBox id="CheckBox3" runat="server" AutoPostBack="True" Checked="False" CssClass="CheckBox3 c_CheckBox3"
											RenderMode="Classic" TabIndex="8" Text="<%$ Resources: CheckBox3 %>" />
										<telerik:RadCheckBox id="CheckBox4" runat="server" AutoPostBack="True" Checked="False" CssClass="CheckBox4 c_CheckBox4"
											RenderMode="Classic" TabIndex="9" Text="<%$ Resources: CheckBox4 %>" />
										<telerik:RadCheckBox id="CheckBox5" runat="server" AutoPostBack="True" Checked="False" CssClass="CheckBox5 c_CheckBox5"
											RenderMode="Classic" TabIndex="10" Text="<%$ Resources: CheckBox5 %>" />
										<telerik:RadLabel id="Label26" runat="server" CssClass="c_Label26" Text="<%$ Resources: Label26 %>" />
										<telerik:RadTextBox id="TextBox6" runat="server" AutoPostBack="False" CssClass="c_TextBox6" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="11"
											TextMode="SingleLine" WrapperCssClass="c_TextBox6_wrapper" />
										<telerik:RadCheckBox id="CheckBox1" runat="server" AutoPostBack="True" Checked="False" CssClass="CheckBox1 c_CheckBox1"
											RenderMode="Classic" TabIndex="12" Text="<%$ Resources: CheckBox1 %>" />
										<telerik:RadToolBar id="tbGroup" runat="server" CssClass="c_tbGroup" EnableRoundedCorners="True" EnableShadows="True"
											OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999" Width="88">
											<Items>
												<telerik:RadToolBarButton id="butGroupCancel2" runat="server" ButtonType="SkinnedButton" CssClass="c_butGroupCancel2 butGroupCancel2"
													CommandArgument="butGroupCancel2" CommandName="butGroupCancel2" RenderMode="Lightweight" TabIndex="13">
												</telerik:RadToolBarButton>
												<telerik:RadToolBarButton id="butGroupSave2" runat="server" ButtonType="SkinnedButton" CssClass="c_butGroupSave2 butGroupSave2"
													CommandArgument="butGroupSave2" CommandName="butGroupSave2" RenderMode="Lightweight" TabIndex="14">
												</telerik:RadToolBarButton>
												<telerik:RadToolBarButton id="butGroupNew2" runat="server" ButtonType="SkinnedButton" CssClass="c_butGroupNew2 butGroupNew2"
													CommandArgument="butGroupNew2" CommandName="butGroupNew2" RenderMode="Lightweight" TabIndex="15">
												</telerik:RadToolBarButton>
												<telerik:RadToolBarButton id="butGroupRemove2" runat="server" ButtonType="SkinnedButton" CssClass="c_butGroupRemove2 butGroupRemove2"
													CommandArgument="butGroupRemove2" CommandName="butGroupRemove2" RenderMode="Lightweight" TabIndex="16">
												</telerik:RadToolBarButton>
											</Items>
										</telerik:RadToolBar>
								</telerik:RadPageView>
								<telerik:RadPageView id="TabPage3" runat="server" BackColor="#FFFFFF" CssClass="c_TabPage3">
										<telerik:RadLabel id="Label35" runat="server" CssClass="c_Label35" Text="<%$ Resources: Label35 %>" />
										<telerik:RadListBox id="ListBox5" runat="server" AutoPostBack="True" CssClass="c_ListBox5" ForeColor="#000000" Height="135"
											OnSelectedIndexChanged="___ListBox5_OnSelectedIndexChanged" RenderMode="Classic" SelectionMode="Single" TabIndex="17" Width="182" />
										<telerik:RadLabel id="Label36" runat="server" CssClass="c_Label36" Text="<%$ Resources: Label36 %>" />
										<telerik:RadListBox id="ListBox6" runat="server" AutoPostBack="True" CssClass="c_ListBox6" ForeColor="#000000" Height="135"
											OnSelectedIndexChanged="___ListBox6_OnSelectedIndexChanged" RenderMode="Classic" SelectionMode="Single" TabIndex="18" Width="182" />
										<telerik:RadLabel id="Label30" runat="server" CssClass="c_Label30" Text="<%$ Resources: Label30 %>" />
										<telerik:RadTextBox id="TextBox7" runat="server" AutoPostBack="False" CssClass="c_TextBox7" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="23"
											TextMode="SingleLine" WrapperCssClass="c_TextBox7_wrapper" />
										<telerik:RadLabel id="Label37" runat="server" CssClass="c_Label37" Text="<%$ Resources: Label37 %>" />
										<telerik:RadTextBox id="TextBox11" runat="server" AutoPostBack="False" CssClass="c_TextBox11" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="24"
											TextMode="SingleLine" WrapperCssClass="c_TextBox11_wrapper" />
										<telerik:RadLabel id="Label31" runat="server" CssClass="c_Label31" Text="<%$ Resources: Label31 %>" />
										<telerik:RadTextBox id="TextBox8" runat="server" AutoPostBack="False" CssClass="c_TextBox8" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="25" TextMode="Password"
											WrapperCssClass="c_TextBox8_wrapper" />
										<telerik:RadLabel id="Label38" runat="server" CssClass="c_Label38" Text="<%$ Resources: Label38 %>" />
										<telerik:RadTextBox id="TextBox9" runat="server" AutoPostBack="False" CssClass="c_TextBox9" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="26" TextMode="Password"
											WrapperCssClass="c_TextBox9_wrapper" />
										<telerik:RadLabel id="Label39" runat="server" CssClass="c_Label39" Text="<%$ Resources: Label39 %>" />
										<telerik:RadTextBox id="TextBox10" runat="server" AutoPostBack="False" CssClass="c_TextBox10" EnabledStyle-HorizontalAlign="Left"
											EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0" ReadOnly="False" RenderMode="Classic" TabIndex="27"
											TextMode="MultiLine" WrapperCssClass="c_TextBox10_wrapper" />
										<telerik:RadToolBar id="tbUser" runat="server" CssClass="c_tbUser" EnableRoundedCorners="True" EnableShadows="True"
											OnClientButtonClicking="ToolbarClickHandler" Orientation="Horizontal" RenderMode="Lightweight" Style="z-index:5999" Width="88">
											<Items>
												<telerik:RadToolBarButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1 Button1" CommandArgument="Button1"
													CommandName="Button1" RenderMode="Lightweight" TabIndex="19">
												</telerik:RadToolBarButton>
												<telerik:RadToolBarButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3 Button3" CommandArgument="Button3"
													CommandName="Button3" RenderMode="Lightweight" TabIndex="20">
												</telerik:RadToolBarButton>
												<telerik:RadToolBarButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4 Button4" CommandArgument="Button4"
													CommandName="Button4" RenderMode="Lightweight" TabIndex="21">
												</telerik:RadToolBarButton>
												<telerik:RadToolBarButton id="Button2" runat="server" ButtonType="SkinnedButton" CssClass="c_Button2 Button2" CommandArgument="Button2"
													CommandName="Button2" RenderMode="Lightweight" TabIndex="22">
												</telerik:RadToolBarButton>
											</Items>
										</telerik:RadToolBar>
								</telerik:RadPageView>
							</telerik:RadMultiPage>
						</div>
						<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
						<telerik:RadButton id="Button7" runat="server" ButtonType="SkinnedButton" CssClass="c_Button7" CommandName="Button7"
							OnClientClicking="___Button7_OnClientClick" RenderMode="Lightweight" TabIndex="28" Text="<%$ Resources: Button7 %>">
						</telerik:RadButton>
						<telerik:RadAjaxLoadingPanel ID="___AjaxPanel1_AjaxLoading" runat="server">
						</telerik:RadAjaxLoadingPanel>
					</telerik:RadAjaxPanel>
				</div>
			</div>
		</form>
</body>
<script>
	var $j = jQuery.noConflict();
	$j(document).ready(SetFocusFirstField());
	function SetFocusFirstField()
	{
		try
		{
			{
				window.focus();
				setTimeout("var $j = jQuery.noConflict();$j('#txtActualPassword').first().focus();", 200);
			}
		}
		catch (e)
		{
		}
	}
</script>
<script type ="text/javascript">
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
	function ToolbarClickHandler(sender, args)
	{
		var CommandArgument = args.get_item().get_commandArgument();
		switch (CommandArgument)
		{
			case "butPWSave":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "butGroupCancel2":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "butGroupSave2":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "butGroupNew2":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "butGroupRemove2":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "Button1":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "Button3":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "Button4":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
			case "Button2":
		AjaxPanel1.ajaxRequestWithTarget('AjaxPanel1', CommandArgument);
			break;
		}
	}
</script>
</html>

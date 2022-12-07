<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="RelacaoAcaoProjeto.aspx.cs" Inherits="PROJETO.DataPages.RelacaoAcaoProjeto" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/RelacaoAcaoProjeto.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/RelacaoAcaoProjeto_USER.js?sv=v1.0.11_20221207165302"></script>
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
		function ___Button1_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___RadTextBox1_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___WSExecucaoDiretoria_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSExecucaoDiretoria_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSExecucaoDiretoria_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
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
					<telerik:RadWindowManager id="WSExecucaoDiretoria" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSExecucaoDiretoria"
						DestroyOnClose="True" EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False"
						OnClientClose="___WSExecucaoDiretoria_OnClientClose" OnClientPageLoad="___WSExecucaoDiretoria_OnClientPageLoad"
						OnClientShow="___WSExecucaoDiretoria_OnClientShow" PreserveClientState="True" RenderMode="Classic" RestrictionZoneID="__MainDiv"
						ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="False" VisibleTitlebar="False" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Relação de Ações" />
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<div id="Div2" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div2">
						<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" EnableEmbeddedSkins="True" EnableHeaderContextMenu="False"
							EnableLinqExpressions="false" ExportFileName="GGrid" OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init"
							OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand" OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound"
							OnNeedDataSource="Grid_NeedDataSource" OnUpdateCommand="Grid_UpdateCommand" PageSize="20" RenderMode="Classic" ShowFooter="False"
							ShowGroupPanel="False" TabIndex="2" TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="projeto,itemProjeto" EditMode="InPlace">
								<Columns>
									<telerik:GridBoundColumn UniqueName="GridColumn1" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="projeto" DataFormatString="{0:#########0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="3" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn1" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="38" HeaderText="<%$ Resources: GridColumn1 %>"
										ItemStyle-CssClass="c_GridColumn1" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="31" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="itemProjeto" DataFormatString="{0:####0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn2"
										HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="35" HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2"
										ItemStyle-HorizontalAlign="Right" ItemStyle-Width="28" MaxLength="5" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn3" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="nomeAcao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="288"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn3" HeaderStyle-Width="323"
										HeaderText="<%$ Resources: GridColumn3 %>" ItemStyle-CssClass="c_GridColumn3" ItemStyle-Width="316" MaxLength="255" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn15" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="statusAcao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="31"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn15" HeaderStyle-Width="66"
										HeaderText="<%$ Resources: GridColumn15 %>" ItemStyle-CssClass="c_GridColumn15" ItemStyle-Width="59" MaxLength="15" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn12" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaCoordenacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="45"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn12" HeaderStyle-Width="80"
										HeaderText="<%$ Resources: GridColumn12 %>" ItemStyle-CssClass="c_GridColumn12" ItemStyle-Width="73" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn4" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="inicioPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn4" HeaderStyle-Width="81" HeaderText="<%$ Resources: GridColumn4 %>" ItemStyle-CssClass="c_GridColumn4"
										ItemStyle-Width="74" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn16" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="inicioRealizado" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn16" HeaderStyle-Width="83" HeaderText="<%$ Resources: GridColumn16 %>" ItemStyle-CssClass="c_GridColumn16"
										ItemStyle-Width="76" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn5" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="terminoPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn5" HeaderStyle-Width="70" HeaderText="<%$ Resources: GridColumn5 %>" ItemStyle-CssClass="c_GridColumn5"
										ItemStyle-Width="63" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn6" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="terminoRealizado" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn6" HeaderStyle-Width="81" HeaderText="<%$ Resources: GridColumn6 %>" ItemStyle-CssClass="c_GridColumn6"
										ItemStyle-Width="74" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn14" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="percentualExecutado" DataFormatString="{0:##0.00}" EnableHeaderContextMenu="True"
										Exportable="True" FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn14" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn14 %>"
										ItemStyle-CssClass="c_GridColumn14" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="6" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn18" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="situacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn18" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn18 %>" ItemStyle-CssClass="c_GridColumn18" ItemStyle-Width="86" MaxLength="20" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridButtonColumn UniqueName="GridColumn17" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn17" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn17" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn17 %>" ItemStyle-CssClass="c_GridColumn17"
										ItemStyle-Width="86" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn17_1 %>" />
									<telerik:GridTemplateColumn Exportable="false" AllowFiltering="false"></telerik:GridTemplateColumn>
								</Columns>
								<CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
							</MasterTableView>
							<PagerStyle Mode="NextPrevAndNumeric" />
							<ClientSettings EnableRowHoverStyle="true">
								<ClientEvents />
							</ClientSettings>
						</telerik:RadGrid>
					</div>
					<div id="Div3" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div3">
						<div runat="server" id ="___DIVRadTextBox1">
							<telerik:RadTextBox id="RadTextBox1" runat="server" AutoPostBack="False" CssClass="c_RadTextBox1"
								data-validation-engine="validate[funcCall[RadTextBox1_Validation]]" data-validation-message="Nome do Projeto não pode ser vazio!"
								enabled="false" EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="0"
								onkeydown="___RadTextBox1_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="3" TextMode="MultiLine"
								WrapperCssClass="c_RadTextBox1_wrapper" />
						</div>
					</div>
					<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
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
					setTimeout("var $j = jQuery.noConflict();$j('#Button1').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function nomeProjeto() { return document.getElementById('RadTextBox1').value; }
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


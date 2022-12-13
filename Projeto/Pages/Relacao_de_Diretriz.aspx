<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="Relacao_de_Diretriz.aspx.cs" Inherits="PROJETO.DataPages.Relacao_de_Diretriz" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/Relacao_de_Diretriz.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/Relacao_de_Diretriz_USER.js?sv=v1.0.11_20221213104558"></script>
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
		function ___Button3_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/CadastroDiretriz.aspx?ParamCod_Projeto={ParamCod_Projeto}&ParamCoordenacao={ParamCoordenacao}") %>';
			UrlPage = UrlPage.replace('{ParamCod_Projeto}', '');
			UrlPage = UrlPage.replace('{ParamCoordenacao}', '');
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___WSRelProjetos_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSRelProjetos_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSRelProjetos_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function GridColumn16_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function GridColumn10_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function GridColumn7_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<telerik:RadWindowManager id="WSRelProjetos" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSRelProjetos" DestroyOnClose="True"
						EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSRelProjetos_OnClientClose"
						OnClientPageLoad="___WSRelProjetos_OnClientPageLoad" OnClientShow="___WSRelProjetos_OnClientShow" PreserveClientState="True"
						RenderMode="Classic" RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="False"
						VisibleTitlebar="False" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Relação de Diretriz" />
						<telerik:RadButton id="Button3" runat="server" ButtonType="SkinnedButton" CssClass="c_Button3" CommandName="Button3"
							OnClientClicking="___Button3_OnClientClick" RenderMode="Lightweight" TabIndex="2" Text="<%$ Resources: Button3 %>">
						</telerik:RadButton>
						<telerik:RadButton id="Button1" runat="server" ButtonType="SkinnedButton" CssClass="c_Button1" CommandName="Button1"
							OnClientClicking="___Button1_OnClientClick" RenderMode="Lightweight" TabIndex="1" Text="<%$ Resources: Button1 %>">
						</telerik:RadButton>
					</div>
					<div id="DivGrid" runat="server" AutoExpandToContent="True" AutoExpandToContentMargin="10" class="c_DivGrid">
						<telerik:RadGrid id="Grid1" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid1" CleanLayoutNoRecord="False" ClientSettings-ClientEvents-OnCommand="CheckValidation"
							EnableEmbeddedSkins="True" EnableHeaderContextMenu="False" EnableLinqExpressions="false" ExportFileName="GGrid"
							OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init" OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid1_ItemCommand"
							OnItemCreated="Grid1_ItemCreated" OnItemDataBound="Grid1_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource"
							OnUpdateCommand="Grid_UpdateCommand" PageSize="20" RenderMode="Classic" ShowFooter="False" ShowGroupPanel="False" TabIndex="3"
							TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="codigo" EditMode="InPlace">
								<Columns>
									<telerik:GridBoundColumn UniqueName="GridColumn12" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="codigo" DataFormatString="{0:#########0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="11" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn12" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="46" HeaderText="<%$ Resources: GridColumn12 %>"
										ItemStyle-CssClass="c_GridColumn12" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="39" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn16" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="anoProjeto" DataFormatString="{0:###0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="9" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn16" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="44" HeaderText="<%$ Resources: GridColumn16 %>"
										ItemStyle-CssClass="c_GridColumn16" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="37" MaxLength="4" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn10" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaCoordenacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn10" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn10 %>" ItemStyle-CssClass="c_GridColumn10" ItemStyle-Width="86" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn11" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaSetorial" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="21"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn11" HeaderStyle-Width="56"
										HeaderText="<%$ Resources: GridColumn11 %>" ItemStyle-CssClass="c_GridColumn11" ItemStyle-Width="49" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn2" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="nomeProjeto" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="349"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn2" HeaderStyle-Width="384"
										HeaderText="<%$ Resources: GridColumn2 %>" ItemStyle-CssClass="c_GridColumn2" ItemStyle-Width="377" MaxLength="255" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridTemplateColumn UniqueName="GridColumn3" runat="server" AllowFiltering="True" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="Diretriz" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="14"
										FilterDelay="2000" ForceExtractValue="Always" GroupByExpression="Diretriz Diretriz Group By Diretriz" HeaderStyle-CssClass="c_GridColumn3"
										HeaderStyle-Width="49" HeaderText="<%$ Resources: GridColumn3 %>" ItemStyle-CssClass="c_GridColumn3" ItemStyle-Width="42" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" SortExpression="Diretriz">
										<EditItemTemplate>
											<telerik:RadComboBox ID="GridColumn3_ComboBox" runat="server" MarkFirstMatch="True" AllowCustomText="False" 
												 AutoPostBack="False" EnableLoadOnDemand="True" EnableVirtualScrolling="True" MaxHeight="100"
												OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" DropDownAutoWidth ="Enabled"
												OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___Grid1_GridColumn3_ComboBox_OnItemsRequested" ItemsPerRequest="15"
												Width="34" ClientIDMode="Static" />
										</EditItemTemplate>
										<ItemTemplate> 
											<asp:Label runat="server" ID="GridColumn3_Label" Text='<%#PageProvider.Relacao_de_Projetos_Grid1Provider.GetGridComboText("GridColumn3", Eval("Diretriz").ToString())%>' Value='<%#Eval("Diretriz").ToString()%>'/>
										</ItemTemplate> 
									</telerik:GridTemplateColumn>
									<telerik:GridTemplateColumn UniqueName="GridColumn4" runat="server" AllowFiltering="True" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="statusProjeto" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="43"
										FilterDelay="2000" ForceExtractValue="Always" GroupByExpression="statusProjeto statusProjeto Group By statusProjeto"
										HeaderStyle-CssClass="c_GridColumn4" HeaderStyle-Width="78" HeaderText="<%$ Resources: GridColumn4 %>" ItemStyle-CssClass="c_GridColumn4"
										ItemStyle-Width="71" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" SortExpression="statusProjeto">
										<EditItemTemplate>
											<telerik:RadComboBox ID="GridColumn4_ComboBox" runat="server" MarkFirstMatch="True" AllowCustomText="False" 
												 AutoPostBack="False" EnableLoadOnDemand="True" EnableVirtualScrolling="True" MaxHeight="100"
												OnClientItemsRequested="CheckComboItems" OnClientItemsRequesting="Combo_OnClientItemsRequesting" DropDownAutoWidth ="Enabled"
												OnClientKeyPressing="Combo_HandleKeyPress" OnItemsRequested="___Grid1_GridColumn4_ComboBox_OnItemsRequested" ItemsPerRequest="15"
												Width="63" ClientIDMode="Static" />
										</EditItemTemplate>
										<ItemTemplate> 
											<asp:Label runat="server" ID="GridColumn4_Label" Text='<%#PageProvider.Relacao_de_Projetos_Grid1Provider.GetGridComboText("GridColumn4", Eval("statusProjeto").ToString())%>' Value='<%#Eval("statusProjeto").ToString()%>'/>
										</ItemTemplate> 
									</telerik:GridTemplateColumn>
									<telerik:GridDateTimeColumn UniqueName="GridColumn7" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="inicioPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn7" HeaderStyle-Width="76" HeaderText="<%$ Resources: GridColumn7 %>" ItemStyle-CssClass="c_GridColumn7"
										ItemStyle-Width="69" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn8" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="terminoPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn8" HeaderStyle-Width="66" HeaderText="<%$ Resources: GridColumn8 %>" ItemStyle-CssClass="c_GridColumn8"
										ItemStyle-Width="59" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn9" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="DiasDeProjeto" DataFormatString="{0:#########0}" EnableHeaderContextMenu="True"
										Exportable="True" FilterControlWidth="2" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn9" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="37" HeaderText="<%$ Resources: GridColumn9 %>"
										ItemStyle-CssClass="c_GridColumn9" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="30" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn14" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="percentualExecutado" DataFormatString="{0:##0.00}" EnableHeaderContextMenu="True"
										Exportable="True" FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn14" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn14 %>"
										ItemStyle-CssClass="c_GridColumn14" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="6" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn13" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="situacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn13" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn13 %>" ItemStyle-CssClass="c_GridColumn13" ItemStyle-Width="86" MaxLength="20" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridButtonColumn UniqueName="GridColumn5" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn5" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn5" HeaderStyle-Width="51" HeaderText="<%$ Resources: GridColumn5 %>" ItemStyle-CssClass="c_GridColumn5"
										ItemStyle-Width="44" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn5_1 %>" />
									<telerik:GridButtonColumn UniqueName="GridColumn6" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn6" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn6" HeaderStyle-Width="47" HeaderText="<%$ Resources: GridColumn6 %>" ItemStyle-CssClass="c_GridColumn6"
										ItemStyle-Width="40" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn6_1 %>" />
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
					<telerik:RadLabel id="labError" runat="server" CssClass="c_labError" />
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
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


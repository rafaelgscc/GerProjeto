<%@ Page Language="C#" ValidateRequest="false" EnableEventValidation="True" AutoEventWireup="true" CodeFile="ProjetosAtividades.aspx.cs" Inherits="PROJETO.DataPages.ProjetosAtividades" Culture="auto" UICulture="auto"%>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "https://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html lang="<%=PROJETO.Utility.CurrentSiteLanguage%>">
<head id="Head1" runat="server">
	<title><asp:Literal runat="server" Text="<%$ Resources: Form1 %>" /></title>
	<telerik:RadStyleSheetManager runat="server" ID="styleSheetManager" EnableStyleSheetCombine="true" OutputCompression="AutoDetect">
		<StyleSheets>
			<telerik:StyleSheetReference Path="~/Styles/gvinci_button.css" OrderIndex="1"/>
			<telerik:StyleSheetReference Path="~/Styles/ProjetosAtividades.css" OrderIndex="2"/>
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
		<script type="text/javascript" src="../JS/ProjetosAtividades_USER.js?sv=v1.0.12_20221220102702"></script>
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
		function Grid2Created(sender, args) {
			var $j = jQuery.noConflict();
			if (($j("#Grid2ShouldDisable")[0] && $j("#Grid2ShouldDisable")[0].value == "True") || ($j("#__PAGESTATE")[0] && $j("#__PAGESTATE")[0].value == "Insert"))
				DisableGrid(sender);
		}
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
		function ___Button4_OnClientClick(sender, args)
		{
			try { GetRadWindow().close(); } catch (ex) {} 
			try { GetRadWindow().Caller.Refresh();} catch (e) {};
			args.set_cancel(true);
			return false;
		}
		function ___WSAtividades_OnClientPageLoad(sender, args)
		{
			OnClientPageLoad(sender);
		}
		function ___WSAtividades_OnClientShow(sender, args)
		{
			OnClientShow(sender);
		}
		function ___WSAtividades_OnClientClose(sender, args)
		{
			OnClientClose(sender);
			ShowClientFormulas(true);
		}
		function ___Button5_OnClientClick(sender, args)
		{
			var UrlPage = '<%= ResolveUrl("~/Pages/CadastroAtividades.aspx?ParamProjeto={ParamProjeto}&ParamAcao={ParamAcao}&ParamAtividade={ParamAtividade}&ParamCoordenacao={ParamCoordenacao}") %>';
			UrlPage = UrlPage.replace('{ParamProjeto}', projeto());
			UrlPage = UrlPage.replace('{ParamAcao}', itemProjeto());
			UrlPage = UrlPage.replace('{ParamAtividade}', '');
			UrlPage = UrlPage.replace('{ParamCoordenacao}', siglaCoordenacao());
			var options = { Modal: true, Center: true }
			Navigate(UrlPage,true, null, options);
			args.set_cancel(true);
			return false;
		}
		function ___RadTextBox1_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox2_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox3_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox8_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox9_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox13_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox4_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox10_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function ___RadTextBox11_onkeydown(event,vgWin)
		{
			onTextChanged(event);
		}
		function GridColumn11_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
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
		function DatePicker1_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function DatePicker2_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox8_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox4_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
		function RadTextBox11_Validation(field, rules, i, options) {
			if (!(validateCall(field, "required", options))) {
				return field.attr('data-validation-message');
			}
		}
	</script>
		
		<form id="Form1" runat="server" class="c_Form1">
			<asp:ScriptManager ID="MainScriptManager" runat="server"/>
			<telerik:RadAjaxPanel id="MainAjaxPanel" runat="server" class="c_MainAjaxPanel" ClientEvents-OnRequestStart="___Form1_OnRequestStart" ClientEvents-OnResponseEnd="___Form1_OnResponseEnd" LoadingPanelID="___Form1_AjaxLoading">
				<div id="__MainDiv" class="c_MainDiv" runat="server" StrechVertical="None">
					<telerik:RadWindowManager id="WSAtividades" runat="server" AutoSize="True" Behaviors="Default" CssClass="c_WSAtividades" DestroyOnClose="True"
						EnableFocusNextWindowShortcut="True" EnableShadow="True" HasScroll="False" OnClientClose="___WSAtividades_OnClientClose"
						OnClientPageLoad="___WSAtividades_OnClientPageLoad" OnClientShow="___WSAtividades_OnClientShow" PreserveClientState="True" RenderMode="Classic"
						RestrictionZoneID="__MainDiv" ShowContentDuringLoad="False" VisibleOnPageLoad="True" VisibleStatusbar="False" VisibleTitlebar="False" />
					<div id="Div1" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div1">
						<telerik:RadLabel id="labModuleTitle" runat="server" CssClass="c_labModuleTitle" Text="Projetos e Atividades Gerenciais" />
						<telerik:RadButton id="Button4" runat="server" ButtonType="SkinnedButton" CssClass="c_Button4" CommandName="Button4"
							OnClientClicking="___Button4_OnClientClick" RenderMode="Lightweight" TabIndex="14" Text="<%$ Resources: Button4 %>">
						</telerik:RadButton>
					</div>
					<div id="Div4" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div4">
						<telerik:RadButton id="Button5" runat="server" ButtonType="SkinnedButton" CssClass="c_Button5" CommandName="Button5"
							OnClientClicking="___Button5_OnClientClick" RenderMode="Lightweight" TabIndex="13" Text="<%$ Resources: Button5 %>">
						</telerik:RadButton>
						<telerik:RadLabel id="Label19" runat="server" CssClass="c_Label19" Text="<%$ Resources: Label19 %>" />
					</div>
					<div id="Div6" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div6">
						<telerik:RadGrid id="Grid2" runat="server" AllowCustomPaging="true" AllowFilteringByColumn="False" AllowPaging="True" AllowSorting="True"
							AutoGenerateColumns="false" CssClass="c_Grid2" CleanLayoutNoRecord="False" ClientSettings-ClientEvents-OnCommand="CheckValidation"
							EnableEmbeddedSkins="True" EnableHeaderContextMenu="False" EnableLinqExpressions="false" ExportFileName="GGrid"
							OnDeleteCommand="Grid_DeleteCommand" OnInit="Grid_Init" OnInsertCommand="Grid_InsertCommand" OnItemCommand="Grid2_ItemCommand"
							OnItemCreated="Grid2_ItemCreated" OnItemDataBound="Grid2_ItemDataBound" OnNeedDataSource="Grid_NeedDataSource"
							OnUpdateCommand="Grid_UpdateCommand" PageSize="10" RenderMode="Classic" ShowFooter="False" ShowGroupPanel="False" TabIndex="12"
							TableLayout="Fixed">
							<MasterTableView  AllowCustomPaging="true" CommandItemDisplay="Top" DataKeyNames="projeto,itemProjeto,itemProcesso" EditMode="InPlace">
								<Columns>
									<telerik:GridBoundColumn UniqueName="GridColumn7" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="itemProcesso" DataFormatString="{0:####0}" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="28" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn7" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="63" HeaderText="<%$ Resources: GridColumn7 %>"
										ItemStyle-CssClass="c_GridColumn7" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="56" MaxLength="5" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn8" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="nomeProcesso" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="148"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn8" HeaderStyle-Width="183"
										HeaderText="<%$ Resources: GridColumn8 %>" ItemStyle-CssClass="c_GridColumn8" ItemStyle-Width="176" MaxLength="255" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn9" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="inicioPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn9" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn9 %>" ItemStyle-CssClass="c_GridColumn9"
										ItemStyle-Width="86" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridDateTimeColumn UniqueName="GridColumn11" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="terminoPrevisto" DataFormatString="{0:dd/MM/yyyy}" EditDataFormatString="dd/MM/yyyy"
										EnableHeaderContextMenu="True" Exportable="True" FilterDateFormat="dd/MM/yyyy" FilterDelay="2000" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn11" HeaderStyle-Width="103" HeaderText="<%$ Resources: GridColumn11 %>"
										ItemStyle-CssClass="c_GridColumn11" ItemStyle-Width="96" MaxLength="10" PickerType="DatePicker" ReadOnly="False" ShowFilterIcon="True"
										ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn14" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="siglaSetorial" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="55"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn14" HeaderStyle-Width="90"
										HeaderText="<%$ Resources: GridColumn14 %>" ItemStyle-CssClass="c_GridColumn14" ItemStyle-Width="83" MaxLength="10" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn17" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="nomeSobrenome" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="108"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn17" HeaderStyle-Width="143"
										HeaderText="<%$ Resources: GridColumn17 %>" ItemStyle-CssClass="c_GridColumn17" ItemStyle-Width="136" MaxLength="50" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn21" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="percentualExecutado" DataFormatString="{0:##0.00}" EnableHeaderContextMenu="True"
										Exportable="True" FilterControlWidth="58" FilterDelay="2000" FooterStyle-HorizontalAlign="Right" ForceExtractValue="Always"
										HeaderStyle-CssClass="c_GridColumn21" HeaderStyle-HorizontalAlign="Right" HeaderStyle-Width="93" HeaderText="<%$ Resources: GridColumn21 %>"
										ItemStyle-CssClass="c_GridColumn21" ItemStyle-HorizontalAlign="Right" ItemStyle-Width="86" MaxLength="6" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GridColumn24" runat="server" AllowFiltering="True" AllowSorting="true" AutoPostBackOnFilter="False"
										ConvertEmptyStringToNull="False" DataField="situacao" EnableHeaderContextMenu="True" Exportable="True" FilterControlWidth="58"
										FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GridColumn24" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GridColumn24 %>" ItemStyle-CssClass="c_GridColumn24" ItemStyle-Width="86" MaxLength="20" ReadOnly="False"
										ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridBoundColumn UniqueName="GrdStatusSituacao" runat="server" AllowFiltering="True" AllowSorting="true"
										AutoPostBackOnFilter="False" ConvertEmptyStringToNull="False" DataField="situacaoProjeto" EnableHeaderContextMenu="True" Exportable="True"
										FilterControlWidth="58" FilterDelay="2000" ForceExtractValue="Always" HeaderStyle-CssClass="c_GrdStatusSituacao" HeaderStyle-Width="93"
										HeaderText="<%$ Resources: GrdStatusSituacao %>" ItemStyle-CssClass="c_GrdStatusSituacao" ItemStyle-Width="86" MaxLength="14"
										ReadOnly="False" ShowFilterIcon="True" ShowSortIcon="True" />
									<telerik:GridButtonColumn UniqueName="GridColumn23" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn23" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn23" HeaderStyle-Width="73" HeaderText="<%$ Resources: GridColumn23 %>" ItemStyle-CssClass="c_GridColumn23"
										ItemStyle-Width="66" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn23_1 %>" />
									<telerik:GridButtonColumn UniqueName="GridColumn22" runat="server" AutoPostBackOnFilter="False" ButtonType="PushButton"
										CommandName="GridColumn22" EnableHeaderContextMenu="True" Exportable="True" FilterDelay="2000" Groupable="false"
										HeaderStyle-CssClass="c_GridColumn22" HeaderStyle-Width="43" HeaderText="<%$ Resources: GridColumn22 %>" ItemStyle-CssClass="c_GridColumn22"
										ItemStyle-Width="36" ShowFilterIcon="True" ShowSortIcon="True" Text="<%$ Resources: GridColumn22_1 %>" />
									<telerik:GridTemplateColumn Exportable="false" AllowFiltering="false"></telerik:GridTemplateColumn>
								</Columns>
								<CommandItemSettings ShowAddNewRecordButton="False" ShowRefreshButton="True" AddNewRecordText="" RefreshText="" />
							</MasterTableView>
							<PagerStyle Mode="NextPrevAndNumeric" />
							<ClientSettings EnableRowHoverStyle="true">
								<ClientEvents OnGridCreated="Grid2Created" />
							</ClientSettings>
						</telerik:RadGrid>
					</div>
					<div id="Div5" runat="server" AutoExpandToContent="False" AutoExpandToContentMargin="10" class="c_Div5">
						<telerik:RadTextBox id="RadTextBox1" runat="server" AutoPostBack="False" CssClass="c_RadTextBox1"
							data-validation-engine="validate[funcCall[RadTextBox1_Validation]]" data-validation-message="Código do Projeto não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox1_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="11" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox1_wrapper" />
						<telerik:RadLabel id="Label1" runat="server" CssClass="c_Label1" Text="<%$ Resources: Label1 %>" />
						<telerik:RadTextBox id="RadTextBox2" runat="server" AutoPostBack="False" CssClass="c_RadTextBox2"
							data-validation-engine="validate[funcCall[RadTextBox2_Validation]]" data-validation-message="Item do Projeto não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="5"
							onkeydown="___RadTextBox2_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="1" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox2_wrapper" />
						<telerik:RadLabel id="Label2" runat="server" CssClass="c_Label2" Text="<%$ Resources: Label2 %>" />
						<telerik:RadTextBox id="RadTextBox3" runat="server" AutoPostBack="False" CssClass="c_RadTextBox3"
							data-validation-engine="validate[funcCall[RadTextBox3_Validation]]" data-validation-message="Nome da Ação não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="255"
							onkeydown="___RadTextBox3_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="2" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox3_wrapper" />
						<telerik:RadLabel id="Label3" runat="server" CssClass="c_Label3" Text="<%$ Resources: Label3 %>" />
						<telerik:RadDatePicker id="DatePicker1" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation" CssClass="c_DatePicker1"
							ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
							EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight"
							ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="3" Width="152">
							<DateInput data-validation-engine="validate[funcCall[DatePicker1_Validation]]" data-validation-message="Início Previsto não pode ser vazio!" />
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label4" runat="server" CssClass="c_Label4" Text="<%$ Resources: Label4 %>" />
						<telerik:RadDatePicker id="DatePicker2" runat="server" Calendar-ClientEvents-OnDateClick="HideDatePickerValidation" CssClass="c_DatePicker2"
							ClientEvents-OnDateSelected="setDatePickerFocus" DateInput-DateFormat="dd/MM/yyyy" DatePickerType="Date" DatePopupButton-ToolTip="Select date"
							EnableEmbeddedSkins="True" Height="32" HideAnimation-Duration="300" HideAnimation-Type="Fade" MinDate="01/01/1900" PopupDirection="BottomRight"
							ReadOnly="False" RenderMode="Lightweight" ShowAnimation-Duration="300" ShowAnimation-Type="Fade" TabIndex="4" Width="152">
							<DateInput data-validation-engine="validate[funcCall[DatePicker2_Validation]]" data-validation-message="Fim Previsto não pode ser vazio!" />
						</telerik:RadDatePicker>
						<telerik:RadLabel id="Label5" runat="server" CssClass="c_Label5" Text="<%$ Resources: Label5 %>" />
						<telerik:RadTextBox id="RadTextBox8" runat="server" AutoPostBack="False" CssClass="c_RadTextBox8"
							data-validation-engine="validate[funcCall[RadTextBox8_Validation]]" data-validation-message="Coordenação não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10"
							onkeydown="___RadTextBox8_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="6" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox8_wrapper" />
						<telerik:RadLabel id="Label12" runat="server" CssClass="c_Label12" Text="<%$ Resources: Label12 %>" />
						<telerik:RadTextBox id="RadTextBox9" runat="server" AutoPostBack="False" CssClass="c_RadTextBox9" EnabledStyle-HorizontalAlign="Left"
							EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="10" onkeydown="___RadTextBox9_onkeydown();" ReadOnly="False"
							RenderMode="Lightweight" TabIndex="7" TextMode="SingleLine" WrapperCssClass="c_RadTextBox9_wrapper" />
						<telerik:RadLabel id="Label13" runat="server" CssClass="c_Label13" Text="<%$ Resources: Label13 %>" />
						<telerik:RadTextBox id="RadTextBox13" runat="server" AutoPostBack="False" CssClass="c_RadTextBox13" EnabledStyle-HorizontalAlign="Right"
							EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="3" onkeydown="___RadTextBox13_onkeydown();" ReadOnly="False"
							RenderMode="Lightweight" TabIndex="10" TextMode="SingleLine" WrapperCssClass="c_RadTextBox13_wrapper" />
						<telerik:RadLabel id="Label18" runat="server" CssClass="c_Label18" Text="<%$ Resources: Label18 %>" />
						<telerik:RadTextBox id="RadTextBox4" runat="server" AutoPostBack="False" CssClass="c_RadTextBox4"
							data-validation-engine="validate[funcCall[RadTextBox4_Validation]]" data-validation-message="Responsável não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Left" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="50"
							onkeydown="___RadTextBox4_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="5" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox4_wrapper" />
						<telerik:RadLabel id="Label7" runat="server" CssClass="c_Label7" Text="<%$ Resources: Label7 %>" />
						<telerik:RadTextBox id="RadTextBox10" runat="server" AutoPostBack="False" CssClass="c_RadTextBox10" EnabledStyle-HorizontalAlign="Right"
							EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="6" onkeydown="___RadTextBox10_onkeydown();" ReadOnly="False"
							RenderMode="Lightweight" TabIndex="8" TextMode="SingleLine" WrapperCssClass="c_RadTextBox10_wrapper" />
						<telerik:RadLabel id="Label14" runat="server" CssClass="c_Label14" Text="<%$ Resources: Label14 %>" />
						<telerik:RadTextBox id="RadTextBox11" runat="server" AutoPostBack="False" CssClass="c_RadTextBox11"
							data-validation-engine="validate[funcCall[RadTextBox11_Validation]]" data-validation-message="Data do Cadastro não pode ser vazio!"
							EnabledStyle-HorizontalAlign="Right" EnableSingleInputRendering="True" ForeColor="#000000" MaxLength="15"
							onkeydown="___RadTextBox11_onkeydown();" ReadOnly="False" RenderMode="Lightweight" TabIndex="9" TextMode="SingleLine"
							WrapperCssClass="c_RadTextBox11_wrapper" />
						<telerik:RadLabel id="Label15" runat="server" CssClass="c_Label15" Text="<%$ Resources: Label15 %>" />
					</div>
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
					setTimeout("var $j = jQuery.noConflict();$j('#RadTextBox2').first().focus();", 200);
				}
			}
			catch (e)
			{
			}
		}
		function projeto() { return document.getElementById('RadTextBox1').value; }
		function itemProjeto() { return document.getElementById('RadTextBox2').value; }
		function nomeAcao() { return document.getElementById('RadTextBox3').value; }
		function inicioPrevisto() { return document.getElementById('DatePicker1').value; }
		function terminoPrevisto() { return document.getElementById('DatePicker2').value; }
		function siglaCoordenacao() { return document.getElementById('RadTextBox8').value; }
		function siglaSetorial() { return document.getElementById('RadTextBox9').value; }
		function DiasPrevistos() { return document.getElementById('RadTextBox13').value; }
		function nomeSobrenome() { return document.getElementById('RadTextBox4').value; }
		function percentualExecutado() { return document.getElementById('RadTextBox10').value; }
		function statusAcao() { return document.getElementById('RadTextBox11').value; }
		function ShowClientFormulas(ShowServerFormulas)
		{
		}

	</script>

</telerik:RadCodeBlock>
</html>
<noscript>Please enable JavaScript in your browser!</noscript>


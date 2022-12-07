<%@ Page Language="C#" AutoEventWireup="true" CodeFile="RelatorioMetas.aspx.cs" Inherits="PROJETO.Reports.RelatorioMetas" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register TagPrefix="telerikreport" Assembly="Telerik.ReportViewer.WebForms" Namespace="Telerik.ReportViewer.WebForms" %>

<!DOCTYPE>
<html>
<head runat="server">
	<title>Relatório de Diretrizes e Metas</title>
</head>
<script type="text/javascript" src="../../JS/Common.js"></script>
<script type="text/javascript" src="../../JS/jquery.js"></script>
<script type="text/javascript" src="../../JS/iframeResizer.min.js" ></script>
<script type="text/javascript" src="../../JS/iframeResizer.contentWindow.min.js" ></script>

<body style="margin:0px;padding:0px;overflow:auto">
	<form id="form1" runat="server">
		<div runat="server" id="__MainDiv" style="overflow: hidden; background-color:White;min-width:800px;min-height:1250px;padding:2px;">
			<telerikreport:ReportViewer ID="TelerikReportViewer1" runat="server" SizeToReportContent="true" BorderWidth="1" BorderColor="Gray" ZoomMode="PageWidth" Width="100%" Height="1250px"/>
			<script type="text/javascript">
                ReportViewer.prototype.PrintReport = function () {
                    switch (this.defaultPrintFormat) {
                        case "Default":
                            this.DefaultPrint();
                            break;
                        case "PDF":
                            this.PrintAs("PDF");
                            previewFrame = document.getElementById(this.previewFrameID);
                            previewFrame.onload = function () { previewFrame.contentDocument.execCommand("print", true, null); }
                            break;
                    }
                };
            </script>			
		</div>
		<asp:Label ID="ReportError" runat="server" Visible="false" Text="Label"></asp:Label>
	</form>
</body>
</html>

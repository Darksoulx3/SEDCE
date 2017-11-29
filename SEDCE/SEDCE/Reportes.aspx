<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="SEDCE.Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Reporteador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <div style="margin-top:30px">
            <div style="margin-right:48px">
                <asp:Label ID="lblTipodeReporte" runat="server" Text="Tipo de reporte: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoReporte" runat="server" Width="200px" >
                    <asp:ListItem>ALUMNOS DE NUEVO INGRESO LICENCIATURA.</asp:ListItem>
                    <asp:ListItem>EGRESADOS DE LICENCIATURA.</asp:ListItem>
                    <asp:ListItem>MATRICULA TOTAL DE LICENCIATURA.</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera: "></asp:Label>
                <asp:DropDownList ID="ddlCarrera" runat="server" Width="200px">
                    <asp:ListItem>TODAS</asp:ListItem>
                    <asp:ListItem>ING. BIOMEDICA</asp:ListItem>
                    <asp:ListItem>ING. EN INFORMATICA</asp:ListItem>
                    <asp:ListItem>ING. IND. 100 INGLES</asp:ListItem>
                    <asp:ListItem>INGENIERIA ELECTRICA</asp:ListItem>
                    <asp:ListItem>INGENIERIA ELECTRONICA</asp:ListItem>
                    <asp:ListItem>INGENIERIA EN GESTION EMPRESARIAL</asp:ListItem>
                    <asp:ListItem>INGENIERIA EN SISTEMAS COMPUTACIONALES</asp:ListItem>
                    <asp:ListItem>INGENIERIA INDUSTRIAL</asp:ListItem>
                    <asp:ListItem>INGENIERIA MECANICA</asp:ListItem>
                    <asp:ListItem>INGENIERIA MECATRONICA</asp:ListItem>
                    <asp:ListItem>LICENCIATURA EN ADMINISTRACION</asp:ListItem>
                    <asp:ListItem>MAESTRIA EN ADMINISTRACION</asp:ListItem>
                    <asp:ListItem>MAESTRIA EN CIENCIAS DE LA COMPUTACION</asp:ListItem>
                    <asp:ListItem>MAESTRIA EN INGENIERIA ELECTRONICA</asp:ListItem>
                    <asp:ListItem>MAESTRIA EN INGENIERIA INDUSTRIAL</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SEDCEConString %>" SelectCommand="SELECT [nombre_carrera] FROM [carrera] ORDER BY [id_carrera]"></asp:SqlDataSource>
            </div>
            <div style="margin-right:0px; margin-top:30px">
                <asp:Label ID="lblPeriodo" runat="server" Text="Periodo: " ></asp:Label>
                <asp:DropDownList ID="ddlPeriodo" runat="server" Width="200px">
                    <asp:ListItem>2017-1</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:2px;margin-top:30px">
                <asp:Label ID="lblFormato" runat="server" Text="Formato: " ></asp:Label>
                <asp:DropDownList ID="ddlFormato" runat="server" Width="200px">
                    <asp:ListItem>PDF</asp:ListItem>
                    <asp:ListItem>WORD</asp:ListItem>
                    <asp:ListItem>EXCEL</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnReporte" runat="server" Text="Ver reporte" OnClick="btnReporte_Click" />
            </div>
            <div>
            </div>
        </div>
    </div>
</asp:Content>
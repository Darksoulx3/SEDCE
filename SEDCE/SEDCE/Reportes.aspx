<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="SEDCE.Reportes" %>

<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Reporteador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <div style="margin-top:30px">
            <div>
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera: "></asp:Label>
                <asp:DropDownList ID="ddlCarrera" runat="server" Width="200px" DataSourceID="SqlDataSource" DataTextField="nombre_carrera" DataValueField="nombre_carrera" OnSelectedIndexChanged="ddlCarrera_SelectedIndexChanged"></asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SEDCEConString %>" SelectCommand="SELECT [nombre_carrera] FROM [carrera] ORDER BY [id_carrera]"></asp:SqlDataSource>
            </div>
            <div style="margin-right:48px; margin-top:30px">
                <asp:Label ID="lblTipodeReporte" runat="server" Text="Tipo de reporte: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoReporte" runat="server" Width="200px" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged">
                    <asp:ListItem>ALUMNOS DE NUEVO INGRESO LIC. Y POS.</asp:ListItem>
                    <asp:ListItem>EGRESADOS DE LIC. Y POS.</asp:ListItem>
                    <asp:ListItem>MATRICULA TOTAL DE LIC. Y POS.</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:0px; margin-top:30px">
                <asp:Label ID="lblPeriodo" runat="server" Text="Periodo: " ></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px" OnSelectedIndexChanged="ddlTipoReporte_SelectedIndexChanged">
                    <asp:ListItem>2017-1</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:2px;margin-top:30px">
                <asp:Label ID="lblFormato" runat="server" Text="Formato: " ></asp:Label>
                <asp:DropDownList ID="ddlFormato" runat="server" Width="200px" OnSelectedIndexChanged="ddlFormato_SelectedIndexChanged">
                    <asp:ListItem>PDF</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnReporte" runat="server" Text="Crear reporte" OnClick="btnReporte_Click" />
            </div>
            <div>
            </div>
        </div>
    </div>
</asp:Content>
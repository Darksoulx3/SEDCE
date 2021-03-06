﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="SEDCE.Reportes" %>

<%--<%@ Register Assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" Namespace="Microsoft.Reporting.WebForms" TagPrefix="rsweb" %>--%>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Reporteador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <div style="margin-top:30px">
            <div style="margin-right:12px">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria: " ></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                    <asp:ListItem>NUEVO INGRESO</asp:ListItem>
                    <asp:ListItem>MATRICULA TOTAL</asp:ListItem>
                    <asp:ListItem>ESTADISTICAS</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:46px; margin-top:30px">
                <asp:Label ID="lblReporte" runat="server" Text="Tipo de reporte: " ></asp:Label>
                <asp:DropDownList ID="ddlReporte" runat="server" Width="200px" AutoPostBack="true" OnSelectedIndexChanged="ddlReporte_SelectedIndexChanged">
                    <asp:ListItem>SEXO POR CARRERA</asp:ListItem>
                    <asp:ListItem>EDAD POR CARRERA</asp:ListItem>
                    <%--<asp:ListItem>PROCEDENCIA POR CARRERA</asp:ListItem>--%>
                </asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <div>
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera: "></asp:Label>
                <asp:DropDownList ID="ddlCarrera" runat="server" Width="200px">
                    <asp:ListItem>TODAS</asp:ListItem>
                    <asp:ListItem>INGENIERIA BIOMEDICA</asp:ListItem>
                    <asp:ListItem>INGENIERIA EN INFORMATICA</asp:ListItem>
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
                    </div>
                <div style="margin-top:30px">
                <asp:Label ID="lblPeriodo" runat="server" Text="Periodo: " Visible="false"></asp:Label>
                <asp:DropDownList ID="ddlPeriodo" runat="server" Visible="false" Width="200px">
                    <asp:ListItem>20102</asp:ListItem>
                    <asp:ListItem>20111</asp:ListItem>
                    <asp:ListItem>20112</asp:ListItem>
                    <asp:ListItem>20121</asp:ListItem>
                    <asp:ListItem>20122</asp:ListItem>
                    <asp:ListItem>20131</asp:ListItem>
                    <asp:ListItem>20132</asp:ListItem>
                    <asp:ListItem>20141</asp:ListItem>
                    <asp:ListItem>20142</asp:ListItem>
                </asp:DropDownList>
                <asp:SqlDataSource ID="SqlDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:SEDCEConString %>" SelectCommand="SELECT [nombre_carrera] FROM [carrera] ORDER BY [id_carrera]"></asp:SqlDataSource>
                    </div>
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
                <asp:Button ID="btnReporte" runat="server" Text="Generar Reporte" OnClick="btnReporte_Click" OnClientClick="return confirm('Seguro que desea generar el reporte con las caracteristicas seleccionadas?')" />
            </div>
            <div>
            </div>
        </div>
    </div>
</asp:Content>
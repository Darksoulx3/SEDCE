<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Graficas.aspx.cs" Inherits="SEDCE.Graficas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Graficador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
            <div style="margin-right:14px">
                <asp:Label ID="lblCategoria" runat="server" Text="Categoria: " ></asp:Label>
                <asp:DropDownList ID="ddlCategoria" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlCategoria_SelectedIndexChanged">
                    <asp:ListItem>NUEVO INGRESO</asp:ListItem>
                    <asp:ListItem>MATRICULA TOTAL</asp:ListItem>
                    <asp:ListItem>ESTADISTICAS</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:49px; margin-top:30px">
                <asp:Label ID="lblTipodeGrafica" runat="server" Text="Tipo de Grafica: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoGrafica" runat="server" Width="200px" AutoPostBack="True" OnSelectedIndexChanged="ddlTipoGrafica_SelectedIndexChanged">
                    <asp:ListItem>SEXO POR CARRERA</asp:ListItem>
                    <asp:ListItem>EDAD POR CARRERA</asp:ListItem>
                </asp:DropDownList>
            </div>
        <div style="margin-top:30px; margin-left:1px">
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
                    <asp:ListItem>MAESTRIA EN ELECTRONICA</asp:ListItem>
                    <asp:ListItem>MAESTRIA EN INGENIERIA INDUSTRIAL</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:60px;margin-top:30px">
                <asp:Label ID="lblEstilo" runat="server" Text="Estilo de gráfica: " ></asp:Label>
                <asp:DropDownList ID="ddlEstiloGrafica" runat="server" Width="200px">
                    <asp:ListItem>COLUMNAS</asp:ListItem>
                    <asp:ListItem>PUNTOS</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-left:2px;margin-top:30px">
                <asp:Label ID="lblPeriodo" runat="server" Text="Periodo: " Visible="False" ></asp:Label>
                <asp:DropDownList ID="ddlPeriodo" runat="server" Width="200px" Visible="False">
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
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnReport" runat="server" Text="Generar Grafica" OnClick="btnReporte_Click" />
            </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Graficas.aspx.cs" Inherits="SEDCE.Graficas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Graficador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
            
            <div style="margin-right:49px; margin-top:30px">
                <asp:Label ID="lblTipodeGrafica" runat="server" Text="Tipo de Grafica: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoReporte" runat="server" Width="200px">
                    <asp:ListItem>INDICE DE REPROBACÍON.</asp:ListItem>
                    <asp:ListItem>EFICIENCIA DE EGRESOS.</asp:ListItem>
                    <asp:ListItem>EFICIENCIA DE TERMINACÍON.</asp:ListItem>
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
            </div>
            <div style="margin-right:49px;margin-top:30px">
                <asp:Label ID="lblTipoGrafica" runat="server" Text="Estilo de gráfica: " ></asp:Label>
                <asp:DropDownList ID="ddlEstiloGrafica" runat="server" Width="200px">
                    <asp:ListItem>COLUMNAS</asp:ListItem>
                    <asp:ListItem>PUNTOS</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-right:3px;margin-top:30px">
                <asp:Label ID="lblFormato" runat="server" Text="Periodo: " ></asp:Label>
                <asp:DropDownList ID="ddlPeriodo" runat="server" Width="200px">
                    <asp:ListItem>17-1</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnReport" runat="server" Text="Generar Grafica" OnClick="btnReporte_Click" />
            </div>
    </div>
</asp:Content>
<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Graficas.aspx.cs" Inherits="SEDCE.Graficas" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Graficador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
            <div style="margin-top:30px">
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera: "></asp:Label>
                <asp:DropDownList ID="ddlCarrera" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-right:49px; margin-top:30px">
                <asp:Label ID="lblTipodeReporte" runat="server" Text="Tipo de reporte: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoReporte" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-right:49px;margin-top:30px">
                <asp:Label ID="lblTipoGrafica" runat="server" Text="Tipo de gráfica: " ></asp:Label>
                <asp:DropDownList ID="DropDownList1" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-right:3px;margin-top:30px">
                <asp:Label ID="lblFormato" runat="server" Text="Formato: " ></asp:Label>
                <asp:DropDownList ID="ddlFormato" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnReporte" runat="server" Text="Crear reporte" />
            </div>
    </div>
</asp:Content>
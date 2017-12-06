<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Menu.ascx.cs" Inherits="SEDCE.Menu" %>

<asp:Menu ID="Menu1" runat="server" Orientation="Horizontal" StaticMenuItemStyle-HorizontalPadding="10px">
    <Items>
        <asp:MenuItem Text="Inicio" NavigateUrl="~/Inicio.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Graficador" NavigateUrl="~/Graficas.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Reporteador" NavigateUrl="~/Reportes.aspx"></asp:MenuItem>
        <%--<asp:MenuItem Text="Seguro Social" NavigateUrl="~/SeguroSocial.aspx"></asp:MenuItem>--%>
        <asp:MenuItem Text="Carga de Archivos" NavigateUrl="~/Info.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Configuraciones" NavigateUrl="~/Configuraciones.aspx"></asp:MenuItem>
        <asp:MenuItem Text="Inicio de Sesion" NavigateUrl="~/Login.aspx"></asp:MenuItem>
    </Items>

</asp:Menu>

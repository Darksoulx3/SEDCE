<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Reportes.aspx.cs" Inherits="SEDCE.Reportes" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Reporteador" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <form id="frm" runat="server" style="margin-top:30px">
            <div>
                <asp:Label ID="lblCarrera" runat="server" Text="Carrera: "></asp:Label>
                <asp:DropDownList ID="ddlCarrera" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-right:48px; margin-top:30px">
                <asp:Label ID="lblTipodeReporte" runat="server" Text="Tipo de reporte: " ></asp:Label>
                <asp:DropDownList ID="ddlTipoReporte" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-right:2px;margin-top:30px">
                <asp:Label ID="lblFormato" runat="server" Text="Formato: " ></asp:Label>
                <asp:DropDownList ID="ddlFormato" runat="server" Width="200px"></asp:DropDownList>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnReporte" runat="server" Text="Crear reporte" />
            </div>
        </form>
    </div>
</asp:Content>
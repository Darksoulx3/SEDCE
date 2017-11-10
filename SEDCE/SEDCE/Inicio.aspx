<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Inicio.aspx.cs" Inherits="SEDCE.Inicio" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Inicio" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:100px">
        <asp:Label ID="lblInicio" runat="server" Text="Bienvenido al sistema estadístico de control escolar, favor de iniciar sesión." Font-Size="Large"></asp:Label>
    </div>
</asp:Content>

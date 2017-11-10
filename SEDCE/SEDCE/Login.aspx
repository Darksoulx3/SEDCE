<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="SEDCE.Login" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Inicio de sesión" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <form id="frm" runat="server" style="margin-top:30px">
            <div>
                <asp:Label ID="lblUsuario" runat="server" Text="Usuario: "></asp:Label>
                <asp:TextBox ID="txtBUsuario" runat="server" Width="200px"></asp:TextBox>
            </div>
            <div style="margin-right:30px; margin-top:30px">
                <asp:Label ID="lblPassword" runat="server" Text="Contraseña: " ></asp:Label>
                <asp:TextBox ID="txtxBPassword" runat="server" Width="200px" TextMode="Password"></asp:TextBox>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnInicioSesion" runat="server" Text="Iniciar sesión" />
            </div>
        </form>
    </div>
</asp:Content>
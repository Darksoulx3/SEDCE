<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="SEDCE.Configuraciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
     <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Configuración de cuentas" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center;">
            <br />
        <br />
        <br />
        <div>
                <asp:Button ID="btnAlta" Text="Alta" runat="server" BorderStyle="Groove" Width="100px" BackColor="White" OnClick="btnAlta_Click" />
                <asp:Button ID="btnBaja" Text="Baja" runat="server" BorderStyle="Groove" Width="100px" BackColor="White" OnClick="btnBaja_Click"/>
                <asp:Button ID="btnCambio" Text="Cambio" runat="server" BorderStyle="Groove" Width="100px" BackColor="White" OnClick="btnCambio_Click"/>

        </div>
        
        <div>
            <br />
            <asp:DropDownList ID="ddlUsuarios" runat="server"></asp:DropDownList>
            <br />
            <br />
            <br />
        </div>

        <div>
            <div>
                <asp:Label ID="lblnUsuario" Text="Nombre de Usuario" runat="server" />
            </div>

            <div>
                <asp:TextBox ID="tbxUsuario" runat="server"></asp:TextBox>
            </div>
        </div>

        <div>
            <br />
            <div>
                <asp:Label ID="lblnContraseña" Text="Contraseña" runat="server" />
            </div>
            <div>
                <asp:TextBox ID="tbxPassword" runat="server"></asp:TextBox>
            </div>
        </div>

        <div>
            <br />
            <br />
            <br />
            <asp:Button ID="btnAceptarCambioUsuario" Text="Aceptar" runat="server" />
        </div>     
    </div>
</asp:Content>

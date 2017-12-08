<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Configuraciones.aspx.cs" Inherits="SEDCE.Configuraciones" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
     <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Configuración de cuentas" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center;">
        <div style="margin-top:30px">
                <asp:Button ID="btnAlta" Text="Alta" runat="server" BorderStyle="Groove" Width="100px" BackColor="LightSkyBlue" OnClick="btnAlta_Click" />
                <asp:Button ID="btnBaja" Text="Baja" runat="server" BorderStyle="Groove" Width="100px" BackColor="White" OnClick="btnBaja_Click"/>
                <asp:Button ID="btnCambio" Text="Cambio" runat="server" BorderStyle="Groove" Width="100px" BackColor="White" OnClick="btnCambio_Click"/>

        </div>
        
        <div style="margin-top:30px">
            <asp:DropDownList ID="ddlUsuarios" runat="server" Visible="False" AutoPostBack="True"></asp:DropDownList>
        </div>

        <div>
            <div style="margin-top:30px">
                <asp:Label ID="lblnUsuario" Text="Nombre de Usuario" runat="server" />
            </div>

            <div>
                <asp:TextBox ID="tbxUsuario" runat="server" AutoPostBack="True" OnTextChanged="tbxUsuario_TextChanged"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblUsuarioError" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
        </div>

        <div>
            <div style="margin-top:30px">
                <asp:Label ID="lblnContraseña" Text="Contraseña" runat="server" />
            </div>
            <div>
                <asp:TextBox ID="tbxPassword" runat="server" AutoPostBack="True" OnTextChanged="tbxPassword_TextChanged" TextMode="Password"></asp:TextBox>
            </div>
            <div>
                <asp:Label ID="lblMensaje" runat="server" Text="Se requiere almenos:" Visible="False"></asp:Label>
                <div>
                    <asp:Label ID="lblMay" runat="server" Text="1 Mayuscula" ForeColor="Red" Visible="False"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblNum" runat="server" Text="1 Numero" ForeColor="Red" Visible="False"></asp:Label>
                </div>
                <div>
                    <asp:Label ID="lblLong" runat="server" Text="Minimo 8 caracteres" ForeColor="Red" Visible="False"></asp:Label>
                </div>
            </div>
        </div>
        <div  style="margin-top:30px">
            <asp:Label ID="lblNivel" runat="server" Text="Nivel de usuario"></asp:Label>
        </div>
        <div>   
            <asp:DropDownList ID="ddlNivel" runat="server">
                <asp:ListItem>Administrador</asp:ListItem>
                <asp:ListItem>Gestor de BD</asp:ListItem>
                <asp:ListItem>Jefe de carrera</asp:ListItem>
                <%--<asp:ListItem>Auxiliar</asp:ListItem>--%>
            </asp:DropDownList>
        </div>
        <div style="margin-top:30px">
            <asp:Label ID="lblResultado" runat="server" Text=""></asp:Label>
        </div>

        <div >
            <asp:Button ID="btnAceptarCambioUsuario" Text="Crear Usuario" runat="server" OnClick="btnAceptarCambioUsuario_Click" OnClientClick ="return confirm('Seguro que desea agregar este usuario?')"/>
            <asp:Button ID="Button1" Text="Eliminar Usuario" runat="server" Visible="false" OnClick="Button1_Click" OnClientClick="return confirm('Seguro que desea eliminar al usuario seleccionado?')"/>
            <asp:Button ID="Button2" Text="Modificar Usuario" runat="server" Visible="false" OnClick="Button2_Click" OnClientClick="return confirm('Seguro que desea modificar el usuario seleccionado?')"/>
        </div>     
    </div>
</asp:Content>

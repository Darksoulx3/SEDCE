<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="SeguroSocial.aspx.cs" Inherits="SEDCE.SeguroSocial" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Seguro Social" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <div style="margin-top:30px">
            <div>
                <asp:Label ID="lblTipodeBusqueda" runat="server" Text="Seleccione el tipo de busqueda: "></asp:Label>
                <asp:DropDownList ID="ddlBusqueda" runat="server" Width="100px">
                    <asp:ListItem>NOMBRE</asp:ListItem>
                    <asp:ListItem>NO. DE CONTROL</asp:ListItem>
                </asp:DropDownList>
                <asp:TextBox ID="txtBBuscar" runat="server" Width="200px" OnTextChanged="txtBBuscar_TextChanged"></asp:TextBox>
                <asp:Button ID="btnBuscar" runat="server" Text="Buscar" />
            </div>
            <div style="margin-top:30px">
                <asp:GridView ID="gvNSS" runat="server" AutoGenerateColumns="False" Height="178px" Width="641px">
                    <Columns>
                        <asp:BoundField HeaderText="NOMBRE" ReadOnly="True" />
                        <asp:BoundField HeaderText="NO. DE CONTROL" ReadOnly="True" />
                        <asp:BoundField HeaderText="NUMERO DE SEGURO SOCIAL" ReadOnly="True" />
                    </Columns>
                </asp:GridView>
                <asp:SqlDataSource ID="DSSeguroSocial" runat="server"></asp:SqlDataSource>
            </div>
            <div style="margin-right:2px;margin-top:30px">
                <asp:Label ID="lblNSS" runat="server" Text="Escriba el numero de seguro social: " ></asp:Label>
                <asp:TextBox ID="txtBNSS" runat="server" Width="200px"></asp:TextBox>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnAgregar" runat="server" Text="Agregar NSS" />
                <asp:Button ID="btnModificar" runat="server" Text="Modificar NSS" />
            </div>
        </div>
    </div>
</asp:Content>
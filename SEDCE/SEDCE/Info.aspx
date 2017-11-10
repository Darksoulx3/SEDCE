<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="SEDCE.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Cargador de archivos" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <form id="frm" runat="server" style="margin-top:30px">
            <div>
                <asp:Label ID="lblSubirArchivo" runat="server" Text="Seleccione un archivo para cargar la base de datos: "></asp:Label>
                <asp:TextBox ID="txtBSubirArchivo" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="btnSubirArchivo" runat="server" Text="..." />
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnSubir" runat="server" Text="Subir datos" />
            </div>
            <div style="margin-top:70px">
                <asp:Label ID="Label1" runat="server" Text="Seleccione un arcivo para cargar la lista de seguro social: "></asp:Label>
                <asp:TextBox ID="TextBox1" runat="server" Width="200px"></asp:TextBox>
                <asp:Button ID="Button1" runat="server" Text="..." />
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="Button2" runat="server" Text="Subir datos" />
            </div>
        </form>
    </div>
</asp:Content>
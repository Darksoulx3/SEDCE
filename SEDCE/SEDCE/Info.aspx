<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Info.aspx.cs" Inherits="SEDCE.Info" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:30px" >
        <asp:Label ID="Titulo" runat="server" Text="Cargador de archivos" Font-Underline="true" Font-Size="X-Large"></asp:Label>
    </div>
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:60px">
        <div style="margin-top:30px">
            <div>
                <asp:Label ID="lblSubirArchivo" runat="server" Text="Seleccione un archivo para cargar la base de datos: "></asp:Label>
            </div>
            <div>
                <asp:Label ID="lblPeriodo" runat="server" Text="Seleccione un Periodo:"></asp:Label>
                <asp:DropDownList ID="ddlPeriodo1" runat="server">
                    <asp:ListItem Value="2010"></asp:ListItem>
                    <asp:ListItem Value="2011"></asp:ListItem>
                    <asp:ListItem Value="2012"></asp:ListItem>
                    <asp:ListItem Value="2013"></asp:ListItem>
                    <asp:ListItem Value="2014"></asp:ListItem>
                    <asp:ListItem Value="2015"></asp:ListItem>
                    <asp:ListItem Value="2016"></asp:ListItem>
                    <asp:ListItem Value="2017"></asp:ListItem>
                    <asp:ListItem Value="2018"></asp:ListItem>
                    <asp:ListItem Value="2019"></asp:ListItem>
                </asp:DropDownList>
                <asp:Label ID="lblSeparador" runat="server" Text=" - "></asp:Label>
                <asp:DropDownList ID="ddlPeriodo2" runat="server">
                    <asp:ListItem>1</asp:ListItem>
                    <asp:ListItem>2</asp:ListItem>
                    <asp:ListItem>3</asp:ListItem>
                </asp:DropDownList>
            </div>
            <div>
                <asp:FileUpload ID="fuBD" runat="server"/>
            </div>
            <div>
                <asp:Label ID="lblResultado" runat="server" Text="" ForeColor="Red"></asp:Label>
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="btnSubir" runat="server" Text="Subir datos" OnClick="btnSubir_Click" />
            </div>
            <div style="margin-top:70px">
                <asp:Label ID="Label1" runat="server" Text="Seleccione un arcivo para cargar la lista de seguro social: "></asp:Label>
            </div>
            <div>
                <asp:Button ID="Button1" runat="server" Text="..." />
            </div>
            <div style="margin-top:30px">
                <asp:Button ID="Button2" runat="server" Text="Subir datos" />
            </div>
        </div>
    </div>
</asp:Content>
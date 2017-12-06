<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Grafo.aspx.cs" Inherits="SEDCE.Grafo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:10px">
            <asp:Chart ID="Chart1" runat="server" Height="519px" OnLoad="Chart1_Load" Width="623px" BorderlineColor="Red" BorderlineDashStyle="Solid" BorderlineWidth="3" Palette="None" PaletteCustomColors="Red; LightSkyBlue; Yellow" BackSecondaryColor="Silver" IsMapEnabled="False" IsSoftShadows="False">
                <series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
                <BorderSkin BackColor="Gainsboro" BorderColor="Gainsboro" />
            </asp:Chart>
        </div>
        <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:10px">
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" Font-Size="Medium" OnClick="btnExportar_Click"/>
        </div>
</asp:Content>

﻿<%@ Page Title="" Language="C#" MasterPageFile="~/Site1.Master" AutoEventWireup="true" CodeBehind="Grafo.aspx.cs" Inherits="SEDCE.Grafo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentCol2" runat="server">
    <div style="margin-left:no; margin-right:auto; text-align:center; margin-top:10px">
            <asp:Chart ID="Chart1" runat="server" Height="716px" OnLoad="Chart1_Load" Width="900px" BorderlineColor="Red" BorderlineDashStyle="Solid" BorderlineWidth="3" Palette="None" BackSecondaryColor="Silver" IsMapEnabled="False" IsSoftShadows="False">
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">        
                    </asp:ChartArea>
                </chartareas>
                <BorderSkin BackColor="Gainsboro" BorderColor="Gainsboro" />
            </asp:Chart>
        </div>
        <div style="margin-left:auto; margin-right:auto; text-align:center; margin-top:10px; width: 899px;">
            <asp:Button ID="btnExportar" runat="server" Text="Exportar" Font-Size="Medium" OnClick="btnExportar_Click"/>
        </div>
</asp:Content>

<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Grafo.aspx.cs" Inherits="SEDCE.Grafo" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
<meta http-equiv="Content-Type" content="text/html; charset=utf-8"/>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <asp:Chart ID="Chart1" runat="server" Height="519px" OnLoad="Chart1_Load" Width="623px" BorderlineColor="Red" BorderlineDashStyle="Solid" BorderlineWidth="3" Palette="None" PaletteCustomColors="Red">
                <series>
                    <asp:Series Name="Series1" ChartType="Line" YValuesPerPoint="6">
                    </asp:Series>
                    <asp:Series Name="Series2" ChartType="Line" YValuesPerPoint="6">
                    </asp:Series>
                    <asp:Series Name="Series3" ChartType="Line" YValuesPerPoint="6">
                    </asp:Series>
                    <asp:Series Name="Series4" ChartType="Line" YValuesPerPoint="6">
                    </asp:Series>
                    <asp:Series Name="Series5" ChartType="Line" YValuesPerPoint="6">
                    </asp:Series>
                </series>
                <chartareas>
                    <asp:ChartArea Name="ChartArea1">
                    </asp:ChartArea>
                </chartareas>
            </asp:Chart>
        </div>
    </form>
</body>
</html>

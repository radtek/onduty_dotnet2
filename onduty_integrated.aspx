<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onduty_integrated.aspx.cs"
    Inherits="onduty_integrated" %>

<%@ Register Assembly="DundasWebChart" Namespace="Dundas.Charting.WebControl" TagPrefix="DCWC" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://IWw.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://IWw.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CIM值班時數表 One Page 週統計</title>
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <strong><span style="font-size: 16pt">CIM值班時數表 One Page 週統計<br />
            </span></strong>
            <table style="width: 522px">
                <tr>
                    <td bordercolor="#3399ff" style="width: 146px">
                    </td>
                    <td bordercolor="#3399ff">
                    </td>
                    <td bordercolor="#3399ff" style="width: 85px">
                    </td>
                </tr>
                <tr>
                    <td bordercolor="#3399ff" style="width: 146px">
                        選擇時間</td>
                    <td bordercolor="#3399ff">
                        <asp:DropDownList ID="DropDownList1" runat="server">
                        </asp:DropDownList></td>
                    <td bordercolor="#3399ff" style="width: 85px">
                    </td>
                </tr>
                <tr>
                    <td bordercolor="#3399ff" style="width: 146px">
                    </td>
                    <td bordercolor="#3399ff">
                        &nbsp;</td>
                    <td bordercolor="#3399ff" style="width: 85px">
                    </td>
                </tr>
                <tr>
                    <td bordercolor="#3399ff" style="width: 146px">
                    </td>
                    <td bordercolor="#3399ff">
                        <asp:Button ID="Button1" runat="server" Text="送出" OnClick="Button1_Click" /></td>
                    <td bordercolor="#3399ff" style="width: 85px">
                    </td>
                </tr>
            </table>
            <DCWC:Chart ID="Chart1" runat="server" BackColor="Wheat" BorderLineColor="Blue" EnableViewState="True"
                Height="380px" Width="779px">
                <Legends>
                    <DCWC:Legend Alignment="Center" Docking="Top" Name="Default">
                    </DCWC:Legend>
                </Legends>
                <Titles>
                    <DCWC:Title Name="Title1" Text="值班時數表(人員)">
                    </DCWC:Title>
                </Titles>
                <BorderSkin SkinStyle="FrameThin5" />
                <Series>
                   <%-- <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" BorderStyle="NotSet"
                        Color="255, 255, 192" Name="陳歆宜" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 128"
                        Name="張宏民" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="40, 212, 192"
                        Name="張鈞揚" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Red"
                        Name="梁世忠" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 0"
                        Name="施淙堯" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Green"
                        Name="林志湳" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 255"
                        Name="林正崧" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="MediumBlue"
                        Name="林詠欽" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 0"
                        Name="沈建名" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 192"
                        Name="潘廷勇" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 255"
                        Name="薛富中" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Purple"
                        Name="蘇智宏" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Orange"
                        Name="謝正一" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 128, 255"
                        Name="邱兆民" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Plum"
                        Name="陳宇東" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="InactiveCaptionText"
                        Name="陳盈仁" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="MenuBar"
                        Name="陳鴻鳴" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="GradientInactiveCaption"
                        Name="黃建友" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Gold"
                        Name="黃昱彰" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="SlateBlue"
                        Name="廖志明" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Blue"
                        Name="吳宗哲" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Azure"
                        Name="林志華" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                  
                  <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Cyan"
                        Name="楊侑橘" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="LightSteelBlue"
                        Name="王詩閔" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="CornflowerBlue"
                        Name="許勝凱" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Orange"
                        Name="陳盈呈" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Tomato"
                        Name="劉邦正" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>--%>
                    
                </Series>
                <ChartAreas>
                    <DCWC:ChartArea AlignOrientation="None" BackColor="224, 224, 224" BackGradientEndColor="CornflowerBlue"
                        BackGradientType="LeftRight" Name="Default">
                        <AxisY Title="【小時】">
                        </AxisY>
                    </DCWC:ChartArea>
                </ChartAreas>
            </DCWC:Chart>
            <br />
            <br />
            <asp:GridView ID="GridView1" runat="server" Font-Names="Arial" Font-Size="16px" Width="45%"
                AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333"
                AllowPaging="True" HorizontalAlign="Center" PageSize="100">
                <Columns>
                    <asp:TemplateField HeaderText="日期">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Bind("date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="人員">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblNUM1" runat="server" Text='<%# Bind("engineer") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處理時間(小時)">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                        <ItemStyle Width="35px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_query1.aspx?date1=" + DataBinder.Eval(Container.DataItem, "date1")+"&engineer="+DataBinder.Eval(Container.DataItem, "engineer")+"&flag=person" %> '
                                Text='<%# Bind("due_time") %>' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
            </asp:GridView>
            <br />
            <br />
            <DCWC:Chart ID="Chart2" runat="server" Height="380px" Width="779px" BackColor="Wheat"
                EnableViewState="True" BorderLineColor="Blue">
                <Legends>
                    <DCWC:Legend Alignment="Center" Docking="Top" Name="Default">
                    </DCWC:Legend>
                </Legends>
                <Titles>
                    <DCWC:Title Name="Title1" Text="值班時數表(Area)">
                    </DCWC:Title>
                </Titles>
                <BorderSkin SkinStyle="FrameThin5" />
                <Series>
                    <%--<DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="255, 255, 192"
                        Name="ARRAY" ShadowOffset="1" ShowLabelAsValue="True" BorderStyle="NotSet" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 128"
                        Name="CELL" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="40, 212, 192"
                        Name="CF" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Red"
                        Name="OTHERS" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 0"
                        Name="T0Array" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Green"
                        Name="T0Cell" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 255"
                        Name="T1Array" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="MediumBlue"
                        Name="T1CF" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 0"
                        Name="T1Cell" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>--%>
                </Series>
                <ChartAreas>
                    <DCWC:ChartArea BackColor="224, 224, 224" BackGradientEndColor="CornflowerBlue" BackGradientType="LeftRight"
                        Name="Default" AlignOrientation="None">
                        <AxisY Title="【小時】">
                        </AxisY>
                    </DCWC:ChartArea>
                </ChartAreas>
            </DCWC:Chart>
            <br />
            <asp:GridView ID="GridView2" runat="server" Font-Names="Arial" Font-Size="16px" Width="45%"
                AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333"
                AllowPaging="True" HorizontalAlign="Center" PageSize="100">
                <Columns>
                    <asp:TemplateField HeaderText="日期">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Bind("date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="Area">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblNUM1" runat="server" Text='<%# Bind("FAB") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處理時間(小時)">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                        <ItemStyle Width="35px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_query1.aspx?date1=" + DataBinder.Eval(Container.DataItem, "date1")+"&FAB="+DataBinder.Eval(Container.DataItem, "FAB")+"&flag=area" %> '
                                Text='<%# Bind("due_time") %>' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
            </asp:GridView>
            <DCWC:Chart ID="Chart3" runat="server" Height="380px" Width="779px" BackColor="Wheat"
                EnableViewState="True" BorderLineColor="Blue">
                <Legends>
                    <DCWC:Legend Alignment="Center" Docking="Top" Name="Default">
                    </DCWC:Legend>
                </Legends>
                <Titles>
                    <DCWC:Title Name="Title1" Text="值班時數表(System)">
                    </DCWC:Title>
                </Titles>
                <BorderSkin SkinStyle="FrameThin5" />
                <Series>
                    <%--<DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="255, 255, 192"
                        Name="ALARM" ShadowOffset="1" ShowLabelAsValue="True" BorderStyle="NotSet" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 128"
                        Name="ARS" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="40, 212, 192"
                        Name="BC" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Gainsboro"
                        Name="CPC" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 0"
                        Name="DB" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Green"
                        Name="EAP" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 255"
                        Name="EDA" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="MediumBlue"
                        Name="EPMS" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 0"
                        Name="ITC" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="255, 192, 128"
                        Name="MES" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 192"
                        Name="NETWORK" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="ControlDark"
                        Name="OEE" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Red"
                        Name="REPORT" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Goldenrod"
                        Name="SPC" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>--%>
                </Series>
                <ChartAreas>
                    <DCWC:ChartArea BackColor="224, 224, 224" BackGradientEndColor="CornflowerBlue" BackGradientType="LeftRight"
                        Name="Default" AlignOrientation="None">
                        <AxisY Title="【小時】">
                        </AxisY>
                    </DCWC:ChartArea>
                </ChartAreas>
            </DCWC:Chart>
            <br />
            <asp:GridView ID="GridView3" runat="server" Font-Names="Arial" Font-Size="16px" Width="45%"
                AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333"
                AllowPaging="True" HorizontalAlign="Center" PageSize="100">
                <Columns>
                    <asp:TemplateField HeaderText="日期">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Bind("date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="System">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblNUM1" runat="server" Text='<%# Bind("SYSTEM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處理時間(小時)">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                        <ItemStyle Width="35px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_query1.aspx?date1=" + DataBinder.Eval(Container.DataItem, "date1")+"&SYSTEM="+DataBinder.Eval(Container.DataItem, "SYSTEM")+"&flag=system" %> '
                                Text='<%# Bind("due_time") %>' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
            </asp:GridView>
            <DCWC:Chart ID="Chart4" runat="server" Height="380px" Width="779px" BackColor="Wheat"
                EnableViewState="True" BorderLineColor="Blue">
                <Legends>
                    <DCWC:Legend Alignment="Center" Docking="Top" Name="Default">
                    </DCWC:Legend>
                </Legends>
                <Titles>
                    <DCWC:Title Name="Title1" Text="值班時數表(生產影響)">
                    </DCWC:Title>
                </Titles>
                <BorderSkin SkinStyle="FrameThin5" />
                <Series>
                    <%--<DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="255, 255, 192"
                        Name="流片異常" ShadowOffset="1" ShowLabelAsValue="True" BorderStyle="NotSet" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 128"
                        Name="上機取消" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="40, 212, 192"
                        Name="搬運取消" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Gainsboro"
                        Name="沒有影響" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 0"
                        Name="無效搬運" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Green"
                        Name="破片報廢" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 255"
                        Name="過帳失敗" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>--%>
                    
                </Series>
                <ChartAreas>
                    <DCWC:ChartArea BackColor="224, 224, 224" BackGradientEndColor="CornflowerBlue" BackGradientType="LeftRight"
                        Name="Default" AlignOrientation="None">
                        <AxisY Title="【小時】">
                        </AxisY>
                    </DCWC:ChartArea>
                </ChartAreas>
            </DCWC:Chart>
            <br />
            <asp:GridView ID="GridView4" runat="server" Font-Names="Arial" Font-Size="16px" Width="45%"
                AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333"
                AllowPaging="True" HorizontalAlign="Center" PageSize="100">
                <Columns>
                    <asp:TemplateField HeaderText="日期">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Bind("date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="生產影響">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblNUM1" runat="server" Text='<%# Bind("product_impact") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處理時間(小時)">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                        <ItemStyle Width="35px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_query1.aspx?date1=" + DataBinder.Eval(Container.DataItem, "date1")+"&product_impact="+DataBinder.Eval(Container.DataItem, "product_impact")+"&flag=product_impact" %> '
                                Text='<%# Bind("due_time") %>' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                        </ItemTemplate>
                    </asp:TemplateField>
                </Columns>
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <RowStyle BackColor="#EFF3FB" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <AlternatingRowStyle BackColor="White" />
                <EditRowStyle BackColor="#2461BF" />
            </asp:GridView>
            <br />
           <table border="0" cellpadding="0" cellspacing="0" style="background-color: white"
                width="100%">
                <tr>
                    <td bgcolor="gray" height="28" style="font-size: 11px; color: #ffffff; line-height: 16px;
                        font-family: Verdana,?啁敦?��?; text-align: center; text-decoration: none">
                        群創光電股份有限公司 版權所有 Copyright &copy; 2009~ Innolux Display Corp., Design By CIM 謝正一(64179)</td>
                </tr>
            </table> 
        </div>
    </form>
</body>
</html>

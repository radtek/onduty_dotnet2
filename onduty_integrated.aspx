<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onduty_integrated.aspx.cs"
    Inherits="onduty_integrated" %>

<%@ Register Assembly="DundasWebChart" Namespace="Dundas.Charting.WebControl" TagPrefix="DCWC" %>
<%@ Register TagPrefix="obout" Namespace="OboutInc.Calendar2" Assembly="obout_Calendar2_Net" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://IWw.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://IWw.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>CIM�ȯZ�ɼƪ� One Page �g�έp</title>
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <strong><span style="font-size: 16pt">CIM�ȯZ�ɼƪ� One Page �g�έp<br />
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
                        ��ܮɶ�</td>
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
                        <asp:Button ID="Button1" runat="server" Text="�e�X" OnClick="Button1_Click" /></td>
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
                    <DCWC:Title Name="Title1" Text="�ȯZ�ɼƪ�(�H��)">
                    </DCWC:Title>
                </Titles>
                <BorderSkin SkinStyle="FrameThin5" />
                <Series>
                   <%-- <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" BorderStyle="NotSet"
                        Color="255, 255, 192" Name="�����y" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 128"
                        Name="�i����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="40, 212, 192"
                        Name="�i�v��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Red"
                        Name="��@��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 0"
                        Name="�I�F��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Green"
                        Name="�L����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 255"
                        Name="�L���]" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="MediumBlue"
                        Name="�L����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 0"
                        Name="�H�ئW" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 192"
                        Name="��ʫi" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 255"
                        Name="���I��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Purple"
                        Name="Ĭ����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Orange"
                        Name="�¥��@" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 128, 255"
                        Name="������" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Plum"
                        Name="���t�F" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="InactiveCaptionText"
                        Name="���դ�" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="MenuBar"
                        Name="���E��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="GradientInactiveCaption"
                        Name="���ؤ�" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Gold"
                        Name="���R��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="SlateBlue"
                        Name="���ө�" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Blue"
                        Name="�d�v��" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Azure"
                        Name="�L�ӵ�" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                  
                  <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Cyan"
                        Name="���ݾ�" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="LightSteelBlue"
                        Name="���ֶ{" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="CornflowerBlue"
                        Name="�\�ӳ�" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Orange"
                        Name="���էe" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Tomato"
                        Name="�B����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>--%>
                    
                </Series>
                <ChartAreas>
                    <DCWC:ChartArea AlignOrientation="None" BackColor="224, 224, 224" BackGradientEndColor="CornflowerBlue"
                        BackGradientType="LeftRight" Name="Default">
                        <AxisY Title="�i�p�ɡj">
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
                    <asp:TemplateField HeaderText="���">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Bind("date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�H��">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblNUM1" runat="server" Text='<%# Bind("engineer") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�B�z�ɶ�(�p��)">
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
                    <DCWC:Title Name="Title1" Text="�ȯZ�ɼƪ�(Area)">
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
                        <AxisY Title="�i�p�ɡj">
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
                    <asp:TemplateField HeaderText="���">
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
                    <asp:TemplateField HeaderText="�B�z�ɶ�(�p��)">
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
                    <DCWC:Title Name="Title1" Text="�ȯZ�ɼƪ�(System)">
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
                        <AxisY Title="�i�p�ɡj">
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
                    <asp:TemplateField HeaderText="���">
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
                    <asp:TemplateField HeaderText="�B�z�ɶ�(�p��)">
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
                    <DCWC:Title Name="Title1" Text="�ȯZ�ɼƪ�(�Ͳ��v�T)">
                    </DCWC:Title>
                </Titles>
                <BorderSkin SkinStyle="FrameThin5" />
                <Series>
                    <%--<DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="255, 255, 192"
                        Name="�y�����`" ShadowOffset="1" ShowLabelAsValue="True" BorderStyle="NotSet" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="128, 255, 128"
                        Name="�W������" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="40, 212, 192"
                        Name="�h�B����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Gainsboro"
                        Name="�S���v�T" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 0, 0"
                        Name="�L�ķh�B" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="Green"
                        Name="�}�����o" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>
                    <DCWC:Series BackGradientEndColor="192, 255, 255" BorderColor="64, 64, 64" Color="192, 192, 255"
                        Name="�L�b����" ShadowOffset="1" ShowLabelAsValue="True" CustomAttributes="DrawingStyle=Cylinder">
                    </DCWC:Series>--%>
                    
                </Series>
                <ChartAreas>
                    <DCWC:ChartArea BackColor="224, 224, 224" BackGradientEndColor="CornflowerBlue" BackGradientType="LeftRight"
                        Name="Default" AlignOrientation="None">
                        <AxisY Title="�i�p�ɡj">
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
                    <asp:TemplateField HeaderText="���">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSN" runat="server" Text='<%# Bind("date1") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�Ͳ��v�T">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblNUM1" runat="server" Text='<%# Bind("product_impact") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="�B�z�ɶ�(�p��)">
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
                        font-family: Verdana,?�細?��?; text-align: center; text-decoration: none">
                        �s�Х��q�ѥ��������q ���v�Ҧ� Copyright &copy; 2009~ Innolux Display Corp., Design By CIM �¥��@(64179)</td>
                </tr>
            </table> 
        </div>
    </form>
</body>
</html>

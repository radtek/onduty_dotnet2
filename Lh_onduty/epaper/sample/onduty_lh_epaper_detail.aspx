<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onduty_lh_epaper_detail.aspx.cs"
    Inherits="Lh_onduty_epaper_onduty_lh_epaper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>LH_onduty_epaper_detail</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <span style="font-size: 14pt">
            &nbsp;Dear SIRs ...
            <br />
            <br />
            龍華出勤違規警示通告 , 共計分為三部分 , 項目分別如下 :
            <br />
            <br />
            一. 做六休一違規事件統計. (連續工作超過六天)
            <br />
            二. 週工時違規事件統計. (週工時超過63小時)
            <br />
            三. 月加班工時違規事件統計. (月加班工時超過91小時) 各項目違規事件統計請參閱如下三表 , 各表於數字上附有超連結 , 可提供資料查詢 , 以利個案追蹤
            .
            <br />
            <br />
            </span>
            <strong><span style="font-size: 14pt">
            一.龍華出勤違規警示通告:做六休一違規事件統計
            <br />
            </span>
            </strong>
            <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GridView1_RowDataBound" Font-Size="X-Small">
                <RowStyle BackColor="#EFF3FB" Font-Size="X-Small" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="RN">
                        <ItemTemplate>
                         
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="日期">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" ForeColor="DarkGreen" Text='<%# Bind("date") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BU名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblBUname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("BUname") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處別名稱 ">
                        <ItemTemplate>
                            <asp:Label ID="lblDIVname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("DIVname") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部門名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("name") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                 
                    
                    <asp:TemplateField HeaderText="連續工作6天以上人數">
                        <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/LH_ON_DUTY_ALARMMAIL_WEB/LHAlarmQueryC1.aspx?dates=" + DataBinder.Eval(Container.DataItem, "date")+"&deptcode="+DataBinder.Eval(Container.DataItem, "deptcode") %> ' 
Text='<%# Bind("counts") %>' ForeColor="DeepPink" Target="_blank" runat="server"></asp:HyperLink> 
<headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" /> 

                        </ItemTemplate>
                    </asp:TemplateField>
                
                </Columns>
            </asp:GridView>
            <span style="font-size: 14pt"></span>
        </div>
        <br />
        <span style="font-size: 14pt">
        ** 說明::日期為人員下班日期,意即於此日期下班人員已達違規之人數.<br />
        <br />
        <br />
        </span>
        <strong><span style="font-size: 14pt">
        二.龍華出勤違規警示通告:週工時違規事件統計(週工時超過63小時)
        <br />
        </span>
        </strong>
        <asp:GridView ID="GridView2" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GridView2_RowDataBound" Font-Size="X-Small">
                <RowStyle BackColor="#EFF3FB" Font-Size="X-Small"  />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="RN">
                        <ItemTemplate>
                         
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="年別">
                        <ItemTemplate>
                            <asp:Label ID="lblbYESRS" runat="server" ForeColor="DarkGreen" Text='<%# Bind("YESRS") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="週別">
                        <ItemTemplate>
                            <asp:Label ID="lblWEEKS" runat="server" ForeColor="DarkGreen" Text='<%# Bind("WEEKS") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BU名稱 ">
                        <ItemTemplate>
                            <asp:Label ID="lblBUname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("BUname") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處別名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblDIVname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("DIVname") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部門名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("name") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    
                    <asp:TemplateField HeaderText="週工時超過63小時人數">
                        <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/LH_ON_DUTY_ALARMMAIL_WEB/LHAlarmQueryC2.aspx?years=" + DataBinder.Eval(Container.DataItem, "YESRS")+"&weeks="+DataBinder.Eval(Container.DataItem, "WEEKS")+"&deptcode="+DataBinder.Eval(Container.DataItem, "deptcode") %> ' 
Text='<%# Bind("OT_counts") %>' ForeColor="DeepPink" Target="_blank"  runat="server"></asp:HyperLink> 
<headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" /> 

                        </ItemTemplate>
                    </asp:TemplateField>
                
                </Columns>
            </asp:GridView>
        <span style="font-size: 14pt">
        <br />
        ** 說明::週別為行事曆上之週數,結算期間為週日(00:00:01)至週六(23:59:59),人員下班時間於結算期間內即納入計算.
        <br />
        <br />
        <br />
        </span>
        <strong><span style="font-size: 14pt">
        三.龍華出勤違規警示通告:月加班工時違規事件統計(月加班工時超過91小時)<br />
        </span>
        </strong>
        <asp:GridView ID="GridView3" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None" AutoGenerateColumns="False" OnRowDataBound="GridView3_RowDataBound" Font-Size="X-Small">
                <RowStyle BackColor="#EFF3FB" Font-Size="X-Small" />
                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <PagerStyle BackColor="#2461BF" ForeColor="White" HorizontalAlign="Center" />
                <SelectedRowStyle BackColor="#D1DDF1" Font-Bold="True" ForeColor="#333333" />
                <HeaderStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                <EditRowStyle BackColor="#2461BF" />
                <AlternatingRowStyle BackColor="White" />
                <Columns>
                    <asp:TemplateField HeaderText="RN">
                        <ItemTemplate>
                         
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="年">
                        <ItemTemplate>
                            <asp:Label ID="lbldate" runat="server" ForeColor="DarkGreen" Text='<%# Bind("YESRS") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="月">
                        <ItemTemplate>
                            <asp:Label ID="lblBUname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("MONTHS") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="BU名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblDIVname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("BUname") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處別名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("DIVname") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="部門名稱">
                        <ItemTemplate>
                            <asp:Label ID="lblcounts" runat="server" ForeColor="DarkGreen" Text='<%# Bind("name") %>'></asp:Label></br>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="月加班工時超過91小時人數">
                        <ItemTemplate>
                          <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/LH_ON_DUTY_ALARMMAIL_WEB/LHAlarmQueryC1.aspx?YESRS=" + DataBinder.Eval(Container.DataItem, "YESRS")+"&MONTHS="+DataBinder.Eval(Container.DataItem, "MONTHS")+"&deptcode="+DataBinder.Eval(Container.DataItem, "deptcode") %> ' 
Text='<%# Bind("OT_counts") %>' ForeColor="DeepPink"  Target="_blank" runat="server"></asp:HyperLink> 
<headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" /> 

                        </ItemTemplate>
                    </asp:TemplateField>
                
                </Columns>
            </asp:GridView>
        <span style="font-size: 14pt">
        <br />
        ** 說明::累計當月至結算日期(23:59:59)止之月加班工時.&nbsp;<br />
        <br />
        此為CIM 電子報系統自動寄發之信件 , 如需服務 , 請洽 竹南 CIM 陳宇東(513-64175) .
        <br />
        <br />
        Best Regards.- CIM ALARM SYSTEM.- </span>
    </form>
</body>
</html>

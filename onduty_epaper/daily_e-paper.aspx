<%@ Page Language="C#" AutoEventWireup="true" CodeFile="daily_e-paper.aspx.cs" Inherits="onduty_epaper_daily_e_paper" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Onduty Daily Report</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <table hight="100%" width="100%">
                <tr>
                    <td align='left' valign='middle' style="width: 906px">
                        <fieldset>
                            <legend align="left" style="color: blue; text-align: left"><span style="font-size: 16pt;
                                font-family: Century Gothic;"><strong>CIM值班記錄每日電子報(C2/T1/T2)</strong></span></legend>
                            <br />
                            <br />
                            C2/T1/T2(地震/壓降)<br />
                            <asp:GridView ID="GridView3" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="No Record!"
                                Font-Names="Century Gothic" Font-Size="X-Small" OnRowDataBound="GridView3_RowDataBound"
                                Width="650px">
                                <RowStyle Font-Size="X-Small" ForeColor="#000066" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrownum" runat="server" ForeColor="DarkGreen" Text='<%# Bind("rownum") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Time">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            SEQ:</br>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF0000" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_record.aspx?SEQ=" + DataBinder.Eval(Container.DataItem, "SEQ") %> '
                                                Target="_blank" Text='<%# Bind("SEQ") %>'></asp:HyperLink>
                                            </br> 開始時間:</br>
                                            <asp:Label ID="lblcalltime" runat="server" ForeColor="DarkGreen" Text='<%# Bind("calltime") %>'></asp:Label></br>
                                            結束時間:</br>
                                            <asp:Label ID="lblendtime" runat="server" ForeColor="DarkGreen" Text='<%# Bind("endtime") %>'></asp:Label></br>
                                            來電人員:</br>
                                            <asp:Label ID="lblrecord_person" runat="server" ForeColor="DarkGreen" Text='<%# Bind("caller") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Area">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            Fab:</br>
                                            <asp:Label ID="lblFab" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Fab") %>'
                                                Width="80px"></asp:Label></br> System:</br>
                                            <asp:Label ID="lblSystem" runat="server" ForeColor="DarkGreen" Text='<%# Bind("System") %>'></asp:Label></br>
                                            Type:</br>
                                            <asp:Label ID="lblType" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Type") %>'></asp:Label></br>
                                            生產影響:</br>
                                            <asp:Label ID="lblProduct_impact" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Product_impact") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            問題敘述:</br>
                                            <asp:Label ID="lblquestion" runat="server" ForeColor="DarkGreen" Text='<%# Bind("question") %>'></asp:Label></br>
                                            影響敘述:</br>
                                            <asp:Label ID="lblProduct_impact_info" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Product_impact_info") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="排除方法">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            排除方法:</br>
                                            <asp:Label ID="lblmethod" runat="server" ForeColor="DarkGreen" Text='<%# Bind("method") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            ARS:</br>
                                            <asp:Label ID="lblars_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("ars_flag") %>'
                                                Width="60px"></asp:Label></br> CLOSE:</br>
                                            <asp:Label ID="lblclose_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("close_flag") %>'></asp:Label></br>
                                            ALARM:</br>
                                            <asp:Label ID="lblalarm_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("alarm_flag") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="值班人員">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblengineer" runat="server" ForeColor="DarkGreen" Text='<%# Bind("engineer") %>'></asp:Label></br>
                                            處理時間:</br>
                                            <asp:Label ID="lbldue_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("due_time") %>'></asp:Label>&nbsp
                                            分</br>
                                            <%--    AssignTo:</br>
                                            <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                             --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AssignTo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                <AlternatingRowStyle BackColor="#EFEDEF" />
                            </asp:GridView>
                            <br>
                            C2/T1<br />
                            <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="No Record!"
                                Font-Names="Century Gothic" Font-Size="X-Small" OnRowDataBound="GridView1_RowDataBound"
                                Width="650px">
                                <RowStyle Font-Size="X-Small" ForeColor="#000066" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrownum" runat="server" ForeColor="DarkGreen" Text='<%# Bind("rownum") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Time">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            SEQ:</br>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF0000" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_record.aspx?SEQ=" + DataBinder.Eval(Container.DataItem, "SEQ") %> '
                                                Target="_blank" Text='<%# Bind("SEQ") %>'></asp:HyperLink>
                                            </br> 開始時間:</br>
                                            <asp:Label ID="lblcalltime" runat="server" ForeColor="DarkGreen" Text='<%# Bind("calltime") %>'></asp:Label></br>
                                            結束時間:</br>
                                            <asp:Label ID="lblendtime" runat="server" ForeColor="DarkGreen" Text='<%# Bind("endtime") %>'></asp:Label></br>
                                            來電人員:</br>
                                            <asp:Label ID="lblrecord_person" runat="server" ForeColor="DarkGreen" Text='<%# Bind("caller") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Area">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            Fab:</br>
                                            <asp:Label ID="lblFab" runat="server" ForeColor="DarkGreen" Width="80px"  Text='<%# Bind("Fab") %>'></asp:Label></br>
                                            System:</br>
                                            <asp:Label ID="lblSystem" runat="server" ForeColor="DarkGreen" Text='<%# Bind("System") %>'></asp:Label></br>
                                            Type:</br>
                                            <asp:Label ID="lblType" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Type") %>'></asp:Label></br>
                                            生產影響:</br>
                                            <asp:Label ID="lblProduct_impact" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Product_impact") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            問題敘述:</br>
                                            <asp:Label ID="lblquestion" runat="server" ForeColor="DarkGreen" Text='<%# Bind("question") %>'></asp:Label></br>
                                            影響敘述:</br>
                                            <asp:Label ID="lblProduct_impact_info" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Product_impact_info") %>'></asp:Label></br>
                                            異常原因:</br>
                                            <asp:Label ID="lblREASON" runat="server" ForeColor="DarkGreen" Text='<%# Bind("REASON") %>'></asp:Label></br>
                                         
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="排除方法">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            
                                            排除方法:</br>
                                            <asp:Label ID="lblmethod" runat="server" ForeColor="DarkGreen" Text='<%# Bind("method") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            ARS:</br>
                                            <asp:Label ID="lblars_flag" runat="server" ForeColor="DarkGreen" Width="60px" Text='<%# Bind("ars_flag") %>'></asp:Label></br>
                                            CLOSE:</br>
                                            <asp:Label ID="lblclose_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("close_flag") %>'></asp:Label></br>
                                            ALARM:</br>
                                            <asp:Label ID="lblalarm_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("alarm_flag") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="值班人員">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblengineer" runat="server" ForeColor="DarkGreen" Text='<%# Bind("engineer") %>'></asp:Label></br>
                                            處理時間:</br>
                                            <asp:Label ID="lbldue_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("due_time") %>'></asp:Label>&nbsp
                                            分</br>
                                           <%--    AssignTo:</br>
                                            <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                             --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="AssignTo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                           
                                            <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                   
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                <AlternatingRowStyle BackColor="#EFEDEF" />
                            </asp:GridView>
                            <br />
                            T2<br />
                            <asp:GridView ID="GridView2" runat="server" AutoGenerateColumns="False" BackColor="White"
                                BorderColor="#CCCCCC" BorderStyle="None" BorderWidth="1px" CellPadding="3" EmptyDataText="No Record!"
                                Font-Names="Century Gothic" Font-Size="X-Small" OnRowDataBound="GridView2_RowDataBound"
                                Width="650px">
                                <RowStyle Font-Size="X-Small" ForeColor="#000066" />
                                <Columns>
                                    <asp:TemplateField HeaderText="RN">
                                        <ItemTemplate>
                                            <asp:Label ID="lblrownum" runat="server" ForeColor="DarkGreen" Text='<%# Bind("rownum") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Time">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            SEQ:</br>
                                            <asp:HyperLink ID="HyperLink1" runat="server" ForeColor="#FF0000" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/onduty_record.aspx?SEQ=" + DataBinder.Eval(Container.DataItem, "SEQ") %> '
                                                Target="_blank" Text='<%# Bind("SEQ") %>'></asp:HyperLink>
                                            </br> 開始時間:</br>
                                            <asp:Label ID="lblcalltime" runat="server" ForeColor="DarkGreen" Text='<%# Bind("calltime") %>'></asp:Label></br>
                                            結束時間:</br>
                                            <asp:Label ID="lblendtime" runat="server" ForeColor="DarkGreen" Text='<%# Bind("endtime") %>'></asp:Label></br>
                                            來電人員:</br>
                                            <asp:Label ID="lblrecord_person" runat="server" ForeColor="DarkGreen" Text='<%# Bind("caller") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Area">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            Fab:</br>
                                            <asp:Label ID="lblFab" runat="server" ForeColor="DarkGreen" Width="80px"  Text='<%# Bind("Fab") %>'></asp:Label></br>
                                            System:</br>
                                            <asp:Label ID="lblSystem" runat="server" ForeColor="DarkGreen" Text='<%# Bind("System") %>'></asp:Label></br>
                                            Type:</br>
                                            <asp:Label ID="lblType" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Type") %>'></asp:Label></br>
                                            生產影響:</br>
                                            <asp:Label ID="lblProduct_impact" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Product_impact") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="Description">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            問題敘述:</br>
                                            <asp:Label ID="lblquestion" runat="server" ForeColor="DarkGreen" Text='<%# Bind("question") %>'></asp:Label></br>
                                            影響敘述:</br>
                                            <asp:Label ID="lblProduct_impact_info" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Product_impact_info") %>'></asp:Label></br>
                                          
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="排除方法">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            
                                            排除方法:</br>
                                            <asp:Label ID="lblmethod" runat="server" ForeColor="DarkGreen" Text='<%# Bind("method") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                      <asp:TemplateField HeaderText="Status">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            ARS:</br>
                                            <asp:Label ID="lblars_flag" runat="server" ForeColor="DarkGreen" Width="60px" Text='<%# Bind("ars_flag") %>'></asp:Label></br>
                                            CLOSE:</br>
                                            <asp:Label ID="lblclose_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("close_flag") %>'></asp:Label></br>
                                            ALARM:</br>
                                            <asp:Label ID="lblalarm_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("alarm_flag") %>'></asp:Label></br>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                    <asp:TemplateField HeaderText="值班人員">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                            <asp:Label ID="lblengineer" runat="server" ForeColor="DarkGreen" Text='<%# Bind("engineer") %>'></asp:Label></br>
                                            處理時間:</br>
                                            <asp:Label ID="lbldue_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("due_time") %>'></asp:Label>&nbsp
                                            分</br>
                                         <%--    AssignTo:</br>
                                            <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                             --%>
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                     <asp:TemplateField HeaderText="AssignTo">
                                        <HeaderStyle HorizontalAlign="Center" />
                                        <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                        <ItemTemplate>
                                           
                                           
                                            <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                             
                                        </ItemTemplate>
                                    </asp:TemplateField>
                                  
                                </Columns>
                                <FooterStyle BackColor="#507CD1" Font-Bold="True" ForeColor="White" />
                                <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                <AlternatingRowStyle BackColor="#EFEDEF" />
                            </asp:GridView>
                            
                            <table border="0" cellpadding="0" cellspacing="0" style="background-color: white; width: 100%; height: 25px;">
        <tr>
            <td bgcolor="gray" style="font-size: 11px; color: #ffffff; line-height: 16px;
                font-family: Verdana,?啁敦??; text-align: center; text-decoration: none; height: 18px; width: 902px;">
                群創光電股份有限公司 版權所有 Copyright &copy; 2010~ Innolux Corp., Design By CIM 謝正一(64179)</td>
        </tr>
    </table>
                        </fieldset>
                    </td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

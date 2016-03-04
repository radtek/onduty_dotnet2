<%@ Page Language="C#" AutoEventWireup="true" CodeFile="record_assign_mail_sample.aspx.cs" Inherits="record_assign_mail_sample" %>



<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>值班紀錄-Mail Data</title>
    <link href="../app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
            
            
            <fieldset>
                <legend align="left" style="width: 167px; color: blue; text-align: center">值班紀錄-Assign</legend>
                                                      <table hight=100% width=100%><tr><td align='left' valign='middle'> 
  <asp:GridView ID="GridView1" runat="server" Font-Names="Century Gothic" Font-Size="X-Small" Width="1000px"
                                                        AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                                        OnRowDataBound="GridView1_RowDataBound" BorderStyle="None" BorderWidth="1px"
                                                        EmptyDataText="No Record!">
                                                        <RowStyle ForeColor="#000066" Font-Size="X-Small" />
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
                                                                    <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl='<%#"http://10.56.131.22" +Context.Request.ApplicationPath+"/onduty_record.aspx?SEQ=" + DataBinder.Eval(Container.DataItem, "SEQ") %> '
                                                                        Text='<%# Bind("SEQ") %>' ForeColor="#FF0000" runat="server"></asp:HyperLink>
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
                                                                    <asp:Label ID="lblFab" runat="server" ForeColor="DarkGreen" Text='<%# Bind("Fab") %>'></asp:Label></br>
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
                                                                排除方法:</br>
                                                                    <asp:Label ID="lblmethod" runat="server" ForeColor="DarkGreen" Text='<%# Bind("method") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                               
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="值班人員">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                         
                                                                    <asp:Label ID="lblengineer" runat="server" ForeColor="DarkGreen" Text='<%# Bind("engineer") %>'></asp:Label></br>
                                                                    處理時間:</br>
                                                                    <asp:Label ID="lbldue_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("due_time") %>'></asp:Label>&nbsp 分</br>
                                                                </ItemTemplate>
                                                               
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Status">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    ARS:</br>
                                                                    <asp:Label ID="lblars_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("ars_flag") %>'></asp:Label></br>
                                                                     CLOSE:</br>
                                                                    <asp:Label ID="lblclose_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("close_flag") %>'></asp:Label></br>
                                                                     ALARM:</br>
                                                                    <asp:Label ID="lblalarm_flag" runat="server" ForeColor="DarkGreen" Text='<%# Bind("alarm_flag") %>'></asp:Label></br>
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            
                                                        
                                                        </Columns>
                                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                                    </asp:GridView>
                                                     
                                                          <table border="0" cellpadding="0" cellspacing="0" style="width: 100%; height: 25px;
                                                              background-color: white">
                                                              <tr>
                                                                  <td bgcolor="gray" style="font-size: 11px; width: 902px; color: #ffffff; line-height: 16px;
                                                                      font-family: Verdana,?啁敦??; height: 18px; text-align: center; text-decoration: none">
                                                                      奇美電子股份有限公司 版權所有 Copyright © 2010 Chimei-Innolux Corp., Design By CIM 謝正一(64179)</td>
                                                              </tr>
                                                          </table>
</td></tr></table>

                                                      
            </fieldset>
            &nbsp;<br />
           
    </form>
</body>
</html>



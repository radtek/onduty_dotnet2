<%@ Page Language="C#" AutoEventWireup="true" CodeFile="board_record.aspx.cs" Inherits="board_record" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>夜巡資料-Data</title>
    <link href="../app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
            <fieldset>
                <legend align="center" style="width: 167px; color: blue; text-align: center">值班公佈欄-新消息</legend>
                                                    <asp:GridView ID="GridView1" runat="server" Font-Names="Arial" Font-Size="12px" Width="1000px"
                                                        AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC" OnRowDataBound="GridView1_RowDataBound"
                                                        BorderStyle="None" BorderWidth="1px" EmptyDataText="No Task!">
                                                        <RowStyle ForeColor="#000066" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RN">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrownum" runat="server" ForeColor="DarkGreen" Text='<%# Bind("rownum") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Publisher">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    發佈人:</br>
                                                                    <asp:Label ID="lblpublisher" runat="server" ForeColor="DarkGreen" Text='<%# Bind("publisher") %>'></asp:Label></br>
                                                                    FAB:</br>
                                                                    <asp:Label ID="lblfab" runat="server" ForeColor="DarkGreen" Text='<%# Bind("fab") %>'></asp:Label></br>
                                                                    
                                                                   
                                                                    
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Time">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    公佈開始:</br>
                                                                    <asp:Label ID="lblbegin_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("begin_time") %>'></asp:Label></br>
                                                                    公佈結束:</br>
                                                                    <asp:Label ID="lblend_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("end_time") %>'></asp:Label></br>
                                                                    更新時間:</br>
                                                                    <asp:Label ID="lblupdate_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("update_time") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="Subject">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                 主旨:</br>
                                                                    <asp:Label ID="lblsubject" runat="server" ForeColor="DarkGreen" Text='<%# Bind("subject") %>'></asp:Label></br>
                                                                      公佈消息:</br>
                                                                    <asp:Label ID="lblcontent" runat="server" ForeColor="DarkGreen" Text='<%# Bind("content") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                                
                                                            </asp:TemplateField>
                                                            
                                                            <asp:TemplateField HeaderText="Download">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                  <asp:HyperLink ID="HyperLink12" Target="_blank" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/FileList/" + DataBinder.Eval(Container.DataItem, "org_file_name") %> '
                                                                        Text='<%# Bind("org_file_name") %>' ForeColor="#3617E3" runat="server"></asp:HyperLink>
                                                                      
                                                                </ItemTemplate>
                                                                
                                                            </asp:TemplateField>
                                                            
                                                           
                                                            
                                                          
                                                        </Columns>
                                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                                    </asp:GridView>
            </fieldset>
            &nbsp;<br />
           
    </form>
</body>
</html>


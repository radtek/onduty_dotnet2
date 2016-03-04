<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onduty_query1.aspx.cs" Inherits="onduty_query1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://IWw.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://IWw.w3.org/1999/xhtml">
<head runat="server">
    <title>值班記錄查詢</title>
    <meta http-equiv="Content-Type" content="text/html; charset=big5">
</head>
<body>
    <form id="form1" runat="server">
        <div style="text-align: center">
            <span style="font-size: 16pt; color: #3333ff"><strong>值班記錄查詢<br />
            </strong></span>
            <asp:GridView ID="GridView1" runat="server" Font-Names="Arial" Font-Size="16px" Width="45%"
                AutoGenerateColumns="False" CellPadding="4" GridLines="None" OnRowDataBound="GridView1_RowDataBound"
                OnPageIndexChanging="GridView1_PageIndexChanging" AllowSorting="True" ForeColor="#333333"
                AllowPaging="True" HorizontalAlign="Center" PageSize="10">
                <Columns>
                    <asp:TemplateField HeaderText="RN">
                        <HeaderStyle Width="30px" HorizontalAlign="Center" />
                        <ItemStyle Width="30px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblRN" runat="server" Text='<%# Bind("rownum") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                   
                    <asp:TemplateField HeaderText="編號">
                        <HeaderStyle Width="35px" HorizontalAlign="Center" />
                        <ItemStyle Width="35px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:HyperLink ID="HyperLink1" NavigateUrl='<%#"http://10.56.131.17:8000/OnDuty/Record.php?SEQ=" + DataBinder.Eval(Container.DataItem, "SEQ") %> '
                                Text='<%# Bind("SEQ") %>' ForeColor="DeepPink" runat="server"></asp:HyperLink>
                            <headerstyle backcolor="#1C5E55" font-bold="True" forecolor="White" />
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="來電時間">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblCALLTIME" runat="server" Text='<%# Bind("CALLTIME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="FAB">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblFAB" runat="server" Text='<%# Bind("FAB") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="SYSTEM">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblSYSTEM" runat="server" Text='<%# Bind("SYSTEM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="TYPE">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblTYPE" runat="server" Text='<%# Bind("TYPE") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="問題描述">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblDESCRIPTION" runat="server" Text='<%# Bind("DESCRIPTION") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="生產影響">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblPRODUCT_IMPACT" runat="server" Text='<%# Bind("PRODUCT_IMPACT") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="影響敘述">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblPRODUCT_IMPACT_INFO" runat="server" Text='<%# Bind("PRODUCT_IMPACT_INFO") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="處理者">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblBYWHOM" runat="server" Text='<%# Bind("BYWHOM") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    
                    <asp:TemplateField HeaderText="處理時間">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblDUE_TIME" runat="server" Text='<%# Bind("DUE_TIME") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ARS">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblARS_FLAG" runat="server" Text='<%# Bind("ARS_FLAG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="CLOSE">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblCLOSE_FLAG" runat="server" Text='<%# Bind("CLOSE_FLAG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="ALARM">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblALARM_FLAG" runat="server" Text='<%# Bind("ALARM_FLAG") %>'></asp:Label>
                        </ItemTemplate>
                    </asp:TemplateField>
                    <asp:TemplateField HeaderText="改判">
                        <HeaderStyle Width="120px" HorizontalAlign="Center" />
                        <ItemStyle Width="120px" HorizontalAlign="Center" />
                        <ItemTemplate>
                            <asp:Label ID="lblRECHARGE_FLAG" runat="server" Text='<%# Bind("RECHARGE_FLAG") %>'></asp:Label>
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
            <table border="0" cellpadding="0" cellspacing="0" style="background-color: white"
                width="100%">
                <tr>
                    <td bgcolor="gray" height="28" style="font-size: 11px; color: #ffffff; line-height: 16px;
                        font-family: Verdana,?啁敦?��?; text-align: center; text-decoration: none">
                        群創光電股份有限公司 版權所有 Copyright &copy; 2009 Innolux Display Corp., Design By CIM 謝正一(64179)</td>
                </tr>
            </table>
        </div>
    </form>
</body>
</html>

<%@ Page Language="C#" AutoEventWireup="true" CodeFile="weekly_onduty_lh1.aspx.cs" Inherits="Lh_onduty_weekly_onduty_lh1" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head id="Head1" runat="server">
    <title>Loader_Rerun_for_LH_Onduty</title>
</head>
<body>
    <form id="form1" runat="server">
    <div style="text-align: center">
        &nbsp;
        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
        </asp:ScriptManager>
        &nbsp;<br />
        <br />
        &nbsp;<fieldset style="text-align: center">
            <legend align="center" style="width: 109px; color: blue; height: 31px; text-align: center">
                <strong><span style="font-size: 14pt">Loader_Rerun_for_LH_Onduty</span></strong>&nbsp;</legend>
            <table style="width: 441px; height: 102px">
                <tr>
                    <td style="height: 26px; text-align: center">
                    開始時間</td>
                    <td style="height: 26px">
                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                        <ContentTemplate>
                            <telerik:raddatepicker id="txtEstimateStartDate" runat="server" enabletyping="False"
                                skin="Office2007" skinid="Office2007">
                                                <%-- <DateInput ID="DateInput1" runat="server" DateFormat="yyyy/MM/dd hh:mm:ss" Font-Size="10pt"--%>
                                                <DateInput ID="DateInput1" runat="server" DateFormat="yyyy/MM/dd" Font-Size="10pt"
                                                    ReadOnly="True" Skin="Office2007">
                                                </DateInput>
                                                <Calendar ID="Calendar1" runat="server" Skin="Office2007">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Date="" ItemStyle-CssClass="rcToday" Repeatable="Today">
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                            </telerik:raddatepicker>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td style="width: 31px; height: 26px">
                    </td>
                </tr>
                <tr>
                    <td style="text-align: center">
                    結束時間</td>
                    <td>
                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                        <ContentTemplate>
                            <telerik:raddatepicker id="txtEstimateEndDate" runat="server" enabletyping="False"
                                skin="Office2007" skinid="Office2007">
                                                <DateInput DateFormat="yyyy/MM/dd" Font-Size="10pt"
                                                    ReadOnly="True" Skin="Office2007">
                                                </DateInput>
                                                <Calendar Skin="Office2007" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Date="" Repeatable="Today">
                                                            <ItemStyle CssClass="rcToday" />
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:raddatepicker>
                            <br />
                        </ContentTemplate>
                    </asp:UpdatePanel>
                    </td>
                    <td style="width: 31px">
                    </td>
                </tr>
                <tr>
                    <td>
                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="做六休一" /></td>
                    <td>
                    <asp:Button ID="Button2" runat="server" Text="週工時違規" OnClick="Button2_Click" /></td>
                    <td style="width: 31px">
                    <asp:Button ID="Button3" runat="server" Text="月加班工時違規" /></td>
                </tr>
            </table>
            <br />
        <asp:Label ID="Label1" runat="server" Text="Label" Visible="False"></asp:Label><br />
        
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" ForeColor="#333333" GridLines="None"
           >
            <RowStyle BackColor="#FFFBD6" ForeColor="#333333" />
            <FooterStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <PagerStyle BackColor="#FFCC66" ForeColor="#333333" HorizontalAlign="Center" />
            <SelectedRowStyle BackColor="#FFCC66" Font-Bold="True" ForeColor="Navy" />
            <HeaderStyle BackColor="#990000" Font-Bold="True" ForeColor="White" />
            <AlternatingRowStyle BackColor="White" />
        </asp:GridView>
            <br />
            <span style="font-size: 14pt; color: blue"></span>
        </fieldset>
        &nbsp;<br />
        <br />
        <br />
        &nbsp;&nbsp;<br />
        <br />
        &nbsp;</div>
    </form>
</body>
</html>


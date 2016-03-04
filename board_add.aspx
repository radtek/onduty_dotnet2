<%@ Page Language="C#" EnableEventValidation="false" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="board_add.aspx.cs" Inherits="board_add" Title="值班記錄公佈欄-新增" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">

<head id="Head1" >
    <title>值班記錄公佈欄-新增</title>
    <link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>

        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
           
            <table id="Table3" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 9px">
                        <img src="images/tables/default_lt.gif" /></td>
                    <td style="background-image: url(images/tables/default_t.gif); height: 9px;">
                        <img height="9" src="images/tables/transparent.gif" /></td>
                    <td style="height: 9px">
                        <img src="images/tables/default_rt.gif" /></td>
                </tr>
                <tr>
                    <td style="background-image: url(images/tables/default_l.gif)">
                        <img src="images/tables/transparent.gif" width="9"></td>
                    <td align="middle" width="100%">
                        <table align="center" cellspacing="0" bordercolordark="#ffffff" cellpadding="2" width="90%"
                            bordercolorlight="#7a9cb7" border="1">
                            <tr>
                                <td background="" colspan="4" class="pageTitle" style="height: 24px">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="width: 533px">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>公佈欄-新增</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy">
                                                * 表示必填!</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    FAB<span class="style4" style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:DropDownList ID="DropDownList1" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    發佈人<span class="style4" style="color: red">﹡</span></td>
                                <td align="left" style="height: 24px" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox_publish" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    主旨<span class="style4"><span class="style4" style="color: red">﹡</span></span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_subject" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 29px">
                                    公佈開始<span class="style4" style="color: red">﹡</span></td>
                                <td align="left" style="width: 107px; height: 29px" valign="top">
                                            <telerik:RadDatePicker ID="txtEstimateStartDate" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007">
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
                                            </telerik:RadDatePicker>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 29px">
                                    公佈結束<span class="style4" style="color: red">﹡</span></td>
                                <td align="left" style="width: 107px; height: 29px" valign="top">
                                            <telerik:RadDatePicker ID="txtEstimateEndDate" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007">
                                                <DateInput DateFormat="yyyy/MM/dd" Font-Size="10pt" ReadOnly="True" Skin="Office2007">
                                                </DateInput>
                                                <Calendar Skin="Office2007" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False"
                                                    ViewSelectorText="x">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Date="" Repeatable="Today">
                                                            <ItemStyle CssClass="rcToday" />
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                                <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                </td>
                            </tr>
                           
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    公佈消息<span class="style4"><span class="style4" style="color: #ff0000">﹡</span></span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_content" runat="server" Height="138px" TextMode="MultiLine"
                                        Width="609px"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    檔案上傳</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:FileUpload ID="FileUpload1" runat="server" /></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    發送MAIL</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:CheckBox ID="CheckBox1" runat="server" Checked="True" />發給T1-CIM&nbsp;
                                    <asp:CheckBox ID="CheckBox2" runat="server" Checked="True" />發給T2-CIM
                                </td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px">
                                    <asp:Button ID="ButtonAdd" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Add" OnClick="ButtonAdd_Click" />
                                    &nbsp;&nbsp; &nbsp;&nbsp;&nbsp;
                                    <asp:Label ID="Label3" runat="server" ForeColor="#FF3300" Height="10px" Visible="False"
                                        Width="58px"></asp:Label>
                                    <asp:Label ID="Label1" runat="server" ForeColor="#FF3300"></asp:Label>
                                    <asp:Label ID="Label2" runat="server" ForeColor="blue"></asp:Label></td>
                            </tr>
                           
                        </table>
                    </td>
                    <td style="font-size: 12pt; background-image: url(images/tables/default_r.gif)">
                        <img src="images/tables/transparent.gif" width="9"></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 9px">
                        <img src="images/tables/default_lb.gif"></td>
                    <td style="background-image: url(images/tables/default_b.gif); height: 9px;">
                        <img height="9" src="images/tables/transparent.gif"></td>
                    <td style="height: 9px">
                        <img src="images/tables/default_rb.gif"></td>
                </tr>
            </table>

</asp:Content>


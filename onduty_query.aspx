<%@ Page Language="C#" MasterPageFile="~/MasterPage.master" AutoEventWireup="true" CodeFile="onduty_query.aspx.cs" Inherits="onduty_query" Title="值班記錄-查詢" %>
<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" Runat="Server">
<head id="Head1" >
    <title>值班記錄-查詢</title>
<link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" /></head>
    <asp:UpdateProgress ID="UpdateProgress1" runat="server" DisplayAfter="100" EnableViewState="False">
        <ProgressTemplate>
            <div id="updating" style="width: 150px; height: 25px; color: #A52A2A; position: absolute;
                left: 50%; top: 50%; margin-top: -50px; margin-left: -100px; text-align: center;
                border: black 3px double; background-color: #99CCFF;">
                資料更新中.....
            </div>
        </ProgressTemplate>
    </asp:UpdateProgress>
 
 <div style="display: inline; z-index: 105; left: 10px; width: 100%; color: black;
            top: 0px; height: 16px; background-color: white">
    <%--        <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>--%>
              <br />
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
                                    <table width="100%" >
                                        <tr>
                                            <td align="left" style="width: 533px; height: 24px;">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>值班記錄-查詢</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 24px;">
                                                * 表示必填!</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%;">
                                    表單編號</td>
                                <td align="left" colspan="3" valign="top">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    班別</td>
                                <td align="left" style="height: 24px" valign="top" colspan="3">
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    來電時間範圍 From</td>
                                <td align="left" style="width: 200px; height: 24px" valign="top">
                                    <telerik:RadDatePicker ID="txtEstimateStartDate" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007" Height="15px" Width="90px">
                                                <DateInput DateFormat="yyyy/MM/dd" Font-Size="10pt"
                                                    ReadOnly="True" Skin="Office2007" Height="15px">
                                                </DateInput>
                                                <Calendar Skin="Office2007" UseColumnHeadersAsSelectors="False" UseRowHeadersAsSelectors="False" ViewSelectorText="x">
                                                    <SpecialDays>
                                                        <telerik:RadCalendarDay Date="" Repeatable="Today">
                                                            <ItemStyle CssClass="rcToday" />
                                                        </telerik:RadCalendarDay>
                                                    </SpecialDays>
                                                </Calendar>
                                        <DatePopupButton HoverImageUrl="" ImageUrl="" />
                                            </telerik:RadDatePicker>
                                            <asp:DropDownList ID="DropDownList5" runat="server">
                                            </asp:DropDownList>時<asp:DropDownList ID="DropDownList8" runat="server">
                                            </asp:DropDownList>分
                                            </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    來電時間範圍To</td>
                                <td align="left" style="width: 200px; height: 24px" valign="top">
                                    <telerik:RadDatePicker ID="txtEstimateEndDate" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007" Height="15px" Width="90px">
                                                <DateInput DateFormat="yyyy/MM/dd" Font-Size="10pt" ReadOnly="True" Skin="Office2007" Height="15px">
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
                                            <asp:DropDownList ID="DropDownList15" runat="server">
                                            </asp:DropDownList>時<asp:DropDownList ID="DropDownList18" runat="server">
                                            </asp:DropDownList>分</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    關鍵字查詢</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox2" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    來電者</td>
                                <td align="left" style="height: 24px" valign="top" colspan="3">
                                    <asp:TextBox ID="TextBox3" runat="server"></asp:TextBox></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    值班工程師</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList4" runat="server">
                                            </asp:DropDownList><br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    FAB</td>
                                <td align="left" style="width: 188px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    SYSTEM</td>
                                <td style="width: 37px; height: 24px">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    CLOSE FLAG</td>
                                <td align="left" style="width: 188px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList3" runat="server">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    ARS FLAG</td>
                                <td style="width: 37px; height: 24px">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList12" runat="server">
                                            </asp:DropDownList>
                                            <br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    ALARM_FLAG</td>
                                <td align="left" style="width: 188px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList10" runat="server">
                                            </asp:DropDownList><br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    TYPE/生產影響</td>
                                <td style="width: 37px; height: 24px; vertical-align: top;">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <table>
                                                <tr>
                                                    <td align="left" valign="top">
                                                        <asp:DropDownList ID="DropDownList6" runat="server">
                                                        </asp:DropDownList>/
                                                    </td>
                                                    <td>
                                                        <asp:DropDownList ID="DropDownList7" runat="server">
                                                        </asp:DropDownList>
                                                        <br />
                                                    </td>
                                                </tr>
                                            </table>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 14%; height: 24px">
                                    處理者</td>
                                <td align="left" style="width: 188px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList9" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    Assign To</td>
                                <td style="width: 37px; height: 24px">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList11" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px">
                                    <asp:Button ID="ButtonQuery" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Query" OnClick="ButtonQuery_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnExport" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Export" OnClick="btnExport_Click1" />&nbsp; (預設抓1天資料) &nbsp;
                                    &nbsp; &nbsp; 總共
                                    <asp:Label ID="Label1" runat="server" Text="Label"></asp:Label>&nbsp; 筆 開立 ARS
                                    <asp:Label ID="Label2" runat="server" Text="Label"></asp:Label>
                                    筆 開立 OPEN
                                    <asp:Label ID="Label3" runat="server" Text="Label"></asp:Label>
                                    筆 開立 ALARM
                                    <asp:Label ID="Label4" runat="server" Text="Label"></asp:Label>
                                    筆 開立 AssignTo
                                    <asp:Label ID="Label5" runat="server" Text="Label"></asp:Label>
                                    筆</td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8">
                                    <asp:HyperLink ID="HyperLink2" runat="server" NavigateUrl="onduty_calendar.aspx"
                                        Target="_blank">Onduty Calendar</asp:HyperLink>&nbsp;
                                         <asp:HyperLink ID="HyperLink5" runat="server" NavigateUrl="http://10.56.131.22/E-FAB_dotnet/Alarm/t1NewAlarmServerEvent.aspx"
                                        Target="_blank">CIM New Alarm Phone</asp:HyperLink>&nbsp;
                                    <asp:HyperLink ID="HyperLink3" runat="server" NavigateUrl="http://172.16.13.73/alarm/QueryForm_at.php"
                                        Target="_blank">AT Alarm Phone</asp:HyperLink>
                                    <asp:HyperLink ID="HyperLink4" runat="server" NavigateUrl="http://10.56.131.22/E-FAB_dotnet/report_creat_time.aspx"
                                        Target="_blank">Report Interval</asp:HyperLink>&nbsp;<asp:Button ID="Button1" runat="server"
                                            OnClick="Button1_Click" Text="視窗放大" />
                                    <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="關閉視窗" /></td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <fieldset>
                                        <legend id="Legend5" runat="server" style="font-weight: bold; font-size: 12px; font-family: Arial;
                                            color: black">&nbsp;&nbsp;&nbsp;查詢結果 </legend>
                                        <br />
                                        
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 169px">
                                                    <%--<asp:GridView ID="gvTask" runat="server" Font-Names="Arial" Font-Size="12px" Width="100%"
                                                        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Task!" OnRowDataBound="gvTask_RowDataBound"
                                                        ForeColor="#333333" GridLines="None">--%>
                                                         <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:GridView ID="GridView1" runat="server" Font-Names="Century Gothic" Font-Size="X-Small"
                                                        Width="800px" AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
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
                                                             <asp:TemplateField HeaderText="FAB">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                
                                                                    <asp:Label ID="lblfab" runat="server" ForeColor="DarkGreen" Text='<%# Bind("FAB") %>'></asp:Label></br>
                                                                  
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="System">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                
                                                                    <asp:Label ID="lblSystem" runat="server" ForeColor="DarkGreen" Text='<%# Bind("System") %>'></asp:Label></br>
                                                                  
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Impact">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                  
                                                                    <asp:Label ID="lblArea" runat="server" ForeColor="DarkGreen" Text='<%# Bind("product_impact") %>'></asp:Label></br>
                                                                  
                                                                   
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                             <asp:TemplateField HeaderText="Type">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                  
                                                                    <asp:Label ID="lbltype" runat="server" ForeColor="DarkGreen" Text='<%# Bind("type") %>'></asp:Label></br>
                                                                  
                                                                   
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
                                                                    排除方法:</br>
                                                                    <asp:Label ID="lblmethod" runat="server" ForeColor="DarkGreen" Text='<%# Bind("method") %>'></asp:Label></br>
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
                                                            <asp:TemplateField HeaderText="值班人員">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblengineer" runat="server" ForeColor="DarkGreen" Text='<%# Bind("engineer") %>'></asp:Label></br>
                                                                    處理時間:</br>
                                                                    <asp:Label ID="lbldue_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("due_time") %>'></asp:Label>&nbsp
                                                                    分</br>
                                                                   <%-- AssignTo:</br>
                                                                    <asp:Label ID="lblbassign_owner" runat="server" ForeColor="DarkGreen" Text='<%# Bind("assign_owner") %>'></asp:Label>&nbsp
                                                                    </br>--%>
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
                                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                                        <AlternatingRowStyle BackColor="#EFEDEF" />
                                                    </asp:GridView>
                                        </ContentTemplate>
                                      <%--    <Triggers>
                <asp:AsyncPostBackTrigger ControlID="ButtonQuery" EventName="Click" />
            </Triggers>--%>
                                    </asp:UpdatePanel>
                                                   
                              
                                                </td>
                                            </tr>
                                        </table>
                                         
                                    </fieldset>
                                </td>
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
 
</div>
</asp:Content>


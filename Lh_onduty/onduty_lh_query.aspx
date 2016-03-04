<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onduty_lh_query.aspx.cs"
    Inherits="onduty_lh_query" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>LH出勤資料-查詢</title>
    <link href="../app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>
            <br />
            <table id="Table3" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 9px">
                        <img src="../images/tables/default_lt.gif" /></td>
                    <td style="background-image: url(../images/tables/default_t.gif); height: 9px;">
                        <img height="9" src="../images/tables/transparent.gif" /></td>
                    <td style="height: 9px">
                        <img src="../images/tables/default_rt.gif" /></td>
                </tr>
                <tr>
                    <td style="background-image: url(../images/tables/default_l.gif)">
                        <img src="../images/tables/transparent.gif" width="9"></td>
                    <td align="middle" width="100%">
                        <table align="center" cellspacing="0" bordercolordark="#ffffff" cellpadding="2" width="90%"
                            bordercolorlight="#7a9cb7" border="1">
                            <tr>
                                <td background="" colspan="4" class="pageTitle" style="height: 71px">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="width: 533px">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>LH出勤資料-查詢</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy">
                                                * 表示必填!</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr>
                                <td class="pageTD" align="center" style="height: 24px; width: 12%;">
                                    發生時間(開始)</td>
                                <td style="width: 107px; height: 24px;" align="left" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel4" runat="server">
                                        <ContentTemplate>
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    <td class="pageTD" align="center" style="height: 24px; width: 12%;">
                                        發生時間(結束)</td>
                                <td style="width: 107px; height: 24px;" align="left" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
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
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    違規種類</td>
                                <td align="left" style="width: 107px; height: 24px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    違規人員工號</td>
                                <td style="width: 37px; height: 24px">
                                    <asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                        <ContentTemplate>
                                            <asp:TextBox ID="TextBox_empo" runat="server"></asp:TextBox><br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 21px">
                                    BU名稱</td>
                                <td align="left" style="width: 107px; height: 21px" valign="top">
                                    <asp:DropDownList ID="DropDownList3" runat="server" OnSelectedIndexChanged="DropDownList3_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 21px">
                                    處別名稱</td>
                                <td style="width: 37px; height: 21px" valign="top">
                                    <asp:DropDownList ID="DropDownList12" runat="server" OnSelectedIndexChanged="DropDownList12_SelectedIndexChanged"
                                        AutoPostBack="True">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 21px">
                                    部門名稱</td>
                                <td align="left" style="width: 107px; height: 21px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList4" runat="server">
                                            </asp:DropDownList><br />
                                            &nbsp;<br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 21px">
                                    異常真因</td>
                                <td style="width: 37px; height: 21px">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList6" runat="server">
                                            </asp:DropDownList><br />
                                            &nbsp;<br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 21px">
                                    狀態</td>
                                <td align="left" colspan="3" style="height: 21px" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 23px">
                                    <asp:Button ID="ButtonQuery" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Query" OnClick="ButtonQuery_Click" />
                                    &nbsp;
                                    <asp:Button ID="btnExport" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="Export" OnClick="btnExport_Click1" />&nbsp; (預設抓7天資料)</td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    <fieldset>
                                        <legend id="Legend5" runat="server" style="font-weight: bold; font-size: 12px; font-family: Arial;
                                            color: black">&nbsp;&nbsp;&nbsp;查詢結果 </legend>
                                        <table width="100%">
                                            <tr>
                                                <td style="height: 169px">
                                                    <%--<asp:GridView ID="gvTask" runat="server" Font-Names="Arial" Font-Size="12px" Width="100%"
                                                        AutoGenerateColumns="False" CellPadding="4" EmptyDataText="No Task!" OnRowDataBound="gvTask_RowDataBound"
                                                        ForeColor="#333333" GridLines="None">--%>
                                                    <asp:GridView ID="GridView1" runat="server" Font-Names="Arial" Font-Size="12px" Width="1000px"
                                                        AutoGenerateColumns="False" CellPadding="3" BackColor="White" BorderColor="#CCCCCC"
                                                        OnRowDataBound="GridView1_RowDataBound" BorderStyle="None" BorderWidth="1px"
                                                        EmptyDataText="No Record!">
                                                        <RowStyle ForeColor="#000066" />
                                                        <Columns>
                                                            <asp:TemplateField HeaderText="RN">
                                                                <ItemTemplate>
                                                                    <asp:Label ID="lblrownum" runat="server" ForeColor="DarkGreen" Text='<%# Bind("rownum") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="開始時間">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    SN:</br>
                                                                    <asp:HyperLink ID="HyperLink1" Target="_blank" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/Lh_onduty/onduty_lh_record.aspx?SN=" + DataBinder.Eval(Container.DataItem, "SN")%> '
                                                                        Text='<%# Bind("SN") %>' ForeColor="#FF0000" runat="server"></asp:HyperLink></br>
                                                                    開始時間:</br>
                                                                    <asp:Label ID="lbldate_time" runat="server" ForeColor="DarkGreen" Text='<%# Bind("date_time") %>'></asp:Label></br>
                                                                    更新時間:</br>
                                                                    <asp:Label ID="lbldttm" runat="server" ForeColor="DarkGreen" Text='<%# Bind("dttm") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="名稱">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    BU:</br>
                                                                    <asp:Label ID="lblbuname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("buname") %>'></asp:Label></br>
                                                                    DIV:</br>
                                                                    <asp:Label ID="lbldivname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("divname") %>'></asp:Label></br>
                                                                    Dep:</br>
                                                                    <asp:Label ID="lbldep_name" runat="server" ForeColor="DarkGreen" Text='<%# Bind("dep_name") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="人員">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    工號:</br>
                                                                    <asp:Label ID="lblempno" runat="server" ForeColor="DarkGreen" Text='<%# Bind("empno") %>'></asp:Label></br>
                                                                    姓名:</br>
                                                                    <asp:Label ID="lblempname" runat="server" ForeColor="DarkGreen" Text='<%# Bind("empname") %>'></asp:Label></br>
                                                                    連續工作天數:</br>
                                                                    <asp:Label ID="lbldays_workcontinue" runat="server" ForeColor="DarkGreen" Text='<%# Bind("days_workcontinue") %>'></asp:Label></br>
                                                                    狀態:</br>
                                                                    <asp:Label ID="lblstatus" runat="server" ForeColor="DarkGreen" Text='<%# Bind("status") %>'></asp:Label></br>
                                                                    結案人:</br>
                                                                    <asp:Label ID="lblclose_person" runat="server" ForeColor="DarkGreen" Text='<%# Bind("close_person") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="描述">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" VerticalAlign="Top" />
                                                                <ItemTemplate>
                                                                    違規種類:</br>
                                                                    <asp:Label ID="lbltype_name" runat="server" ForeColor="DarkGreen" Text='<%# Bind("type_name") %>'></asp:Label></br>
                                                                    異常真因:</br>
                                                                    <asp:Label ID="lblcategory" runat="server" ForeColor="DarkGreen" Text='<%# Bind("category") %>'></asp:Label></br>
                                                                    異常描述:</br>
                                                                    <asp:Label ID="lbldescription" runat="server" ForeColor="DarkGreen" Text='<%# Bind("description") %>'></asp:Label></br>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                            <asp:TemplateField HeaderText="下載檔案">
                                                                <HeaderStyle HorizontalAlign="Center" />
                                                                <ItemStyle HorizontalAlign="Left" />
                                                                <ItemTemplate>
                                                                    <asp:DataList ID="DataList1" runat="server" CellPadding="4" ForeColor="#333333" RepeatColumns="1">
                                                                        <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="Black" />
                                                                        <SelectedItemStyle BackColor="#C5BBAF" Font-Bold="True" ForeColor="#333333" />
                                                                        <ItemTemplate>
                                                                            <asp:HyperLink ID="HyperLink12" Target="_blank" NavigateUrl='<%#"http://"+ Server.MachineName +Context.Request.ApplicationPath+"/Lh_onduty/upload_file/" + DataBinder.Eval(Container.DataItem, "file_name") %> '
                                                                                Text='<%# Bind("file_name") %>' ForeColor="#3617E3" runat="server"></asp:HyperLink>
                                                                        </ItemTemplate>
                                                                        <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                                                                    </asp:DataList>
                                                                </ItemTemplate>
                                                            </asp:TemplateField>
                                                        </Columns>
                                                        <FooterStyle BackColor="#507CD1" ForeColor="White" Font-Bold="True" />
                                                        <PagerStyle BackColor="White" ForeColor="#000066" HorizontalAlign="Left" />
                                                        <SelectedRowStyle BackColor="#669999" Font-Bold="True" ForeColor="White" />
                                                        <HeaderStyle BackColor="#DEDFDE" Font-Bold="True" ForeColor="Black" />
                                                    </asp:GridView>
                                                </td>
                                            </tr>
                                        </table>
                                    </fieldset>
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="font-size: 12pt; background-image: url(../images/tables/default_r.gif)">
                        <img src="../images/tables/transparent.gif" width="9"></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 9px">
                        <img src="../images/tables/default_lb.gif"></td>
                    <td style="background-image: url(../images/tables/default_b.gif); height: 9px;">
                        <img height="9" src="../images/tables/transparent.gif"></td>
                    <td style="height: 9px">
                        <img src="../images/tables/default_rb.gif"></td>
                </tr>
            </table>
    </form>
</body>
</html>

<script language="javascript">
function check_field()
{
    if( document.getElementById("txtProjectDesc").value=="")
    {
        alert("請輸入Project Description");
        return false;
    }
    else if( document.getElementById("txtEstimateStartDate").value=="")
    {
        alert("請輸入預計開始日");
        return false;
    }
    else if( document.getElementById("txtEstimateEndDate").value=="")
    {
        alert("請輸入預計完成日");
        return false;
    }
      else if( document.getElementById("File1").value!="" && document.getElementById("txtFileDesc1").value=="")
    {
        alert("請輸入File Description");
        return false;
    }
      else if (document.getElementById("txtPrice").value!="" && isNaN(document.getElementById("txtPrice").value)==true)
    {
        alert("請輸入效益(金額)且為數字");
        return false;
    }
    else
    {
        return true;
    }
     
}


function AddTask()
{
//   w = window.open("task_apply.aspx?project_id="+ document.getElementById('lblProjectNo').innerText ,"Add_task", "height=600, width=950, left=200, top=150, " +  "location=no,	menubar=no, resizable=yes, " + "scrollbars=yes, titlebar=no, toolbar=no", true);
//   w.focus();
   return false;
}

function OpenTask(task_id)
{
//   w = window.open("task_assign.aspx?task_id="+ task_id ,"task_maintain", "height=600, width=950, left=200, top=150, " +  "location=yes,	menubar=yes, resizable=yes, " + "scrollbars=yes, titlebar=no, toolbar=yes", true);
//   w.focus();
   return false;
}

function showHideAnswer(obj,imgObj)
{
    if (document.getElementById(obj) == null)
        return;
    if(document.getElementById(obj).style.display=='none'){
        document.getElementById(imgObj).src = "../images/close13.gif";
	    document.getElementById(obj).style.display='block';
    }else{
        document.getElementById(imgObj).src = "../images/open13.gif";
	    document.getElementById(obj).style.display='none';
    }		
}
</script>


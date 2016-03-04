<%@ Page Language="C#" AutoEventWireup="true"  validateRequest="False" EnableEventValidation="false" CodeFile="onduty_record.aspx.cs" Inherits="onduty_record" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>值班記錄-更新</title>
    <link href="app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    &nbsp;<form id="form1" runat="server">
       
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
          <asp:ScriptManager id="ScriptManager1" runat="server">
                                    </asp:ScriptManager>
            <table id="Table3" align="center" border="0" cellpadding="0" cellspacing="0" width="100%">
                <tr>
                    <td style="height: 9px; width: 10px;">
                        <img src="images/tables/default_lt.gif" /></td>
                    <td style="background-image: url(images/tables/default_t.gif); height: 9px; width: 888px;">
                        <img height="9" src="images/tables/transparent.gif" /></td>
                    <td style="height: 9px">
                        <img src="images/tables/default_rt.gif" /></td>
                </tr>
                <tr>
                    <td style="background-image: url(images/tables/default_l.gif); width: 10px;">
                        <img src="images/tables/transparent.gif" width="9"></td>
                    <td align="middle" style="width: 888px">
                        <table align="center" cellspacing="0" bordercolordark="#ffffff" cellpadding="2" width="90%"
                            bordercolorlight="#7a9cb7" border="1">
                            <tr>
                                <td background="" colspan="4" class="pageTitle" style="height: 24px; text-align: left;">
                                    <table width="100%"  >
                                        <tr>
                                            <td align="left" style="width: 533px">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>值班記錄-更新</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy">
                                                * 表示必填!</td>
                                        </tr>
                                    </table>
                                    <span style="font-size: 16pt; font-family: Century Gothic"><span style="font-size: 8pt;
                                        font-family: Times New Roman"></span></span>
                                
                                </td>
                            </tr>
                            <tr style="font-family: Times New Roman">
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    表單編號</td>
                                <td align="left" colspan="3" style="height: 24px" >
                                    <asp:Label ID="Label_SEQ" runat="server" Text="Label"></asp:Label>&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    班別</td>
                                <td align="left" style="width: 107px; height: 24px" >
                                    <asp:RadioButtonList ID="RadioButtonList_OFFDAY" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    值班手機</td>
                                <td align="left" style="width: 106px; height: 24px" >
                                    <asp:TextBox ID="TextBox_MOBILE" runat="server"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    值班工程師</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:DropDownList ID="DropDownList_ENG_DEP" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList_ENG_DEP_SelectedIndexChanged">
                                    </asp:DropDownList>
                                    /<asp:DropDownList ID="DropDownList_ENGINEER" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 49px">
                                    來電時間</td>
                                <td align="left" style="height: 24px" valign="top" colspan="3">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <telerik:RadDatePicker ID="txtEstimateCALLTIME" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007"><DateInput DateFormat="yyyy/MM/dd" Font-Size="10pt"
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
                                            </telerik:RadDatePicker>
                                            <br />
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>時
                                            <asp:DropDownList ID="DropDownList2" runat="server">
                                            </asp:DropDownList>分
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    來電人員</td>
                                <td align="left" style="width: 107px; height: 24px">
                                    <asp:TextBox ID="TextBox_CALLER" runat="server"></asp:TextBox>
                                    </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    來電手機</td>
                                <td align="left" style="width: 106px; height: 24px" >
                                    <asp:TextBox ID="TextBox_EXTENTION" runat="server"></asp:TextBox>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    FAB/AREA</td>
                                <td align="left" style="width: 107px; height: 24px" valign="top">
                                   <table>
                                   <tr>
                                   <td valign="top">
                                    <asp:DropDownList ID="DropDownList1_FAB" runat="server" AutoPostBack="True" OnSelectedIndexChanged="DropDownList1_FAB_SelectedIndexChanged">
                                    </asp:DropDownList>/
                                   </td>
                                   <td>
                                       <asp:DropDownList ID="DropDownList_AREA" runat="server">
                                    </asp:DropDownList>
                              
                                   </td>
                                   </tr>
                                   </table>
                                  </td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    SYSTEM</td>
                                <td align="left" style="width: 106px; height: 24px" valign="top">
                                    <asp:DropDownList ID="DropDownList_SYSTEM" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    TYPE/生產影響</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:DropDownList ID="DropDownList_TYPE" runat="server">
                                    </asp:DropDownList>/<asp:DropDownList ID="DropDownList_PRODUCT_IMPACT" runat="server">
                                    </asp:DropDownList>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 51px">
                                    生產影響敘述<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 51px" valign="top">
                                    <asp:TextBox ID="TextBox_PRODUCT_IMPACT_INFO" runat="server" Height="70px" TextMode="MultiLine"
                                        Width="450px"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    CASSETTE</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_CASSETTE" runat="server"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    LOT_ID</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_LOT_ID" runat="server"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    EQ_ID</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_EQ_ID" runat="server"></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    來電問題<span style="color: #ff0000">﹡</span></td>
                                <td align="left" colspan="3" style="height: 76px" valign="top">
                                    <asp:TextBox ID="TextBox_QUESTION" runat="server" Height="70px" TextMode="MultiLine" Width="450px" ></asp:TextBox>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    發生時間<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top"><asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDatePicker ID="txtEstimateSTARTTIME" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007">
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
                                        </telerik:RadDatePicker>
                                        <br />
                                        <asp:DropDownList ID="DropDownList3" runat="server">
                                        </asp:DropDownList>時
                                        <asp:DropDownList ID="DropDownList4" runat="server">
                                        </asp:DropDownList>分
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                    &nbsp;&nbsp;
                                </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    修復時間<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 76px; font-size: 12pt;" valign="top"><asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                    <ContentTemplate>
                                        <telerik:RadDatePicker ID="txtEstimateEndTime" runat="server" EnableTyping="False"
                                                Skin="Office2007" SkinID="Office2007">
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
                                        </telerik:RadDatePicker>
                                        <br />
                                        <asp:DropDownList ID="DropDownList5" runat="server">
                                        </asp:DropDownList>時
                                        <asp:DropDownList ID="DropDownList6" runat="server">
                                        </asp:DropDownList>分
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                    &nbsp;<br />
                                    處理時間&nbsp;
                                    <asp:Label ID="Label1" runat="server" Font-Bold="True" Font-Size="Medium" Text="Label"></asp:Label>&nbsp;
                                    分(標準處理時間 <strong><span style="font-size: 12pt"><span style="color: blue">30</span> </span>
                                    </strong>分鐘)</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    處理者<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:DropDownList ID="DropDownList_BY_WHOM" runat="server">
                                    </asp:DropDownList></td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    異常描述<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_DESCRIPTION" runat="server" Height="70px" TextMode="MultiLine" Width="450px"></asp:TextBox>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    異常原因<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_REASON" runat="server" Height="70px" TextMode="MultiLine" Width="450px"></asp:TextBox>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    排除方法<span style="color: red">﹡</span></td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_METHOD" runat="server" Height="70px" TextMode="MultiLine" Width="450px"></asp:TextBox>&nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    CLOSE_FLAG</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:RadioButtonList ID="RadioButtonList_CLOSE_FLAG" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    ALARM_FLAG</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:RadioButtonList ID="RadioButtonList_ALARM_FLAG" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    ARS_FLAG</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:RadioButtonList ID="RadioButtonList_ARS_FLAG" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    ARS_LINK
                                </td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_ARS_LINK" runat="server" Height="70px" TextMode="MultiLine"
                                        Width="450px"></asp:TextBox><br />
                                    &nbsp;
                                    <asp:HyperLink ID="HyperLink_ARS_LINK" runat="server" ForeColor="Blue" Visible="False" Font-Size="Medium">ARS_LINK</asp:HyperLink>
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    Assign To</td>
                                <td align="left" style="width: 107px; height: 24px" >
                                    <asp:DropDownList ID="DropDownList_ASSIGN_OWNER" runat="server">
                                    </asp:DropDownList></td>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    REJUDGE(改判)</td>
                                <td align="left" style="width: 106px; height: 24px" >
                                    <asp:RadioButtonList ID="RadioButtonList1" runat="server" RepeatDirection="Horizontal">
                                    </asp:RadioButtonList>
                                    </td>
                            </tr>
                            <tr>
                                <td align="center" class="pageTD" style="width: 12%; height: 24px">
                                    矯正對策</td>
                                <td align="left" colspan="3" style="height: 24px" valign="top">
                                    <asp:TextBox ID="TextBox_ADDITION_INFO" runat="server" Height="70px" TextMode="MultiLine"
                                        Width="450px"></asp:TextBox>&nbsp;&nbsp;&nbsp;</td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px">
                                    <asp:Button ID="ButtonModify" runat="server" Style="font-size: 12px; font-family: Arial;
                                        width: 100px;" Text="修改" OnClientClick="return check_field();" OnClick="ButtonModify_Click" />
                                    &nbsp;&nbsp; &nbsp;
                                </td>
                            </tr>
                        </table>
                    </td>
                    <td style="font-size: 12pt; background-image: url(images/tables/default_r.gif)">
                        <img src="images/tables/transparent.gif" width="9"></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 9px; width: 10px;">
                        <img src="images/tables/default_lb.gif"></td>
                    <td style="background-image: url(images/tables/default_b.gif); height: 9px; width: 888px;">
                        <img height="9" src="images/tables/transparent.gif"></td>
                    <td style="height: 9px">
                        <img src="images/tables/default_rb.gif"></td>
                </tr>
            </table>
    </form>
</body>
</html>

<script language="javascript">
function check_field()
{
    if( document.getElementById("TextBox_PRODUCT_IMPACT_INFO").value=="")
    {
        alert("請輸入生產影響敘述 ");
        return false;
    }
    else if( document.getElementById("TextBox_QUESTION").value=="")
    {
        alert("請輸入來電問題");
        return false;
    }
    else if( document.getElementById("DropDownList_BY_WHOM").value=="請選擇")
    {
        alert("請輸入處理者");
        return false;
    }
    else if( document.getElementById("TextBox_DESCRIPTION").value=="")
    {
        alert("請輸入異常描述");
        return false;
    }
    else if( document.getElementById("TextBox_REASON").value=="")
    {
        alert("請輸入異常原因");
        return false;
    }
    else if( document.getElementById("TextBox_METHOD").value=="")
    {
        alert("請輸入排除方法");
        return false;
    }
//      else if( document.getElementById("File1").value!="" && document.getElementById("txtFileDesc1").value=="")
//    {
//        alert("請輸入File Description");
//        return false;
//    }
//      else if (document.getElementById("txtPrice").value!="" && isNaN(document.getElementById("txtPrice").value)==true)
//    {
//        alert("請輸入效益(金額)且為數字");
//        return false;
//    }
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
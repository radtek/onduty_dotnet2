<%@ Page Language="C#" AutoEventWireup="true" CodeFile="onduty_lh_record.aspx.cs" Inherits="Lh_onduty_onduty_lh_record" %>

<%@ Register Assembly="Telerik.Web.UI" Namespace="Telerik.Web.UI" TagPrefix="telerik" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="head1" runat="server">
    <title>LH出勤資料</title>
    <link href="../app_themes/layout/layout.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
        <div style="display: inline; z-index: 105; left: 10px; width: 90%; color: black;
            top: 0px; height: 16px; background-color: white">
            <asp:ScriptManager ID="ScriptManager1" runat="server" EnableScriptGlobalization="True">
            </asp:ScriptManager>
            <br />
            <table id="Table3" align="center" border="0" cellpadding="0" cellspacing="0" width="98%">
                <tr>
                    <td style="height: 9px">
                        <img src="../images/tables/default_lt.gif" /></td>
                    <td style="background-image: url(../images/tables/default_t.gif); height: 9px;">
                        <img height="9" src="../images/tables/transparent.gif" /></td>
                    <td style="height: 9px; width: 10px;">
                        <img src="../images/tables/default_rt.gif" /></td>
                </tr>
                <tr>
                    <td style="background-image: url(../images/tables/default_l.gif)">
                        <img src="../images/tables/transparent.gif" width="9"></td>
                    <td align="middle" width="100%">
                        <table align="center" cellspacing="0" bordercolordark="#ffffff" cellpadding="2" width="100%"
                            bordercolorlight="#7a9cb7" border="1">
                            <tr>
                                <td background="" colspan="4" class="pageTitle">
                                    <table width="100%">
                                        <tr>
                                            <td align="left" style="height: 30px">
                                                <span id="Span1" style="font-size: 16pt; font-family: Century Gothic"><strong>LH出勤資料-更新</strong></span></td>
                                            <td align="right" style="font-size: 12px; color: navy; height: 30px;">
                                                <span style="color: #ff0000">*</span> 表示必填!</td>
                                        </tr>
                                    </table>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" colspan="4" style="height: 10px; text-align: left"
                                    valign="middle">
                                    <span style="color: navy">Step 1</span></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 15%; height: 22px; text-align: center"
                                    valign="middle">
                                    出勤違規編號/ Sheet Abnormal No.<span style="color: red">*</span></td>
                                <td style="width: 341px; height: 22px; text-align: left" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel11" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label3" runat="server" Text="Label" Width="200px"></asp:Label>&nbsp;
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center">
                                    狀態/Status<span style="color: #ff0000">*</span></td>
                                <td align="left" colspan="1" style="width: 327px; height: 22px; text-align: left"
                                    valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel5" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList5" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" valign="middle" style="height: 22px; width: 15%;
                                    text-align: center;">
                                    違規出勤員工姓名<span style="color: #ff0000">*</span></td>
                                &nbsp;
                                <td style="text-align: left; width: 341px; height: 22px;" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel1" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label4" runat="server" Text="Label" Width="200px"></asp:Label><br />
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    &nbsp;
                                </td>
                                <td class="pageTD" style="width: 10%; height: 22px; text-align: center;">
                                    違規出勤員工工號<span style="color: red">*</span></td>
                                <td colspan="1" align="left" valign="top" style="text-align: left; height: 22px;
                                    width: 327px;">
                                    <asp:UpdatePanel ID="UpdatePanel2" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label1" runat="server" Text="Label" Width="200px"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td class="pageTD" align="center" style="height: 5px; width: 15%;">
                                    所屬BU名稱<span style="color: red">*&nbsp;</span></td>
                                <td style="width: 341px; height: 5px; text-align: left;" valign="top"><asp:UpdatePanel ID="UpdatePanel3" runat="server">
                                    <ContentTemplate>
                                        <asp:Label ID="Label7" runat="server" Text="Label" Width="200px"></asp:Label>
                                    </ContentTemplate>
                                </asp:UpdatePanel>
                                    &nbsp; &nbsp;
                                </td>
                                <td class="pageTD" align="center" style="height: 5px; width: 10%;">
                                    所屬處別名稱<span style="color: red">*</span></td>
                                <td style="width: 327px; height: 5px; text-align: left;">
                                    <asp:UpdatePanel ID="UpdatePanel9" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label8" runat="server" Text="Label" Width="200px"></asp:Label>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                    &nbsp; &nbsp;&nbsp; &nbsp;
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 15%; height: 5px">
                                    所屬部門名稱<span style="color: #ff0000">*</span></td>
                                <td style="width: 341px; height: 5px; text-align: left" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel6" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label9" runat="server" Text="Label" Width="200px"></asp:Label></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 10%; height: 5px">
                                    違規項目<span style="color: #ff0000">*</span></td>
                                <td style="width: 327px; height: 5px; text-align: left">
                                    <asp:UpdatePanel ID="UpdatePanel7" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label10" runat="server" Text="Label" Width="200px"></asp:Label></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 15%; height: 4px">
                                    違規數值<span style="color: #ff0000">*</span></td>
                                <td style="width: 341px; height: 4px; text-align: left" valign="top">
                                    <asp:UpdatePanel ID="UpdatePanel8" runat="server">
                                        <ContentTemplate>
                                            <asp:Label ID="Label5" runat="server" Height="17px" Text="Label" Width="200px"></asp:Label></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                                <td align="center" class="pageTD" style="width: 10%; height: 4px">
                                    開單時間<span style="color: #ff0000">*</span></td>
                                <td style="width: 327px; height: 4px; text-align: left">
                                    <asp:UpdatePanel ID="UpdatePanel10" runat="server">
                                        <ContentTemplate>
                                            &nbsp;<asp:Label ID="Label6" runat="server" Height="20px" Text="Label" Width="200px"></asp:Label></ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 15%; height: 4px">
                                    違規改善方式(簡略)</td>
                                <td colspan="3" style="height: 4px; text-align: left" valign="top">
                                    <asp:TextBox ID="TextBox5" runat="server" Height="100px" TextMode="MultiLine" Width="700px" OnTextChanged="TextBox5_TextChanged"></asp:TextBox></td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 15%; height: 4px">
                                    <span style="color: #000000">
                                    上傳檔案</span></td>
                                <td style="width: 341px; height: 4px; text-align: left" valign="top">
                                    <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="上傳Link" />&nbsp</td>
                                <td align="center" class="pageTD" style="width: 10%; height: 4px">
                                    <span style="color: #ff0000"><span style="color: #000000">異常真因</span>*</span></td>
                                <td style="width: 327px; height: 4px; text-align: left">
                                    <asp:UpdatePanel ID="UpdatePanel12" runat="server">
                                        <ContentTemplate>
                                            <asp:DropDownList ID="DropDownList1" runat="server">
                                            </asp:DropDownList>
                                        </ContentTemplate>
                                    </asp:UpdatePanel>
                                </td>
                            </tr>
                            <tr style="font-size: 12pt">
                                <td align="center" class="pageTD" style="width: 15%; height: 4px">
                                    結案人</td>
                                <td style="width: 341px; height: 4px; text-align: left" valign="top">
                                    <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                                <td align="center" class="pageTD" style="width: 10%; height: 4px">
                                    結案時間</td>
                                <td style="width: 327px; height: 4px; text-align: left">
                                    <asp:Label ID="Label11" runat="server" Text="Label" Width="163px"></asp:Label></td>
                            </tr>
                            <tr>
                                <td class="pageTD" colspan="8" style="height: 35px; text-align: left;">
                                    <asp:Button ID="Button2" runat="server" OnClientClick="return check_field();"   OnClick="Button2_Click" Text="Modify" />
                                    &nbsp; &nbsp; 
                                    <asp:Label ID="Label2" runat="server" Text="Label" Visible="False"></asp:Label>
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                                    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;
                                    &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp; &nbsp; &nbsp;&nbsp;&nbsp;
                                    &nbsp; &nbsp;&nbsp;&nbsp; &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp;&nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp; &nbsp;
                                    &nbsp;</td>
                            </tr>
                            <tr>
                                <td colspan="8">
                                    &nbsp;</td>
                            </tr>
                        </table>
                    </td>
                    <td style="font-size: 12pt; background-image: url(../images/tables/default_r.gif);
                        width: 10px;">
                        <img src="../images/tables/transparent.gif" width="9"></td>
                </tr>
                <tr style="font-size: 12pt">
                    <td style="height: 9px">
                        <img src="../images/tables/default_lb.gif"></td>
                    <td style="background-image: url(../images/tables/default_b.gif); height: 9px;">
                        <img height="9" src="../images/tables/transparent.gif"></td>
                    <td style="height: 9px; width: 10px;">
                        <img src="../images/tables/default_rb.gif"></td>
                </tr>
            </table>
    </form>
</body>
</html>

<script language="javascript">
function check_field()
{
    
   
  if(document.getElementById("TextBox5").value==""  )
    {
        alert("請輸入 違規改善方式(簡略)!!!");
        return false;
    }
    
    
      
      else if(document.getElementById("DropDownList5").value=="Closed"&& document.getElementById("DropDownList1").value=="請選擇" )
    {
          alert("請輸入 異常真因!!!");
        return false;
        
    }
    
    else if(document.getElementById("DropDownList5").value=="Closed" && document.getElementById("TextBox1").innerHTML=="")
    {
          alert("請輸入 結案人!!!");
        return false;
        
    }

    
     else if(document.getElementById("DropDownList5").value=="Closed" )
    {
         return confirm('確認要將此紀錄【Closed】!!!');
        
    }
    
   
     
     
    else
    {
        return true;
    }
     
}

function check_field1()
{
    if( document.getElementById("TextBox6").value=="")
    {
        alert("請輸入 矯正對策!!!");
        return false;
    }
   
   
   
    
    
   
   else if(document.getElementById("DropDownList4").value=="Closed" && document.getElementById("TextBox1").value==""   )
    {
        alert("請輸入 結案人!!!");
        return false;
    }
    
      else if(document.getElementById("DropDownList4").value=="Closed"  )
    {
        return confirm('確認要將此紀錄【Closed】!!!');

    }
    
   
     
     
    else
    {
        return true;
    }
     
}

function check_field22()
{
    if( document.getElementById("TextBox6").value=="")
    {
        alert("請輸入 矯正對策!!!");
        return false;
    }
   
   
   
    
    
   
   else if(document.getElementById("TextBox3").value==""  )
    {
        alert("請輸入 結案人!!!");
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


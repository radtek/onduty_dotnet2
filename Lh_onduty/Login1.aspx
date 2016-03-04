<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Login1.aspx.cs" Inherits="Lh_onduty_Login1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title>員工關懷系統</title>
</head>
<body bgcolor="#FFFFFF" leftmargin="0" topmargin="0" marginwidth="0" marginheight="0">
    <form id="form1" runat="server">
        <table width="100%" height="600px" align="center">
            <tr>
                <td>
                    <table border="0" cellpadding="0" cellspacing="0" align="CENTER">
                        <tr>
                            <td>
                                <img src="images/CareLogin_03.gif" width="388" height="260" alt=""></td>
                            <td>
                                <img src="images/CareLogin_04.gif" width="294" height="260" alt=""></td>
                            <td>
                                <img src="images/CareLogin_05.gif" width="99" height="260" alt=""></td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/CareLogin_07.gif" width="388" height="66" alt=""></td>
                            <td>
                                <table width="100" border="0" align="right">
                                    <tr>
                                        <td>
                                            <span style="font-weight: bold;">username:&nbsp;</span></td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="user_id" runat="server"></asp:TextBox></td>
                                    </tr>
                                    <tr>
                                        <td>
                                            <span style="font-weight: bold;">password:&nbsp;</span></td>
                                        <td>
                                            &nbsp;<asp:TextBox ID="password" runat="server" TextMode="password" Width="148px"></asp:TextBox></td>
                                    </tr>
                                </table>
                            </td>
                            <td>
                                <asp:ImageButton ID="ImageButton1" runat="server" ImageUrl="images/CareLogin_09.gif"
                                    Width="99" Height="66" OnClick="SigninBtn_Click" /></td>
                        </tr>
                        <tr>
                            <td>
                                <img src="images/CareLogin_10.gif" width="388" height="109" alt=""></td>
                            <td>
                                <img src="images/CareLogin_11.gif" width="294" height="109" alt=""></td>
                            <td>
                                <img src="images/CareLogin_12.gif" width="99" height="109" alt=""></td>
                        </tr>
                        <tr>
                            <td colspan="3" align="right">
                                <asp:Label ID="Message" runat="server" font-name="Verdana" Font-Size="10" ForeColor="red"></asp:Label></td>
                        </tr>
                    </table>
                </td>
            </tr>
        </table>
    </form>
</body>
</html>
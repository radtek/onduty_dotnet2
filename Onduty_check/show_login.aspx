<%@ Page Language="C#" AutoEventWireup="true" CodeFile="show_login.aspx.cs" Inherits="Onduty_check_show_login" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Check View</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <fieldset style="text-align: center" > 
<legend align="center" style="color:blue;text-align:center">Check View&nbsp;</legend> <br /> 
        <table style="width: 710px; height: 86px">
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 350px;">
                    1.OEE</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                    <Iframe src="http://172.16.12.83:8085/" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 350px;">
                    2.SPC</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                    <Iframe src="http://172.16.13.129:10047/iGate/spcreport" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 278px;">
                    3.EDA</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                     <Iframe src="http://172.16.12.139:8085/lcdeda/logonPage.do" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 350px;">
                    4.TFT-meeting</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                    <Iframe src="http://10.56.131.50:10000/tft-meeting/" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 350px;">
                    5.T1_Innoview</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                    <Iframe src="http://172.16.15.12/t1_innoview" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 350px;">
                    6.FEHS</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                    <Iframe src="http://172.16.13.125/fehs/fehs.asp" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            <tr>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double; width: 350px;">
                    7.ITC/CPC</td>
                <td style="border-left-color: gray; border-bottom-color: gray; border-top-style: double;
                    border-top-color: gray; border-right-style: double; border-left-style: double;
                    border-right-color: gray; border-bottom-style: double">
                    <Iframe src="http://172.16.13.56:60000/itcdb_query/result.asp" width="800px" height="600px" scrolling="Yes" frameborder="0"></Iframe>
                </td>
            </tr>
            
        </table>
        <br /> 
        <table border="0" cellpadding="0" cellspacing="0" style="background-color: white"
                width="100%">
                <tr>
                    <td bgcolor="gray" height="28" style="font-size: 11px; color: #ffffff; line-height: 16px;
                        font-family: Verdana,?啁敦??; text-align: center; text-decoration: none">
                        群創光電股份有限公司 版權所有 Copyright &copy; 2010 Innolux Display Corp., Design By CIM 謝正一(64179)</td>
                </tr>
            </table>
      
</fieldset> 

    
    </div>
    </form>
</body>
</html>

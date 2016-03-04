using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions; 

public partial class Lh_onduty_epaper_onduty_lh_epaper : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_ODS_OLE"];
    
    DataSet ds_temp = new DataSet();
    string sql="";
    
    protected void Page_Load(object sender, EventArgs e)
    {
       
        DataSet ds_temp = new DataSet();

        WebClient w = new WebClient();
        w.Encoding = System.Text.Encoding.GetEncoding("Big5");
        string strHTML = w.DownloadString("http://t1cimweb01/Onduty_dotnet/Lh_onduty/epaper/sample/onduty_lh_epaper_detail.aspx");

        #region 收件人
      sql = "select t.useremail from lh_onduty_alarmmail t WHERE T.ENABLE_FLAG = 'Y' and t.receivetype = 'TO'";
        ds_temp = func.get_dataSet_access(sql, conn);
        string mail_to = "";
        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count-1; i++)
        {
            if (i == 0)
            {
                mail_to = ds_temp.Tables[0].Rows[i]["useremail"].ToString();

            }
            else

            {
                mail_to +=","+ ds_temp.Tables[0].Rows[i]["useremail"].ToString();



            
            }
        }
        ds_temp.Clear();

        #endregion

        #region 寄件份本
        sql = "select t.useremail from lh_onduty_alarmmail t WHERE T.ENABLE_FLAG = 'Y' and t.receivetype = 'CC'";
        ds_temp = func.get_dataSet_access(sql, conn);
        string mail_CC = "";
        for (int i = 0; i <= ds_temp.Tables[0].Rows.Count - 1; i++)
        {
            if (i == 0)
            {
                mail_CC = ds_temp.Tables[0].Rows[i]["useremail"].ToString();

            }
            else
            {
                mail_CC += "," + ds_temp.Tables[0].Rows[i]["useremail"].ToString();




            }
        }

        #endregion
        
        




        string title = "[CIM 電子報系統]" + DateTime.Now.ToString("yyyy/MM/dd") + " 龍華出勤違規警示通告";
       // ArrayList maillist = func.FileToArray(Server.MapPath("..\\") + "\\maillist\\money_link_maillist.txt");

        SendEmail("cimalarm@chimei-innolux.com", mail_to, title, strHTML, mail_CC);// 
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式 
        //jrrsc@ms96.url.com.tw 
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com 
        //write_log("MAIL"); 
        //WebClient w1 = new WebClient();
        //w1.Encoding = Encoding.GetEncoding("utf-8");
        //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        ////SAVE_CREATE_FILE(strHTML1); 
        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");
    }

    public static void SendEmail(string from, string to, string subject, string body, string cca)
    {
        SmtpClient smtp = new SmtpClient("10.56.130.57");
        MailMessage email = new MailMessage(from, to, subject, body);
        if (cca == "")
        {
        }
        else
        {
            //email.CC.Add(cca); 
            email.Bcc.Add(cca);
        }

        email.IsBodyHtml = true;
        smtp.Send(email);


    } 

}

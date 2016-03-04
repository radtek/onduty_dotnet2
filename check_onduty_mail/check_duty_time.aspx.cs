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
using System.Net;
using System.Text;
using System.Net.Mail;

public partial class check_onduty_mail_check_duty_time : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];

    string sql = "";
    string sql_temp = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    ArrayList arlist = new ArrayList();
    string after_five_day = DateTime.Now.AddDays(+5).ToString("yyyy/MM/dd");
    string after_four_day = DateTime.Now.AddDays(+4).ToString("yyyy/MM/dd");
    string today_hour = DateTime.Now.AddDays(+0).ToString("HH");
    string today_min = DateTime.Now.AddDays(+0).ToString("mm");
    string update1 = "";
    string update2 = "";

    protected void Page_Load(object sender, EventArgs e)
    {

        update1 = @"
update onduty_email_list t
   set t.cname=trim(t.cname)
      
 where 1=1";
        func.get_sql_execute(update1, conn);


        update2 = @"
 update onduty_schedule
    set 
        name = trim(name)
      
  where 1=1";
        func.get_sql_execute(update2, conn);


        
        
        ds_temp1 = bind_data1();
        ds_temp2 = bind_data2(ds_temp1.Tables[0]);

        if (ds_temp1.Tables[0].Rows.Count == ds_temp2.Tables[0].Rows.Count)
        {

        }
        else
        {
            for (int i = 0; i <= ds_temp1.Tables[0].Rows.Count - 1; i++)
            {

                call_mail(ds_temp1.Tables[0].Rows[i]["name"].ToString(), ds_temp1.Tables[0].Rows[i]["class"].ToString(), ds_temp1.Tables[0].Rows[i]["email"].ToString());
            }
          
        }
        
      
        
        func.write_log("Check_Onduty_Time From Onduty_dotnet2 ", "D:\\CIM-SE-RPT-WEB\\E-FAB_dotnet\\LOG\\", "log");
        func.delete_log_file("D:\\CIM-SE-RPT-WEB\\E-FAB_dotnet\\LOG\\", "*.log", -30);

        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");
  

    }

    private DataSet bind_data1()
    {

        string sql = @" SELECT t.*, t1.email
   FROM onduty_schedule t, onduty_email_list t1
  where t.shift_date = '{0}'
    and trim(t.name)= trim(t1.cname)
    and t.flag = 'Y'";
        sql = string.Format(sql, after_five_day);
        ds_temp = func.get_dataSet_access(sql, conn);

     

        return ds_temp;
    }
    
    private DataSet bind_data2( DataTable dt)
    {

        #region check normal holiday

        string ini = "";
        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            if (i == 0)
            {
                ini = "'" + dt.Rows[0]["NAME"].ToString() + "'";
            }
            else
            {
                ini = ini + ",'" + dt.Rows[i]["NAME"].ToString() + "'";

            }



        }

        string sql = @" SELECT t.*, t1.email
   FROM onduty_schedule t, onduty_email_list t1
  where t.shift_date = '{0}'
    and trim(t.name) = trim(t1.cname)
    and t.flag = 'Y'
    and t.name in ({1})

      ";
        sql = string.Format(sql, after_four_day, ini);
        ds_temp = func.get_dataSet_access(sql, conn);

        #endregion
      

     

        return ds_temp;
    }

    public void call_mail(string name1, string class1,string e_mail1)
    {


        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");
       // string strHTML = w.DownloadString("http://t1cimweb01/onduty_dotnet/record_assign_mail_sample.aspx?seq=" + sn + "");

        string strHTML = @"
<html>
<head>
<title>名稱</title>
<style type='text/css'>
<!--
.style3 {
	color: #FF0000;
	font-weight: bold;
}
.style4 {
	color: #3300FF;
	font-weight: bold;
}
.style5 {
	color: #009900;
	font-weight: bold;
}
-->
</style>
</head>
<body>
<p>相關連結:</p>
<p> <span class='style3'>1.加班申請單:</span><br>
  http://myam.cminl.oa/HRReport/mycategory.aspx</p>
<p> <span class='style4'>2.CIM新值班系統</span><br>
  http://10.56.131.22/onduty_dotnet2/</p>
<p> <span class='style5'>3.CIM值班表</span><br>
  http://10.56.131.22/onduty_dotnet2/onduty_calendar.aspx </p>
<p>&nbsp;</p>
<p class='style7'>&nbsp; </p>
<p class='style7'>&nbsp;</p>
<p class='style7'>&nbsp;</p>
<p class='style7'>&nbsp;</p>
<p class='style7'>&nbsp;</p>
<p class='style7'>Copyright @2012-2013~ Innolux Corp., Design By CIM 謝正一 (513-64179) </p>
</body>
</html>
        ";

        //string sql = " select count(*) as count_num from ( " +
        //" " +
        //" SELECT " +
        //" format(t1.date_time,'YYYY/MM/DD') as " +
        //" date_time,t1.stock_name,t1.stock_id,t1.price,round(t1.percentage*100,2)&'%' " +
        //" as percentage,t1.volumn,round(t1.K_percentage*100,2)&'%' as K_percentage FROM " +
        //" strong_up t1,(select stock_id from volumn t2 where t2.date_time>=format(now()- " +
        //" 7,'YYYY/MM/DD') )t3 where t1.date_time>format(now()-1,'YYYY/MM/DD') and t1.stock_id in (t3.stock_id) " +
        //" " +
        //" ) " +
        //" " +
        //" ";
        //ds_temp = func.get_dataSet_access(sql, conn);


        string title = "【溫馨提醒】 " + after_five_day + " " + name1 + " 您  值【 " + class1 + "  】班  ";
        //ArrayList maillist = func.FileToArray(Server.MapPath(".") + "\\maillist\\onduty.txt");
        //string receive = maillist[0].ToString();

       // string sql_receive = "select t.email from onduty_email_list t where t.cname='" + receive1 + "' ";

        //ds_temp1 = func.get_dataSet_access(sql_receive, conn);

        //string receive = ds_temp1.Tables[0].Rows[0]["email"].ToString();


        //receive = "oscar.hsieh@chimei-innolux.com";


        SendEmail("Onduty_Server@chimei-innolux.com", e_mail1, title, strHTML, "");// 
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式 
        //jrrsc@ms96.url.com.tw 
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com 
        //write_log("MAIL"); 
        //WebClient w1 = new WebClient();
        //w1.Encoding = Encoding.GetEncoding("utf-8");
        //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        //SAVE_CREATE_FILE(strHTML1); 
        //Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");
    }



    public static void SendEmail(string from, string to, string subject, string body, string cca)
    {
        SmtpClient smtp = new SmtpClient("10.56.196.147");
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

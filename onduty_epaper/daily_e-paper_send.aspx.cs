using System;
using System.Data;
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
using System.IO;
using System.Text;
using System.Text.RegularExpressions;


public partial class onduty_epaper_daily_e_paper_send : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql_str = "";
    string sql_check = "";
    string sql_count = "";
    string sqlInsert= "";
    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {


        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");

        string sql = " select seq,                                               " +
"                to_char(calltime,'YYYY/MM/DD HH24:MI') as calltime,    " +
"                to_char(endtime,'YYYY/MM/DD HH24:MI')as endtime ,     " +
"                caller,                                    " +
"                extension,                                 " +
"                engineer,                                  " +
"                fab,                                       " +
"                system,                                    " +
"                offday,                                    " +
"                type,                                      " +
"                cassette,                                  " +
"                lot_id,                                    " +
"                eq_id,                                     " +
"                question,                                  " +
"                bywhom,                                    " +
"                description,                               " +
"                mantis,                                    " +
"                insert_time,                               " +
"                close_flag,                                " +
"                mobile,                                    " +
"                area,                                      " +
"                starttime,                                 " +
"                reason,                                    " +
"                method,                                    " +
"                assign_owner,                              " +
"                additional_info,                           " +
"                ars_flag,                                  " +
"                ars_link,                                  " +
"                due_time,                                  " +
"                alarm_flag,                                " +
"                product_impact,                            " +
"                org_flag,                                  " +
"                product_impact_info,                       " +
"                finaltime,                                 " +
"                recharge_flag,                             " +
"                modify_count                               " +
"           from onduty t1                                  " +
 " where 1=1                                                           ";



        sql += " and  t1.calltime>=to_date('" + DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + " 08:30" + "','YYYY/MM/DD HH24:MI')     ";



        sql += " and  t1.calltime<to_date('" + DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd") + " 08:30" + "','YYYY/MM/DD HH24:MI')     ";






        sql += " order by calltime desc ";

        string sql_count = "";

        sql_count = sql;

        sql_count = " select count(aa.seq)as total_count,sum(case when aa.ars_flag='ON' then 1 else 0 end) as ars_count,  " +
"        sum(case when aa.close_flag='OPEN' then 1 else 0 end) as open_count,                         " +
"        sum(case when aa.alarm_flag='ON' then 1 else 0 end) as alarm_count,                           " +
"        sum(case when aa.assign_owner in ('請選擇')  then 0 else 1 end) as assignto_count                           " +
"  from (      " + sql_count + "  ) aa                                                                                      ";







        DataSet ds_fl = new DataSet();
        ds_fl = func.get_dataSet_access(sql_count, conn);



        string strHTML = w.DownloadString("http://10.56.131.22/Onduty_dotnet2/onduty_epaper/daily_e-paper.aspx");
        string title = "[CIM 電子報系統(C2/T1/T2)] : " + DateTime.Now.ToString("yyyy/MM/dd") + " 值班記錄【 Total: " + ds_fl.Tables[0].Rows[0]["total_count"].ToString() + " 筆 ARS: " + ds_fl.Tables[0].Rows[0]["ars_count"].ToString() + " 筆 Open : " + ds_fl.Tables[0].Rows[0]["open_count"].ToString() + " 筆 Alarm : " + ds_fl.Tables[0].Rows[0]["alarm_count"].ToString() + " 筆 AssignTo: " + ds_fl.Tables[0].Rows[0]["assignto_count"].ToString() + " 筆 】";
        string mail_List = "";
        mail_List = func.ArrayListToString(Server.MapPath("..") + "\\maillist\\onduty12.txt");
        //mail_List = "oscar.hsieh@innolux.com";

        sql_check = @"select count(t.procedurename) counter from dw_etl_runlog t
                       where t.procedurename='Onduty_Daily_email' and t.lastrunsysdate>sysdate-1/2
                     ";
        DataSet dsCheck = new DataSet();
        dsCheck = func.get_dataSet_access(sql_check, conn);

        // Check if had Send Mail 
        if (Convert.ToInt32(dsCheck.Tables[0].Rows[0]["counter"].ToString()) == 0)
        {
            SendEmail("cim.alarm@innolux.com", mail_List, title, strHTML, "");//

            sqlInsert = @"insert into dw_etl_runlog
                          (procedurename, lastruntm, errcode, errmsg, lastrunshiftdate, lastrunsysdate, errlevel, duration)
                          values
                         ('Onduty_Daily_email', '', 'Begin', 'OK', '', sysdate, '', '')";
            func.get_sql_execute(sqlInsert, conn);
        }


       

        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");

        //StringWriter sw = new StringWriter();
        //        HtmlTextWriter htw = new HtmlTextWriter(sw);
        //        Server.Execute("http://172.16.15.10/alarm/QueryForm3.php", htw);
        //        SendEmail("Alarm@innolux.com", "oscar.hsieh@innolux.com,bunny.su@innolux.com", "Alarm Event TOP ", sw.ToString(), "");
        //        //Response.Redirect("mail_detail2.aspx?aid=" + Request.QueryString["aid"].ToString(), false);
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
            email.CC.Add(cca);
        }

        email.IsBodyHtml = true;
        smtp.Send(email);


    }

}

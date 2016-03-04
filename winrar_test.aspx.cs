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

public partial class winrar_test : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string today_hour = DateTime.Now.AddDays(+0).ToString("HH");
    string today_min = DateTime.Now.AddDays(+0).ToString("mm");
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql = "";
    ArrayList arlist_temp1 = new ArrayList();
    string zip_name="";
    string file_folder = "";
    protected void Page_Load(object sender, EventArgs e)
    {
        //file_folder = get_ary_file("T1CFDAILY", file_name);

        file_folder = get_file_folder(Request.QueryString["type"]);
        zip_name = get_zip_name(Request.QueryString["type"]);

        string date_string = DateTime.Now.ToString("yyyyMMdd");

        int loop_count = 0;

        System.Diagnostics.Process.Start(Server.MapPath("winrar.exe"), " a -ep " + Server.MapPath("abc.zip") + " " + Server.MapPath(".\\top.aspx") );
        //System.Diagnostics.Process.Start(Server.MapPath("winrar.exe"), " a -ep " + Server.MapPath(zip_name) + " " + Server.MapPath("winrar.exe") + file_name);
        
        System.Threading.Thread.Sleep(3000);
        //fi_zip.Refresh();
        //while (!fi_zip.Exists)
        //{
        //    System.Threading.Thread.Sleep(2000);
        //    loop_count = loop_count + 1;
        //    if (loop_count > 10)
        //    {
        //        Response.Write("Compress File Fail");
        //        Response.Write("<script language='javascript'>setTimeout('window.opener=null; window.close();' , 3000)</script> ");
        //        Response.End();
        //    }
        //    fi_zip.Refresh();
        //}


    }


   //private void get_ary_file(string type, string file_name)
   // {
   //     string folder_name = "";

   //     switch (type)
   //     {
   //         case "T0ARYDAILY":
   //             folder_name = "array_daily/AUTO";
   //             break;
   //         case "T0ARYNOON":
   //             folder_name = "array_noon/AUTO";
   //             break;
   //         case "T1ARYDAILY":
   //             folder_name = "array_daily/AUTO";
   //             break;
   //         case "T1ARYNOON":
   //             folder_name = "array_noon/AUTO";
   //             break;
   //     }


   //     FTPFactory ff = new FTPFactory();
   //     ff.setDebug(true);
   //     ff.setRemoteHost("172.16.15.11");
   //     ff.setRemoteUser("subsystem");
   //     ff.setRemotePass("System@");
   //     ff.login();

   //     try
   //     {
   //         ff.chdir(folder_name);
   //         ff.download(file_name, Server.MapPath(file_name));
   //     }
   //     catch
   //     {

   //     }

   //     ff.close();

   // }

    private static string get_file_folder(string type)
    {
        string file_folder = "";
        switch (type)
        {
            case "T0ARYDAILY":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/array/daily_meeting_report/array_daily/AUTO/";
                break;
            case "T0ARYNOON":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/array/daily_meeting_report/array_noon/AUTO/";
                break;
            case "T1ARYDAILY":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/array/daily_meeting_report/array_daily/AUTO/";
                break;
            case "T1ARYNOON":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/array/daily_meeting_report/array_noon/AUTO/";
                break;
            case "T0CELDAILY":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/cell/daily_meeting_report_526/cell_daily_T0/AUTO/";
                break;
            case "T0CELNOON":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/cell/daily_meeting_report_526/cell_subs_T0/AUTO/";
                break;
            case "T1CELDAILY":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/cell/daily_meeting_report_526/cell_daily_T1/AUTO/";
                break;
            case "T1CELNOON":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/cell/daily_meeting_report_526/cell_subs_T1/AUTO/";
                break;
            case "T1CFDAILY":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/cf/daily_meeting_report/CF_daily/AUTO/";
                break;
            case "T1CFNOON":
                file_folder = "D:/CIM-SE-RPT-WEB/e-fab/rpt-item/cf/daily_meeting_report/CF_PP/AUTO/";
                break;
        }

        return file_folder;
    }

    private string get_zip_name(string type)
    {
        string zip_name = "";
        string date_string = DateTime.Now.ToString("yyyyMMdd");
        switch (type)
        {
            case "T0ARYDAILY":
                zip_name = "E_FAB_T0ARRAY_DAILY_METTING_RPT_" + date_string + ".zip";
                break;
            case "T0ARYNOON":
                zip_name = "E_FAB_T0ARRAY_NOON_METTING_RPT_" + date_string + ".zip";
                break;
            case "T1ARYDAILY":
                zip_name = "E_FAB_T1ARRAY_DAILY_METTING_RPT_" + date_string + ".zip";
                break;
            case "T1ARYNOON":
                zip_name = "E_FAB_T1ARRAY_NOON_METTING_RPT_" + date_string + ".zip";
                break;
            case "T0CELDAILY":
                zip_name = "E_FAB_T0CELL_DAILY_METTING_RPT_" + date_string + ".zip";
                break;
            case "T0CELNOON":
                zip_name = "E_FAB_T0CELL_NOON_METTING_RPT_" + date_string + ".zip";
                break;
            case "T1CELDAILY":
                zip_name = "E_FAB_T1CELL_DAILY_METTING_RPT_" + date_string + ".zip";
                break;
            case "T1CELNOON":
                zip_name = "E_FAB_T1CELL_NOON_METTING_RPT_" + date_string + ".zip";
                break;
            case "T1CFDAILY":
                zip_name = "E_FAB_T1CF_DAILY_METTING_RPT_" + date_string + ".zip";
                break;
            case "T1CFNOON":
                zip_name = "E_FAB_T1CF_NOON_METTING_RPT_" + date_string + ".zip";
                break;
        }
        return zip_name;
    }




}

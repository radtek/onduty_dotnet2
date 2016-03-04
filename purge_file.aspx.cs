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

public partial class purge_file : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string today_hour = DateTime.Now.AddDays(+0).ToString("HH");
    string today_min = DateTime.Now.AddDays(+0).ToString("mm");
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql = "";
    ArrayList arlist_temp1 = new ArrayList();
   
    protected void Page_Load(object sender, EventArgs e)
    {
        func.delete_log_dir(@"D:\CIM-SE-RPT-WEB\Array_photo\alarm\OEE_EQP_Status_SMS\File", "*.xml", -3);

        func.delete_log_dir(@"D:\CIM-SE-RPT-WEB\Array_photo\alarm\OEE_EQP_Status_SMS\log", "*.log", -3);
        func.delete_log_dir(@"D:\CIM-SE-RPT-WEB\Array_photo\alarm\OEE_EQP_Status_SMS\log_array_test", "*.log", -3);

        func.write_log("Auto Purge OEE_EQP_Status_SMS", Server.MapPath(".\\") + "log\\", "log");




        func.delete_log_file(@"D:\CIM-SE-RPT-WEB\Onduty_dotnet2\log", "*.log", -90);



        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");

    }
}

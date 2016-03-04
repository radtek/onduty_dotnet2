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

public partial class _onduty_member_info : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql = "";
    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();
    protected void Page_Load(object sender, EventArgs e)
    {

        sql = @"

        select t.* from onduty_email_list t
where (t.dep like '8N1C1%' or t.dep like '8N1C2%'or t.dep like '8N1C0%')
   and t.flag='Y'
 order by  t.dep 
        ";
        ds_temp=func.get_dataSet_access(sql,conn);

        GridView1.DataSource = ds_temp.Tables[0];
        GridView1.DataBind();


    }
}

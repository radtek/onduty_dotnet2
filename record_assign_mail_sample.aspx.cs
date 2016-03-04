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

public partial class record_assign_mail_sample : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    DataSet ds_temp = new DataSet();
    string sql_str = "";
    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["seq"] = Request["seq"].Trim().ToUpper();
            //Session["seq"]="30929";

            bind_data();
        }

    }

    protected DataSet bind_data()
    {

        string sql = " select t.* from onduty t where t.seq='" + Session["seq"] + "'                            ";



        sql = "select rownum,t.* from (" + sql + ")t where rownum<=1 ";

        ds_temp = func.get_dataSet_access(sql, conn);

        GridView1.DataSource = ds_temp;
        GridView1.DataBind();



        return ds_temp;




    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {







            //strTaskID = ((DataRowView)e.Row.DataItem)["task_id"].ToString(); 
            // dv.RowFilter = "task_id=" + strTaskID; 
            //dv.Sort = "is_owner desc"; 

            //task member datalist 
            //((DataList)e.Row.FindControl("dlTaskMember")).DataSource = dv; 
            //((DataList)e.Row.FindControl("dlTaskMember")).DataBind(); 

            //image link to task content 

            //string sMessage = String.Format("return(OpenTask('{0}'));", strTaskID); 
            //((ImageButton)e.Row.FindControl("btnEdit")).OnClientClick = sMessage;//"if (OpenTask('" + sMessage + "')==false) {return false;}"; 

        }
    } 
}

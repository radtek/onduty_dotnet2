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

public partial class daily_onduty_lh1 : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_LHMIS1"];
    string conn1 = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_MEETUSER"];


    //string start_time = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");
    //string end_time = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");

    string sql_temp = "";
    DataSet ds_temp = new DataSet();

    DataSet ds_temp1 = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {

            txtEstimateStartDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(-2).ToString("yyyy/MM/dd"));

            txtEstimateEndDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd"));


        }

        bind_data1();

        Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>"); 

    }

    private DataTable bind_data1()
    {

        string sql = "";
        //string sql_combine = "";
        //string sql_combine1 = "";

        for (int i = 0; i <= date_diff() - 1; i++)
        {

            if (i == 0)
            {


                sql = " SELECT '1'+ot1.date+ot1.empno as sn,'1' as type,'做六休一'as type_name, SUBSTRING(ot1.date,1,4)as year,SUBSTRING(ot1.date,5,2)as month,'0'as week,ot1.date, ot2.BUname, ot2.DIVname, ot2.name, ot1.empno, ot1.name AS                                                    " +
"                                empname, ot1.days_workcontinue ,'OPEN'as status,''as category ,'' as description FROM (SELECT                                                    " +
"                                DISTINCT CONVERT(varchar(12), t1e, 112) AS date,                                               " +
"                                empno, name, t1s, t1e, days_workcontinue,                                                      " +
"                                deptcode FROM dbo.View_WorkHourByCard WHERE                                                    " +
"                                (days_workcontinue > 6)                                                                        " +
"                                                                                                                               " +
"                               )                                                                                               " +
"                               AS ot1 INNER JOIN                                                                               " +
"                               (SELECT         TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode,  name                       " +
"                                FROM              dbo.View_corporganization                                                " +
"                                WHERE          (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')))                  " +
                    //"                                AS ot2 ON ot1.deptcode = ot2.deptcode AND ot1.date = '20100704' AND ot1.deptcode = '8CCLA002'  "+
"                                AS ot2 ON ot1.deptcode = ot2.deptcode AND ot1.date = '" + txtEstimateStartDate.SelectedDate.Value.AddDays(+i).ToString("yyyy/MM/dd").Replace("/", "") + "'   " +
"                                                                               ";
                //sql_combine = "select * from ( " + sql + ")";

            }
            else
            {
                sql = sql + " UNION  all ";
                sql = sql + " SELECT '1'+ot1.date+ot1.empno as sn,'1' as type,'做六休一'as type_name, SUBSTRING(ot1.date,1,4)as year,SUBSTRING(ot1.date,5,2)as month,'0'as week,ot1.date, ot2.BUname, ot2.DIVname, ot2.name, ot1.empno, ot1.name AS                                                    " +
"                                empname, ot1.days_workcontinue ,'OPEN'as status,''as category ,'' as description FROM (SELECT                                                    " +
"                                DISTINCT CONVERT(varchar(12), t1e, 112) AS date,                                               " +
"                                empno, name, t1s, t1e, days_workcontinue,                                                      " +
"                                deptcode FROM dbo.View_WorkHourByCard WHERE                                                    " +
"                                (days_workcontinue > 6)                                                                        " +
"                                                                                                                               " +
"                               )                                                                                               " +
"                               AS ot1 INNER JOIN                                                                               " +
"                               (SELECT         TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode,  name                       " +
"                                FROM              dbo.View_corporganization                                                " +
"                                WHERE          (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')))                  " +
                    //"                                AS ot2 ON ot1.deptcode = ot2.deptcode AND ot1.date = '20100704' AND ot1.deptcode = '8CCLA002'  "+
"                                AS ot2 ON ot1.deptcode = ot2.deptcode AND ot1.date = '" + txtEstimateStartDate.SelectedDate.Value.AddDays(+i).ToString("yyyy/MM/dd").Replace("/", "") + "'   " +
"                                                                                ";

            }




        }

        ds_temp = func.get_dataSet_access(sql, conn);

        GridView1.DataSource = ds_temp.Tables[0];
        GridView1.DataBind();
        delete_data1();
        insert_data1(ds_temp.Tables[0]);

        return ds_temp.Tables[0];
    }

    private void insert_data1(DataTable dt)
    {

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {

            sql_temp = " insert into lh_onduty_record                                                                                                                                             " +
"   (sn, type, type_name, year,month, week, date_time, buname, divname, dep_name, empno, empname, days_workcontinue, status, category, description,dttm)                              " +
" values                                                                                                                                                                   " +
"   ('" + dt.Rows[i]["sn"] + "', '" + dt.Rows[i]["type"] + "', '" + dt.Rows[i]["type_name"] + "', '" + dt.Rows[i]["year"] + "', '" + dt.Rows[i]["month"] + "','" + dt.Rows[i]["week"] + "', '" + dt.Rows[i]["date"] + "', '" + dt.Rows[i]["buname"] + "', '" + dt.Rows[i]["divname"] + "', '" + dt.Rows[i]["name"] + "', '" + dt.Rows[i]["empno"] + "', '" + dt.Rows[i]["empname"] + "',  '" + dt.Rows[i]["days_workcontinue"] + "', '" + dt.Rows[i]["status"] + "', '" + dt.Rows[i]["category"] + "', '" + dt.Rows[i]["description"] + "',sysdate)";

            func.get_sql_execute(sql_temp, conn1);

        }

        Label1.Text = " Insert Data Success!!!";


    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        bind_data1();

    }

    private void delete_data1()
    {
        string start_time = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");
        string end_time = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");



        sql_temp = " delete lh_onduty_record tt " +
  "where tt.date_time>='" + start_time + "' and tt.date_time<='" + end_time + "' ";

        func.get_dataSet_access(sql_temp, conn1);
        Label1.Text = " Delete File OK (During Selected Time Area)!!!";

    }


    private Int32 date_diff()
    {
        int count = 0;

        //System.DateTime time1 = Convert.ToDateTime(baseDate);
        System.DateTime time1 = Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"));
        System.DateTime time2 = Convert.ToDateTime(txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd"));


        TimeSpan ts = time2.Subtract(time1);
        Int32 diffm = Convert.ToInt32(ts.TotalDays);
        //Int32 diffm2 = diffm % 4;

        return diffm;



    }
}

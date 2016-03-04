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

public partial class Lh_onduty_monthly_onduty_lh1 : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_LHMIS1"];
    string conn1 = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_MEETUSER"];


    //string start_time = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");
    //string end_time = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");

    string sql_temp = "";
    string sql_temp1 = "";
    DataSet ds_temp = new DataSet();

    DataSet ds_temp1 = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {

        if (!IsPostBack)
        {
            txtEstimateEndDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd"));
            txtEstimateStartDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd"));


        }

        bind_data3();
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
    private DataTable bind_data2()
    {
        string years_start = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Substring(0, 4);

        string weeks_start = func.GetWeekOfCurrDate(Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"))).Substring(4, 2);


        Int32 weeks_start_num = Convert.ToInt32(func.GetWeekOfCurrDate(Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"))));

        string sql = "";



        sql = " SELECT '2' + CONVERT(char(4), ot1.YESRS) + CONVERT(char(2), ot1.WEEKS) +                         " +
"        ot1.empno AS sn,                                                                          " +
"        ot1.YESRS as year,                                                                                " +
"        '0' as month,                                                                                " +
"        ot1.WEEKS as week,                                                                                " +
"        '0'as date,                                                                                " +


"        ot1.empno,                                                                                " +
"        ot1.name as empname,                                                                                 " +
"        ot1.deptcode,                                                                             " +
"        ot1.OverTimesByWeek as days_workcontinue,                                                                      " +
"        ot2.BUname,                                                                               " +
"        ot2.DIVname,                                                                              " +
"        ot2.name AS depname,                                                                         " +
"        '2' AS type ,                                                                        " +
"        '週工時超過63小時' AS type_name  ,                                                                        " +
"        'OPEN'as status ,                                                                       " +
"      ''as category,                                                                   " +
"      '' as description                                                                " +
"   FROM (SELECT DATEPART(year, t1e) AS YESRS,                                                     " +
"                DATEPART(WEEK, t1e) AS WEEKS,                                                     " +
"                empno,                                                                            " +
"                name,                                                                             " +
"                deptcode,                                                                         " +
"                SUM(work_hours) AS OverTimesByWeek                                                " +
"           FROM (SELECT DISTINCT empno, name, deptcode, t1s, t1e, work_hours                      " +
"                   FROM dbo.View_WorkHourByCard                                                   " +
"                  WHERE (work_hours > 0)) AS derivedtbl_2                                         " +
"          GROUP BY DATEPART(year, t1e),                                                           " +
"                   DATEPART(WEEK, t1e),                                                           " +
"                   empno,                                                                         " +
"                   name,                                                                          " +
"                   deptcode) AS ot1                                                               " +
"  INNER JOIN (SELECT TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode, name                     " +
"                FROM dbo.View_corporganization                                                    " +
"               WHERE (DIVcode IN                                                                  " +
"                     ('8N110000', '8N230000', '8CCL0000', '8N410000'))) AS ot2 ON ot1.deptcode =  " +
"                                                                                  ot2.deptcode    " +
"  WHERE (ot1.OverTimesByWeek > 63)                                                                " +
"    AND (ot1.YESRS = '" + years_start + "')                                                                      " +
"    AND (ot1.WEEKS = '" + weeks_start + "')                                                                        ";

        //for (int i = 0; i <= week_diff() - 1; i++)
        //{

        //    if (i == 0)
        //    {

        //        sql = " SELECT '2'+YESRS+WEEK+empno as sn,'2' as type,'週工時超過63小時'as type_name,YESRS as year,'0' as month, WEEKS as week,'0'as date,'0'as BUname,'0'as DIVname  , empno, name, deptcode, OverTimesByWeek " +
        //" FROM ( SELECT DATEPART(year, t1e) AS YESRS, DATEPART(WEEK, t1e) AS WEEKS,  " +
        //"               empno, name, deptcode, SUM(work_hours) AS OverTimesByWeek  " +
        //"        FROM ( SELECT DISTINCT empno, name, deptcode, t1s, t1e, work_hours " +
        //"               FROM dbo.View_WorkHourByCard " +
        //"               WHERE (work_hours > 0) " +
        //"              ) AS derivedtbl_2  " +
        //"        GROUP BY DATEPART(year, t1e), DATEPART(WEEK, t1e), empno, name, deptcode  " +
        //"      ) AS derivedtbl_1  " +
        //" WHERE (OverTimesByWeek > 63) AND (YESRS = '" + years_start + "') AND (WEEKS = '" + weeks_start + "') ";

        //    }
        //    else
        //    {
        //        weeks_start_num++;
        //        sql = sql + " UNION  all ";
        //        sql = sql + " SELECT '2'+YESRS+WEEK+empno as sn,'2' as type,'週工時超過63小時'as type_name,YESRS as year,'0' as month, WEEKS as week,'0'as date, empno, name, deptcode, OverTimesByWeek " +
        //" FROM ( SELECT DATEPART(year, t1e) AS YESRS, DATEPART(WEEK, t1e) AS WEEKS,  " +
        //"               empno, name, deptcode, SUM(work_hours) AS OverTimesByWeek  " +
        //"        FROM ( SELECT DISTINCT empno, name, deptcode, t1s, t1e, work_hours " +
        //"               FROM dbo.View_WorkHourByCard " +
        //"               WHERE (work_hours > 0) " +
        //"              ) AS derivedtbl_2  " +
        //"        GROUP BY DATEPART(year, t1e), DATEPART(WEEK, t1e), empno, name, deptcode  " +
        //"      ) AS derivedtbl_1  " +
        //" WHERE (OverTimesByWeek > 63) AND (YESRS = '" + years_start + "') AND (WEEKS = '" + weeks_start_num + "') ";



        //    }



        //}






        ds_temp = func.get_dataSet_access(sql, conn);

        GridView1.DataSource = ds_temp.Tables[0];
        GridView1.DataBind();
        //delete_data2();
        insert_data2(ds_temp.Tables[0]);

        return ds_temp.Tables[0];
    }
    private DataTable bind_data3()
    {
        string years_end = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Substring(0, 4);
        string month_end = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Substring(5, 2);


        string sql = "";





        sql = " SELECT '3' + CONVERT(char(4), ot1.YESRS) + CONVERT(char(2), ot1.MONTHS) +                                     " +
"        ot1.empno AS sn,                                                                                       " +
"        ot1.YESRS as year,                                                                                             " +
"        ot1.MONTHS AS month,                                                                                   " +
"        '0' AS week,                                                                                           " +
"        '0' AS date,                                                                                           " +
"        ot1.empno,                                                                                             " +
"        ot1.name AS empname,                                                                                   " +
"        ot1.deptcode,                                                                                          " +
"        ot1.OverTimesByWeek AS days_workcontinue,                                                              " +
"        ot3.BUname,                                                                                            " +
"        ot3.DIVname,                                                                                           " +
"        ot3.name AS depname,                                                                                   " +
"        '3' AS type,                                                                                           " +
"        '月加班工時超過91小時' AS type_name,                                                                   " +
"        'OPEN' AS status,                                                                                      " +
"        '' AS category,                                                                                        " +
"        '' AS description                                                                                      " +
"   FROM (SELECT DATEPART(year, t1e) AS YESRS,                                                                  " +
"                DATEPART(MONTH, t1e) AS MONTHS,                                                                " +
"                empno,                                                                                         " +
"                name,                                                                                          " +
"                deptcode,                                                                                      " +
"                SUM(OT_fromcard) AS OverTimesByWeek                                                            " +
"           FROM (SELECT DISTINCT empno, name, deptcode, t1s, t1e, OT_fromcard                                  " +
"                   FROM dbo.View_WorkHourByCard                                                                " +
"                  WHERE (OT_fromcard > 0)) AS derivedtbl_2                                                     " +
"          GROUP BY DATEPART(year, t1e),                                                                        " +
"                   DATEPART(month, t1e),                                                                       " +
"                   empno,                                                                                      " +
"                   name,                                                                                       " +
"                   deptcode) AS ot1                                                                            " +
"  INNER JOIN (SELECT TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode, name                                  " +
"                FROM dbo.View_corporganization                                                                 " +
"               WHERE (DIVcode IN                                                                               " +
"                     ('8N110000', '8N230000', '8CCL0000', '8N410000'))) AS ot3 ON ot1.deptcode =               " +
"                                                                                  ot3.deptcode                 " +
"  WHERE (ot1.OverTimesByWeek > 91)                                                                             " +
"    AND (ot1.YESRS = '" + years_end + "')                                                                                   " +
"    AND (ot1.MONTHS = '" + month_end + "')                                                                                    ";






        ds_temp = func.get_dataSet_access(sql, conn);

        GridView1.DataSource = ds_temp.Tables[0];
        GridView1.DataBind();
        //delete_data3();
        insert_data3(ds_temp.Tables[0]);

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
        Label1.Visible = true;


    }
    private void insert_data2(DataTable dt)
    {


        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            sql_temp1 = "select count(*) as countX from lh_onduty_record t  where t.sn='" + dt.Rows[i]["sn"] + "'";

            ds_temp1 = func.get_dataSet_access(sql_temp1, conn1);

            if (Convert.ToInt32(ds_temp1.Tables[0].Rows[0]["countX"].ToString()) > 0)
            {
                sql_temp = " update lh_onduty_record                           " +
"    set                                            " +
"        type = '" + dt.Rows[i]["type"] + "',                             " +
"        type_name ='" + dt.Rows[i]["type_name"] + "',                  " +
"        year = '" + dt.Rows[i]["year"] + "',                             " +
"        month = '" + dt.Rows[i]["month"] + "',                           " +
"        week = '" + dt.Rows[i]["week"] + "',                             " +
"        date_time = '" + dt.Rows[i]["date"] + "',                   " +
"        buname = '" + dt.Rows[i]["buname"] + "',                         " +
"        divname = '" + dt.Rows[i]["divname"] + "',                       " +
"        dep_name = '" + dt.Rows[i]["depname"] + "',                     " +
"        empno = '" + dt.Rows[i]["empno"] + "',                           " +
"        empname = '" + dt.Rows[i]["empname"] + "',                       " +
"        days_workcontinue = '" + dt.Rows[i]["days_workcontinue"] + "',   " +
"        dttm = sysdate                           " +


"  where sn='" + dt.Rows[i]["sn"] + "'                                      ";



            }
            else
            {
                sql_temp = " insert into lh_onduty_record                                                                                                                                             " +
"   (sn, type, type_name, year,month, week, date_time, buname, divname, dep_name, empno, empname, days_workcontinue, status, category, description,dttm)                              " +
" values                                                                                                                                                                   " +
"   ('" + dt.Rows[i]["sn"] + "', '" + dt.Rows[i]["type"] + "', '" + dt.Rows[i]["type_name"] + "', '" + dt.Rows[i]["year"] + "', '" + dt.Rows[i]["month"] + "','" + dt.Rows[i]["week"] + "', '" + dt.Rows[i]["date"] + "', '" + dt.Rows[i]["buname"] + "', '" + dt.Rows[i]["divname"] + "', '" + dt.Rows[i]["depname"] + "', '" + dt.Rows[i]["empno"] + "', '" + dt.Rows[i]["empname"] + "',  '" + dt.Rows[i]["days_workcontinue"] + "', '" + dt.Rows[i]["status"] + "', '" + dt.Rows[i]["category"] + "', '" + dt.Rows[i]["description"] + "',sysdate)";


            }

            func.get_sql_execute(sql_temp, conn1);

        }

        Label1.Text = " Insert Data  Weekly Success!!!";
        Label1.Visible = true;


    }
    private void insert_data3(DataTable dt)
    {

        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {
            sql_temp1 = "select count(*) as countX from lh_onduty_record t  where t.sn='" + dt.Rows[i]["sn"] + "'";

            ds_temp1 = func.get_dataSet_access(sql_temp1, conn1);

            if (Convert.ToInt32(ds_temp1.Tables[0].Rows[0]["countX"].ToString()) > 0)
            {
                sql_temp = " update lh_onduty_record                           " +
"    set                                            " +
"        type = '" + dt.Rows[i]["type"] + "',                             " +
"        type_name ='" + dt.Rows[i]["type_name"] + "',                  " +
"        year = '" + dt.Rows[i]["year"] + "',                             " +
"        month = '" + dt.Rows[i]["month"] + "',                           " +
"        week = '" + dt.Rows[i]["week"] + "',                             " +
"        date_time = '" + dt.Rows[i]["date"] + "',                   " +
"        buname = '" + dt.Rows[i]["buname"] + "',                         " +
"        divname = '" + dt.Rows[i]["divname"] + "',                       " +
"        dep_name = '" + dt.Rows[i]["depname"] + "',                     " +
"        empno = '" + dt.Rows[i]["empno"] + "',                           " +
"        empname = '" + dt.Rows[i]["empname"] + "',                       " +
"        days_workcontinue = '" + dt.Rows[i]["days_workcontinue"] + "',   " +
"        dttm = sysdate                           " +


"  where sn='" + dt.Rows[i]["sn"] + "'                                      ";



            }
            else
            {
                sql_temp = " insert into lh_onduty_record                                                                                                                                             " +
"   (sn, type, type_name, year,month, week, date_time, buname, divname, dep_name, empno, empname, days_workcontinue, status, category, description,dttm)                              " +
" values                                                                                                                                                                   " +
"   ('" + dt.Rows[i]["sn"] + "', '" + dt.Rows[i]["type"] + "', '" + dt.Rows[i]["type_name"] + "', '" + dt.Rows[i]["year"] + "', '" + dt.Rows[i]["month"] + "','" + dt.Rows[i]["week"] + "', '" + dt.Rows[i]["date"] + "', '" + dt.Rows[i]["buname"] + "', '" + dt.Rows[i]["divname"] + "', '" + dt.Rows[i]["depname"] + "', '" + dt.Rows[i]["empno"] + "', '" + dt.Rows[i]["empname"] + "',  '" + dt.Rows[i]["days_workcontinue"] + "', '" + dt.Rows[i]["status"] + "', '" + dt.Rows[i]["category"] + "', '" + dt.Rows[i]["description"] + "',sysdate)";


            }

            func.get_sql_execute(sql_temp, conn1);

        }

        Label1.Text = " Insert Data Monthly Success!!!";
        Label1.Visible = true;


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
        Label1.Text = " Delete File OK For Daily (During Selected Time Area)!!!";

    }
    private void delete_data2()
    {
        string years_start = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Substring(0, 4);

        string weeks_start = func.GetWeekOfCurrDate(Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"))).Substring(4, 2);

        Int32 weeks_start_num = Convert.ToInt32(func.GetWeekOfCurrDate(Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"))));


        for (int i = 0; i <= 0; i++)
        {
            sql_temp = " delete lh_onduty_record tt " +
  "where tt.year='" + years_start + "' and tt.week='" + weeks_start + "' ";

            weeks_start_num++;

            func.get_dataSet_access(sql_temp, conn1);

        }





        Label1.Text = " Delete File OK For Weekly (During Selected Time Area)!!!";

    }
    //  private void delete_data3()
    //  {
    //      string start_time = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");
    //      string end_time = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");



    //      sql_temp = " delete lh_onduty_record tt " +
    //"where tt.date_time>='" + start_time + "' and tt.date_time<='" + end_time + "' ";

    //      func.get_dataSet_access(sql_temp, conn1);
    //      Label1.Text = " Delete File OK (During Selected Time Area)!!!";

    //  }


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


    private Int32 week_diff()
    {
        Int32 count_week_diff = 0;

        //System.DateTime time1 = Convert.ToDateTime(baseDate);
        System.DateTime time1 = Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"));
        System.DateTime time2 = Convert.ToDateTime(txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd"));

        Int32 Begin_week = Convert.ToInt32(func.GetWeekOfCurrDate(time1));

        Int32 End_week = Convert.ToInt32(func.GetWeekOfCurrDate(time2));


        count_week_diff = End_week - Begin_week;

        return count_week_diff;



    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        bind_data2();
    }
    protected void Button3_Click(object sender, EventArgs e)
    {
        bind_data3();
    }
}

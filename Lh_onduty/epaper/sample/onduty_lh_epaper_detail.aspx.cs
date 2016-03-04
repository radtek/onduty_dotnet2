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

public partial class Lh_onduty_epaper_onduty_lh_epaper : System.Web.UI.Page
{
    string conn1 = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_ODS_OLE"];
    string conn2 = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_LHMIS1"];
    string sql = "";

    DataSet ds_temp1 = new DataSet();

    DataSet ds_temp2 = new DataSet();


    protected void Page_Load(object sender, EventArgs e)
    {
        bind_data1();
        bind_data2();
        bind_data3();

    }

    protected DataSet bind_data1()
    {
        sql = " SELECT         ot1.date, ot2.BUname, ot2.DIVname, ot2.name, ot2.deptcode, SUM(1) AS counts " +
          " FROM             (SELECT DISTINCT CONVERT(varchar(12), t1e, 112) AS date, empno, name, t1s, t1e, " +
          "                                                       days_workcontinue, deptcode " +
          "                            FROM              dbo.View_WorkHourByCard " +
          "                            WHERE          (days_workcontinue > 6) AND (CONVERT(varchar(12), t1e, 112)  " +
          "                                                       = CONVERT(varchar(12), DATEADD(day, - 2, GETDATE()), 112)))  " +
          "                           AS ot1 INNER JOIN " +
          "                               (SELECT         TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode, name " +
          "                                 FROM              dbo.View_corporganization " +
          "                                 WHERE          (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')))  " +
          "                           AS ot2 ON ot1.deptcode = ot2.deptcode " +
          " GROUP BY  ot1.date, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name , ot2.deptcode " +
          " ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";

        //sql = "select rownum,t.* from (" + sql + ")t  ";

        ds_temp1 = func.get_dataSet_access(sql, conn2);

        GridView1.DataSource = ds_temp1;
        GridView1.DataBind();



        return ds_temp1;




    }

    protected DataSet bind_data2()
    {
        sql = " SELECT ot1.YESRS, ot1.WEEKS, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name,ot2.deptcode, SUM(1) AS OT_counts " +
                           " FROM (SELECT YESRS, WEEKS, empno, name, deptcode, OverTimesByWeek " +
                           "       FROM (SELECT DATEPART(year, t1e) AS YESRS, DATEPART(WEEK,t1e) AS WEEKS, empno, name, deptcode,  " +
                           "                    SUM(work_hours) AS OverTimesByWeek " +
                           "             FROM (SELECT DISTINCT  empno, name, deptcode, t1s, t1e,  work_hours " +
                           "                   FROM dbo.View_WorkHourByCard " +
                           "                   WHERE (work_hours > 0)  " +
                           "             ) AS derivedtbl_2 " +
                           "       GROUP BY DATEPART(year, t1e), DATEPART(WEEK, t1e), empno,  name, deptcode ) AS derivedtbl_1 " +
                           " WHERE (OverTimesByWeek > 63) AND (WEEKS = DATEPART(WEEK,  DATEADD(day, - 7, GETDATE())))) AS ot1 INNER JOIN " +
                           " (SELECT TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode,  name " +
                           "  FROM dbo.View_corporganization " +
                           "  WHERE (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000'))  " +
                           " ) AS ot2 ON ot1.deptcode = ot2.deptcode " +
                           "GROUP BY ot1.YESRS, ot1.WEEKS, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name ,ot2.deptcode " +
                           "ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";

        //sql = "select rownum,t.* from (" + sql + ")t  ";

        ds_temp1 = func.get_dataSet_access(sql, conn2);

        GridView2.DataSource = ds_temp1;
        GridView2.DataBind();



        return ds_temp1;




    }

    protected DataSet bind_data3()
    {
        sql = " SELECT ot1.YESRS, ot1.MONTHS, ot1.SumDate, ot2.BUname, ot2.DIVcode, " +
                          "        ot2.DIVname, ot2.name,ot2.deptcode, SUM(1) AS OT_counts " +
                          " FROM ( SELECT YESRS, MONTHS, empno, name, deptcode, OverTimesByMonth, " +
                          "               CONVERT(varchar(12), DATEADD(day, - 2, GETDATE()), 112) AS SumDate " +
                          "        FROM ( SELECT DATEPART(year, t1e) AS YESRS, DATEPART(MONTH, t1e) AS MONTHS, " +
                          "                      empno, name, deptcode, SUM(OT_fromcard) AS OverTimesByMonth " +
                          "               FROM ( SELECT DISTINCT empno, name, deptcode, t1s, t1e, OT_fromcard " +
                          "                      FROM dbo.View_WorkHourByCard " +
                          "                      WHERE  (OT_fromcard > 0) " +
                          "                     ) AS derivedtbl_2 " +
                          "               GROUP BY DATEPART(year, t1e), DATEPART(MONTH, t1e), empno, name, deptcode " +
                          "             ) AS derivedtbl_1 " +
                          "        WHERE (OverTimesByMonth > 91 ) AND (MONTHS = DATEPART(MONTH, DATEADD(day, - 2, GETDATE()))) " +
                          "      ) AS ot1 INNER JOIN " +
                          "      ( SELECT TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode, name " +
                          "        FROM dbo.View_corporganization " +
                          "        WHERE (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')) " +
                          "      ) AS ot2 ON ot1.deptcode = ot2.deptcode " +
                          " GROUP BY ot1.YESRS, ot1.MONTHS, ot1.SumDate, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name,ot2.deptcode" +
                          " ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";


        //sql = "select rownum,t.* from (" + sql + ")t  ";

        ds_temp1 = func.get_dataSet_access(sql, conn2);

        GridView3.DataSource = ds_temp1;
        GridView3.DataBind();



        return ds_temp1;




    }

    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }


            //string strSql_file_name;
            //string snn1;

            //GridViewRow row = GridView2.Rows[e.RowIndex]; 



            //DataSet ds = new DataSet();




            //           strSql_file_name = " select distinct (t3.file_name)            " +
            //"  from (                                   " +
            //"        select *                           " +
            //"          from lh_onduty_file t     " +
            //"         where t.sn = '" + ((DataRowView)e.Row.DataItem)["sn"] + "'     " +
            //"         order by t.dttm desc) t3          ";



            //           ds = func.get_dataSet_access(strSql_file_name, conn);


            //           ((DataList)e.Row.FindControl("DataList1")).DataSource = ds.Tables[0];
            //           ((DataList)e.Row.FindControl("DataList1")).DataBind();

            //String Flag_satus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS"));

            //if (Flag_satus == "OPEN")
            //    //e.Row.Cells[0].BackColor = Color.Yellow; 
            //    e.Row.Cells[3].Style.Add("background-color", "#FFFF80");
            //if (Flag_satus == "CLOSE")
            //    e.Row.Cells[3].Style.Add("background-color", "#95CAFF");
            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[3].Style.Add("background-color", "#FF9DFF");








        }
    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }


            //string strSql_file_name;
            //string snn1;

            //GridViewRow row = GridView2.Rows[e.RowIndex]; 



            //DataSet ds = new DataSet();




            //           strSql_file_name = " select distinct (t3.file_name)            " +
            //"  from (                                   " +
            //"        select *                           " +
            //"          from lh_onduty_file t     " +
            //"         where t.sn = '" + ((DataRowView)e.Row.DataItem)["sn"] + "'     " +
            //"         order by t.dttm desc) t3          ";



            //           ds = func.get_dataSet_access(strSql_file_name, conn);


            //           ((DataList)e.Row.FindControl("DataList1")).DataSource = ds.Tables[0];
            //           ((DataList)e.Row.FindControl("DataList1")).DataBind();

            //String Flag_satus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS"));

            //if (Flag_satus == "OPEN")
            //    //e.Row.Cells[0].BackColor = Color.Yellow; 
            //    e.Row.Cells[3].Style.Add("background-color", "#FFFF80");
            //if (Flag_satus == "CLOSE")
            //    e.Row.Cells[3].Style.Add("background-color", "#95CAFF");
            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[3].Style.Add("background-color", "#FF9DFF");








        }
    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            if (e.Row.RowIndex != -1)
            {
                int id = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = id.ToString();
            }


            //string strSql_file_name;
            //string snn1;

            //GridViewRow row = GridView2.Rows[e.RowIndex]; 



            //DataSet ds = new DataSet();




            //           strSql_file_name = " select distinct (t3.file_name)            " +
            //"  from (                                   " +
            //"        select *                           " +
            //"          from lh_onduty_file t     " +
            //"         where t.sn = '" + ((DataRowView)e.Row.DataItem)["sn"] + "'     " +
            //"         order by t.dttm desc) t3          ";



            //           ds = func.get_dataSet_access(strSql_file_name, conn);


            //           ((DataList)e.Row.FindControl("DataList1")).DataSource = ds.Tables[0];
            //           ((DataList)e.Row.FindControl("DataList1")).DataBind();

            //String Flag_satus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS"));

            //if (Flag_satus == "OPEN")
            //    //e.Row.Cells[0].BackColor = Color.Yellow; 
            //    e.Row.Cells[3].Style.Add("background-color", "#FFFF80");
            //if (Flag_satus == "CLOSE")
            //    e.Row.Cells[3].Style.Add("background-color", "#95CAFF");
            //if (Flag_satus == "Cancel")
            //    e.Row.Cells[3].Style.Add("background-color", "#FF9DFF");








        }
    }
}

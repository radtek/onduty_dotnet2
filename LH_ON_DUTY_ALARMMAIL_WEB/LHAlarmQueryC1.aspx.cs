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
using System.Data.SqlClient;

public partial class LHAlarmQueryC1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack == true)
        {

        }
        else
        {
            query_table.Text = "page loading...";
            do_Query();
        }

    }

    protected void do_Query()
    {
        string dates = Request.QueryString["dates"];
        string deptcode = Request.QueryString["deptcode"];

        //dates="20100710";
        //deptcode = "8CCL6004";
        string Mail_Body = "", sql_stm = "", empno = "",workdays="",date_time="";
        string connect_string = "Data Source=INLLHHRMDB01;Initial Catalog=HRBI;User Id=BUuser;Password=BUuser123";
        DataTable dt = new DataTable();



        // 龍華出勤違規警示通告:做六休一違規事件人員資料
        sql_stm = " SELECT ot1.date, ot2.BUname, ot2.DIVname, ot2.name, ot1.empno, " +
                          "        ot1.name AS empname, ot1.days_workcontinue " +
                          " FROM (SELECT DISTINCT  " +
                          "              CONVERT(varchar(12), t1e, 112) AS date, empno, name, t1s, t1e, days_workcontinue, deptcode " +
                          "       FROM              dbo.View_WorkHourByCard " +
                          "       WHERE          (days_workcontinue > 6) " +
                        //  "           AND (CONVERT(varchar(12), t1e, 112) = CONVERT(varchar(12), DATEADD(day, - 2, GETDATE()), 112)) " +
                          "       )  " +
                          "       AS ot1 INNER JOIN " +
                          "       (SELECT         TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode,  name " +
                          "        FROM              dbo.View_corporganization " +
                          "        WHERE          (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')))  " +
                          "        AS ot2 ON ot1.deptcode = ot2.deptcode AND ot1.date = '"+dates+"' AND ot1.deptcode = '"+deptcode+"' " +
                          " ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";
        dt = GetDataTable2(sql_stm, connect_string);

        Mail_Body += "    &nbsp;龍華出勤違規警示通告:做六休一違規事件人員資料&nbsp;";
        Mail_Body += "    <table align=left border=1 cellpadding=0 cellspacing=0 width=850px bordercolor=#C2DE81>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            if (i == 0)
            {
                Mail_Body += "<tr style='background-color:#FF8000;'>";
                Mail_Body += "<td>&nbsp;日期&nbsp;</td>";
                Mail_Body += "<td>&nbsp;BU名稱&nbsp;</td>";
                Mail_Body += "<td>&nbsp;處別名稱&nbsp;</td>";
                Mail_Body += "<td>&nbsp;部門名稱&nbsp;</td>";
                Mail_Body += "<td>&nbsp;員工工號&nbsp;</td>";
                Mail_Body += "<td>&nbsp;員工姓名&nbsp;</td>";
                Mail_Body += "<td>&nbsp;連續工作天數&nbsp;</td>";
                Mail_Body += "<td>&nbsp;&nbsp;</td>";
                Mail_Body += "<td>&nbsp;&nbsp;</td>";
                Mail_Body += "</tr>";
            }
            Mail_Body += "<tr style='background-color:#FFFF80;'>";
            for (int j = 0; j < dt.Columns.Count; j++)
            {

                if (j == 0) // 員工工號
                {
                    date_time = dt.Rows[i][j].ToString();

                }

                if (j == 4) // 員工工號
                {
                    empno = dt.Rows[i][j].ToString();

                }

                if (j == 6) // 連續工作天數
                {
                    Mail_Body += "<td style='text-align:center;' >&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                    workdays = dt.Rows[i][j].ToString();

                }
                else
                {
                    Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                }

            }

            Mail_Body += "<td><a href='LHAlarmQueryC1_1.aspx?empno="+empno+"&workdays="+workdays+"' target='_blank' >&nbsp;查詢&nbsp;</a></td>";
            Mail_Body += "<td><a href='" + "http://" + Server.MachineName + "/onduty_dotnet/Lh_onduty/" + "login.aspx?SN=" + "1" + date_time + empno + "' target='_blank' >&nbsp;結案&nbsp;</a></td>";


            Mail_Body += "</tr>";
        }
        Mail_Body += "      </table>";
        query_table.Text = Mail_Body;



    }

    public static DataTable GetDataTable2(string strSql, string connect_string)
    {
        DataTable dt = new DataTable();
        SqlConnection myConnection = new SqlConnection();
        SqlCommand myCommand = new SqlCommand();
        SqlDataAdapter mydataad = new SqlDataAdapter();
        try
        {

            myConnection.ConnectionString = connect_string;
            myCommand.CommandType = CommandType.Text;
            myCommand.Connection = myConnection;
            myCommand.CommandText = strSql;
            myCommand.CommandTimeout = 0;
            // conn.CommandTimeout = 600  '秒
            mydataad.SelectCommand = myCommand;
            mydataad.Fill(dt);
            myConnection.Close();
        }
        catch (Exception e)
        {
            //e.ToString();
            //query_table.Text = e.ToString();
            myConnection.Close();
        }

        return dt;
    }

}

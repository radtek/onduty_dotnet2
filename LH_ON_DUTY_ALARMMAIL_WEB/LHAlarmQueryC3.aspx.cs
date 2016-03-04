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

public partial class LHAlarmQueryC3 : System.Web.UI.Page
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
        string years = Request.QueryString["years"];
        string months = Request.QueryString["months"];
        string deptcode = Request.QueryString["deptcode"];
        string Mail_Body = "", sql_stm = "", empno = "", YESRS="",month="";
        string connect_string = "Data Source=INLLHHRMDB01;Initial Catalog=HRBI;User Id=BUuser;Password=BUuser123";
        DataTable dt = new DataTable();

        // 龍華出勤違規警示通告:月累計加班工時超過 91 小時
        sql_stm = " SELECT YESRS, MONTHS, empno, name, deptcode, OverTimesByWeek " +
          " FROM ( SELECT DATEPART(year, t1e) AS YESRS, DATEPART(MONTH, t1e) AS MONTHS,  " +
          "               empno, name, deptcode, SUM(OT_fromcard) AS OverTimesByWeek  " +
          "        FROM ( SELECT DISTINCT empno, name, deptcode, t1s, t1e, OT_fromcard " +
          "               FROM dbo.View_WorkHourByCard " +
          "               WHERE (OT_fromcard > 0) " +
          "              ) AS derivedtbl_2  " +
          "        GROUP BY DATEPART(year, t1e), DATEPART(month, t1e), empno, name, deptcode  " +
          "      ) AS derivedtbl_1  " +
          " WHERE (OverTimesByWeek > 91) AND (YESRS = '" + years + "') AND (MONTHS = '" + months + "') AND (deptcode = '" + deptcode + "') ";
        dt = GetDataTable2(sql_stm, connect_string);

        Mail_Body += "    &nbsp;龍華出勤違規警示通告:月累計加班工時超過 91 小時人員資料&nbsp;";
        Mail_Body += "    <table align=left border=1 cellpadding=0 cellspacing=0 width=850px bordercolor=#C2DE81>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            if (i == 0)
            {
                Mail_Body += "<tr style='background-color:#FF8000;'>";
                Mail_Body += "<td>&nbsp;年別&nbsp;</td>";
                Mail_Body += "<td>&nbsp;月別&nbsp;</td>";
                Mail_Body += "<td>&nbsp;員工工號&nbsp;</td>";
                Mail_Body += "<td>&nbsp;員工姓名&nbsp;</td>";
                Mail_Body += "<td>&nbsp;部門代號&nbsp;</td>";
                Mail_Body += "<td>&nbsp;月加班工時&nbsp;</td>";
                Mail_Body += "<td>&nbsp;&nbsp;</td>";
                Mail_Body += "<td>&nbsp;&nbsp;</td>";
                Mail_Body += "</tr>";
            }
            Mail_Body += "<tr style='background-color:#FFFF80;'>";
            for (int j = 0; j < dt.Columns.Count; j++)
            {

                if (j == 2) // 員工工號
                    empno = dt.Rows[i][j].ToString();
                if (j == 0) // 年
                    YESRS = dt.Rows[i][j].ToString();

                if (j == 1) // 月
                    month = dt.Rows[i][j].ToString();

                if (j == 5) // 月加班工時
                {
                    Mail_Body += "<td style='text-align:center;' >&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                }
                else
                {
                    Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                }

            }

            Mail_Body += "<td><a href='LHAlarmQueryC3_1.aspx?years=" + years + "&months=" + months + "&empno=" + empno + "' target='_blank' >&nbsp;查詢&nbsp;</a></td>";
            Mail_Body += "<td><a href='" + "http://" + Server.MachineName + "/onduty_dotnet/Lh_onduty/" + "login.aspx?SN=" + "3" + YESRS + month + empno + "' target='_blank' >&nbsp;結案&nbsp;</a></td>";

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

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

public partial class LHAlarmQueryC3_1 : System.Web.UI.Page
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
        string empno = Request.QueryString["empno"];
        string Mail_Body = "", sql_stm = "";
        string connect_string = "Data Source=INLLHHRMDB01;Initial Catalog=HRBI;User Id=BUuser;Password=BUuser123";
        DataTable dt = new DataTable();

        // 人員月加班工時超過91小時資料查詢
        sql_stm = " SELECT DISTINCT empno, name, deptcode, workbegin, workend, t1s, t1e, OT_fromcard " +
          " FROM dbo.View_WorkHourByCard " +
          " WHERE (OT_fromcard > 0) AND (empno = '" + empno + " ')  " +
          "   AND (DATEPART(year, t1e) = '" + years + "') AND (DATEPART(month, t1e) = '" + months + "') " +
          " ORDER BY  t1e DESC ";


        dt = GetDataTable2(sql_stm, connect_string);

        Mail_Body += "    &nbsp;龍華出勤違規警示通告:人員月加班工時資料&nbsp;";
        Mail_Body += "    <table align=left border=1 cellpadding=0 cellspacing=0 width=1050px bordercolor=#C2DE81>";

        for (int i = 0; i < dt.Rows.Count; i++)
        {

            if (i == 0)
            {
                Mail_Body += "<tr style='background-color:#FF8000;'>";
                Mail_Body += "<td>&nbsp;員工工號&nbsp;</td>";
                Mail_Body += "<td>&nbsp;員工姓名&nbsp;</td>";
                Mail_Body += "<td>&nbsp;部門代號&nbsp;</td>";
                Mail_Body += "<td>&nbsp;標準工作開始時間&nbsp;</td>";
                Mail_Body += "<td>&nbsp;標準工作結束時間&nbsp;</td>";
                Mail_Body += "<td>&nbsp;實際工作開始時間&nbsp;</td>";
                Mail_Body += "<td>&nbsp;實際工作結束時間&nbsp;</td>";
                Mail_Body += "<td>&nbsp;加班工時(小時)&nbsp;</td>";
                Mail_Body += "</tr>";
            }
            Mail_Body += "<tr style='background-color:#FFFF80;'>";
            for (int j = 0; j < dt.Columns.Count; j++)
            {

                if (j == 7) // 加班工時
                {
                    Mail_Body += "<td style='text-align:center;' >&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                }
                else
                {
                    Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                }

            }
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

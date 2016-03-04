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

public partial class onduty_lh_query : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_MEETUSER"];
    DataSet ds_temp = new DataSet();
    ArrayList arlist_temp1 = new ArrayList();
    string sql_temp = "";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            txtEstimateStartDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(-7).ToString("yyyy/MM/dd"));
            txtEstimateEndDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd"));

            sql_temp = "select distinct(t.type_name) as type_name from lh_onduty_record t";

            ds_temp = func.get_dataSet_access(sql_temp, conn);

            DropDownList1.DataTextField = "type_name";
            DropDownList1.DataValueField = "type_name";
            DropDownList1.DataSource = ds_temp.Tables[0];
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "請選擇");
            ds_temp.Clear();

            sql_temp = "select distinct(t.buname) as buname from lh_onduty_record t";

            ds_temp = func.get_dataSet_access(sql_temp, conn);

            DropDownList3.DataTextField = "buname";
            DropDownList3.DataValueField = "buname";
            DropDownList3.DataSource = ds_temp.Tables[0];
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "請選擇");
            ds_temp.Clear();





            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\lh_category.txt");

            DropDownList6.DataSource = arlist_temp1;
            DropDownList6.DataBind();


            DropDownList12.DataSource = "";
            DropDownList12.DataBind();
            DropDownList12.Items.Insert(0, "請選擇");

            DropDownList4.DataSource = "";
            DropDownList4.Items.Insert(0, "請選擇");

            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\flag_type_query.txt");
            DropDownList2.DataSource = arlist_temp1;
            DropDownList2.DataBind();
           
            DropDownList2.Items.Insert(0, "請選擇");

            bind_data();






        }


    }
    protected DataSet bind_data()
    {
        string sql = " select t1.* from lh_onduty_record t1                             " +
 " where 1=1                                                           ";

        #region 做六休一
        if (DropDownList1.SelectedValue.Equals("做六休一") || DropDownList1.SelectedValue.Equals("請選擇"))
        {

            if (!txtEstimateStartDate.SelectedDate.Value.Equals(""))
            {
                sql += " and  t1.date_time>='" + txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "") + "'   ";

            }

            if (!txtEstimateEndDate.SelectedDate.Value.Equals(""))
            {
                sql += " and  t1.date_time<'" + txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "") + "'    ";

            }

            if (!DropDownList1.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.type_name='" + DropDownList1.SelectedValue + "'                                          ";

            }

            if (!DropDownList2.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.status='" + DropDownList2.SelectedValue + "'                                          ";

            }

            if (!TextBox_empo.Text.Equals(""))
            {
                sql += " and t1.empno='" + TextBox_empo.Text + "'                                                ";

            }


            if (!DropDownList3.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.buname='" + DropDownList3.SelectedValue + "'                                                        ";

            }

            if (!DropDownList12.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.divname='" + DropDownList12.SelectedValue + "'                                                        ";

            }


            if (!DropDownList4.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.dep_name='" + DropDownList4.SelectedValue + "'                                                        ";

            }
            if (!DropDownList6.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.category='" + DropDownList6.SelectedValue + "'                                                        ";

            }


            sql += " order by date_time desc ";

            sql = "select rownum,t.* from (" + sql + ")t  ";

        }
        #endregion

        #region 週工時超過63小時

        if (DropDownList1.SelectedValue.Equals("週工時超過63小時"))
        {
            System.DateTime time1 = Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"));
            System.DateTime time2 = Convert.ToDateTime(txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd"));


            string combine_year_week_start = func.GetWeekOfCurrDate(time1);

            string combine_year_week_end = func.GetWeekOfCurrDate(time2);


            if (!txtEstimateStartDate.SelectedDate.Value.Equals(""))
            {
                sql += " and  t1.year||t1.week>='" + combine_year_week_start + "'   ";

            }

            if (!txtEstimateEndDate.SelectedDate.Value.Equals(""))
            {
                sql += " and  t1.year||t1.week<'" + combine_year_week_end + "'    ";

            }

            if (!DropDownList1.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.type_name='" + DropDownList1.SelectedValue + "'                                          ";

            }
            if (!DropDownList2.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.status='" + DropDownList2.SelectedValue + "'                                          ";

            }

            if (!TextBox_empo.Text.Equals(""))
            {
                sql += " and t1.empno='" + TextBox_empo.Text + "'                                                ";

            }


            if (!DropDownList3.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.buname='" + DropDownList3.SelectedValue + "'                                                        ";

            }

            if (!DropDownList12.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.divname='" + DropDownList12.SelectedValue + "'                                                        ";

            }


            if (!DropDownList4.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.dep_name='" + DropDownList4.SelectedValue + "'                                                        ";

            }
            if (!DropDownList6.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.category='" + DropDownList6.SelectedValue + "'                                                        ";

            }


            sql += " order by t1.year||t1.week desc ";

            sql = "select rownum,t.* from (" + sql + ")t  ";

        }
        #endregion

        #region 月加班工時超過91小時
        if (DropDownList1.SelectedValue.Equals("月加班工時超過91小時"))
        {
           string  temp_start_date = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd");
           string temp_end_date = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd");


           string combine_year_month_start = temp_start_date.Substring(0, 4) + temp_start_date.Substring(5, 2);

           string combine_year_month_end = temp_end_date.Substring(0, 4) + temp_end_date.Substring(5, 2);

            if (!txtEstimateStartDate.SelectedDate.Value.Equals(""))
            {
                sql += " and  t1.year||t1.month>='" + combine_year_month_start + "'   ";

            }

            if (!txtEstimateEndDate.SelectedDate.Value.Equals(""))
            {
                sql += " and  t1.year||t1.month<'" + combine_year_month_end + "'    ";

            }

            if (!DropDownList1.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.type_name='" + DropDownList1.SelectedValue + "'                                          ";

            }

            if (!DropDownList2.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.status='" + DropDownList2.SelectedValue + "'                                          ";

            }

            if (!TextBox_empo.Text.Equals(""))
            {
                sql += " and t1.empno='" + TextBox_empo.Text + "'                                                ";

            }


            if (!DropDownList3.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.buname='" + DropDownList3.SelectedValue + "'                                                        ";

            }

            if (!DropDownList12.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.divname='" + DropDownList12.SelectedValue + "'                                                        ";

            }


            if (!DropDownList4.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.dep_name='" + DropDownList4.SelectedValue + "'                                                        ";

            }
            if (!DropDownList6.SelectedValue.Equals("請選擇"))
            {
                sql += " and t1.category='" + DropDownList6.SelectedValue + "'                                                        ";

            }


            sql += " order by t1.year||t1.month desc ";

            sql = "select rownum,t.* from (" + sql + ")t  ";

        }
        #endregion




        ds_temp = func.get_dataSet_access(sql, conn);

        GridView1.DataSource = ds_temp;
        GridView1.DataBind();



        return ds_temp;




    }
    protected void ButtonQuery_Click(object sender, EventArgs e)
    {
        bind_data();
    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        GridView gv = new GridView();
        gv.DataSource = bind_data();
        gv.DataBind();
        ExportExcel(gv);
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // base.VerifyRenderingInServerForm(control); 
    }

    private void ExportExcel(GridView SeriesValuesDataGrid)
    {
        Response.Clear();
        Response.Buffer = true;

        Response.AddHeader("content-disposition", "attachment;filename=Onduty_lh.xls");

        Response.Charset = "big5";

        // If you want the option to open the Excel file without saving than 

        // comment out the line below 

        // Response.Cache.SetCacheability(HttpCacheability.NoCache); 

        Response.ContentType = "application/vnd.xls";

        System.IO.StringWriter stringWrite = new System.IO.StringWriter();

        System.Web.UI.HtmlTextWriter htmlWrite = new HtmlTextWriter(stringWrite);

        SeriesValuesDataGrid.AllowPaging = false;
        SeriesValuesDataGrid.DataBind();

        SeriesValuesDataGrid.RenderControl(htmlWrite);

        string head = " <html> " +
        " <head><meta http-equiv='Content-Type' content='text/html; charset=big5'></head> " +
        " <body> ";

        string footer = " </body>" +
        " </html>";

        Response.Write(head + stringWrite.ToString() + footer);

        Response.End();

        SeriesValuesDataGrid.AllowPaging = true;
        SeriesValuesDataGrid.DataBind();





    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

        string strTaskID = string.Empty;

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            string strSql_file_name;
            string snn1;

            //GridViewRow row = GridView2.Rows[e.RowIndex]; 



            DataSet ds = new DataSet();




            strSql_file_name = " select distinct (t3.file_name)            " +
 "  from (                                   " +
 "        select *                           " +
 "          from lh_onduty_file t     " +
 "         where t.sn = '" + ((DataRowView)e.Row.DataItem)["sn"] + "'     " +
 "         order by t.dttm desc) t3          ";



            ds = func.get_dataSet_access(strSql_file_name, conn);


            ((DataList)e.Row.FindControl("DataList1")).DataSource = ds.Tables[0];
            ((DataList)e.Row.FindControl("DataList1")).DataBind();

            String Flag_satus = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "STATUS"));

            if (Flag_satus == "OPEN")
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[3].Style.Add("background-color", "#FFFF80");
            if (Flag_satus == "CLOSED")
                e.Row.Cells[3].Style.Add("background-color", "#C0C0C0");
            if (Flag_satus == "Cancel")
                e.Row.Cells[3].Style.Add("background-color", "#FF9DFF");




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
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql_temp = "select distinct(t.divname) as divname from lh_onduty_record t where t.buname='" + DropDownList3.SelectedValue + "' ";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        DropDownList12.DataTextField = "divname";
        DropDownList12.DataValueField = "divname";
        DropDownList12.DataSource = ds_temp.Tables[0];
        DropDownList12.DataBind();
        DropDownList12.Items.Insert(0, "請選擇");
        ds_temp.Clear();

    }
    protected void DropDownList12_SelectedIndexChanged(object sender, EventArgs e)
    {
        sql_temp = "select distinct(t.dep_name) as dep_name from lh_onduty_record t where t.divname='" + DropDownList12.SelectedValue + "' ";

        ds_temp = func.get_dataSet_access(sql_temp, conn);

        DropDownList4.DataTextField = "dep_name";
        DropDownList4.DataValueField = "dep_name";
        DropDownList4.DataSource = ds_temp.Tables[0];
        DropDownList4.DataBind();
        DropDownList4.Items.Insert(0, "請選擇");
        ds_temp.Clear();
    }


}

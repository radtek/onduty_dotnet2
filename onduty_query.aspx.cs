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
using System.Drawing;

public partial class onduty_query : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");
    
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql_str = "";

    string sql_count = "";
    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();


    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql_str = " select distinct(t.offday) as offday from onduty t " +
" where t.offday not in ('OFF','ON')      ";
            ds_temp = func.get_dataSet_access(sql_str, conn);



            RadioButtonList1.DataSource = ds_temp.Tables[0];

            RadioButtonList1.DataTextField = "offday";
            RadioButtonList1.DataValueField = "offday";
            RadioButtonList1.DataBind();
            // RadioButtonList1.Items.Insert(0, "請選擇");

            txtEstimateStartDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd"));


            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\hour.txt");

            DropDownList5.DataSource = arlist_temp1;
            DropDownList5.DataBind();
            DropDownList5.Text = DateTime.Now.ToString("HH");
            DropDownList5.Text = "08";



            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\min.txt");

            DropDownList8.DataSource = arlist_temp1;
            DropDownList8.DataBind();
            DropDownList8.Text = DateTime.Now.ToString("mm");
            DropDownList8.Text = "00";



            txtEstimateEndDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd"));


            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\hour.txt");

            DropDownList15.DataSource = arlist_temp1;
            DropDownList15.DataBind();
            DropDownList15.Text = DateTime.Now.ToString("HH");




            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\min.txt");

            DropDownList18.DataSource = arlist_temp1;
            DropDownList18.DataBind();
            DropDownList18.Text = DateTime.Now.ToString("mm");
            DropDownList18.Text = "59";

            #region MyRegion 值班工程師
            sql_str = " select distinct (t.engineer) as engineer                                                                      " +
"   from onduty t                                                                                   " +
"  where t.engineer not in                                                                          " +
"        ('何宗彥', '吳泳潔', '廖建賀', '張松騰', '徐展文', '林校平', '林豐裕',                     " +
"         '羅盛平', '胡慶祥', '邵朝文', '賴岳汶', '陳品辰', '陳盈仁', '魏武慶',                     " +
"         '黃建友', '黃紹煒','蔡丞','楊炎煌','蕭寶棋','蔡育倫','陳鏞企','吳宗哲','吳宜蓁','呂政達') ";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList4.DataSource = ds_temp.Tables[0];
            DropDownList4.DataTextField = "engineer";
            DropDownList4.DataValueField = "engineer";

            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, "請選擇");

            #endregion

            #region fab
            sql_str = " select distinct (t.fab) as fab                                                                      " +
"   from onduty t                                                                                   ";

            // ds_temp.Clear();
            string [] fab_array={"T0T1*","T2*","T0Array","T1Array","T0Cell","T1Cell","T1CF","T2Array","T2Cell","T2CF","T0T1_OTHERS","T2_OTHERS"};
            ds_temp = func.get_dataSet_access(sql_str, conn);
            
            DropDownList1.DataSource = ds_temp.Tables[0];
            DropDownList1.DataSource = fab_array;
            //DropDownList1.DataTextField = "fab";
            //DropDownList1.DataValueField = "fab";

            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "請選擇");


            #endregion


            #region fab
            sql_str = " select distinct (t.system) as system                                                                      " +
"   from onduty t                                                                                   ";

            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList2.DataSource = ds_temp.Tables[0];
            DropDownList2.DataTextField = "system";
            DropDownList2.DataValueField = "system";

            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "請選擇");


            #endregion



            #region close_flag
            sql_str = "select distinct(t.close_flag) as close_flag  from onduty t" +
" where t.close_flag is not null";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList3.DataSource = ds_temp.Tables[0];
            DropDownList3.DataTextField = "close_flag";
            DropDownList3.DataValueField = "close_flag";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "請選擇");


            #endregion



            #region ars_flag
            sql_str = "select distinct(t.ars_flag) as ars_flag  from onduty t" +
" where t.ars_flag is not null";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList12.DataSource = ds_temp.Tables[0];
            DropDownList12.DataTextField = "ars_flag";
            DropDownList12.DataValueField = "ars_flag";
            DropDownList12.DataBind();
            DropDownList12.Items.Insert(0, "請選擇");



            #endregion


            #region alarm_flag
            sql_str = "select distinct(t.alarm_flag) as alarm_flag  from onduty t" +
" where t.alarm_flag is not null";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList10.DataSource = ds_temp.Tables[0];
            DropDownList10.DataTextField = "alarm_flag";
            DropDownList10.DataValueField = "alarm_flag";
            DropDownList10.DataBind();
            DropDownList10.Items.Insert(0, "請選擇");



            #endregion





            #region type
            sql_str = " select distinct(t.type) as type  from onduty t                                                       " +
" where t.type not in ('資料異常','MO+過帳失敗','交辦事項','支援部門','設備(搬運系統)','過帳失敗')     ";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList6.DataSource = ds_temp.Tables[0];
            DropDownList6.DataTextField = "type";
            DropDownList6.DataValueField = "type";
            DropDownList6.DataBind();
            DropDownList6.Items.Insert(0, "請選擇");



            #endregion


            #region product_impact
            sql_str = " select distinct(t.product_impact) as product_impact  from onduty t " +
" where t.product_impact is not null                                 ";
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList7.DataSource = ds_temp.Tables[0];
            DropDownList7.DataTextField = "product_impact";
            DropDownList7.DataValueField = "product_impact";
            DropDownList7.DataBind();
            DropDownList7.Items.Insert(0, "請選擇");

            #endregion



            #region 處理者
            sql_str = " select distinct(t.bywhom) as bywhom  from onduty t " +
" where t.bywhom is not null                                 ";
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList9.DataSource = ds_temp.Tables[0];
            DropDownList9.DataTextField = "bywhom";
            DropDownList9.DataValueField = "bywhom";
            DropDownList9.DataBind();
            DropDownList9.Items.Insert(0, "請選擇");


            #endregion



            #region Assign To
            sql_str = " select distinct(t.assign_owner) as assign_owner  from onduty t                                       " +
" where t.assign_owner  not in ('何宗彥', '吳泳潔', '廖建賀', '張松騰', '徐展文', '林校平', '林豐裕',  " +
"         '羅盛平', '胡慶祥', '邵朝文', '賴岳汶', '陳品辰', '陳盈仁', '魏武慶',                        " +
"         '黃建友', '黃紹煒','蔡丞','楊炎煌','蕭寶棋','蔡育倫','陳鏞企','吳宗哲','吳宜蓁','呂政達')    ";
            ds_temp = func.get_dataSet_access(sql_str, conn);
            DropDownList11.DataSource = ds_temp.Tables[0];
            DropDownList11.DataTextField = "assign_owner";
            DropDownList11.DataValueField = "assign_owner";
            DropDownList11.DataBind();
            DropDownList11.Items.Insert(0, "請選擇");
            DropDownList11.Items.Insert(1, "*");


            #endregion

            Label1.Text = "0";
            Label2.Text = "0";
            Label3.Text = "0";
            Label4.Text = "0";
            Label5.Text = "0";

            Label1.ForeColor = Color.Red;
            Label2.ForeColor = Color.Red;
            Label3.ForeColor = Color.Red;
            Label4.ForeColor = Color.Red;
            Label5.ForeColor = Color.Red;

            bind_data();


        }
    }

    protected DataSet bind_data()
    {
        string sql = " select seq,                                               " +
"                to_char(calltime,'YYYY/MM/DD HH24:MI') as calltime,    " +
"                to_char(endtime,'YYYY/MM/DD HH24:MI')as endtime ,     " +
"                caller,                                    " +
"                extension,                                 " +
"                engineer,                                  " +
"                fab,                                       " +
"                system,                                    " +
"                offday,                                    " +
"                type,                                      " +
"                cassette,                                  " +
"                lot_id,                                    " +
"                eq_id,                                     " +
"                question,                                  " +
"                bywhom,                                    " +
"                description,                               " +
"                mantis,                                    " +
"                insert_time,                               " +
"                close_flag,                                " +
"                mobile,                                    " +
"                area,                                      " +
"                starttime,                                 " +
"                reason,                                    " +
"                method,                                    " +
"                 case when assign_owner='請選擇' then '' else assign_owner end as assign_owner ,                              " +
"                additional_info,                           " +
"                ars_flag,                                  " +
"                ars_link,                                  " +
"                due_time,                                  " +
"                alarm_flag,                                " +
"                product_impact,                            " +
"                org_flag,                                  " +
"                product_impact_info,                       " +
"                finaltime,                                 " +
"                recharge_flag,                             " +
"                modify_count                               " +
"           from onduty t1                                  " +
 " where 1=1                                                           ";

        if (!TextBox1.Text.Equals(""))
        {
            sql += " and  t1.seq='" + TextBox1.Text + "' ";

        }
        if (!txtEstimateStartDate.SelectedDate.Value.Equals("") && TextBox1.Text.Equals(""))
        {
            sql += " and  t1.calltime>=to_date('" + txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList5.SelectedValue + ":" + DropDownList8.SelectedValue + "','YYYY/MM/DD HH24:MI')     ";

        }

        if (!txtEstimateEndDate.SelectedDate.Value.Equals("") && TextBox1.Text.Equals(""))
        {
            sql += " and  t1.calltime<to_date('" + txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList15.SelectedValue + ":" + DropDownList18.SelectedValue + "','YYYY/MM/DD HH24:MI')     ";

        }

        if (!RadioButtonList1.SelectedValue.Equals("") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.offday='" + RadioButtonList1.SelectedValue + "'                                          ";

        }

        if (!TextBox2.Text.Equals("") && TextBox1.Text.Equals(""))
        {
            sql += " and upper(t1.question) like '%" + TextBox2.Text.ToUpper().ToString() + "%'                                                ";

        }


        if (!TextBox3.Text.Equals("") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.caller like '%" + TextBox3.Text + "%'                                                        ";

        }

        if (!DropDownList4.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.engineer='" + DropDownList4.SelectedValue + "'                                                        ";

        }

        if (!DropDownList1.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {

            if (DropDownList1.SelectedValue.Equals("T0T1*"))
            {
                sql += " and (t1.fab like 'T0%'   or  t1.fab like 'T1%'  or  t1.fab like 'T0T1_OTHERS%' or t1.fab like 'OTHERS%' or t1.fab like 'ARRAY%' or t1.fab like 'CELL%' or t1.fab like 'CF%'  )                                                  ";

            }
            else
            {

                if (DropDownList1.SelectedValue.Equals("T2*"))
                {
                    sql += " and t1.fab like 'T2%'                                                    ";

                }

                else
                {
                    sql += " and t1.fab='" + DropDownList1.SelectedValue + "'                                                        ";


                }
           
            
            }

            
        }

        if (!DropDownList2.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.system='" + DropDownList2.SelectedValue + "'                                                        ";

        }


        if (!DropDownList3.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.close_flag='" + DropDownList3.SelectedValue + "'                                                        ";

        }


        if (!DropDownList12.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.ars_flag='" + DropDownList12.SelectedValue + "'                                                        ";

        }


        if (!DropDownList10.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.alarm_flag='" + DropDownList10.SelectedValue + "'                                                        ";

        }

        if (!DropDownList6.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.type='" + DropDownList6.SelectedValue + "'                                                        ";

        }

        if (!DropDownList7.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.product_impact='" + DropDownList7.SelectedValue + "'                                                        ";

        }


        if (!DropDownList9.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
        {
            sql += " and t1.bywhom='" + DropDownList9.SelectedValue + "'                                                        ";

        }


        if (DropDownList11.SelectedValue.Equals("*"))
        {
            sql += " and t1.assign_owner not in ('請選擇')                                                        ";



        }
        else
        {
            if (!DropDownList11.SelectedValue.Equals("請選擇") && TextBox1.Text.Equals(""))
            {
                sql += " and t1.assign_owner='" + DropDownList11.SelectedValue + "'                                                        ";

            }

        
        
        }

        









        sql += " ORDER BY ARS_FLAG DESC,CLOSE_FLAG DESC,ALARM_FLAG DESC,CALLTIME DESC";

        sql_count = sql;
        sql = "select rownum,t.* from (" + sql + "   )t  ";




        ds_temp = func.get_dataSet_access(sql, conn);




        GridView1.DataSource = ds_temp;
        GridView1.DataBind();


        sql_count = " select count(aa.seq)as total_count,sum(case when aa.ars_flag='ON' then 1 else 0 end) as ars_count,  " +
"        sum(case when aa.close_flag='OPEN' then 1 else 0 end) as open_count,                         " +
"        sum(case when aa.alarm_flag='ON' then 1 else 0 end) as alarm_count,                           " +
"        sum(case when aa.assign_owner is null  then 0 else 1 end) as assignto_count                           " +
"  from (      " + sql_count + "  ) aa                                                                                      ";


        ds_temp1 = func.get_dataSet_access(sql_count, conn);

        Label1.Text = ds_temp1.Tables[0].Rows[0]["total_count"].ToString();
        Label2.Text = ds_temp1.Tables[0].Rows[0]["ars_count"].ToString();
        Label3.Text = ds_temp1.Tables[0].Rows[0]["open_count"].ToString();
        Label4.Text = ds_temp1.Tables[0].Rows[0]["alarm_count"].ToString();
        Label5.Text = ds_temp1.Tables[0].Rows[0]["assignto_count"].ToString();


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
        //ExportExcel(GridView1);
        
    }

    public override void VerifyRenderingInServerForm(Control control)
    {
        // base.VerifyRenderingInServerForm(control); 
    }

    private void ExportExcel(GridView SeriesValuesDataGrid)
    {
        Response.Clear();
        Response.Buffer = true;

        string file_name = "attachment;filename=" + today + "_onduty.xls";

        Response.AddHeader("content-disposition", file_name);

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


            // string strSql_file_name;
            string snn1;

            //GridViewRow row = GridView2.Rows[e.RowIndex]; 



            //DataSet ds = new DataSet();




            //           strSql_file_name = " select distinct (t3.file_name)            " +
            //"  from (                                   " +
            //"        select *                           " +
            //"          from night_inspection_file t     " +
            //"         where t.sn = '" + ((DataRowView)e.Row.DataItem)["sn"] + "'     " +
            //"         order by t.dttm desc) t3          ";



            //           ds = func.get_dataSet_access(strSql_file_name, conn);


            //           ((DataList)e.Row.FindControl("DataList1")).DataSource = ds.Tables[0];
            //           ((DataList)e.Row.FindControl("DataList1")).DataBind();






            String close_flag = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "close_flag"));

            if (close_flag == "OPEN")
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[7].Style.Add("background-color", "#B9B9FF");
            //if (close_flag == "Closed")
            //    e.Row.Cells[6].Style.Add("background-color", "#95CAFF");
            //if (close_flag == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF");


            String ars_flag = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ars_flag"));
            if (ars_flag == "ON")
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[7].Style.Add("background-color", "#EE89FC");


            String due_time = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "due_time"));

            if (Convert.ToInt32(due_time) >= 30)
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[6].Style.Add("background-color", "#FFFF80");

            String str_assign_owner = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "assign_owner"));

            if (!str_assign_owner.Equals(""))
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            {
                e.Row.Cells[8].Style.Add("background-color", "#D3FCDB");
                e.Row.Cells[9].Style.Add("background-color", "#D3FCDB");
            } 

          

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

    protected void Button1_Click(object sender, EventArgs e)
    {
        Button1.Attributes["onclick"] = "window.open('onduty_query.aspx?user_id=111', '_blank', 'width=1024px, height=768px,menubar, resizable ,fullscreen,toolbar,directories,scrollbars')";

    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        Button2.Attributes["onclick"] = "window.close()";

    }
}

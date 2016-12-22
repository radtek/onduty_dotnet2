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

public partial class onduty_epaper_daily_e_paper : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql_str = "";

    string sql_count = "";
    string sql_count2 = "";
    string sql_count3 = "";
    string sql_temp2 = "";
    string sql_temp3 = "";
    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        bind_data();
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

      
       
            sql += " and  t1.calltime>=to_date('" +DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + " 08:00"+"','YYYY/MM/DD HH24:MI')     ";

      

       sql += " and  t1.calltime<to_date('" + DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd") + " 08:00" + "','YYYY/MM/DD HH24:MI')     ";

       sql += " and (t1.fab like 'T0%'   or  t1.fab like 'T1%'  or  t1.fab like 'T0T1_OTHERS%' or t1.fab like 'OTHERS%' or t1.fab like 'ARRAY%' or t1.fab like 'CELL%' or t1.fab like 'CF%'  )                                                  ";




       sql += " ORDER BY ARS_FLAG DESC,CLOSE_FLAG DESC,ALARM_FLAG DESC,CALLTIME DESC  ";

        sql_count = sql;
        sql = "select rownum,t.* from (" + sql + ")t  ";




        ds_temp = func.get_dataSet_access(sql, conn);




        GridView1.DataSource = ds_temp;
        GridView1.DataBind();


        sql_temp2 = " select seq,                                               " +
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



        sql_temp2 += " and  t1.calltime>=to_date('" + DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + " 08:00" + "','YYYY/MM/DD HH24:MI')     ";



        sql_temp2 += " and  t1.calltime<to_date('" + DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd") + " 08:00" + "','YYYY/MM/DD HH24:MI')     ";

        sql_temp2 += " and (t1.fab like 'T2%'   or  t1.fab like 'T2_OTHERS%'   )                                                  ";




        sql_temp2 += " ORDER BY ARS_FLAG DESC,CLOSE_FLAG DESC,ALARM_FLAG DESC,CALLTIME DESC  ";

        sql_count2 = sql_temp2;
        sql_temp2 = "select rownum,t.* from (" + sql_count2 + ")t  ";


        ds_temp = func.get_dataSet_access(sql_temp2, conn);




        GridView2.DataSource = ds_temp;
        GridView2.DataBind();


        sql_temp3 = " select seq,                                               " +
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



        sql_temp3 += " and  t1.calltime>=to_date('" + DateTime.Now.AddDays(-1).ToString("yyyy/MM/dd") + " 08:00" + "','YYYY/MM/DD HH24:MI')     ";



       // sql_temp3 += " and  t1.calltime<to_date('" + DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd") + " 08:00" + "','YYYY/MM/DD HH24:MI')     ";

        sql_temp3 += " and (t1.fab like 'T1T2%'      )                                                  ";




        sql_temp3 += " ORDER BY ARS_FLAG DESC,CLOSE_FLAG DESC,ALARM_FLAG DESC,CALLTIME DESC  ";

        sql_count3 = sql_temp3;
        sql_temp3 = "select rownum,t.* from (" + sql_count3 + ")t  ";

        ds_temp = func.get_dataSet_access(sql_temp3, conn);




        GridView3.DataSource = ds_temp;
        GridView3.DataBind();



        sql_count = " select count(aa.seq)as total_count,sum(case when aa.ars_flag='ON' then 1 else 0 end) as ars_count,  " +
"        sum(case when aa.close_flag='OPEN' then 1 else 0 end) as open_count,                         " +
"        sum(case when aa.alarm_flag='ON' then 1 else 0 end) as alarm_count                           " +
"  from (      " + sql_count + "  ) aa                                                                                      ";


        ds_temp1 = func.get_dataSet_access(sql_count, conn);

        //Label1.Text = ds_temp1.Tables[0].Rows[0]["total_count"].ToString();
        //Label2.Text = ds_temp1.Tables[0].Rows[0]["ars_count"].ToString();
        //Label3.Text = ds_temp1.Tables[0].Rows[0]["open_count"].ToString();
        //Label4.Text = ds_temp1.Tables[0].Rows[0]["alarm_count"].ToString();



        return ds_temp;




    }

    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[5].Style.Add("background-color", "#B9B9FF");
            //if (close_flag == "Closed")
            //    e.Row.Cells[6].Style.Add("background-color", "#95CAFF");
            //if (close_flag == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF");


            String ars_flag = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ars_flag"));
            if (ars_flag == "ON")
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[5].Style.Add("background-color", "#EE89FC");


            String due_time = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "due_time"));

            if (Convert.ToInt32(due_time) >= 30)
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[3].Style.Add("background-color", "#FFFF80");

            String str_assign_owner = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "assign_owner"));

            if (!str_assign_owner.Equals(""))
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            {
                e.Row.Cells[6].Style.Add("background-color", "#D3FCDB");
                e.Row.Cells[7].Style.Add("background-color", "#D3FCDB");

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

    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
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
                e.Row.Cells[5].Style.Add("background-color", "#B9B9FF");
            //if (close_flag == "Closed")
            //    e.Row.Cells[6].Style.Add("background-color", "#95CAFF");
            //if (close_flag == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF");


            String ars_flag = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ars_flag"));
            if (ars_flag == "ON")
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[5].Style.Add("background-color", "#EE89FC");


            String due_time = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "due_time"));

            if (Convert.ToInt32(due_time) >= 30)
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[3].Style.Add("background-color", "#FFFF80");

            String str_assign_owner = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "assign_owner"));

            if (!str_assign_owner.Equals(""))
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            {
                e.Row.Cells[6].Style.Add("background-color", "#D3FCDB");
                e.Row.Cells[7].Style.Add("background-color", "#D3FCDB");

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
                e.Row.Cells[5].Style.Add("background-color", "#B9B9FF");
            //if (close_flag == "Closed")
            //    e.Row.Cells[6].Style.Add("background-color", "#95CAFF");
            //if (close_flag == "Cancel")
            //    e.Row.Cells[6].Style.Add("background-color", "#FF9DFF");


            String ars_flag = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "ars_flag"));
            if (ars_flag == "ON")
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[5].Style.Add("background-color", "#EE89FC");


            String due_time = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "due_time"));

            if (Convert.ToInt32(due_time) >= 30)
                //e.Row.Cells[0].BackColor = Color.Yellow; 
                e.Row.Cells[3].Style.Add("background-color", "#FFFF80");

            String str_assign_owner = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "assign_owner"));

            if (!str_assign_owner.Equals(""))
            //e.Row.Cells[0].BackColor = Color.Yellow; 
            {
                e.Row.Cells[6].Style.Add("background-color", "#D3FCDB");
                e.Row.Cells[7].Style.Add("background-color", "#D3FCDB");

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

}

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
 "                additional_i
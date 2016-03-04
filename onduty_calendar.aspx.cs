﻿using System;
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

public partial class _onduty_calendar : System.Web.UI.Page
{

    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    string conn1 = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_T1NEWALARM"];


    string sql_temp = "";
    string sql_temp1 = "";
    string sql_temp2 = "";
    string sql_temp3 = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    DataSet ds_temp2 = new DataSet();
    DataSet ds_temp3 = new DataSet();
    DataSet ds = new DataSet();

    DataView dv = new DataView();
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string today_hour = DateTime.Now.AddDays(+0).ToString("HH");
    string today_min = DateTime.Now.AddDays(+0).ToString("mm");
    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm:ss");
    
    
    protected void Page_Load(object sender, EventArgs e)
    {

        //DBUtil.setUserData(); 
        if (!Page.IsPostBack)
        {
            // setDept(); 
        }
        getProjectTaskDs();
        get_max_time();
        //setColorList(); 
    }

    public Color getStatusColor(string status)
    {
        switch (status)
        {
            case "Receiving":
                return Color.SpringGreen;
                break;
            case "Processing":
                return Color.LightSkyBlue;
                break;
            case "Close":
                return Color.Gray;
                break;
            case "Pending":
                return Color.Yellow;
                break;
            case "Delay":
                return Color.Red;
                break;
            default:
                return Color.Yellow;
                break;
        }
    }

    public void addControl(DayRenderEventArgs e, string project_id, string project_name, string status, DateTime estimate_start_dttm, DateTime estimate_end_dttm, string navigateUrl)
    {
        string strStartText = "<div align='left' style='padding:2px'>";
        string strEndText = "</div>";

        if ((status != "Close" && status != "Pending") && estimate_end_dttm < DateTime.Now)
            status = "Delay";

        //蝜摰璆緮澆亙唳∪蝔? 
        if (e.Day.Date >= estimate_start_dttm && e.Day.Date <= estimate_end_dttm)
        {
            HyperLink link = new HyperLink();

            string strNavigateUrl = navigateUrl + project_id;
            string statusColor = getStatusColor(status).Name;
            string strToolTip = "開啟[" + project_name + "]檢視";

            project_name = "<span style='background-color:" + statusColor + ";'>" + project_name + "</span>";

            if (e.Day.Date == estimate_start_dttm)
                strStartText += "<span style='font-weight:bold; font-size:15px; color:red'></span>";
            if (e.Day.Date == estimate_end_dttm)
                strEndText = "<span style='font-weight:bold; font-size:15px; color:red'></span>" + strEndText;

            link.Text = strStartText + project_name + strEndText;
            link.Target = "_blank";
            link.NavigateUrl = strNavigateUrl;
            link.ToolTip = strToolTip;

            e.Cell.Controls.Add(link);
        }

        //緡蹂賊寄ighlight憿鞎 
        if (e.Day.Date >= DateTime.Now && e.Day.Date < DateTime.Now.AddDays(7))
        {
            e.Cell.BackColor = System.Drawing.Color.Azure;
        }
    }
    private DataSet getProjectTaskDs()
    {
        string strSql = string.Empty;
        //string selectedDept = "''";

        strSql = @"SELECT t.shift_date ,t.name,t.class
FROM onduty_schedule t";

        //if(chkDept.SelectedIndex > -1) 
        // selectedDept = dsutil.getCheckbox2Sql(chkDept); 

        //strSql = string.Format(strSql, selectedDept);

        ds = func.get_dataSet_access(strSql, conn);
        // ds = DBUtil.GetDataset(strSql); 

        return ds;

    }

    private void get_max_time()
    {
        
        string strSqlX = string.Empty;


        strSqlX = @"SELECT max(t.shift_date) as  shift_date
FROM onduty_schedule t";

        //if(chkDept.SelectedIndex > -1) 
        // selectedDept = dsutil.getCheckbox2Sql(chkDept); 

        //strSql = string.Format(strSql, selectedDept);

        ds_temp2 = func.get_dataSet_access(strSqlX, conn);

        Label1.Text = ds_temp2.Tables[0].Rows[0]["shift_date"].ToString();


        // ds = DBUtil.GetDataset(strSql); 


    }


    protected void Calendar1_SelectionChanged(object sender, EventArgs e)
    {
        getProjectList(Calendar1.SelectedDate.ToString("yyyy/MM/dd"));
    }

    //public void setColorList(BulletedList blList) 
    //{ 
    // string[] listStatus = { "Receiving", "Processing", "Close", "Pending", "Delay" }; 
    // blList.Items.Clear(); 
    // foreach (string status in listStatus) 
    // { 
    // ListItem listItem = new ListItem(); 
    // listItem.Text = status; 
    // listItem.Attributes.Add("style", "background-color:" + getStatusColor(status).Name); 
    // blList.Items.Add(listItem); 
    // } 

    //} 

    private void getProjectList(string strSelectedDate)
    {
        //string strSql = string.Empty; 

        //strSql = "select a.*,rownum rn from ( "; 
        //strSql += "select t.project_id , t.project_name , t.applicant, t.apply_date , to_char(t.estimate_start_date,'YYYY/MM/DD') estimate_start_date , to_char(t.estimate_end_date,'YYYY/MM/DD') estimate_end_date , to_char(t.actual_start_date,'YYYY/MM/DD') actual_start_date, to_char(t.actual_end_date,'YYYY/MM/DD') actual_end_date , t.priority, t.status,x.ai_total,x.ai_processing,x.ai_hour,x.ai_unclose_ratio,t1.project_group "; 
        //strSql += " from tms_project t,tms_project_group t1, "; 
        //strSql += "(select t2.*,decode(t2.ai_total,0,0,round(((t2.ai_total-t2.ai_processing)/t2.ai_total),4)*100) ai_unclose_ratio from ( "; 
        //strSql += "select t.project_id,count(*) ai_total, "; 
        //strSql += "sum(decode(t1.status,'Receiving',1,'Processing',1,'Pending',1,0)) ai_processing, "; 
        //strSql += "sum(t1.ai_hour) ai_hour "; 
        //strSql += "from tms_task t,tms_action_item t1 "; 
        //strSql += "where t.task_id=t1.task_id "; 
        //strSql += "and t1.status <> 'Cancel' "; 
        //strSql += "group by t.project_id) t2) x where t.project_id=x.project_id(+) and t.project_group_id = t1.project_id(+) "; 
        //strSql += "and to_date('" + strSelectedDate + "','yyyy/mm/dd') between t.estimate_start_date and t.estimate_end_date and t.status not in ('Cancel') ) a"; 

        ////strSql = @"select t.project_id , t.project_name , t.applicant, t.apply_date , to_char(t.estimate_start_date,'YYYY/MM/DD') estimate_start_date , to_char(t.estimate_end_date,'YYYY/MM/DD') estimate_end_date , to_char(t.actual_start_date,'YYYY/MM/DD') actual_start_date, to_char(t.actual_end_date,'YYYY/MM/DD') actual_end_date , t.priority, t.status 
        //// from tms_project t where to_date('" + strSelectedDate + "','yyyy/mm/dd') between t.estimate_start_date and t.estimate_end_date and status not in ('Cancel') "; 

        //Project_list1.bindGV(strSql); 
        //Project_list1.getCalendarProject(strSelectedDate); 
    }

    // public void getCalendarProject(string strSelectedDate) 
    //{ 
    // strSql = "select a.*,rownum rn from ( "; 
    // strSql += "select t.project_id , t.project_name , t.applicant, t.apply_date , to_char(t.estimate_start_date,'YYYY/MM/DD') estimate_start_date , to_char(t.estimate_end_date,'YYYY/MM/DD') estimate_end_date , to_char(t.actual_start_date,'YYYY/MM/DD') actual_start_date, to_char(t.actual_end_date,'YYYY/MM/DD') actual_end_date , t.priority, t.status,x.ai_total,x.ai_processing,x.ai_hour,x.ai_unclose_ratio,t1.project_group "; 
    // strSql += " from tms_project t,tms_project_group t1, "; 
    // strSql += "(select t2.*,decode(t2.ai_total,0,0,round(((t2.ai_total-t2.ai_processing)/t2.ai_total),4)*100) ai_unclose_ratio from ( "; 
    // strSql += "select t.project_id,count(*) ai_total, "; 
    // strSql += "sum(decode(t1.status,'Receiving',1,'Processing',1,'Pending',1,0)) ai_processing, "; 
    // strSql += "sum(t1.ai_hour) ai_hour "; 
    // strSql += "from tms_task t,tms_action_item t1 "; 
    // strSql += "where t.task_id=t1.task_id "; 
    // strSql += "and nvl(t1.status,'N/A') <> 'Cancel' "; 
    // strSql += "group by t.project_id) t2) x where t.project_id=x.project_id(+) and t.project_group_id = t1.project_id(+) "; 
    // strSql += "and to_date('" + strSelectedDate + "','yyyy/mm/dd') between t.estimate_start_date and t.estimate_end_date and nvl(t.status,'N/A') not in ('Cancel') ) a"; 

    // //lblSql.Text = strSql; 

    // ds = DBUtil.GetDataset(lblSql.Text); 
    // GridView1.DataSource = ds; 
    // GridView1.DataBind(); 
    //} 
    protected void Calendar1_DayRender(object sender, DayRenderEventArgs e)
    {
        string estimate_start_date, estimate_end_date = string.Empty;
        string project_id = string.Empty;
        string project_name = string.Empty;
        string status = string.Empty;
        DateTime estimate_start_dttm, estimate_end_dttm = new DateTime();

        DateTime currentData = DateTime.Now.Date;
        dv = ds.Tables[0].DefaultView;
        ////dv.RowFilter = e.Day.Date.ToString("yyyy/MM/dd") + " between estimate_start_date and estimate_end_date "; 
        //dv.RowFilter = string.Format("estimate_start_date <= '{0}' and estimate_end_date >= '{0}'", e.Day.Date.ToString("yyyy/MM/dd")); 
        dv.RowFilter = string.Format("shift_date <= '{0}' and shift_date >= '{0}'", e.Day.Date.ToString("yyyy/MM/dd"));
        foreach (DataRow Rows in dv.ToTable().Rows)
        {
            estimate_start_date = Rows["shift_date"].ToString() + " 00:00:00";
            estimate_end_date = Rows["shift_date"].ToString() + " 23:59:59";
            //project_id = Rows["TASK_NAME"].ToString(); 
            project_name = "●" + Rows["name"].ToString() +"_" +Rows["class"].ToString();
            status = "";
           // status = Rows["status"].ToString();


            estimate_start_dttm = DateTime.Parse(estimate_start_date);
            estimate_end_dttm = DateTime.Parse(estimate_end_date);

            addControl(e, project_id, project_name, status, estimate_start_dttm, estimate_end_dttm, "");
        }
    } 

}

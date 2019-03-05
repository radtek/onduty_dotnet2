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
using System.Net;
using System.Text;
using System.Net.Mail;
using Innolux.Portal.Common;

public partial class onduty_add : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");
    string todayHour = DateTime.Now.AddDays(+0).ToString("HH");
    string todayMin = DateTime.Now.AddDays(+0).ToString("mm");
    DataSet dsTemp = new DataSet();
    DataSet dsTemp1 = new DataSet();
    string sql = "";
    ArrayList arlistTemp1 = new ArrayList();
    ArrayList arlistTemp2 = new ArrayList();
    ArrayList arlistTemp3 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["seq"] = Request.QueryString["seq"];
            //Session["seq"] = "30918";

            //Session["seq"] = "30840";

            #region offday


            string[] offday ={ "日A", "日B", "夜A", "夜B", "常日" };

            TextBox_ARS_LINK.Text = "";

            RadioButtonList_OFFDAY.DataSource = offday;
            RadioButtonList_OFFDAY.DataBind();

            RadioButtonList_OFFDAY.SelectedValue = GetClass(today, todayHour);
            //RadioButtonList_OFFDAY.SelectedValue = "DB";

            #endregion


            #region rejudge_flag

            string[] rejudge_flag ={ "Y", "N" };

            RadioButtonList1.DataSource = rejudge_flag;
            RadioButtonList1.DataBind();
            RadioButtonList1.SelectedValue = "N";
            #endregion


            #region CLOSE_FLAG

            string[] closeFlag ={ "OPEN", "CLOSE" };

            RadioButtonList_CLOSE_FLAG.DataSource = rejudge_flag;
            RadioButtonList_CLOSE_FLAG.DataBind();
            RadioButtonList_CLOSE_FLAG.SelectedValue = "OPEN";
            #endregion


            #region ALARM_FLAG

            string[] alarmFlag ={ "ON", "OFF" };

            RadioButtonList_ALARM_FLAG.DataSource = rejudge_flag;
            RadioButtonList_ALARM_FLAG.DataBind();
            RadioButtonList_ALARM_FLAG.SelectedValue = "OFF";
            #endregion


            #region ARS_FLAG

            string[] arsFlag ={ "ON", "OFF" };

            RadioButtonList_ARS_FLAG.DataSource = rejudge_flag;
            RadioButtonList_ARS_FLAG.DataBind();
            RadioButtonList_ARS_FLAG.SelectedValue = "OFF";
            #endregion


            #region CLOSE_FLAG
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_CLOSE_FLAG.txt");



            RadioButtonList_CLOSE_FLAG.DataSource = arlistTemp1;
            RadioButtonList_CLOSE_FLAG.DataBind();
            #endregion

            #region ALARM_FLAG
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_ALARM_FLAG.txt");


            RadioButtonList_ALARM_FLAG.DataSource = arlistTemp1;
            RadioButtonList_ALARM_FLAG.DataBind();
            #endregion


            #region ARS_FLAG
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_ARS_FLAG.txt");



            RadioButtonList_ARS_FLAG.DataSource = arlistTemp1;
            RadioButtonList_ARS_FLAG.DataBind();
            #endregion

            #region ENG_DEP
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_ENG_DEP.txt");



            DropDownList_ENG_DEP.DataSource = arlistTemp1;
            DropDownList_ENG_DEP.DataBind();
            #endregion

            #region ENGINEER


            DropDownList_ENGINEER.Items.Insert(0, "請選擇");

            #endregion

            #region date

            txtEstimateCALLTIME.SelectedDate = Convert.ToDateTime(today);
            txtEstimateSTARTTIME.SelectedDate = Convert.ToDateTime(today);
            txtEstimateEndTime.SelectedDate = Convert.ToDateTime(today);



            #endregion


            #region hour
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\hour.txt");



            DropDownList1.DataSource = arlistTemp1;
            DropDownList1.DataBind();
            DropDownList1.SelectedValue = todayHour;


            DropDownList3.DataSource = arlistTemp1;
            DropDownList3.DataBind();
            DropDownList3.SelectedValue = todayHour;


            DropDownList5.DataSource = arlistTemp1;
            DropDownList5.DataBind();
            DropDownList5.SelectedValue = todayHour;

            #endregion


            #region min
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\min.txt");



            DropDownList2.DataSource = arlistTemp1;
            DropDownList2.DataBind();
            DropDownList2.SelectedValue = todayMin;



            DropDownList4.DataSource = arlistTemp1;
            DropDownList4.DataBind();
            DropDownList4.SelectedValue = todayMin;

            DropDownList6.DataSource = arlistTemp1;
            DropDownList6.DataBind();
            DropDownList6.SelectedValue = todayMin;

            #endregion


            #region fab
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab.txt");



            DropDownList1_FAB.DataSource = arlistTemp1;
            DropDownList1_FAB.DataBind();
            DropDownList1_FAB.Items.Insert(0, "請選擇");



            #endregion


            #region SYSTEM
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_System.txt");



            DropDownList_SYSTEM.DataSource = arlistTemp1;
            DropDownList_SYSTEM.DataBind();
            DropDownList_SYSTEM.Items.Insert(0, "請選擇");



            #endregion

            #region TYPE
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_TYPE.txt");



            DropDownList_TYPE.DataSource = arlistTemp1;
            DropDownList_TYPE.DataBind();
            DropDownList_TYPE.Items.Insert(0, "請選擇");



            #endregion


            #region PRODUCT_IMPACT
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_PRODUCT_IMPACT.txt");



            DropDownList_PRODUCT_IMPACT.DataSource = arlistTemp1;
            DropDownList_PRODUCT_IMPACT.DataBind();
            DropDownList_PRODUCT_IMPACT.Items.Insert(0, "請選擇");



            #endregion


            #region ASSIGN_OWNER
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_CIM_MEMBER.txt");



            DropDownList_ASSIGN_OWNER.DataSource = arlistTemp1;
            DropDownList_ASSIGN_OWNER.DataBind();
            DropDownList_ASSIGN_OWNER.Items.Insert(0, "請選擇");



            #endregion

            #region BY_WHOM
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_CIM_MEMBER.txt");



            DropDownList_BY_WHOM.DataSource = arlistTemp1;
            DropDownList_BY_WHOM.DataBind();
            DropDownList_BY_WHOM.Items.Insert(0, "請選擇");



            #endregion

            #region due_time
            Label1.Text = "0";
            #endregion



            // BindData1();

            #region hyperlink

            HyperLink hp = new HyperLink();
            hp = HyperLink_ARS_LINK;
            if (TextBox_ARS_LINK.Text.Trim() != null)
            {
                hp.NavigateUrl = TextBox_ARS_LINK.Text;
                hp.Target = "_blank";
            }

            #endregion


        }

    }


    protected void DropDownList_ENG_DEP_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList_ENG_DEP.SelectedValue.Equals("CIM"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_CIM_MEMBER.txt");
            DropDownList_ENGINEER.DataSource = arlistTemp1;
            DropDownList_ENGINEER.DataBind();
        }
        if (DropDownList_ENG_DEP.SelectedValue.Equals("AT"))
        {

            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_AT_MEMBER.txt");
            DropDownList_ENGINEER.DataSource = arlistTemp1;
            DropDownList_ENGINEER.DataBind();
        }

    }
    protected void DropDownList1_FAB_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (DropDownList1_FAB.SelectedValue.Equals("T1Array") || DropDownList1_FAB.SelectedValue.Equals("T0Array"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T0Array.txt");

        }
        if (DropDownList1_FAB.SelectedValue.Equals("T0Cell") || DropDownList1_FAB.SelectedValue.Equals("T1Cell"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T0Cell.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T1CF"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T1CF.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("ARRAY") || DropDownList1_FAB.SelectedValue.Equals("CELL") || DropDownList1_FAB.SelectedValue.Equals("CF"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_Array.txt");

        }
        if (DropDownList1_FAB.SelectedValue.Equals("OTHERS"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_Others.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T0T1_OTHERS"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_Others.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T2_OTHERS"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_Others.txt");

        }


        if (DropDownList1_FAB.SelectedValue.Equals("T2Array"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2Array.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T2Cell"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2Cell.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T2CF"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2CF.txt");

        }
        if (DropDownList1_FAB.SelectedValue.Equals("T1T2_OTHERS"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T1T2_OTHERS.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T2LCM"))
        {
            arlistTemp3 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2LCM.txt");

        }



        DropDownList_AREA.DataSource = arlistTemp3;
        DropDownList_AREA.DataBind();
    }

    public string GetClass(string today_time, string hour)
    {
        string baseDate = "2008/12/18";

        int count = 0;

        System.DateTime time1 = Convert.ToDateTime(baseDate);
        // System.DateTime time2 = Convert.ToDateTime(txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd"));
        System.DateTime time2 = Convert.ToDateTime(DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd"));



        TimeSpan ts = time2.Subtract(time1);
        Int32 diffm = Convert.ToInt32(ts.TotalDays);
        Int32 diffm2 = diffm % 4;
        string class_AB = "";
        string class_DN = "";
        string combine = "";

        if (diffm2.Equals(0))
        {
            class_AB = "A(1)";
        }
        else if (diffm2.Equals(1))
        {

            class_AB = "A(2)";
        }
        else if (diffm2.Equals(2))
        {
            class_AB = "B(1)";
        }
        else
        {

            class_AB = "B(2)";

        }

        if (Convert.ToInt32(hour) > 7 && Convert.ToInt32(hour) < 19)
        {
            class_DN = "D";

        }
        else
        {
            class_DN = "N";

        }



        combine = class_DN + class_AB;

        combine = combine.Substring(0, 2);

        combine = combine.Replace("D", "日");
        combine = combine.Replace("N", "夜");


        // Label1.Visible = true;

        //Label1.Text = combine;
        return combine;


    }

    private DataSet BindData1()
    {

        string sql = " select seq,                     " +
"        calltime,                " +
"        endtime,                 " +
"        caller,                  " +
"        extension,               " +
"        engineer,                " +
"        fab,                     " +
"        system,                  " +
"        offday,                  " +
"        type,                    " +
"        cassette,                " +
"        lot_id,                  " +
"        eq_id,                   " +
"        question,                " +
"        bywhom,                  " +
"        description,             " +
"        mantis,                  " +
"        insert_time,             " +
"        close_flag,              " +
"        mobile,                  " +
"        area,                    " +
"        starttime,               " +
"        reason,                  " +
"        method,                  " +
"        assign_owner,            " +
"        additional_info,         " +
"        ars_flag,                " +
"        ars_link,                " +
"        due_time,                " +
"        alarm_flag,              " +
"        product_impact,          " +
"        org_flag,                " +
"        product_impact_info,     " +
"        finaltime,               " +
"        recharge_flag,           " +
"        modify_count             " +
"   from onduty t2                " +
"   where t2.seq='" + Session["seq"].ToString() + "'            ";


        dsTemp = func.get_dataSet_access(sql, conn);

        //Label_SEQ.Text = dsTemp.Tables[0].Rows[0]["seq"].ToString();
        RadioButtonList_OFFDAY.SelectedValue = dsTemp.Tables[0].Rows[0]["offday"].ToString();
        TextBox_MOBILE.Text = dsTemp.Tables[0].Rows[0]["mobile"].ToString();
        DropDownList_ENGINEER.Items.Insert(0, dsTemp.Tables[0].Rows[0]["engineer"].ToString());
        txtEstimateCALLTIME.SelectedDate = Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["calltime"].ToString());


        DropDownList1.Items.Insert(0, Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["calltime"].ToString()).ToString("HH"));
        DropDownList2.Items.Insert(0, Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["calltime"].ToString()).ToString("mm"));

        TextBox_CALLER.Text = dsTemp.Tables[0].Rows[0]["caller"].ToString();
        TextBox_EXTENTION.Text = dsTemp.Tables[0].Rows[0]["extension"].ToString();
        DropDownList1_FAB.Items.Insert(0, dsTemp.Tables[0].Rows[0]["fab"].ToString());
        DropDownList_AREA.Items.Insert(0, dsTemp.Tables[0].Rows[0]["area"].ToString());
        DropDownList_SYSTEM.Items.Insert(0, dsTemp.Tables[0].Rows[0]["system"].ToString());
        DropDownList_TYPE.Items.Insert(0, dsTemp.Tables[0].Rows[0]["type"].ToString());
        DropDownList_PRODUCT_IMPACT.Items.Insert(0, dsTemp.Tables[0].Rows[0]["product_impact"].ToString());
        TextBox_PRODUCT_IMPACT_INFO.Text = dsTemp.Tables[0].Rows[0]["product_impact_info"].ToString();
        TextBox_CASSETTE.Text = dsTemp.Tables[0].Rows[0]["cassette"].ToString();
        TextBox_LOT_ID.Text = dsTemp.Tables[0].Rows[0]["lot_id"].ToString();
        TextBox_EQ_ID.Text = dsTemp.Tables[0].Rows[0]["eq_id"].ToString();
        TextBox_QUESTION.Text = dsTemp.Tables[0].Rows[0]["question"].ToString();
        txtEstimateSTARTTIME.SelectedDate = Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["starttime"].ToString());
        DropDownList3.Items.Insert(0, Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["starttime"].ToString()).ToString("HH"));
        DropDownList4.Items.Insert(0, Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["starttime"].ToString()).ToString("mm"));

        DropDownList_BY_WHOM.Items.Insert(0, dsTemp.Tables[0].Rows[0]["bywhom"].ToString());

        txtEstimateEndTime.SelectedDate = Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["endtime"].ToString());
        DropDownList5.Items.Insert(0, Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["endtime"].ToString()).ToString("HH"));
        DropDownList6.Items.Insert(0, Convert.ToDateTime(dsTemp.Tables[0].Rows[0]["endtime"].ToString()).ToString("mm"));

        if (Convert.ToInt32(dsTemp.Tables[0].Rows[0]["due_time"].ToString()) > 30)
        {
            Label1.ForeColor = Color.Red;

        }
        Label1.Text = dsTemp.Tables[0].Rows[0]["due_time"].ToString();

        TextBox_DESCRIPTION.Text = dsTemp.Tables[0].Rows[0]["description"].ToString();

        TextBox_REASON.Text = dsTemp.Tables[0].Rows[0]["reason"].ToString();

        TextBox_METHOD.Text = dsTemp.Tables[0].Rows[0]["method"].ToString();

        RadioButtonList_CLOSE_FLAG.SelectedValue = dsTemp.Tables[0].Rows[0]["close_flag"].ToString();

        RadioButtonList_ALARM_FLAG.SelectedValue = dsTemp.Tables[0].Rows[0]["alarm_flag"].ToString();

        RadioButtonList_ARS_FLAG.SelectedValue = dsTemp.Tables[0].Rows[0]["ars_flag"].ToString();

        TextBox_ARS_LINK.Text = dsTemp.Tables[0].Rows[0]["ars_link"].ToString().Trim();

        DropDownList_ASSIGN_OWNER.Items.Insert(0, dsTemp.Tables[0].Rows[0]["assign_owner"].ToString());

        RadioButtonList1.SelectedValue = dsTemp.Tables[0].Rows[0]["recharge_flag"].ToString();

        TextBox_ADDITION_INFO.Text = dsTemp.Tables[0].Rows[0]["additional_info"].ToString();

        return dsTemp;
    }
    protected void Button1_Click(object sender, EventArgs e)
    {
        if (DropDownList_ENGINEER.Text.Equals("請選擇"))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請選擇 值班工程師!!!');");
            Response.Write("</script>");
            return;

        }



        if (DropDownList1_FAB.Text.Equals("請選擇"))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請選擇 FAB!!!');");
            Response.Write("</script>");
            return;

        }
        
        if (DropDownList_SYSTEM.SelectedValue.Equals("請選擇"))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請選擇 SYSTEM!!!');");
            Response.Write("</script>");
            return;

        }

        if (DropDownList_TYPE.SelectedValue.Equals("請選擇"))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請選擇 TYPE!!! ');");
            Response.Write("</script>");
            return;

        }
        if (DropDownList_PRODUCT_IMPACT.SelectedValue.Equals("請選擇"))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請輸入 生產影響!!! ');");
            Response.Write("</script>");
            return;

        }
       
        if (TextBox_PRODUCT_IMPACT_INFO.Text.Equals(""))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請輸入 生產影響敘述!!!');");
            Response.Write("</script>");
            return; 
        
        }
        
        if (TextBox_QUESTION.Text.Equals(""))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請輸入 來電問題!!!');");
            Response.Write("</script>");
            return;

        }

        if (DropDownList_BY_WHOM.SelectedValue.Equals("請選擇"))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請選擇 處理者!!!');");
            Response.Write("</script>");
            return;

        }
        if (TextBox_DESCRIPTION.Text.Equals(""))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請輸入 異常描述!!!');");
            Response.Write("</script>");
            return;

        }

        if (TextBox_REASON.Text.Equals(""))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請輸入 異常原因!!!');");
            Response.Write("</script>");
            return;

        }

        if (TextBox_METHOD.Text.Equals(""))
        {
            Response.Write("<script language='javascript'>" + "\n");
            Response.Write("alert('請輸入 排除方法!!!');");
            Response.Write("</script>");
            return;

        }

       




        
        
        

        
        
        string sql_max_sn = " select max(t.seq)as seq  from onduty t ";

        dsTemp1 = func.get_dataSet_access(sql_max_sn, conn);

        Int32 max_sn = Convert.ToInt32(dsTemp1.Tables[0].Rows[0]["seq"]);

        max_sn++;

        sql = " insert into onduty        " +
"   (seq,                   " +
"    calltime,              " +
"    endtime,               " +
"    caller,                " +
"    extension,             " +
"    engineer,              " +
"    fab,                   " +
"    system,                " +
"    offday,                " +
"    type,                  " +
"    cassette,              " +
"    lot_id,                " +
"    eq_id,                 " +
"    question,              " +
"    bywhom,                " +
"    description,           " +
"    insert_time,           " +
"    close_flag,            " +
"    mobile,                " +
"    area,                  " +
"    starttime,             " +
"    reason,                " +
"    method,                " +
"    assign_owner,          " +
"    additional_info,       " +
"    ars_flag,              " +
"    ars_link,              " +
"    due_time,              " +
"    alarm_flag,            " +
"    product_impact,        " +
"    org_flag,              " +
"    product_impact_info,   " +
"    finaltime,             " +
"    recharge_flag,         " +
"    modify_count)          " +
" values                    " +
"   (onduty_seq.nextval,                 " +
"to_date('" + txtEstimateCALLTIME.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList1.SelectedValue + ":" + DropDownList2.SelectedValue + "','YYYY/MM/DD HH24:MI'),     " +
 "        to_date('" + txtEstimateEndTime.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList5.SelectedValue + ":" + DropDownList6.SelectedValue + "','YYYY/MM/DD HH24:MI'),     " +
"       '" + TextBox_CALLER.Text.Trim().Replace("'", "''") + "',                           " +
 "        '" + TextBox_EXTENTION.Text.Trim().Replace("'", "''") + "',                     " +
 "        '" + DropDownList_ENGINEER.SelectedValue + "',                       " +
 "      '" + DropDownList1_FAB.SelectedValue + "',                                 " +
  "        '" + DropDownList_SYSTEM.SelectedValue + "',                           " +
  "        '" + RadioButtonList_OFFDAY.SelectedValue + "',                           " +
  "       '" + DropDownList_TYPE.SelectedValue + "',                               " +
  "        '" + TextBox_CASSETTE.Text.Trim().Replace("'", "''") + "',                       " +
  "        '" + TextBox_LOT_ID.Text.Trim().Replace("'", "''") + "',                           " +
  "         '" + TextBox_EQ_ID.Text.Trim().Replace("'", "''") + "',                             " +
 "         '" + TextBox_QUESTION.Text.Trim().Replace("'", "''") + "',                       " +
 "         '" + DropDownList_BY_WHOM.SelectedValue + "',                           " +
  "       '" + TextBox_DESCRIPTION.Text.Trim().Replace("'", "''")  + "',                 " +
"    sysdate,         " +
  "   '" + RadioButtonList_CLOSE_FLAG.SelectedValue + "',                   " +
  "       '" + TextBox_MOBILE.Text.Trim().Replace("'", "''") + "',                           " +
  "      '" + DropDownList_AREA.Text + "',                               " +
"        to_date('" + txtEstimateSTARTTIME.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList3.SelectedValue + ":" + DropDownList4.SelectedValue + "','YYYY/MM/DD HH24:MI'),     " +
  "      '" + TextBox_REASON.Text.Trim().Replace("'", "''") + "',                           " +
  "      '" + TextBox_METHOD.Text.Trim().Replace("'", "''") + "',                           " +
  "      '" + DropDownList_ASSIGN_OWNER.SelectedValue + "',               " +
  "    '" + TextBox_ADDITION_INFO.Text.Trim().Replace("'", "''") + "',         " +
  "     '" + RadioButtonList_ARS_FLAG.SelectedValue + "',                       " +
  "       '" + TextBox_ARS_LINK.Text.Trim().Replace("'", "''") + "',                       " +
 "       round((to_date('" + txtEstimateEndTime.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList5.SelectedValue + ":" + DropDownList6.SelectedValue + "','YYYY/MM/DD HH24:MI')-" + "to_date('" + txtEstimateSTARTTIME.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList3.SelectedValue + ":" + DropDownList4.SelectedValue + "','YYYY/MM/DD HH24:MI') )*24*60,0) ," +
  "      '" + RadioButtonList_ALARM_FLAG.SelectedValue + "',                   " +
  "     '" + DropDownList_PRODUCT_IMPACT.SelectedValue + "',           " +
"    '" + RadioButtonList_CLOSE_FLAG.SelectedValue + "',            " +
  "       '" + TextBox_PRODUCT_IMPACT_INFO.Text.Trim().Replace("'", "''") + "', " +
"    sysdate,           " +
  " '" + RadioButtonList1.SelectedValue + "',             " +
"    0)        ";

        func.get_sql_execute(sql, conn);

        if (!DropDownList_ASSIGN_OWNER.SelectedValue.Equals("請選擇"))
        {
            call_mail(max_sn.ToString(), DropDownList_ASSIGN_OWNER.SelectedValue);
        }


        #region Add UploadFile


        NetworkDrive oNetDrive1 = new NetworkDrive();
        oNetDrive1.LocalDrive = "M:";
        oNetDrive1.Persistent = true;
        oNetDrive1.SaveCredentials = true;
        oNetDrive1.ShareName = @"\\172.16.12.62\ams";

        try
        {
            oNetDrive1.MapDrive(@"T1FAB\t1eda", "CIMabc123");




            for (int i = 1; i <= Request.Files.Count; i++)
            {
                FileUpload myFL = new FileUpload();
                ContentPlaceHolder c = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
                myFL = (FileUpload)c.FindControl("FileUpload" + i);
                //myFL = (FileUpload)Page.FindControl("FileUpload" + i);
                if (myFL.PostedFile.ContentLength < 15360000)
                {

                    if ((myFL.PostedFile != null) && (myFL.PostedFile.ContentLength > 0))
                    {

                        string fn = System.IO.Path.GetFileName(myFL.PostedFile.FileName);
                        // string saveLocation = Server.MapPath("../") + "\\upload_file\\" + fn;
                        //string saveLocation = Server.MapPath("FileList/") + fn;
                        string saveLocation = oNetDrive1.LocalDrive + @"\" + fn;


                        //Session["file_path"] = "FileList/" + fn;
                        int file_size = myFL.PostedFile.ContentLength;
                        string file_type = myFL.PostedFile.ContentType;
                        try
                        {
                            myFL.PostedFile.SaveAs(saveLocation);

                            //OleDbConnection myConnection = new OleDbConnection(ConfigurationSettings.AppSettings["dsnn"]);

                            //string strClientIP;

                            string strClientIP = Request.ServerVariables["remote_host"].ToString();

                            string sql_insert = @"insert into onduty_file
                                             (seq, file_name, dttm)
                                             values
                                            ('{0}', '{1}', sysdate)";

                            FileHandle cfilehandle = new FileHandle();
                            cfilehandle.GetMaxSeq();
                            //cfilehandle.Seq = Session["seq"].ToString();
                            sql_insert = string.Format(sql_insert, cfilehandle.Seq, fn);

                            func.get_sql_execute(sql_insert, conn);



                        }
                        catch (Exception ex)
                        {
                            Response.Write("上傳檔案失敗");
                        }
                    }

                }

                else
                {
                    //Label3.Visible = true;
                    //Label3.Text = "上傳檔案超過15MB...";

                }
            }
            // Parser_tmp_directory_file(oNetDrive.LocalDrive + "\\T1\\" + DropDownList1.SelectedValue.ToString() + "\\EDANG\\", "*.TXT", -360);
            // Delete_tmp_directory_file(HttpContext.Current.Server.MapPath(".") + "\\File\\", "*", -3);


            oNetDrive1.UnMapDrive(oNetDrive1.LocalDrive, true);
        }
        catch (Exception)
        {

            oNetDrive1.UnMapDrive(oNetDrive1.LocalDrive, true);
        }
        finally
        {
            //oNetDrive.UnMapDrive();
        }


        //oNetDrive.MapDrive(@"T1FAB\t1eda", "CIMabc123");

        #endregion
        Response.Write("<script language='javascript' type='text/JavaScript'>\n");
        Response.Write("alert('新增成功!!');\n");
        Response.Write("location = 'onduty_query.aspx';\n");
        //Response.Write("setTimeout(\"window.opener=null; window.close();\",null)");
        Response.Write("</script>");
        //Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");

        //Response.Redirect("onduty_add.aspx");

        //Page_Load(null, null);
    }


    public class FileHandle
    {
        // Field
        public string Name;
        public string Seq;

        // Constructor that takes no arguments.
        public FileHandle()
        {
            //Name = "unknown";
        }

        // Constructor that takes one argument.
        public FileHandle(string nm)
        {
            //Name = nm;
        }

        // Method
        public void GetMaxSeq()
        {
            //Name = newName;
            DataSet dsTemp1=new DataSet();
            string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
            string sql = @"
                    select max(t.seq)seq from onduty t

                  ";



            dsTemp1 = func.get_dataSet_access(sql, conn);
            Seq = dsTemp1.Tables[0].Rows[0]["seq"].ToString();
          
        }


        public void InsertFileData(string fileName)
        {
            //name = newName;
            DataSet dsTemp1 = new DataSet();
            string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
            string sql = @"
                    select max(t.seq)seq from onduty t

                  ";



            dsTemp1 = func.get_dataSet_access(sql, conn);
            Seq = dsTemp1.Tables[0].Rows[0]["seq"].ToString();





        }
    }





    public void call_mail(string sn, string receive1)
    {


        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");
        string strHTML = w.DownloadString("http://10.56.131.22/onduty_dotnet2/record_assign_mail_sample.aspx?seq=" + sn + "");

        //string sql = " select count(*) as count_num from ( " +
        //" " +
        //" SELECT " +
        //" format(t1.date_time,'YYYY/MM/DD') as " +
        //" date_time,t1.stock_name,t1.stock_id,t1.price,round(t1.percentage*100,2)&'%' " +
        //" as percentage,t1.volumn,round(t1.K_percentage*100,2)&'%' as K_percentage FROM " +
        //" strong_up t1,(select stock_id from volumn t2 where t2.date_time>=format(now()- " +
        //" 7,'YYYY/MM/DD') )t3 where t1.date_time>format(now()-1,'YYYY/MM/DD') and t1.stock_id in (t3.stock_id) " +
        //" " +
        //" ) " +
        //" " +
        //" ";
        //dsTemp = func.get_dataSet_access(sql, conn);


        string title = "[CIM電子報]:您被 Assign 值班記錄-> " + DateTime.Now.ToString("yyyy/MM/dd") + " 編號【 " + sn + "  】";
        //ArrayList maillist = func.FileToArray(Server.MapPath(".") + "\\maillist\\onduty.txt");
        //string receive = maillist[0].ToString();

        string sql_receive = "select t.email from onduty_email_list t where t.cname='" + receive1 + "' ";

        dsTemp1 = func.get_dataSet_access(sql_receive, conn);

        string receive = dsTemp1.Tables[0].Rows[0]["email"].ToString();


        //receive = "oscar.hsieh@chimei-innolux.com";

        SendEmail("cimalarm@innolux.com", receive, title, strHTML, "");// 
        //SendEmail("vsoscar@ms26.url.com.tw", "vsoscar2003@yahoo.com.hk", title, strHTML, "");//測試寄送程式 
        //jrrsc@ms96.url.com.tw 
        //fdlsongyy888@hotmail.com,vsoscar2003@yahoo.com.hk,liu.chang@msa.hinet.net,phyllis0531@hotmail.com,m8903157@yahoo.com.tw,benjamin6522@hotmail.com,dai.ww@msa.hinet.net,vrmouse@hotmail.com,roger.liu@infomax.com.tw,Yu.ChiaHao@gmail.com,chin-1520@yahoo.com.tw,heavenlibra@yahoo.com.tw,scm.shen@msa.hinet.net,bakery1202@gmail.com 
        //write_log("MAIL"); 
        //WebClient w1 = new WebClient();
        //w1.Encoding = Encoding.GetEncoding("utf-8");
        //string strHTML1 = w.DownloadString("http://vsoscar.no-ip.org/stock/three_top_open_cross.php");
        //SAVE_CREATE_FILE(strHTML1); 
        //Response.Write("<script language=\"javascript\">setTimeout(\"window.opener=null; window.close();\",null)</script>");
    }



    public static void SendEmail(string from, string to, string subject, string body, string cca)
    {
        SmtpClient smtp = new SmtpClient("10.56.196.147");
        MailMessage email = new MailMessage(from, to, subject, body);
        if (cca == "")
        {
        }
        else
        {
            //email.CC.Add(cca); 
            email.Bcc.Add(cca);
        }

        email.IsBodyHtml = true;
        smtp.Send(email);


    }

    protected void TextBox_PRODUCT_IMPACT_INFO_TextChanged(object sender, EventArgs e)
    {

    }
}

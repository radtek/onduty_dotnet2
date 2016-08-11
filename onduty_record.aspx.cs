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

public partial class onduty_record : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    DataSet dsTemp = new DataSet();
    DataSet dsTemp1 = new DataSet();
    string sql = "";
    ArrayList arlistTemp1 = new ArrayList();
    ArrayList arlistTemp2 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            Session["seq"] = Request.QueryString["seq"];


            //Session["seq"] = "30918";

            //Session["seq"] = "45097";

            #region offday

            sql = " select distinct(t.offday) as offday from onduty t " +
" where t.offday not in ('OFF','ON')      ";
            dsTemp = func.get_dataSet_access(sql, conn);

            TextBox_ARS_LINK.Text = "";

            RadioButtonList_OFFDAY.DataSource = dsTemp.Tables[0];

            RadioButtonList_OFFDAY.DataTextField = "offday";
            RadioButtonList_OFFDAY.DataValueField = "offday";
            RadioButtonList_OFFDAY.DataBind();


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
            RadioButtonList_CLOSE_FLAG.SelectedValue = "CLOSE";
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


            #region hour
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\hour.txt");



            DropDownList1.DataSource = arlistTemp1;
            DropDownList1.DataBind();


            DropDownList3.DataSource = arlistTemp1;
            DropDownList3.DataBind();


            DropDownList5.DataSource = arlistTemp1;
            DropDownList5.DataBind();

            #endregion


            #region min
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\min.txt");



            DropDownList2.DataSource = arlistTemp1;
            DropDownList2.DataBind();


            DropDownList4.DataSource = arlistTemp1;
            DropDownList4.DataBind();


            DropDownList6.DataSource = arlistTemp1;
            DropDownList6.DataBind();

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

            

            BindData1();

            #region hyperlink

            HyperLink hp = new HyperLink();
            hp = HyperLink_ARS_LINK;
            if (!TextBox_ARS_LINK.Text.Trim().Equals(""))
            {
                hp.NavigateUrl = TextBox_ARS_LINK.Text;
                hp.Target = "_blank";
                hp.Visible = true;
            }
            
            #endregion


       


        }

        #region GetUploadFile

        DataTable dt = new DataTable();


        sql = @"select t.file_name from onduty_file t
                           where t.seq='{0}'  order by dttm   ";

        sql = string.Format(sql, Session["seq"].ToString());



        dt = func.get_dataSet_access(sql, conn).Tables[0];


        TableRow row = new TableRow();



        for (int i = 0; i <= dt.Rows.Count - 1; i++)
        {

            TableCell cell = new TableCell();



            HyperLink alnk = new HyperLink();

            //alnk.Text = Convert.ToString(i + 1);
            alnk.Text = dt.Rows[i]["file_name"].ToString();


            alnk.ID = (alnk + i.ToString());
            alnk.Target = "_blank";

            alnk.NavigateUrl = "http://10.56.131.22/onduty_dotnet2/FileList/" + dt.Rows[i]["file_name"].ToString();



            cell.Controls.Add(alnk);

            row.Cells.Add(cell);

            Table1.Rows.Add(row);

        }
        #endregion

    }


    public class FileHandle
    {
        // Field
        public string Name;
        public string Seq;

        // Constructor that takes no arguments.
        public FileHandle()
        {
            //name = "unknown";
        }

        // Constructor that takes one argument.
        public FileHandle(string nm)
        {
            //Name = nm;
        }

        // Method
        public void GetMaxSeq()
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



    protected void ButtonModify_Click(object sender, EventArgs e)
    {
        
        string sql_modify_count = "select t.modify_count from onduty t where t.seq='" + Session["seq"] + "' ";

        dsTemp1 = func.get_dataSet_access(sql_modify_count, conn);

        Int32 modify_count_num = Convert.ToInt32(dsTemp1.Tables[0].Rows[0]["modify_count"]);

        modify_count_num++;
        
        sql = " update onduty                                       " +
  "    set seq = '" + Session["seq"].ToString() + "',                                 " +
  "        calltime = to_date('" + txtEstimateCALLTIME.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList1.SelectedValue + ":" + DropDownList2.SelectedValue + "','YYYY/MM/DD HH24:MI'),     "+
   "        endtime = to_date('" + txtEstimateEndTime.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList5.SelectedValue + ":" + DropDownList6.SelectedValue + "','YYYY/MM/DD HH24:MI'),     " +
  "        caller = '" + TextBox_CALLER.Text+ "',                           " +
  "        extension = '" + TextBox_EXTENTION.Text.Trim().Replace("'", "''") + "',                     " +
  "        engineer = '" + DropDownList_ENGINEER .SelectedValue+ "',                       " +
  "        fab = '" + DropDownList1_FAB .SelectedValue+ "',                                 " +
  "        system = '" + DropDownList_SYSTEM .SelectedValue+ "',                           " +
  "        offday = '" + RadioButtonList_OFFDAY .SelectedValue+ "',                           " +
  "        type = '" + DropDownList_TYPE .SelectedValue+ "',                               " +
  "        cassette = '" + TextBox_CASSETTE .Text+ "',                       " +
  "        lot_id = '" + TextBox_LOT_ID.Text.Trim().Replace("'", "''") + "',                           " +
  "        eq_id = '" + TextBox_EQ_ID.Text.Trim().Replace("'", "''") + "',                             " +
  "        question = '" + TextBox_QUESTION.Text.Trim().Replace("'", "''") + "',                       " +
  "        bywhom = '" + DropDownList_BY_WHOM .SelectedValue+ "',                           " +
  "        description = '" + TextBox_DESCRIPTION.Text.Trim().Replace("'", "''") + "',                 " +
  "        close_flag = '" + RadioButtonList_CLOSE_FLAG .SelectedValue+ "',                   " +
  "        mobile = '" + TextBox_MOBILE.Text.Trim().Replace("'", "''") + "',                           " +
  "        area = '" + DropDownList_AREA .Text+ "',                               " +
  "        starttime = to_date('" + txtEstimateSTARTTIME.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList3.SelectedValue + ":" + DropDownList4.SelectedValue + "','YYYY/MM/DD HH24:MI'),     " +
  "        reason = '" + TextBox_REASON .Text.Trim().Replace("'","''")+ "',                           " +
  "        method = '" + TextBox_METHOD.Text.Trim().Replace("'", "''") + "',                           " +
  "        assign_owner = '" + DropDownList_ASSIGN_OWNER .SelectedValue+ "',               " +
  "        additional_info = '" + TextBox_ADDITION_INFO.Text.Trim().Replace("'", "''") + "',         " +
  "        ars_flag = '" + RadioButtonList_ARS_FLAG .SelectedValue+ "',                       " +
  "        ars_link = '" + TextBox_ARS_LINK.Text.Trim().Replace("'", "''") + "',                       " +
  "        due_time = round((to_date('" + txtEstimateEndTime.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList5.SelectedValue + ":" + DropDownList6.SelectedValue + "','YYYY/MM/DD HH24:MI')-" + "to_date('" + txtEstimateSTARTTIME.SelectedDate.Value.ToString("yyyy/MM/dd") + " " + DropDownList3.SelectedValue + ":" + DropDownList4.SelectedValue + "','YYYY/MM/DD HH24:MI') )*24*60,0) ," +
  "        alarm_flag = '" + RadioButtonList_ALARM_FLAG .SelectedValue+ "',                   " +
  "        product_impact = '" + DropDownList_PRODUCT_IMPACT.SelectedValue + "',           " +
  "        product_impact_info = '" + TextBox_PRODUCT_IMPACT_INFO.Text.Trim().Replace("'", "''") + "', " +
  "        finaltime = sysdate,                     " +
  "        recharge_flag = '" + RadioButtonList1 .SelectedValue+ "',             " +
  "        modify_count = '" + modify_count_num + "'                " +
  "  where seq = '" + Session["seq"].ToString() + "'                                  ";

        func.get_sql_execute(sql, conn);
        BindData1();

        #region Add UploadFile


        for (int i = 1; i <= Request.Files.Count; i++)
        {
            FileUpload myFL = new FileUpload();
            //ContentPlaceHolder c = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            //myFL = (FileUpload)c.FindControl("FileUpload" + i);
            myFL = (FileUpload)Page.FindControl("FileUpload" + i);
            if (myFL.PostedFile.ContentLength < 15360000)
            {

                if ((myFL.PostedFile != null) && (myFL.PostedFile.ContentLength > 0))
                {

                    string fn = System.IO.Path.GetFileName(myFL.PostedFile.FileName);
                    // string saveLocation = Server.MapPath("../") + "\\upload_file\\" + fn;
                    string saveLocation = Server.MapPath("FileList/") + fn;

                    Session["file_path"] = "FileList/" + fn;
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
        #endregion

//        string frmClose = @"<script language='javascript' type='text/JavaScript'> 
//                             self.opener.location.reload();
//                             window.opener=null; 
//
//                             window.open('','_self'); 
//
//                             window.close();
//
//                             </script>";

//        //呼叫 javascript 
//        this.Page.RegisterStartupScript("", frmClose);


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
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T0Array.txt");

        }
        if (DropDownList1_FAB.SelectedValue.Equals("T0Cell") || DropDownList1_FAB.SelectedValue.Equals("T1Cell"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T0Cell.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T1CF"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T1CF.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("ARRAY") || DropDownList1_FAB.SelectedValue.Equals("CELL") || DropDownList1_FAB.SelectedValue.Equals("CF"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_Array.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("OTHERS"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_Others.txt");

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
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2Array.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T2Cell"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2Cell.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T2CF"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T2CF.txt");

        }

        if (DropDownList1_FAB.SelectedValue.Equals("T1T2_OTHERS"))
        {
            arlistTemp1 = func.FileToArray(Server.MapPath(".") + "\\config\\onduty_fab_T1T2_OTHERS.txt");

        }

        DropDownList_AREA.DataSource = arlistTemp1;
        DropDownList_AREA.DataBind();
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

        Label_SEQ.Text = dsTemp.Tables[0].Rows[0]["seq"].ToString();
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
}

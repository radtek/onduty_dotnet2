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

public partial class Lh_onduty_onduty_lh_record : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_LHMIS1"];
    string conn1 = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_MEETUSER"];


    //string start_time = txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");
    //string end_time = txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd").Replace("/", "");
    ArrayList arlist_temp1 = new ArrayList();
    string sql_temp = "";
    DataSet ds_temp = new DataSet();

    DataSet ds_temp1 = new DataSet();

    
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
           

            //Session["sn"] = "120100701F9258730";

            Session["sn"] = Request["sn"].Trim().ToUpper();
            //Session["user_id"] = Request["user_id"].Trim().ToUpper();
            ds_temp1 = bind_data();

            Label3.Text = ds_temp1.Tables[0].Rows[0]["SN"].ToString();



            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\flag_type.txt");

            DropDownList5.DataSource = arlist_temp1;

            DropDownList5.DataBind();


            DropDownList5.SelectedValue = ds_temp1.Tables[0].Rows[0]["STATUS"].ToString();




            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\lh_category.txt");

            DropDownList1.DataSource = arlist_temp1;

            DropDownList1.DataBind();


            DropDownList1.SelectedValue = ds_temp1.Tables[0].Rows[0]["category"].ToString();





            Label4.Text = ds_temp1.Tables[0].Rows[0]["EMPNAME"].ToString();
            Label1.Text = ds_temp1.Tables[0].Rows[0]["empno"].ToString();
            Label7.Text = ds_temp1.Tables[0].Rows[0]["buname"].ToString();
            Label8.Text = ds_temp1.Tables[0].Rows[0]["divname"].ToString();
            Label9.Text = ds_temp1.Tables[0].Rows[0]["dep_name"].ToString();
            Label10.Text = ds_temp1.Tables[0].Rows[0]["type_name"].ToString();
            Label5.Text = ds_temp1.Tables[0].Rows[0]["days_workcontinue"].ToString();
            Label6.Text = ds_temp1.Tables[0].Rows[0]["dttm"].ToString();
            TextBox5.Text = ds_temp1.Tables[0].Rows[0]["description"].ToString();
            //Label12.Text = ds_temp1.Tables[0].Rows[0]["close_person"].ToString();
            Label11.Text = ds_temp1.Tables[0].Rows[0]["close_dttm"].ToString();
            TextBox1.Text = ds_temp1.Tables[0].Rows[0]["close_person"].ToString();
            //TextBox1.Text = Session["user_id"];
            //Label12.Text = Request["user_id"].Trim().ToUpper();

        }

        if (DropDownList5.SelectedValue.Equals("CLOSED"))
        {
            Button1.Visible = false;

        }


       
    }


    protected void Button1_Click(object sender, EventArgs e)
    {
       

       
        
        Response.Write("<script language='javascript'>\n");
        Response.Write("window.open('UPLOAD.aspx?sn=" + Session["sn"] + "', '_blank', 'height=800, width=1000, left=0, top=0, location=no,	menubar=no, resizable=yes, scrollbars=yes, titlebar=no, toolbar=no', true);\n");
        //Response.Write("window.opener=null; window.close();\n");
        Response.Write("</script>");
    }
    protected void Button2_Click(object sender, EventArgs e)
    {
        
        sql_temp = " update lh_onduty_record                   " +
"    set                                    " +
"        status = '" + DropDownList5 .SelectedValue+ "',                 " +
"        category = '" + DropDownList1 .SelectedValue+ "',             " +
"        description = '" + TextBox5 .Text+ "',       " +
"                                           " +
"        close_person = '" + TextBox1.Text + "',     " +
"        close_dttm = sysdate               " +
"  where sn='" + Session["sn"] .ToString()+ "'                              ";

        func.get_sql_execute(sql_temp, conn1);

       Response.Write("<script language='javascript' type='text/JavaScript'>\n");
       Response.Write("alert('資料更新 完成!!!');\n");
       //Response.Write("opener.document.location.reload(); window.opener=null; window.close();\n");

       //Response.Write("location = 'onduty_lh_query.aspx';\n");

       //Response.Write(" window.navigate(window.location.href);\n");

       Response.Write("window.opener.location=window.opener.location;\n");
       //Response.Write("opener.document.location.reload();\n");
       Response.Write("window.opener=null; window.close();\n");
       Response.Write("</script>");
       


    }

    protected DataSet bind_data()
    {
        string sql = " select t1.* from lh_onduty_record t1                             " +
 " where sn='" + Session["sn"] + "'                                                    ";


        sql = "select rownum,t.* from (" + sql + ")t  ";

        ds_temp = func.get_dataSet_access(sql, conn1);

        //GridView1.DataSource = ds_temp;
        //GridView1.DataBind();



        return ds_temp;




    }

    protected void TextBox5_TextChanged(object sender, EventArgs e)
    {

    }
}

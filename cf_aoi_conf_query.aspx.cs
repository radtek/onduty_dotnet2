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

public partial class cf_aoi_conf_query : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_EDA"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyyMMddHHmmss");

    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet();
    string sql_str = "";
    string sql_ProdID = "";
    string sql_Recipe = "";

    string sql_change = "";


    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            sql_str =@"
select distinct(t.equip_id) as equip_id from ldr_cf_step_mapping_t t  order by t.equip_id";
            ds_temp = func.get_dataSet_access(sql_str, conn);



            DropDownList1.DataSource = ds_temp.Tables[0];

            DropDownList1.DataTextField = "equip_id";
            DropDownList1.DataValueField = "equip_id";
            DropDownList1.DataBind();
            DropDownList1.Items.Insert(0, "請選擇");




            #region MyRegion ProdID
            sql_ProdID = @" 
select distinct(t.product_id) as product_id from ldr_cf_step_mapping_t t order by t.product_id";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_ProdID, conn);
            DropDownList2.DataSource = ds_temp.Tables[0];
            DropDownList2.DataTextField = "product_id";
            DropDownList2.DataValueField = "product_id";

            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "請選擇");

            #endregion

            #region SubEQID
            sql_ProdID = @" 
select distinct(t.sub_equip_id) as sub_equip_id from ldr_cf_step_mapping_t t order by t.sub_equip_id";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_ProdID, conn);
            DropDownList3.DataSource = ds_temp.Tables[0];
            DropDownList3.DataTextField = "sub_equip_id";
            DropDownList3.DataValueField = "sub_equip_id";

            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "請選擇");


            #endregion


            #region RECIPE
            sql_Recipe = @" 
select distinct(t.recipe_id) as recipe_id from ldr_cf_step_mapping_t t order by recipe_id ";
            // ds_temp.Clear();
            ds_temp = func.get_dataSet_access(sql_Recipe, conn);
            DropDownList4.DataSource = ds_temp.Tables[0];
            DropDownList4.DataTextField = "recipe_id";
            DropDownList4.DataValueField = "recipe_id";

            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, "請選擇");


            #endregion

    

            //bind_data();


        }
    }
    protected void ButtonQuery_Click(object sender, EventArgs e)
    {
        sql_change = @"select *  from ldr_cf_step_mapping_t t where  1=1 ";

        if (!DropDownList1.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and  t.equip_id='" + DropDownList1.SelectedValue + "'    ";
          
        }

        if (!DropDownList2.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and   t.product_id='" + DropDownList2.SelectedValue + "'    ";

        }
        if (!DropDownList3.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and   t.sub_equip_id='" + DropDownList3.SelectedValue + "'    ";

        }

        if (!DropDownList4.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and  t.recipe_id='" + DropDownList4.SelectedValue + "'    ";

        }

        ds_temp = func.get_dataSet_access(sql_change, conn);

        GridView1.DataSource = ds_temp.Tables[0];
        GridView1.DataBind();

    }
    protected void btnExport_Click1(object sender, EventArgs e)
    {
        GridView gv = new GridView();
        gv.DataSource = bind_data();
        gv.DataBind();

        ExportExcel(gv);
    }
    protected void DropDownList1_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (!DropDownList1.SelectedValue.Equals("請選擇"))

        {
            sql_str = @"
select distinct(t.product_id) as product_id from ldr_cf_step_mapping_t t where  1=1  and t.equip_id='{0}' order by product_id";

            sql_str = string.Format(sql_str, DropDownList1.SelectedValue);

            ds_temp = func.get_dataSet_access(sql_str, conn);



            DropDownList2.DataSource = ds_temp.Tables[0];

            DropDownList2.DataTextField = "product_id";
            DropDownList2.DataValueField = "product_id";
            DropDownList2.DataBind();
            DropDownList2.Items.Insert(0, "請選擇");
        }
      

    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        if (!DropDownList2.SelectedValue.Equals("請選擇"))

        {
            sql_str = @"
select distinct(t.sub_equip_id) as sub_equip_id from ldr_cf_step_mapping_t t where t.equip_id='{0}' and t.product_id='{1}' order by  t.sub_equip_id";

            sql_str = string.Format(sql_str,DropDownList1.SelectedValue,DropDownList2.SelectedValue);
            
            ds_temp = func.get_dataSet_access(sql_str, conn);



            DropDownList3.DataSource = ds_temp.Tables[0];

            DropDownList3.DataTextField = "sub_equip_id";
            DropDownList3.DataValueField = "sub_equip_id";
            DropDownList3.DataBind();
            DropDownList3.Items.Insert(0, "請選擇");
        }
       
    }
    protected void DropDownList3_SelectedIndexChanged(object sender, EventArgs e)
    {

        if (!DropDownList3.SelectedValue.Equals("請選擇"))

        {
            sql_str = @"
 select distinct(t.recipe_id) as recipe_id from ldr_cf_step_mapping_t t where t.equip_id='{0}' and t.product_id='{1}' and t.sub_equip_id='{2}' order by recipe_id";

            sql_str = string.Format(sql_str, DropDownList1.SelectedValue, DropDownList2.SelectedValue,DropDownList3.SelectedValue);
            ds_temp = func.get_dataSet_access(sql_str, conn);



            DropDownList4.DataSource = ds_temp.Tables[0];

            DropDownList4.DataTextField = "recipe_id";
            DropDownList4.DataValueField = "recipe_id";
            DropDownList4.DataBind();
            DropDownList4.Items.Insert(0, "請選擇");
        
        }
    
     
    }



    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {

       

        if (e.Row.RowType == DataControlRowType.DataRow)
        {


            // string strSql_file_name;
            string snn1;
            if (e.Row.RowIndex != -1)
            {
                int RN = e.Row.RowIndex + 1;
                e.Row.Cells[0].Text = RN.ToString();
            }
          

        }
    }


    private void ExportExcel(GridView SeriesValuesDataGrid)
    {
        Response.Clear();
        Response.Buffer = true;

        string file_name = "attachment;filename=" + today + "_cf_aoi.xls";

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

    private DataSet bind_data()
    {
        sql_change = @"select *  from ldr_cf_step_mapping_t t where  1=1 ";

        if (!DropDownList1.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and  t.equip_id='" + DropDownList1.SelectedValue + "'    ";

        }

        if (!DropDownList2.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and   t.product_id='" + DropDownList2.SelectedValue + "'    ";

        }
        if (!DropDownList3.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and   t.sub_equip_id='" + DropDownList3.SelectedValue + "'    ";

        }

        if (!DropDownList4.SelectedValue.Equals("請選擇"))
        {
            sql_change += "and  t.recipe_id='" + DropDownList4.SelectedValue + "'    ";

        }

        ds_temp = func.get_dataSet_access(sql_change, conn);
      

        return ds_temp;
    }

   
}

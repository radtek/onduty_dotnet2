using System.Data;
using System;
using System.Configuration;
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;
using Dundas.Charting.WebControl;

public partial class onduty_integrated : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            string sql_date = "select distinct('W'||substr(to_char(t.calltime+1,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) as week_num from  onduty t order by week_num desc";

            DropDownList1.DataTextField = "week_num";
            DropDownList1.DataValueField = "week_num";
            DropDownList1.DataSource = get_dataSet_access(sql_date);
            DropDownList1.DataBind();
            doChart_person();
            BindGridView_person();
            doChart_area();
            BindGridView_area();
            doChart_system();
            BindGridView_system();
            doChart_product_impact();
            BindGridView_product_impact();

        }
    }


    private DataSet get_dataSet_access(string sql_str)
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;

        sql_str2 = sql_str;

        OleDbDataAdapter myCommand2 = new OleDbDataAdapter(sql_str2, strConn2);

        DataSet myDataSet2 = new DataSet();
        myCommand2.Fill(myDataSet2, "AccessInfo");
        return myDataSet2;

    }


    protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        //    {
        //        ((DropDownList)e.Row.FindControl("lblStatus_Edit_Drop")).SelectedValue = ((DataRowView)e.Row.DataItem)["status"].ToString();

        //        //((HyperLink)e.Row.FindControl("HyperLink2")).Visible = false;

        //    }

        //    //e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
        //}
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //string DEADLINE = (Label)e.Row.FindControl("DEADLINE").ToString();

        //    String DEADLINE = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEADLINE"));



        //    // DataBinder.Eval(Container.DataItem, "Price", "{0:c}") 

        //    //if (DEADLINE == "DEADLINE") 緪格砌?銝剔洵撟曉銝剔撘蝥 "DEADLINE"  槫瑁?
        //    //{

        //    e.Row.Cells[15].Style.Add("background-color", "#FFFF80"); //蝚?5甈雿  靽格寧箄瘥憿鞎蝥 #FFFF80
        //    //e.Row.Cells[15].BackColor=

        //    // }
        //}

    }
    protected void GridView2_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        //    {
        //        ((DropDownList)e.Row.FindControl("lblStatus_Edit_Drop")).SelectedValue = ((DataRowView)e.Row.DataItem)["status"].ToString();

        //        //((HyperLink)e.Row.FindControl("HyperLink2")).Visible = false;

        //    }

        //    //e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
        //}
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //string DEADLINE = (Label)e.Row.FindControl("DEADLINE").ToString();

        //    String DEADLINE = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEADLINE"));



        //    // DataBinder.Eval(Container.DataItem, "Price", "{0:c}") 

        //    //if (DEADLINE == "DEADLINE") 緪格砌?銝剔洵撟曉銝剔撘蝥 "DEADLINE"  槫瑁?
        //    //{

        //    e.Row.Cells[15].Style.Add("background-color", "#FFFF80"); //蝚?5甈雿  靽格寧箄瘥憿鞎蝥 #FFFF80
        //    //e.Row.Cells[15].BackColor=

        //    // }
        //}

    }
    protected void GridView3_RowDataBound(object sender, GridViewRowEventArgs e)
    {
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    if ((e.Row.RowState == (DataControlRowState.Edit | DataControlRowState.Alternate)) || (e.Row.RowState == DataControlRowState.Edit))
        //    {
        //        ((DropDownList)e.Row.FindControl("lblStatus_Edit_Drop")).SelectedValue = ((DataRowView)e.Row.DataItem)["status"].ToString();

        //        //((HyperLink)e.Row.FindControl("HyperLink2")).Visible = false;

        //    }

        //    //e.Row.Cells[e.Row.Cells.Count - 1].Visible = false;
        //}
        //if (e.Row.RowType == DataControlRowType.DataRow)
        //{
        //    //string DEADLINE = (Label)e.Row.FindControl("DEADLINE").ToString();

        //    String DEADLINE = Convert.ToString(DataBinder.Eval(e.Row.DataItem, "DEADLINE"));



        //    // DataBinder.Eval(Container.DataItem, "Price", "{0:c}") 

        //    //if (DEADLINE == "DEADLINE") 緪格砌?銝剔洵撟曉銝剔撘蝥 "DEADLINE"  槫瑁?
        //    //{

        //    e.Row.Cells[15].Style.Add("background-color", "#FFFF80"); //蝚?5甈雿  靽格寧箄瘥憿鞎蝥 #FFFF80
        //    //e.Row.Cells[15].BackColor=

        //    // }
        //}

    }

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //gvNewsList.PageIndex = e.NewPageIndex;
        BindGridView_person2();


    }
    protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView2.PageIndex = e.NewPageIndex;
        //gvNewsList.PageIndex = e.NewPageIndex;
        BindGridView_area2();


    }
    protected void GridView3_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView3.PageIndex = e.NewPageIndex;
        //gvNewsList.PageIndex = e.NewPageIndex;
        BindGridView_system2();


    }
    protected void GridView4_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView4.PageIndex = e.NewPageIndex;
        //gvNewsList.PageIndex = e.NewPageIndex;
        BindGridView_product_impact2();


    }

    private void doChart_person()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart1.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        //string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        //string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.engineer,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.engineer      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_type = ds22.Tables[0].DefaultView;

        dv_type.RowFilter = " ";

        dv_type.Sort = "DATE1 asc";
        DataTable TypeTable;
        //將重複的data distinct出來
        TypeTable = dv_type.ToTable(true, "engineer");
        dv_type.Sort = "";

        string sql_current_week = "";

        sql_current_week = sql_current_week + "select * from (                                                                                                     ";
        sql_current_week = sql_current_week + "select distinct('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) as week_num from  onduty t   ";
        sql_current_week = sql_current_week + "                                                                                                  ";
        sql_current_week = sql_current_week + "order by week_num desc                                                                                              ";
        sql_current_week = sql_current_week + ")                                                                                                                   ";
        sql_current_week = sql_current_week + "where rownum<2      ";

        DataSet da_current_week = new DataSet();
        da_current_week = get_dataSet_access(sql_current_week);

        

        DataView TypeView = TypeTable.DefaultView;

        for (int x = 0; x >= 0; x--)
        {


            string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_type.RowFilter = "date1='" + date_key + "'";


            if (TypeView.Count > 0)
            {



                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["engineer"].ToString();
                    dv_type.RowFilter = "date1='" + date_key + "' and engineer='" + typeCode + "'";

                    if (dv_type.Count > 0)
                    {
                        if (typeCode != "")
                        {
                            Chart1.Series.Add(typeCode);
                            Chart1.Series[typeCode].Points.AddXY(date_key, Convert.ToDouble(dv_type[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (typeCode != "")
                        {
                            Chart1.Series.Add(typeCode);
                            Chart1.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["engineer"].ToString();

                    if (typeCode != "")
                    {

                        Chart1.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

        //DataView dv = ds22.Tables[0].DefaultView;

        //dv.RowFilter = "type = '" + onduty_type[0] + "'";

        //dv.Sort = "DATE1 asc";

        //for (int j = 0; j < dv.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[0]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }

        //DataView dv1 = ds22.Tables[0].DefaultView;

        //dv1.RowFilter = "type = '" + onduty_type[1] + "'";

        //dv1.Sort = "DATE1 asc";

        //for (int j = 0; j < dv1.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[1]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }



        string dep_key = "";


    }

    private void doChart_person2()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart1.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        //string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        //string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.engineer,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.engineer      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'   ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_type = ds22.Tables[0].DefaultView;

        dv_type.RowFilter = " ";

        dv_type.Sort = "DATE1 asc";
        DataTable TypeTable;
        //將重複的data distinct出來
        TypeTable = dv_type.ToTable(true, "engineer");
        dv_type.Sort = "";

        DataView TypeView = TypeTable.DefaultView;

        Chart1.Series.Clear();

        for (int x = 0; x >= 0; x--)
        {

            string date_key = "20" + DropDownList1.Text.Substring(1, 2) + "/" + DropDownList1.Text.Substring(3, 2);
            //string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_type.RowFilter = "date1='" + date_key + "'";


            if (TypeView.Count > 0)
            {



                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["engineer"].ToString();
                    dv_type.RowFilter = "date1='" + date_key + "' and engineer='" + typeCode + "'";

                    if (dv_type.Count > 0)
                    {
                        if (typeCode != "")
                        {
                            Chart1.Series.Add(typeCode);
                            Chart1.Series[typeCode].Points.AddXY(date_key, Convert.ToDouble(dv_type[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (typeCode != "")
                        {
                            Chart1.Series.Add(typeCode);
                            Chart1.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["engineer"].ToString();

                    if (typeCode != "")
                    {
                        Chart1.Series.Add(typeCode);
                        Chart1.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

      



        string dep_key = "";


    }

    private void doChart_area()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart2.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        // string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        //string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.FAB,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime+1,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.FAB      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_FAB = ds22.Tables[0].DefaultView;

        dv_FAB.RowFilter = " ";

        dv_FAB.Sort = "DATE1 asc";
        DataTable FABTable;
        //將重複的data distinct出來
        FABTable = dv_FAB.ToTable(true, "FAB");
        dv_FAB.Sort = "";

        string sql_current_week = "";

        sql_current_week = sql_current_week + "select * from (                                                                                                     ";
        sql_current_week = sql_current_week + "select distinct('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) as week_num from  onduty t   ";
        sql_current_week = sql_current_week + "                                                                                                  ";
        sql_current_week = sql_current_week + "order by week_num desc                                                                                              ";
        sql_current_week = sql_current_week + ")                                                                                                                   ";
        sql_current_week = sql_current_week + "where rownum<2      ";

        DataSet da_current_week = new DataSet();
        da_current_week = get_dataSet_access(sql_current_week);


        DataView FABView = FABTable.DefaultView;

        for (int x = 0; x >= 0; x--)
        {


            string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_FAB.RowFilter = "date1='" + date_key + "'";


            if (FABView.Count > 0)
            {



                for (int j = 0; j < FABView.Count; j++)
                {
                    string FABCode = FABView[j]["FAB"].ToString();
                    dv_FAB.RowFilter = "date1='" + date_key + "' and FAB='" + FABCode + "'";

                    if (dv_FAB.Count > 0)
                    {
                        if (FABCode != "")
                        {
                            Chart2.Series.Add(FABCode);
                            Chart2.Series[FABCode].Points.AddXY(date_key, Convert.ToDouble(dv_FAB[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (FABCode != "")
                        {
                            Chart2.Series.Add(FABCode);
                            Chart2.Series[FABCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < FABView.Count; j++)
                {
                    string FABCode = FABView[j]["FAB"].ToString();

                    if (FABCode != "")
                    {

                        Chart2.Series[FABCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

        //DataView dv = ds22.Tables[0].DefaultView;

        //dv.RowFilter = "type = '" + onduty_type[0] + "'";

        //dv.Sort = "DATE1 asc";

        //for (int j = 0; j < dv.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[0]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }

        //DataView dv1 = ds22.Tables[0].DefaultView;

        //dv1.RowFilter = "type = '" + onduty_type[1] + "'";

        //dv1.Sort = "DATE1 asc";

        //for (int j = 0; j < dv1.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[1]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }



        //string dep_key = "";


    }
    private void doChart_area2()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart2.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        //string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.FAB,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.FAB      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'   ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_type = ds22.Tables[0].DefaultView;

        dv_type.RowFilter = " ";

        dv_type.Sort = "DATE1 asc";
        DataTable TypeTable;
        //將重複的data distinct出來
        TypeTable = dv_type.ToTable(true, "FAB");
        dv_type.Sort = "";

        DataView TypeView = TypeTable.DefaultView;
        Chart2.Series.Clear();
        for (int x = 0; x >= 0; x--)
        {

            string date_key = "20" + DropDownList1.Text.Substring(1, 2) + "/" + DropDownList1.Text.Substring(3, 2);
            //string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_type.RowFilter = "date1='" + date_key + "'";


            if (TypeView.Count > 0)
            {



                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["FAB"].ToString();
                    dv_type.RowFilter = "date1='" + date_key + "' and FAB='" + typeCode + "'";

                    if (dv_type.Count > 0)
                    {
                        if (typeCode != "")
                        {
                            Chart2.Series.Add(typeCode);
                            Chart2.Series[typeCode].Points.AddXY(date_key, Convert.ToDouble(dv_type[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (typeCode != "")
                        {
                            Chart2.Series.Add(typeCode);
                            Chart2.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["FAB"].ToString();

                    if (typeCode != "")
                    {

                        Chart2.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

        



        string dep_key = "";


    }
    private void doChart_system()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart3.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        // string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        //string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.SYSTEM,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.SYSTEM                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.SYSTEM      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.SYSTEM) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_FAB = ds22.Tables[0].DefaultView;

        dv_FAB.RowFilter = " ";

        dv_FAB.Sort = "DATE1 asc";
        DataTable FABTable;
        //將重複的data distinct出來
        FABTable = dv_FAB.ToTable(true, "SYSTEM");
        dv_FAB.Sort = "";

        string sql_current_week = "";

        sql_current_week = sql_current_week + "select * from (                                                                                                     ";
        sql_current_week = sql_current_week + "select distinct('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) as week_num from  onduty t   ";
        sql_current_week = sql_current_week + "                                                                                                  ";
        sql_current_week = sql_current_week + "order by week_num desc                                                                                              ";
        sql_current_week = sql_current_week + ")                                                                                                                   ";
        sql_current_week = sql_current_week + "where rownum<2      ";

        DataSet da_current_week = new DataSet();
        da_current_week = get_dataSet_access(sql_current_week);


        DataView FABView = FABTable.DefaultView;

        for (int x = 0; x >= 0; x--)
        {


            string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_FAB.RowFilter = "date1='" + date_key + "'";


            if (FABView.Count > 0)
            {



                for (int j = 0; j < FABView.Count; j++)
                {
                    string FABCode = FABView[j]["SYSTEM"].ToString();
                    dv_FAB.RowFilter = "date1='" + date_key + "' and SYSTEM='" + FABCode + "'";

                    if (dv_FAB.Count > 0)
                    {
                        if (FABCode != "")
                        {
                            Chart3.Series.Add(FABCode);
                            Chart3.Series[FABCode].Points.AddXY(date_key, Convert.ToDouble(dv_FAB[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (FABCode != "")
                        {
                            Chart3.Series.Add(FABCode);
                            Chart3.Series[FABCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < FABView.Count; j++)
                {
                    string FABCode = FABView[j]["SYSTEM"].ToString();

                    if (FABCode != "")
                    {

                        Chart3.Series[FABCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

        //DataView dv = ds22.Tables[0].DefaultView;

        //dv.RowFilter = "type = '" + onduty_type[0] + "'";

        //dv.Sort = "DATE1 asc";

        //for (int j = 0; j < dv.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[0]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }

        //DataView dv1 = ds22.Tables[0].DefaultView;

        //dv1.RowFilter = "type = '" + onduty_type[1] + "'";

        //dv1.Sort = "DATE1 asc";

        //for (int j = 0; j < dv1.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[1]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }



        //string dep_key = "";


    }
    private void doChart_system2()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart3.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        //string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.SYSTEM,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime, 'yyyy/IW'), t.SYSTEM                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.SYSTEM      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime,'IW')) ='" + DropDownList1.Text + "'   ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime, 'yyyy/IW'), t.SYSTEM) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_type = ds22.Tables[0].DefaultView;

        dv_type.RowFilter = " ";

        dv_type.Sort = "DATE1 asc";
        DataTable TypeTable;
        //將重複的data distinct出來
        TypeTable = dv_type.ToTable(true, "SYSTEM");
        dv_type.Sort = "";

        DataView TypeView = TypeTable.DefaultView;
        Chart3.Series.Clear();
        for (int x = 0; x >= 0; x--)
        {

            string date_key = "20" + DropDownList1.Text.Substring(1, 2) + "/" + DropDownList1.Text.Substring(3, 2);
            //string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_type.RowFilter = "date1='" + date_key + "'";


            if (TypeView.Count > 0)
            {



                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["SYSTEM"].ToString();
                    dv_type.RowFilter = "date1='" + date_key + "' and SYSTEM='" + typeCode + "'";

                    if (dv_type.Count > 0)
                    {
                        if (typeCode != "")
                        {
                            Chart3.Series.Add(typeCode);
                            Chart3.Series[typeCode].Points.AddXY(date_key, Convert.ToDouble(dv_type[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (typeCode != "")
                        {
                            Chart3.Series.Add(typeCode);
                            Chart3.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["SYSTEM"].ToString();

                    if (typeCode != "")
                    {
                        Chart3.Series.Add(typeCode);
                        Chart3.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

       



       // string dep_key = "";


    }
    private void doChart_product_impact()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart4.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        // string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        //string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       trim(t.product_impact) as product_impact,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'),trim(t.product_impact)                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               trim(t.product_impact) as product_impact      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_FAB = ds22.Tables[0].DefaultView;

        dv_FAB.RowFilter = " ";

        dv_FAB.Sort = "DATE1 asc";
        DataTable FABTable;
        //將重複的data distinct出來
        FABTable = dv_FAB.ToTable(true, "product_impact");
        dv_FAB.Sort = "";

        string sql_current_week = "";

        sql_current_week = sql_current_week + "select * from (                                                                                                     ";
        sql_current_week = sql_current_week + "select distinct('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) as week_num from  onduty t   ";
        sql_current_week = sql_current_week + "                                                                                                  ";
        sql_current_week = sql_current_week + "order by week_num desc                                                                                              ";
        sql_current_week = sql_current_week + ")                                                                                                                   ";
        sql_current_week = sql_current_week + "where rownum<2      ";

        DataSet da_current_week = new DataSet();
        da_current_week = get_dataSet_access(sql_current_week);


        DataView FABView = FABTable.DefaultView;

        for (int x = 0; x >= 0; x--)
        {


            string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_FAB.RowFilter = "date1='" + date_key + "'";


            if (FABView.Count > 0)
            {



                for (int j = 0; j < FABView.Count; j++)
                {
                    string FABCode = FABView[j]["product_impact"].ToString();
                    dv_FAB.RowFilter = "date1='" + date_key + "' and product_impact='" + FABCode + "'";

                    if (dv_FAB.Count > 0)
                    {
                        if (FABCode != "")
                        {
                            Chart4.Series.Add(FABCode);
                            Chart4.Series[FABCode].Points.AddXY(date_key, Convert.ToDouble(dv_FAB[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (FABCode != "")
                        {
                            Chart4.Series.Add(FABCode);
                            Chart4.Series[FABCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < FABView.Count; j++)
                {
                    string FABCode = FABView[j]["product_impact"].ToString();

                    if (FABCode != "")
                    {
                        Chart4.Series.Add(FABCode);
                        Chart4.Series[FABCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

        //DataView dv = ds22.Tables[0].DefaultView;

        //dv.RowFilter = "type = '" + onduty_type[0] + "'";

        //dv.Sort = "DATE1 asc";

        //for (int j = 0; j < dv.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[0]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }

        //DataView dv1 = ds22.Tables[0].DefaultView;

        //dv1.RowFilter = "type = '" + onduty_type[1] + "'";

        //dv1.Sort = "DATE1 asc";

        //for (int j = 0; j < dv1.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[1]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }



        //string dep_key = "";


    }
    private void doChart_product_impact2()
    {

        string strConn_chart = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        //clear all point
        foreach (Series series in Chart4.Series)
        {
            series.Points.Clear();
        }
        //Chart1.Series.Clear();

        DataSet ds22 = new DataSet();
        DataSet ds33 = new DataSet();

        //string[] onduty_type = { "詢問問題", "操作錯誤(MO)", "系統BUG", "設備", "整合Modeling問題" };


        string sql_str2 = "";


        string sql_product;

        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       trim(t.product_impact) as product_impact,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               trim(t.product_impact) as product_impact      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'   ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)) t2                                                                                              ";


        ds22 = get_dataSet_access(sql_str2);




        //ds = dbutil.GetDataset(sql_grade);


        DataView dv_type = ds22.Tables[0].DefaultView;

        dv_type.RowFilter = " ";

        dv_type.Sort = "DATE1 asc";
        DataTable TypeTable;
        //將重複的data distinct出來
        TypeTable = dv_type.ToTable(true, "product_impact");
        dv_type.Sort = "";

        DataView TypeView = TypeTable.DefaultView;
        Chart4.Series.Clear();
        for (int x = 0; x >= 0; x--)
        {

            string date_key = "20" + DropDownList1.Text.Substring(1, 2) + "/" + DropDownList1.Text.Substring(3, 2);
            //string date_key = DateTime.Now.ToString("yyyy") + "/" + da_current_week.Tables[0].Rows[0]["week_num"].ToString().Substring(3, 2);

            dv_type.RowFilter = "date1='" + date_key + "'";


            if (TypeView.Count > 0)
            {



                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["product_impact"].ToString();
                    dv_type.RowFilter = "date1='" + date_key + "' and product_impact='" + typeCode + "'";

                    if (dv_type.Count > 0)
                    {
                        if (typeCode != "")
                        {
                            Chart4.Series.Add(typeCode);
                            Chart4.Series[typeCode].Points.AddXY(date_key, Convert.ToDouble(dv_type[0]["due_time"]));
                        }



                    }
                    else
                    {
                        if (typeCode != "")
                        {

                            Chart4.Series.Add(typeCode);
                            Chart4.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                        }



                    }
                }
            }

            else
            {

                for (int j = 0; j < TypeView.Count; j++)
                {
                    string typeCode = TypeView[j]["product_impact"].ToString();

                    if (typeCode != "")
                    {
                        Chart4.Series.Add(typeCode);
                        Chart4.Series[typeCode].Points.AddXY(date_key, Double.NaN);

                    }


                }
            }
        }

        //DataView dv = ds22.Tables[0].DefaultView;

        //dv.RowFilter = "type = '" + onduty_type[0] + "'";

        //dv.Sort = "DATE1 asc";

        //for (int j = 0; j < dv.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[0]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }

        //DataView dv1 = ds22.Tables[0].DefaultView;

        //dv1.RowFilter = "type = '" + onduty_type[1] + "'";

        //dv1.Sort = "DATE1 asc";

        //for (int j = 0; j < dv1.Count; j++)
        //    for (int j = 0; j < arr_shop.Length; j++)
        //    {
        //        string shop_key = "";
        //        shop_key = arr_shop[j];

        //        Chart1.Series[onduty_type[1]].Points.AddXY(dv[j]["date1"], Convert.ToDouble(dv[j]["due_time"]));

        //    }



        string dep_key = "";


    }



    public void BindGridView_person()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;
        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.engineer,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.engineer      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime+1,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer) t2                                                                                              ";


        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView1.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView1.DataBind();
    }

    public void BindGridView_person2()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;

        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.engineer,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.engineer      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.engineer) t2                                                                                              ";





        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView1.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView1.DataBind();
    }

    public void BindGridView_area()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;
        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.FAB,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.FAB      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB) t2                                                                                              ";


        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView2.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView2.DataBind();
    }
    public void BindGridView_area2()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;

        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.FAB,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.FAB      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.FAB) t2                                                                                              ";





        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView2.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView2.DataBind();
    }
    public void BindGridView_system()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;
        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.SYSTEM,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.SYSTEM                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.SYSTEM      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.SYSTEM) t2                                                                                              ";


        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView3.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView3.DataBind();
    }

    public void BindGridView_system2()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;

        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       t.SYSTEM,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), t.SYSTEM                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               t.SYSTEM      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), t.SYSTEM) t2                                                                                              ";





        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView3.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView3.DataBind();
    }

    public void BindGridView_product_impact()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;
        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       trim(t.product_impact) as product_impact,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))             ";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               trim(t.product_impact) as product_impact     ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = ('W'||substr(to_char(sysdate,'yyyy'),3,2)||to_char(sysdate+1,'IW'))    ";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)) t2                                                                                              ";


        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView4.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView4.DataBind();
    }
    public void BindGridView_product_impact2()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2;

        sql_str2 = "";
        sql_str2 = sql_str2 + "select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                               ";
        sql_str2 = sql_str2 + "       trim(t.product_impact) as product_impact ,                                                                                                                                            ";
        sql_str2 = sql_str2 + "       round(sum(t.due_time)/60,2) as due_time                                                                                                                ";
        sql_str2 = sql_str2 + "  from onduty t                                                                                                                                               ";
        sql_str2 = sql_str2 + " where('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) = '" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + " group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)                                                                                                          ";
        sql_str2 = sql_str2 + "union all                                                                                                                                                     ";
        sql_str2 = sql_str2 + "select 'total', '', sum(t2.due_time)                                                                                                                          ";
        sql_str2 = sql_str2 + "  from (select to_char(t.calltime+1, 'yyyy/IW') as date1,                                                                                                       ";
        sql_str2 = sql_str2 + "               trim(t.product_impact) as product_impact      ,                                                                                                                              ";
        sql_str2 = sql_str2 + "               round(sum(t.due_time)/60,2) as due_time                                                                                                        ";
        sql_str2 = sql_str2 + "          from onduty t                                                                                                                                       ";
        sql_str2 = sql_str2 + "         where ('W'||substr(to_char(t.calltime,'yyyy'),3,2)||to_char(t.calltime+1,'IW')) ='" + DropDownList1.Text + "'";
        sql_str2 = sql_str2 + "         group by to_char(t.calltime+1, 'yyyy/IW'), trim(t.product_impact)) t2                                                                                              ";





        DataSet myDataSet2 = new DataSet();
        myDataSet2 = get_dataSet_access(sql_str2);

        GridView4.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView4.DataBind();
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        BindGridView_person2();
        doChart_person2();
        BindGridView_area2();
        doChart_area2();
        BindGridView_system2();
        doChart_system2();
        BindGridView_product_impact2();
        doChart_product_impact2();

    }



   

}

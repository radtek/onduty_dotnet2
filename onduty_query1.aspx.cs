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
using System.Data.OleDb;
using System.Net;
using System.IO;
using System.Net.Sockets;
using System.Text;
using System.Diagnostics;

public partial class onduty_query1 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            //TextBox1.Text = "7";
            //txtCalendar1.Text = DateTime.Now.ToString("yyyy/MM/dd");
            BindGridView();

        }

        BindGridView();
    }


    public void BindGridView()
    {
        string strConn2;

        strConn2 = "Provider=MSDAORA.1;Password=onduty;User ID=onduty;Data Source=PARS1;Persist Security Info=True";
        string sql_str2="";
        if (Request.QueryString["flag"] == "person")
        {

            sql_str2 = "";
            sql_str2 = sql_str2 + "SELECT rownum,                                                               ";
            sql_str2 = sql_str2 + "       SEQ,                                                                  ";
            sql_str2 = sql_str2 + "       to_char(CALLTIME, 'yyyy/mm/dd hh24:mi') as CALLTIME,                  ";
            sql_str2 = sql_str2 + "       FAB,                                                                  ";
            sql_str2 = sql_str2 + "       AREA,                                                                 ";
            sql_str2 = sql_str2 + "       SYSTEM,                                                               ";
            sql_str2 = sql_str2 + "       TYPE,                                                                 ";
            sql_str2 = sql_str2 + "       QUESTION,                                                             ";
            sql_str2 = sql_str2 + "       DESCRIPTION,                                                          ";
            sql_str2 = sql_str2 + "       REASON,                                                               ";
            sql_str2 = sql_str2 + "       METHOD,                                                               ";
            sql_str2 = sql_str2 + "       BYWHOM,                                                               ";
            sql_str2 = sql_str2 + "       CLOSE_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       EQ_ID,                                                                ";
            sql_str2 = sql_str2 + "       CALLER,                                                               ";
            sql_str2 = sql_str2 + "       ARS_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       ALARM_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT,                                                       ";
            sql_str2 = sql_str2 + "       ORG_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT_INFO,                                                  ";
            sql_str2 = sql_str2 + "       DUE_TIME,                                                             ";
            sql_str2 = sql_str2 + "       RECHARGE_FLAG                                                         ";
            sql_str2 = sql_str2 + "  FROM OnDuty                                                                ";
            sql_str2 = sql_str2 + " WHERE INSERT_TIME < sysdate                                                 ";
            sql_str2 = sql_str2 + "   AND to_char(CALLTIME+1, 'yyyy/IW') = '" + Request.QueryString["DATE1"] + "'                              ";
            sql_str2 = sql_str2 + "   and  bywhom= '" + Request.QueryString["engineer"] + "'                                                     ";
            sql_str2 = sql_str2 + " ORDER BY ARS_FLAG DESC, CLOSE_FLAG DESC, ALARM_FLAG DESC, CALLTIME DESC     ";

        }

        if (Request.QueryString["flag"] == "area")
        {

            sql_str2 = "";
            sql_str2 = sql_str2 + "SELECT rownum,                                                               ";
            sql_str2 = sql_str2 + "       SEQ,                                                                  ";
            sql_str2 = sql_str2 + "       to_char(CALLTIME, 'yyyy/mm/dd hh24:mi') as CALLTIME,                  ";
            sql_str2 = sql_str2 + "       FAB,                                                                  ";
            sql_str2 = sql_str2 + "       AREA,                                                                 ";
            sql_str2 = sql_str2 + "       SYSTEM,                                                               ";
            sql_str2 = sql_str2 + "       TYPE,                                                                 ";
            sql_str2 = sql_str2 + "       QUESTION,                                                             ";
            sql_str2 = sql_str2 + "       DESCRIPTION,                                                          ";
            sql_str2 = sql_str2 + "       REASON,                                                               ";
            sql_str2 = sql_str2 + "       METHOD,                                                               ";
            sql_str2 = sql_str2 + "       BYWHOM,                                                               ";
            sql_str2 = sql_str2 + "       CLOSE_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       EQ_ID,                                                                ";
            sql_str2 = sql_str2 + "       CALLER,                                                               ";
            sql_str2 = sql_str2 + "       ARS_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       ALARM_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT,                                                       ";
            sql_str2 = sql_str2 + "       ORG_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT_INFO,                                                  ";
            sql_str2 = sql_str2 + "       DUE_TIME,                                                             ";
            sql_str2 = sql_str2 + "       RECHARGE_FLAG                                                         ";
            sql_str2 = sql_str2 + "  FROM OnDuty                                                                ";
            sql_str2 = sql_str2 + " WHERE INSERT_TIME < sysdate                                                 ";
            sql_str2 = sql_str2 + "   AND to_char(CALLTIME+1, 'yyyy/IW') = '" + Request.QueryString["DATE1"] + "'                              ";
            sql_str2 = sql_str2 + "   and  fab= '" + Request.QueryString["FAB"] + "'                                                     ";
            sql_str2 = sql_str2 + " ORDER BY ARS_FLAG DESC, CLOSE_FLAG DESC, ALARM_FLAG DESC, CALLTIME DESC     ";

        }


        if (Request.QueryString["flag"] == "system")
        {

            sql_str2 = "";
            sql_str2 = sql_str2 + "SELECT rownum,                                                               ";
            sql_str2 = sql_str2 + "       SEQ,                                                                  ";
            sql_str2 = sql_str2 + "       to_char(CALLTIME, 'yyyy/mm/dd hh24:mi') as CALLTIME,                  ";
            sql_str2 = sql_str2 + "       FAB,                                                                  ";
            sql_str2 = sql_str2 + "       AREA,                                                                 ";
            sql_str2 = sql_str2 + "       SYSTEM,                                                               ";
            sql_str2 = sql_str2 + "       TYPE,                                                                 ";
            sql_str2 = sql_str2 + "       QUESTION,                                                             ";
            sql_str2 = sql_str2 + "       DESCRIPTION,                                                          ";
            sql_str2 = sql_str2 + "       REASON,                                                               ";
            sql_str2 = sql_str2 + "       METHOD,                                                               ";
            sql_str2 = sql_str2 + "       BYWHOM,                                                               ";
            sql_str2 = sql_str2 + "       CLOSE_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       EQ_ID,                                                                ";
            sql_str2 = sql_str2 + "       CALLER,                                                               ";
            sql_str2 = sql_str2 + "       ARS_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       ALARM_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT,                                                       ";
            sql_str2 = sql_str2 + "       ORG_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT_INFO,                                                  ";
            sql_str2 = sql_str2 + "       DUE_TIME,                                                             ";
            sql_str2 = sql_str2 + "       RECHARGE_FLAG                                                         ";
            sql_str2 = sql_str2 + "  FROM OnDuty                                                                ";
            sql_str2 = sql_str2 + " WHERE INSERT_TIME < sysdate                                                 ";
            sql_str2 = sql_str2 + "   AND to_char(CALLTIME+1, 'yyyy/IW') = '" + Request.QueryString["DATE1"] + "'                              ";
            sql_str2 = sql_str2 + "   and  system= '" + Request.QueryString["SYSTEM"] + "'                                                     ";
            sql_str2 = sql_str2 + " ORDER BY ARS_FLAG DESC, CLOSE_FLAG DESC, ALARM_FLAG DESC, CALLTIME DESC     ";

        }



        if (Request.QueryString["flag"] == "product_impact")
        {

            sql_str2 = "";
            sql_str2 = sql_str2 + "SELECT rownum,                                                               ";
            sql_str2 = sql_str2 + "       SEQ,                                                                  ";
            sql_str2 = sql_str2 + "       to_char(CALLTIME, 'yyyy/mm/dd hh24:mi') as CALLTIME,                  ";
            sql_str2 = sql_str2 + "       FAB,                                                                  ";
            sql_str2 = sql_str2 + "       AREA,                                                                 ";
            sql_str2 = sql_str2 + "       SYSTEM,                                                               ";
            sql_str2 = sql_str2 + "       TYPE,                                                                 ";
            sql_str2 = sql_str2 + "       QUESTION,                                                             ";
            sql_str2 = sql_str2 + "       DESCRIPTION,                                                          ";
            sql_str2 = sql_str2 + "       REASON,                                                               ";
            sql_str2 = sql_str2 + "       METHOD,                                                               ";
            sql_str2 = sql_str2 + "       BYWHOM,                                                               ";
            sql_str2 = sql_str2 + "       CLOSE_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       EQ_ID,                                                                ";
            sql_str2 = sql_str2 + "       CALLER,                                                               ";
            sql_str2 = sql_str2 + "       ARS_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       ALARM_FLAG,                                                           ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT,                                                       ";
            sql_str2 = sql_str2 + "       ORG_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT_INFO,                                                  ";
            sql_str2 = sql_str2 + "       DUE_TIME,                                                             ";
            sql_str2 = sql_str2 + "       RECHARGE_FLAG                                                         ";
            sql_str2 = sql_str2 + "  FROM OnDuty                                                                ";
            sql_str2 = sql_str2 + " WHERE INSERT_TIME < sysdate                                                 ";
            sql_str2 = sql_str2 + "   AND to_char(CALLTIME+1, 'yyyy/IW') = '" + Request.QueryString["DATE1"] + "'                              ";
            sql_str2 = sql_str2 + "   and  trim(product_impact)= '" + Request.QueryString["product_impact"] + "'                                                     ";
            sql_str2 = sql_str2 + " ORDER BY ARS_FLAG DESC, CLOSE_FLAG DESC, ALARM_FLAG DESC, CALLTIME DESC     ";

        }



        if (Request.QueryString["flag"] == "type")
        
        {

            sql_str2 = "";
            sql_str2 = sql_str2 + "SELECT rownum,SEQ,                                                             ";
            sql_str2 = sql_str2 + "       to_char(CALLTIME, 'yyyy/mm/dd hh24:mi') as CALLTIME,                    ";
            sql_str2 = sql_str2 + "       FAB,                                                                    ";
            sql_str2 = sql_str2 + "       AREA,                                                                   ";
            sql_str2 = sql_str2 + "       SYSTEM,                                                                 ";
            sql_str2 = sql_str2 + "       TYPE,                                                                   ";
            sql_str2 = sql_str2 + "       QUESTION,                                                               ";
            sql_str2 = sql_str2 + "       DESCRIPTION,                                                            ";
            sql_str2 = sql_str2 + "       REASON,                                                                 ";
            sql_str2 = sql_str2 + "       METHOD,                                                                 ";
            sql_str2 = sql_str2 + "       BYWHOM,                                                                 ";
            sql_str2 = sql_str2 + "       CLOSE_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       EQ_ID,                                                                  ";
            sql_str2 = sql_str2 + "       CALLER,                                                                 ";
            sql_str2 = sql_str2 + "       ARS_FLAG,                                                               ";
            sql_str2 = sql_str2 + "       ALARM_FLAG,                                                             ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT,                                                         ";
            sql_str2 = sql_str2 + "       ORG_FLAG,                                                               ";
            sql_str2 = sql_str2 + "       PRODUCT_IMPACT_INFO,                                                    ";
            sql_str2 = sql_str2 + "       DUE_TIME,                                                               ";
            sql_str2 = sql_str2 + "       RECHARGE_FLAG                                                           ";
            sql_str2 = sql_str2 + "  FROM OnDuty                                                                  ";
            sql_str2 = sql_str2 + " WHERE INSERT_TIME < sysdate                                                          ";
            //sql_str2 = sql_str2 + "   AND to_char(CALLTIME, 'yyyy/mm/dd') = '2009/09/16'                          ";
            sql_str2 = sql_str2 + "   AND to_char(CALLTIME, 'yyyy/mm/dd') = '" + Request.QueryString["DATE1"] + "'                          ";
            //sql_str2 = sql_str2 + "   and type='設備'                                                          ";
            sql_str2 = sql_str2 + "   and type='" + Request.QueryString["type"] + "'                                                          ";
            sql_str2 = sql_str2 + " ORDER BY ARS_FLAG DESC, CLOSE_FLAG DESC, ALARM_FLAG DESC, CALLTIME DESC       ";
        
        }
       
        

        //Response.Write(sql_str2);
        OleDbDataAdapter oda3 = new OleDbDataAdapter(sql_str2, strConn2);

        DataSet myDataSet2 = new DataSet();
        oda3.Fill(myDataSet2, "AccessInfo");

        GridView1.DataSource = myDataSet2.Tables["AccessInfo"];
        GridView1.DataBind();
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

    protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
    {
        GridView1.PageIndex = e.NewPageIndex;
        //gvNewsList.PageIndex = e.NewPageIndex;
        BindGridView();


    }


}

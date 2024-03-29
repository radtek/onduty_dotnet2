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

public partial class MasterPage : System.Web.UI.MasterPage
{

    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    string today = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd");

    string today_minus17 = DateTime.Now.AddDays(-17).ToString("yyyy/MM/dd");

    string today_detail = DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd HH:mm");
    string sql_temp = "";
    string sql_temp1 = "";
    DataSet ds_temp = new DataSet();
    DataSet ds_temp1 = new DataSet(); 


    protected void Page_Load(object sender, EventArgs e)
    {

        //*****取得Tree物件***** 
        //利用Session 當Tree已經建立過，不重新建立，直接從Session中取得，加快速度 
        if (Session["Tree1"] == null)
        {
            //Tree不曾建立過→呼叫建立TreeView程序 
            InitTree(); //初始化Tree 
            BuildTree(); //建立Tree內容 
        }

        //宣告Tree物件 
        TreeView Tree1 = new TreeView();

        //從Session中取得Tree物件 
        Tree1 = (TreeView)Session["Tree1"];

        //設定Tree的ImageSet 
        Tree1.ImageSet = TreeViewImageSet.XPFileExplorer;

        //置放於PlaceHolder 
        this.PlaceHolder1.Controls.Add(Tree1);

    }

    public void InitTree()
    {
        //********初始化Tree******** 
        //定義TreeView物件並實體化 
        TreeView Tree1 = new TreeView();

        //定義一個TreeNode並實體化 
        TreeNode tmpNote = new TreeNode();

        //設定【根目錄】相關屬性內容 
        tmpNote.Text = "首頁";
        tmpNote.Value = "0";
        tmpNote.NavigateUrl = "top.aspx";
        tmpNote.Target = "_Top";

        //Tree建立該Node 
        Tree1.Nodes.Add(tmpNote);

        //將Tree存放入Session中 
        Session["Tree1"] = Tree1;
    }


    public DataSet Bind_data(string sqlX, string connx)
    {
        sql_temp = sqlX;




        ds_temp = func.get_dataSet_access(sql_temp, connx);


        Session["Dt"] = ds_temp.Tables[0];

     
       return ds_temp;

    } 


    public void BuildTree()
    {
        //********建立樹狀結構******** 
        //宣告TreeView 
        TreeView Tree1 = new TreeView();

        //如果Session中沒有Tree,初始化Tree 
        if (Session["Tree1"] == null)
        {
            InitTree();
        }

        Tree1 = (TreeView)Session["Tree1"];

        //取得根目錄節點 
        TreeNode RootNode = new TreeNode();
        RootNode = Tree1.Nodes[0];
        string rc;

        //呼叫建立子節點的函數 
        rc = AddNodes(RootNode, 0);
        Session["Tree1"] = Tree1;

    }

    public string AddNodes(TreeNode tNode, int PId)
    {

        try
        {
            //如果Session中沒有DataTable→取得DataTable 
            if (Session["dt"] == null)
            {
                //讀取 table 資料 

                sql_temp = "SELECT t.* FROM onduty_menu t  order by  t.noteid  ";

                Bind_data(sql_temp,conn);
                //GetDataTable();
            }
            //定義DataTable 
            DataTable Dt = new DataTable();
            //DataTable DtOne = new DataTable(); 
            //從Session中取得DataTable 
            Dt = (DataTable)Session["Dt"];


            //定義DataRow承接DataTable篩選的結果 
            DataRow[] rows;

            //定義篩選的條件 
            string filterExpr = "ParentId = " + PId;

            //資料篩選並把結果傳入Rows 
            rows = Dt.Select(filterExpr);

            int _Ippp = rows.GetUpperBound(0);

            //如果篩選結果有資料 
            if (rows.GetUpperBound(0) >= 0)
            {
                long tmpNodeId;
                string tmpsText, tmpsValue, tmpsUrl, tmpsTarget, rc;

                //逐筆取出篩選後資料 
                foreach (DataRow row in rows)
                {
                    //放入相關變數中 
                    tmpNodeId = Convert.ToInt64(row[0]);
                    tmpsText = row[2].ToString();
                    tmpsValue = row[3].ToString();
                    tmpsUrl = row[4].ToString();
                    tmpsTarget = row[5].ToString();
                    //實體化新節點 
                    TreeNode NewNode = new TreeNode();
                    //設定節點各屬性 
                    NewNode.Text = tmpsText;
                    NewNode.Value = tmpsValue;
                    NewNode.NavigateUrl = tmpsUrl;
                    NewNode.Target = tmpsTarget;
                    //將節點加入Tree中 
                    tNode.ChildNodes.Add(NewNode); //tNode 為根目錄節點 

                    //呼叫遞回取得子節點 
                    rc = AddNodes(NewNode, Convert.ToInt32(tmpNodeId));
                }
            }

            //傳回成功訊息 
            return "Success";
        }
        catch (Exception ex)
        {
           // lblMessage.Text = ex.Message;
            return "False";
        }

    }


    public string AddNodes1(TreeNode tNode, int PId)
    {

        try
        {
            //如果Session中沒有DataTable→取得DataTable 
            if (Session["dt"] == null)
            {
                //讀取 table 資料 

                sql_temp = "SELECT * FROM onduty_menu";

                Bind_data(sql_temp, conn);
                //GetDataTable();
            }
            //定義DataTable 
            DataTable Dt = new DataTable();
            //DataTable DtOne = new DataTable(); 
            //從Session中取得DataTable 
            Dt = (DataTable)Session["Dt"];

            DataView dv = Dt.DefaultView;

            dv.RowFilter = "ParentId = " + PId;


            //定義DataRow承接DataTable篩選的結果 
            //DataRow[] rows;

            //定義篩選的條件 
            //string filterExpr = "ParentId = " + PId;

            //資料篩選並把結果傳入Rows 
            //rows = Dt.Select(filterExpr);

            //int _Ippp = rows.GetUpperBound(0);

            //如果篩選結果有資料 
            if (dv.Count>=0)
            {
                long tmpNodeId;
                string tmpsText, tmpsValue, tmpsUrl, tmpsTarget, rc;

                //逐筆取出篩選後資料 

                for (int i = 0; i <= dv.Count-1; i++)
                {
                    tmpNodeId = Convert.ToInt64(dv[i][0]);
                    tmpsText = dv[i][2].ToString();
                    tmpsValue = dv[i][3].ToString();
                    tmpsUrl = dv[i][4].ToString();
                    tmpsTarget = dv[i][5].ToString();
                    //實體化新節點 
                    TreeNode NewNode = new TreeNode();
                    //設定節點各屬性 
                    NewNode.Text = tmpsText;
                    NewNode.Value = tmpsValue;
                    NewNode.NavigateUrl = tmpsUrl;
                    NewNode.Target = tmpsTarget;
                    //將節點加入Tree中 
                    tNode.ChildNodes.Add(NewNode); //tNode 為根目錄節點 

                    //呼叫遞回取得子節點 
                    rc = AddNodes(NewNode, Convert.ToInt32(tmpNodeId));


                }
                //foreach (DataRow row in rows)
                //{
                //    //放入相關變數中 
                //    tmpNodeId = Convert.ToInt64(row[0]);
                //    tmpsText = row[2].ToString();
                //    tmpsValue = row[3].ToString();
                //    tmpsUrl = row[4].ToString();
                //    tmpsTarget = row[5].ToString();
                //    //實體化新節點 
                //    TreeNode NewNode = new TreeNode();
                //    //設定節點各屬性 
                //    NewNode.Text = tmpsText;
                //    NewNode.Value = tmpsValue;
                //    NewNode.NavigateUrl = tmpsUrl;
                //    NewNode.Target = tmpsTarget;
                //    //將節點加入Tree中 
                //    tNode.ChildNodes.Add(NewNode); //tNode 為根目錄節點 

                //    //呼叫遞回取得子節點 
                //    rc = AddNodes(NewNode, Convert.ToInt32(tmpNodeId));
                //}
            }

            //傳回成功訊息 
            return "Success";
        }
        catch (Exception ex)
        {
            // lblMessage.Text = ex.Message;
            return "False";
        }

    }

    //讀取 table 資料 
    //private void GetDataTable()
    //{
    //    //取得DataTable 
    //    //宣告相關變數 
    //    string ConnStr, SqlTxt;
    //    SqlConnection Conn;
    //    SqlDataAdapter Da;
    //    DataSet Ds;
    //    DataTable dt;
    //    try
    //    {
    //        //設定連接字串，請修改符合您的資料來源的ConnectionString 
    //        ConnStr = "Data Source=127.0.0.1;Persist Security Info=True;User ID=sa;Password=*($!**)@GLORY;Initial Catalog=HuskyDB";
    //        //建立Connection 
    //        Conn = new SqlConnection(ConnStr);
    //        Conn.Open();
    //        //設定資料來源T-SQL 
    //        SqlTxt = "SELECT * FROM TestThree";//請修改您的資料表名稱 
    //        //實體化DataAdapter並且取得資料 
    //        Da = new SqlDataAdapter(SqlTxt, Conn);
    //        //實體化DataSet 
    //        Ds = new DataSet();
    //        //資料填入DataSet 
    //        Da.Fill(Ds);
    //        //設定DataTable 
    //        dt = new DataTable();
    //        dt = Ds.Tables[0];
    //        //將DataTable放入Session中 
    //        Session["Dt"] = dt;
    //        //關閉連線 
    //        Conn.Close();
    //    }
    //    catch (Exception ex)
    //    {
    //        lblMessage.Text = ex.Message;
    //    }

    //    //資源回收 
    //    Da = null;

    //}

}

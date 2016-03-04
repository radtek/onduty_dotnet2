using System;
using System.Data;
using System.Configuration;
using System.Collections;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Data.OleDb;
using System.Drawing;
using System.Net.Mail;
using System.Net;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Text;

public partial class board_add : System.Web.UI.Page
{
    string conn = System.Configuration.ConfigurationSettings.AppSettings["DBCONN_OARPT_PARS1"];
    DataSet ds_temp = new DataSet();
    string sql_str = "";
    ArrayList arlist_temp1 = new ArrayList();
    ArrayList arlist_temp2 = new ArrayList();

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {

            #region Area

            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\dep.txt");

            DropDownList1.DataSource = arlist_temp1;
            DropDownList1.DataBind();




            #endregion




            #region start_time

            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\hour.txt");

            //DropDownList5.DataSource = arlist_temp1;
            //DropDownList5.DataBind();

            //DropDownList5.Text = DateTime.Now.ToString("HH");


            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\min.txt");

            //DropDownList8.DataSource = arlist_temp1;
            //DropDownList8.DataBind();

            //DropDownList8.Text = DateTime.Now.ToString("mm");

            txtEstimateStartDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(+0).ToString("yyyy/MM/dd"));

            #endregion



            #region end_time

            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\hour.txt");

            //DropDownList15.DataSource = arlist_temp1;
            //DropDownList15.DataBind();

            //DropDownList15.Text = DateTime.Now.ToString("HH");


            arlist_temp1 = func.FileToArray(Server.MapPath(".") + "\\config\\min.txt");

            //DropDownList18.DataSource = arlist_temp1;
            //DropDownList18.DataBind();

            //DropDownList18.Text = DateTime.Now.ToString("mm");

            txtEstimateEndDate.SelectedDate = Convert.ToDateTime(DateTime.Now.AddDays(+30).ToString("yyyy/MM/dd"));
            #endregion





        }


    }
    protected void ButtonAdd_Click(object sender, EventArgs e)
    {


        for (int i = 1; i <= Request.Files.Count; i++)
        {
            FileUpload myFL = new FileUpload();
            ContentPlaceHolder c = (ContentPlaceHolder)Master.FindControl("ContentPlaceHolder1");
            myFL = (FileUpload)c.FindControl("FileUpload" + i); 
            //myFL = (FileUpload)Page.FindControl("FileUpload" + i);
            if (myFL.PostedFile.ContentLength < 15360000)
            //if (myFL.PostedFile.ContentLength < 30720000)
            {

                if ((myFL.PostedFile != null) && (myFL.PostedFile.ContentLength > 0))
                {

                    string fn = System.IO.Path.GetFileName(myFL.PostedFile.FileName);
                    // string SaveLocation = Server.MapPath("../") + "\\upload_file\\" + fn;
                    string SaveLocation = Server.MapPath("FileList/") + fn;

                    Session["file_path"] = "FileList/" + fn;
                    int file_size = myFL.PostedFile.ContentLength;
                    string file_type = myFL.PostedFile.ContentType;
                    try
                    {
                        myFL.PostedFile.SaveAs(SaveLocation);

                        //OleDbConnection myConnection = new OleDbConnection(ConfigurationSettings.AppSettings["dsnn"]);

                        //string strClientIP;

                        string strClientIP = Request.ServerVariables["remote_host"].ToString();

                        string sql_insert = " insert into board                                                                                                    " +
"   (fab, publisher, subject, begin_time, end_time, content, update_time, file_name, org_file_name)                    " +
" values                                                                                                               " +
"   ('" + DropDownList1.SelectedValue + "', '" + TextBox_publish.Text + "', '" + TextBox_subject.Text + "',  to_date('" + txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "','YYYY/MM/DD')" + ",to_date('" + txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "','YYYY/MM/DD')" + ",'" + TextBox_content.Text + "', sysdate, '" + Session["file_path"].ToString() + "', '" + fn.ToString() + "')  ";
                        func.get_sql_execute(sql_insert, conn);


                        //myLabel.Append("<hr>檔名---- " + fn);

                        Label2.Text = "上傳成功";

                        if (CheckBox1.Checked && CheckBox2.Checked)
                        {
                            call_mail("T1+T2");

                        }
                        else
                        {
                            if (CheckBox1.Checked)
                            {
                                call_mail("T1");


                            }

                            if (CheckBox2.Checked)
                            {
                                call_mail("T2");


                            }


                        }

                        Response.Write("<script language='javascript' type='text/JavaScript'>\n");
                        Response.Write("alert('新增成功!!');\n");
                        Response.Write("location = 'top.aspx';\n");
                        //Response.Write("window.opener.location = window.opener.location;\n");
                        //Response.Write("opener.document.location.reload();\n");
                        Response.Write("window.opener=null; window.close();\n");
                        Response.Write("</script>");

                    }
                    catch (Exception Ex)
                    {
                        Response.Write("上傳檔案失敗");
                    }
                }
                else
                {
                    string sql_insert1 = " insert into board                                                                                                    " +
 "   (fab, publisher, subject, begin_time, end_time, content, update_time, file_name, org_file_name)                    " +
 " values                                                                                                               " +
 "   ('" + DropDownList1.SelectedValue + "', '" + TextBox_publish.Text + "', '" + TextBox_subject.Text + "',  to_date('" + txtEstimateStartDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "','YYYY/MM/DD')" + ",to_date('" + txtEstimateEndDate.SelectedDate.Value.ToString("yyyy/MM/dd") + "','YYYY/MM/DD')" + ",'" + TextBox_content.Text + "', sysdate, '', '')  ";
                    func.get_sql_execute(sql_insert1, conn);


                    //myLabel.Append("<hr>瑼?--- " + fn);

                    //Label2.Text = "銝撜緪";

                    if (CheckBox1.Checked && CheckBox2.Checked)
                    {
                        call_mail("T1+T2");

                    }
                    else
                    {
                        if (CheckBox1.Checked)
                        {
                            call_mail("T1");


                        }

                        if (CheckBox2.Checked)
                        {
                            call_mail("T2");


                        }
                        
                    
                    }

                    Response.Write("<script language='javascript' type='text/JavaScript'>\n");
                    Response.Write("alert('新增成功!!');\n");
                    Response.Write("location = 'top.aspx';\n");
                    //Response.Write("window.opener.location = window.opener.location;\n");
                    //Response.Write("opener.document.location.reload();\n");
                    Response.Write("window.opener=null; window.close();\n");
                    Response.Write("</script>");


                }
            }

            else
            {
                Label3.Visible = true;
                Label3.Text = "上傳檔案超過15MB...";

            }








        }



    }



    public void call_mail(string area)
    {


        WebClient w = new WebClient();
        w.Encoding = Encoding.GetEncoding("Big5");
        string strHTML = w.DownloadString("http://t1cimweb01/onduty_dotnet/board_record.aspx");
        ArrayList maillist = new ArrayList();

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
        //ds_temp = func.get_dataSet_access(sql, conn);


        string title = "值班記錄公佈欄有新公告-> " + DateTime.Now.ToString("yyyy/MM/dd") + "【 " + TextBox_subject.Text + "  】";
        if (area == "T1")
        {
           maillist = func.FileToArray(Server.MapPath(".") + "\\maillist\\onduty1.txt");
        
        }

        if (area == "T2")
        {
           maillist = func.FileToArray(Server.MapPath(".") + "\\maillist\\onduty2.txt");

        }

        if (area == "T1+T2")
        {
            maillist = func.FileToArray(Server.MapPath(".") + "\\maillist\\onduty12.txt");

        }

        
        //ArrayList maillist = func.FileToArray(Server.MapPath(".") + "\\maillist\\onduty.txt");
        string receive = maillist[0].ToString();
        //receive = "oscar.hsieh@chimei-innolux.com";
        SendEmail("cim.alarm@innolux.com", receive, title, strHTML, "");// 
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


}

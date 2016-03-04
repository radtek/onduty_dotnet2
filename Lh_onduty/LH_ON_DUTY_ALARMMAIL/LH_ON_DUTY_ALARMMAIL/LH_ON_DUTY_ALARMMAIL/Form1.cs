using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Web.Mail;
using System.Web.UI;
using System.Data.OleDb;
using System.Data.SqlClient;
//using System.Web;


namespace LH_ON_DUTY_ALARMMAIL
{
    public partial class Form1 : Form
    {
        //string err_msg = "";

        public Form1()
        {
            InitializeComponent();
        }

        static void Main()
        {

            string sql_stm = "";
            //DataSet ds = new DataSet();
            DataTable dt = new DataTable();
            string email_list = "";
            string Mail_To = "";
            string Mail_Cc = "";
            string Mail_Body = "";
            string subjectDate = "";
            string dates = "", deptcode = "";
            string years = "",months="", weeks = "";
            

            StringWriter sw = new StringWriter();


            string connect_string = "Provider=MSDAORA.1;Password=stdman;User ID=stdman;Data Source=PRPT1.INNOLUX.COM.TW;Persist Security Info=True";

          //  MSG_LABEL = "KK";

            //StringWriter sw = new StringWriter();
            //HtmlTextWriter htw = new HtmlTextWriter(sw);
            //Server.Execute("task_assign_mail.aspx?task_id=" + task_no, htw);

            //strMailTo = rbOwner.SelectedValue + "@innolux.com.tw";
            //strMailSubject = "[Task Management System]Task Id " + task_no + " : " + rbOwner.SelectedItem.Text + " �z�Q�����@�ӷs�u�@";
            //strMailBody = sw.ToString();

            //send_mail("test", "pinchen.chen@innolux.com.tw", "test");

            //MSG_LABEL.Text = "send mail to you";


            sql_stm = "select t.useremail from lh_onduty_alarmmail t WHERE T.ENABLE_FLAG = 'Y' and t.receivetype = 'TO'";

            dt = GetDataTable(sql_stm, connect_string);
            
            for (int i = 0; i < dt.Rows.Count; i++)
                email_list += dt.Rows[i][0].ToString()+",";

            Mail_To = email_list;
            Mail_To = "oscar.hsieh@chimei-innolux.com";
            email_list = "";

            sql_stm = "select t.useremail from lh_onduty_alarmmail t WHERE T.ENABLE_FLAG = 'Y' and t.receivetype = 'CC'";

            dt = GetDataTable(sql_stm, connect_string);

            for (int i = 0; i < dt.Rows.Count; i++)
                email_list += dt.Rows[i][0].ToString() + ",";

            Mail_Cc = email_list;
            Mail_Cc = "oscar.hsieh@chimei-innolux.com";

            //connect_string = "Provider=SQLOLEDB.1;Password=BUuser123;Persist Security Info=True;User ID=BUuser;Initial Catalog=HRBI;Data Source=10.133.225.34";

            connect_string = "Data Source=INLLHHRMDB01;Initial Catalog=HRBI;User Id=BUuser;Password=BUuser123";


            sql_stm = " SELECT         ot1.date, ot2.BUname, ot2.DIVname, ot2.name, ot2.deptcode, SUM(1) AS counts " +
          " FROM             (SELECT DISTINCT CONVERT(varchar(12), t1e, 112) AS date, empno, name, t1s, t1e, " +
          "                                                       days_workcontinue, deptcode " +
          "                            FROM              dbo.View_WorkHourByCard " +
          "                            WHERE          (days_workcontinue > 6) AND (CONVERT(varchar(12), t1e, 112)  " +
          "                                                       = CONVERT(varchar(12), DATEADD(day, - 2, GETDATE()), 112)))  " +
          "                           AS ot1 INNER JOIN " +
          "                               (SELECT         TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode, name " +
          "                                 FROM              dbo.View_corporganization " +
          "                                 WHERE          (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')))  " +
          "                           AS ot2 ON ot1.deptcode = ot2.deptcode " +
          " GROUP BY  ot1.date, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name , ot2.deptcode " +
          " ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";
           
            //sql_stm =  "SELECT  BUname, DIVcode, DIVname, deptcode, name FROM dbo.View_corporganization WHERE (DIVcode IN ('8N110000'))";

            dt = GetDataTable2(sql_stm, connect_string);

            if (1==1)
            {

                Mail_Body = "<html><body>";
                Mail_Body += "  <table border=0>";

                Mail_Body += "    <tr>&nbsp;Dear SIRs ...&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�s�إX�ԹH�Wĵ�ܳq�i , �@�p�����T���� , ���ؤ��O�p�U :&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�@. ������@�H�W�ƥ�έp.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(�s��u�@�W�L����)&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�G. �g�u�ɹH�W�ƥ�έp.&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;(�g�u�ɶW�L63�p��)&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�T. ��[�Z�u�ɹH�W�ƥ�έp.&nbsp;(��[�Z�u�ɶW�L91�p��)&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;&nbsp;&nbsp;&nbsp;�U���عH�W�ƥ�έp�аѾ\�p�U�T�� , �U���Ʀr�W�����W�s�� , �i���Ѹ�Ƭd�� , �H�Q�Ӯװl�� .&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;</tr>";
                Mail_Body += "    <tr>&nbsp;&nbsp;</tr>";
 
                Mail_Body += "    <tr>&nbsp;�@.�s�إX�ԹH�Wĵ�ܳq�i:������@�H�W�ƥ�έp&nbsp;</tr>";
                Mail_Body += "    <tr><td>";
                Mail_Body += "      <table align=left border=1 cellpadding=0 cellspacing=0 width=800px bordercolor=#C2DE81>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (i == 0)
                    {
                        Mail_Body += "<tr style='background-color:#FF8000;'>";
                        Mail_Body += "<td>&nbsp;���&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;BU�W��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�B�O�W��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�����W��&nbsp;</td>";
                        //Mail_Body += "<td>&nbsp;�����N��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�s��u�@6�ѥH�W�H��&nbsp;</td>";
                        Mail_Body += "</tr>";
                    }
                    Mail_Body += "<tr style='background-color:#FFFF80;'>";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0) // ���
                        {
                            Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                            subjectDate = dt.Rows[i][j].ToString();
                            dates = dt.Rows[i][j].ToString();

                        }
                        else if (j == 4) // �����N�� �����
                        {
                            //Mail_Body += "<td style='text-align:center;' >&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                            deptcode = dt.Rows[i][j].ToString();


                        }
                        else if (j == 5) // �s��u�@6�ѥH�W�H��
                        {
                            Mail_Body += "<td style='text-align:center;' ><a href='http://t1cimweb01/Onduty_dotnet/LH_ON_DUTY_ALARMMAIL_WEB/LHAlarmQueryC1.aspx?dates=" + dates + "&deptcode=" + deptcode + "' target='_blank'>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</a></td>";

                        }
                        else
                        {
                            Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                        }

                    }
                    Mail_Body += "</tr>";
                }


                Mail_Body += "      </table>";
                Mail_Body += "    </td></tr>";

                Mail_Body += "    <tr><td><br>** ����::������H���U�Z���,�N�Y�󦹤���U�Z�H���w�F�H�W���H��.";
                Mail_Body += "    </td></tr>";

                Mail_Body += "    <tr><td><br><br></td></tr>";



                sql_stm = " SELECT ot1.YESRS, ot1.WEEKS, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name,ot2.deptcode, SUM(1) AS OT_counts " +
                          " FROM (SELECT YESRS, WEEKS, empno, name, deptcode, OverTimesByWeek " +
                          "       FROM (SELECT DATEPART(year, t1e) AS YESRS, DATEPART(WEEK,t1e) AS WEEKS, empno, name, deptcode,  " +
                          "                    SUM(work_hours) AS OverTimesByWeek " +
                          "             FROM (SELECT DISTINCT  empno, name, deptcode, t1s, t1e,  work_hours " +
                          "                   FROM dbo.View_WorkHourByCard " +
                          "                   WHERE (work_hours > 0)  " +
                          "             ) AS derivedtbl_2 " +
                          "       GROUP BY DATEPART(year, t1e), DATEPART(WEEK, t1e), empno,  name, deptcode ) AS derivedtbl_1 " +
                          " WHERE (OverTimesByWeek > 63) AND (WEEKS = DATEPART(WEEK,  DATEADD(day, - 7, GETDATE())))) AS ot1 INNER JOIN " +
                          " (SELECT TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode,  name " +
                          "  FROM dbo.View_corporganization " +
                          "  WHERE (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000'))  " +
                          " ) AS ot2 ON ot1.deptcode = ot2.deptcode " +
                          "GROUP BY ot1.YESRS, ot1.WEEKS, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name ,ot2.deptcode " +
                          "ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";

                dt = GetDataTable2(sql_stm, connect_string);

                Mail_Body += "    <tr>&nbsp;�G.�s�إX�ԹH�Wĵ�ܳq�i:�g�u�ɹH�W�ƥ�έp(�g�u�ɶW�L63�p��)&nbsp;</tr>";
                Mail_Body += "    <tr><td>";
                Mail_Body += "      <table align=left border=1 cellpadding=0 cellspacing=0 width=800px bordercolor=#C2DE81>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (i == 0)
                    {
                        Mail_Body += "<tr style='background-color:#FF8000;'>";
                        Mail_Body += "<td>&nbsp;�~�O&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�g�O&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;BU�W��&nbsp;</td>";
                        //Mail_Body += "<td>&nbsp;Divcode&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�B�O�W��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�����W��&nbsp;</td>";
                        //Mail_Body += "<td>&nbsp;�����N��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�g�u�ɶW�L63�p�ɤH��&nbsp;</td>";
                        Mail_Body += "</tr>";
                    }
                    Mail_Body += "<tr style='background-color:#FFFF80;'>";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0)
                            years = dt.Rows[i][j].ToString();
                        if (j == 1)
                            weeks = dt.Rows[i][j].ToString();
                        if (j == 6)
                            deptcode = dt.Rows[i][j].ToString();


                        if (j == 3 || j == 6) // Divcode �P �����N�� �����
                        {
                            Mail_Body += "";
                        }
                        else if (j == 7) // �g�[�Z�u�ɶW�L20�p�ɤH��
                        {
                            Mail_Body += "<td style='text-align:center;' ><a href='http://t1cimweb01/Onduty_dotnet/LH_ON_DUTY_ALARMMAIL_WEB/LHAlarmQueryC2.aspx?years=" + years + "&weeks=" + weeks + "&deptcode=" + deptcode + "' target='_blank'>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</a></td>";
                        }
                        else
                        {
                            Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                        }

                    }
                    Mail_Body += "</tr>";
                }


                Mail_Body += "      </table>";
                Mail_Body += "    </td></tr>";

                Mail_Body += "    <tr><td><br>** ����::�g�O����ƾ�W���g��,����������g��(00:00:01)�ܶg��(23:59:59),�H���U�Z�ɶ��󵲺�������Y�ǤJ�p��.";
                Mail_Body += "    </td></tr>";


                Mail_Body += "    <tr><td><br><br></td></tr>";

                sql_stm = " SELECT ot1.YESRS, ot1.MONTHS, ot1.SumDate, ot2.BUname, ot2.DIVcode, " +
                          "        ot2.DIVname, ot2.name,ot2.deptcode, SUM(1) AS OT_counts " +
                          " FROM ( SELECT YESRS, MONTHS, empno, name, deptcode, OverTimesByMonth, " +
                          "               CONVERT(varchar(12), DATEADD(day, - 2, GETDATE()), 112) AS SumDate " +
                          "        FROM ( SELECT DATEPART(year, t1e) AS YESRS, DATEPART(MONTH, t1e) AS MONTHS, " +
                          "                      empno, name, deptcode, SUM(OT_fromcard) AS OverTimesByMonth " +
                          "               FROM ( SELECT DISTINCT empno, name, deptcode, t1s, t1e, OT_fromcard " +
                          "                      FROM dbo.View_WorkHourByCard " +
                          "                      WHERE  (OT_fromcard > 0) " +
                          "                     ) AS derivedtbl_2 " +
                          "               GROUP BY DATEPART(year, t1e), DATEPART(MONTH, t1e), empno, name, deptcode " +
                          "             ) AS derivedtbl_1 " +
                          "        WHERE (OverTimesByMonth > 91 ) AND (MONTHS = DATEPART(MONTH, DATEADD(day, - 2, GETDATE()))) " +
                          "      ) AS ot1 INNER JOIN " +
                          "      ( SELECT TOP 100 PERCENT BUname, DIVcode, DIVname, deptcode, name " +
                          "        FROM dbo.View_corporganization " +
                          "        WHERE (DIVcode IN ('8N110000', '8N230000', '8CCL0000', '8N410000')) " +
                          "      ) AS ot2 ON ot1.deptcode = ot2.deptcode " +
                          " GROUP BY ot1.YESRS, ot1.MONTHS, ot1.SumDate, ot2.BUname, ot2.DIVcode, ot2.DIVname, ot2.name,ot2.deptcode" +
                          " ORDER BY  ot2.DIVcode, ot2.DIVname, ot2.name ";

                dt = GetDataTable2(sql_stm, connect_string);

                Mail_Body += "    <tr>&nbsp;�T.�s�إX�ԹH�Wĵ�ܳq�i:��[�Z�u�ɹH�W�ƥ�έp(��[�Z�u�ɶW�L91�p��)&nbsp;</tr>";
                Mail_Body += "    <tr><td>";
                Mail_Body += "      <table align=left border=1 cellpadding=0 cellspacing=0 width=800px bordercolor=#C2DE81>";

                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    if (i == 0)
                    {
                        Mail_Body += "<tr style='background-color:#FF8000;'>";
                        Mail_Body += "<td>&nbsp;�~�O&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;��O&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;������&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;BU�W��&nbsp;</td>";
                        //Mail_Body += "<td>&nbsp;Divcode&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�B�O�W��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;�����W��&nbsp;</td>";
                        //Mail_Body += "<td>&nbsp;�����N��&nbsp;</td>";
                        Mail_Body += "<td>&nbsp;��[�Z�u�ɶW�L91�p�ɤH��&nbsp;</td>";
                        Mail_Body += "</tr>";
                    }
                    Mail_Body += "<tr style='background-color:#FFFF80;'>";
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        if (j == 0)
                            years = dt.Rows[i][j].ToString();
                        if (j == 1)
                            months = dt.Rows[i][j].ToString();
                        if (j == 7)
                            deptcode = dt.Rows[i][j].ToString();


                        if (j == 3 || j == 7) // Divcode �P �����N�� �����
                        {
                            Mail_Body += "";

                        }
                        else if (j == 8) // ��[�Z�u�ɶW�L91�p�ɤH��
                        {
                            Mail_Body += "<td style='text-align:center;' ><a href='http://t1cimweb01/Onduty_dotnet/LH_ON_DUTY_ALARMMAIL_WEB/LHAlarmQueryC3.aspx?years=" + years + "&months=" + months + "&deptcode=" + deptcode + "' target='_blank'>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</a></td>";
                        }
                        else
                        {
                            Mail_Body += "<td>&nbsp;" + dt.Rows[i][j].ToString() + "&nbsp;</td>";
                        }

                    }
                    Mail_Body += "</tr>";
                }


                Mail_Body += "      </table>";
                Mail_Body += "    </td></tr>";

                Mail_Body += "    <tr><td><br>** ����::�֭p���ܵ�����(23:59:59)���[�Z�u��.";
                Mail_Body += "    </td></tr>";
                
                Mail_Body += "    <tr><td><br><br>����CIM �q�l���t�Φ۰ʱH�o���H�� , �p�ݪA�� , �Ь� �˫n CIM ���t�F(513-64175) . ";
                Mail_Body += "    </td></tr>";
                Mail_Body += "    <tr><td><br><br>Best Regards.-<br>CIM ALARM SYSTEM.-";
                Mail_Body += "    </td></tr>";

                
                
                Mail_Body += "  </table></body></html>";

                send_mail(Mail_Body, Mail_To, Mail_Cc, "[CIM �q�l���t��] " + subjectDate + "�s�إX�ԹH�Wĵ�ܳq�i");

            }

            else
            {
                //Mail_Body = err_msg;
                send_mail("�t�β��` , �гB�z .. ", "pinchen.chen@chimei-innolux.com", "", "[�t�β��`] " + subjectDate + "�s�إX�ԹH�Wĵ�ܳq�i");
            }


            


            
            //send_mail("�s�إX�ԹH�Wĵ�ܳq�i�H�{���޿観�~,���ˬd�{��.", Mail_To, Mail_Cc, "�s�إX�ԹH�Wĵ�ܳq�i");

        }



        private static void send_mail(string Mail_Body, string Mail_To, string Mail_Cc, string Mail_Subject)
        {
            MailMessage objMailMessage = new MailMessage();
            SmtpMail objmail;
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);



            htw.Write(Mail_Body.ToString());

            //System.Web.HttpContext context = System.Web.HttpContext.Current;

            //context.Server.Execute("http://www.taifex.com.tw/chinese/3/7_12_1.asp", htw);

            Mail_Body = sw.ToString();

            



            objMailMessage.BodyFormat = MailFormat.Html;
            objMailMessage.Body = Mail_Body;
            objMailMessage.To = Mail_To;
            objMailMessage.Cc = Mail_Cc; 
            objMailMessage.From = "cimalarm@innolux.com.tw";
            objMailMessage.Subject = Mail_Subject;

            try
            {
                SmtpMail.SmtpServer = "10.56.130.63";
                SmtpMail.Send(objMailMessage);
            }
            catch
            {
                try
                {
                    SmtpMail.SmtpServer = "10.56.130.57";
                    SmtpMail.Send(objMailMessage);
                }
                catch
                {
                }
            }
        }


        public static DataSet Get_DataSet(string sql_stm, string connect_string)
        {


            DataSet ds = new DataSet();
            OleDbConnection myConnection = new OleDbConnection();
            OleDbCommand myCommand = new OleDbCommand();
            OleDbDataAdapter mydataad = new OleDbDataAdapter();
            try
            {
                myConnection.ConnectionString = connect_string;
                myCommand.CommandType = CommandType.Text;
                myCommand.Connection = myConnection;
                myCommand.CommandText = sql_stm;
                mydataad.SelectCommand = myCommand;
                mydataad.Fill(ds);
                myConnection.Close();
            }
            catch (Exception e)
            {
                myConnection.Close();

            }

            return ds;
        }

        public static DataTable GetDataTable2(string strSql,string connect_string)
        {
            DataTable dt = new DataTable();
            SqlConnection myConnection = new SqlConnection();
            SqlCommand myCommand = new SqlCommand();
            SqlDataAdapter mydataad = new SqlDataAdapter();
            try
            {

                myConnection.ConnectionString = connect_string;
                myCommand.CommandType = CommandType.Text;
                myCommand.Connection = myConnection;
                myCommand.CommandText = strSql;
                myCommand.CommandTimeout = 0;
                // conn.CommandTimeout = 600  '��
                mydataad.SelectCommand = myCommand;
                mydataad.Fill(dt);
                myConnection.Close();
            }
            catch(Exception e)
            {
                //e.ToString();
                //err_msg = e.ToString();
                myConnection.Close();
            }

            return dt;
        }

        public static DataTable GetDataTable(string strSql,string connect_string)
        {
            DataTable dt = new DataTable();
           OleDbConnection myConnection = new OleDbConnection();
            OleDbCommand myCommand = new OleDbCommand();
            OleDbDataAdapter mydataad = new OleDbDataAdapter();
            try
            {

                myConnection.ConnectionString = connect_string;
                myCommand.CommandType = CommandType.Text;
                myCommand.Connection = myConnection;
                myCommand.CommandText = strSql;
                myCommand.CommandTimeout = 0;
                // conn.CommandTimeout = 600  '��
                mydataad.SelectCommand = myCommand;
                mydataad.Fill(dt);
                myConnection.Close();
            }
            catch(Exception e)
            {
                e.ToString();
                myConnection.Close();
            }

            return dt;
        }

        private static void ExecuteStatement(string sql_stm, string connect_string)
        {
            
            try
            {
                OleDbConnection myConnection = new OleDbConnection(connect_string);
                OleDbCommand myCommand = new OleDbCommand(sql_stm, myConnection);
                myConnection.Open();
                myCommand.ExecuteNonQuery();
                myConnection.Close();
            }
            catch (Exception e)
            {
                
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

    }
}
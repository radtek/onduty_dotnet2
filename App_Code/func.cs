using System;
using System.Data;
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


/// <summary>
/// func 的摘要描述
/// </summary>
public class func
{
	public func()
	{
		//
		// TODO: 在此加入建構函式的程式碼
		//
	}

    public static string get_netdrive_id()
    {
        string add_drive_id = "";
        string[] drives = Directory.GetLogicalDrives();

        if (drives[drives.Length - 1] == "C:\\")
            add_drive_id = "D";
        if (drives[drives.Length - 1] == "D:\\")
            add_drive_id = "E";
        if (drives[drives.Length - 1] == "E:\\")
            add_drive_id = "F";
        if (drives[drives.Length - 1] == "F:\\")
            add_drive_id = "G";
        if (drives[drives.Length - 1] == "H:\\")
            add_drive_id = "I";
        if (drives[drives.Length - 1] == "I:\\")
            add_drive_id = "J";
        if (drives[drives.Length - 1] == "J:\\")
            add_drive_id = "K";
        if (drives[drives.Length - 1] == "K:\\")
            add_drive_id = "L";
        if (drives[drives.Length - 1] == "L:\\")
            add_drive_id = "M";
        if (drives[drives.Length - 1] == "M:\\")
            add_drive_id = "N";
        if (drives[drives.Length - 1] == "N:\\")
            add_drive_id = "O";
        if (drives[drives.Length - 1] == "O:\\")
            add_drive_id = "P";
        if (drives[drives.Length - 1] == "P:\\")
            add_drive_id = "Q";
        if (drives[drives.Length - 1] == "Q:\\")
            add_drive_id = "R";
        if (drives[drives.Length - 1] == "R:\\")
            add_drive_id = "S";
        if (drives[drives.Length - 1] == "S:\\")
            add_drive_id = "T";
        if (drives[drives.Length - 1] == "T:\\")
            add_drive_id = "U";

        if (drives[drives.Length - 1] == "U:\\")
            add_drive_id = "V";
        if (drives[drives.Length - 1] == "V:\\")
            add_drive_id = "W";
        if (drives[drives.Length - 1] == "W:\\")
            add_drive_id = "X";
        if (drives[drives.Length - 1] == "X:\\")
            add_drive_id = "Y";
        if (drives[drives.Length - 1] == "Y:\\")
            add_drive_id = "Z";

        if (drives[drives.Length - 1] == "Z:\\")
            add_drive_id = "A";

        return add_drive_id;


    }


    public static void zip_file(string winrar_program_path,string destination_file,string target_file)
    {

    //System.Diagnostics.Process.Start(Server.MapPath("winrar.exe"), " a -ep " + Server.MapPath("abc.zip") + " " + Server.MapPath(".\\top.aspx"));
        Process.Start(winrar_program_path, " a -ep " + destination_file + " " + target_file);
    
    
    }


     


    public static void start_process(string cmd_string)
    {

        Process prc = new Process();
        prc.StartInfo.FileName = @"cmd.exe ";
        prc.StartInfo.UseShellExecute = false;
        prc.StartInfo.RedirectStandardInput = true;
        prc.StartInfo.RedirectStandardOutput = true;
        prc.StartInfo.RedirectStandardError = true;
        prc.StartInfo.CreateNoWindow = false;

        prc.Start();

        string cmd = @"net use z: \\192.168.1.1\tmp pass /user:name ";
        cmd = @"net use e: \\172.16.12.61\e-meeting FABabc123 /USER:t1fab\fabuser"; 
        cmd = cmd_string;
        prc.StandardInput.WriteLine(cmd);
        prc.StandardInput.Close();

    }



    public static void write_log(string program_name, string file_path, string file_type)
    {
        StreamWriter sw;
        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        string program_name1 = program_name;
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(file_path); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log"); 
        fi = new FileInfo(file_path + DateTime.Now.ToString("yyyyMMdd") + "." + file_type);

        if (!di.Exists)
        {
            di.Create();//目錄不存在 產生目錄 
        }
        if (fi.Exists == true)
        {
            //檔案存在 寫檔案 
            //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log"); 
            sw = File.AppendText(file_path + DateTime.Now.ToString("yyyyMMdd") + "." + file_type);
        }
        else
        {
            sw = fi.CreateText(); //檔案不存在 產生檔案 
        }

        sw.WriteLine("Create log file");
        sw.WriteLine(DateTime.Now.ToString("u") + " " + program_name1 + " Program Start");
        sw.WriteLine(DateTime.Now.ToString("u") + " " + program_name1 + " Program END ");
        sw.WriteLine("");
        sw.Close();


    }

    public static void delete_log_dir(string file_path, string file_type, Double dayAgo)
    {
        //DirectoryInfo dir = new DirectoryInfo(Server.MapPath(".") + "\\CF\\Save_file\\"); 
        DirectoryInfo dir = new DirectoryInfo(file_path);
        // FileInfo[] files = dir.GetFiles("*.xls"); 
        //FileInfo[] files = dir.GetFiles(file_type);

        DirectoryInfo[] subdir = dir.GetDirectories();


        for (int i = 0; i <= subdir.Length - 1; i++)
        {
            if (subdir[i].CreationTime < DateTime.Now.AddDays(dayAgo))
            {
                FileInfo[] files = subdir[i].GetFiles(file_type);

                for (int j = 0; j <= files.Length - 1; j++)
                {
                    if (files[j].CreationTime < DateTime.Now.AddDays(dayAgo))
                    {

                        files[j].Delete();
                    }



                }

                subdir[i].Delete();
            }



        }

        //Int32 counter = 0;
        // Display the name of all the files. 
        #region MyRegion
        //foreach (FileInfo file in files) 
        //{ 
        // counter = counter + 1; 
        // Response.Write(counter + "."); 

        // Response.Write("Name: " + file.Name + " "); 
        // Response.Write("<br/>"); 
        // Response.Write("Size: " + file.Length.ToString()); 
        // Response.Write("<br/>"); 
        //} 
        #endregion



    }

    public static void delete_log_file(string file_path, string file_type, Double dayAgo)
    {
        //DirectoryInfo dir = new DirectoryInfo(Server.MapPath(".") + "\\CF\\Save_file\\"); 
        DirectoryInfo dir = new DirectoryInfo(file_path);
        // FileInfo[] files = dir.GetFiles("*.xls"); 
        FileInfo[] files = dir.GetFiles(file_type);


        for (int i = 0; i <= files.Length - 1; i++)
        {
            if (files[i].CreationTime < DateTime.Now.AddDays(dayAgo))
            {

                files[i].Delete();
            }



        }

        //Int32 counter = 0;
        // Display the name of all the files. 
        #region MyRegion
        //foreach (FileInfo file in files) 
        //{ 
        // counter = counter + 1; 
        // Response.Write(counter + "."); 

        // Response.Write("Name: " + file.Name + " "); 
        // Response.Write("<br/>"); 
        // Response.Write("Size: " + file.Length.ToString()); 
        // Response.Write("<br/>"); 
        //} 
        #endregion



    } 


    public static  string get_ticket(string location,string user_id)
    {
        ArrayList al_temp = new ArrayList();
        al_temp = func.FileToArray(location);
        
        Int32 initial = 0;

        string str_ticket = "N";

        for (int i = 0; i < al_temp.Count; i++)
        {
            if (al_temp[i].ToString() == user_id)
            {
                initial++;
            }
        }


        if (initial > 0)
        {
            str_ticket = "Y";

        }
        return str_ticket;

    }

    public static string GetWeekOfCurrDate(DateTime dt)
    {
        int Week = 1;
        int nYear = dt.Year;
        System.DateTime FirstDayInYear = new DateTime(nYear, 1, 1);
        System.DateTime LastDayInYear = new DateTime(nYear, 12, 31);
        int DaysOfYear = Convert.ToInt32(LastDayInYear.DayOfYear);
        int WeekNow = Convert.ToInt32(FirstDayInYear.DayOfWeek) - 1;
        if (WeekNow < 0) WeekNow = 6;
        int DayAdd = 6 - WeekNow;
        System.DateTime BeginDayOfWeek = new DateTime(nYear, 1, 1);
        System.DateTime EndDayOfWeek = BeginDayOfWeek.AddDays(DayAdd);
        Week = 2;
        for (int i = DayAdd + 1; i <= DaysOfYear; i++)
        {
            BeginDayOfWeek = FirstDayInYear.AddDays(i);
            if (i + 6 > DaysOfYear)
            {
                EndDayOfWeek = BeginDayOfWeek.AddDays(DaysOfYear - i - 1);
            }
            else
            {
                EndDayOfWeek = BeginDayOfWeek.AddDays(6);
            }

            if (dt.Month == EndDayOfWeek.Month && dt.Day <= EndDayOfWeek.Day)
            {
                break;
            }
            Week++;
            i = i + 6;
        }
        string date_year_week = dt.Year + Week.ToString();
        return date_year_week;
    }


    public static string MergeMailListToString(string sql, string conn)
    {
        DataSet maillistX = new DataSet();

        string connx = System.Configuration.ConfigurationManager.AppSettings["OARPT"];

        connx = conn;
        string sql_mailist = "select * from dmbs_ce_alarm_mail_cfg t                                 " +
                             "where t.material_group='Chemical' and t.material='DMSO' and plan='T1'  ";


        sql_mailist = sql;

        //ArrayList maillist = new ArrayList();

        // maillist = func.FileToArray(Server.MapPath(".") + "\\maillist.txt"); 
        maillistX = func.get_dataSet_access(sql_mailist, connx);

        string maillist1 = "";
        string maillist2 = "";

        for (int i = 0; i <= maillistX.Tables[0].Rows.Count - 1; i++)
        {

            if (maillistX.Tables[0].Rows.Count == 1)
            {
                maillist1 = maillistX.Tables[0].Rows[i]["MAIL_ADDRESS"].ToString();
            }
            else

                maillist1 = maillistX.Tables[0].Rows[i]["MAIL_ADDRESS"].ToString() + ","; //呈現每一個 DataSet Row[i] 
            maillist2 = maillist2 + maillist1; //將每個 DataSet Row[i] 的值串起來 
        }
        return maillist2;
    }

    public static void get_sql_execute(string sql_str, string strConn)
    {
        string strConn2;
        strConn2 = strConn;

        //strConn2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\stock.mdb; Persist Security Info=True;"; 
        string sql_str2;

        sql_str2 = sql_str;



        OleDbConnection myConnection = new OleDbConnection(strConn2);

        OleDbCommand myCommand = new OleDbCommand(sql_str2, myConnection);
        myConnection.Open();

        OleDbDataReader MyReader = myCommand.ExecuteReader();

        MyReader.Read();

        MyReader.Close();

        myConnection.Close();



    } 

    public static DataSet get_dataSet_access(string sql_str, string strConn)
    {
        string strConn2;
        strConn2 = strConn;

        //strConn2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\stock.mdb; Persist Security Info=True;"; 
        string sql_str2;

        sql_str2 = sql_str;

        OleDbDataAdapter oda2 = new OleDbDataAdapter(sql_str2, strConn2);
        oda2.SelectCommand.CommandTimeout = 900;
        DataSet myDataSet2 = new DataSet();
        oda2.Fill(myDataSet2, "AccessInfo");
        return myDataSet2;

    }



    private static DataTable get_dataTable(string sql_str, string strConn)
    {
        string strConn2;
        strConn2 = strConn;

        //strConn2 = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=c:\\stock.mdb; Persist Security Info=True;"; 
        string sql_str2;

        sql_str2 = sql_str;

        OleDbDataAdapter oda2 = new OleDbDataAdapter(sql_str2, strConn2);

        DataTable myDataTable2 = new DataTable();
        oda2.Fill(myDataTable2, "AccessInfo");
        return myDataTable2;

    }



    public static DataTable Table_transport(DataTable dt)
    {
        DataTable dtNew = new DataTable();
        dtNew.Columns.Add("ColumnName", typeof(string));
        for (int i = 0; i < dt.Rows.Count; i++)
        {
            dtNew.Columns.Add("Column" + (i + 1).ToString(), typeof(string));
        }
        foreach (DataColumn dc in dt.Columns)
        {
            DataRow drNew = dtNew.NewRow();
            drNew["ColumnName"] = dc.ColumnName;
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                drNew[i + 1] = dt.Rows[i][dc].ToString();
            }
            dtNew.Rows.Add(drNew);
        }

        return dtNew;
    }



    public static ArrayList FileToArray(string srtPath)
    {
        StreamReader ReadFile = new StreamReader(srtPath, // 檔案路徑
    System.Text.Encoding.Default); // 編碼方式

        ArrayList arrFile = new ArrayList(); //make our temporary storage object
        string strTmp;

        //loop through all the rows, stopping when we reach the end of file
        do
        {
            strTmp = ReadFile.ReadLine();
            if (strTmp != null)
            {
                strTmp = strTmp.Trim();
                if (strTmp.Length != 0) arrFile.Add(strTmp); //add each element to our ArrayList
            }
        } while (strTmp != null);
        ReadFile.Close();
        return arrFile;
    } 


    //public static void BindGridView(string sql, string strConn)
    //{
    //    string sql_str, strConn2;
    //    DataSet myDataSet123 = new DataSet();
    //    sql_str = sql;
    //    //sql_str = "select * from stock_macd_1 WHERE DATE>DATEADD('d',-1,NOW()) order by DATE desc"; 
    //    //GridView GridViewn = new GridView(); 

    //    //DATEADD(day, 1, @CountDate) 
    //    strConn2 = strConn;

    //    myDataSet123 = get_dataSet_access(sql_str, strConn2);

    //    GridView1.DataSource = myDataSet123.Tables["AccessInfo"].DefaultView;
    //    GridView1.DataBind();
    //} 



    public static string ArrayListToString(string file_path)
    {

        ArrayList maillist = new ArrayList();

        // maillist = func.FileToArray(Server.MapPath(".") + "\\maillist.txt"); 
        maillist = func.FileToArray(file_path);

        string maillist1 = "";
        string maillist2 = "";

        for (int i = 0; i <= maillist.Count - 1; i++)
        {

            if (i == maillist.Count - 1)
            {
                maillist1 = maillist[i].ToString();
            }
            else

                maillist1 = maillist[i] + ","; //呈現每一個 ArrayList[i] 
            maillist2 = maillist2 + maillist1; //將每個ArrayList[i]的值串起來 
        }
        return maillist2;
    } 


   private static void Upload(string filename, string ftpServerIP, string Account, string ftppassword)
    {

        FileInfo fileInf = new FileInfo(filename);

        string uri = "ftp://" + ftpServerIP + "/" + fileInf.Name;

        FtpWebRequest reqFTP;

        // Create FtpWebRequest object from the Uri provided

        reqFTP = (FtpWebRequest)FtpWebRequest.Create(new Uri("ftp://" + ftpServerIP + "/" + fileInf.Name));//此段關鍵

        // Provide the WebPermission Credintials

        reqFTP.Credentials = new NetworkCredential(Account, ftppassword);

        // By default KeepAlive is true, where the control connection is not closed

        // after a command is executed.

        reqFTP.KeepAlive = false;

        // Specify the command to be executed.

        reqFTP.Method = WebRequestMethods.Ftp.UploadFile;

        // Specify the data transfer type.

        reqFTP.UseBinary = true;

        // Notify the server about the size of the uploaded file

        reqFTP.ContentLength = fileInf.Length;

        // The buffer size is set to 2kb

        int buffLength = 2048;

        byte[] buff = new byte[buffLength];

        int contentLen;

        // Opens a file stream (System.IO.FileStream) to read the file to be uploaded

        FileStream fs = fileInf.OpenRead();

        try
        {

            // Stream to which the file to be upload is written

            Stream strm = reqFTP.GetRequestStream();

            // Read from the file stream 2kb at a time

            contentLen = fs.Read(buff, 0, buffLength);

            // Till Stream content ends

            while (contentLen != 0)
            {

                // Write Content from the file stream to the FTP Upload Stream

                strm.Write(buff, 0, contentLen);

                contentLen = fs.Read(buff, 0, buffLength);

            }

            // Close the file stream and the Request Stream

            strm.Close();

            fs.Close();

        }


        catch (Exception ex)
        {

            //MessageBox.Show(ex.Message, "Upload Error");

        }

    }



}

public class FileIndexProvider
{
    // C2M\TFTR2\YH83D\YH83DN01\YH83DN013A61.txt
    //===== 0       1      2       3

    public FileIndexProvider()
    {
    }
    public DirectoryInfo[] GetDirectory(string file_path)
    {
        DirectoryInfo dir = new DirectoryInfo(file_path);
        // FileInfo[] files = dir.GetFiles("*.xls"); 
        //FileInfo[] files = dir.GetFiles(file_type);

        DirectoryInfo[] subdir = dir.GetDirectories();

        return subdir;

    }

    public FileInfo[] GetFileInfo(string file_path)
    {
        DirectoryInfo dir = new DirectoryInfo(file_path);
        FileInfo[] files = dir.GetFiles("*.*");
        //FileInfo[] files = dir.GetFiles(file_type);


        return files;

    }

    public void WriteLOG(string file_path, string content, string file_type)
    {

        StreamWriter sw;
        DirectoryInfo di;//宣告目錄 
        FileInfo fi;//宣告檔案 
        string localcontent = content;
        //di = new DirectoryInfo(Server.MapPath(".") + "\\RUN_LOG\\" ); //DateTime.Now.ToString("yyyyMMdd") 
        di = new DirectoryInfo(file_path); //DateTime.Now.ToString("yyyyMMdd") 
        //fi = new FileInfo(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + "\\" + DateTime.Now.ToString("yyyyMMdd") + ".log"); 
        fi = new FileInfo(file_path + DateTime.Now.ToString("yyyyMMdd") + "." + file_type);

        if (!di.Exists)
        {
            di.Create();//目錄不存在 產生目錄 
        }
        if (fi.Exists == true)
        {
            //檔案存在 寫檔案 
            //sw = File.AppendText(Server.MapPath(".") + "\\RUN_LOG\\" + DateTime.Now.ToString("yyyyMMdd") + ".log"); 
            sw = File.AppendText(file_path + DateTime.Now.ToString("yyyyMMdd") + "." + file_type);
        }
        else
        {
            sw = fi.CreateText(); //檔案不存在 產生檔案 
        }

        sw.WriteLine(localcontent);
        sw.Close();

    }

}


public class MappProvider : Page
{
    private string mappoupid = "";
    private string mappContent = "";

    public MappProvider()
    {

    }
    public void SendMessage(string sgroup, string scontent)
    {
        mappoupid = sgroup;
        mappContent = scontent;

        string webmessage = @"http://mapp.innolux.com/teamplus_innolux/API/IMService.ashx?ask=sendChatMessage&account=api_jncim1_mi&api_key=B195F0D2-7AFF-0F08-41A0-48386C54DE70&chat_sn={0}&content_type=1&msg_content={1}";
        webmessage = string.Format(webmessage, mappoupid, mappContent);

        string ask = "sendChatMessage";

        string account = "api_jncim1_mi";

        string api_key = "B195F0D2-7AFF-0F08-41A0-48386C54DE70";
        string content_type = "1";
        string chat_sn = mappoupid;
        string msg_content = mappContent;

        Encoding myEncoding = Encoding.GetEncoding("UTF-8");

        string address = "http://mapp.innolux.com/teamplus_innolux/API/IMService.ashx?" + HttpUtility.UrlEncode("ask", myEncoding) + "=" + HttpUtility.UrlEncode(ask, myEncoding) + "&" + HttpUtility.UrlEncode("account", myEncoding) + "=" + HttpUtility.UrlEncode(account, myEncoding) + "&" + HttpUtility.UrlEncode("api_key", myEncoding) + "=" + HttpUtility.UrlEncode(api_key, myEncoding) + "&" + HttpUtility.UrlEncode("chat_sn", myEncoding) + "=" + HttpUtility.UrlEncode(chat_sn, myEncoding) + "&" + HttpUtility.UrlEncode("content_type", myEncoding) + "=" + HttpUtility.UrlEncode(content_type, myEncoding) + "&" + HttpUtility.UrlEncode("msg_content", myEncoding) + "=" + HttpUtility.UrlEncode(msg_content, myEncoding);

        //Console.WriteLine("address:" + address);

        HttpWebRequest req = (HttpWebRequest)HttpWebRequest.Create(address);

        req.Method = "GET";

        using (WebResponse wr = req.GetResponse())
        {

            using (StreamReader myStreamReader = new StreamReader(wr.GetResponseStream(), myEncoding))
            {

                string data = myStreamReader.ReadToEnd();

                //Console.WriteLine("data:" + data);

            }

        }


        //string script_temp2 = @" <script language='javascript' type='text/JavaScript'>" +
        //         " window.open(' " + webmessage + " ', 'mapp', config='height=20,width=30');" +
        //         "window.opener=null;window.close();" +
        //         " </script> ";


        ////呼叫 javascript 
        //this.Page.RegisterStartupScript("", script_temp2);

    }


}

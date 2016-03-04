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

public partial class Lh_onduty_Login1 : System.Web.UI.Page
{

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Request["IsAuthenticated"] == "passed" && Request.QueryString["sn"] != null)
        {
            //FormsAuthentication.SetAuthCookie("Admin", false);
            FormsAuthentication.SetAuthCookie("Admin", false);
            Response.Redirect("onduty_lh_query.aspx?sn=" + Request.QueryString["sn"]);
        }

        //if (Request["Is_Auth"] == "passed")
        //{
        //    login(Request["user_id"].Trim(), "", "passed");
        //}
    }

    private void login(string user_id, string password)
    {
        WebReference1.Login auth = new WebReference1.Login();

        SSO.Encode ssoObj = new SSO.EncodeClass();
        string login = "";
        string pass = "";

        try
        {
            login = ssoObj.ssoEncode(user_id + "||" + password + "||" + "LH_onduty").ToString();
            pass = auth.CheckPassword(login).ToString();
        }
        catch
        {
            Message.Text = "AD Failed!";
            return;
        }

        if (pass.Substring(0, 1) == "0")
        {


            //string auth_user = "TWN050314,TWN050555,TWN040459,TWN020035,JEFFREY.YANG,TWN030314,KEVIN.CHUNG,TWN040117,SEAN.CHEN,F3106570,GUANGLIANG.YI,TWN090013,SIMON01.LIN,TWN070578,HUANGLA.HUANG,TWN040620,FANYUAN.KUNG,TWN040349,JOBPIN.YAO,F3106613,MING.ZHAO,F3103420,AO.CHEN,F3115258,VINA.GAO,F4395984,HAN.WANG";

            //if (auth_user.IndexOf(user_id.ToUpper()) != -1)
            //{
            FormsAuthentication.SetAuthCookie(user_id.ToUpper(), false);

            Session["user_id"] = user_id.ToUpper();
            Response.Redirect("onduty_lh_query.aspx?user_id=" + Session["user_id"]);
            //}
            //else
            //{
            //    Message.Text = "請申請系統使用權限!";
            //}

        }

        else
        {
            Message.Text = "Log In Failed!...Please try again!";
        }
    }

    protected void SigninBtn_Click(object sender, ImageClickEventArgs e)
    {
        login(user_id.Text.Trim().ToUpper(), password.Text.Trim());
    }
}

using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin.SystemAdmin
{
    public partial class UserInfo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            

                if (!this.IsPostBack)
                {
                    //if (this.Session["UserLoginInfo"] == null)
                    if (!AuthManager.IsLogined())
                    {
                        Response.Redirect("/Login.aspx");
                        return;
                    }
                    var currentUser = AuthManager.GetCurrentUser();

                    //string account = this.Session["UserLoginInfo"] as string;
                    //DataRow dr = UserInfoManger.GetUserInfoByAccount(account);

                    if (currentUser == null)//如果帳號查不到那就倒回登入
                    {
                        //this.Session["UserLoginInfo"] = null;不需要重複檢查
                        Response.Redirect("/Login.aspx");
                        return;
                    }
                    //this.ltlAcc.Text = dr["Account"].ToString();一行為引用版本之前的樣子
                    this.ltlAcc.Text = currentUser.Account;
                    this.ltlName.Text = currentUser.Name;
                    this.ltlEmail.Text = currentUser.Email;
                }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            //this.Session["UserLoginInfo"] = null;
            AuthManager.Logout();
            Response.Redirect("/Login.aspx");
        }
    }
}
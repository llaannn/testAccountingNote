using AccountingNote.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin
{
    public partial class Admin : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
                //if (this.Session["UserLoginInfo"] == null)
                if (!AuthManager.IsLogined())
                {
                    Response.Redirect("/Login.aspx");
                    return;
                }
                var currentUser = AuthManager.GetCurrentUser();

                if (currentUser == null)//如果帳號查不到那就倒回登入
                {
                   
                    Response.Redirect("/Login.aspx");
                    return;
                }

            
        }
    }
}
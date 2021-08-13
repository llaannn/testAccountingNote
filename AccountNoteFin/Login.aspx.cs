using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (this.Session["UserInfo"] != null)
            {
                this.plcLogin.Visible = false;
                Response.Redirect("/AdminSystem/UserInfo.aspx");
            }
            else

            {
                this.plcLogin.Visible = true;

            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            //string db_acc = "Admin";
            //string db_pwd = "12345";

            string inp_Acc = this.txtAcc.Text;
            string inp_PWD = this.txtPWD.Text;


            if (string.IsNullOrWhiteSpace(inp_Acc) || string.IsNullOrWhiteSpace(inp_PWD))
            {
                this.ltlMsg.Text = "帳號或密碼為空白";
                return;
            }

            var dr = UserInfoManger.GetUserInfoByAccount(inp_Acc);

            //if (string.Compare(db_acc, inp_Acc, true) == 0 && string.Compare(db_pwd, inp_Pwd, false)==0)

            if (dr == null)
            {
                this.ltlMsg.Text = "輸入的帳號並不存在";
                return;
            }


            if (string.Compare(dr["Account"].ToString(), inp_Acc, true) == 0 && string.Compare(dr["PWD"].ToString(), inp_PWD, false) == 0)
            {
                //this.Session["UserLoginInfo"] = db_acc;
                this.Session["UserLoginInfo"] = dr["Account"].ToString();
                Response.Redirect("/SystemAdmin/UserInfo.aspx");


            }

            else
            {
                this.ltlMsg.Text = "登入失敗，請確定輸入正確的帳號及密碼";
                return;
            }
        }
    }
    
}
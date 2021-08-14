﻿using AccountingNote.Auth;
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

                    string account = this.Session["UserLoginInfo"] as string;
                    DataRow dr = UserInfoManger.GetUserInfoByAccount(account);


          


                    if (dr == null)//如果帳號查不到那就倒回登入
                    {
                        this.Session["UserLoginInfo"] = null;
                        Response.Redirect("/Login.aspx");
                        return;
                    }

                    this.ltlAcc.Text = dr["Account"].ToString();
                    this.ltlName.Text = dr["Name"].ToString();
                    this.ltlEmail.Text = dr["Email"].ToString();
                }
            
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            this.Session["UserLoginInfo"] = null;
            Response.Redirect("/Login.aspx");
        }
    }
}
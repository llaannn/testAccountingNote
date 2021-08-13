using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin.SystemAdmin
{
    public partial class AccountingList : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //驗證登入
            if (this.Session["UserLoginInfo"] == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            //取得使用者資料
            string account = this.Session["UserLoginInfo"] as string;
            var dr = UserInfoManger.GetUserInfoByAccount(account);

            if (dr == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }


            var dt = AccountingManager.GetAccountingList(dr["ID"].ToString());//把取得的帳號資料當參數傳給查詢的方法

            if (dt.Rows.Count > 0)
            {
                this.gvAccList.DataSource = dt;
                this.gvAccList.DataBind();
            }
            else
            {
                this.gvAccList.Visible = false;
                this.plcNoData.Visible = true;

            }


        }

        protected void btnCreate_Click(object sender, EventArgs e)
        {
            Response.Redirect("/SystemAdmin/AccountingDetail.aspx");
        }

        protected void gvAccList_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            //這是為了做支出收入而建立的
            var row = e.Row;

            if (row.RowType == DataControlRowType.DataRow)
            {
                //Literal ltl = row.FindControl("ltActType") as Literal;

                Label lbl = row.FindControl("lblActType") as Label;


                var dr = row.DataItem as DataRowView;
                int actType = dr.Row.Field<int>("ActType");


                if (actType == 0)
                {
                    // ltl.Text = "支出";
                    lbl.Text = "支出";

                }
                else
                {
                    //ltl.Text = "收入";
                    lbl.Text = "收入";
                }

                if (dr.Row.Field<int>("Amount") > 1500)
                {
                    lbl.ForeColor = Color.Red;
                }
            }

        }
    }
}
using AccountingNote.Auth;
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
            //if (this.Session["UserLoginInfo"] == null)
            if(!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            //取得使用者資料
            //string account = this.Session["UserLoginInfo"] as string;
            //var dr = UserInfoManger.GetUserInfoByAccount(account);

            //if (dr == null)
            //{
            //    Response.Redirect("/Login.aspx");
            //    return;
            //}
            var currentUser = AuthManager.GetCurrentUser();


            if (currentUser == null)//如果帳號查不到那就倒回登入
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }


            var dt = AccountingManager.GetAccountingList(currentUser.ID);//把取得的帳號資料當參數傳給查詢的方法

            if (dt.Rows.Count > 0)
            {
                //int totalPages = this.GetTotalPages(dt);//先算出總項目數
                //var dtPage = this.GetCPageDataTable(dt);//取出新表格
                var dtPage = this.GetPageDataTable(dt);

                this.ucPage2.TotalSize = dt.Rows.Count;
                this.ucPage2.Bind();



                this.gvAccList.DataSource = dtPage;//本來只放dt
                this.gvAccList.DataBind();

                ////this.ucPager.TotalSize = dt.Rows.Count;
                ////this.ucPager.Bind();除以零的第一個方法還沒有改 暫且先這註解這邊



              //  this.gvAccList.DataBind();

                //var pages = (dt.Rows.Count / 10);
                //if(dt.Rows.Count % 10>0)
                
                //    pages += 1;
                //    this.ltPager.Text = $"共{dt.Rows.Count}筆，共{pages}頁，現在在第{this.GetCurrentPage()}頁<br/>";


                ////最後跑迴圈 用來取出超連結的資料
                //for (var i = 1; i <= totalPages; i++)
                //{
                //    this.ltPager.Text += $"<a href='AccountingList.aspx?page={i}'>{i}</a>&nbsp";
                //}


            }
            else
            {
                this.gvAccList.Visible = false;
                this.plcNoData.Visible = true;

            }
           

        }
        //private int GetTotalPages(DataTable dt)//取得總筆數
        //{
        //    int pegers = dt.Rows.Count / 10;
        //    if ((dt.Rows.Count % 10) > 0)
        //        pegers += 1;
        //        return pegers;
        //}


        private int GetCurrentPage()
        {
            string pageText = Request.QueryString["Page"];
            if (string.IsNullOrWhiteSpace(pageText))
                return 1;
            int intPage;


            if(!int.TryParse(pageText, out intPage))
                return 1;

            if(intPage <=0)
                return 1;
            return intPage;

        }

        private DataTable GetPageDataTable(DataTable dt)//這裡只是複製資料
        {
            DataTable dtPage = dt.Clone(); //Clone 拿了結構出來用 COPY除了結構也拿了資料
            int pageSize = this.ucPage2.PageSize;

            int startIndex = (this.GetCurrentPage() - 1) * pageSize;
            int endIndex = (this.GetCurrentPage()) * pageSize;
            //int endIndex = (this.GetCurrentPage()) * 10;本來是直接放十筆

            if (endIndex > dt.Rows.Count)
                endIndex = dt.Rows.Count;
            for (var i = startIndex; i < endIndex; i++)
            {
                DataRow dr = dt.Rows[i];
                var drNew = dtPage.NewRow();

                foreach(DataColumn dc in dt.Columns)
               
                {

                    drNew[dc.ColumnName] = dr[dc];
                }
                dtPage.Rows.Add(drNew);
            }
            return dtPage;
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
using AccountingNote.Auth;
using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace AccountNoteFin.SystemAdmin
{
    public partial class AccountingDetail : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            //if (this.Session["UserLoginInfo"] == null)
            if (!AuthManager.IsLogined())
            {
                Response.Redirect("/Login.aspx");
                return;
            }

            //取得使用者資料
            string account = this.Session["UserLoginInfo"] as string;
            //var drUserInfo = UserInfoManger.GetUserInfoByAccount(account);

            //if (drUserInfo == null)
            //{
            //    Response.Redirect("/Login.aspx");
            //    return;
            //}
            var currentUser = AuthManager.GetCurrentUser();

            //string account = this.Session["UserLoginInfo"] as string;
            //DataRow dr = UserInfoManger.GetUserInfoByAccount(account);

            if (currentUser == null)//如果帳號查不到那就倒回登入
            {
                this.Session["UserLoginInfo"] = null;
                Response.Redirect("/Login.aspx");
                return;
            }


            if (!this.IsPostBack)
            {
                if (this.Request.QueryString["ID"] == null)
                {
                    this.btnDelete.Visible = false;
                }
                else
                {
                    this.btnDelete.Visible = true;


                    string idText = this.Request.QueryString["ID"];//將傳入的值視為字串重新轉型避免無法輸入資料庫
                    int id;
                    if (int.TryParse(idText, out id))
                    {
                        var drAcc = AccountingManager.GetAccounting(id, currentUser.ID);
                        //var drAcc = AccountingManager.GetAccounting(id, drUserInfo["ID"].ToString());改之前的樣子

                        if (drAcc == null)
                        {
                            this.ltlMsg.Text = "資料不存在";
                            this.btnSave.Visible = false;
                            this.btnDelete.Visible = false;

                        }
                        else
                        {
                            //if (drAcc["USserID"].ToString() == drUserInfo["ID"].ToString()) 
                            //{做好老師就說不要ㄌ
                            this.ddlActType.SelectedValue = drAcc["ActType"].ToString();
                            this.txtAmount.Text = drAcc["Amount"].ToString();
                            this.txtCaption.Text = drAcc["Caption"].ToString();
                            this.txtDesc.Text = drAcc["Body"].ToString();
                            //}
                        }

                    }
                    else
                    {
                        this.ltlMsg.Text = "無法找到ID";
                        this.btnSave.Visible = false;
                        this.btnDelete.Visible = false;

                    }

                }

            }
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            List<string> msgList = new List<string>();//錯誤訊息檢查
            if (!this.CheckInput(out msgList))
            {
                this.ltlMsg.Text = string.Join("<br/>", msgList);
                return;
            }

            UserInfoModel currentUser = AuthManager.GetCurrentUser();

            //string account = this.Session["UserLoginInfo"] as string;
            //var dr = UserInfoManger.GetUserInfoByAccount(account);

            //if (dr == null)
            if (currentUser == null)
            {
                Response.Redirect("/Login.aspx");
                return;
            }//從頁面移過來，確認現在登入者的ID

            //string userID = dr["ID"].ToString();
            string userID = currentUser.ID;
            string actTypeText = this.ddlActType.SelectedValue;
            string amountText = this.txtAmount.Text;
            string caption = this.txtCaption.Text;
            string body = this.txtDesc.Text;

            int amount = Convert.ToInt32(amountText);
            int actType = Convert.ToInt32(actTypeText);

            //testAccountingManager.CreateAccounting(userID, caption, amount, actType, body);
            //Response.Redirect("/AdminSystem/AccountingList.aspx");

            string idText = this.Request.QueryString["ID"];
            if (string.IsNullOrWhiteSpace(idText))
            {
                AccountingManager.CreateAccounting(userID, caption, amount, actType, body);
            }
            else
            {
                int id;
                if (int.TryParse(idText, out id))
                {
                    AccountingManager.UpdateAccounting(id, userID, caption, amount, actType, body);
                }
            }
            Response.Redirect("/SystemAdmin/AccountingList.aspx");
        }


        private bool CheckInput(out List<string> errorMsgList)
        {
            List<string> msgList = new List<string>();

            if (this.ddlActType.SelectedValue != "0" && this.ddlActType.SelectedValue != "1")
            {
                msgList.Add("Type MUST BE 0 or 1");
            }
            if (string.IsNullOrWhiteSpace(this.txtAmount.Text))
            {
                msgList.Add("請再次確認您的輸入");

            }
            else
            {
                int tempInt;
                if (!int.TryParse(this.txtAmount.Text, out tempInt))
                {
                    msgList.Add("請再次確認您輸入的微數字");
                }

                if (tempInt < 0 || tempInt > 1000000)
                {
                    msgList.Add("輸入的金額必須在零到一百萬之間");
                }
            }


            errorMsgList = msgList;

            if (msgList.Count == 0)
                return true;
            else
                return false;
        }



        protected void btnDelete_Click(object sender, EventArgs e)
        {
            string idText = this.Request.QueryString["ID"];

            if (string.IsNullOrWhiteSpace(idText))
                return;

            int id;
            if (int.TryParse(idText, out id))
            {
                AccountingManager.DeleteAccounting(id);
            }
            Response.Redirect("/SystemAdmin/AccountingList.aspx");
        }
    }
}

using AccountingNote.DBSource;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace AccountingNote.Auth
{
    public class AuthManager
    {
        /// <summary>
        /// 確認是否登入
        /// </summary>
        /// <returns></returns>
        public static bool IsLogined()
        {
            if (System.Web.HttpContext.Current.Session["UserLoginInfo"] == null)
                return false;
            else
                return true;

        }

        /// <summary>
        /// 取得現在使用者
        /// </summary>
        /// <returns></returns>
        public static UserInfoModel GetCurrentUser()
        //public static DataRow GetCurrentUser()
        {

            string account = HttpContext.Current.Session["UserLoginInfo"] as string;
            if (account == null)
                return null;
            DataRow dr = UserInfoManger.GetUserInfoByAccount(account);
            //return dr;

            if (dr == null)
                return null;

            UserInfoModel model = new UserInfoModel();
            model.ID = dr["ID"].ToString();
            model.Account = dr["Account"].ToString();
            model.Name = dr["Name"].ToString();
            model.Email = dr["Email"].ToString();
            return model;
        }

        /// <summary>
        /// 登出
        /// </summary>
        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
           
        }


        public static bool TryLogin(string account,string pwd,out string errorMsg)
        {
            //檢查輸入內容是否為空字串
            if (string.IsNullOrWhiteSpace(account) || string.IsNullOrWhiteSpace(pwd))
            {
                errorMsg = "帳號或密碼為空白";
                return false;
            }

            //讀取資料庫查找帳號
            var dr = UserInfoManger.GetUserInfoByAccount(account);

            if (dr == null)
            {
                errorMsg = $"輸入的帳號:{account}並不存在";
                return false;
            }


            if (string.Compare(dr["Account"].ToString(), account, true) == 0 && string.Compare(dr["PWD"].ToString(), pwd, false) == 0)
            {
                //this.Session["UserLoginInfo"] = db_acc;
                HttpContext.Current.Session["UserLoginInfo"] = dr["Account"].ToString();
                errorMsg = string.Empty;
                return true;


            }

            else
            {
                errorMsg = "登入失敗，請確定輸入正確的帳號及密碼";
                return false;
            }
        }
        
    }
}

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

        public static void Logout()
        {
            HttpContext.Current.Session["UserLoginInfo"] = null;
           
        }
        
    }
}

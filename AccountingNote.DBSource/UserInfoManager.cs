using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccountingNote.DBSource
{
    public class UserInfoManger
    {
        /// <summary>
        /// 建立連線字串
        /// </summary>
        /// <returns></returns>
        //public static string GetConnectionString()
        //{
        //    string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    return val;
        //}
        public static DataRow GetUserInfoByAccount(string account)
        {
            string connectionString = DBHelper.GetConnectionString();
            string dbCommandString =
                @" SELECT [ID],[Account],[PWD],[Name],[Email]
                   FROM UserInfo
                   WHERE [Account] = @account
                ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("account", account));


            try
            {
                return DBHelper.ReadDataRow(connectionString, dbCommandString, list);

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }

            //做完重構就註解
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{

            //    using (SqlCommand Command = new SqlCommand(dbCommandString, connection))
            //    {
            //        //Command.Parameters.AddWithValue("account", account);
            //        Command.Parameters.AddRange(list.ToArray());

            //        try
            //        {
            //            connection.Open();
            //            SqlDataReader reader = Command.ExecuteReader();

            //            DataTable dt = new DataTable();
            //            dt.Load(reader);
            //            reader.Close();

            //            if (dt.Rows.Count == 0)//有資料就回傳第0筆
            //                return null;

            //            DataRow dr = dt.Rows[0];
            //            return dr;

            //            //id被設為主鍵一定會為第0筆所以只要回傳這樣就好

            //        }

            //        catch (Exception ex)

            //        {

            //            Logger.WriteLog(ex);
            //            return null;
            //        }
            //    }
            //}


        }

       

    }
}



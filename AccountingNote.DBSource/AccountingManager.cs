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
    public class AccountingManager
    {
        /// <summary>
        /// 連結字串
        /// </summary>
        /// <param name="userID"></param>
        /// <returns></returns>
        //public static string GetConnectionString()
        //{
        //    string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
        //    return val;
        //}

        /// <summary>
        /// 取得使用者列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable GetAccountingList(string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                    $@"SELECT
                        ID
                       ,Caption
                       ,Amount
                       ,ActType
                       ,CreateDate             
                FROM Accounting
                WHERE UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@userID", userID));
            try
            {
                return DBHelper.ReadDataTable(connStr, dbcommand, list);

            }
            catch (Exception ex)
            {
                //Logger.WriteLog(ex);

                return null;
            }
        }
        /// <summary>
        /// 取得使用者列表(已擷取了方法)
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        //private static DataTable ReadDataTable(string connStr, string dbcommand, List<SqlParameter> list)
        //{
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        using (SqlCommand comm = new SqlCommand(dbcommand, conn))

        //        {
        //            //comm.Parameters.AddWithValue("@userID", userID);
        //            comm.Parameters.AddRange(list.ToArray());

        //            conn.Open();
        //            var reader = comm.ExecuteReader();

        //            DataTable dt = new DataTable();
        //            dt.Load(reader);

        //            return dt;

        //        }
        //    }
        //}

        /// <summary>
        /// 取得使用者帳號
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataRow GetAccounting(int id, string userID)
        {
            string connStr = DBHelper.GetConnectionString();
            string dbcommand =
                    $@"SELECT
                        ID
                       ,Caption
                       ,Amount
                       ,ActType
                       ,CreateDate
                       ,Body
                FROM Accounting
                WHERE id = @id AND UserID = @userID
                 ";

            List<SqlParameter> list = new List<SqlParameter>();
            list.Add(new SqlParameter("@id", id));
            list.Add(new SqlParameter("@userID", userID));
            try
            {
                return DBHelper.ReadDataRow(connStr, dbcommand, list);

            }
            catch (Exception ex)
            {
                Logger.WriteLog(ex);
                return null;
            }
        }

        //private static DataRow ReadDataRow(string connStr, string dbcommand, List<SqlParameter> list)
        //{
        //    using (SqlConnection conn = new SqlConnection(connStr))
        //    {
        //        using (SqlCommand comm = new SqlCommand(dbcommand, conn))

        //        {
        //            //comm.Parameters.AddWithValue("@id", id);
        //            //comm.Parameters.AddWithValue("@userID", userID);//不窺探他人資料
        //            comm.Parameters.AddRange(list.ToArray());


        //            try
        //            {
        //                conn.Open();
        //                var reader = comm.ExecuteReader();

        //                DataTable dt = new DataTable();
        //                dt.Load(reader);

        //                if (dt.Rows.Count == 0)
        //                    return null;
        //                return dt.Rows[0];

        //            }
        //            catch (Exception ex)
        //            {
        //                Logger.WriteLog(ex);
        //                return null;
        //            }

        //        }


        //    }
        //}



        /// <summary>
        /// 建立流水帳
        /// </summary>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        public static void CreateAccounting(string userID, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("填入金額必須在零到一百萬之間");

            if (actType < 0 || actType > 1000000)
                throw new ArgumentException("必須為支出或者收入");

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                    $@"INSERT INTO [dbo].[Accounting]
                       (
                                 UserID                                
                                 ,Caption                          
                                 ,Amount                                
                                 ,ActType                               
                                 ,CreateDate                            
                                 ,Body        
                    )
                    VALUES        
                    (
                                 @userID                             
                                 ,@caption                               
                                 ,@amount                           
                                 ,@actType                              
                                 ,@createDate                           
                                 ,@body  
                     )
       
             ";

            using (SqlConnection conn = new SqlConnection(connStr))

            using (SqlCommand comm = new SqlCommand(dbCommand, conn))

            {
                comm.Parameters.AddWithValue("@userID", userID);
                comm.Parameters.AddWithValue("@caption", caption);
                comm.Parameters.AddWithValue("@amount", amount);
                comm.Parameters.AddWithValue("@actType", actType);
                comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                comm.Parameters.AddWithValue("@body", body);


                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                }

            }
        }

        /// <summary>
        /// 新增流水帳
        /// </summary>
        /// <param name="ID"></param>
        /// <param name="userID"></param>
        /// <param name="caption"></param>
        /// <param name="amount"></param>
        /// <param name="actType"></param>
        /// <param name="body"></param>
        /// <returns></returns>
        public static bool UpdateAccounting(int ID, string userID, string caption, int amount, int actType, string body)
        {
            if (amount < 0 || amount > 1000000)
                throw new ArgumentException("填入金額必須在零到一百萬之間");

            if (actType < 0 || actType > 1000000)
                throw new ArgumentException("必須為支出或者收入");

            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                    $@"UPDATE [Accounting]
                       SET
                                 UserID       =  @userID      
                                 ,Caption     =  @caption       
                                 ,Amount      =  @amount                            
                                 ,ActType     =  @actType                           
                                 ,CreateDate  =  @createDate                           
                                 ,Body        =  @body 
                    
                    WHERE 
                            ID = @id
       
             ";

            using (SqlConnection conn = new SqlConnection(connStr))

            using (SqlCommand comm = new SqlCommand(dbCommand, conn))

            {
                comm.Parameters.AddWithValue("@userID", userID);
                comm.Parameters.AddWithValue("@caption", caption);
                comm.Parameters.AddWithValue("@amount", amount);
                comm.Parameters.AddWithValue("@actType", actType);
                comm.Parameters.AddWithValue("@createDate", DateTime.Now);
                comm.Parameters.AddWithValue("@body", body);
                comm.Parameters.AddWithValue("@id", ID);


                try
                {
                    conn.Open();
                    int effectRows = comm.ExecuteNonQuery();

                    if (effectRows == 1)

                        return true;

                    else
                        return false;
                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);
                    return false;
                }

            }
        }

        /// <summary>
        /// 刪除流水帳
        /// </summary>
        /// <param name="ID"></param>
        public static void DeleteAccounting(int ID)
        {


            string connStr = DBHelper.GetConnectionString();
            string dbCommand =
                    $@"DELETE [Accounting]
               
                    WHERE 
                            ID = @id
       
             ";

            using (SqlConnection conn = new SqlConnection(connStr))

            using (SqlCommand comm = new SqlCommand(dbCommand, conn))

            {

                comm.Parameters.AddWithValue("@id", ID);


                try
                {
                    conn.Open();
                    comm.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    Logger.WriteLog(ex);

                }

            }
        }

    }
}
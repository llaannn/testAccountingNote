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
    public class DBHelper
    {
        /// <summary>
        /// 建立連線字串
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString()
        {
            string val = ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString;
            return val;
        }
        /// <summary>
        /// 取得使用者列表
        /// </summary>
        /// <param name="id"></param>
        /// <param name="userID"></param>
        /// <returns></returns>
        public static DataTable ReadDataTable(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))

                {
                    //comm.Parameters.AddWithValue("@userID", userID);
                    comm.Parameters.AddRange(list.ToArray());

                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    return dt;

                }
            }
        }


        public static DataRow ReadDataRow(string connStr, string dbcommand, List<SqlParameter> list)
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbcommand, conn))

                {
                    //comm.Parameters.AddWithValue("@id", id);
                    //comm.Parameters.AddWithValue("@userID", userID);//不窺探他人資料
                    comm.Parameters.AddRange(list.ToArray());



                    conn.Open();
                    var reader = comm.ExecuteReader();

                    DataTable dt = new DataTable();
                    dt.Load(reader);

                    if (dt.Rows.Count == 0)
                        return null;
                    return dt.Rows[0];

                }


            }

        }
        public static int ModifyData(string connStr, string dbCommand, List<SqlParameter> list)//本來為void後來改為int
        {
            using (SqlConnection conn = new SqlConnection(connStr))
            {
                using (SqlCommand comm = new SqlCommand(dbCommand, conn))

                {
                    //comm.Parameters.AddWithValue("@id", ID);

                    comm.Parameters.AddRange(list.ToArray());
                    conn.Open();
                    //comm.ExecuteNonQuery()原先刪除到這裡截止這裡開始合併更新功能
                    int effectRowCount = comm.ExecuteNonQuery();
                    return effectRowCount;
                }
            }
        }
    }
}

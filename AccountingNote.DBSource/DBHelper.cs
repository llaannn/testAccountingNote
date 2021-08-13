using System;
using System.Collections.Generic;
using System.Configuration;
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

    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Configuration;

namespace AutoBill.Utils
{
    class DBUtil
    {

        private static SqlConnection conn;

        public static SqlConnection getSQLConnection() {

            if (conn == null) {
                conn = new SqlConnection(Constants.CONNECTION_STRING);
            }

            return conn;
        }

    }
}

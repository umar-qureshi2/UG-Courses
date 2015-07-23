using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace SDA_Pro_Classes
{
    class Database_Connection
    {
        private static string con_str = "Data Source=myServerAddress;"
            + "Initial Catalog=myDataBase;User Id=myUsername;Password=myPassword;";
        private static SqlConnection _sqlcon;

        private Database_Connection()
        {

        }

        public static SqlConnection SQL_Con
        {
            get
            {
                if (_sqlcon == null)
                {
                    _sqlcon = new SqlConnection(con_str);
                }
                return _sqlcon;
            }
        }

        public static bool isOpen
        {
            get
            {
                if (_sqlcon != null && _sqlcon.State == ConnectionState.Open)
                {
                    return true;
                }
                return false;
            }
        }
    }
}

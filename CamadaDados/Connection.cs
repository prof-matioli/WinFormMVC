using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace Model
{
    class Connection
    {
        public static String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static SqlConnection SqlCon = new SqlConnection(conString);

    }
}

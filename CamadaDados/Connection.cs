using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dados
{
    class Connection
    {
        public static String conString = ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        public static SqlConnection SqlCon = new SqlConnection(conString);
    }
}

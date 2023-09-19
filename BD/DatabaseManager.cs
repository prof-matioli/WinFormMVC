using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BD
{
    class DatabaseManager
    {
        string connectionString =
        ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString;
        SqlConnection conn;
        SqlDataAdapter adapter;
        SqlCommandBuilder builder;
        public DatabaseManager()
        {
            conn = new SqlConnection(connectionString);
        }

        public DataTable FillData(string command)
        {
            if (command.Trim().Length < 0)
                throw new Exception("Command text is empty");
            SqlDataAdapter _ad = new SqlDataAdapter(command, conn);
            DataTable dt = new DataTable();
            if (conn.State == ConnectionState.Closed)
                conn.Open();
            _ad.Fill(dt);
            adapter = _ad;
            builder = new SqlCommandBuilder(adapter);
            adapter.InsertCommand = builder.GetInsertCommand();
            adapter.UpdateCommand = builder.GetUpdateCommand();
            adapter.DeleteCommand = builder.GetDeleteCommand();

            return dt;
        }
        public int UpdateData(DataTable dt)
        {
            if (adapter == null)
                throw new Exception("Parameter adapter is null");
            return adapter.Update(dt);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Driving.Models
{
    internal class Database
    {

        SqlConnection conn = new SqlConnection("Data Source=DESKTOP-23GPLJV;Initial Catalog=SRS;Integrated Security=True");

        public void openConnection()
        {
            if(conn.State == System.Data.ConnectionState.Closed)
                conn.Open();
        }

        public void closeConnection()
        {
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
        }

        public SqlConnection GetConnection()
        {
            return conn;
        }



    }
}

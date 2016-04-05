using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;
using System.Threading.Tasks;
using MySql.Data;
using MySql.Web;
using MySql.Data.MySqlClient;

namespace Game1
{
    class Connect
    {
        MySql.Data.MySqlClient.MySqlConnection conn;
        string myConnectionString = null;
        String sql = null;
        public Connect()
        {
            Console.WriteLine("We are here");
          
            myConnectionString = "server=89.236.61.189;database=nyancat;uid=remote_user;pwd=PASSWORD;";

            try
            {
                conn = new MySql.Data.MySqlClient.MySqlConnection();
                conn.ConnectionString = myConnectionString;
                conn.Open();

            }
            catch (MySql.Data.MySqlClient.MySqlException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        public void RunSQLStatement(String sql)
        {
            MySqlCommand cmd = new MySqlCommand(sql, conn);
            MySqlDataReader rdr = cmd.ExecuteReader();

            while (rdr.Read())
            {
                Console.WriteLine(rdr[0]);
            }
        }
    }
}

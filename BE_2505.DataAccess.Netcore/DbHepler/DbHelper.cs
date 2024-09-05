using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BE_2505.DataAccess.Netcore.DbHepler
{
    public static class DbHelper
    {
        public static SqlConnection GetSqlConnection()
        {
            SqlConnection connection;
            try
            {
                string str = "Data Source=DESKTOP-IFRSV3F;Initial Catalog=BE_2505_DB;Integrated Security=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;TrustServerCertificate=True";
                connection = new SqlConnection(str);
                if(connection.State == System.Data.ConnectionState.Closed)
                {
                    connection.Open();
                }
            }
            catch (Exception ex)
            {

                throw;
            }

            return connection;
        }
    }
}

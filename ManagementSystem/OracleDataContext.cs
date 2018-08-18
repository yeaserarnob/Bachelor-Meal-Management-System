using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace ManagementSystem
{
    public class OracleDataContext
    {
        private static String connectionString = ConfigurationManager.ConnectionStrings["OracleConnectionString"].ConnectionString;

        public static OracleConnection GetConnection()
        {
            return new OracleConnection(connectionString);
        }
    }
}
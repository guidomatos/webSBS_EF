using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace SBS.Infrastructure.Connection.Utility
{
    public class ConnectionManager
    {
        protected static IConfiguration _dapperConfiguration;
        public ConnectionManager(IConfiguration _configuration)
        {
            _dapperConfiguration = _configuration;
        }
        //static internal IDbConnection GetConnection()
        //{
        //    string connectionStringName = "ConnectionStrings:ConexionSvr_Default";

        //    var connectionString = _dapperConfiguration[connectionStringName];

        //    if (string.IsNullOrEmpty(connectionString))
        //        throw new ArgumentException("El parámetro connectionString se encuentra nulo.");

        //    return new OracleConnection(connectionString);
        //}
    }
}

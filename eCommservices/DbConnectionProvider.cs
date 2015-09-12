using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Practices.EnterpriseLibrary.Data;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data.Configuration;
using System.Configuration;
namespace eCommservices
{
    public class DbConnectionProvider
    {
        #region Fields

        // static holder for instance, need to use lambda to construct since constructor private
        private static readonly Lazy<DbConnectionProvider> _instance
          = new Lazy<DbConnectionProvider>(() => new DbConnectionProvider());

        public SqlDatabase DbConn { get; set; }
        //public static readonly string connectionStringName = GetConnectionStringName();
        #endregion

        #region PrivateMethods

        private DbConnectionProvider()
        {
            var factory = new DatabaseProviderFactory();
            DbConn = (SqlDatabase)factory.Create(GetConnectionStringName("dataConfiguration"));
           
        }

        private static string GetConnectionStringName(string configName)
        {
            var dbSettings = (DatabaseSettings)ConfigurationManager.GetSection(configName);
            var connectionString = dbSettings.DefaultDatabase;
            return connectionString;
        }


        #endregion

        #region PublicMethods
        public static DbConnectionProvider Instance
        {
            get
            {
                return _instance.Value;
            }
        }
        #endregion
    }
}
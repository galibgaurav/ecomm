using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Diagnostics;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;

namespace eCommservices
{
    public abstract class BaseDataAccess
    {
        public SqlDatabase DbConn { get; set; }
        protected BaseDataAccess()
        {
            try
            {
                DbConn = DbConnectionProvider.Instance.DbConn;
               
            }
            catch (Exception ex)
            {
                //LoggingHelper.LogException("DAL:BaseDataAccess", "", TraceEventType.Error, ex);
                throw;
            }
        }

    }

}
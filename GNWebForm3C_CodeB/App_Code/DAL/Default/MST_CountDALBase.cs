using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel.Channels;
using System.Web;

/// <summary>
/// Summary description for MST_CountDALBase
/// </summary>

namespace GNForm3C.DAL
{
    public class MST_CountDALBase : DataBaseConfig
    {
        #region Properties

        private string _Message;
        public string Message
        {
            get
            {
                return _Message;
            }
            set
            {
                _Message = value;
            }
        }

        #endregion Properties
        public MST_CountDALBase()
        {

        }

        public DataTable SelectCount(SqlInt32 HospitalID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST__DSB_Count");
                sqlDB.AddInParameter(dbCMD, "@HospitalID", SqlDbType.Int, HospitalID);

                DataTable dtCount = new DataTable("PR_MST__DSB_Count");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtCount);

                return dtCount;
            }
            catch(SqlException ex)
            {
                Message = ex.Message;
                if (SQLDataExceptionHandler(ex))
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }
            catch (Exception ex)
            {
                Message = ex.Message;
                if (ExceptionHandler(ex))
                {
                    throw;
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
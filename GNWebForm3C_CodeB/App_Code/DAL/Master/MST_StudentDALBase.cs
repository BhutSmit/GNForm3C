using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Data;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_StudentDALBase
/// </summary>

namespace GNForm3C.DAL
{
    public class MST_StudentDALBase : DataBaseConfig
    {

        #region Property

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

        #endregion

        #region Select

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString StudentName, SqlString Enrollment, SqlInt32 RollNo, SqlInt32 CurrentSem, SqlString EmailInstitude, SqlString EmailPersonal, SqlString Gender, SqlInt32 UserID)
        {
            TotalRecords = 0;
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectPage");
                sqlDB.AddInParameter(dbCMD, "@PageOffset", SqlDbType.Int, PageOffset);
                sqlDB.AddInParameter(dbCMD, "@PageSize", SqlDbType.Int, PageSize);
                sqlDB.AddOutParameter(dbCMD, "@TotalRecords", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.NVarChar, StudentName);
                sqlDB.AddInParameter(dbCMD, "@Enrollment", SqlDbType.NVarChar, Enrollment);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitude", SqlDbType.NVarChar, EmailInstitude);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.NVarChar, EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, UserID);

                DataTable dtMST_Hospital = new DataTable("PR_MST_Student_SelectPage");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

                TotalRecords = Convert.ToInt32(dbCMD.Parameters["@TotalRecords"].Value);

                return dtMST_Hospital;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return null;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return null;
            }
        }

        #endregion

    }
}
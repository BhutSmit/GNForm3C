using GNForm3C.DAL;
using Microsoft.Practices.EnterpriseLibrary.Data.Sql;
using Microsoft.Practices.EnterpriseLibrary.Data;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Data;
using GNForm3C.ENT;
using System.Data.SqlTypes;

/// <summary>
/// Summary description for Demo_DALBase
/// </summary>
namespace GNForm3C.DAL
{
    public class Demo_DALBase :DataBaseConfig
    {
        private string Message;

        public DataTable SelectAll()
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Select");

                DataTable dt_Demo = new DataTable("PR_Demo_Select");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dt_Demo);

                return dt_Demo;
            }
            catch (SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                {
                    throw;
                }
                return null;

            }
        }

        public DataTable SelectByPK(SqlInt32 Id)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@Id", SqlDbType.Int, Id);
                DataTable dt_Demo = new DataTable("PR_Demo_SelectByPK");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dt_Demo);

                return dt_Demo;
            }
            catch (SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                {
                    throw;
                }
                return null;

            }
        }

        public DataTable Insert(String Name)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Insert");

                sqlDB.AddInParameter(dbCMD, "@Name", SqlDbType.NVarChar, Name);
                DataTable dt_Demo = new DataTable("PR_Demo_Insert");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dt_Demo);

                return dt_Demo;
            }
            catch (SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                {
                    throw;
                }
                return null;

            }
        }

        public DataTable Update(SqlInt32 Id, string Name)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@Id", SqlDbType.Int, Id);
                sqlDB.AddInParameter(dbCMD, "@name", SqlDbType.VarBinary, Name);
                DataTable dt_Demo = new DataTable("PR_Demo_SelectByPK");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dt_Demo);

                return dt_Demo;
            }
            catch (SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                {
                    throw;
                }
                return null;

            }
        }
    }
}

//try
//{
//    SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
//    DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_Demo_Select");

//    DataTable dt_Demo = new DataTable("PR_Demo_Select");

//    DataBaseHelper DBH = new DataBaseHelper();
//    DBH.LoadDataTable(sqlDB, dbCMD, dt_Demo);

//    return dt_Demo;
//}
//catch (SqlException ex)
//{
//    Message = SQLDataExceptionMessage(ex);
//    if (SQLDataExceptionHandler(ex))
//    {
//        throw;
//    }
//    return null;

//}
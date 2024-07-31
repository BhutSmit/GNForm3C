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
using GNForm3C.ENT;
using Microsoft.ReportingServices.ReportProcessing.ReportObjectModel;

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

        #region InsertOperation

        public Boolean Insert(MST_StudentENT ent_MST_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Insert");

                sqlDB.AddOutParameter(dbCMD, "@StudentID", SqlDbType.Int, 4);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.NVarChar, ent_MST_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@Enrollment", SqlDbType.NVarChar, ent_MST_Student.Enrollment);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, ent_MST_Student.RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, ent_MST_Student.CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitude", SqlDbType.NVarChar, ent_MST_Student.EmailInstitude);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.NVarChar, ent_MST_Student.EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@BirthDate", SqlDbType.DateTime, ent_MST_Student.Birthdate);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, ent_MST_Student.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, ent_MST_Student.Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, ent_MST_Student.UserID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                ent_MST_Student.StudentID = (SqlInt32)Convert.ToInt32(dbCMD.Parameters["@StudentID"].Value);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_StudentENT ent_MST_Student)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Update");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, ent_MST_Student.StudentID);
                sqlDB.AddInParameter(dbCMD, "@StudentName", SqlDbType.NVarChar, ent_MST_Student.StudentName);
                sqlDB.AddInParameter(dbCMD, "@Enrollment", SqlDbType.NVarChar, ent_MST_Student.Enrollment);
                sqlDB.AddInParameter(dbCMD, "@RollNo", SqlDbType.Int, ent_MST_Student.RollNo);
                sqlDB.AddInParameter(dbCMD, "@CurrentSem", SqlDbType.Int, ent_MST_Student.CurrentSem);
                sqlDB.AddInParameter(dbCMD, "@EmailInstitude", SqlDbType.NVarChar, ent_MST_Student.EmailInstitude);
                sqlDB.AddInParameter(dbCMD, "@EmailPersonal", SqlDbType.NVarChar, ent_MST_Student.EmailPersonal);
                sqlDB.AddInParameter(dbCMD, "@BirthDate", SqlDbType.DateTime, ent_MST_Student.Birthdate);
                sqlDB.AddInParameter(dbCMD, "@ContactNo", SqlDbType.VarChar, ent_MST_Student.ContactNo);
                sqlDB.AddInParameter(dbCMD, "@Gender", SqlDbType.NVarChar, ent_MST_Student.Gender);
                sqlDB.AddInParameter(dbCMD, "@UserID", SqlDbType.Int, ent_MST_Student.UserID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch (SqlException sqlex)
            {
                Message = SQLDataExceptionMessage(sqlex);
                if (SQLDataExceptionHandler(sqlex))
                    throw;
                return false;
            }
            catch (Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion UpdateOperation

        #region SelectPK

        public MST_StudentENT SelectByPK(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectByPK");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                MST_StudentENT entMST_Student = new MST_StudentENT();
                DataBaseHelper DBH = new DataBaseHelper();
                using (IDataReader dr = DBH.ExecuteReader(sqlDB, dbCMD))
                {
                    while (dr.Read())
                    {
                        if (!dr["StudentID"].Equals(System.DBNull.Value))
                            entMST_Student.StudentID = Convert.ToInt32(dr["StudentID"]);

                        if (!dr["StudentName"].Equals(System.DBNull.Value))
                            entMST_Student.StudentName = Convert.ToString(dr["StudentName"]);

                        if (!dr["Enrollment"].Equals(System.DBNull.Value))
                            entMST_Student.Enrollment = Convert.ToString(dr["Enrollment"]);

                        if (!dr["RollNo"].Equals(System.DBNull.Value))
                            entMST_Student.RollNo = Convert.ToInt32(dr["RollNo"]);

                        if (!dr["CurrentSem"].Equals(System.DBNull.Value))
                            entMST_Student.CurrentSem = Convert.ToInt32(dr["CurrentSem"]);

                        if (!dr["EmailInstitude"].Equals(System.DBNull.Value))
                            entMST_Student.EmailInstitude = Convert.ToString(dr["EmailInstitude"]);

                        if (!dr["EmailPersonal"].Equals(System.DBNull.Value))
                            entMST_Student.EmailPersonal = Convert.ToString(dr["EmailPersonal"]);

                        if (!dr["ContactNo"].Equals(System.DBNull.Value))
                            entMST_Student.ContactNo = Convert.ToString(dr["ContactNo"]);

                        if (!dr["Gender"].Equals(System.DBNull.Value))
                            entMST_Student.Gender = Convert.ToString(dr["Gender"]);

                        if (!dr["UserID"].Equals(System.DBNull.Value))
                            entMST_Student.UserID = Convert.ToInt32(dr["UserID"]);

                        if (!dr["Birthdate"].Equals(System.DBNull.Value))
                            entMST_Student.Birthdate = Convert.ToDateTime(dr["Birthdate"]);

                        if (!dr["Created"].Equals(System.DBNull.Value))
                            entMST_Student.Created = Convert.ToDateTime(dr["Created"]);

                        if (!dr["Modified"].Equals(System.DBNull.Value))
                            entMST_Student.Modified = Convert.ToDateTime(dr["Modified"]);
                    }
                }
                return entMST_Student;
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

        #region Delete

        public Boolean Delete(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_Delete");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.ExecuteNonQuery(sqlDB, dbCMD);

                return true;
            }
            catch(SqlException ex)
            {
                Message = SQLDataExceptionMessage(ex);
                if (SQLDataExceptionHandler(ex))
                    throw;
                return false;
            }
            catch(Exception ex)
            {
                Message = ExceptionMessage(ex);
                if (ExceptionHandler(ex))
                    throw;
                return false;
            }
        }

        #endregion

        #region Select View proc

        public DataTable SelectView(SqlInt32 StudentID)
        {
            try
            {
                SqlDatabase sqlDB = new SqlDatabase(myConnectionString);
                DbCommand dbCMD = sqlDB.GetStoredProcCommand("PR_MST_Student_SelectView");

                sqlDB.AddInParameter(dbCMD, "@StudentID", SqlDbType.Int, StudentID);

                DataTable dtMST_Hospital = new DataTable("PR_MST_Student_SelectView");

                DataBaseHelper DBH = new DataBaseHelper();
                DBH.LoadDataTable(sqlDB, dbCMD, dtMST_Hospital);

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
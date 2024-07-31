using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_StudentBAlBase
/// </summary>

namespace GNForm3C.BAL
{
    public class MST_StudentBALBase
    {
        #region Private Fields

        private string _Message;

        #endregion Private Fields

        #region Public Properties

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

        #endregion Public Properties

        #region InsertOPeration
        public Boolean Insert(MST_StudentENT entMST_Student)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            if (dalMST_Student.Insert(entMST_Student))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Student.Message;
                return false;
            }
        }

        #endregion InsertOperation

        #region UpdateOperation

        public Boolean Update(MST_StudentENT entMST_Student)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            if (dalMST_Student.Update(entMST_Student))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Student.Message;
                return false;
            }
        }

        #endregion UpdateOperation

        #region DeleteOperation

        public Boolean Delete(SqlInt32 StudentID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            if (dalMST_Student.Delete(StudentID))
            {
                return true;
            }
            else
            {
                this.Message = dalMST_Student.Message;
                return false;
            }
        }

        #endregion DeleteOperation

        #region SelectOperation

        public MST_StudentENT SelectByPK(SqlInt32 StudentID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectByPK(StudentID);
        }

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString StudentName, SqlString Enrollment, SqlInt32 RollNo, SqlInt32 CurrentSem, SqlString EmailInstitude, SqlString EmailPersonal, SqlString Gender, SqlInt32 UserID)
        {
            MST_StudentDAL dal_MST_Student = new MST_StudentDAL();
            return dal_MST_Student.SelectPage(PageOffset, PageSize, out TotalRecords, StudentName, Enrollment, RollNo, CurrentSem, EmailInstitude, EmailPersonal, Gender, UserID);
        }

        public DataTable SelectView(SqlInt32 StudentID)
        {
            MST_StudentDAL dalMST_Student = new MST_StudentDAL();
            return dalMST_Student.SelectView(StudentID);
        }


        #endregion SelectOperation
    }
}
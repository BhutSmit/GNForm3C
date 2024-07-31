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
    public class MST_StudentBAlBase
    {
        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlString StudentName, SqlString Enrollment, SqlInt32 RollNo, SqlInt32 CurrentSem, SqlString EmailInstitude, SqlString EmailPersonal, SqlString Gender, SqlInt32 UserID)
        {
            MST_StudentBAL bal_MST_Student = new MST_StudentBAL();
            return bal_MST_Student.SelectPage(PageOffset, PageSize, out TotalRecords, StudentName, Enrollment, RollNo, CurrentSem, EmailInstitude, EmailPersonal, Gender, UserID);
        }
    }
}
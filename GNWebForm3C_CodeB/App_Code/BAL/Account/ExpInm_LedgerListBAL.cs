using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ExpInm_LedgerList_BAL
/// </summary>

namespace GNForm3C.BAL
{
    public class ExpInm_LedgerList_BAL : ExpInm_LedgerListBALBase
    {

        public DataTable SelectPage(SqlInt32 PageOffset, SqlInt32 PageSize, out Int32 TotalRecords, SqlDateTime FromDate, SqlDateTime ToDate)
        {
            ExpInm_LedgerListDAL dal_ExpInm_LedgerList = new ExpInm_LedgerListDAL();
            return dal_ExpInm_LedgerList.SelectPage(PageOffset, PageSize, out TotalRecords, FromDate, ToDate);
        }
        
    }
}
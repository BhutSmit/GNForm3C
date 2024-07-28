using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_CountBALBase
/// </summary>

namespace GNForm3C.BAL
{
    public class MST_CountBALBase
    {
        public MST_CountBALBase()
        {

        }

        public DataTable SelectCount(SqlInt32 HospitalID)
        {
            MST_CountDAL dal_MST_Count = new MST_CountDAL();
            DataTable dt = dal_MST_Count.SelectCount(HospitalID);

            return dt;
        }

    }
}
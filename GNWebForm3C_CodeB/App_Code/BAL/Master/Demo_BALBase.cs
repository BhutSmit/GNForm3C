using GNForm3C.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Demo_BALBase
/// </summary>

namespace GNForm3C.BAL
{
    public class Demo_BALBase
    {

        public DataTable SelectAll()
        {
            Demo_DAL dal_Demo = new Demo_DAL();
            return dal_Demo.SelectAll();
        }

        public DataTable SelectByPK(SqlInt32 Id)
        {
            Demo_DAL dal_Demo = new Demo_DAL();
            return dal_Demo.SelectByPK(Id);
        }

        public DataTable Insert(String Name)
        {
            Demo_DAL dal_Demo = new Demo_DAL();
            return dal_Demo.Insert(Name);
        }

        public DataTable Update(SqlInt32 Id, string Name)
        {
            Demo_DAL dal_Demo = new Demo_DAL();
            return dal_Demo.Update(Id, Name);
        }

    }
}
using GNForm3C.DAL;
using GNForm3C.ENT;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_PatientBALBase
/// </summary>
namespace GNForm3C.BAL
{
    public class MST_PatientBALBase
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
        #endregion
        public object InsertPatient(MST_GNPatientENT entMST_Patient)
        {
            //ACC_GNTransactionDAL dalACC_GNTransaction = new ACC_GNTransactionDAL();
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.InsertPatient(entMST_Patient);
        }

        public DataTable SelectView(SqlInt32 PatientID)
        {
            MST_PatientDAL dalMST_Patient = new MST_PatientDAL();
            return dalMST_Patient.SelectView(PatientID);
        }
    }
}
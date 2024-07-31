using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MST_StudemtENTBase
/// </summary>

namespace GNForm3C.ENT
{
    public class MST_StudentENTBase
    {
        #region Property

        protected SqlInt32 _StudentID;
        public SqlInt32 StudentID
        {
            get
            {
                return _StudentID;
            }
            set
            {
                _StudentID = value;
            }
        }

        protected SqlString _StudentName;
        public SqlString StudentName
        {
            get
            {
                return _StudentName;
            }
            set
            {
                _StudentName = value;
            }
        }

        protected SqlString _Enrollment;
        public SqlString Enrollment
        {
            get
            {
                return _Enrollment;
            }
            set
            {
                _Enrollment = value;
            }
        }

        protected SqlInt32 _RollNo;
        public SqlInt32 RollNo
        {
            get
            {
                return _RollNo;
            }
            set
            {
                _RollNo = value;
            }
        }

        protected SqlInt32 _CurrentSem;
        public SqlInt32 CurrentSem
        {
            get
            {
                return _CurrentSem;
            }
            set
            {
                _CurrentSem = value;
            }
        }

        protected SqlString _EmailInstitude;
        public SqlString EmailInstitude
        {
            get
            {
                return _EmailInstitude;
            }
            set
            {
                _EmailInstitude = value;
            }
        }

        protected SqlString _EmailPersonal;
        public SqlString EmailPersonal
        {
            get
            {
                return _EmailPersonal;
            }
            set
            {
                _EmailPersonal = value;
            }
        }

        protected SqlDateTime _Birthdate;
        public SqlDateTime Birthdate
        {
            get
            {
                return _Birthdate;
            }
            set
            {
                _Birthdate = value;
            }
        }

        protected SqlString _ContactNo;
        public SqlString ContactNo
        {
            get
            {
                return _ContactNo;
            }
            set
            {
                _ContactNo = value;
            }
        }

        protected SqlString _Gender;
        public SqlString Gender
        {
            get
            {
                return _Gender;
            }
            set
            {
                _Gender = value;
            }
        }

        protected SqlInt32 _UserID;
        public SqlInt32 UserID
        {
            get
            {
                return _UserID;
            }
            set
            {
                _UserID = value;
            }
        }

        protected SqlDateTime _Created;
        public SqlDateTime Created
        {
            get
            {
                return _Created;
            }
            set
            {
                _Created = value;
            }
        }

        protected SqlDateTime _Modified;
        public SqlDateTime Modified
        {
            get
            {
                return _Modified;
            }
            set
            {
                _Modified = value;
            }
        }


        #endregion
    }
}
//public class MST_StudemtENTBase
//{
    
//}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class Operator
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private Int64 _intUserId;
        private string _strOperatorName;
        private string _strUserName;
        private string _strPassword;
        private byte _bytStatusId;
        private DateTime _datCreatedDate;
        private DateTime _datUpdatedDate;

        #endregion Declarations

        #region Properties

        public bool ObjectChanged
        {
            get { return this._boolObjectChanged; }
            set { this._boolObjectChanged = value; }
        }

        public Int64 ID
        {
            get { return this._intID; }
            set { this._intID = value; }
        }

        public Int64 UserId
        {
            get { return this._intUserId; }
            set { this._intUserId = value; }
        }

        public Int64 RowNumber
        {
            get;
            set;
        }

        public string OperatorName
        {
            get { return this._strOperatorName; }
            set { this._strOperatorName = value; }
        }

        public string UserName
        {
            get { return this._strUserName; }
            set { this._strUserName = value; }
        }

        public string Password
        {
            get { return this._strPassword; }
            set { this._strPassword = value; }
        }

        public byte StatusId
        {
            get { return this._bytStatusId; }
            set { this._bytStatusId = value; }
        }

        public DateTime CreatedDate
        {
            get { return this._datCreatedDate; }
            set { this._datCreatedDate = value; }
        }

        public DateTime UpdatedDate
        {
            get { return this._datUpdatedDate; }
            set { this._datUpdatedDate = value; }
        }

        #endregion Properties
    }
}
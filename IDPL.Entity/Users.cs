using System;
using System.Collections.Generic;

namespace Core.Entity
{
    public class Users
    {
        #region Declarations

        private bool _boolObjectChanged;
        private Int64 _intID;
        private string _strUserName;
        private string _strPassword;
        private string _strFirstName;
        private string _strLastName;
        private int _intSchoolID;
        private string _strAlternateEmail;
        private string _strPhoneNumber;
        private string _strProfilePicture;
        private int _intRoleID;
        private int _intParentID;
        private int _intLanguageId;
        private bool _boolIsEmailVerified;
        private string _EmailVerficationCode;
        private DateTime _datEmailVerificationDate;
        private byte _bytStatusId;
        private DateTime _datCreatedDate;
        private DateTime _datUpdatedDate;

        public string JoiningDate { get; set; }
        public string ClassName { get; set; }
        public string FullName { get; set; }
        public string UserId { get; set; }
        public int Age { get; set; }
        public string GradeMasterID { get; set; }
        public string GradeName { get; set; }
        public string Address { get; set; }
        public string DateOfBirth { get; set; }
        public Int64 ClassID { get; set; }

        public int StudentDetailsID { get; set; }
        public string ProfilePicture { get; set; }
        public string ProfilePictureName { get; set; }
        public string ProfilePictureExtention { get; set; }
        public string LoginCode { get; set; }
        public string FCMToken { get; set; }
        public string SchoolName { get; set; }
        public string StudentName { get; set; }
        public int IsPrimaryContact { get; set; }
        public Int64 StudentCount { get; set; }
        public Int64 TeacherCount { get; set; }
        public Int64 ParentCount { get; set; }

        public string AccessToken { get; set; }
        public string RefreshToken { get; set; }
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

        public string UserName
        {
            get { return this._strUserName; }
            set { this._strUserName = value; }
        }

        public string DeviceID
        {
            get;
            set;
        }

        public string Password
        {
            get { return this._strPassword; }
            set { this._strPassword = value; }
        }

        public string FirstName
        {
            get { return this._strFirstName; }
            set { this._strFirstName = value; }
        }

        public string LastName
        {
            get { return this._strLastName; }
            set { this._strLastName = value; }
        }

        public int SchoolID
        {
            get { return this._intSchoolID; }
            set { this._intSchoolID = value; }
        }
        public int SchoolHQID
        {
            get ;
            set;
        }

        public string AlternateEmail
        {
            get { return this._strAlternateEmail; }
            set { this._strAlternateEmail = value; }
        }

        public string PhoneNumber
        {
            get { return this._strPhoneNumber; }
            set { this._strPhoneNumber = value; }
        }



        public int RoleID
        {
            get { return this._intRoleID; }
            set { this._intRoleID = value; }
        }

        public int ParentID
        {
            get { return this._intParentID; }
            set { this._intParentID = value; }
        }

        public int LanguageId
        {
            get { return this._intLanguageId; }
            set { this._intLanguageId = value; }
        }

        public bool IsEmailVerified
        {
            get { return this._boolIsEmailVerified; }
            set { this._boolIsEmailVerified = value; }
        }

        public DateTime EmailVerificationDate
        {
            get { return this._datEmailVerificationDate; }
            set { this._datEmailVerificationDate = value; }
        }

        public string EmailVerficationCode
        {
            get { return this._EmailVerficationCode; }
            set { this._EmailVerficationCode = value; }
        }

        public byte StatusId
        {
            get { return this._bytStatusId; }
            set { this._bytStatusId = value; }
        }
        public int IsBulkUpload { get; set; }
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

        public string FUserName { get; set; }
        public string FPassword { get; set; }
        public string LoginMode { get; set; }
        public byte IsAdded
        {
            get;
            set;
        }
        public string relation
        {
            get;
            set;
        }
        public byte Document { get; set; }
        public byte EnquiryManagement { get; set; }
        #endregion Properties
    }
}

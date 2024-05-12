namespace Core.Business.DataAccess.Constants
{
    public class UsersDBFields
    {
        public static string IU_Flag = "IU_Flag";

        public static string TableNameVal = "Users";
        public static string ID = "ID";
        public static string UsersID = "ID";
        public static string UserName = "UserName";
        public static string Password = "Password";
        public static string FirstName = "FirstName";
        public static string LastName = "LastName";
        public static string SchoolID = "SchoolID";
        public static string AlternateEmail = "AlternateEmail";
        public static string PhoneNumber = "PhoneNumber";
        public static string ProfilePicture = "ProfilePicture";
        public static string RoleID = "RoleID";
        public static string ParentID = "ParentID";
        public static string LanguageId = "LanguageId";
        public static string IsEmailVerified = "IsEmailVerified";
        public static string EmailVerficationCode = "EmailVerficationCode";
        public static string EmailVerificationDate = "EmailVerificationDate";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
        public static string DateOfBirth = "DateOfBirth";
        public static string ContactNumber = "ContactNumber";
        public static string LoginMode = "LoginMode";
        public static string DeviceID = "DeviceID";
        public static string type = "type";
        public static string relation = "relation";
        public static string ClassID = "ClassID";
        public static string Address = "Address";
        public static string Age = "Age";
        public static string ClassName = "ClassName";
        public static string JoiningDate = "JoiningDate";
        public static string FullName = "FullName";
        public static string StudentDetailsID = "StudentDetailsID";
        public static string GradeMasterID = "GradeMasterID";
        public static string GradeName = "GradeName";
        public static string Source = "Source";
        public static string Email = "Email";

        public static string userRole = "userRole";
        public static string LoginCode = "LoginCode";
        public static string FCMToken = "FCMToken";
        public static string SchoolName = "SchoolName";
        public static string FUserName = "FUserName";
        public static string FPassword = "FPassword";
        public static string StudentName = "StudentName";
        public static string IsPrimaryContact = "IsPrimaryContact";
        public static string Document = "Document";
        public static string EnquiryManagement = "EnquiryManagement";
        public static string ExternalID = "ExternalID";
        public static string EntityType = "EntityType";

        public static string Teacher = "Teacher";
        public static string Parent = "Parent";
        public static string Student = "Student";

        public static string TeacherCount = "TeacherCount";
        public static string ParentCount = "ParentCount";
        public static string StudentCount = "StudentCount";
        public static string startDate = "StartDate";
        public static string endDate = "EndDate";
        public static string IsAdded = "IsAdded";

        public static string ValueType = "ValueType";
        public static string Value = "Value";
        public static string RefreshToken = "RefreshToken";
        public static string SchoolHQID = "SchoolHQID";
    }

    public class UsersStoredProcedures
    {
        #region Object StoredProcedure

        #region Object StoredProcedure
        public static string Users_DeleteEnquiryStudent = "Users_DeleteEnquiryStudent";
        public static string UsersGetEnquirySchoolDetails = "UsersGetEnquirySchoolDetails";

        public static string UsersIsLastActiveStudent = "UsersIsLastActiveStudent";

        public static string UsersCountStudentForUserName = "UsersCountStudentForUserName";

        public static string Users_getClassUsersParentByClassID = "Users_getClassUsersParentByClassID";
        public static string Users_GetListRecordsOfParents = "Users_GetListRecordsOfParents";

        public static string Users_getTeacherDetailsByTeacherID = "Users_getTeacherDetailsByTeacherID";

        public static string UsersSAVE = "Users_SAVE";
        public static string UsersGetRecordById = "Users_GetRecordById";

        public static string GetUsersRecords = "Users_GetRecords";
        public static string Users_UpdateStatus = "Users_UpdateStatus";
        public static string GetUsersRecordByValue = "Users_GetRecordByValue";
        public static string GetUsersRecordByValueArray = "Users_GetRecordByValueArray";
        public static string Users_IsUserNameExists = "Users_IsUserNameExists";
        public static string Users_IsUserNameContactExists = "Users_IsUserNameContactExists";
        public static string Users_IsSchoolExist = "Users_IsSchoolExist";
        public static string Users_IsParentExists = "Users_IsParentExists";
        public static string Users_IsUserNameExists_ExceptUser = "Users_IsUserNameExists_ExceptUser";

        public static string Users_Login = "Users_Login";
        public static string Users_OTP_Login = "Users_OTP_Login";
        public static string Users_Login_AuthenticateRefreshToken = "Users_Login_AuthenticateRefreshToken";
        public static string Users_IsUserExists = "Users_IsUserExists";
        public static string SSOLogin = "SSOLogin";
        public static string IsExternalIdExist = "IsExternalIdExist";

        public static string Password_Update = "Password_Update";
        public static string ForgotPassword = "ForgotPassword";
        public static string getUserByLoginCode = "getUserByLoginCode";
        public static string getUserPasswordExist = "getUserPasswordExist";
        public static string Users_getParentDetailsByClassID = "getStudentParentDetailsByClassID";
        public static string Users_getClassTeachersByClassID = "getClassTeachersByClassID";
        public static string getParentDetailsByStudentID = "getParentDetailsByStudentID";
        public static string getParentDetailsByStudentUserID = "getParentDetailsByStudentUserID";
        public static string getParentDetailsByUserID = "getParentDetailsByUserID";

        public static string getAllUsers = "Users_getAllUsers";
        public static string getUsersCount = "Users_getUsersCount";
        public static string HQgetUsersCount = "HQ_Users_getUsersCount";
        public static string getUsersTotalCount = "Users_getUsersTotalCount";
        public static string HQ_getUsersTotalCount = "HQ_Users_getUsersTotalCount";
        public static string DocumentFolder_GetDocumentPermissionUsers = "DocumentFolder_GetDocumentPermissionUsers";
        public static string Users_getHolidayNotificationUsers = "Users_getHolidayNotificationUsers";
        public static string Users_getSchoolStudents = "Users_getSchoolStudents";
        public static string getAllUsers_ParentsTeachers = "Users_getAllUsers_ParentsTeachers";
        public static string Users_DeleteUsers = "Users_DeleteUsers";
        public static string Users_CheckExistence = "Users_CheckExistence";
        public static string Users_getRecordContactDetails = "Users_getRecordContactDetails";
        public static string Users_getRecordUsers = "Users_getRecordUsers";
        public static string UsersGetParentContactDetailsByStudentUserID = "Users_getParentContactDetailsByStudentUserID";
        public static string ClassGetByUserId = "Class_GetByUserId";

        #endregion Object StoredProcedure
        #endregion
        #region Collection StoredProcedure

        public static string UsersSearch = "Users_Search";
        public static string UsersSearchByValue = "Users_SearchByValue";
        public static string UsersSearchByValueArray = "Users_SearchByValueArray";
        public static string Users_GetDetails = "Users_GetDetails";

        #endregion Collection StoredProcedure

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";
       
    }
}
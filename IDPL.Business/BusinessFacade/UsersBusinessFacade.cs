using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.Wrapper;
using Core.Entity;
using Core.Entity.Common;
using Core.Entity.Enums;
using Core.Utility.Common;
using IDPL.Resources;
using System;
using System.Collections.Generic;

namespace Core.Business.BusinessFacade
{
    public class UsersBusinessFacade//:UniversalObject
    {
        private dynamic objdynamicWrapper;
        private UsersWrapperColletion objUsersWrapperColletion = new UsersWrapperColletion();
        private UsersWrapper objUsersWrapper = new UsersWrapper();
        private Users objEntity = new Users();
        private List<Users> _lstUsers = new List<Users>();

        private JsonMessage _jsonMessage = null;

        private static readonly string _module = "Core.Business.BusinessFacade.UsersBusinessFacade";

        public UsersBusinessFacade()
        {
        }

        public UsersBusinessFacade(dynamic WrapperType)
        {
            objdynamicWrapper = WrapperType;
        }

        public dynamic GetRecordsList()
        {
            string[,] Sort = new string[1, 2];
            if (objdynamicWrapper.GetRecords(false, Sort))
            {
                return objdynamicWrapper.Items;
            }
            return null;
        }

        public dynamic GetRecordsListByValue(string Field, String Values)
        {
            string[,] Sort = new string[1, 2];

            if (objdynamicWrapper.GetRecords(false, Sort, true, Field, Values))
            {
                return objdynamicWrapper.Items;
            }
            return null;
        }

        public List<Users> getClassUsersParentByClassID(Int64 ClassID)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getClassUsersParentByClassID(ClassID);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getClassUsersParentByClassID(ClassID:" + ClassID + ")", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public dynamic GetRecordByValue(string Field, string Values)
        {
            string[,] Sort = new string[1, 2];

            if (objdynamicWrapper.GetRecordByValue(Field, Values))
            {
                return objdynamicWrapper.objUsers;
            }
            return null;
        }

        public dynamic GetRecords(int Id)
        {
            if (objUsersWrapper.GetRecordById(Id))
            {
                return objUsersWrapper.objWrapperClass;
            }
            return null;
        }

        public dynamic GetListRecordsOfParents()
        {
            List<Users> _data = new List<Users>();
            // dynamic _data = null;
            try
            {
                _data = objUsersWrapperColletion.GetListRecordsOfParents();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetHolidayNotificationUsers()", ex.Source, ex.Message, ex);
            }

            return _data;
        }

        public dynamic GetDocumentPermissionUsers(Int64 ID, int AllTeachers, int AllParents)
        {
            List<Users> _data = new List<Users>();
            // dynamic _data = null;
            try
            {
                _data = objUsersWrapperColletion.GetDocumentPermissionUsers(ID, AllTeachers, AllParents);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDocumentPermissionUsers(ID:" + ID + ")", ex.Source, ex.Message, ex);
            }

            return _data;
        }

        public dynamic GetHolidayNotificationUsers(Int64 SchoolID, Int64 HolidayID)
        {
            List<Users> _data = new List<Users>();
            // dynamic _data = null;
            try
            {
                _data = objUsersWrapperColletion.GetHolidayNotificationUsers(SchoolID, HolidayID);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetHolidayNotificationUsers(SchoolID:" + SchoolID + ")", ex.Source, ex.Message, ex);
            }

            return _data;
        }

        public Int64 Save(dynamic objEntity)
        {
            try
            {
                objUsersWrapper.objWrapperClass = objEntity;

                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objUsersWrapper.Save(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                {
                    Int64 ID = 0;
                    if (long.TryParse(TransObj.ReturnID, out ID) && ID > 0)
                    {
                        objEntity.ID = Int64.Parse(ID.ToString());
                    }
                    return objEntity.ID;
                }
                else
                    return 0;
            }
            catch (Exception ex)
            {
                return 0;
            }
            finally { }
        }

        public Users Authenticate(string username, string password, string LoginMode)
        {
            try
            {
                return objUsersWrapper.Authenticate(username, password, LoginMode);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate(username=" + username + ", password=" + password + ",LoginMode:" + LoginMode + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

        public Users AuthenticateOTP(string mobileNumber, Int64 otp, string LoginMode)
        {
            try
            {
                return objUsersWrapper.AuthenticateOTP(mobileNumber, otp, LoginMode);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "AuthenticateOTP(mobileNumber=" + mobileNumber + ", otp=" + otp + ",LoginMode:" + LoginMode + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

        public Users AuthenticateRefreshToken(string username, string loginMode, string refreshToken = "")
        {
            try
            {
                return objUsersWrapper.AuthenticateRefreshToken(username, loginMode, refreshToken);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "AuthenticateRefreshToken(username=" + username + ",LoginMode:" + loginMode + ")", ex.Source, ex.Message, ex);
            }
            return null;
        }

        public Int64 getUserByLoginCode(string LoginCode, string username)
        {
            Int64 return_val = 0;

            try
            {
                objUsersWrapper = new UsersWrapper();
                objEntity = objUsersWrapper.getUserByLoginCode(LoginCode, username);

                if (objEntity != null && objEntity.ID > 0)
                    return_val = Int64.Parse(objEntity.ID.ToString());
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserByLoginCode(LoginCode=" + LoginCode + ")", ex.Source, ex.Message, ex);
                return_val = 0;
            }

            return return_val;
        }

        public bool getUserPasswordExist(string password, string username)
        {
            bool return_val = false;

            try
            {
                objUsersWrapper = new UsersWrapper();
                objEntity = objUsersWrapper.getUserPasswordExist(password, username);

                if (objEntity != null && objEntity.ID > 0)
                    return_val = true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserPasswordExist(password=" + password + ",username=" + username + ")", ex.Source, ex.Message, ex);
                return_val = false;
            }

            return return_val;
        }

        public JsonMessage IsUserIdExist(string UserName, long ID)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(UserName))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsUserIdExist(UserName, ID);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, objEntity);
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_emilIdInUse, KeyEnums.JsonMessageType.ERROR, objEntity);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsEmailIdExist(email=" + UserName + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public JsonMessage IsUserNameExist(string username)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsUserNameExists(username);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Email is already in use", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserNameExist(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public int IsUserNameContactExists(string username, string contactNumber, int roleId, Int64 id = 0)
        {
            int retId = 0;
            try
            {
                retId = objUsersWrapper.IsUserNameContactExists(username, contactNumber, roleId, id);
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserNameContactExists(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return retId;
        }

        public JsonMessage IsSchoolExist(string username, string id)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsSchoolExist(username, id);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Email is already in use", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsSchoolExist(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public JsonMessage ValidateParentsDetails(string username, string studentId)
        {
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    int retValue = 0;
                    retValue = objUsersWrapper.ValidateParentsDetails(username, studentId);
                    //if (retValue > 2)
                    if (retValue > (Convert.ToInt32(ShikshaConstants.TypeEnums.StudentLimit) - 1))
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_error, KeyEnums.JsonMessageType.ERROR, retValue.ToString(), "false");
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, retValue.ToString(), "true");
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "ValidateParentsDetails(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public JsonMessage IsLastActiveStudent(string username, string studentId)
        {
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    int retValue = 0;
                    retValue = objUsersWrapper.IsLastActiveStudent(username, studentId);
                    if (retValue > (Convert.ToInt32(ShikshaConstants.TypeEnums.StudentLimit) - 1))
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_error, KeyEnums.JsonMessageType.ERROR, retValue.ToString(), "false");
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS, retValue.ToString(), "true");
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsLastActiveStudent(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public List<Users> GetParentContactDetailsByStudentUserID(Int64 studentUserID)
        {
            List<Users> users = new List<Users>();
            try
            {
                users = objUsersWrapperColletion.GetParentContactDetailsByStudentUserID(studentUserID);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getParentContactDetailsByStudentUserID(ClassID:" + studentUserID + ")", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public List<Users> GetEnquirySchoolDetails(string userName)
        {
            List<Users> users = new List<Users>();
            try
            {
                users = objUsersWrapperColletion.GetEnquirySchoolDetails(userName);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetEnquirySchoolDetails(userName:" + userName + ")", ex.Source, ex.Message, ex);
            }

            return users;
        }

        public JsonMessage IsParentExist(string username, string type)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsParentExist(username, type);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Email is already  use for mother", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserNameExist(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public JsonMessage IsUserNameExist_ExceptUser(string username, int ID)
        {
            bool returnValue = false;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.IsUserNameExists_ExceptUser(username, ID);

                    if (objEntity != null && objEntity.ID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, "Email is already in use", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, "IsUserNameExist(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public List<Users> getTeacherDetailsByTeacherID(Int64 userid)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getTeacherDetailsByTeacherID(userid);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getTeacherDetailsByTeacherID(userid:" + userid + ")", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public bool UpdatePassword(Users objUsers)
        {
            try
            {
                objUsersWrapper = new UsersWrapper();
                objUsersWrapper.objWrapperClass = objUsers;
                DataAccess.DataAccessLayer.DataAccess dalObject = new DataAccess.DataAccessLayer.DataAccess();
                Transaction TransObj = new Transaction(dalObject);
                TransObj.ConnectionString = dbClass.SqlConnectString();
                Dictionary<string, Command> CommandsObj = new Dictionary<string, Command>();
                int commandCounter = 0;

                bool result = objUsersWrapper.UpdatePassword(ref CommandsObj, ref commandCounter);
                TransObj.AddCommandList(CommandsObj);
                if (TransObj.ExecuteTransaction())
                    return true;
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdatePassword()", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }

        public Users GetUserDetailsByUsername(string username, int sts = 0)
        {
            objEntity = new Users();
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    objUsersWrapper = new UsersWrapper();
                    objEntity = objUsersWrapper.GetForgotPasswordDetails(username, sts);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetUserDetailsByUsername(username=" + username + ")", ex.Source, ex.Message, ex);
            }

            return objEntity;
        }

       

        public JsonMessage ChangeStatus(Int64 ID, string StatusID, int RoleID)
        {
            try
            {
                UsersWrapper objWrapper = new UsersWrapper();
                objWrapper.ChangeStatus(ID, StatusID, RoleID);
                string strMessage = "";
                if (StatusID == "0")
                    strMessage = Resource.lbl_accountDisabled;
                else if (StatusID == "1")
                    strMessage = "Enabled";
                else if (StatusID == "2")
                    strMessage = Resource.lbl_accountDeleted;
                _jsonMessage = new JsonMessage(true, Resource.lbl_success, strMessage, KeyEnums.JsonMessageType.SUCCESS, "", "");
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "0", null);
                Log.WriteLog(_module, "ChangeStatus(ID=" + ID + ",StatusID=" + StatusID + ", RoleID = " + RoleID + ")", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }

        public JsonMessage DeleteUsers(Int64 ID, string StatusID, int RoleID)
        {
            try
            {
                UsersWrapper objWrapper = new UsersWrapper();
                objWrapper.DeleteUsers(ID, StatusID, RoleID);
                string strMessage = "";
                if (StatusID == "0")
                    strMessage = Resource.lbl_accountDisabled;
                else if (StatusID == "1")
                    strMessage = "Enabled";
                else if (StatusID == "2")
                    strMessage = Resource.lbl_accountDeleted;
                _jsonMessage = new JsonMessage(true, Resource.lbl_success, strMessage, KeyEnums.JsonMessageType.SUCCESS, "", "");
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "0", null);
                Log.WriteLog(_module, "ChangeStatus(ID=" + ID + ",StatusID=" + StatusID + ", RoleID = " + RoleID + ")", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }

       

        
       

       

        

        public List<Users> getAllUsers()
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getAllUsers();
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAllUsers()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> getAllUsers_ParentsTeachers(int RoleID)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getAllUsers_ParentsTeachers(RoleID);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAllUsers_ParentsTeachers()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> getSchoolStudents(Int64 SchoolID, Int64 ClassID)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getSchoolStudents(SchoolID, ClassID);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAllUsers()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> getUserCount(int UserRole, int SchoolID, string startDate, string endDate, bool student, bool teacher, bool parent)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getUserCount(UserRole, SchoolID, startDate, endDate, student, teacher, parent);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> HQ_getUserCount(int UserRole, int SchoolID, string startDate, string endDate, bool student, bool teacher, bool parent)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.HQ_getUserCount(UserRole, SchoolID, startDate, endDate, student, teacher, parent);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "HQ_getUserCount()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> getUserTotalCount(int UserRole, int SchoolID, bool student, bool teacher, bool parent)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.getUserTotalCount(UserRole, SchoolID, student, teacher, parent);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> HQ_getUserTotalCount(int UserRole, int SchoolID, bool student, bool teacher, bool parent)
        {
            try
            {
                _lstUsers = objUsersWrapperColletion.HQ_getUserTotalCount(UserRole, SchoolID, student, teacher, parent);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }

        public List<Users> GetUserDetails(Int64 UserID)

        {
            try
            {
                _lstUsers = objUsersWrapperColletion.GetDetails(UserID);
                //_users = objUsersWrapperColletion.Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAllUsers()", ex.Source, ex.Message, ex);
            }

            return _lstUsers;
        }


        #region CheckExistence

        /// <summary>
        /// This method is common every validation can use exists or not
        /// </summary>
        /// <param name="value"></param>
        /// <param name="valueType"> which type value you pass store procedure </param>
        /// <returns></returns>
        public JsonMessage CheckExistence(string value, string valueType, Int64 Id)
        {
            bool returnValue = false;
            string valueDescription = "";

            try
            {
                if (!string.IsNullOrEmpty(value) && !string.IsNullOrEmpty(valueType))
                {
                    objUsersWrapper = new UsersWrapper();

                    switch (valueType.ToLower())
                    {
                        case "phonenumber":
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, 0);
                            valueDescription = "Phone Number";
                            break;

                        case "hqadmineditmobilenumberexistsornot":
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, Id);
                            valueDescription = "Phone Number";
                            break;

                        case "firsttimephonenumbercheckhqadmin":
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, Id);
                            valueDescription = "Phone Number";
                            break;

                        case "hqadmineditusernameexistsornot":
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, Id);
                            valueDescription = "User Name";
                            break;

                        case "parentusername": // student module on add click
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, Id);
                            valueDescription = "Parent Email";
                            break;

                        case "parentusernameedit": // student module on edit click
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, Id);
                            valueDescription = "Parent Email";
                            break;

                        case "retrievehqadminuserid": // Retrieve HQ Admin User ID For Email
                            objEntity = objUsersWrapper.CheckExistence(value, valueType, Id);
                            valueDescription = "User Id";
                            break;

                        default:
                            break;
                    }

                    if (objEntity != null && objEntity.StatusId == 5 || objEntity.ParentID > 0)
                        returnValue = true;

                    if (returnValue)
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, $"{valueDescription} In Used", KeyEnums.JsonMessageType.ERROR, objEntity);
                    else
                        _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_success, KeyEnums.JsonMessageType.SUCCESS);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, "", "Exception", ex.Message);
                Log.WriteLog(_module, $"CheckExistence(value={value}, valueType={valueType})", ex.Source, ex.Message, ex);
            }
            return _jsonMessage;
        }

        public Users AuthenticateLogin(long userId, string source, string userEmail, int schoolId)
        {
            return objUsersWrapper.AuthenticateLogin(userId, source, userEmail, schoolId);
        }

        public bool IsExternalIdExist(string cgStudentUserId, string entityTypeStudent)
        {
            return objUsersWrapper.IsExternalIdExist(cgStudentUserId, entityTypeStudent);
        }

        #endregion CheckExistence
    }
}
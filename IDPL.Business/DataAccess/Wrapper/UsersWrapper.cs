using Core.Business.DataAccess.Constants;
using Core.Business.DataAccess.DataAccessLayer;
using Core.Business.DataAccess.DataAccessLayer.General;
using Core.Business.DataAccess.Mapper;
using Core.Entity;
using Core.Utility.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace Core.Business.DataAccess.Wrapper
{
    public class UsersWrapper : UniversalObject
    {
        private readonly string _module = "Core.Business.DataAccess.Wrapper.Users";
        private SqlConnection Connection;

        #region UniversalObject Interface Members

        public bool ObjectChanged { get; set; }

        public Users objWrapperClass = new Users();
        private UsersDataMapper objUsersDataMapper = new UsersDataMapper();

        #region GetRecords methods

        public bool GetRecordById(int id)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = UsersStoredProcedures.UsersGetRecordById;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, id);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordById(" + id + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool GetRecordByValue(string fieldName, string value)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = UsersStoredProcedures.GetUsersRecordByValue;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                sqlCommand.Parameters.AddWithValue(fieldName, value);
                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordByValue(" + fieldName + "," + value + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool GetRecordByValue(string[] fieldNames, string[] values)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = UsersStoredProcedures.GetUsersRecordByValueArray;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;
                for (int i = 0; i < fieldNames.Length; i++)
                {
                    sqlCommand.Parameters.AddWithValue(fieldNames[i], values[i]);
                }

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    return true;
                }
                else
                    return false;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRecordByValue(" + string.Join(",", fieldNames) + "," + string.Join(",", values) + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (sqlDataReader != null)
                    sqlDataReader.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        #endregion GetRecords methods

        public bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                if (objWrapperClass.ID > 0)
                {
                    Update(ref commandList, ref commandCounter);
                }
                else
                {
                    Command command = new Command(UsersStoredProcedures.UsersSAVE, CommandType.StoredProcedure);
                    command.AddParameter(UsersDBFields.IU_Flag, "I", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.UserName, objWrapperClass.UserName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.Password, objWrapperClass.Password, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.FirstName, objWrapperClass.FirstName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.LastName, objWrapperClass.LastName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.SchoolID, objWrapperClass.SchoolID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.AlternateEmail, objWrapperClass.AlternateEmail, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.PhoneNumber, objWrapperClass.PhoneNumber, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.ProfilePicture, objWrapperClass.ProfilePicture, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.RoleID, objWrapperClass.RoleID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.ParentID, objWrapperClass.ParentID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.LanguageId, objWrapperClass.LanguageId, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);

                    command.AddParameter(UsersDBFields.LoginCode, objWrapperClass.LoginCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.FCMToken, objWrapperClass.FCMToken, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.FUserName, objWrapperClass.FUserName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.FPassword, objWrapperClass.FPassword, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.IsEmailVerified, objWrapperClass.IsEmailVerified, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.EmailVerficationCode, objWrapperClass.EmailVerficationCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.EmailVerificationDate, objWrapperClass.EmailVerificationDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.StatusId, objWrapperClass.StatusId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.CreatedDate, objWrapperClass.CreatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                    //command.AddParameter(UsersDBFields.UpdatedDate, objWrapperClass.UpdatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.DeviceID, objWrapperClass.DeviceID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                    command.AddParameter(UsersDBFields.RefreshToken, objWrapperClass.RefreshToken, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);

                    command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);

                    command.Name = UsersStoredProcedures.UsersSAVE + commandCounter.ToString();
                    commandCounter++;
                    commandList.Add(command.Name, command);
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Save", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool Update(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command(UsersStoredProcedures.UsersSAVE, CommandType.StoredProcedure);

                command.AddParameter(UsersDBFields.IU_Flag, "U", DataAccessLayer.DataAccess.DataType.Char, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.UserName, objWrapperClass.UserName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.Password, objWrapperClass.Password, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.FirstName, objWrapperClass.FirstName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.LastName, objWrapperClass.LastName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.SchoolID, objWrapperClass.SchoolID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.AlternateEmail, objWrapperClass.AlternateEmail, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.PhoneNumber, objWrapperClass.PhoneNumber, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.ProfilePicture, objWrapperClass.ProfilePicture, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.RoleID, objWrapperClass.RoleID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.ParentID, objWrapperClass.ParentID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.LanguageId, objWrapperClass.LanguageId, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.IsEmailVerified, objWrapperClass.IsEmailVerified, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.EmailVerficationCode, objWrapperClass.EmailVerficationCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.EmailVerificationDate, objWrapperClass.EmailVerificationDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.StatusId, objWrapperClass.StatusId, DataAccessLayer.DataAccess.DataType.Varchar2, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.CreatedDate, objWrapperClass.CreatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);
                //command.AddParameter(UsersDBFields.UpdatedDate, objWrapperClass.UpdatedDate, DataAccessLayer.DataAccess.DataType.DateTime, 0, ParameterDirection.Input);

                command.AddParameter(UsersDBFields.LoginCode, objWrapperClass.LoginCode, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.FCMToken, objWrapperClass.FCMToken, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.FUserName, objWrapperClass.FUserName, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.FPassword, objWrapperClass.FPassword, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.DeviceID, objWrapperClass.DeviceID, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.RefreshToken, objWrapperClass.RefreshToken, DataAccessLayer.DataAccess.DataType.NVarChar, 0, ParameterDirection.Input);

                command.AddParameter("RetID", 0, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Output);

                command.Name = UsersStoredProcedures.UsersSAVE + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Update", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool Delete(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command("SP_MASTERS_Delete", CommandType.StoredProcedure);
                command.AddParameter("@TableName", "Users", DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", "ID", DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.Name = "DeleteUsers" + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Delete", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool SaveCopy()
        {
            throw new NotImplementedException();
        }

        public bool Move()
        {
            throw new NotImplementedException();
        }

        public bool Print()
        {
            throw new NotImplementedException();
        }

        #endregion UniversalObject Interface Members

        #region Other Methods

        #region CheckExistence

        public Users CheckExistence(string value, string valueType, Int64 Id)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(value))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_CheckExistence, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.Value, value);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ValueType, valueType);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, Id);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "CheckExistence(username=" + value + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        #endregion CheckExistence

        public Users Authenticate(string username, string password, string LoginMode)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_Login, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.Password, password);
                    if (!string.IsNullOrEmpty(LoginMode))
                    {
                        sqlCommand.Parameters.AddWithValue(UsersDBFields.LoginMode, LoginMode);
                    }

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                        return objWrapperClass;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Authenticate(username=" + username + "Password=" + password + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users AuthenticateOTP(string mobileNumber, Int64 otp, string LoginMode)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (!string.IsNullOrEmpty(mobileNumber) && !string.IsNullOrEmpty(otp.ToString()))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_OTP_Login, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.PhoneNumber, mobileNumber);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, otp);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                        return objWrapperClass;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "AuthenticateOTP(mobileNumber=" + mobileNumber + "OTP=" + otp + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users AuthenticateRefreshToken(string username, string loginMode, string refreshToken = "")
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_Login_AuthenticateRefreshToken, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.RefreshToken, refreshToken);
                    if (!string.IsNullOrEmpty(loginMode))
                    {
                        sqlCommand.Parameters.AddWithValue(UsersDBFields.LoginMode, loginMode);
                    }
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);

                        return objWrapperClass;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "AuthenticateRefreshToken(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
            return objWrapperClass;
        }

        public byte ChangeStatus(Int64 ID, string StatusID, int RoleID)
        {
            byte retVal = 0;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_UpdateStatus, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.StatusId, StatusID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleID, RoleID);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "ChangeStatus(ID=" + ID + ", StatusID=" + StatusID + ", RoleID = " + RoleID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return retVal;
        }

        public byte DeleteEnquiryStudent(Int64 ID, string StatusID, int RoleID)
        {
            byte retVal = 0;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_DeleteEnquiryStudent, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.StatusId, StatusID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleID, RoleID);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "DeleteEnquiryStudent(ID=" + ID + ", StatusID=" + StatusID + ", RoleID = " + RoleID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return retVal;
        }

        public byte DeleteUsers(Int64 ID, string StatusID, int RoleID)
        {
            byte retVal = 0;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_DeleteUsers, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.StatusId, StatusID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleID, RoleID);

                sqlCommand.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "ChangeStatus(ID=" + ID + ", StatusID=" + StatusID + ", RoleID = " + RoleID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return retVal;
        }

        public Users IsUserIdExist(string userName, long ID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(userName))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsUserExists, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, userName);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsEmailIdExist(email=" + userName + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users getUserByLoginCode(string LoginCode, string username)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(LoginCode))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.getUserByLoginCode, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.LoginCode, LoginCode);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserByLoginCode(LoginCode=" + LoginCode + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users getUserPasswordExist(string password, string username)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(password))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.getUserPasswordExist, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.Password, password);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserPasswordExist(password=" + password + ",username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users IsUserNameExists(string username)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsUserNameExists, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserNameExists(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users IsSchoolExist(string username, string id)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsSchoolExist, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, id);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserNameExists(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public int ValidateParentsDetails(string username, string studentId)
        {
            int retVal = 0;
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersCountStudentForUserName, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.StudentDetailsID, Convert.ToInt64(studentId));
                    sqlCommand.Parameters.Add("@retID", SqlDbType.Int);
                    sqlCommand.Parameters["@retID"].Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    if (sqlCommand.Parameters["@retID"].Value != DBNull.Value)
                    {
                        retVal = Convert.ToByte(sqlCommand.Parameters["@retID"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "CountStudentForUserName(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return retVal;
        }

        public int IsUserNameContactExists(string username, string contactNumber, int roleId, Int64 id = 0)
        {
            int retVal = 0;
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsUserNameContactExists, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ContactNumber, contactNumber);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleID, roleId);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, id);
                    sqlCommand.Parameters.Add("@retID", SqlDbType.Int);
                    sqlCommand.Parameters["@retID"].Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    if (sqlCommand.Parameters["@retID"].Value != DBNull.Value)
                    {
                        retVal = Convert.ToInt32(sqlCommand.Parameters["@retID"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserNameContactExists(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return retVal;
        }

        public int IsLastActiveStudent(string username, string studentId)
        {
            int retVal = 0;
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersIsLastActiveStudent, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.StudentDetailsID, Convert.ToInt64(studentId));
                    sqlCommand.Parameters.Add("@retID", SqlDbType.Int);
                    sqlCommand.Parameters["@retID"].Direction = ParameterDirection.Output;

                    sqlCommand.ExecuteNonQuery();

                    if (sqlCommand.Parameters["@retID"].Value != DBNull.Value)
                    {
                        retVal = Convert.ToByte(sqlCommand.Parameters["@retID"].Value);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "CountStudentForUserName(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return retVal;
        }

        public Users IsParentExist(string username, string type)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsParentExists, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.type, type);
                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserNameExists(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users IsUserNameExists_ExceptUser(string username, int ID)
        {
            SqlDataReader sqlDataReader = null;
            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_IsUserNameExists_ExceptUser, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.CommandTimeout = Convert.ToInt32(ShikshaConstants.SQLCommandTimeOut);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsUserNameExists_ExceptUser(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public bool UpdatePassword(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command(UsersStoredProcedures.Password_Update, CommandType.StoredProcedure);
                command.AddParameter(UsersDBFields.ID, objWrapperClass.ID, DataAccessLayer.DataAccess.DataType.Number, 0, ParameterDirection.Input);
                command.AddParameter(UsersDBFields.Password, objWrapperClass.Password, DataAccessLayer.DataAccess.DataType.NVarChar, 100, ParameterDirection.Input);
                command.Name = "UpdateUser" + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateRecords", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public Users GetForgotPasswordDetails(string username, int sts = 0)
        {
            SqlDataReader sqlDataReader = null;

            try
            {
                if (!string.IsNullOrEmpty(username))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.ForgotPassword, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, username);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.StatusId, sts);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetForgotPasswordDetails(username=" + username + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public Users AuthenticateLogin(long userId, string source, string userEmail, int schoolId)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (userId != 0 && !string.IsNullOrEmpty(source))
                {
                    if (this.Connection == null)
                        this.Connection = dbClass.GetSqlConnection();

                    SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.SSOLogin, this.Connection);
                    sqlCommand.CommandType = CommandType.StoredProcedure;
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, userId);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.Source, source);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.Email, userEmail);
                    sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, schoolId);

                    sqlDataReader = sqlCommand.ExecuteReader();
                    if (sqlDataReader.Read())
                    {
                        objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                        return objWrapperClass;
                    }
                    else
                        return null;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "AuthenticateLogin(userId=" + userId + "source=" + source + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return objWrapperClass;
        }

        public bool IsExternalIdExist(string cgStudentUserId, string entityTypeStudent)
        {
            SqlDataReader sqlDataReader = null;
            bool returnValue = false;
            UsersDataMapper objUsersDataMapper = new UsersDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.IsExternalIdExist, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ExternalID, cgStudentUserId);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.EntityType, entityTypeStudent);

                sqlDataReader = sqlCommand.ExecuteReader();
                if (sqlDataReader.Read())
                {
                    objWrapperClass = objUsersDataMapper.GetDetails(sqlDataReader);
                    if (objWrapperClass != null)
                    {
                        return returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsExternalIdExist(cgStudentUserId=" + cgStudentUserId + "source=" + cgStudentUserId + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
            return returnValue;
        }

        #endregion Other Methods
    }

    public class UsersWrapperColletion : UniversalCollection
    {
        private readonly string _module = "Users";
        private SqlConnection Connection;
        private List<Users> _Items = new List<Users>();

        public List<Users> Items
        { get { return this._Items; } set { this._Items = value; } }

        private DataSet _DtsDataset = null;
        private string _SortingString = "";

        #region UniversalCollection Interface Members Implementation

        #region GetRecords methods

        public bool GetRecords(bool createDataSet, string[,] sortFields)
        {
            if (createDataSet)
                return GetDataSetForQuery(UsersStoredProcedures.GetUsersRecords);
            else
                return GetCollectionForQuery(UsersStoredProcedures.GetUsersRecords);
        }

        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter)
        {
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }
            }

            SqlParameterCollection sqlParameterCollection = null;
            SqlParameter ObjSqlParameter = new SqlParameter();
            ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
            ObjSqlParameter.Value = _SortingString;
            sqlParameterCollection.Add(ObjSqlParameter);

            if (createDataSet)
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
        }

        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter, string fieldName, string fieldValue)
        {
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }
            }

            string[] Fieldsname = new string[1];
            string[] Values = new string[1];
            Fieldsname[0] = fieldName;
            Values[0] = fieldValue;

            return GetCollectionForQueryWithParameters(UsersStoredProcedures.GetUsersRecordByValue, Fieldsname, Values);
        }

        private bool GetCollectionForQueryWithParameters(string sqlQuery, string[] fieldNames, string[] values)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;

                if (fieldNames != null)
                {
                    if (fieldNames.Length > 0)
                    {
                        for (int i = 0; i < fieldNames.Length; i++)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            sqlParameter.ParameterName = fieldNames[i];
                            sqlParameter.Value = values[i];
                            sqlCommand.Parameters.Add(sqlParameter);
                        }
                    }
                }

                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    UsersDataMapper objDataMapper = new UsersDataMapper();
                    this.Items.Add(objDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQueryWithParameters(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool GetRecords(bool createDataSet, string[,] sortFields, bool isParameter, string[] fieldName, string[] fieldValue)
        {
            SqlParameterCollection sqlParameterCollection = null;
            if (fieldName != null)
            {
                if (fieldName.Length > 0)
                {
                    for (int i = 0; i < fieldName.Length; i++)
                    {
                        SqlParameter sqlParameter = new SqlParameter();
                        sqlParameter.ParameterName = fieldName[i];
                        sqlParameter.Value = fieldValue[i];
                        sqlParameterCollection.Add(sqlParameter);
                    }
                }
            }
            if (sortFields != null)
            {
                if (sortFields.Length > 0)
                {
                    _SortingString += "order by ";
                    for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                    {
                        _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                    }
                    _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                }

                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);
            }

            if (createDataSet)
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
            else
                return GetDataSetForQueryParameter(UsersStoredProcedures.GetUsersRecords, sqlParameterCollection);
        }

        #endregion GetRecords methods

        #region Seach Method

        public bool Search(string searchString, string[,] sortString)
        {
            throw new NotImplementedException();
        }

        public bool Search(string fieldName, string fieldValue, string[,] sortString)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;
                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = fieldName;
                ObjSqlParameter.Value = fieldValue;
                sqlParameterCollection.Add(ObjSqlParameter);

                GetCollectionForQueryWithParameter(UsersStoredProcedures.UsersSearch, sqlParameterCollection);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool Search(string searchString, bool createDataSet, string[,] sortFields)
        {
            throw new NotImplementedException();
        }

        public bool Search(string fieldName, string fieldValue, bool createDataSet, string[,] sortFields)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;

                SqlParameter sqlParameter = new SqlParameter();
                sqlParameter.ParameterName = fieldName;
                sqlParameter.Value = fieldValue;
                sqlParameterCollection.Add(sqlParameter);

                SqlParameter ObjSqlParameter = new SqlParameter();
                ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
                ObjSqlParameter.Value = _SortingString;
                sqlParameterCollection.Add(ObjSqlParameter);

                if (createDataSet)
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValue, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValue, sqlParameterCollection);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        public bool Search(string[] fieldName, string[] fieldValue, bool createDataSet, string[,] sortFields)
        {
            try
            {
                SqlParameterCollection sqlParameterCollection = null;
                if (fieldName != null)
                {
                    if (fieldName.Length > 0)
                    {
                        for (int i = 0; i < fieldName.Length; i++)
                        {
                            SqlParameter sqlParameter = new SqlParameter();
                            sqlParameter.ParameterName = fieldName[i];
                            sqlParameter.Value = fieldValue[i];
                            sqlParameterCollection.Add(sqlParameter);
                        }
                    }
                }
                if (sortFields != null)
                {
                    if (sortFields.Length > 0)
                    {
                        _SortingString += "order by ";
                        for (int i = 0; i <= sortFields.GetUpperBound(0); i++)
                        {
                            _SortingString += "" + sortFields[i, 0] + " " + sortFields[i, 1] + ",";
                        }
                        _SortingString = _SortingString.Substring(0, _SortingString.Length - 1);
                    }

                    SqlParameter ObjSqlParameter = new SqlParameter();
                    ObjSqlParameter.ParameterName = UsersStoredProcedures.SortingString;
                    ObjSqlParameter.Value = _SortingString;
                    sqlParameterCollection.Add(ObjSqlParameter);
                }

                if (createDataSet)
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValueArray, sqlParameterCollection);
                else
                    return GetDataSetForQueryParameter(UsersStoredProcedures.UsersSearchByValueArray, sqlParameterCollection);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Search(" + fieldName + "," + fieldValue + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        #endregion Seach Method

        #region ExecuteQuery Methods

        private bool GetDataSetForQuery(string sqlQuery)
        {
            try
            {
                DataSet _DtsUsers = new DataSet("Users");
                SqlDataAdapter _Adpusers = new SqlDataAdapter(sqlQuery, this.Connection);
                _Adpusers.Fill(_DtsUsers);
                this._DtsDataset = _DtsUsers;
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDataSetForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }

        private bool GetDataSetForQueryParameter(string sqlQuery, SqlParameterCollection ObjSqlParameter)
        {
            try
            {
                DataSet _DtsUsers = new DataSet("Users");
                SqlCommand sqlCommand = new SqlCommand(sqlQuery, this.Connection);
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.Add(ObjSqlParameter);
                SqlDataAdapter _Adpusers = new SqlDataAdapter();
                _Adpusers.SelectCommand = sqlCommand;
                _Adpusers.Fill(this._DtsDataset);
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDataSetForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally { }
        }

        private bool GetCollectionForQuery(string sqlQuery)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Connection = this.Connection;

                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    UsersDataMapper objUsersDataMapper = new UsersDataMapper();
                    this.Items.Add(objUsersDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        private bool GetCollectionForQueryWithParameter(string sqlQuery, SqlParameterCollection ObjSqlParameter)
        {
            SqlDataReader _Dtr = null;
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();
                SqlCommand sqlCommand = new SqlCommand();
                sqlCommand.CommandText = sqlQuery;
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.CommandTimeout = 0;
                sqlCommand.Parameters.Add(ObjSqlParameter);
                sqlCommand.Connection = this.Connection;
                _Dtr = sqlCommand.ExecuteReader();
                while (_Dtr.Read())
                {
                    UsersDataMapper objUsersDataMapper = new UsersDataMapper();
                    this.Items.Add(objUsersDataMapper.GetDetails(_Dtr));
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetCollectionForQuery(" + sqlQuery + ")", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
                if (_Dtr != null)
                    _Dtr.Close();
                dbClass.CloseSqlConnection(ref this.Connection);
            }
        }

        #endregion ExecuteQuery Methods

        public bool Save(ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                UsersWrapper objUsersWrapper = new UsersWrapper();
                for (int i = 0; i < this.Items.Count; i++)
                {
                    if (this.Items[i].ObjectChanged == true)
                    {
                        Dictionary<string, Command> subCommands = new Dictionary<string, Command>();
                        objUsersWrapper.Save(ref subCommands, ref commandCounter);
                        foreach (KeyValuePair<string, Command> commandPair in subCommands)
                        {
                            commandList.Add(commandPair.Key, commandPair.Value);
                        }
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Save", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        public bool Delete(string ids, ref Dictionary<string, Command> commandList, ref int commandCounter)
        {
            try
            {
                Command command = new Command("SP_MASTERS_DELETE", CommandType.StoredProcedure);
                command.AddParameter("@TableName", UsersDBFields.TableNameVal, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@PrimaryKeyColumn", UsersDBFields.ID, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.AddParameter("@IDs", ids, DataAccessLayer.DataAccess.DataType.Varchar, 0, ParameterDirection.Input);
                command.Name = "Delete" + UsersDBFields.TableNameVal + commandCounter.ToString();
                commandCounter++;
                commandList.Add(command.Name, command);

                return true;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "Delete", ex.Source, ex.Message, ex);
                return false;
            }
            finally
            {
            }
        }

        object UniversalCollection.GetRecordById(int id)
        {
            throw new NotImplementedException();
        }

        object UniversalCollection.GetRecordByValue(string fieldName, string value)
        {
            throw new NotImplementedException();
        }

        #endregion UniversalCollection Interface Members Implementation

        #region Other Methods

        public dynamic getClassUsersParentByClassID(Int64 ClassID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_getClassUsersParentByClassID, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ClassID, ClassID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getClassUsersParentByClassID(ClassID: " + ClassID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public dynamic GetListRecordsOfParents()
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper _DataMapper = new UsersDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_GetListRecordsOfParents, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                //sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                //sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, HolidayID);
                sqlDataReader = sqlCommand.ExecuteReader();

                _Items = _DataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetListRecordsOfParents()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> GetParentContactDetailsByStudentUserID(Int64 studentUserID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            Users objEntity = new Users();
            List<Users> users = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersGetParentContactDetailsByStudentUserID, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UsersID, studentUserID);

                sqlDataReader = sqlCommand.ExecuteReader();
                users = objDataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getParentContactDetailsByStudentUserID(StudentUserID: " + studentUserID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return users;
        }

        public List<Users> GetEnquirySchoolDetails(string userName)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();
            Users objEntity = new Users();
            List<Users> users = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.UsersGetEnquirySchoolDetails, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.UserName, userName);
                sqlDataReader = sqlCommand.ExecuteReader();
                users = objDataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetEnquirySchoolDetails(userName: " + userName + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return users;
        }

        public dynamic getTeacherDetailsByTeacherID(Int64 ID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_getTeacherDetailsByTeacherID, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getTeacherDetailsByTeacherID(userid: " + ID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public dynamic GetDocumentPermissionUsers(Int64 ID, int AllTeachers, int AllParents)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper _DataMapper = new UsersDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.DocumentFolder_GetDocumentPermissionUsers, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, ID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Teacher, AllTeachers);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Parent, AllParents);
                sqlDataReader = sqlCommand.ExecuteReader();

                _Items = _DataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDocumentPermissionUsers(ID:" + ID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public dynamic GetHolidayNotificationUsers(Int64 SchoolID, Int64 HolidayID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper _DataMapper = new UsersDataMapper();
            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_getHolidayNotificationUsers, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, HolidayID);
                sqlDataReader = sqlCommand.ExecuteReader();

                _Items = _DataMapper.GetDetailsList(sqlDataReader);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDocumentPermissionUsers(SchoolID:" + SchoolID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        
      
        

        

       

       

        public List<Users> getAllUsers()
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.getAllUsers, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAllUsers()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> getAllUsers_ParentsTeachers(int RoleID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.getAllUsers_ParentsTeachers, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.RoleID, RoleID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getAllUsers()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> getSchoolStudents(Int64 SchoolID, Int64 ClassID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_getSchoolStudents, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ClassID, ClassID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getSchoolStudents(SchoolID: " + SchoolID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> GetDetails(Int64 ID)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.Users_getRecordContactDetails, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.ID, ID);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getSchoolStudents(ID: " + ID + ")", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

       
        public List<Users> getUserCount(int UserRole, int SchoolID, string startDate, string endDate, bool student, bool teacher, bool parent)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.getUsersCount, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.userRole, UserRole);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.startDate, startDate);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.endDate, endDate);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Teacher, teacher);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Parent, parent);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Student, student);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> HQ_getUserCount(int UserRole, int SchoolID, string startDate, string endDate, bool student, bool teacher, bool parent)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.HQgetUsersCount, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.userRole, UserRole);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.startDate, startDate);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.endDate, endDate);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Teacher, teacher);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Parent, parent);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Student, student);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> getUserTotalCount(int UserRole, int SchoolID, bool student, bool teacher, bool parent)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.getUsersTotalCount, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.userRole, UserRole);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Teacher, teacher);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Parent, parent);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Student, student);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        public List<Users> HQ_getUserTotalCount(int UserRole, int SchoolID, bool student, bool teacher, bool parent)
        {
            SqlDataReader sqlDataReader = null;
            UsersDataMapper objDataMapper = new UsersDataMapper();

            Users objEntity = new Users();
            List<Users> _lstobjEntity = new List<Users>();

            try
            {
                if (this.Connection == null)
                    this.Connection = dbClass.GetSqlConnection();

                SqlCommand sqlCommand = new SqlCommand(UsersStoredProcedures.HQ_getUsersTotalCount, this.Connection);
                sqlCommand.CommandType = CommandType.StoredProcedure;
                sqlCommand.Parameters.AddWithValue(UsersDBFields.userRole, UserRole);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.SchoolID, SchoolID);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Teacher, teacher);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Parent, parent);
                sqlCommand.Parameters.AddWithValue(UsersDBFields.Student, student);

                sqlDataReader = sqlCommand.ExecuteReader();
                _Items = objDataMapper.GetDetailsList(sqlDataReader);

                _lstobjEntity = _Items;
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "getUserCount()", ex.Source, ex.Message, ex);
            }
            finally
            {
                dbClass.CloseSqlConnection(ref this.Connection);
            }

            return _Items;
        }

        #endregion Other Methods
    }

    public class CG_UserDetails
    {
        public int ID { get; set; }
        public int userRole { get; set; } // 1 = student, 2 = teacher, 3 = parent
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DOB { get; set; }
        public string ContactNumber { get; set; }
        public string token { get; set; }
        public string DateOfBirth { get; set; }
    }
}
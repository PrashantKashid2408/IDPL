using Core.Business.DataAccess.Constants;
using Core.Entity;
using Core.Utility.Common;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Reflection.PortableExecutable;

namespace Core.Business.DataAccess.Mapper
{
    public class UsersDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.UsersDataMapper";
        private Users objUsers = null;

        public Users GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objUsers = new Users();

                if (sqlDataReader.HasColumn(UsersDBFields.ID))
                    objUsers.ID = (sqlDataReader[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.ID]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.UserName))
                    objUsers.UserName = (sqlDataReader[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.Password))
                    objUsers.Password = (sqlDataReader[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.Password]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.FirstName))
                    objUsers.FirstName = (sqlDataReader[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FirstName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.LastName))
                    objUsers.LastName = (sqlDataReader[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.LastName]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.SchoolID))
                    objUsers.SchoolID = (sqlDataReader[UsersDBFields.SchoolID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.SchoolID]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.AlternateEmail))
                    objUsers.AlternateEmail = (sqlDataReader[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.AlternateEmail]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.PhoneNumber))
                    objUsers.PhoneNumber = (sqlDataReader[UsersDBFields.PhoneNumber] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.PhoneNumber]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.ProfilePicture))
                    objUsers.ProfilePicture = (sqlDataReader[UsersDBFields.ProfilePicture] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.ProfilePicture]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.RoleID))
                    objUsers.RoleID = (sqlDataReader[UsersDBFields.RoleID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.RoleID]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.ParentID))
                    objUsers.ParentID = (sqlDataReader[UsersDBFields.ParentID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.ParentID]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.LanguageId))
                    objUsers.LanguageId = (sqlDataReader[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.LanguageId]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.IsEmailVerified))
                    objUsers.IsEmailVerified = (sqlDataReader[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(sqlDataReader[UsersDBFields.IsEmailVerified]) : false);
                if (sqlDataReader.HasColumn(UsersDBFields.EmailVerficationCode))
                    objUsers.EmailVerficationCode = (sqlDataReader[UsersDBFields.EmailVerficationCode] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.EmailVerficationCode]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.EmailVerificationDate))
                    objUsers.EmailVerificationDate = (sqlDataReader[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.EmailVerificationDate]) : DateTime.Now);

                if (sqlDataReader.HasColumn(UsersDBFields.StatusId))
                    objUsers.StatusId = (sqlDataReader[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.StatusId]) : (byte)0);

                if (sqlDataReader.HasColumn(UsersDBFields.CreatedDate))
                    objUsers.CreatedDate = (sqlDataReader[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.CreatedDate]) : DateTime.Now);
                if (sqlDataReader.HasColumn(UsersDBFields.UpdatedDate))
                    objUsers.UpdatedDate = (sqlDataReader[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.UpdatedDate]) : DateTime.Now);

                if (sqlDataReader.HasColumn(UsersDBFields.ClassID))
                    objUsers.ClassID = (sqlDataReader[UsersDBFields.ClassID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.ClassID]) : 0);

                if (sqlDataReader.HasColumn(UsersDBFields.FUserName))
                    objUsers.FUserName = (sqlDataReader[UsersDBFields.FUserName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FUserName]) : "");

                if (sqlDataReader.HasColumn(UsersDBFields.FPassword))
                    objUsers.FPassword = (sqlDataReader[UsersDBFields.FPassword] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FPassword]) : "");

                if (sqlDataReader.HasColumn(UsersDBFields.DateOfBirth))
                    objUsers.DateOfBirth = (sqlDataReader[UsersDBFields.DateOfBirth] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.DateOfBirth]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.Address))
                    objUsers.Address = (sqlDataReader[UsersDBFields.Address] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.Address]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.Age))
                    objUsers.Age = (sqlDataReader[UsersDBFields.Age] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.Age]) : 0);

                if (sqlDataReader.HasColumn(UsersDBFields.ClassName))
                    objUsers.ClassName = (sqlDataReader[UsersDBFields.ClassName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.ClassName]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.JoiningDate))
                    objUsers.JoiningDate = (sqlDataReader[UsersDBFields.JoiningDate] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.JoiningDate]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.FullName))
                    objUsers.FullName = (sqlDataReader[UsersDBFields.FullName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FullName]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.StudentDetailsID))
                    objUsers.StudentDetailsID = (sqlDataReader[UsersDBFields.StudentDetailsID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.StudentDetailsID]) : 0);

                if (sqlDataReader.HasColumn(UsersDBFields.GradeMasterID))
                    objUsers.GradeMasterID = (sqlDataReader[UsersDBFields.GradeMasterID] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.GradeMasterID]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.GradeName))
                    objUsers.GradeName = (sqlDataReader[UsersDBFields.GradeName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.GradeName]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.ProfilePicture))
                    objUsers.ProfilePicture = (sqlDataReader[UsersDBFields.ProfilePicture] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.ProfilePicture]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.LoginCode))
                    objUsers.LoginCode = (sqlDataReader[UsersDBFields.LoginCode] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.LoginCode]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.FCMToken))
                    objUsers.FCMToken = (sqlDataReader[UsersDBFields.FCMToken] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.FCMToken]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.SchoolName))
                    objUsers.SchoolName = (sqlDataReader[UsersDBFields.SchoolName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.SchoolName]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.StudentName))
                    objUsers.StudentName = (sqlDataReader[UsersDBFields.StudentName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.StudentName]) : string.Empty);

                if (sqlDataReader.HasColumn(UsersDBFields.IsPrimaryContact))
                    objUsers.IsPrimaryContact = (sqlDataReader[UsersDBFields.IsPrimaryContact] != DBNull.Value ? Convert.ToInt16(sqlDataReader[UsersDBFields.IsPrimaryContact]) : 0);

                if (sqlDataReader.HasColumn(UsersDBFields.StudentCount))
                    objUsers.StudentCount = (sqlDataReader[UsersDBFields.StudentCount] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.StudentCount]) : 0);

                if (sqlDataReader.HasColumn(UsersDBFields.TeacherCount))
                    objUsers.TeacherCount = (sqlDataReader[UsersDBFields.TeacherCount] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.TeacherCount]) : 0);

                if (sqlDataReader.HasColumn(UsersDBFields.ParentCount))
                    objUsers.ParentCount = (sqlDataReader[UsersDBFields.ParentCount] != DBNull.Value ? Convert.ToInt64(sqlDataReader[UsersDBFields.ParentCount]) : 0);
                if (sqlDataReader.HasColumn(UsersDBFields.LoginMode))
                    objUsers.LoginMode = (sqlDataReader[UsersDBFields.LoginMode] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.LoginMode]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.IsAdded))
                    objUsers.IsAdded = (sqlDataReader[UsersDBFields.IsAdded] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.IsAdded]) : (byte)0);
                if (sqlDataReader.HasColumn(UsersDBFields.relation))
                    objUsers.relation = (sqlDataReader[UsersDBFields.relation] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.relation]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.RefreshToken))
                    objUsers.RefreshToken = (sqlDataReader[UsersDBFields.RefreshToken] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.RefreshToken]) : string.Empty);
                if (sqlDataReader.HasColumn(UsersDBFields.Document))
                    objUsers.Document = ((byte)(sqlDataReader[UsersDBFields.Document] != DBNull.Value ? Convert.ToInt16(sqlDataReader[UsersDBFields.Document]) : 0));
                if (sqlDataReader.HasColumn(UsersDBFields.EnquiryManagement))
                    objUsers.EnquiryManagement = ((byte)(sqlDataReader[UsersDBFields.EnquiryManagement] != DBNull.Value ? Convert.ToInt16(sqlDataReader[UsersDBFields.EnquiryManagement]) : 0));
                if (sqlDataReader.HasColumn(UsersDBFields.SchoolHQID))
                    objUsers.SchoolHQID = (sqlDataReader[UsersDBFields.SchoolHQID] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.SchoolHQID]) : 0);

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objUsers;
        }

        public List<Users> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<Users> list = new List<Users>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objUsers = GetDetails(sqlDataReader);
                    list.Add(objUsers);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<Users> GetDetails(DataSet dataSet)
        {
            List<Users> Userss = new List<Users>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUsers = new Users();

                        if (drow.Table.Columns.Contains(UsersDBFields.ID))
                            objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName))
                            objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.Password))
                            objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName))
                            objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName))
                            objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.SchoolID))
                            objUsers.SchoolID = (drow[UsersDBFields.SchoolID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.SchoolID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail))
                            objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.ProfilePicture))
                            objUsers.ProfilePicture = (drow[UsersDBFields.ProfilePicture] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.ProfilePicture]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleID))
                            objUsers.RoleID = (drow[UsersDBFields.RoleID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.RoleID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentID))
                            objUsers.ParentID = (drow[UsersDBFields.ParentID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.LanguageId))
                            objUsers.LanguageId = (drow[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.LanguageId]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.IsEmailVerified))
                            objUsers.IsEmailVerified = (drow[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsEmailVerified]) : false);
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerficationCode))
                            if (drow.Table.Columns.Contains(UsersDBFields.EmailVerificationDate))
                                objUsers.EmailVerificationDate = (drow[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.EmailVerificationDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId))
                            objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate))
                            objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate))
                            objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now);

                        if (drow.Table.Columns.Contains(UsersDBFields.LoginMode))
                            objUsers.LoginMode = (drow[UsersDBFields.LoginMode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LoginMode]) : string.Empty);

                        Userss.Add(objUsers);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return Userss;
        }

        public Users GetDetailsobj(DataSet dataSet)
        {
            Users objUsers = new Users();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objUsers = new Users();

                        if (drow.Table.Columns.Contains(UsersDBFields.ID))
                            objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName))
                            objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.Password))
                            objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName))
                            objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName))
                            objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.SchoolID))
                            objUsers.SchoolID = (drow[UsersDBFields.SchoolID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.SchoolID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail))
                            objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.ProfilePicture))
                            objUsers.ProfilePicture = (drow[UsersDBFields.ProfilePicture] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.ProfilePicture]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleID))
                            objUsers.RoleID = (drow[UsersDBFields.RoleID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.RoleID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentID))
                            objUsers.ParentID = (drow[UsersDBFields.ParentID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.LanguageId))
                            objUsers.LanguageId = (drow[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.LanguageId]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.IsEmailVerified))
                            objUsers.IsEmailVerified = (drow[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsEmailVerified]) : false);
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerficationCode))
                            if (drow.Table.Columns.Contains(UsersDBFields.EmailVerificationDate))
                                objUsers.EmailVerificationDate = (drow[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.EmailVerificationDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId))
                            objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate))
                            objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate))
                            objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.LoginMode))
                            objUsers.LoginMode = (drow[UsersDBFields.LoginMode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LoginMode]) : string.Empty);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

        public Users GetDetails(DataTable dataTable)
        {
            Users objUsers = new Users();

            try
            {
                if (dataTable != null && dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objUsers = new Users();

                        if (drow.Table.Columns.Contains(UsersDBFields.ID))
                            objUsers.ID = (drow[UsersDBFields.ID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.UserName))
                            objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.Password))
                            objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.FirstName))
                            objUsers.FirstName = (drow[UsersDBFields.FirstName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.FirstName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.LastName))
                            objUsers.LastName = (drow[UsersDBFields.LastName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LastName]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.SchoolID))
                            objUsers.SchoolID = (drow[UsersDBFields.SchoolID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.SchoolID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.AlternateEmail))
                            objUsers.AlternateEmail = (drow[UsersDBFields.AlternateEmail] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.AlternateEmail]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.ProfilePicture))
                            objUsers.ProfilePicture = (drow[UsersDBFields.ProfilePicture] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.ProfilePicture]) : string.Empty);
                        if (drow.Table.Columns.Contains(UsersDBFields.RoleID))
                            objUsers.RoleID = (drow[UsersDBFields.RoleID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.RoleID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.ParentID))
                            objUsers.ParentID = (drow[UsersDBFields.ParentID] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.ParentID]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.LanguageId))
                            objUsers.LanguageId = (drow[UsersDBFields.LanguageId] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.LanguageId]) : 0);
                        if (drow.Table.Columns.Contains(UsersDBFields.IsEmailVerified))
                            objUsers.IsEmailVerified = (drow[UsersDBFields.IsEmailVerified] != DBNull.Value ? Convert.ToBoolean(drow[UsersDBFields.IsEmailVerified]) : false);
                        if (drow.Table.Columns.Contains(UsersDBFields.EmailVerficationCode))
                            if (drow.Table.Columns.Contains(UsersDBFields.EmailVerificationDate))
                                objUsers.EmailVerificationDate = (drow[UsersDBFields.EmailVerificationDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.EmailVerificationDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.StatusId))
                            objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0);
                        if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate))
                            objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate))
                            objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now);
                        if (drow.Table.Columns.Contains(UsersDBFields.LoginMode))
                            objUsers.LoginMode = (drow[UsersDBFields.LoginMode] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.LoginMode]) : string.Empty);


                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objUsers;
        }

    }
}

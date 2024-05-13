using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Business.DataAccess.Constants;
using System.Data.SqlClient;
using System.Data;
using Core.Entity;
using Core.Entity.Common;
using Core.Utility.Common;

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
               
			   if (sqlDataReader.HasColumn(UsersDBFields.Id))
   objUsers.Id = (sqlDataReader[UsersDBFields.Id] != DBNull.Value ? Convert.ToInt32(sqlDataReader[UsersDBFields.Id]) : 0); 
if (sqlDataReader.HasColumn(UsersDBFields.UserName))
   objUsers.UserName = (sqlDataReader[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.UserName]) : string.Empty); 
if (sqlDataReader.HasColumn(UsersDBFields.Password))
   objUsers.Password = (sqlDataReader[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(sqlDataReader[UsersDBFields.Password]) : string.Empty); 
if (sqlDataReader.HasColumn(UsersDBFields.RoleId))
   objUsers.RoleId = (sqlDataReader[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.RoleId]) : (byte)0); 
if (sqlDataReader.HasColumn(UsersDBFields.StatusId))
   objUsers.StatusId = (sqlDataReader[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[UsersDBFields.StatusId]) : (byte)0); 
if (sqlDataReader.HasColumn(UsersDBFields.CreatedDate))
   objUsers.CreatedDate = (sqlDataReader[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.CreatedDate]) : DateTime.Now); 
if (sqlDataReader.HasColumn(UsersDBFields.UpdatedDate))
   objUsers.UpdatedDate = (sqlDataReader[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[UsersDBFields.UpdatedDate]) : DateTime.Now); 

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
                       
						if (drow.Table.Columns.Contains(UsersDBFields.Id)) 
  objUsers.Id = (drow[UsersDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.Id]) : 0); 
if (drow.Table.Columns.Contains(UsersDBFields.UserName)) 
  objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty); 
if (drow.Table.Columns.Contains(UsersDBFields.Password)) 
  objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty); 
if (drow.Table.Columns.Contains(UsersDBFields.RoleId)) 
  objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0); 
if (drow.Table.Columns.Contains(UsersDBFields.StatusId)) 
  objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate)) 
  objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate)) 
  objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now); 


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
                      
						if (drow.Table.Columns.Contains(UsersDBFields.Id)) 
  objUsers.Id = (drow[UsersDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.Id]) : 0); 
if (drow.Table.Columns.Contains(UsersDBFields.UserName)) 
  objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty); 
if (drow.Table.Columns.Contains(UsersDBFields.Password)) 
  objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty); 
if (drow.Table.Columns.Contains(UsersDBFields.RoleId)) 
  objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0); 
if (drow.Table.Columns.Contains(UsersDBFields.StatusId)) 
  objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate)) 
  objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate)) 
  objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now); 

                        
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
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objUsers = new Users();
                      
						if (drow.Table.Columns.Contains(UsersDBFields.Id)) 
  objUsers.Id = (drow[UsersDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[UsersDBFields.Id]) : 0); 
if (drow.Table.Columns.Contains(UsersDBFields.UserName)) 
  objUsers.UserName = (drow[UsersDBFields.UserName] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.UserName]) : string.Empty); 
if (drow.Table.Columns.Contains(UsersDBFields.Password)) 
  objUsers.Password = (drow[UsersDBFields.Password] != DBNull.Value ? Convert.ToString(drow[UsersDBFields.Password]) : string.Empty); 
if (drow.Table.Columns.Contains(UsersDBFields.RoleId)) 
  objUsers.RoleId = (drow[UsersDBFields.RoleId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.RoleId]) : (byte)0); 
if (drow.Table.Columns.Contains(UsersDBFields.StatusId)) 
  objUsers.StatusId = (drow[UsersDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[UsersDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(UsersDBFields.CreatedDate)) 
  objUsers.CreatedDate = (drow[UsersDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(UsersDBFields.UpdatedDate)) 
  objUsers.UpdatedDate = (drow[UsersDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[UsersDBFields.UpdatedDate]) : DateTime.Now); 

                        
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

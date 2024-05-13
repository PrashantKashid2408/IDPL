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
    public class EventLogsDataMapper
    {
        private static readonly string _module = "Core.Business.DataAccess.Mapper.EventLogsDataMapper";
        private EventLogs objEventLogs = null;

        public EventLogs GetDetails(SqlDataReader sqlDataReader)
        {
            try
            {
                objEventLogs = new EventLogs();
               
			   if (sqlDataReader.HasColumn(EventLogsDBFields.Id))
   objEventLogs.Id = (sqlDataReader[EventLogsDBFields.Id] != DBNull.Value ? Convert.ToInt32(sqlDataReader[EventLogsDBFields.Id]) : 0); 
if (sqlDataReader.HasColumn(EventLogsDBFields.Event))
   objEventLogs.Event = (sqlDataReader[EventLogsDBFields.Event] != DBNull.Value ? Convert.ToString(sqlDataReader[EventLogsDBFields.Event]) : string.Empty); 
if (sqlDataReader.HasColumn(EventLogsDBFields.EventBy))
   objEventLogs.EventBy = (sqlDataReader[EventLogsDBFields.EventBy] != DBNull.Value ? Convert.ToInt32(sqlDataReader[EventLogsDBFields.EventBy]) : 0); 
if (sqlDataReader.HasColumn(EventLogsDBFields.StatusId))
   objEventLogs.StatusId = (sqlDataReader[EventLogsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(sqlDataReader[EventLogsDBFields.StatusId]) : (byte)0); 
if (sqlDataReader.HasColumn(EventLogsDBFields.CreatedDate))
   objEventLogs.CreatedDate = (sqlDataReader[EventLogsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[EventLogsDBFields.CreatedDate]) : DateTime.Now); 
if (sqlDataReader.HasColumn(EventLogsDBFields.UpdatedDate))
   objEventLogs.UpdatedDate = (sqlDataReader[EventLogsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(sqlDataReader[EventLogsDBFields.UpdatedDate]) : DateTime.Now); 

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return objEventLogs;
        }
		
		public List<EventLogs> GetDetailsList(SqlDataReader sqlDataReader)
        {
            List<EventLogs> list = new List<EventLogs>();
            try
            {
                while (sqlDataReader.Read())
                {
                    objEventLogs = GetDetails(sqlDataReader);
                    list.Add(objEventLogs);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetailsList(sqlDataReader)", ex.Source, ex.Message, ex);
            }
            return list;
        }

        public List<EventLogs> GetDetails(DataSet dataSet)
        {
            List<EventLogs> EventLogss = new List<EventLogs>();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objEventLogs = new EventLogs();
                       
						if (drow.Table.Columns.Contains(EventLogsDBFields.Id)) 
  objEventLogs.Id = (drow[EventLogsDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[EventLogsDBFields.Id]) : 0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.Event)) 
  objEventLogs.Event = (drow[EventLogsDBFields.Event] != DBNull.Value ? Convert.ToString(drow[EventLogsDBFields.Event]) : string.Empty); 
if (drow.Table.Columns.Contains(EventLogsDBFields.EventBy)) 
  objEventLogs.EventBy = (drow[EventLogsDBFields.EventBy] != DBNull.Value ? Convert.ToInt32(drow[EventLogsDBFields.EventBy]) : 0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.StatusId)) 
  objEventLogs.StatusId = (drow[EventLogsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[EventLogsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.CreatedDate)) 
  objEventLogs.CreatedDate = (drow[EventLogsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[EventLogsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(EventLogsDBFields.UpdatedDate)) 
  objEventLogs.UpdatedDate = (drow[EventLogsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[EventLogsDBFields.UpdatedDate]) : DateTime.Now); 


                        EventLogss.Add(objEventLogs);
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return EventLogss;
        }
		
		public EventLogs GetDetailsobj(DataSet dataSet)
        {
            EventLogs objEventLogs = new EventLogs();

            try
            {
                if (dataSet != null && dataSet.Tables.Count > 0 && dataSet.Tables[0].Rows.Count > 0)
                {
                    foreach (DataRow drow in dataSet.Tables[0].Rows)
                    {
                        objEventLogs = new EventLogs();
                      
						if (drow.Table.Columns.Contains(EventLogsDBFields.Id)) 
  objEventLogs.Id = (drow[EventLogsDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[EventLogsDBFields.Id]) : 0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.Event)) 
  objEventLogs.Event = (drow[EventLogsDBFields.Event] != DBNull.Value ? Convert.ToString(drow[EventLogsDBFields.Event]) : string.Empty); 
if (drow.Table.Columns.Contains(EventLogsDBFields.EventBy)) 
  objEventLogs.EventBy = (drow[EventLogsDBFields.EventBy] != DBNull.Value ? Convert.ToInt32(drow[EventLogsDBFields.EventBy]) : 0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.StatusId)) 
  objEventLogs.StatusId = (drow[EventLogsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[EventLogsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.CreatedDate)) 
  objEventLogs.CreatedDate = (drow[EventLogsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[EventLogsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(EventLogsDBFields.UpdatedDate)) 
  objEventLogs.UpdatedDate = (drow[EventLogsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[EventLogsDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(dataSet)", ex.Source, ex.Message, ex);
            }

            return objEventLogs;
        }
		
		public EventLogs GetDetails(DataTable dataTable)
        {
            EventLogs objEventLogs = new EventLogs();

            try
            {
                if (dataTable != null &&  dataTable.Rows.Count > 0)
                {
                    foreach (DataRow drow in dataTable.Rows)
                    {
                        objEventLogs = new EventLogs();
                      
						if (drow.Table.Columns.Contains(EventLogsDBFields.Id)) 
  objEventLogs.Id = (drow[EventLogsDBFields.Id] != DBNull.Value ? Convert.ToInt32(drow[EventLogsDBFields.Id]) : 0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.Event)) 
  objEventLogs.Event = (drow[EventLogsDBFields.Event] != DBNull.Value ? Convert.ToString(drow[EventLogsDBFields.Event]) : string.Empty); 
if (drow.Table.Columns.Contains(EventLogsDBFields.EventBy)) 
  objEventLogs.EventBy = (drow[EventLogsDBFields.EventBy] != DBNull.Value ? Convert.ToInt32(drow[EventLogsDBFields.EventBy]) : 0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.StatusId)) 
  objEventLogs.StatusId = (drow[EventLogsDBFields.StatusId] != DBNull.Value ? Convert.ToByte(drow[EventLogsDBFields.StatusId]) : (byte)0); 
if (drow.Table.Columns.Contains(EventLogsDBFields.CreatedDate)) 
  objEventLogs.CreatedDate = (drow[EventLogsDBFields.CreatedDate] != DBNull.Value ? Convert.ToDateTime(drow[EventLogsDBFields.CreatedDate]) : DateTime.Now); 
if (drow.Table.Columns.Contains(EventLogsDBFields.UpdatedDate)) 
  objEventLogs.UpdatedDate = (drow[EventLogsDBFields.UpdatedDate] != DBNull.Value ? Convert.ToDateTime(drow[EventLogsDBFields.UpdatedDate]) : DateTime.Now); 

                        
                    }
                }

            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetDetails(DataTable)", ex.Source, ex.Message, ex);
            }

            return objEventLogs;
        }

    }
}

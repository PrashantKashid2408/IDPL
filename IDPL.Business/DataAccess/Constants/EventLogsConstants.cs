using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DataAccess.Constants
{
    public class EventLogsDBFields
    {

	
        public static string IU_Flag = "IU_Flag"; 


		

        public static string TableNameVal = "EventLogs";
public static string  Id = "Id";
public static string  Event = "Event";
public static string  EventBy = "EventBy";
public static string  StatusId = "StatusId";
public static string  CreatedDate = "CreatedDate";
public static string  UpdatedDate = "UpdatedDate";

      
    }
    public class EventLogsStoredProcedures
    {

        #region Object StoredProcedure

		



		
        public static string EventLogsSAVE = "EventLogs_SAVE";
        public static string EventLogsGetRecordById = "EventLogs_GetRecordById";

        public static string GetEventLogsRecords = "EventLogs_GetRecords";
        public static string GetEventLogsRecordByValue =  "EventLogs_GetRecordByValue";
        public static string GetEventLogsRecordByValueArray = "EventLogs_GetRecordByValueArray";
         
        #endregion

        #region Collection StoredProcedure
		 
        public static string EventLogsSearch = "EventLogs_Search";
        public static string EventLogsSearchByValue =  "EventLogs_SearchByValue";
        public static string EventLogsSearchByValueArray = "EventLogs_SearchByValueArray";
        #endregion
 
        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";


      
    }
}

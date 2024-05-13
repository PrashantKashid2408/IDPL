using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DataAccess.Constants
{
    public class UsersDBFields
    {
        public static string IU_Flag = "IU_Flag";

        public static string TableNameVal = "Users";
        public static string Id = "Id";
        public static string UserName = "UserName";
        public static string Password = "Password";
        public static string RoleId = "RoleId";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
    }

    public class UsersStoredProcedures
    {
        #region Object StoredProcedure

        public static string UsersSAVE = "Users_SAVE";
        public static string Users_Login = "Users_Login";

        public static string UsersGetRecordById = "Users_GetRecordById";

        public static string GetUsersRecords = "Users_GetRecords";
        public static string GetUsersRecordByValue = "Users_GetRecordByValue";
        public static string GetUsersRecordByValueArray = "Users_GetRecordByValueArray";

        #endregion Object StoredProcedure

        #region Collection StoredProcedure

        public static string UsersSearch = "Users_Search";
        public static string UsersSearchByValue = "Users_SearchByValue";
        public static string UsersSearchByValueArray = "Users_SearchByValueArray";

        #endregion Collection StoredProcedure

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";
    }
}
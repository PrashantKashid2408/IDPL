using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Business.DataAccess.Constants
{
    public class OperatorDBFields
    {
        public static string IU_Flag = "IU_Flag";

        public static string TableNameVal = "Operator";
        public static string ID = "ID";
        public static string UserId = "UserId";
        public static string OperatorName = "OperatorName";
        public static string UserName = "UserName";
        public static string Password = "Password";
        public static string StatusId = "StatusId";
        public static string CreatedDate = "CreatedDate";
        public static string UpdatedDate = "UpdatedDate";
    }

    public class OperatorStoredProcedures
    {
        #region Object StoredProcedure

        public static string OperatorSAVE = "Operator_SAVE";
        public static string OperatorGetRecordById = "Operator_GetRecordById";

        public static string GetOperatorRecords = "Operator_GetRecords";
        public static string OperatorChageStatus = "Operator_ChangeStatus";
        public static string GetOperatorRecordByValue = "Operator_GetRecordByValue";
        public static string GetOperatorRecordByValueArray = "Operator_GetRecordByValueArray";

        #endregion Object StoredProcedure

        #region Collection StoredProcedure

        public static string OperatorSearch = "Operator_Search";
        public static string OperatorSearchByValue = "Operator_SearchByValue";
        public static string OperatorSearchByValueArray = "Operator_SearchByValueArray";

        #endregion Collection StoredProcedure

        public static string IsExist = "";
        public static string GetCollectionForQuery = "";
        public static string SortingString = "SortOrder";
    }
}
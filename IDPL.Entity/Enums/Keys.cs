namespace Core.Entity.Enums
{
    public class KeyEnums
    {
        public enum JsonMessageType
        {
            PRIMARY,
            INFO,
            SUCCESS,
            WARNING,
            DANGER,
            ERROR,
            FAILURE,
            DEFAULT,
            LOGIN_USING_CODE
        }

        public enum FileUploadApiKeys
        {
            FILE_UPLOAD_KEY,
            FILE_UPLOAD_VIRTUAL_PATH,
            FILE_UPLOAD_NAME,
            FILE_UPLOAD_DELETE_EXISTING,
            FILE_UPLOAD_FLAG
        }

        public enum MenuKeys
        {
            liAdmin,
            liOperators
        }

        public enum SessionKeys
        {
            UserId,
            UserCreatedById,
            UserName,
            UserRole,
            UserRoleName,
            FirstName,
            LastName,
            UserSession,
            GridPageSize
        }

        public enum ApplicationKeys
        {
            Languages = 0,
            Formats = 1,
            Countries = 2,
            Communites = 3,
            SocialMediaMaster = 4,
            LanguagesSelectAll = 5,
        }

        public enum ListType
        {
            AllViews,
            AllTran,
            WordCloud
        }

        public enum TempDataKeys
        {
            Flag,
            MessageToClient,
            WarningMessage,
            InfoMessage
        }
    }
}
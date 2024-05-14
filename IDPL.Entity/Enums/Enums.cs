using System.Collections.Generic;

namespace Core.Entity.Enums
{

    public class RoleEnums
    {
        public const string Admin = "1";
        public const string Operator = "2";


        public enum Role
        {
            Admin = 1,
            Operator = 2,

        }
    }

    public class StateEnums
    {
        public enum Mode
        {
            Create = 0,
            Edit = 1,
            Delete = 2,
            EditProfile = 3,
            User = 4,
            Read = 5,
            Resend = 6,
            Verify = 7,
            Lock = 8,
            Register = 9
        }

        public enum PasswordStatus
        {
            NotChanged = 0,
            Changed = 1,
        }
        /// <summary>
        /// database statusid
        /// </summary>
        public enum Statuses : byte
        {
            InActive = 0,
            Active = 1,
            Deleted = 2,
            Pending = 3
        }
    }

    public class NotificationEnums
    {
        public enum MailSent : byte
        {
            NotSent = 0,
            SentToUser = 1
        }
    }

    public enum Source
    {
        Google = 1,
        Facebook = 2,
        Twitter = 3,
        Microsoft = 4
    }

    public enum RequestMadeBy : byte
    {
        Website = 1,
        RequestAPI = 2,
        ResponseAPI = 3,
        RequestBulkSave = 4
    }

    public enum UserRole : byte
    {
        ADMIN = 1,
        GeneralAdmin = 2,
        RegionalAdmin = 3,
        Doctor = 4,
        Patient = 5
    }

    public enum UserRoleLevel : byte
    {
        Level_0 = 1,
        GeneralAdmin = 2,
        Level_1 = 3,
        Editor = 4,
        Level_2 = 5,
        Level_3 = 6,
        Level_4 = 7,
        Level_5 = 8
    }
    public enum EnquiryStatus : byte
    {
        Enquired = 1,
        AdFormSent = 2,
        Admitted = 3,
        Rejected = 4,
        Waitlisted = 5,
        Cold = 6,
        Warm = 7,
        Hot = 8,
        Lost = 9,
        Consulted = 10,
        Evaluated = 11,
        AdCancelled = 12
    }

    public class LoginMode
    {
        public const string CMS = "cms";
        public const string APP = "app";
        public const string COOKIE = "cookie";

        public enum LoginModeType
        {
            CMS = 1,
            APP = 2,
        }
    }

    public class ColorCodes
    {
        public const string Green = "#3AA84C";
        public const string Red = "#C84D4D";
        public const string Orange = "#F48242";
        public const string Yellow = "#E8C031";
        public const string White = "#44000000";

    }

    public class SMSDLTTemplateID
    {
        public const string Mailer = "1307160993373136684";
        public const string TriggerMail = "1307160993380943077";
    }

}

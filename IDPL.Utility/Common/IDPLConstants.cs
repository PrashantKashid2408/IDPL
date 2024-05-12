using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;
using System.Security.Permissions;

namespace Core.Utility.Common
{
    public class ShikshaConstants
    {
        private static IConfiguration Configuration;

        public static string GetAppSetting(string appSettingKey)
        {
            var builder = new ConfigurationBuilder().SetBasePath(Directory.GetCurrentDirectory()).AddJsonFile("appsettings.json", optional: false);
            Configuration = builder.Build();

            string[] SplittedKey = appSettingKey.Split(":");

            string PureKey = SplittedKey[(SplittedKey.Length) - 1];

            bool a = Configuration.GetChildren().Any(item => item.Key == appSettingKey);
            string appSettingValue = Configuration.GetValue<string>(appSettingKey);

            return appSettingValue;
        }

        #region AppSettings

        public static readonly string OnAuthorizationController = GetAppSetting("AppSettings:OnAuthorizationController");
        public static readonly string OnAuthorizationAction = GetAppSetting("AppSettings:OnAuthorizationAction");
        public static readonly string AppName = GetAppSetting("AppSettings:AppName");
        public static readonly string Environment = GetAppSetting("AppSettings:Environment");
        public static readonly string RootPath = GetAppSetting("AppSettings:RootPath");
        public static readonly string PhyPath = GetAppSetting("AppSettings:PhyPath");
        public static readonly string TemplatePath = GetAppSetting("AppSettings:TemplatePath");
        public static readonly string ShikshaDomain = GetAppSetting("AppSettings:ShikshaDomain");
        public static readonly string DeepLinkEncodePrefix = GetAppSetting("AppSettings:DeepLinkEncodePrefix");
        public static readonly string shortURL = GetAppSetting("AppSettings:shortURL");
        public static readonly string Cachedate = GetAppSetting("AppSettings:Cachedate");
        public static readonly string DefaultController = GetAppSetting("AppSettings:DefaultController");
        public static readonly string DefaultView = GetAppSetting("AppSettings:DefaultView");
        public static readonly string TeacherDefaultController = GetAppSetting("AppSettings:TeacherDefaultController");
        public static readonly string TeacherDefaultView = GetAppSetting("AppSettings:TeacherDefaultView");

        public static readonly string LoginCookie = GetAppSetting("AppSettings:LoginCookie");
        public static readonly string GeocodingAPIURL = GetAppSetting("AppSettings:GeocodingAPIURL");
        public static readonly string GeocodingAPIKey = GetAppSetting("AppSettings:GeocodingAPIKey");
        public static readonly string ProfilePicture = GetAppSetting("AppSettings:ProfilePicture");
        public static readonly string CreditNoteDocumentPath = GetAppSetting("AppSettings:CreditNoteDocumentPath");
        public static readonly string SchoolStamp = GetAppSetting("AppSettings:SchoolStamp");
        public static readonly string SchoolSignature = GetAppSetting("AppSettings:SchoolSignature");
        public static readonly string MealIcon = GetAppSetting("AppSettings:MealIcon");
        public static readonly string ReceiptSignature = GetAppSetting("AppSettings:ReceiptSignature");
        public static readonly string QualificationDoc = GetAppSetting("AppSettings:QualificationDoc");
        public static readonly string Attendance = GetAppSetting("AppSettings:Attendance");
        public static readonly string Event = GetAppSetting("AppSettings:Event");
        public static readonly string SHORTURL_key_size = GetAppSetting("AppSettings:SHORTURL_key_size");
        public static readonly string PictureQuality = GetAppSetting("AppSettings:PictureQuality");
        public static readonly string WebPQuality = GetAppSetting("AppSettings:WebPQuality");
        public static readonly string ApplicationPath = GetAppSetting("AppSettings:ApplicationPath");
        public static readonly string ClassInstaIMGPath = GetAppSetting("AppSettings:ClassInstaIMGPath");
        public static readonly string ClassInstaVIDPath = GetAppSetting("AppSettings:ClassInstaVIDPath");
        public static readonly string SchoolDocumentsPath = GetAppSetting("AppSettings:SchoolDocumentsPath");
        public static readonly string SchoolDailyDiaryPath = GetAppSetting("AppSettings:SchoolDailyDiaryPath");
        public static readonly string SchoolAttendancePath = GetAppSetting("AppSettings:SchoolAttendancePath");
        public static readonly string LessonPlanPath = GetAppSetting("AppSettings:LessonPlanPath");
        public static readonly string Bulk_Stduent_XL_Path = GetAppSetting("AppSettings:Bulk_Stduent_XL_Path");
        public static readonly string Bulk_Teacher_XL_Path = GetAppSetting("AppSettings:Bulk_Teacher_XL_Path");
        public static readonly string CurriculumPath = GetAppSetting("AppSettings:CurriculumPath");
        public static readonly string MobileAppRoot = GetAppSetting("AppSettings:MobileAppRoot");
        public static readonly string ExcelSummary = GetAppSetting("AppSettings:ExcelSummary");
        public static readonly string DefaultEmailPrefix = GetAppSetting("AppSettings:DefaultEmailPrefix");
        public static readonly string ToondemyLessonPlanPath = GetAppSetting("AppSettings:ToondemyLessonPlanPath");
        public static readonly string ToondemyCurriculumPath = GetAppSetting("AppSettings:ToondemyCurriculumPath");
        public static readonly string newWidth = GetAppSetting("AppSettings:NewWidth");
        public static readonly string newHeight = GetAppSetting("AppSettings:NewHeight");
        public static readonly string RoleID = GetAppSetting("AppSettings:RoleID");
        public static readonly string SuccessURL = GetAppSetting("AppSettings:SuccessURL");
        public static readonly string EnquiryQRPath = GetAppSetting("AppSettings:EnquiryQRPath");
        public static readonly string EnquiryImages = GetAppSetting("AppSettings:EnquiryImages");

        #endregion AppSettings

        #region AppMailerSettings

        public static readonly string UseSmtpCredentials = GetAppSetting("AppMailerSettings:UseSmtpCredentials");
        public static readonly string UseDefaultCredentials = GetAppSetting("AppMailerSettings:UseDefaultCredentials");
        public static readonly string SmtpUsername = GetAppSetting("AppMailerSettings:SmtpUsername");
        public static readonly string SmtpPassword = GetAppSetting("AppMailerSettings:SmtpPassword");
        public static readonly string SmtpHost = GetAppSetting("AppMailerSettings:SmtpHost");
        public static readonly string SmtpPort = GetAppSetting("AppMailerSettings:SmtpPort");
        public static readonly string EnableSsl = GetAppSetting("AppMailerSettings:EnableSsl");
        public static readonly string DefaultHost = GetAppSetting("AppMailerSettings:DefaultHost");

        public static readonly string ResetPassword_Subject = GetAppSetting("AppMailerSettings:ResetPassword_Subject");
        public static readonly string WelcomeEmail_Subject = GetAppSetting("AppMailerSettings:WelcomeEmail_Subject");
        public static readonly string Assessment_Approval_Subject = GetAppSetting("AppMailerSettings:Assessment_Approval_Subject");
        public static readonly string Assessment_Approved_Subject = GetAppSetting("AppMailerSettings:Assessment_Approved_Subject");
        public static readonly string Assessment_Rejection_Subject = GetAppSetting("AppMailerSettings:Assessment_Rejection_Subject");
        public static readonly string Portfolio_Approval = GetAppSetting("AppMailerSettings:Portfolio_Approval");
        public static readonly string Portfolio_Approved = GetAppSetting("AppMailerSettings:Portfolio_Approved");
        public static readonly string Portfolio_Rejection = GetAppSetting("AppMailerSettings:Portfolio_Rejection");
        public static readonly string BulkStudentUpload = GetAppSetting("AppMailerSettings:BulkStudentUpload");
        public static readonly string BulkTeacherUpload = GetAppSetting("AppMailerSettings:BulkTeacherUpload");

        #endregion AppMailerSettings

        #region AppMailer

        public static readonly string DefaultmailID = GetAppSetting("AppMailer:DefaultmailID");
        public static readonly string Account_Confirmation = GetAppSetting("AppMailer:Account_Confirmation");
        public static readonly string ReplyToEmail = GetAppSetting("AppMailer:ReplyToEmail");
        public static readonly string CareEmail = GetAppSetting("AppMailer:CareEmail");

        #endregion AppMailer

        #region Logging

        public static readonly string LOG_FOLDER_PATH = GetAppSetting("Logging:LOG_FOLDER_PATH");
        public static readonly string LOG_EMAIL_SENDER = GetAppSetting("Logging:LogMailer:LOG_EMAIL_SENDER");
        public static readonly string LOG_EMAIL_RECEIVER = GetAppSetting("Logging:LogMailer:LOG_EMAIL_RECEIVER");
        public static readonly string LOG_EMAIL_SUBJECT = GetAppSetting("Logging:LogMailer:LOG_EMAIL_SUBJECT");
        public static readonly string LOG_EMAIL_IS_SEND = GetAppSetting("Logging:LogMailer:LOG_EMAIL_IS_SEND");
        public static readonly string LOG_EMAIL_CC = GetAppSetting("Logging:LogMailer:LOG_EMAIL_CC");
        public static readonly string LOG_EMAIL_BCC = GetAppSetting("Logging:LogMailer:LOG_EMAIL_BCC");
        public static readonly string ErrorLogEmailSubject = GetAppSetting("Logging:LogMailer:ErrorLogEmailSubject");

        #endregion Logging

        #region AppEncryption

        public static readonly string AESUserEncrryptKey = GetAppSetting("AppEncryption:AESUserEncrryptKey");
        public static readonly string AESUserVector = GetAppSetting("AppEncryption:AESUserVector");
        public static readonly string AESUserSalt = GetAppSetting("AppEncryption:AESUserSalt");

        #endregion AppEncryption

        #region AppMessenger

        public static readonly string MSG91Key = GetAppSetting("AppMessenger:MSG91Key");
        public static readonly string MSG91SenderId = GetAppSetting("AppMessenger:MSG91SenderId");
        public static readonly string MSG91Route = GetAppSetting("AppMessenger:MSG91Route");
        public static readonly string MSG91APIUrl = GetAppSetting("AppMessenger:MSG91APIUrl");

        #endregion AppMessenger

        #region CG

        public static readonly string CGAPIKey = GetAppSetting("CG:CGAPIKey");
        public static readonly string CGRegisterParent = GetAppSetting("CG:CGRegisterParent");
        public static readonly string CGRegisterKid = GetAppSetting("CG:CGRegisterKid");
        public static readonly string CGAddAssignment = GetAppSetting("CG:CGAddAssignment");
        public static readonly string CGUrl = GetAppSetting("CG:CGUrl");
        public static readonly string CGAddAssg_ShortUrl = GetAppSetting("CG:CGAddAssg_ShortUrl");
        public static readonly string CGApiToken = GetAppSetting("CG:CGApiToken");
        public static readonly string M3u8Video = GetAppSetting("CG:M3u8Video");
        public static readonly string AddStudentBridgeAPI = GetAppSetting("CG:AddStudentBridgeAPI");
        public static readonly string UpdateStudentBridgeAPI = GetAppSetting("CG:UpdateStudentBridgeAPI");
        public static readonly string CGGradeType = "general";

        #endregion CG

        #region JWTSettings

        public static readonly string JWT_expires = GetAppSetting("JWTSettings:expires");
        public static readonly string JWT_issuer = GetAppSetting("JWTSettings:issuer");
        public static readonly string JWT_audience = GetAppSetting("JWTSettings:audience");
        public static readonly string JWT_secret = GetAppSetting("JWTSettings:secret");

        #endregion JWTSettings

        #region FirebaseSettings

        public static readonly string FirebaseServerKey = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string FirebaseOrganizationId = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasecontent_available = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasepriority = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasesound = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string Firebasebadge = GetAppSetting("FirebaseSettings:ServerKey");
        public static readonly string FIRESTORE_KEY = GetAppSetting("FirebaseSettings:FIRESTORE_KEY");
        public static readonly string FIRESTORE_Project_ID = GetAppSetting("FirebaseSettings:FIRESTORE_Project_ID");

        #endregion FirebaseSettings

        #region Notifications

        public static readonly string NotificationAppName = GetAppSetting("PushNotification:AppName");
        public static readonly string ClassInsta_SubTitle = GetAppSetting("PushNotification:ClassInsta_SubTitle");
        public static readonly string ClassInsta_OpeartionalURL = GetAppSetting("PushNotification:ClassInsta_OpeartionalURL");

        public static readonly string Assignment_SubTitle = GetAppSetting("PushNotification:Assignment_SubTitle");
        public static readonly string Assignment_OpeartionalURL = GetAppSetting("PushNotification:Assignment_OpeartionalURL");

        public static readonly string Evaluation_SubTitle = GetAppSetting("PushNotification:Evaluation_SubTitle");
        public static readonly string Evaluation_OpeartionalURL = GetAppSetting("PushNotification:Evaluation_OpeartionalURL");

        public static readonly string Portfolio_SubTitle = GetAppSetting("PushNotification:Portfolio_SubTitle");
        public static readonly string Portfolio_OpeartionalURL = GetAppSetting("PushNotification:Portfolio_OpeartionalURL");

        public static readonly string Worksheet_SubTitle = GetAppSetting("PushNotification:Worksheet_SubTitle");
        public static readonly string Worksheet_OpeartionalURL = GetAppSetting("PushNotification:Worksheet_OpeartionalURL");

        public static readonly string DocumentPermission_SubTitle = GetAppSetting("PushNotification:DocumentPermission_SubTitle");
        public static readonly string DocumentPermission_OpeartionalURL = GetAppSetting("PushNotification:DocumentPermission_OpeartionalURL");

        #endregion Notifications

        #region Reports

        public static readonly string EvaluationReportsPath = GetAppSetting("Reports:Evaluation");
        public static readonly string PortfolioReportsPath = GetAppSetting("Reports:Portfolio");
        public static readonly string AttendanceReportsPath = GetAppSetting("Reports:Attendance");
        public static readonly string InvoiceReportsPath = GetAppSetting("Reports:Invoice");
        public static readonly string PaymentReceiptPath = GetAppSetting("Reports:Receipt");
        public static readonly string DepositPath = GetAppSetting("Reports:Deposit");
        public static readonly string AdvancePaymentPath = GetAppSetting("Reports:AdvancePayment");
        public static readonly string CreditNotePath = GetAppSetting("Reports:CreditNote");
        public static readonly string RefundPath = GetAppSetting("Reports:Refund");
        public static readonly string EnquiryPath = GetAppSetting("Reports:EnquiryPath");
        public static readonly string FinanceLogPath = GetAppSetting("Reports:FinanceLogPath");

        #endregion Reports

        #region OTP

        public static readonly string SenderId = GetAppSetting("OTP:SenderId");
        public static readonly string MSG91AuthKey = GetAppSetting("OTP:MSG91AuthKey");
        public static readonly string TemplateId = GetAppSetting("OTP:TemplateId");
        public static readonly string CompanyName = GetAppSetting("OTP:CompanyName");
        public static readonly string OTPSMSUri = GetAppSetting("OTP:OTPSMSUri");

        #endregion OTP

        #region RazorPay

        public static readonly string RazorPayKey = GetAppSetting("RazorPay:Key");
        public static readonly string RazorPaySecret = GetAppSetting("RazorPay:Secret");
        public static readonly string OrderIdURL = GetAppSetting("RazorPay:OrderIdURL");

        #endregion RazorPay

        public static readonly string ShikshaDomainSiteRUL = URLDetails.GetSiteRootUrl().TrimEnd('/');

        public static readonly int SQLCommandTimeOut = GetAppSetting("ConnectionStrings:SQLCommandTimeOut") != "" ? Convert.ToInt32(GetAppSetting("SQLCommandTimeOut")) : 0;

        //Paths
        public static readonly string UploadFetchVir = @"/ALLContent/User/[UserID]/UploadFetch/";

        public static readonly string UploadFetchPhy = @"\ALLContent\User\[UserID]\UploadFetch\";
        public static readonly string UploadFetchTemplateVir = @"/Templates/Excel/UploadFetch.xls";
        public static readonly string UploadFetchTemplatePhy = @"\Templates\Excel\TD-Academy-Student-Details-Upload-Template.xlsx";

        public static readonly string UploadFetchTempVir = @"/ALLContent/Temp/";
        public static readonly string UploadFetchTempPhy = @"\ALLContent\Temp\";

        public static readonly string ContentNoLogoPathVir = "/Content/images/no-logo.jpg";

        public static readonly string AttendancePath = "//wwwroot//UserData//Attendance//";
        public static readonly string UserDataTempPath = "//wwwroot//UserData//TEMP";
        public static readonly string TempDomain = "//UserData/TEMP/";
        public static readonly string SchoolDataExcelPath = "\\wwwroot\\UserData\\SchoolData\\Excel\\";
        public static readonly string ClassInstaMediaThumbnailPath = "//wwwroot//UserData//ClassInstaMedia//Thumbnail//";
        public static readonly string ClassChatThumbnailPath = "//wwwroot//UserData//ClassChat//Thumbnail//";
        public static readonly string DynamicEmailDomain = "creativegalileo.com";

        public static class Modules
        {
            public const string StudentDetailsController = "Shiksha.Controllers.App.StudentDetailsController";
            public const string ClassController = "Shiksha.Controllers.App.ClassController";
            public const string AdminController = "Shiksha.Controllers.App.AdminController";
            public const string ExportExcelController = "Shiksha.Controllers.App.ExportExcelController";
            public const string UserController = "Shiksha.Controllers.App.UserController";
            public const string ClassInstaController = "Shiksha.Controllers.App.ClassInstaController";
            public const string DocumentsController = "Shiksha.Controllers.App.DocumentsController";
            public const string PortfolioController = "Shiksha.Controllers.App.PortfolioController";
            public const string AdvancePaymentController = "Shiksha.Controllers.AdvancePaymentController";
            public const string DeleteUserController = "Shiksha.Controllers.DeleteUserController";
            public const string SchoolsApiController = "Shiksha.Controllers.App.SchoolsApiController";
            public const string ClassesApiController = "Shiksha.Controllers.App.ClassesApiController";
            public const string TeachersApiController = "Shiksha.Controllers.App.TeachersApiController";
            public const string StudentsApiController = "Shiksha.Controllers.App.StudentsApiController";
            public const string InvoiceApiController = "Shiksha.Controllers.App.InvoiceApiController";
            public const string DepositApiController = "Shiksha.Controllers.App.DepositApiController";
            public const string PaymentApiController = "Shiksha.Controllers.App.PaymentApiController";
            public const string CreditNoteApiController = "Shiksha.Controllers.App.CreditNoteApiController";
            public const string ReceiptApiController = "Shiksha.Controllers.App.ReceiptApiController";
            public const string RefundApiController = "Shiksha.Controllers.App.RefundApiController";
            public const string AttendanceApiController = "Shiksha.Controllers.App.AttendanceApiController";
            public const string SchoolHQApiController = "Shiksha.Controllers.App.SchoolHQApiController";
            public const string GradeApiController = "Shiksha.Controllers.App.GradeApiController";
            public const string AcademicYearApiController = "Shiksha.Controllers.App.AcademicYearApiController";
            public const string SSOController = "Shiksha.Controllers.SSOController";
        }

        public static class CacheKey
        {
            public const string AdvancePaymentCacheKey = "AdvancePaymentController_";
        }

        public static class TypeEnums
        {
            public const string DefaultType = "0";
            public const string InvoiceType = "1";
            public const string DepositType = "2";
            public const string ReceiptType = "3";
            public const string AdvancePaymentType = "4";
            public const string CreditNoteType = "5";
            public const string RefundType = "6";
            public const string StudentLimit = "7";
        }

        public static class Common
        {
            public const string NA = "NA";
            public const string LoginCode = "1234";
            public const string AttendanceReportTemplate = "~/views/Report/AttendanceReport.cshtml";
            public const string Depricated328 = "API was deprecated from V3.2.8";
            public const string Depricated329 = "API was deprecated from V3.2.9";
        }

        public static class Relation
        {
            public const string Mother = "mother";
            public const string Father = "father";
            public const string Boy = "boy";
            public const string Male = "male";
            public const string Emergency = "Emergency";
        }

        public static class Operation
        {
            public const string Update = "UPDATE";
            public const string Insert = "INSERT";
            public const string I = "I";
            public const string U = "U";
        }

        public static class RegularExpressions
        {
            public const string SpecialCharPattern = "^[a-zA-Z0-9 ._-]*$";
        }

        public static class DateFormats
        {
            public const string YYYYMMDDTimeFormat = "yyyy-MM-dd hh:mm:ss";
            public const string YYYYMMDDDateFormat = "yyyy-MM-dd";
            public const string YYYYMMDDFullTimeFormat = "yyyy-MM-dd--HH-mm-ss-fff";
            public const string DDMMYYYYTimeFormat = "dd/MM/yyyy";
            public const string YYYYMMDDHHmmssTimeFormat = "yyyyMMddHHmmss";
            public const string MMDDYYYYDateFormat = "MM-dd-yyyy";
        }

        public static class Connection
        {
            // TODO: In ExportExcel.cs file we are using prod connection string directly. Let's review and remove the code if not in use.
            public const string ConnectionString = "Data Source = tcp:sandeshakamshiksha.database.windows.net,1433; Initial Catalog = tdacademy; User ID = SQLSandeshakam-Shiksha; Password = $0!S41k$H@saNd; Connect Timeout = 30; Encrypt = False; TrustServerCertificate = False; ApplicationIntent = ReadWrite; MultiSubnetFailover = False";
        }

        public static class StoredProcedureNames
        {
            public const string Student = "Report_Student";
            public const string ClassInsta = "Report_ClassInsta";
            public const string School = "Report_School";
            public const string Teacher = "Report_Teacher";
            public const string Class = "Report_Class";
            public const string AttendenceCount = "Report_AttendanceCount";
        }

        public static class JwtConfigurations
        {
            public const string JwtBearerDescription = "JWT Authorization header using the Bearer scheme. Example: \"Authorization: Bearer {token}\"";
            public const string HeaderName = "Authorization";
            public const string Schema = "Bearer";
            public const string BearerFormat = "JWT";
        }

        public static class Messages
        {
            public const string StudentLimit3 = "There are 7 active students associated with this ";

            //public const string LastStudent = "Are you sure you want on remove access of '"+{parentname}+"' and '"+{studentname}+"' from TD app?";
            public const string LastStudentM2 = "And if you disable this student above accounts will not be able to log in  ";

            public const string EnquiryStudent = "There are few students in Manage Enquiry for approval associated with this ";
        }

        public static class Gender
        {
            public const string Male = "Male";
            public const string Female = "Female";
        }
    }
}
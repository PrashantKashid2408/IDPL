using Core.Entity;
using Core.Entity.Enums;
using Core.Entity.ViewModel;
using Core.Utility;
using Core.Utility.Common;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Text;

namespace IDPL.Models
{
    public class Helper
    {
        private readonly string _module = "IDPL.Models.Helper";

        private readonly IHttpContextAccessor _httpContextAccessor;

        public Helper(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        private bool _IsRegisterProcess = false;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public bool IsRegisterProcess
        {
            get { return _IsRegisterProcess; }
            set { _IsRegisterProcess = value; }
        }

        public void KillSession()
        {
            _httpContextAccessor.HttpContext.Session.Clear();
        }

        public LoginVM GetSession()
        {
            LoginVM loginVM = new LoginVM();

            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()) != null)
                {
                    loginVM = JsonConvert.DeserializeObject<LoginVM>(_session.GetString(KeyEnums.SessionKeys.UserSession.ToString()));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetSession()", ex.Source, ex.Message, ex);
            }
            return loginVM;
        }

        public LoginVM UpdateSession(LoginVM _LoginVM)
        {
            LoginVM loginVM = new LoginVM();
            try
            {
                _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(loginVM));
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "UpdateSession()", ex.Source, ex.Message, ex);
            }
            return loginVM;
        }

        public void SetAssessmentData(Int64 ClassID, string TermID, Int64 UserID)
        {
            _session.SetString("AssessmentClassID", ClassID.ToString());
            _session.SetString("AssessmentTermID", TermID.ToString());
            _session.SetString("AssessmentUserID", UserID.ToString());
        }

        public void SetPortfolioData(Int64 ClassID, string TermID, Int64 UserID)
        {
            _session.SetString("PortfolioClassID", ClassID.ToString());
            _session.SetString("PortfolioTermID", TermID.ToString());
            _session.SetString("PortfolioUserID", UserID.ToString());
        }

        public void SetPlayLearnData(Int64 ClassID)
        {
            _session.SetString("PlayLearnClassID", ClassID.ToString());
        }

        public void SetSentenceData(Int64 ClassID, int DomainID)
        {
            _session.SetString("SentenceClassID", ClassID.ToString());
            _session.SetString("SentenceDomainID", DomainID.ToString());
        }

        public void SetWorksheetData(Int64 ClassID)
        {
            _session.SetString("WorksheetClassID", ClassID.ToString());
        }

        public void SetSession(Users user)
        {
            try
            {
                if (user != null)
                {
                    LoginVM loginVM = new LoginVM();
                    loginVM.SessionId = _session.Id;

                    loginVM.Id = user.Id;
                    loginVM.UserName = user.UserName;
                    loginVM.Password = user.Password;
                    loginVM.RoleId = (byte)user.RoleId;
                    loginVM.StatusId = user.StatusId;
                    loginVM.CreatedDate = user.CreatedDate;

                    CommonData _CommonData = new CommonData();
                    _session.SetString(KeyEnums.SessionKeys.UserId.ToString(), loginVM.Id.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserName.ToString(), loginVM.UserName.ToString());
                    _session.SetString(KeyEnums.SessionKeys.RoleId.ToString(), loginVM.RoleId.ToString());
                    _session.SetString(KeyEnums.SessionKeys.UserSession.ToString(), JsonConvert.SerializeObject(loginVM));
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "SetSession(User user)", ex.Source, ex.Message, ex);
            }
        }

        public bool IsValidUser(Int64 UserID, string RoleIDs)
        {
            bool isAllowed = false;
            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.RoleId.ToString()) == null || UserID == 0)
                    isAllowed = false;
                else if (RoleIDs.ToLower().Contains(_session.GetString(KeyEnums.SessionKeys.RoleId.ToString()).ToString().ToLower()))
                    isAllowed = true;

                if (!isAllowed)
                {
                    _httpContextAccessor.HttpContext.Response.Redirect("/Users/Login", true);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsValidUser(UserID:" + UserID + ",RoleIDs:" + RoleIDs + ")", ex.Source, ex.Message, ex);
            }
            return isAllowed;
        }

        public bool IsValidDeleteUser(Int64 UserID, string RoleIDs)
        {
            bool isAllowed = false;
            try
            {
                if (_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()) == null || UserID == 0)
                    isAllowed = false;
                else if (RoleIDs.ToLower().Contains(_session.GetString(KeyEnums.SessionKeys.UserRole.ToString()).ToString().ToLower()))
                    isAllowed = true;

                if (!isAllowed)
                {
                    _httpContextAccessor.HttpContext.Response.Redirect("/DeleteUser/Index", true);
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "IsValidDeleteUser(UserID:" + UserID + ",RoleIDs:" + RoleIDs + ")", ex.Source, ex.Message, ex);
            }
            return isAllowed;
        }
    }
}
using Core.Entity.Common;
using Core.Entity.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Core.Entity.Enums;
using IDPL.Resources;
using Core.Utility.Common;
using Core.Entity;
using Core.Business.BusinessFacade;

namespace IDPL.Controllers
{
    public class UsersController : Controller
    {
        private JsonMessage _jsonMessage = null;
        private Users users = new Users();
        private readonly string _module = "IDPL.Controllers.UsersController";
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public JsonResult Login(string username, string password, string queryString, bool isRemember, bool autologin)
        {
            try
            {
                LoginVM loginVM = new LoginVM();

                if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                {
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_emailPasswordRequired, KeyEnums.JsonMessageType.ERROR);
                }
                else
                {
                    password = new Encription().Encrypt(password);
                    _jsonMessage = IsLoginValid(username, password, LoginMode.CMS);

                    if (loginVM != null)
                    {
                        if (_jsonMessage.IsSuccess)
                        {
                            users = (Users)_jsonMessage.Data;

                            //InsertAccessMember (objUserEntity.ID, "Login", getAccessMember());
       
                            if (users.RoleID == 1)
                            {
                                _jsonMessage.ReturnUrl = ShikshaConstants.ShikshaDomain + ShikshaConstants.DefaultController + "/" + ShikshaConstants.DefaultView + "";
                            }
                            else
                            {
                                _jsonMessage.ReturnUrl = ShikshaConstants.ShikshaDomain + ShikshaConstants.TeacherDefaultController + "/" + ShikshaConstants.TeacherDefaultView + "";
                            }
                        }
                        else
                        {
                            _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_invalidEmailAddressPassword, KeyEnums.JsonMessageType.ERROR);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER, "", "username", string.Format("Method : Login(), Source : {0}, Message {1}", ex.Source, ex.Message));
            }
            return Json(_jsonMessage);
        }
        public JsonMessage IsLoginValid(string username, string password, string LoginMode = "")
        {
            Users objUserEntity = new Users();
            try
            {
                if (string.IsNullOrWhiteSpace(username))
                    _jsonMessage = new JsonMessage(false, Resource.lbl_msg_invalidEmailAddress, Resource.lbl_msg_invalidEmailAddress, KeyEnums.JsonMessageType.DANGER);
                else if (string.IsNullOrWhiteSpace(password))
                    _jsonMessage = new JsonMessage(false, Resource.lbl_msg_invalidPassowrd, Resource.lbl_msg_invalidPassowrd, KeyEnums.JsonMessageType.DANGER);
                else
                {
                    string[] Fieldsname = new string[2];
                    string[] Values = new string[2];
                    Fieldsname[0] = username;
                    Fieldsname[1] = password;
                    Values[0] = username;
                    Values[1] = password;

                    UsersBusinessFacade objUsersBusinessFacade = new UsersBusinessFacade();
                    objUserEntity = objUsersBusinessFacade.Authenticate(username, password, LoginMode);

                    if (LoginMode == "APP")
                    {
                        if (objUserEntity != null)
                        {
                            if (objUserEntity.RoleID == 1 || objUserEntity.RoleID == 2 || objUserEntity.RoleID == 3)
                            {
                                if (objUserEntity.RoleID == 3)
                                {
                                    string error_msg = "This is a school account, only teacher or parent accounts can access the app.";
                                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, error_msg, KeyEnums.JsonMessageType.FAILURE, "/User/Login");
                                    return _jsonMessage;
                                }
                                else
                                {
                                    objUserEntity = null;
                                }
                            }
                        }
                    }

                    if (objUserEntity != null)
                    {
                        if (objUserEntity.LoginCode == password)
                        {
                            _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, "strUrl", KeyEnums.JsonMessageType.LOGIN_USING_CODE.ToString(), objUserEntity);
                        }
                        else
                        {
                            if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Active)
                            {
                                _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, "strUrl", "true", objUserEntity);
                            }
                            else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Pending)
                            {
                                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_accountNotActivated, KeyEnums.JsonMessageType.FAILURE, "/User/Login");
                            }
                            else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.InActive)
                            {
                                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_accountDisabled, KeyEnums.JsonMessageType.FAILURE, "/User/Login");
                            }
                            else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Deleted)
                            {
                                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_accountDeleted, KeyEnums.JsonMessageType.FAILURE, "/User/Login");
                            }
                            else if (objUserEntity.StatusId == (byte)StateEnums.Statuses.Active && objUserEntity.IsEmailVerified == true)
                            {
                                _jsonMessage = new JsonMessage(true, Resource.lbl_Cap_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, "StrUrl", "true", objUserEntity);
                            }
                            else
                            {
                                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_loginFailed, KeyEnums.JsonMessageType.ERROR);
                            }
                        }
                    }
                    else
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_invalidEmpIdAddressPassword, KeyEnums.JsonMessageType.ERROR);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_msg_internalServerErrorOccurred, Resource.lbl_msg_internalServerErrorOccurred, KeyEnums.JsonMessageType.ERROR, ex.Message);
                Log.WriteLog(_module, "IsLoginValid(username=" + username + ", password=" + password + ")", ex.Source, ex.Message, ex);
            }

            return _jsonMessage;
        }
    }
}

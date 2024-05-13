using Core.Business.BusinessFacade;
using Core.Entity;
using Core.Entity.Common;
using Core.Entity.Enums;
using Core.Entity.ViewModel;
using Core.Utility.Common;
using IDPL.Models;
using IDPL.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using IHostingEnvironment = Microsoft.AspNetCore.Hosting.IHostingEnvironment;

namespace IDPL.Controllers
{
    public class UsersController : Controller
    {
        private JsonMessage _jsonMessage = null;
        private Users users = new Users();
        private readonly string _module = "IDPL.Controllers.UsersController";
        private Helper _helper;
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        private ISession _session => _httpContextAccessor.HttpContext.Session;

        public UsersController(IHostingEnvironment environment = null, IHttpContextAccessor httpContextAccessor = null)
        {
            _helper = new Helper(_httpContextAccessor);
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Operators()
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
                            Users objUsers = new Users();
                            objUsers = (Users)_jsonMessage.Data;

                           _helper.SetSession(objUsers);

                            //InsertAccessMember (objUserEntity.ID, "Login", getAccessMember());

                            if (users.RoleId == 1)
                            {
                                _jsonMessage.ReturnUrl = "https://localhost:7033/Admin/Index";
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
                UsersBusinessFacade objUsersBusinessFacade = new UsersBusinessFacade();
                objUserEntity = objUsersBusinessFacade.Authenticate(username, password, LoginMode);

                if (objUserEntity != null)
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
                    else
                    {
                        _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_loginFailed, KeyEnums.JsonMessageType.ERROR);
                    }
                }
                else
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_invalidEmpIdAddressPassword, KeyEnums.JsonMessageType.ERROR);
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
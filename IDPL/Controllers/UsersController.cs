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
        
        private readonly string _module = "IDPL.Controllers.UsersController";
        
        private readonly IHttpContextAccessor _httpContextAccessor;
        private IHostingEnvironment _hostingEnvironment;
        private IMemoryCache _cache;
        private ISession _session => _httpContextAccessor.HttpContext.Session;
        private Users users = new Users();
        private JsonMessage _jsonMessage = null;
        private Helper _helper;
        private LoginVM _loginVM = null;

        public UsersController(IHostingEnvironment environment = null, IHttpContextAccessor httpContextAccessor = null, IMemoryCache cache = null)
        {
            _hostingEnvironment = environment;
            _httpContextAccessor = httpContextAccessor;
            _cache = cache;
            _helper = new Helper(_httpContextAccessor);
            _loginVM = _helper.GetSession();
        }

        public IActionResult Login()
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

                            if (objUsers.RoleId == 1)
                            {
                                _jsonMessage.ReturnUrl = "https://localhost:7033/Operators/Index";
                            }
                            else if (objUsers.RoleId == 2)
                            {
                                _jsonMessage.ReturnUrl = "https://localhost:7033/Home/Index";
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
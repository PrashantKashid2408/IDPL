using Core.Business.BusinessFacade;
using Core.Entity;
using Core.Entity.Common;
using Core.Entity.Enums;
using Core.Utility.Common;
using IDPL.Models;
using IDPL.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Caching.Memory;
using Newtonsoft.Json;
using X.PagedList;

namespace IDPL.Controllers
{
    public class OperatorsController : Controller
    {
        private static string _module = "Shiksha.Controllers.OperatorsController";

        private Int64 _userId = 0;
        private string _roleId = "";
        private string _cacheKey = "OperatorsController_";
        private JsonMessage _jsonMessage = null;
        private int page = 1, size = 10;
        private bool isValidUser = false;
        private IMemoryCache _cache;
        private Helper _helper;
        private List<Operator> _list = new List<Operator>();
        private readonly IHttpContextAccessor _httpContextAccessor;

        public OperatorsController(IHttpContextAccessor httpContextAccessor = null, IMemoryCache cache = null)
        {
            _cache = cache;
            _httpContextAccessor = httpContextAccessor;
            _helper = new Helper(_httpContextAccessor);
            _userId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString()) != null ? Convert.ToInt64(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.UserId.ToString())) : 0;
            _roleId = httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.RoleId.ToString()) != null ? Convert.ToString(httpContextAccessor.HttpContext.Session.GetString(KeyEnums.SessionKeys.RoleId.ToString())) : "";
            isValidUser = _helper.IsValidUser(_userId, RoleEnums.Admin);
        }

        public IActionResult Index()
        {
            ViewBag.MenuId = KeyEnums.MenuKeys.liOperators.ToString();
            if (isValidUser)
            {
                try
                {
                    _list = GetList("", "", "asc", ref page, ref size, "sort", "", "", _userId, true, ViewBag.RequestList);
                }
                catch (Exception ex)
                {
                    Log.WriteLog(_module, "Index", ex.Source, ex.Message, ex);
                }
            }
            return View(_list.ToPagedList(1, 10));
        }

        public IActionResult AddOperator(string id = "0")
        {
            List<Operator> _lstobj = new List<Operator>();
            Operator objSM = new Operator();
            try
            {
                if (id != "0")
                {
                    _lstobj = new OperatorBusinessFacade().GetRecordsBy_ID(id);
                }
                else
                {
                    _lstobj = null;
                }

                if (_lstobj != null)
                    objSM = _lstobj[0];
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "AddOperator(id:" + id + ")", ex.Source, ex.Message, ex);
            }

            return View(objSM);
        }

        public dynamic SaveOperator(IFormCollection objEntity)
        {
            try
            {
                var objBF = new OperatorBusinessFacade();
                bool isSuccess = objBF.Save(objEntity);

                if (isSuccess)
                    _jsonMessage = new JsonMessage(true, Resource.lbl_success, Resource.lbl_msg_dataSavedSuccessfully, KeyEnums.JsonMessageType.SUCCESS, objEntity);
                else
                    _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_dataNotSavedSuccessfully, KeyEnums.JsonMessageType.FAILURE);
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "SaveOperator(" + Json(objEntity) + ")", ex.Source, ex.Message);
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_msg_dataNotSavedSuccessfully, KeyEnums.JsonMessageType.FAILURE, ex.Message);
            }

            return _jsonMessage;
        }
        public List<Operator> GetList(string query, string sortColumn, string sortOrder, ref int page, ref int size, string flag, string startDate = "", string toDate = "", Int64 _userId = 0, bool isLoad = true, string ListType = "", Int64 companyID = 0, Int64 locationId = 0)
        {
            List<Operator> _list = new List<Operator>();

            try
            {
                _list = new OperatorBusinessFacade().GetListRecords();

                flag = !string.IsNullOrEmpty(flag) ? flag : "";

                if (_list != null)
                {
                    if (!string.IsNullOrEmpty(query))
                    {
                        query = query.Trim().ToLower();
                        _list = _list.Where(a => a.OperatorName.ToLower().Trim().Contains(query.Trim())
                                                      || a.CreatedDate.ToString().ToLower().Trim().Contains(query.Trim())
                                                    ).ToList();

                        if (flag.ToLower() == "search")
                        {
                            page = 1;
                        }
                    }

                    if (flag.ToLower() == "size")
                        page = 1;

                    if (!string.IsNullOrEmpty(sortColumn) && !string.IsNullOrEmpty(sortOrder))
                    {
                        if (flag.ToLower() == "sort")
                            sortOrder = sortOrder.ToLower().Trim() == "asc" ? "desc" : "asc";

                        switch (sortColumn.ToLower().Trim())
                        {
                            case "srno":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.RowNumber).ToList();
                                else
                                    _list = _list.OrderBy(p => p.RowNumber).ToList();
                                break;

                            case "cademicYearName":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.OperatorName).ToList();
                                else
                                    _list = _list.OrderBy(p => p.OperatorName).ToList();
                                break;

                            case "date":
                                if (sortOrder.ToLower() == "desc")
                                    _list = _list.OrderByDescending(p => p.CreatedDate).ToList();
                                else
                                    _list = _list.OrderBy(p => p.CreatedDate).ToList();
                                break;

                            default:
                                break;
                        }
                    }

                    ViewBag.SortColumn = sortColumn == null ? "" : sortColumn.ToLower();
                    ViewBag.SortOrder = sortOrder == null ? "" : sortOrder.ToLower();
                    ViewBag.Page = page;
                    ViewBag.Size = size;
                }
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetList(query=" + query + "sortColumn=" + sortColumn + "," + "sortOrder=" + sortOrder + "," + "page=" + page + "," + "size=" + size + ", flag=" + flag + ")", ex.Source, ex.Message, ex);
            }

            if (_list == null)
                return new List<Operator>();
            else
                return _list;
        }

        public ActionResult Search(string query, string sortColumn, string sortOrder, int page, int size, string flag, bool ISLOAD = false, string ListType = "", Int64 CompanyID = 0, Int64 LocationID = 0, string startDate = "", string toDate = "")
        {
            if (isValidUser)
            {
                try
                {
                    ViewBag.RequestList = ListType;
                    if (ListType == KeyEnums.ListType.AllViews.ToString())
                    {
                        if (query != "")
                            _list = GetList(query, sortColumn, sortOrder, ref page, ref size, flag, startDate, toDate, _userId, ISLOAD, ListType, CompanyID, LocationID);
                        else
                        {
                            ViewBag.SortColumn = "";
                            ViewBag.SortOrder = "desc";
                            ViewBag.Page = 1;
                            ViewBag.Size = 10;
                        }
                    }
                    else
                        _list = GetList(query, sortColumn, sortOrder, ref page, ref size, flag, startDate, toDate, _userId, ISLOAD, ListType, CompanyID, LocationID);
                }
                catch (Exception ex)
                {
                    Log.WriteLog(_module, "Search(query=" + query + ", sortColumn=" + sortColumn + ", sortOrder=" + sortOrder + ", page=" + page + ", size=" + size + ", flag=" + flag + ", ISLOAD=" + ISLOAD + ",ListType:" + ListType + ")", ex.Source, ex.Message, ex);
                }
            }
            return PartialView("_ListPartial", _list.ToPagedList(page, size));
        }

        public async Task<JsonResult> ChangeStatus(Int64 ID, string StatusID)
        {
            try
            {
                if (ID > 0)
                {
                    OperatorBusinessFacade objBF = new OperatorBusinessFacade();
                    _jsonMessage = objBF.ChangeStatus(ID, StatusID);
                }
            }
            catch (Exception ex)
            {
                _jsonMessage = new JsonMessage(false, Resource.lbl_error, Resource.lbl_internalServerErrorOccurred, KeyEnums.JsonMessageType.DANGER);
                Log.WriteLog(_module, "ChangeStatus(ID=" + ID + ",StatusID=" + StatusID + ")", ex.Source, ex.Message, ex);
            }
            return Json(_jsonMessage);
        }
    }
}
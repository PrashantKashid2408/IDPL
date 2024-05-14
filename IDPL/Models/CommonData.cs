using Core.Utility.Common;
using Microsoft.AspNetCore.Mvc.Rendering;

//using SelectPdf;

namespace IDPL.Models
{
    public class CommonData
    {
        private readonly string _module = "IDPL.Models.CommonData";
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CommonData(IHttpContextAccessor httpContextAccessor = null)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public List<SelectListItem> GetPageSizes()
        {
            List<SelectListItem> pageSizes = new List<SelectListItem>();
            try
            {
                pageSizes = new List<SelectListItem>
                {
                    //new SelectListItem { Text = "5", Value = "5"} ,
                    new SelectListItem { Text = "10", Value = "10"} ,
                    new SelectListItem { Text = "25", Value = "25"} ,
                    new SelectListItem { Text = "50", Value = "50" },
                    new SelectListItem { Text = "100", Value = "100" }
                };
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetPageSizes()", ex.Source, ex.Message, ex);
            }
            return pageSizes;
        }

        public List<SelectListItem> GetOtherRelationships()
        {
            List<SelectListItem> relationships = new List<SelectListItem>();
            try
            {
                relationships = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Select Relationship", Value = "0"} ,
                    new SelectListItem { Text = "pickup", Value = "Pickup" },
                    new SelectListItem { Text = "emergency", Value = "Emergency" }
                };
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRelationships()", ex.Source, ex.Message, ex);
            }
            return relationships;
        }

        public List<SelectListItem> GetRelationships()
        {
            List<SelectListItem> relationships = new List<SelectListItem>();
            try
            {
                relationships = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Mother", Value = "mother"},
                };
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetRelationships()", ex.Source, ex.Message, ex);
            }
            return relationships;
        }

        public List<SelectListItem> GetFather()
        {
            List<SelectListItem> relationships = new List<SelectListItem>();
            try
            {
                relationships = new List<SelectListItem>
                {
                    new SelectListItem { Text = "Father", Value = "father"},
                };
            }
            catch (Exception ex)
            {
                Log.WriteLog(_module, "GetFather()", ex.Source, ex.Message, ex);
            }
            return relationships;
        }
    }
}
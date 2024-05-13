using Microsoft.AspNetCore.Mvc;

namespace IDPL.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

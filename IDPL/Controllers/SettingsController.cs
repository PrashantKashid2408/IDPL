using Microsoft.AspNetCore.Mvc;

namespace IDPL.Controllers
{
    public class SettingsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

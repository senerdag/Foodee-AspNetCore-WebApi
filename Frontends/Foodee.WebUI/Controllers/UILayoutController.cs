using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

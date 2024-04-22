using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebUI.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Route("Admin/AdminUILayout")]
	public class AdminUILayoutController : Controller
	{
        [Route("Index")]
        public IActionResult Index()
		{
			return View();
		}
	}
}

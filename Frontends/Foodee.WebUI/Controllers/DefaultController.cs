using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebUI.Controllers
{
	public class DefaultController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

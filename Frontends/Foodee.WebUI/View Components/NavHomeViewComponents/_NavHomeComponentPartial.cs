using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebUI.View_Components.NavHomeViewComponents
{
	public class _NavHomeComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

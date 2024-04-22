using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebUI.View_Components.UILayoutViewComponents
{
	public class _HeadUILayoutComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

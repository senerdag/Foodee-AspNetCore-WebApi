using Microsoft.AspNetCore.Mvc;

namespace Foodee.WebUI.View_Components.ContactViewComponents
{
	public class _ReservationComponentPartial:ViewComponent
	{
		public IViewComponentResult Invoke()
		{
			return View();
		}
	}
}

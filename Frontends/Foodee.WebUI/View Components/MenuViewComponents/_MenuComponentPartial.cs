using Foodee.Dto.AboutDtos;
using Foodee.Dto.FoodDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.MenuViewComponents
{
	public class _MenuComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _MenuComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Foods/GetCategoryWithFoodsList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetCategoryWithFoodsList>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

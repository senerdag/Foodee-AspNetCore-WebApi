using Foodee.Dto.AboutDtos;
using Foodee.Dto.FoodDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.FeaturedViewComponents
{
	public class _FeaturedComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _FeaturedComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Foods/GetLast6FoodList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<GetLast6FoodDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

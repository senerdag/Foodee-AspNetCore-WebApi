using Foodee.Dto.BannerDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.HomeViewComponents
{
	public class _HomeComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _HomeComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Banners");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultBannerDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

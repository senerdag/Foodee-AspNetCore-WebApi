using Foodee.Dto.AboutDtos;
using Foodee.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.AboutViewComponents
{
	public class _AboutComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _AboutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Abouts");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

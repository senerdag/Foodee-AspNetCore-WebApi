using Foodee.Dto.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.LastFourCategoryViewComponents
{
	public class _LastFourCategoryComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _LastFourCategoryComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client=_httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Categories/GetLastFourCategoryList");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata=await responseMessage.Content.ReadAsStringAsync();
				var values=JsonConvert.DeserializeObject<List<ResultLastFourCategory>>(jsondata);	
				return View(values);
			}
			return View();
		}
	}
}

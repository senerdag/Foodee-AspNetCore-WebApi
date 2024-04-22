using Foodee.Dto.ContactInfoDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.ContactViewComponents
{
	public class _ContactComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _ContactComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/ContactInfos");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultContactInfoDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

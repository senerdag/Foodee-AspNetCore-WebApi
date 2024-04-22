using Foodee.Dto.SocialMediaDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.UILayoutViewComponents
{
	public class _FooterUILayoutComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _FooterUILayoutComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/SocialMedias");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultSocialMediaDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

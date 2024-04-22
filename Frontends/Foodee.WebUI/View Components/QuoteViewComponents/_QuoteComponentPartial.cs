using Foodee.Dto.QuoteDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.QuoteViewComponents
{
	public class _QuoteComponentPartial:ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _QuoteComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}

		public async Task<IViewComponentResult> InvokeAsync()
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync("https://localhost:7122/api/Quotes");
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsondata = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<List<ResultQuoteDto>>(jsondata);
				return View(values);
			}
			return View();
		}
	}
}

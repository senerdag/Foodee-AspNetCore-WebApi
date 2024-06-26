﻿using Foodee.Dto.DescriptionDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.View_Components.DescriptionViewComponents
{
	public class _DescriptionComponentPartial : ViewComponent
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public _DescriptionComponentPartial(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public async Task<IViewComponentResult> InvokeAsync(int id)
		{
			var client = _httpClientFactory.CreateClient();
			var responseMessage = await client.GetAsync($"https://localhost:7122/api/Descriptions/" + id);
			if (responseMessage.IsSuccessStatusCode)
			{
				var jsonData = await responseMessage.Content.ReadAsStringAsync();
				var values = JsonConvert.DeserializeObject<ResultDescriptionByIdDto>(jsonData);
				return View(values);
			}
			return View();
		}
	}
}

using FluentValidation;
using FluentValidation.AspNetCore;
using Foodee.Domain.Entities;
using Foodee.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using NToastNotify;
using System.Net.Http;
using System.Text;

namespace Foodee.WebUI.Controllers
{
	public class ReservationController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toast;

		public ReservationController(IHttpClientFactory httpClientFactory, IToastNotification toast)
		{
			_httpClientFactory = httpClientFactory;
			_toast = toast;
		}

		[HttpPost]
		public async Task<IActionResult> SendReservation(CreateReservationDto createReservationDto)
		{
			
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(createReservationDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7122/api/Reservations", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
					_toast.AddSuccessToastMessage("We will send you an email when we confirm.");
                    return RedirectToAction("Index", "Default");
                }


			_toast.AddErrorToastMessage("Make sure you fill in everything properly.");
			return RedirectToAction("Index", "Default");
		}
	}
}

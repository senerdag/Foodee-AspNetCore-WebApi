using Foodee.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Foodee.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminReservation")]
    public class AdminReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7122/api/Reservations");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultReservationDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [Route("DeleteReservation/{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7122/api/Reservations?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminReservation", new { area = "Admin" });
            }
            return View();
        }
    }
}

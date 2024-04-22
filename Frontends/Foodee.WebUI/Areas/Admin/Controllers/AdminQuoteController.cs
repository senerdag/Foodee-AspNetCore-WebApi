using Foodee.Dto.QuoteDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Foodee.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminQuote")]
    public class AdminQuoteController : Controller
    {
       
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminQuoteController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
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
        [HttpGet]
        [Route("CreateQuote")]
        public IActionResult CreateQuote()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateQuote")]
        public async Task<IActionResult> CreateQuote(CreateQuoteDto createQuoteDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(createQuoteDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7122/api/Quotes", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminQuote", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteQuote/{id}")]
        public async Task<IActionResult> DeleteQuote(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7122/api/Quotes?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminQuote", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateQuote/{id}")]
        public async Task<IActionResult> UpdateQuote(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7122/api/Quotes/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateQuoteDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateQuote/{id}")]
        public async Task<IActionResult> UpdateQuote(UpdateQuoteDto updateQuoteDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateQuoteDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7122/api/Quotes/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminQuote", new { area = "Admin" });
            }
            return View();
        }
    }
}

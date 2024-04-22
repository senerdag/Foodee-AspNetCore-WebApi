using Foodee.Dto.CategoryDtos;
using Foodee.Dto.FoodDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using NToastNotify;
using System.Text;

namespace Foodee.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminFood")]
    public class AdminFoodController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IToastNotification _toast;

        public AdminFoodController(IHttpClientFactory httpClientFactory, IToastNotification toast)
        {
            _httpClientFactory = httpClientFactory;
            _toast = toast;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7122/api/Foods/GetCategoryWithFoodsList");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<GetCategoryWithFoodsList>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateFood")]
        public async Task<IActionResult> CreateFood()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7122/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> categoryValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.Name,
                                                    Value = x.CategoryId.ToString()
                                                }).ToList();
            ViewBag.CategoryValues = categoryValues;
            return View();
        }
        [HttpPost]
        [Route("CreateFood")]
        public async Task<IActionResult> CreateFood(CreateFoodDto createFoodDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonDate = JsonConvert.SerializeObject(createFoodDto);
            StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7122/api/Foods", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFood", new { area = "Admin" });
            }
            else 
            {
                if(createFoodDto.Name==null)
                {
                    createFoodDto.Name = "Undefined";
                }
                _toast.AddErrorToastMessage($"{createFoodDto.Name} is not added");
                return RedirectToAction("Index", "AdminFood", new { area = "Admin" });
            }
        }

        [Route("DeleteFood/{id}")]
        public async Task<IActionResult> DeleteFood(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7122/api/Foods?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFood", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateFood/{id}")]
        public async Task<IActionResult> UpdateFood(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7122/api/Foods/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFoodDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateFood/{id}")]
        public async Task<IActionResult> UpdateFood(UpdateFoodDto updateFoodDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateFoodDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7122/api/Foods/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminFood", new { area = "Admin" });
            }
            return View();
        }
    }
}

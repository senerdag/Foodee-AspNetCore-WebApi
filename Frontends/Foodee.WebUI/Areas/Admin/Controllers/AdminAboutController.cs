using FluentValidation;
using FluentValidation.AspNetCore;
using Foodee.Domain.Entities;
using Foodee.Dto.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace Foodee.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminAbout")]
    public class AdminAboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<About> _validator;
        public AdminAboutController(IHttpClientFactory httpClientFactory, IValidator<About> validator)
        {
            _httpClientFactory = httpClientFactory;
            _validator = validator;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
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
        [HttpGet]
        [Route("CreateAbout")]
        public IActionResult CreateAbout()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateAbout")]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            var result = await _validator.ValidateAsync(new About
            {
                Description = createAboutDto.Description,
                Title = createAboutDto.Title,
                CoverImageUrl = createAboutDto.CoverImageUrl
            });

            if(!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var jsonDate = JsonConvert.SerializeObject(createAboutDto);
                StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7122/api/Abouts", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
                }
            }
            
            return View();
        }

        [Route("DeleteAbout/{id}")]
        public async Task<IActionResult> DeleteAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7122/api/Abouts?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7122/api/Abouts/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                return View(values);
            }
            return View();
        }
        
        [HttpPost]
        [Route("UpdateAbout/{id}")]
        public async Task<IActionResult> UpdateAbout(UpdateAboutDto updateAboutDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateAboutDto);
            StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync("https://localhost:7122/api/Abouts/", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminAbout", new { area = "Admin" });
            }
            return View();
        }
    }
}

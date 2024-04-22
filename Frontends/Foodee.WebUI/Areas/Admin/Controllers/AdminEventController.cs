using FluentValidation;
using FluentValidation.AspNetCore;
using FluentValidation.Results;
using Foodee.Application.Validator;
using Foodee.Domain.Entities;
using Foodee.Dto.EventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Text;

namespace Foodee.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminEvent")]
    public class AdminEventController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;
        private readonly IValidator<Event> _validator;

        public AdminEventController(IHttpClientFactory httpClientFactory,IValidator<Event> validator)
        {
            _httpClientFactory = httpClientFactory;
            _validator = validator;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7122/api/Events");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsondata = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventDto>>(jsondata);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateEvent")]
        public IActionResult CreateEvent()
        {
            return View();
        }
        [HttpPost]
        [Route("CreateEvent")]
        public async Task<IActionResult> CreateEvent(CreateEventDto createEventDto)
        {

            var result = await _validator.ValidateAsync(new Event
            {
                EventDate = createEventDto.EventDate,
                Description = createEventDto.Description,
                Title = createEventDto.Title
            });

            if(!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var jsonDate = JsonConvert.SerializeObject(createEventDto);
                StringContent stringContent = new StringContent(jsonDate, Encoding.UTF8, "application/json");
                var responseMessage = await client.PostAsync("https://localhost:7122/api/Events", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
                }
                
            }
            return View();

        }

        [Route("DeleteEvent/{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync($"https://localhost:7122/api/Events?id=" + id);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7122/api/Events/{id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateEventDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [HttpPost]
        [Route("UpdateEvent/{id}")]
        public async Task<IActionResult> UpdateEvent(UpdateEventDto updateEventDto)
        {
            var result = await _validator.ValidateAsync(new Event
            {
                EventDate = updateEventDto.EventDate,
                Description = updateEventDto.Description,
                Title = updateEventDto.Title
            });
            if (!result.IsValid)
            {
                result.AddToModelState(this.ModelState);
            }
            else
            {
                var client = _httpClientFactory.CreateClient();
                var jsonData = JsonConvert.SerializeObject(updateEventDto);
                StringContent stringContent = new StringContent(jsonData, Encoding.UTF8, "application/json");
                var responseMessage = await client.PutAsync("https://localhost:7122/api/Events/", stringContent);
                if (responseMessage.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index", "AdminEvent", new { area = "Admin" });
                }
            }

            
            return View();
        }
    }
}

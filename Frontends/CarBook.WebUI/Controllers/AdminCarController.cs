using CarBook_1.Dto.BrandDtos;
using CarBook_1.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Text;

namespace CarBook_1.WebUI.Controllers
{
    public class AdminCarController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AdminCarController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
            var client = _httpClientFactory.CreateClient();
            var apiConnectedUrl = "https://localhost:7174/api/Cars/GetCarWithBrand";
            var responseMesage = await client.GetAsync(apiConnectedUrl);
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarWithBrandsDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> CreateCar()
        {
            var client = _httpClientFactory.CreateClient();
            var apiConnectedUrl = "https://localhost:7174/api/Brands";
            var responseMesage = await client.GetAsync(apiConnectedUrl);
            var jsonData = await responseMesage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData);
            List<SelectListItem> brandValues = (from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.name,
                                                    Value = x.brandId.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateCar(CreateCarDto createCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesage = await client.PostAsync("https://localhost:7174/api/Cars/", content);
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public async Task<IActionResult> RemoveCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.DeleteAsync($"https://localhost:7174/api/Cars/{id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> UpdateCar(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var apiConnectedUrl = "https://localhost:7174/api/Brands";
            var responseMesage1 = await client.GetAsync(apiConnectedUrl);
            var jsonData1 = await responseMesage1.Content.ReadAsStringAsync();
            var values1 = JsonConvert.DeserializeObject<List<ResultBrandDto>>(jsonData1);
            List<SelectListItem> brandValues = (from x in values1
                                                select new SelectListItem
                                                {
                                                    Text = x.name,
                                                    Value = x.brandId.ToString()
                                                }).ToList();
            ViewBag.BrandValues = brandValues;



            var responseMesage2 = await client.GetAsync($"https://localhost:7174/api/Cars/{id}");
            if (responseMesage2.IsSuccessStatusCode)
            {
                var jsonData2 = await responseMesage2.Content.ReadAsStringAsync();
                var values2 = JsonConvert.DeserializeObject<UpdateCarDto>(jsonData2);
                return View(values2);
            }
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> UpdateCar(UpdateCarDto updateCarDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateCarDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesage = await client.PutAsync("https://localhost:7174/api/Cars/", content);
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View();
        }

        
    }
}

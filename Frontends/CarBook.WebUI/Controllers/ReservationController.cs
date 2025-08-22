using CarBook_1.Dto.LocationDtos;
using CarBook_1.Dto.ReservationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using System.Text;

namespace CarBook_1.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index(int id)
        {
            ViewBag.carId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync("https://localhost:7174/api/Locations");

            var jsonData = await responseMesage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultLocationDto>>(jsonData);
            List<SelectListItem> values2 = (from x in values
                                            select new SelectListItem
                                            {
                                                Text = x.name,
                                                Value = x.locationId.ToString(),
                                            }).ToList();

            ViewBag.selectedItemReservationLocation = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateReservationDto createReservationDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(createReservationDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMesage = await client.PostAsync("https://localhost:7174/api/Reservations", content);
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Default");
            }
            return View();
        }
    }
}

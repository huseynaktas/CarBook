using CarBook_1.Dto.LocationDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.Controllers
{
    public class ReservationController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ReservationController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index()
        {
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
    }
}

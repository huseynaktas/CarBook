using CarBook_1.Dto.RentACarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;

namespace CarBook_1.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public RentACarListController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> Index(int id)
        {
            var book_pick_date = TempData["book_pick_date"];
            var book_off_date = TempData["book_off_date"];
            var time_pick = TempData["time_pick"];
            var time_off = TempData["time_off"];
            var locationId = TempData["locationId"];

            //filterRentACarDto.locationId = int.Parse(locationId.ToString());
            //filterRentACarDto.available = true;

            id = int.Parse(locationId.ToString());

            ViewBag.book_pick_date = book_pick_date;
            ViewBag.book_off_date = book_off_date;
            ViewBag.time_pick = time_pick;
            ViewBag.time_off = time_off;
            ViewBag.locationId = locationId;


            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync($"https://localhost:7174/api/RentACars?locationId={id}&available=true");
            if(responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<FilterRentACarDto>>(jsonData);
                return View(values);
            }

            return View();
        }
    }
}

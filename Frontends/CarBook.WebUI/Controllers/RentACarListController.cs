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
            var locationId = TempData["locationId"];

            //filterRentACarDto.locationId = int.Parse(locationId.ToString());
            //filterRentACarDto.available = true;

            id = int.Parse(locationId.ToString());

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

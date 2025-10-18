using CarBook_1.Dto.CarDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.ViewComponents.CarDetailViewComponents
{
    public class _CarDetailMainCarFeatureComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CarDetailMainCarFeatureComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.carId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync($"https://localhost:7174/api/Cars/{id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultCarWithBrandsDto>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

using CarBook_1.Dto.CarPricingDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.ViewComponents.DashboardComponent
{
    public class _AdminDashboardCarPricingListComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardCarPricingListComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync("https://localhost:7174/api/CarPricings/GetCarPricingWithTimePeriodList");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCarPricingListWithModelDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }
}

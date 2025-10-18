using CarBook_1.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.ViewComponents.DashboardComponent
{
    public class _AdminDashboardStatisticsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _AdminDashboardStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            Random random = new Random();
            var client = _httpClientFactory.CreateClient();

            #region //Car Count
            var responseMesage = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCount");
            if (responseMesage.IsSuccessStatusCode)
            {
                int random1 = random.Next(0, 101);
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.carCount;
                ViewBag.randomCarCount = random1;
            }
            #endregion

            #region //Location Count
            var responseMesage2 = await client.GetAsync("https://localhost:7174/api/Statistics/GetLocationCount");
            if (responseMesage2.IsSuccessStatusCode)
            {
                int randomLocationCount = random.Next(0, 101);
                var jsonData = await responseMesage2.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.locationCount = values.locationCount;
                ViewBag.randomLocationCount = randomLocationCount;
            }
            #endregion

            #region //Brand Count
            var responseMesage5 = await client.GetAsync("https://localhost:7174/api/Statistics/GetBrandCount");
            if (responseMesage5.IsSuccessStatusCode)
            {
                int randomBrandCount = random.Next(0, 101);
                var jsonData = await responseMesage5.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.brandCount = values.brandCount;
                ViewBag.randomBrandCount = randomBrandCount;
            }
            #endregion 

            #region //Avg Rent Price For Daily
            var responseMesage6 = await client.GetAsync("https://localhost:7174/api/Statistics/GetAvgRentPriceForDaily");
            if (responseMesage6.IsSuccessStatusCode)
            {
                int randomAvgPriceForDaily = random.Next(0, 101);
                var jsonData = await responseMesage6.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.avgPriceForDaily = values.avgPriceForDaily.ToString("0.00");
                ViewBag.randomAvgPriceForDaily = randomAvgPriceForDaily;
            }
            #endregion 


            return View();
        }
    }
}

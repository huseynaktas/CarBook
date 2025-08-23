using CarBook_1.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;

namespace CarBook_1.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultStatisticsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            #region //Car Count
            var responseMesageCarCount = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCount");
            if (responseMesageCarCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMesageCarCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCount = values.carCount;
            }
            #endregion

            #region //Location Count
            var responseMesageLocationCount = await client.GetAsync("https://localhost:7174/api/Statistics/GetLocationCount");
            if (responseMesageLocationCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMesageLocationCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.locationCount = values.locationCount;
            }
            #endregion 

            #region //Brand Count
            var responseMesageBrandCount = await client.GetAsync("https://localhost:7174/api/Statistics/GetBrandCount");
            if (responseMesageBrandCount.IsSuccessStatusCode)
            {
                var jsonData = await responseMesageBrandCount.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.brandCount = values.brandCount;
            }
            #endregion 

            #region //Car Count By Fuel Electric
            var responseMesageCarCountByFuelElectric = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCountByFuelElectric");
            if (responseMesageCarCountByFuelElectric.IsSuccessStatusCode)
            {
                var jsonData = await responseMesageCarCountByFuelElectric.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectric;
            }
            #endregion

            return View();
        }
    }
}

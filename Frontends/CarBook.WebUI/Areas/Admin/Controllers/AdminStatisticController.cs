using CarBook_1.Dto.StatisticDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace CarBook_1.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/AdminStatistic")]
    public class AdminStatisticController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AdminStatisticController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
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

            #region //Author Count
            var responseMesage3 = await client.GetAsync("https://localhost:7174/api/Statistics/GetAuthorCount");
            if (responseMesage3.IsSuccessStatusCode)
            {
                int randomAuthorCount = random.Next(0, 101);
                var jsonData = await responseMesage3.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.authorCount = values.authorCount;
                ViewBag.randomAuthorCount = randomAuthorCount;
            }
            #endregion 

            #region //Blog Count
            var responseMesage4 = await client.GetAsync("https://localhost:7174/api/Statistics/GetBlogCount");
            if (responseMesage4.IsSuccessStatusCode)
            {
                int randomBlogCount = random.Next(0, 101);
                var jsonData = await responseMesage4.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.blogCount = values.blogCount;
                ViewBag.randomBlogCount = randomBlogCount;
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

            #region //Avg Rent Price For Weekly
            var responseMesage7 = await client.GetAsync("https://localhost:7174/api/Statistics/GetAvgRentPriceForWeekly");
            if (responseMesage7.IsSuccessStatusCode)
            {
                int randomAvgRentPriceForWeekly = random.Next(0, 101);
                var jsonData = await responseMesage7.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.avgRentPriceForWeekly = values.avgRentPriceForWeekly.ToString("0.00");
                ViewBag.randomAvgRentPriceForWeekly = randomAvgRentPriceForWeekly;
            }
            #endregion 

            #region //Avg Rent Price For Hoursly
            var responseMesage8 = await client.GetAsync("https://localhost:7174/api/Statistics/GetAvgRentPriceForMonthly");
            if (responseMesage8.IsSuccessStatusCode)
            {
                int randomAvgRentPriceForHoursly = random.Next(0, 101);
                var jsonData = await responseMesage8.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.avgRentPriceForHoursly = values.avgRentPriceForMonthly.ToString("0.00");
                ViewBag.randomAvgRentPriceForHoursly = randomAvgRentPriceForHoursly;
            }
            #endregion 

            #region //Car Count By Transmission Is Auto
            var responseMesage9 = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCountByTransmissionIsAuto");
            if (responseMesage9.IsSuccessStatusCode)
            {
                int randomCarCountByTransmissionIsAuto = random.Next(0, 101);
                var jsonData = await responseMesage9.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCountByTransmissionIsAuto = values.carCountByTransmissionIsAuto;
                ViewBag.randomCarCountByTransmissionIsAuto = randomCarCountByTransmissionIsAuto;
            }
            #endregion

            #region //Car Count By Km Smaller Than 1000
            var responseMesage10 = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCountByKmSmallerThan1000");
            if (responseMesage10.IsSuccessStatusCode)
            {
                int randomCarCountByKmSmallerThan1000 = random.Next(0, 101);
                var jsonData = await responseMesage10.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCountByKmSmallerThan1000 = values.carCountByKmSmallerThan1000;
                ViewBag.randomCarCountByKmSmallerThan1000 = randomCarCountByKmSmallerThan1000;
            }
            #endregion

            #region //Car Count By Fuel Gasoline Or Diesel
            var responseMesage11 = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCountByFuelGasolineOrDiesel");
            if (responseMesage11.IsSuccessStatusCode)
            {
                int randomCarCountByFuelGasolineOrDiesel = random.Next(0, 101);
                var jsonData = await responseMesage11.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCountByFuelGasolineOrDiesel = values.carCountByFuelGasolineOrDiesel;
                ViewBag.randomCarCountByFuelGasolineOrDiesel = randomCarCountByFuelGasolineOrDiesel;
            }
            #endregion

            #region //Car Count By Fuel Electric
            var responseMesage12 = await client.GetAsync("https://localhost:7174/api/Statistics/GetCarCountByFuelElectric");
            if (responseMesage12.IsSuccessStatusCode)
            {
                int randomCarCountByFuelElectric = random.Next(0, 101);
                var jsonData = await responseMesage12.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<ResultStatisticsDto>(jsonData);
                ViewBag.carCountByFuelElectric = values.carCountByFuelElectric;
                ViewBag.randomCarCountByFuelElectric = randomCarCountByFuelElectric;
            }
            #endregion

            return View();
        }
    }
}

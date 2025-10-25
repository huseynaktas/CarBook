using CarBook_1.Dto.LoginDtos;
using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.Controllers
{
    public class LoginController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Index(ResultLoginDto resultLoginDto)
        {
            var client = _httpClientFactory.CreateClient();
            return View();
        }
    }
}

using CarBook_1.Dto.ServiceDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.Controllers
{
    public class ServiceController : Controller
    {

        public IActionResult Index()
        {
            return View();
        }
    }
}

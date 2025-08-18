using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.Controllers
{
    public class RentACarListController : Controller
    {
        public IActionResult Index()
        {
            var data = TempData["value"];
            ViewBag.v = data;
            return View();
        }
    }
}

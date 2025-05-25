using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

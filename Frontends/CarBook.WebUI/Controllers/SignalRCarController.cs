using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.Controllers
{
    public class SignalRCarController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

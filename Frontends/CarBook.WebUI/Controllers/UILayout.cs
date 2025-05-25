using Microsoft.AspNetCore.Mvc;

namespace CarBook.WebUI.Controllers
{
    public class UILayout : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

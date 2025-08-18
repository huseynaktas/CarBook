using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.ViewComponents.RentACarFilterComponent
{
    public class _RentACarFilterComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke(string v)
        {
            v = "aaaa";
            TempData["value"] = v;
            return View();
        }
    }
}

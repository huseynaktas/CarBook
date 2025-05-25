using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.ViewComponents.AboutViewComponents
{
    public class _BecomeADriverComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

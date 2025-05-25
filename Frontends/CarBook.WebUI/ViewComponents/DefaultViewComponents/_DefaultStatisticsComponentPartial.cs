using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.ViewComponents.DefaultViewComponents
{
    public class _DefaultStatisticsComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

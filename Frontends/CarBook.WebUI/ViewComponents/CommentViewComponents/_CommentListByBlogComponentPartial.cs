using Microsoft.AspNetCore.Mvc;

namespace CarBook_1.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}

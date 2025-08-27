using CarBook_1.Dto.BlogDtos;
using CarBook_1.Dto.CommentDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CarBook_1.WebUI.ViewComponents.CommentViewComponents
{
    public class _CommentListByBlogComponentPartial: ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _CommentListByBlogComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync(int id)
        {
            ViewBag.blogId = id;
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.GetAsync($"https://localhost:7174/api/Comments/CommentListByBlog?id=" + id);
            if(responseMesage.IsSuccessStatusCode)
            {
                var jsonData = await responseMesage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);

                var responseMesage2 = await client.GetAsync($"https://localhost:7174/api/Comments/CommentCountByBlog?id=" + id);
                var jsonData2 = await responseMesage2.Content.ReadAsStringAsync();
                ViewBag.countComment = jsonData2;

                return View(values);
            }
            
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class RecentBlogViewComponent : ViewComponent
    {
        private readonly IPostServices _postServices;
        public RecentBlogViewComponent(IPostServices postServices)
        {
            _postServices = postServices;
        }
        public IViewComponentResult Invoke()
        {
            var model = _postServices.ListBlog().TakeLast(3).ToList();
            return View(model);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Components
{
    public class RelatedBlogViewComponent : ViewComponent
    {
        private readonly IPostServices _postServices;
        public RelatedBlogViewComponent(IPostServices postServices)
        {
            _postServices = postServices;
        }
        public IViewComponentResult Invoke(int id)
        {
            var model = _postServices.RelatedBlog(id).ToList();
            return View(model);
        }
    }
}

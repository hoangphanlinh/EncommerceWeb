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
        public IViewComponentResult Invoke(int CategoryId)
        {
            var model = _postServices.RelatedBlog(CategoryId).ToList();
            return View(model);
        }
    }
}

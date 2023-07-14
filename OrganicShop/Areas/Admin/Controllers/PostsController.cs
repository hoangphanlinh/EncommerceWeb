using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IPostServices _postServices;
        public PostsController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 2;
            var lsposts = _postServices.GetAllPost();
            PagedList<Posts> models = new PagedList<Posts>(lsposts, pageNumber, pageSize);
            ViewBag.CategoryList = new SelectList(_postServices.GetCategories(), "CatID", "CatName");
            ViewBag.PublishedList = _postServices.GetPublished();
            return View(models);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;
using System.Text.Json;
namespace OrganicShop.Controllers
{
    public class BlogController : Controller
    {
        private readonly IPostServices _postServices;
        public BlogController(IPostServices postServices)
        {
            _postServices = postServices;
        }

        public IActionResult Index(int? page, string searchString, int categoryId)
        {
            ViewBag.searchString = searchString;
            ViewBag.categoryId = categoryId;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 4;
            var lsPosts = _postServices.GetAllPost();
            if (!String.IsNullOrEmpty(searchString) || categoryId != 0)
            {
                lsPosts = _postServices.SearchPosts(searchString,categoryId);
            }
            PagedList<Posts> models = new PagedList<Posts>(lsPosts, pageNumber, pageSize);
            return View(models);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var result = _postServices.GetPostById(id);
            return View(result);
        }
        [HttpGet]
        public IActionResult RelatedBlog(int id)
        {
            var model = _postServices.RelatedBlog(id).Take(3).ToList();
            return View(model);
        }
    }
}

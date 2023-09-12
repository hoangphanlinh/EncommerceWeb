using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using System.Diagnostics;
using X.PagedList;

namespace OrganicShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IProductServices _productservices;

        public HomeController(ILogger<HomeController> logger, IProductServices productServices)
        {
            _logger = logger;
            _productservices = productServices;
        }
        public IActionResult Index(string searchCategory)
        {
            ViewBag.SearchCategory = searchCategory;
            var result = _productservices.SearchProductCatName(searchCategory).ToList();
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }
     
        public IActionResult Blog()
        {
            return View();
        }
        public IActionResult Contact()
        {
            return View();
        }
    }
}
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;
namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductServices _productservices;
        public ProductsController(IProductServices productservices)
        {
            _productservices = productservices;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 2;
            var lsproducts = _productservices.GetAllProduct();
            PagedList<Products> models = new PagedList<Products>(lsproducts, pageNumber, pageSize);
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
            ViewBag.StatusList = _productservices.GetStatus();
            return View(models);
        }
    }
}

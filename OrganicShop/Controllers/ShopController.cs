using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Controllers
{
    public class ShopController : Controller
    {
        private readonly IProductServices _productservices;
        public ShopController(IProductServices productservices)
        {
            _productservices = productservices;
        }
        public IActionResult Index(int? page, string searchString, int categoryId)
        {
            ViewBag.searchString = searchString;
            ViewBag.categoryId = categoryId;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 9;
            var lsproducts = _productservices.GetAllProduct();
            if (!String.IsNullOrEmpty(searchString) || categoryId != 0)
            {
                lsproducts = _productservices.SearchProduct(searchString, categoryId);
            }
            PagedList<Products> models = new PagedList<Products>(lsproducts, pageNumber, pageSize);
            return View(models);
        }
        public IActionResult Discount_Product_List(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 9;
            var lsproducts = _productservices.ProductDiscount();
           
            PagedList<Products> models = new PagedList<Products>(lsproducts, pageNumber, pageSize);
            return View(models);
        }
        public IActionResult BestSale_Product_List(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 9;
            var lsproducts = _productservices.ProductBestSale();

            PagedList<Products> models = new PagedList<Products>(lsproducts, pageNumber, pageSize);
            return View(models);
        }
    }
}

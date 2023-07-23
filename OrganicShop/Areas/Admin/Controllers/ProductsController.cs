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
        public IActionResult Index(int? page,string searchString,int categoryId)
        {
            ViewBag.searchString = searchString;
            ViewBag.categoryId = categoryId;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lsproducts = _productservices.GetAllProduct();
            if(!String.IsNullOrEmpty(searchString) || categoryId !=0)
            {
                lsproducts = _productservices.SearchProduct(searchString,categoryId);
            }
           
            PagedList<Products> models = new PagedList<Products>(lsproducts,pageNumber, pageSize);
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
            return View(models);
        }
        public IActionResult Create()
        {
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
            ViewBag.BestSellersList = _productservices.GetBestSeller();
            ViewBag.StatusList = _productservices.GetStatus();
            return View();
        }
        [HttpPost]
        public IActionResult Create(
            [Bind("ProductID,ProductName, ShortDesc,Description,CatID,Price,Discount,Thumb,Video,CreatedDate,ModifiedDate,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock")]Products products)
        {

            if (ModelState.IsValid)
            {
                _productservices.CreateProduct(products);
                return RedirectToAction("Index");
            }
            return View(products);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var product = _productservices.GetProductById(id);
            return View(product);
        }

        public IActionResult Edit(int id)
        {
            var _product = _productservices.GetProductById(id);
            if (_product == null)
            {
                return NotFound();
            }
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
            ViewBag.BestSellersList = _productservices.GetBestSeller();
            ViewBag.StatusList = _productservices.GetActive();
            return View(_product);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("ProductID,ProductName, ShortDesc,Description,CatID,Price,Discount,Thumb,Video,CreatedDate,ModifiedDate,BestSellers,HomeFlag,Active,Tags,Title,Alias,MetaDesc,MetaKey,UnitslnStock")] Products products) 
        {
           if(id != products.ProductID)
            {
                return NotFound();
            }
           if(ModelState.IsValid)
            {
                _productservices.UpdateProduct(id, products);
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
          
            return View(products);
        }

        public IActionResult searchListProduct(int? page,string searchName, int categoryId, string status)
        {
            ViewBag.searchString = searchName;
            ViewBag.categoryId = categoryId;
            ViewBag.status = status;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lsproducts = _productservices.GetAllProduct();
            if (!String.IsNullOrEmpty(searchName) || categoryId != 0 || !String.IsNullOrEmpty(status) || (categoryId != 0 && !String.IsNullOrEmpty(status)))
            {
                lsproducts = _productservices.SearchListProduct(searchName, categoryId, status);
            }

            PagedList<Products> models = new PagedList<Products>(lsproducts, pageNumber, pageSize);
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
            ViewBag.StatusList = _productservices.GetStatus();
            return View(models);
        }
    }
}

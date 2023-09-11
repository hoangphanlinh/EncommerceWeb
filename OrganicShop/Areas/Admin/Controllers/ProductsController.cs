using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.DotNet.Scaffolding.Shared.Messaging;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Data.ViewModels;
using OrganicShop.Helpper;
using OrganicShop.Models;
using System.Drawing.Printing;
using X.PagedList;
namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {
        private readonly IProductServices _productservices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IProductServices productservices, IWebHostEnvironment webHostEnvironment)
        {
            _productservices = productservices;
            _webHostEnvironment = webHostEnvironment;
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
            ViewBag.StatusList = _productservices.GetActive();
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(ProductViewModel model)
        {

            if (ModelState.IsValid)
            {
                string uniuefilename = string.Empty;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                uniuefilename = fileName;
                            }
                            
                        }
                    }
                }
                var product = new Products()
                {
                    ProductID = model.ProductID,
                    ProductName = model.ProductName,
                    ShortDesc = model.ShortDesc,
                    Description = model.Description,
                    CatID = model.CatID,
                    Price = model.Price,
                    Discount = model.Discount,
                    Thumb = uniuefilename,
                    Video = model.Video,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    BestSellers = model.BestSellers,
                    HomeFlag = model.HomeFlag,
                    Active = model.Active,
                    Tags = model.Tags,
                    Title = model.Title,
                    Alias = Utilities.SEOUrl(model.ProductName),
                    MetaDesc    = model.MetaDesc,
                    MetaKey = model.MetaKey,
                    UnitslnStock = model.UnitslnStock
                };
                _productservices.CreateProduct(product);
                return RedirectToAction("Index");
            }
            return View(model);
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
        public async Task<IActionResult> Edit(Products products) 
        {
           
            if (ModelState.IsValid)
            {
                Products model = _productservices.GetProductById(products.ProductID);
                string uniuefilename = model.Thumb;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/products");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                uniuefilename = fileName;
                            }

                        }
                    }
                }
                model.ProductID = products.ProductID;
                model.ProductName = products.ProductName;
                model.ShortDesc = products.ShortDesc;
                model.Description = products.Description;
                model.CatID = products.CatID;
                model.Price = products.Price;
                model.Discount = products.Discount;
                model.Thumb = uniuefilename;
                model.Video = products.Video;
                model.CreatedDate = products.CreatedDate;
                model.ModifiedDate = DateTime.Now;
                model.BestSellers = products.BestSellers;
                model.HomeFlag = products.HomeFlag;
                model.Active = products.Active;
                model.Tags = products.Tags;
                model.Title = products.Title;
                model.Alias = Utilities.SEOUrl(model.ProductName);
                model.MetaDesc = products.MetaDesc;
                model.MetaKey = products.MetaKey;
                model.UnitslnStock = products.UnitslnStock;
                _productservices.UpdateProduct();
                
                return RedirectToAction("Index");
            }
            ViewBag.CategoryList = new SelectList(_productservices.GetCategories(), "CatID", "CatName");
          
            return View(products);
        }
        // GET: Admin/AccountsController1/Delete/5
        public IActionResult Delete(int id)
        {
            var product = _productservices.GetProductById(id);
            if (product == null) { return NotFound(); }
            return View(product);
        }

        // POST: Admin/AccountsController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                _productservices.Delete(id);
            }
            return RedirectToAction(nameof(Index));
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

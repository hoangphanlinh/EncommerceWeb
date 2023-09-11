using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Data.ViewModels;
using OrganicShop.Helpper;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public CategoriesController(ICategoryServices categoryServices, IWebHostEnvironment webHostEnvironment)
        {
            _categoryServices = categoryServices;
            _webHostEnvironment = webHostEnvironment;
        }
        public IActionResult Index(int? page,string searchString)
        {
            ViewBag.SearchString = searchString;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lscategories = _categoryServices.GetAllCategories();
            if (!String.IsNullOrEmpty(searchString))
            {
                lscategories = _categoryServices.SearchCategory(searchString);
            }
            PagedList<Categories> models = new PagedList<Categories>(lscategories, pageNumber, pageSize);
            return View(models);
           
        }
        public IActionResult Create()
        {
            ViewBag.Published = _categoryServices.GetPublished();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(UpdateCategoriesViewModel model)
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

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/categories");
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
                var category = new Categories()
                {
                    CatID = model.CatID,
                    CatName = model.CatName,
                    Description = model.Description,
                    ParentID = model.ParentID,
                    Levels = model.Levels,
                    Ordering = model.Ordering,
                    Published = model.Published,
                    Thumb = uniuefilename,
                    Title = model.Title,
                    Alias = Utilities.SEOUrl(model.CatName),
                    MetaDesc = model.MetaDesc,
                    MetaKey = model.MetaKey,
                    Cover = model.Cover,
                    SchemeMarkup = model.SchemeMarkup
                };
                _categoryServices.Add(category);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            var category = _categoryServices.Detail(id);
            if(category == null)
            {
                return NotFound();
            }
            else
            {
                ViewBag.Published = _categoryServices.GetPublished().ToList();
                return View(category);

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Categories category)
        { 
            if(ModelState.IsValid)
            {
                Categories model = _categoryServices.Detail(category.CatID);
                string uniuefilename = model.Thumb;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/categories");
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
                model.CatID = category.CatID;
                model.CatName = category.CatName;
                model.Description = category.Description;
                model.ParentID = category.ParentID;
                model.Levels = category.Levels;
                model.Ordering = category.Ordering;
                model.Published = category.Published;
                model.Thumb = uniuefilename;
                model.Title = category.Title;
                model.Alias = Utilities.SEOUrl(category.CatName);
                model.MetaDesc = category.MetaDesc;
                model.MetaKey = category.MetaKey;
                model.Cover = category.Cover;
                model.SchemeMarkup = category.SchemeMarkup;

                _categoryServices.Edit();
                return RedirectToAction("Index");
            }
            return View(category);
        }
        public IActionResult Detail(int id)
        {
            var model = _categoryServices.Detail(id);
            return View(model);
        }
        public IActionResult Delete(int id)
        {
            var category = _categoryServices.Detail(id);
            if (category == null) { return NotFound(); }
            return View(category);
        }

        // POST: Admin/AccountsController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CategoriesController : Controller
    {
        private readonly ICategoryServices _categoryServices;
        public CategoriesController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
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
        public IActionResult Create([Bind("CatID,CatName,Description,ParentID,Levels,Ordering,Published,Thumb,Title,Alias,MetaDesc,MetaKey,Cover,SchemeMarkup")]Categories category)
        {
            if (ModelState.IsValid)
            {
                _categoryServices.Add(category);
                return RedirectToAction("Index");
            }
            return View(category);
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
                var ViewModel = new UpdateCategoriesViewModel()
                {
                    CatID = category.CatID,
                    CatName = category.CatName,
                    Description = category.Description,
                    ParentID = category.ParentID,
                    Levels = category.Levels,
                    Ordering = category.Ordering,
                    Published = category.Published,
                    Thumb = category.Thumb,
                    Title = category.Title,
                    Alias = category.Alias,
                    MetaDesc = category.MetaDesc,
                    MetaKey = category.MetaKey,
                    Cover = category.Cover,
                    SchemeMarkup = category.SchemeMarkup,
                };
                return View(ViewModel);

            }

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdateCategoriesViewModel model)
        { 
            if(ModelState.IsValid)
            {
                _categoryServices.Edit(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        public IActionResult Detail(int id)
        {
            var model = _categoryServices.Detail(id);
            return View(model);
        }
    }
}

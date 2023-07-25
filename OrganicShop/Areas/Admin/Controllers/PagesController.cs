using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;
using X.PagedList;
using static OrganicShop.Data.ViewModels.PagesViewModel;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly IPageServices _pageServices;
        public PagesController(IPageServices pageServices)
        {
            _pageServices = pageServices;
        }
        public IActionResult Index(int? page,string searchString)
        {
            ViewBag.SearchString = searchString;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lsPages = _pageServices.GetAllPages();
            if (!String.IsNullOrEmpty(searchString))
            {
                lsPages = _pageServices.searchPage(searchString);
            }
            PagedList<Pages> models = new PagedList<Pages>(lsPages, pageNumber, pageSize);
            return View(models);
        }
        public IActionResult Create()
        {
            ViewBag.Published = _pageServices.GetPublished();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Pages model)
        {
            if (ModelState.IsValid)
            {
                _pageServices.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var model = _pageServices.GetById(id);
            if(model == null)
            {
                NotFound();
            }
            return View(model);
        }
        public IActionResult Edit(int id)
        {
            ViewBag.Published = _pageServices.GetPublished().ToList();
            var page = _pageServices.GetById(id);
            if(page == null )
            {
                return NotFound();
            }
            else
            {
                var viewModel = new UpdatePageViewModel()
                {
                    PageID = page.PageID,
                    PageName = page.PageName,
                    Contents = page.Contents,
                    Thumb = page.Thumb,
                    Published = page.Published,
                    Title = page.Title,
                    MetaDesc = page.MetaDesc,
                    MetaKey = page.MetaKey,
                    Alias = page.Alias,
                    CreatedDate = DateTime.Now,
                    Ordering = page.Ordering,
                };
                return View(viewModel);
            }

        }
        // POST: PagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdatePageViewModel model)
        {
            if (ModelState.IsValid)
            {
                _pageServices.Update(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
        // GET: Admin/AccountsController1/Delete/5
        public IActionResult Delete(int id)
        {
            var page = _pageServices.GetById(id);
            if(page == null ) { return NotFound(); }
            return View(page);
        }

        // POST: Admin/AccountsController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                _pageServices.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

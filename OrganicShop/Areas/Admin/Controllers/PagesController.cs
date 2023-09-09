using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Data.ViewModels;
using OrganicShop.Helpper;
using OrganicShop.Models;
using X.PagedList;
using static OrganicShop.Data.ViewModels.PagesViewModel;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PagesController : Controller
    {
        private readonly IPageServices _pageServices;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PagesController(IPageServices pageServices, IWebHostEnvironment webHostEnvironment)
        {
            _pageServices = pageServices;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(PageViewModel model)
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

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/pages");
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
                var pages = new Pages()
                {
                    PageID = model.PageID,
                    PageName = model.PageName,
                    Contents = model.Contents,
                    Thumb = uniuefilename,
                    Published = model.Published,
                    Title = model.Title,
                    MetaDesc = model.MetaDesc,
                    MetaKey = model.MetaKey,
                    Alias = Utilities.SEOUrl(model.PageName),
                    CreatedDate = model.CreatedDate,
                    Ordering = model.Ordering
                };
                _pageServices.Create(pages);
                return RedirectToAction("Index");

            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var model = _pageServices.GetById(id);
            if(model == null)
            {
                NotFound();
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var page = _pageServices.GetById(id);
            if(page == null )
            {
                return NotFound();
            }
            else
            {
                return View(page);
            }

        }
        // POST: PagesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(Pages pages)
        {
            if (ModelState.IsValid)
            {
                Pages model = _pageServices.GetById(pages.PageID);
                string uniuefilename = model.Thumb;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/pages");
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
                _pageServices.Update(pages,Utilities.SEOUrl(pages.PageName),uniuefilename);
                return RedirectToAction("Index");
            }

            return View();
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

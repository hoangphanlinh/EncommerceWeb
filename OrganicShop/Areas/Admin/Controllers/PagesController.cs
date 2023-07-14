using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;

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
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 2;
            var lsPages = _pageServices.GetAllPages();
            PagedList<Pages> models = new PagedList<Pages>(lsPages, pageNumber, pageSize);
            return View(models);
        }
    }
}

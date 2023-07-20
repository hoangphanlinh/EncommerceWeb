using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LocationsController : Controller
    {
        private readonly ILocationServices _locationServices;
        public LocationsController(ILocationServices locationServices)
        {
            _locationServices = locationServices;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lslocations = _locationServices.GetAllLocation();
            PagedList<Locations> models = new PagedList<Locations>(lslocations, pageNumber, pageSize);
            return View(models);
        }
    }
}

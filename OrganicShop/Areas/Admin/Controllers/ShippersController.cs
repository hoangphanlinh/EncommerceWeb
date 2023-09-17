using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ShippersController : Controller
    {
        private readonly IShipperServices _shipperServices;
        public ShippersController(IShipperServices shipperServices)
        {
            _shipperServices = shipperServices;
        }
       public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lsshippers = _shipperServices.GetAllShipper();
            PagedList<Shippers> models = new PagedList<Shippers>(lsshippers, pageNumber, pageSize);
            return View(models);

        }
        [HttpGet]

        public JsonResult LoadData()
        {
            var data = _shipperServices.GetAllShipper().ToList();
            return Json(data);

        }
    }
}

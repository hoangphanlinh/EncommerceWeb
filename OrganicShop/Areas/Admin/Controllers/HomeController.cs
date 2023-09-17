using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly IShipperServices _shipperServices;
        public HomeController(IShipperServices shipperServices)
        {
            _shipperServices = shipperServices;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]

        public JsonResult LoadData()
        {
            var data = _shipperServices.GetAllShipper().ToList();
            return Json(data);

        }
    }
}

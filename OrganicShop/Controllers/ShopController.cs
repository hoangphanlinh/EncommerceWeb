using Microsoft.AspNetCore.Mvc;

namespace OrganicShop.Controllers
{
    public class ShopController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class TransactStationsController : Controller
    {
        private readonly ITransactStatusServices _transactStatusServices;
        public TransactStationsController(ITransactStatusServices transactStatusServices)
        {
            _transactStatusServices = transactStatusServices;
        }

        public IActionResult Index()
        {
            var model = _transactStatusServices.GetAllTransactStatuses();
            return View(model);
        }
    }
}

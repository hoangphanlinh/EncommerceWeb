using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PaymentsController : Controller
    {
        private readonly IPaymentServices _paymentServices;
        public PaymentsController(IPaymentServices paymentServices)
        {
            _paymentServices = paymentServices;
        }

        public IActionResult Index(int? page)
        {

            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lspayments = _paymentServices.GetAllPayments();
            PagedList<Payments> models = new PagedList<Payments>(lspayments, pageNumber, pageSize);
           
            return View(models);
        }
    }
}

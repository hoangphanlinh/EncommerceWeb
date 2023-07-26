using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Models;
using X.PagedList;
using static OrganicShop.Data.ViewModels.PaymentViewModel;

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
        public IActionResult Create()
        {
            ViewBag.Allowed = _paymentServices.GetAllowed();
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("PaymentID,Type,Allowed")]Payments model)
        {
            if(ModelState.IsValid)
            {
                _paymentServices.Create(model);
                return RedirectToAction("Index");
            }
            return View(model);
            
        }
        public IActionResult Edit(int id) 
        {
            ViewBag.Status = _paymentServices.GetAllowed().ToList();
            var payment = _paymentServices.GetById(id);
            if(payment == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new UpdatePaymentViewModel()
                {
                    PaymentID = payment.PaymentID,
                    Type = payment.Type,
                    Allowed = payment.Allowed,
                };
                return View(viewModel);
            }
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(UpdatePaymentViewModel model)
        {
            if (ModelState.IsValid)
            {
                _paymentServices.Update(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

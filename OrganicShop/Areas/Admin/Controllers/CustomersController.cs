using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;
using X.PagedList;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CustomersController : Controller
    {
        private readonly ICustomerServices _customerServices;
        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }
        // GET: CustomersController
        public ActionResult Index(int? page, string? searchString = null, string? status = null)
        {
            ViewBag.SearchString = searchString;
            ViewBag.Status = status;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lsCustomers = _customerServices.GetAllCustomer();
            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(status))
            {
                lsCustomers = _customerServices.SearchCustomer(searchString, status);
            }
            PagedList<Customers> models = new PagedList<Customers>(lsCustomers, pageNumber, pageSize);
            ViewBag.StatusList = _customerServices.GetStatus();
            return View(models);
        }

        // GET: CustomersController/Details/5
        public ActionResult Details(int id)
        {
            var model = _customerServices.Details(id);
            return View(model);
        }
        [HttpGet]
        // GET: CustomersController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.StatusList = _customerServices.GetStatus().ToList();
            var customer = _customerServices.getCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            else
            {
                var viewModel = new UpdateCustomerViewModel()
                {
                    CustomerID = customer.CustomerID,
                    FullName = customer.FullName,
                    BirthDay = customer.BirthDay,
                    Address = customer.Address,
                    Email = customer.Email,
                    Phone = customer.Phone,
                    Active = customer.Active,
                };
                return View(viewModel);

            }
        }

        // POST: CustomersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(UpdateCustomerViewModel model)
        {
            if (ModelState.IsValid)
            {
                _customerServices.Edit(model);
                return RedirectToAction("Index");
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult SearchCustomers(int? page, string? searchString = null, string? status = null,int city=0,int district =0, int ward =0)
        {
            ViewBag.city = city;
            ViewBag.district = district;
            ViewBag.ward = ward;
            ViewBag.SearchString = searchString;
            ViewBag.Status = status;
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 5;
            var lsCustomers = _customerServices.GetAllCustomer();
            if (!String.IsNullOrEmpty(searchString) || !String.IsNullOrEmpty(status) || city>0 || (city >0 && district >0) || (city >0 && district > 0 && ward >0))
            {
                lsCustomers = _customerServices.FilterCustomers(searchString, status,city,district,ward);
            }
            PagedList<Customers> models = new PagedList<Customers>(lsCustomers, pageNumber, pageSize);
            ViewBag.StatusList = _customerServices.GetStatus();
     
            return View(models);
        }
       
        public JsonResult GetCity()
        {
            return Json(new SelectList(_customerServices.GetCity(),"cityId","cityName"));
        }
        public JsonResult getDistrict(int id)
        {
            return Json(new SelectList(_customerServices.GetDistrict(id), "DistrictId", "DistrictName"));
        }
        
        public JsonResult getWard(int id)
        {
            return Json (new SelectList(_customerServices.GetWard(id), "WardId", "WardName"));
        }
    }
}

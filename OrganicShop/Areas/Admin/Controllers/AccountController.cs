using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using System.ComponentModel.DataAnnotations;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly IAccountServices _accountServices;
        public AccountController(IAccountServices accountServices)
        {
            _accountServices = accountServices;
        }

        public IActionResult Index(int? idrole, string? idstatus)
        {

            var result = _accountServices.AccountList();
            if (result == null) {
                return NotFound();
            }
            if (idrole != null || idstatus != null || (idrole!=null && idstatus!=null))
            {
                result = _accountServices.getAccountByRoleAndStatus(idrole, idstatus);
            }

            ViewBag.RoleList = new SelectList(_accountServices.GetRoles(), "RoleId", "RoleName");
            ViewBag.StatusList = _accountServices.GetStatus();

            return View(result);
        }
        public IActionResult Create()
        {
            var roleList = _accountServices.GetRoles();
            ViewBag.RoleList = new SelectList(roleList, "RoleId", "RoleName");

            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("AccountID,Phone,Email,Password,Salt,Active,FullName,RoleID,LastLogin,CreatedDate")] Accounts model)
        {
            if (ModelState.IsValid)
            {
                _accountServices.AddAccount(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public IActionResult Details(int id)
        {
            var role = _accountServices.GetAccountById(id);
            return View(role);
        }
        public IActionResult Edit(int id)
        {
            var roleList = _accountServices.GetRoles();
            var account = _accountServices.GetAccountById(id);
            if(account == null)
            {
                return NotFound();
            }
            ViewBag.RoleList = new SelectList(roleList, "RoleId", "RoleName",account.RoleID);

            return View(account);

        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, [Bind("AccountID, Phone,Email,Password,Salt,Active,FullName,RoleID,LastLogin,CreatedDate")] Accounts model)
        {
            if (id != model.AccountID)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _accountServices.UpdateAccount(id, model);
                return RedirectToAction("Index");
            }
            ViewBag.RoleList = new SelectList(_accountServices.GetRoles(), "RoleId", "RoleName",model.RoleID);

            return View(model);
        }
      

    }
}

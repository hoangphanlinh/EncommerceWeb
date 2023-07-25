using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RolesController : Controller
    {
        private readonly IRoleServices _roleServices;
        public RolesController(IRoleServices roleServices)
        {
            _roleServices = roleServices;
        }
        [HttpGet]
        public IActionResult Index()
        {
            var model = _roleServices.GetAllRole();
            return View(model);
        }
        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create([Bind("RoleId,RoleName,RoleDescription")] Roles model)
        {
            if (ModelState.IsValid)
            {
                _roleServices.AddRole(model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var role = _roleServices.GetRoleById(id);
            if(role == null)
            {
                return NotFound();
            }
            return View(role);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]

        public IActionResult Edit(int id, [Bind("RoleId,RoleName,RoleDescription")] Roles model)
        {
            if(id != model.RoleId)
            {
                return NotFound();
            }
            if (ModelState.IsValid)
            {
                _roleServices.UpdateRole(id, model);
                return RedirectToAction("Index");
            }
            return View(model);
        }
        
    }
}

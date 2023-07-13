using Microsoft.AspNetCore.Mvc;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly AppDBContext _context;
        public RoleServices(AppDBContext context)
        {
            _context = context;
        }
        public void AddRole(Roles role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
        }

        public void DeleteRole(int id)
        {
            var _role = _context.Roles.FirstOrDefault(n => n.RoleId == id);
            if (_role != null)
            {
                _context.Roles.Remove(_role);
                _context.SaveChanges();
            }
            else
            {
                NotFound();
            }
        }

        public List<Roles> GetAllRole()
        {
            return _context.Roles.ToList();
        }

        public Roles GetRoleById(int id)
        {
            var role = _context.Roles.FirstOrDefault(n => n.RoleId == id);
            if (role == null)
            {
                return NotFound();
            }
            return role;

        }

        private Roles NotFound()
        {
            throw new NotImplementedException();
        }

        public Roles UpdateRole(int id, Roles role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return role;
        }
    }
}

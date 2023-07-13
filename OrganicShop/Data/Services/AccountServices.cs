using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;
using System.Data;

namespace OrganicShop.Data.Services
{
    public class AccountServices : IAccountServices
    {
        private readonly AppDBContext _context;
        public AccountServices(AppDBContext context) { _context = context; }
        public List<Accounts> AccountList()
        {
            return _context.Accounts.ToList();
        }

        public void AddAccount(Accounts account)
        {
            _context.Accounts.Add(account);
            _context.SaveChanges();
        }

        public Accounts GetAccountById(int id)
        {
            var account = _context.Accounts.FirstOrDefault(n => n.AccountID == id);
            if (account == null)
            {
                return NotFound();
            }
            return account;
        }

        private Accounts NotFound()
        {
            throw new NotImplementedException();
        }


        public Accounts UpdateAccount(int id, Accounts account)
        {
            _context.Accounts.Update(account);
            _context.SaveChanges();
            return account;
        }

        public List<Roles> GetRoles()
        {
            return _context.Roles.ToList();
        }
        public List<SelectListItem> GetStatus()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "True", Text = "Active" },
                new SelectListItem { Value = "False", Text = "Block" }
            };
            return Status;
        }
        public List<Accounts> getAccountByRoleAndStatus(int? roleId, string? status)
        {
            var accounts = from account in _context.Accounts select account;
            if(roleId != 0)
            {
                accounts = accounts.Where(x => x.RoleID == roleId);
            }
            if (status == "True")
            {
                accounts = accounts.Where(x => x.Active == true);

            }
            if(status == "False")
            {
                accounts = accounts.Where(x => x.Active == false);

            }
            if (status =="False" && roleId != 0)
            {
                accounts = accounts.Where(x => x.Active == false && x.RoleID==roleId);

            }
            if(status == "True" && roleId != 0)
            {
                accounts = accounts.Where(x => x.Active == true && x.RoleID == roleId);

            }


            return accounts.ToList();
        }

    }
}

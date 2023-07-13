using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IAccountServices
    {
        List<Accounts> AccountList();
        void AddAccount(Accounts account);
     
        Accounts GetAccountById(int id);
        Accounts UpdateAccount(int id, Accounts account);
        List<Accounts> getAccountByRoleAndStatus(int? roleId, string? status);

        /*-------------------Dropdown-------------------------------*/
        List<Roles> GetRoles();
        List<SelectListItem> GetStatus();



    }
}

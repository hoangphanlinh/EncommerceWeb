using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IRoleServices
    {
        List<Roles> GetAllRole();
        Roles GetRoleById (int id);
        void AddRole(Roles role);
        Roles UpdateRole(int id, Roles role);
        void DeleteRole(int id);
    }
}

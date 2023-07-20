using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface ILocationServices
    {
        IOrderedQueryable<Locations> GetAllLocation();
    }
}

using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IShipperServices
    {
        IOrderedQueryable<Shippers> GetAllShipper();
    }
}

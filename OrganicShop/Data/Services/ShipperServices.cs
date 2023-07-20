using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class ShipperServices : IShipperServices
    {
        private readonly AppDBContext _context;
        public ShipperServices(AppDBContext context)
        {
            _context = context;
        }
        public IOrderedQueryable<Shippers> GetAllShipper()
        {
            var result = _context.Shippers.AsNoTracking().OrderByDescending(x => x.ShipperID);
            return result;
        }
    }
}

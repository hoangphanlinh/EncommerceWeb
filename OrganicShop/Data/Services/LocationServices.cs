using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class LocationServices : ILocationServices
    {
        private readonly AppDBContext _context;
        public LocationServices(AppDBContext context)
        {
            _context = context;
        }
        public IOrderedQueryable<Locations> GetAllLocation()
        {
            var result = _context.Locations.AsNoTracking().OrderByDescending(x => x.LocationID);
            return result;
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OrganicShop.Data.Interfaces;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class CustomerServices : ICustomerServices
    {
        private readonly AppDBContext _context;
        public CustomerServices(AppDBContext context) 
        {  
            _context = context; 
        }
        public IOrderedQueryable<Customers> GetAllCustomer()
        {
            var result = _context.Customers.AsNoTracking().OrderByDescending(x => x.CustomerID);
            return result;
        }
        public Customers EditActive(int id, Customers customers)
        {
            throw new NotImplementedException();
        }

        public List<Customers> SearchCustomer(string search)
        {
            throw new NotImplementedException();
        }
    }
}

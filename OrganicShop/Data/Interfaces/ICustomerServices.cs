using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface ICustomerServices
    {
        IOrderedQueryable<Customers> GetAllCustomer();
        List<Customers> SearchCustomer(string search);
        Customers EditActive(int id, Customers customers);

    }
}

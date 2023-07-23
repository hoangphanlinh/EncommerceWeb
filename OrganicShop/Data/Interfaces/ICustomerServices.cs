using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface ICustomerServices
    {
        IOrderedQueryable<Customers> GetAllCustomer();
        IOrderedQueryable<Customers> SearchCustomer(string? searchString, string? status);
        void Edit(UpdateCustomerViewModel customers);
        IOrderedQueryable<Customers> FilterCustomers(string? searchString,string? status, int city, int district, int ward);

        Customers Details(int id);
        Customers getCustomerById (int id);
        List<SelectListItem> GetStatus();
        List<City> GetCity();
        List<District> GetDistrict(int cityId);
        List<Ward> GetWard(int districtId);


    }
}

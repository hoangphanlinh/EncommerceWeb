using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IProductServices
    {
        IOrderedQueryable<Products> GetAllProduct();


        /*----Dropdown----*/
        List<Categories> GetCategories();
        List<SelectListItem> GetStatus();
        List<SelectListItem> getStock();

    }
}

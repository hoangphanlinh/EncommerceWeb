using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IProductServices
    {
        IOrderedQueryable<Products> GetAllProduct();
        void CreateProduct(Products product);
        Products GetProductById(int id);
        Products UpdateProduct(int id, Products product);
        IOrderedQueryable<Products> SearchProduct(string searchString,int categoryId);

        /*----Dropdown----*/
        List<Categories> GetCategories();
        List<SelectListItem> GetStatus();
        List<SelectListItem> GetBestSeller();

    }
}

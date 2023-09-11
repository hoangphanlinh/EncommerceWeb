using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IProductServices
    {
        IOrderedQueryable<Products> GetAllProduct();
        void CreateProduct(Products product);
        Products GetProductById(int id);
        void UpdateProduct();
        void Delete(int id);
        IOrderedQueryable<Products> SearchProduct(string searchString,int categoryId);
        IOrderedQueryable<Products> SearchListProduct(string searchString,int categoryId,string status);

        /*----Dropdown----*/
        List<Categories> GetCategories();
        List<SelectListItem> GetStatus();
        List<SelectListItem> GetBestSeller();
        List<SelectListItem> GetActive();

    }
}

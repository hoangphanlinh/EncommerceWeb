using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface ICategoryServices
    {
        IOrderedQueryable<Categories> GetAllCategories();

        List<SelectListItem> GetPublished();
        void Add(Categories categories);
        void Remove(int id);
        Categories Detail(int id);
        void Edit(UpdateCategoriesViewModel category);
        IOrderedQueryable<Categories> SearchCategory(string searchString);

    }
}

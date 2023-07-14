using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface ICategoryServices
    {
        IOrderedQueryable<Categories> GetAllCategories();

        List<SelectListItem> GetPublished();
    }
}

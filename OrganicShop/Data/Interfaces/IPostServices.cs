using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IPostServices
    {
        IOrderedQueryable<Posts> GetAllPost();
        List<Categories> GetCategories();
        List<SelectListItem> GetPublished();
    }
}

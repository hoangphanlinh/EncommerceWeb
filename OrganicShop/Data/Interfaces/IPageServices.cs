using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;

namespace OrganicShop.Data.Interfaces
{
    public interface IPageServices
    {
        IOrderedQueryable<Pages> GetAllPages();
        List<SelectListItem> GetPublished();
    }
}

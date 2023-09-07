using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;
using static OrganicShop.Data.ViewModels.PagesViewModel;

namespace OrganicShop.Data.Interfaces
{
    public interface IPageServices
    {
        IOrderedQueryable<Pages> GetAllPages();
        List<SelectListItem> GetPublished();
        void Create(Pages page);
        void Update(Pages page,string alias, string photo);
        void Delete(int id);
        Pages GetById(int id);
        IOrderedQueryable<Pages> searchPage(string searchString);

    }
}

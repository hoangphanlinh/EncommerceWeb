using Microsoft.AspNetCore.Mvc.Rendering;
using OrganicShop.Models;
using static OrganicShop.Data.ViewModels.PostViewModel;

namespace OrganicShop.Data.Interfaces
{
    public interface IPostServices
    {
        IOrderedQueryable<Posts> GetAllPost();
        List<NewsDirectory> GetNewsDirectories();
        List<SelectListItem> GetPublished();
        void Create(Posts posts);
        Posts GetPostById(int id);
        void Update(UpdatePostViewModel model);
        void Delete(int id);
    }
}

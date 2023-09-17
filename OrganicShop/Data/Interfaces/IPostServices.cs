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
        void Update(Posts model,string photo,string alias);
        void Delete(int id);
        IOrderedQueryable<Posts> SearchPosts(string searchString, int categoryId);
        IEnumerable<Posts> ListBlog();
        IEnumerable<Posts> RelatedBlog(int id);
    }
}

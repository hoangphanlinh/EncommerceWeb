using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.ViewModels;
using OrganicShop.Models;

namespace OrganicShop.Data.Services
{
    public class PostServices : IPostServices
    {
        private readonly AppDBContext _context;
        public PostServices(AppDBContext context)
        {
            _context = context;
        }

        public void Create(Posts posts)
        {
            _context.Posts.Add(posts);
            _context.SaveChanges();
        }

        public IOrderedQueryable<Posts> GetAllPost()
        {
            var result = _context.Posts.Include(x => x.NewsDirectory).Include(y=>y.Accounts).AsNoTracking().OrderByDescending(x => x.PostID);
            return result;
        }

        public List<NewsDirectory> GetNewsDirectories()
        {
            return _context.NewsDirectories.ToList();
        }

        public Posts GetPostById(int id)
        {
            var model = _context.Posts.Include(x=>x.Accounts).Include(y=>y.NewsDirectory).FirstOrDefault(c=>c.PostID == id);
            if (model == null)
                return NotFound();
            return model;
        }

        private Posts NotFound()
        {
            throw new NotImplementedException();
        }

        public List<SelectListItem> GetPublished()
        {
            List<SelectListItem> Status = new()
            {
                new SelectListItem { Value = "1", Text = "Active" },
                new SelectListItem { Value = "0", Text = "Disable" }
            };
            return Status;
        }

        public void Update(PostViewModel.UpdatePostViewModel model)
        {
            var result = GetPostById(model.PostID);
            if(result != null)
            {
                result.PostID = model.PostID;
                result.Title = model.Title;
                result.SContents = model.SContents;
                result.Contents = model.Contents;
                result.Thumb = model.Thumb;
                result.Published = model.Published;
                result.Alias = model.Alias;
                result.CreatedDate  = model.CreatedDate;
                result.Author = model.Author;
                result.AccountID = model.AccountID;
                result.Tags = model.Tags;
                result.NewDirID = model.NewDirID;
                result.isHot = model.isHot;
                result.isNewfeed = model.isNewfeed;
                result.MetaDesc = model.MetaDesc;
                result.MetaKey = model.MetaKey;
                result.Views = model.Views;
            }
           _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var page = _context.Posts.FirstOrDefault(x => x.PostID == id);
            if (page != null)
            {
                _context.Posts.Remove(page);

            }
            _context.SaveChanges();
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;
using Microsoft.IdentityModel.Tokens;
using OrganicShop.Data.Interfaces;
using OrganicShop.Data.Services;
using OrganicShop.Helpper;
using OrganicShop.Models;
using X.PagedList;
using static OrganicShop.Data.ViewModels.PostViewModel;

namespace OrganicShop.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PostsController : Controller
    {
        private readonly IPostServices _postServices;
        public PostsController(IPostServices postServices)
        {
            _postServices = postServices;
        }
        public IActionResult Index(int? page)
        {
            var pageNumber = page == null || page <= 0 ? 1 : page.Value;
            var pageSize = 2;
            var lsposts = _postServices.GetAllPost();
            PagedList<Posts> models = new PagedList<Posts>(lsposts, pageNumber, pageSize);
            ViewBag.NewsList = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");
            ViewBag.PublishedList = _postServices.GetPublished();
            return View(models);
        }
        public IActionResult Create()
        {
            ViewBag.lsNew = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PostID,Title,SContents,Contents,Thumb,Published,Alias,CreatedDate,Author,AccountID,Tags,NewDirID,isHot,isNewfeed,MetaDesc,MetaKey,Views")] Posts posts, IFormFile fThumb )
        {
            if (ModelState.IsValid)
            {
                //Xu ly Thumb
                if(fThumb != null)
                {
                    string extension = Path.GetExtension(fThumb.FileName);
                    string imageName = Helpper.Utilities.SEOUrl(posts.Title) + extension;
                    posts.Thumb = await Utilities.UpLoadFile(fThumb, @"news", imageName.ToLower());
                }
                if (string.IsNullOrEmpty(posts.Thumb)) posts.Thumb = "default.jpg";
                posts.Alias = Utilities.SEOUrl(posts.Title);

                _postServices.Create(posts);
                return RedirectToAction("Index");
            }
            ViewBag.lsNew = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");

            return View(posts);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
           var _post = _postServices.GetPostById(id);
           if(_post != null)
            {
                var viewModel = new UpdatePostViewModel()
                {
                    PostID = _post.PostID,
                    Title = _post.Title,
                    SContents = _post.SContents,
                    Contents = _post.Contents,
                    Thumb = _post.Thumb,
                    Published = _post.Published,
                    Alias = _post.Alias,
                    CreatedDate = _post.CreatedDate,
                    Author = _post.Author,
                    AccountID = _post.AccountID,
                    Tags = _post.Tags,
                    NewDirID = _post.NewDirID,
                    isHot = _post.isHot,
                    isNewfeed = _post.isNewfeed,
                    MetaDesc = _post.MetaDesc,
                    MetaKey = _post.MetaKey,
                    Views = _post.Views,
                };
            }
            return View(_post);
        }
        public IActionResult Edit(int id)
        {
            var _post = _postServices.GetPostById(id);
            ViewBag.lsNew = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");

            if ( _post == null )
            {
                return NotFound();
            }
            else
            {
                var viewModel = new UpdatePostViewModel()
                {
                    PostID = _post.PostID,
                    Title = _post.Title,
                    SContents = _post.SContents,
                    Contents = _post.Contents,
                    Thumb = _post.Thumb,
                    Published = _post.Published,
                    Alias = _post.Alias,
                    CreatedDate = _post.CreatedDate,
                    Author = _post.Author,
                    AccountID = _post.AccountID,
                    Tags = _post.Tags,
                    NewDirID = _post.NewDirID,
                    isHot = _post.isHot,
                    isNewfeed = _post.isNewfeed,
                    MetaDesc = _post.MetaDesc,
                    MetaKey = _post.MetaKey,
                    Views = _post.Views,
                };
                return View(viewModel);

            }

           
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(UpdatePostViewModel posts,IFormFile fThumb)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (fThumb != null)
                    {
                        string extension = Path.GetExtension(fThumb.FileName);
                        string imageName = Helpper.Utilities.SEOUrl(posts.Title) + extension;
                        posts.Thumb = await Utilities.UpLoadFile(fThumb, @"news", imageName.ToLower());
                    }
                    if (string.IsNullOrEmpty(posts.Thumb)) posts.Thumb = "default.jpg";
                    posts.Alias = Utilities.SEOUrl(posts.Title);

                    _postServices.Update(posts);

                    return RedirectToAction("Index");
                }catch(Exception)
                {
                    return NotFound();
                }
            }
            ViewBag.lsNew = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");

            return View(posts);
        }
        public IActionResult Delete(int id)
        {
            var page = _postServices.GetPostById(id);
            if (page == null) { return NotFound(); }
            return View(page);
        }

        // POST: Admin/AccountsController1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            if (ModelState.IsValid)
            {
                _postServices.Delete(id);
            }
            return RedirectToAction(nameof(Index));
        }

    }
}

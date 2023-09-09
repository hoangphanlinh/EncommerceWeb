using Microsoft.AspNetCore.Hosting;
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
        private readonly IWebHostEnvironment _webHostEnvironment;
        public PostsController(IPostServices postServices, IWebHostEnvironment webHostEnvironment)
        {
            _postServices = postServices;
            _webHostEnvironment = webHostEnvironment;
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
        public async Task<IActionResult> Create(CreatePostViewModel model)
        {
            if (ModelState.IsValid)
            {
                //Xu ly Thumb
                string uniuefilename = string.Empty;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/news");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                uniuefilename = fileName;
                            }

                        }
                    }
                }
                var post = new Posts()
                {
                    PostID = model.PostID,
                    Title = model.Title,
                    SContents = model.Contents,
                    Contents = model.Contents,
                    Thumb = uniuefilename,
                    Published = model.Published,
                    Alias = Utilities.SEOUrl(model.Title),
                    CreatedDate = model.CreatedDate,
                    Author = model.Author,
                    AccountID = model.AccountID,
                    Tags = model.Tags,
                    NewDirID = model.NewDirID,
                    isHot = model.isHot,
                    isNewfeed = model.isNewfeed,
                    MetaDesc = model.MetaDesc,
                    MetaKey = model.MetaKey,
                    Views = model.Views
                };
                _postServices.Create(post);
                return RedirectToAction("Index");
            }
           
            ViewBag.lsNew = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");

            return View(model);
        }
        [HttpGet]
        public IActionResult Details(int id)
        {
            var _post = _postServices.GetPostById(id);
            if (_post != null)
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

            if (_post == null)
            {
                return NotFound();
            }
            else
            {
                return View(_post);

            }

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Posts posts)
        {
            if (ModelState.IsValid)
            {
                Posts model = _postServices.GetPostById(posts.PostID);
                string uniuefilename = model.Thumb ;
                var files = HttpContext.Request.Form.Files;
                foreach (var Image in files)
                {
                    if (Image != null && Image.Length > 0)
                    {
                        var file = Image;

                        var uploads = Path.Combine(_webHostEnvironment.WebRootPath, "images/news");
                        if (file.Length > 0)
                        {
                            // var fileName = Guid.NewGuid().ToString().Replace("-", "") + Path.GetExtension(file.FileName);
                            var fileName = Guid.NewGuid().ToString().Replace("-", "") + file.FileName;
                            using (var fileStream = new FileStream(Path.Combine(uploads, fileName), FileMode.Create))
                            {
                                await file.CopyToAsync(fileStream);
                                uniuefilename = fileName;
                            }

                        }
                    }
                }
                _postServices.Update(posts, uniuefilename,Utilities.SEOUrl(posts.Title));
                return RedirectToAction("Index");
            }
            ViewBag.lsNew = new SelectList(_postServices.GetNewsDirectories(), "ID", "Name");

            return View();
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

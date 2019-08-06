using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Forums.Models;
using System;
using Forums.ViewModels.Home;
using Forums.Services.Interfaces;
using System.Linq;
using Forums.ViewModels.Post;
using Forums.ViewModels.Forum;

namespace Forums.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPostService _postService;

        public HomeController(IPostService postService)
        {
            _postService = postService;
        }

        public IActionResult Index()
        {
            var model = BuildHomeIndexModel();
            return View(model);
        }

        private HomeIndexModel BuildHomeIndexModel()
        {
            var latestPosts = _postService.GetLatestPosts(10);            

            var posts = latestPosts.Select(p => new PostListingModel
            {
                Id = p.Id,
                Title = p.Title,
                AuthorName = p.User.UserName,
                AuthorId = p.User.Id,
                AuthorRating = p.User.Rating,
                DatePosted = p.Created.ToString(),
                RepliesCount = p.Replies.Count(),
                Forum = GetForumListingForPost(p)
            });

            return new HomeIndexModel
            {
                LatestPosts = posts,
                SearchQuery = ""
            };
        }

        private ForumListingModel GetForumListingForPost(Post post)
        {
            var forum = post.Forum;

            return new ForumListingModel
            {
                Id = forum.Id,
                Title = forum.Title,
                ImageUrl = forum.ImageUrl,
                Description = forum.Description
            };
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

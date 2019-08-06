using Forums.Models;
using Forums.Services.Interfaces;
using Forums.ViewModels.Forum;
using Forums.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace Forums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;        

        public ForumController(IForumService forumService)
        {
            _forumService = forumService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Title = forum.Title,
                    Description = forum.Description
                });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);

            var posts = forum.Posts.Select(p => new PostListingModel
            {
               Id = p.Id,
               AuthorId = p.User.Id,
               AuthorName = p.User.UserName,
               AuthorRating = p.User.Rating,
               Title = p.Title,
               DatePosted = p.Created.ToString(),
               RepliesCount = p.Replies.Count(),
               Forum = BuildForumListing(p)
            });

            var model = new ForumTopicModel
            {
                Forum = BuildForumListing(forum),
                Posts = posts
            };

            return View(model);
        }

        private ForumListingModel BuildForumListing(Post post)
        {
            var forum = post.Forum;
            return BuildForumListing(forum);
        }

        private ForumListingModel BuildForumListing(Forum forum)
        {
            return new ForumListingModel()
            {
                Id = forum.Id,
                Title = forum.Title,
                Description = forum.Description,
                ImageUrl = forum.ImageUrl
            };
        }
    }
}
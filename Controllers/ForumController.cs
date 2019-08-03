using Forums.Models;
using Forums.Services.Interfaces;
using Forums.ViewModels.Forum;
using Forums.ViewModels.Post;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace Forums.Controllers
{
    public class ForumController : Controller
    {
        private readonly IForumService _forumService;
        private readonly IPostService _postService;

        public ForumController(IForumService forumService, IPostService postService)
        {
            _forumService = forumService;
            _postService = postService;
        }

        public IActionResult Index()
        {
            var forums = _forumService.GetAll()
                .Select(forum => new ForumListingModel
                {
                    Id = forum.Id,
                    Name = forum.Title,
                    Description = forum.Description
                });

            var model = new ForumIndexModel
            {
                ForumList = forums
            };

            return View(model);
        }

        public IActionResult Topic(int id)
        {
            var forum = _forumService.GetById(id);
            var posts = _postService.GetPostsByForum(id);

            var postListings = posts.Select(p => new PostListingModel
            {
               Id = p.Id,
               AuthorId = p.User.Id,
               AuthorRating = p.User.Rating,
               Title = p.Title,
               DatePosted = p.Created.ToString(),
               RepliesCount = p.Replies.Count(),
               Forum = BuildForumListing(p)
            });

            return View(postListings);
        }

        private ForumListingModel BuildForumListing(Post p)
        {
            throw new NotImplementedException();
        }
    }
}
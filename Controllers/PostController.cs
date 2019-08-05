using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forums.Models;
using Forums.Services.Interfaces;
using Forums.ViewModels.Post;
using Forums.ViewModels.Reply;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Forums.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService _postService;
        private readonly IForumService _forumService;
        private readonly UserManager<ApplicationUser> _userManager;

        public PostController(
            IPostService postService,
            IForumService forumService,
            UserManager<ApplicationUser> userManager)
        {
            _postService = postService;
            _forumService = forumService;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index(int id)
        {
            var post = _postService.GetById(id);
            var replies = BuildPostReplies(post.Replies);

            var model = new PostIndexModel
            {
                Id = post.Id,
                Title = post.Title,
                AuthorId = post.User.Id,
                AuthorName = post.User.UserName,
                AuthorImageUrl = post.User.ProfileImageUrl,
                Created = post.Created,
                Content = post.Content,
                Replies = replies
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Create(int id)
        {
            var forum = _forumService.GetById(id);

            var model = new NewPostModel
            {
                ForumName = forum.Title,
                ForumId = forum.Id,
                ForumImageUrl = forum.ImageUrl,
                AuthorName = User.Identity.Name
            };

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> AddPost(NewPostModel model)
        {
            var userId = _userManager.GetUserId(User);
            var user = await _userManager.FindByIdAsync(userId);
            var post = BuildPost(model, user);

            await _postService.Add(post);
            return RedirectToAction("Index", "Post", post.Id);
        }

        private Post BuildPost(NewPostModel model, ApplicationUser user)
        {
            var forum = _forumService.GetById(model.ForumId);

            return new Post
            {
                Title = model.Title,
                Content = model.Content,
                Created = DateTime.Now,
                User = user,
                Forum = forum
            };
        }

        private IEnumerable<PostReplyModel> BuildPostReplies(IEnumerable<PostReply> replies)
        {
            return replies.Select(r => new PostReplyModel
            {
                Id = r.Id,
                AuthorId = r.User.Id,
                AuthorName = r.User.UserName,
                AuthorImageUrl = r.User.ProfileImageUrl,
                AuthorRating = r.User.Rating,
                Created = r.Created,
                Content = r.Content
            });
        }
    }
}
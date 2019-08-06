using Forums.Data;
using Forums.Models;
using Forums.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Forums.Services
{
    public class PostService : IPostService
    {
        private readonly ApplicationDbContext _context;

        public PostService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task Add(Post post)
        {
            _context.Add(post);
            await _context.SaveChangesAsync();
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task EditPostContent(int id, string newContent)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetAll()
        {
            throw new NotImplementedException();
        }

        public Post GetById(int id)
        {
            var post = _context.Posts.Where(p => p.Id == id)
                .Include(p => p.User)
                .Include(p => p.Replies)
                    .ThenInclude(r => r.User)
                .Include(p => p.Forum)
                .First();

            return post;
        }

        public IEnumerable<Post> GetFilteredPosts(string searchQuery)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Post> GetLatestPosts(int numberOfPosts)
        {
            var posts = GetAll()
                .OrderByDescending(p => p.Created)
                .Take(numberOfPosts);

            return posts;
        }

        public IEnumerable<Post> GetPostsByForum(int id)
        {
            var posts = _context.Forums.First(f => f.Id == id).Posts;

            return posts;
        }
    }
}

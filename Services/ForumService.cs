using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Forums.Data;
using Forums.Models;
using Forums.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Forums.Services
{
    public class ForumService : IForumService
    {
        private readonly ApplicationDbContext _context;

        public ForumService(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task Create(Forum forum)
        {
            throw new System.NotImplementedException();
        }

        public Task Delete(int id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            var forums = _context.Forums
                .Include(f => f.Posts);

            return forums;
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new System.NotImplementedException();
        }

        public Forum GetById(int id)
        {
            var forum = _context.Forums.Where(f => f.Id == id)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.Replies)
                        .ThenInclude(r => r.User)
                .Include(f => f.Posts)
                    .ThenInclude(p => p.User)
                .FirstOrDefault();

            return forum;
        }

        public Task UpdateForumDescription(int id, string newDescription)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateForumTitle(int id, string newTitle)
        {
            throw new System.NotImplementedException();
        }
    }
}

using System.Collections.Generic;
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

        public Task Delete(int Id)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Forum> GetAll()
        {
            return _context.Forums
                .Include(forum => forum.Posts);
        }

        public IEnumerable<ApplicationUser> GetAllActiveUsers()
        {
            throw new System.NotImplementedException();
        }

        public Forum GetById(int Id)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateForumDescription(int Id, string newDescription)
        {
            throw new System.NotImplementedException();
        }

        public Task UpdateForumTitle(int Id, string newTitle)
        {
            throw new System.NotImplementedException();
        }
    }
}

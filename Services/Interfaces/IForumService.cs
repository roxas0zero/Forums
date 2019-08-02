using Forums.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forums.Services.Interfaces
{
    public interface IForumService
    {
        Forum GetById(int Id);
        IEnumerable<Forum> GetAll();
        IEnumerable<ApplicationUser> GetAllActiveUsers();

        Task Create(Forum forum);
        Task Delete(int Id);
        Task UpdateForumTitle(int Id, string newTitle);
        Task UpdateForumDescription(int Id, string newDescription);
    }
}
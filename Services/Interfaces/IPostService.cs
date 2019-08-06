using Forums.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Forums.Services.Interfaces
{
    public interface IPostService
    {
        Post GetById(int id);
        IEnumerable<Post> GetAll();
        IEnumerable<Post> GetFilteredPosts(string searchQuery);
        IEnumerable<Post> GetPostsByForum(int id);
        IEnumerable<Post> GetLatestPosts(int numberOfPosts);

        Task Add(Post post);
        Task Delete(int id);
        Task EditPostContent(int id, string newContent);
    }
}

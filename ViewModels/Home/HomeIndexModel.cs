using Forums.ViewModels.Post;
using System.Collections.Generic;

namespace Forums.ViewModels.Home
{
    public class HomeIndexModel
    {
        public string SearchQuery { get; set; }
        public IEnumerable<PostListingModel> LatestPosts { get; set; }
    }
}

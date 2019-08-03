using Forums.ViewModels.Post;
using System.Collections.Generic;

namespace Forums.ViewModels.Forum
{
    public class ForumTopicModel
    {
        public ForumListingModel Forum { get; set; }
        public IEnumerable<PostListingModel> Posts { get; set; }
    }
}

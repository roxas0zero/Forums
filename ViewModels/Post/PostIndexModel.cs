using Forums.ViewModels.Reply;
using System;
using System.Collections.Generic;

namespace Forums.ViewModels.Post
{
    public class PostIndexModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string AuthorId { get; set; }
        public string AuthorName { get; set; }
        public string AuthorImageUrl { get; set; }
        public int AuthorRating { get; set; }
        public DateTime Created { get; set; }
        public string Content { get; set; }

        public IEnumerable<PostReplyModel> Replies { get; set; }
    }
}

using System.Collections.Generic;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Core.Domain.Posts;

namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class PostCommentModel
    {
         public string Title { get; set; }
        public string Description { get; set; }
        public int BlogId { get; set; }
        public ICollection<Comment> Comments { get; set; }
         public int? VisitCount { get; set; }
         public Post ToPost() => new Post
        {
            Title = Title,
            Description = Description,
            BlogId = BlogId
        };
    }
}
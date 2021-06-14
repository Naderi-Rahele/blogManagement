using BlogManagement.Core.Domain.Posts;

using System.ComponentModel.DataAnnotations;
namespace BlogManagement.Core.ApplicationServices.Posts
{
    public class AddPostCommand
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 20)]
        public string Description { get; set; }
        [Required]
        public int BlogId { get; set; }

        public Post ToPost() => new Post
        {
            Title = Title,
            Description = Description,
            BlogId = BlogId
        };

    }
}
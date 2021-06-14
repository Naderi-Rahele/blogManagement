using System.ComponentModel.DataAnnotations;
using BlogManagement.Core.Domain.Comments;

namespace BlogManagement.Core.ApplicationServices.Comments
{
    public class AddCommentCommand
    {
        [Required]
        [StringLength(100, MinimumLength = 5)]
        public string Title { get; set; }
        [Required]
        [StringLength(500, MinimumLength = 5)]
        public string Description { get; set; }
        [Required]
        public int? PostId { get; set; }

        public Comment ToComment()
        {
            return new Comment
            {
                Title = Title,
                Desciption = Description,
                PostId = PostId.Value
            };
        }

    }
    }
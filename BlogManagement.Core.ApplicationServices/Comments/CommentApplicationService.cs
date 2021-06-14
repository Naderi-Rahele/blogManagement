using System.Collections.Generic;
using BlogManagement.Core.Domain.Comments;

namespace BlogManagement.Core.ApplicationServices.Comments
{
    public class CommentApplicationService
    {
        private readonly CommentRepository _commentRepository;

        public CommentApplicationService(CommentRepository commentRepository)
        {
            _commentRepository = commentRepository;
        }

        public void Add(AddCommentCommand comment)
        {
            _commentRepository.Add(comment.ToComment());
        }

        public Comment Get(int commentId)
        {
            return _commentRepository.Get(commentId);
        }

        public ICollection<Comment> Get()
        {
            return _commentRepository.Get();
        }

        public void Remove(int commentId)
        {
            _commentRepository.Remove(commentId);
        }
    }
    }
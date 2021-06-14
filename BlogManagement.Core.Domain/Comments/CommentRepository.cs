using System.Collections.Generic;

namespace BlogManagement.Core.Domain.Comments
{
    public interface CommentRepository
    {
        void Add(Comment comment);
        void Remove(int commentId);
        Comment Get(int commentId);
        ICollection<Comment> Get();

    }
}
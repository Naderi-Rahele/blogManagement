using System.Collections.Generic;

namespace BlogManagement.Core.Domain.Posts
{
    public interface PostRepository
    {
        void Add(Post blog);
        void Remove (int blogId);
        ICollection<Post> Get();
        Post Get(int postId);
    }
}
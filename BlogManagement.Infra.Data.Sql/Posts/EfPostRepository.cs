using System.Collections.Generic;
using System.Linq;
using BlogManagement.Core.Domain.Posts;
using BlogManagement.Infra.Data.Sql.Common;
using Microsoft.EntityFrameworkCore;

namespace BlogManagement.Infra.Data.Sql.Posts
{
    public class EfPostRepository: PostRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;

        public EfPostRepository(BlogManagementDbContext blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
        public void Add(Post post)
        {
            _blogManagementDb.Add(post);
            _blogManagementDb.SaveChanges();
        }

       public Post Get(int postId)
        {
            return _blogManagementDb.Posts.Include(x => x.Comments).Include(x => x.Visits).FirstOrDefault(c => c.Id == postId);
        }

        public void Remove(int postId)
        {
            var comment = new Post
            {
                Id = postId
            };
            _blogManagementDb.Posts.Remove(comment);
            _blogManagementDb.SaveChanges();
        }

        Post PostRepository.Get(int blogId)
        {
            throw new System.NotImplementedException();
        }

        ICollection<Post> PostRepository.Get()
        {
            throw new System.NotImplementedException();
        }
    }
}

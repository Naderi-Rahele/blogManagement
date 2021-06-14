using System.Collections.Generic;
using System.Linq;
using BlogManagement.Core.Domain.Comments;
using BlogManagement.Infra.Data.Sql.Common;

namespace BlogManagement.Infra.Data.Sql.Comments
{
    public class EfCommentRepository: CommentRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;

        public EfCommentRepository(BlogManagementDbContext blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }
        public void Add(Comment comment)
        {
            _blogManagementDb.Add(comment);
            _blogManagementDb.SaveChanges();
        }

        public Comment Get(int commentId)
        {
            return _blogManagementDb.Comments.FirstOrDefault(c => c.Id == commentId);
        }

        public ICollection<Comment> Get()
        {
            return _blogManagementDb.Comments.ToList();
        }

        public void Remove(int commentId)
        {
            var comment = new Comment
            {
                Id = commentId
            };
            _blogManagementDb.Comments.Remove(comment);
            _blogManagementDb.SaveChanges();
        }
    }
}

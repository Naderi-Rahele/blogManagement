using BlogManagement.Core.Domain.Visits;
using BlogManagement.Infra.Data.Sql.Common;

namespace BlogManagement.Infra.Data.Sql.Visits
{
    public class EfVisitRepository: VisitRepository
    {
        private readonly BlogManagementDbContext _blogManagementDb;

        public EfVisitRepository(BlogManagementDbContext blogManagementDb)
        {
            _blogManagementDb = blogManagementDb;
        }

        public void Add(Visit visit)
        {
            _blogManagementDb.Add(visit);
            _blogManagementDb.SaveChanges();
        }
    }
}

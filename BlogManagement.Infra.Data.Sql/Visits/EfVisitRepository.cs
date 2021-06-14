using System.Threading.Tasks;
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

        public async Task Add(Visit visit)
        {
           await _blogManagementDb.AddAsync(visit);
           await _blogManagementDb.SaveChangesAsync();
        }
    }
}

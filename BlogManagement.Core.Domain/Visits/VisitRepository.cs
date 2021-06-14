using System.Threading.Tasks;

namespace BlogManagement.Core.Domain.Visits
{

    public interface VisitRepository
    {
        Task Add(Visit visit);
    }
}
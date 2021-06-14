using BlogManagement.Core.Domain.Visits;

namespace BlogManagement.Core.ApplicationServices.Visits
{
    public class VisitApplicationService
    {
         private readonly VisitRepository _visitRepository;

        public VisitApplicationService(VisitRepository visitRepository)
        {
            _visitRepository = visitRepository;
        }

        public void Add(Visit visit)
        {
            _visitRepository.Add(visit);
        }
    }
    }
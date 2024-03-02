

using PubsMartes.Domain.Entities;
using PubsMartes.Domain.Repository;

namespace PubsMartes.Infrastructure.Interfaces
{
    public interface IjobsRepository : IBaseRepository<jobs>
    {
        List<jobs> GetJobsByDescription(string description);
    }
}

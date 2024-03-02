using PubsMartes.Domain.Entities;
using PubsMartes.Domain.Repository;
using PubsMartes.Infrastructure.Interfaces;

namespace PubsMartes.Infrastructure.Repositories
{
    public class jobsRepository : IjobsRepository
    {
        public List<jobs> GetEntities()
        {
            throw new NotImplementedException();
        }

        public jobs GetEntity(int id)
        {
            throw new NotImplementedException();
        }

        public List<jobs> GetJobsByDescription(string description)
        {
            throw new NotImplementedException();
        }

        public void Remove(jobs entity)
        {
            throw new NotImplementedException();
        }

        public void Save(jobs entity)
        {
            throw new NotImplementedException();
        }

        public void Update(jobs entity)
        {
            throw new NotImplementedException();
        }
    }
}

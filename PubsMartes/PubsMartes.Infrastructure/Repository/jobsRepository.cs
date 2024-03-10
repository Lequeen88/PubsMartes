using PubsMartes.Domain.Entities;
using PubsMartes.Infrastructure.Context;
using PubsMartes.Infrastructure.Core;
using PubsMartes.Infrastructure.Interface;

namespace PubsMartes.Infrastructure.Repository
{
    public class jobRepository : BaseRepository<Jobs>, IJobsRepository
    {
        private readonly PubsMartesContext context;

        public jobRepository(PubsMartesContext context) : base(context)
        {
            this.context = context;
        }

        public override List<Jobs> GetEntities()
        {
            return base.GetEntities().Where(job => !job.Deleted)
                                   .OrderByDescending(job => job.CreationDate).ToList();
        }

        public override void Save(Jobs entity)
        {
            base.Save(entity);
            context.SaveChanges();
        }

        public override void Update(Jobs entity)
        {
            var JobUpdate = base.GetEntityByID(entity.JobID);

            JobUpdate.JobID = entity.JobID;
            JobUpdate.JobDescription = entity.JobDescription;
            JobUpdate.Maxlvl = entity.Maxlvl;
            JobUpdate.Minlvl = entity.Minlvl;
            JobUpdate.ModifiedDate = entity.ModifiedDate;
            JobUpdate.IDModifiedUser = entity.IDModifiedUser;

            //context.jobs.update(JobUpdate);
            context.SaveChanges();

        }

        public override void Remove(Jobs entity)
        {
            var JobRemove = base.GetEntityByID(entity.JobID);

            JobRemove.JobID = entity.JobID;
            JobRemove.Deleted = true;
            JobRemove.DeletedDate = entity.DeletedDate;
            JobRemove.DeletedUser = entity.DeletedUser;

            //context.jobs.update(JobRemove);
            context.SaveChanges();
        }
    }
}

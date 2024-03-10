using PubsMartes.Application.Core;
using PubsMartes.Application.Dtos.Jobs;


namespace PubsMartes.Application.Contract
{
    public interface IJobsService : IBaseService<JobsDtoUpdate, JobsDtoAdd, JobDtoRemove>
    {
    }
}

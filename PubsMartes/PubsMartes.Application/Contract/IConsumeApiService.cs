
using PubsMartes.Application.Dtos.Jobs;

namespace PubsMartes.Application.Contract;

public interface IConsumeApiService
{
    Task<JonDetailsResult> GetAllJobs();
    Task CreateJob(JobsDtoAdd request);
    Task<JobsDtoUpdate> GetJobById(int id);
    Task EditJob(int id, JobsDtoUpdate request);

    Task<JobDtoRemove> GetDeleteModel(int id);
    Task Delete(JobDtoRemove request);



}
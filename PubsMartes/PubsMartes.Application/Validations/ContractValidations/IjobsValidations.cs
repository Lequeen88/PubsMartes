using PubsMartes.Application.Dtos.Jobs;
using PubsMartes.Application.Validations.IBaseValidations;


namespace PubsMartes.Application.Validations.ContractValidations
{
    public interface IjobsValidations : IValidationsServices<JobsDtoBase, JobsDtoUpdate, JobsDtoAdd, JobDtoRemove>
    {

    }
}

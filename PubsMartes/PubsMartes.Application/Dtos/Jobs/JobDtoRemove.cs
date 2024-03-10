
using PubsMartes.Application.Dtos.BasesDto;

namespace PubsMartes.Application.Dtos.Jobs
{
    public class JobDtoRemove : DtoBase
    {
        public int JobID { get; set; }
        public bool Deleted { get; set; }
    }
}

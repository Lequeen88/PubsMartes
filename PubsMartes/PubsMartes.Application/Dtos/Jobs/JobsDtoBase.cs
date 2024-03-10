using PubsMartes.Application.Dtos.BasesDto;


namespace PubsMartes.Application.Dtos.Jobs
{
    public class JobsDtoBase : DtoBase
    {
        public string JobDescription { get; set; }
        public byte Minlvl { get; set; }
        public byte Maxlvl { get; set; }

    }
}

using PubsMartes.Domain.core;

namespace PubsMartes.Domain.Entities
{
    public class Jobs : BaseEntity
    {
        public int JobID { get; set; }
        public string? JobDescription { get; set; }
        public byte Minlvl { get; set; }
        public byte Maxlvl { get; set; }

    }
}

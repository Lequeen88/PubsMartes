
namespace PubsMartes.Domain.core
{
    public abstract class BaseEntity
    {
        public BaseEntity() 
        {
            
        }

        public string? City { get; set; }

        public string? State { get; set; }
    }
}

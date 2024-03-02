using Microsoft.EntityFrameworkCore;
using PubsMartes.Domain.Entities;

namespace PubsMartes.Infrastructure.Context
{
    public class PubsContext : DbContext
    {
        public PubsContext(DbContextOptions<PubsContext> options) : base(options)
        {
        }
        public DbSet<jobs> Jobs { get; set; }

    }
}

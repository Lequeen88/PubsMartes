using Microsoft.EntityFrameworkCore;
using PubsMartes.Domain.Entities;

namespace PubsMartes.Infrastructure.Context
{
    public class PubsMartesContext : DbContext
    {
        internal object jobs;

        public PubsMartesContext(DbContextOptions<PubsMartesContext> options) : base(options)
        {

        }
        public DbSet<Jobs> Jobs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)

        {
            modelBuilder.Entity<Jobs>().HasKey(e => e.JobID);
            
        }
    }
}

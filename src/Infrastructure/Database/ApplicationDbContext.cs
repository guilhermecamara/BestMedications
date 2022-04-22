using Infrastructure.Database.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infrastructure.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<MedicationModel> Medications { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MedicationModel>()
               .Property(b => b.CreationDate)
               .HasDefaultValueSql("getdate()");

            base.OnModelCreating(modelBuilder);
        }
    }
}

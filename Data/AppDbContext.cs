using bARTapp.Models;
using Microsoft.EntityFrameworkCore;

namespace bARTapp.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<Contact> Contact { get; set; }
        
        public DbSet<Account> Account { get; set; }
        
        public DbSet<Incident> Incident { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Contact>()
                .HasOne(a => a.Account)
                .WithMany(c => c.Contacts);
            
            modelBuilder.Entity<Incident>()
                .HasMany(a => a.Accounts)
                .WithOne(y => y.Incident);

            modelBuilder.Entity<Account>()
                .HasIndex(e => e.Name)
                .IsUnique();
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using THE_SPOT.Models;

namespace THE_SPOT.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<Tea>()
       .Property(p => p.Price)
       .HasPrecision(18, 2);
            modelBuilder.Entity<IdentityUserLogin<string>>()
         .HasKey(l => new { l.LoginProvider, l.ProviderKey });

            modelBuilder.Entity<IdentityUserRole<string>>()
                .HasKey(r => new { r.UserId, r.RoleId });
            modelBuilder.Entity<IdentityUserToken<string>>()
        .HasKey(t => new { t.UserId, t.LoginProvider, t.Name });
        }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<CoffeeDeptPR> CoffeeDeptPR { get; set; }
        public DbSet<TeaDeptPR> TeaDeptPR { get; set; }
        public DbSet<MugsDeptPR> MugsDeptPR { get; set; }
        public DbSet<Tea> Teas { get; set; }
    }
}
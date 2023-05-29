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
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<CoffeeDeptPR> CoffeeDeptPR { get; set; }
        public DbSet<TeaDeptPR> TeaDeptPR { get; set; }
        public DbSet<MugsDeptPR> MugsDeptPR { get; set; }
    }
}
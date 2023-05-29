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
        public DbSet<DeptEmployeePR> DeptEmployeePR { get; set; }
    }
}
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using TimeKeeper.Web.Models;

namespace TimeKeeper.Data
{
    public class AppDbContext : IdentityDbContext<AppUser, AppRole, string>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {

        }

        public DbSet<ProjectModel> Projects { get; set; }
        public DbSet<CompanyModel> Companies { get; set; }
        public DbSet<PersonModel> Customers { get; set; }

    }
}

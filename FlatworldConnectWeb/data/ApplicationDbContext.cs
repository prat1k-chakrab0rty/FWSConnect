using FlatworldConnectWeb.Models;
using Microsoft.EntityFrameworkCore;

namespace FlatworldConnectWeb.data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customers { get; set; }
        public DbSet<Login> Logins { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ManageProject> ManageProjects { get; set; }
        public DbSet<CreateProject> CreateProjects { get; set; }
    }
}

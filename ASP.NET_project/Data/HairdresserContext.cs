using ASP.NET_project.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

namespace ASP.NET_project.Data
{
    public class HairdresserContext : IdentityDbContext<IdentityUser>
    {
        public HairdresserContext(DbContextOptions<HairdresserContext> options) : base(options)
        {
        }

        public DbSet<Worker> Workers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Reservation> Reservations { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Worker>().ToTable("Worker");
            modelBuilder.Entity<Client>().ToTable("Client");
            modelBuilder.Entity<Service>().ToTable("Service");
            modelBuilder.Entity<Reservation>().ToTable("Reservation");
        }
    }
}

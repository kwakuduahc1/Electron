using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Electron.Context
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=assistant.db;", x =>
            {
                x.SuppressForeignKeyEnforcement(false);
                x.UseRelationalNulls(true);
            });
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Locations>(x => x.HasData(
                new Locations { Location = "Kumasi", LocationsID = 1, Region = "Ashanti" },
                new Locations { Location = "Accra", LocationsID = 2, Region = "Greater Accra" },
                new Locations { Location = "Nalerigu", Region = "Northern", LocationsID = 3 }
                ));
            base.OnModelCreating(builder);
            // Customize the ASP.NET Identity model and override the defaults if needed.// For example, you can rename the ASP.NET Identity table names and more.// Add your customizations after calling base.OnModelCreating(builder);
        }

        public virtual DbSet<Locations> Locations { get; set; }
    }

    public class Locations
    {
        [Key]
        public int LocationsID { get; set; }

        [Required]
        public string Location { get; set; }

        [Required]
        public string Region { get; set; }
    }
}

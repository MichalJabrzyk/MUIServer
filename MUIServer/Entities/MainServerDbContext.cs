using Microsoft.EntityFrameworkCore;
using VisioForge.Libs.AForge.Math.Geometry;

namespace MUIServer.Entities
{
    public class MainServerDbContext : DbContext
    {

        private string _connectionString = "Data Source=DESKTOP-UN8ETUT\\SQLEXPRESS;Initial Catalog = MainServer; Integrated Security = True; TrustServerCertificate=True";

        public DbSet<MainServer> MainServer { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MainServer>()
                .Property(p => p.MainServerID)
                .IsRequired();

            modelBuilder.Entity<MainServer>()
                .Property(p => p.MainServerName)
                .IsRequired()
                .HasMaxLength(50);

            modelBuilder.Entity<MainServer>()
                .Property(p => p.MainServerTimeStart)
                .IsRequired()
                .HasMaxLength(50);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);

        }
    }
}

using Microsoft.EntityFrameworkCore;
using SamauraiApp.Domain;

namespace SamauraiApp.Data
{
    public class SamauraiContext : DbContext
    {
        public DbSet<Samurai> Samurais { get; set; }
        public DbSet<Quote> Quotes { get; set; }
        public DbSet<Clan> Clans { get; set; }
        private const string _dbConnectionString = "Server=DESKTOP-PHMAO3P\\SQLSERVER17;database=efcore31samrui;Trusted_connection=true;pooling=true;MultipleActiveResultSets=True";

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_dbConnectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SamuraiBattle>().HasKey(s => new { s.BattleId, s.SamuraiId });
            base.OnModelCreating(modelBuilder);
        }
    }
}

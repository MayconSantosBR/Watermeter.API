using Microsoft.EntityFrameworkCore;
using Watermeter.Project.API.Entities;

namespace Watermeter.Project.API.Data.Context
{
    public class MainContext : DbContext
    {
        public DbSet<Owner> Owners { get; set; }
        public DbSet<Arduino> Arduinos { get; set; }
        public DbSet<Achieviment> Achieviments { get; set; }
        public DbSet<History> Histories { get; set; }

        public MainContext(DbContextOptions<MainContext> options) : base(options) {}
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}

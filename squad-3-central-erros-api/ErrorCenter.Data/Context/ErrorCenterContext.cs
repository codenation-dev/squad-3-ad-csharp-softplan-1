using ErrorCenter.Data.Config;
using ErrorCenter.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace ErrorCenter.Data.Context
{
    public class ErrorCenterContext : DbContext
    {
        public ErrorCenterContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Error> Errors { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<ErrorOccurrence> ErrorOccurrences { get; set; }
        public DbSet<Situation> Situations { get; set; }
        public DbSet<Level> Levels { get; set; }
        public DbSet<Domain.Models.Environment> Environments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(string)))
            {
                if (property.GetMaxLength() == null) property.SetMaxLength(255);
            }

            //foreach (var property in modelBuilder.Model.GetEntityTypes()
            //    .SelectMany(t => t.GetProperties()).Where(p => p.ClrType == typeof(decimal)))
            //{
            //    if (property.GetColumnType() == null) property.SetColumnType("decimal(18, 4)");
            //}

            // modelBuilder.ApplyConfiguration(new ClienteConfig());
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ErrorCenterContext).Assembly);




        }
    }
}

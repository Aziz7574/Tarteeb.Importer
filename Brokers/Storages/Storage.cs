using Microsoft.EntityFrameworkCore;
using Tarteeb.Importer.Models.Clients.Model;

namespace Tarteeb.Importer.DataBase.DAL
{
    internal class Storage : DbContext
    {
        private readonly IConfiguration _configuration;

        public Storage(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.EnsureCreated();
            Database.Migrate();
        }

        public DbSet<Client> Clients { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            optionsBuilder.UseSqlite(_configuration.GetConfiguration());
        }
    }
}

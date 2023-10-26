//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.EntityFrameworkCore;
using Tarteeb.Importer.Models.Clients;
using Database = Microsoft.EntityFrameworkCore.Storage.Database;

namespace Tarteeb.Importer.DataBase.DAL
{
    internal class Broker : DbContext
    {
        private readonly IConfiguration _configuration;

        Broker()
        {

        }

        public Broker(IConfiguration configuration)
        {
            _configuration = configuration;
            Database.Migrate();
        }
        public DbSet<Client> Clients { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
            string connectingString = this._configuration.GetConfiguration();
            optionsBuilder.UseSqlite(connectingString);
        }
    }
}

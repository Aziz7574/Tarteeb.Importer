//===========================
// Copyright (c) Tarteeb LLC
// Powering True Leadership
//===========================

using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tarteeb.Importer.Models.Clients;

namespace Tarteeb.Importer.DataBase.DAL
{
    internal class StorageBroker : Broker, IStorageBroker<Client>
    {

        public StorageBroker(IConfiguration configuration) : base(configuration)
        {
        }

        public async ValueTask<Client> DeleteAsync(Expression<Func<Client, bool>> expression)
        {
            var obj = await this.Clients.FirstOrDefaultAsync(expression);
            this.Entry(obj).State = EntityState.Deleted;
            await this.SaveChangesAsync();
            return obj;
        }

        public async ValueTask<Client> InsertAsync(Client @object)
        {
            this.Entry(@object).State = EntityState.Added;
            await this.SaveChangesAsync();
            return @object;
        }

        public IQueryable<Client> SelectAllAsync()
        {
            return this.Clients.Where(l => l.Id != default);
        }

        public async ValueTask<Client> SelectObjectAsync(Expression<Func<Client, bool>> expression)
        {
            Client client = await this.Clients.FirstOrDefaultAsync(expression);
            return client;
        }

        public async ValueTask<Client> UpdateObjectAsync(Client @object)
        {
            this.Clients.Update(@object);
            await this.SaveChangesAsync();
            return @object;
        }
    }
}

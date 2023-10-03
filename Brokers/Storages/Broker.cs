using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Tarteeb.Importer.Models.Clients.Model;

namespace Tarteeb.Importer.DataBase.DAL
{
    internal class Broker : IBroker
    {
        private static Storage _storage;

        internal Broker()
        {
            _storage = new Storage(new Configuration());
        }




        public async ValueTask<Client> InsertAsync(Client client)
        {
            await _storage.Clients.AddAsync(client);

            var result = await _storage.SaveChangesAsync();
            if (result == 1)
                return client;
            return null;
        }




        public async ValueTask<Client> DeleteAsync(Expression<Func<Client, bool>> expression)
        {
            var client = await _storage.Clients.FirstOrDefaultAsync(expression);

            _storage.Clients.Remove(client);
            var result = await _storage.SaveChangesAsync();
           if(result == 1)
                return client;
           return null;
        }




        public async ValueTask<Client> GetAsync(Expression<Func<Client, bool>> expression)
        {
            Client client = await _storage.Clients.FirstOrDefaultAsync(expression);
            return client;
        }



        public async ValueTask<Client> UpdateAsync(Expression<Func<Client, bool>> expression, Client client)
        {
            Client dbClient = await _storage.Clients.FirstOrDefaultAsync(expression);

            if (dbClient is null) return null;

            client.Id = dbClient.Id;
            dbClient.FirstName = client.FirstName;
            dbClient.LastName = client.LastName;
            dbClient.Email = client.Email;
            dbClient.BirthDate = client.BirthDate;

            _storage.Clients.Update(client);
            var result = await _storage.SaveChangesAsync();

            return client;


        }
    }
}

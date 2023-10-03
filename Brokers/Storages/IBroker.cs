using System.Linq.Expressions;
using Tarteeb.Importer.Models.Clients.Model;

namespace Tarteeb.Importer.DataBase.DAL
{
    internal interface IBroker
    {
        ValueTask<Client> InsertAsync(Client client);

        ValueTask<Client> GetAsync(Expression<Func<Client, bool>> expression);

        ValueTask<Client> UpdateAsync(Expression<Func<Client, bool>> expression, Client client);

        ValueTask<Client> DeleteAsync(Expression<Func<Client, bool>> expression);
    }
}

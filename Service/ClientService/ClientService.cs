using System.Linq.Expressions;
using Tarteeb.Importer.DataBase.DAL;
using Tarteeb.Importer.Models.Clients.Model;

namespace Tarteeb.Importer.Service.ClientService
{
    internal class ClientService
    {
        private readonly Broker _broker;
        private readonly ClientValidationException _clientValidation;
        internal ClientService()
        {
            this._broker = new Broker();
            _clientValidation = new ClientValidationException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public async Task<Client> AddAsync(Client client)
        {
            _clientValidation.ValidateClientToNull(client);
            _clientValidation.ValidateClient(client);

            return await _broker.InsertAsync(client);
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="expression"></param>
        /// <returns></returns>
        public async Task<Client> GetAsync(Expression<Func<Client, bool>> expression)
        => await _broker.GetAsync(expression);


        public async Task<Client> RemoveAsync(Expression<Func<Client, bool>> expression)
        => await _broker.DeleteAsync(expression);
    }
}


using System.Linq.Expressions;
using Tarteeb.Importer.DataBase.DAL;
using Tarteeb.Importer.Models.Clients;
using Configuration = Tarteeb.Importer.DataBase.DAL.Configuration;

namespace Tarteeb.Importer.Service.ClientService
{
    internal class ClientService
    {
        private readonly IStorageBroker<Client> _broker;
        private readonly IConfiguration _configuration = new Configuration();
        private readonly ClientValidationException _clientValidation;
        internal ClientService()
        {
            //this._broker = new StorageBroker(_configuration);
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
        => await _broker.SelectObjectAsync(expression);


        public async Task<Client> RemoveAsync(Expression<Func<Client, bool>> expression)
        {
            try
            {
                return await _broker.DeleteAsync(expression);
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
            catch (NullReferenceException ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}


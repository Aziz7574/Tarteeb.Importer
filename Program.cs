using Tarteeb.Importer.DataBase.DAL;
using Tarteeb.Importer.Service.ClientService;

namespace Tarteeb.Importer
{
    internal class Program
    {
        static async Task Main()
        {
            var clientService = new ClientService();

            //await clientService.AddAsync(new Models.Clients.Model.Client()
            //{
            //    Id = Guid.Empty,
            //    FirstName = "h = k",
            //    LastName = string.Empty,
            //    BirthDate = new DateTime(2010,10,19),
            //    Email = "wiufeh ijhu "
            //}) ;
            // Client client = await clientService.GetAsync(p => p.FirstName == "h = k");
            //Console.WriteLine(client.LastName);  

            Broker broker = new Broker();

            await broker.DeleteAsync(p => p.LastName == string.Empty);




        }
    }
}
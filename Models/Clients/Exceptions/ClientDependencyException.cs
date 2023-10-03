using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class ClientDependencyException : Xeption
    {
        public ClientDependencyException(Exception innerException)
            : base("Client dependency exception,contact support", innerException)
        {

        }
    }
}

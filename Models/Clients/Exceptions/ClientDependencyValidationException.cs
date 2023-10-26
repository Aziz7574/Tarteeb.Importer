using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class ClientDependencyValidationException : Xeption
    {
        public ClientDependencyValidationException(Exception innerException)
            : base(message: "Client dependency error occured, fix errors and try again", innerException)
        { }
    }
}

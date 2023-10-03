using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class ClientDependencyValidationException : Xeption
    {
        public ClientDependencyValidationException(Xeption innerException)
            : base(message: "Client dependency error occured, fix errors and try again", innerException)
        { }
    }
}

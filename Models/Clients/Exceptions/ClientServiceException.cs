using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class ClientServiceException : Xeption
    {
        public ClientServiceException(Exception innerException)
            : base(message: "Client service error occurred, please contact support", innerException)
        { }
    }

}

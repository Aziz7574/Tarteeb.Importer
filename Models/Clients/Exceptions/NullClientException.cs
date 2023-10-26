using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class NullClientException : Xeption
    {
        public NullClientException(Exception innerException)
            : base(message: "Client is null", innerException)
        { }
    }
}

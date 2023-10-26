using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class InvalidClientException : Xeption
    {
        internal InvalidClientException(Exception innerException)
            : base("Client is invalid, Please fix errors and try again", innerException)
        { }
    }
}

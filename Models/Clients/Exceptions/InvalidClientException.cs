using Xeptions;

namespace Tarteeb.Importer.Models.Clients.ClientExceptions
{
    internal class InvalidClientException : Xeption
    {
        internal InvalidClientException()
            : base("Client is invalid, Please fix errors and try again")
        { }
    }
}

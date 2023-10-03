using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class LockedClientException : Xeption
    {
        internal LockedClientException(Exception innerException) :
            base(message: "Client is locked, try later again", innerException)
        { }
    }
}

using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class FailedStorageClientException : Xeption
    {
        public FailedStorageClientException(Exception innerException)
            : base(message: "Client failed storage exception,contact support", innerException)
        {}
    }

}

using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class FailedServiceClientException : Xeption
    {
        public FailedServiceClientException(Exception innerException)
            : base(message: "Failed client service occurred,please contact support", innerException)
        { }
    }
}

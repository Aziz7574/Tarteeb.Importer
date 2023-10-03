using Xeptions;

namespace Tarteeb.Importer.Models.Clients.ClientExceptions
{
    internal class NullClientException : Xeption
    {
        public NullClientException() : base(message: "Client is null")
        { }



    }
}

using Xeptions;

namespace Tarteeb.Importer.Models.Clients.Exceptions
{
    internal class AlreadyExistsClientException : Xeption
    {
        internal AlreadyExistsClientException(Exception innerException) 
            : base(message:"Client already exists",innerException ) 
        { }
    }

}

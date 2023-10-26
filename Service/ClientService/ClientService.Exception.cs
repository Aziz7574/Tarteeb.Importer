using Microsoft.EntityFrameworkCore;
using Tarteeb.Importer.Models.Clients;
using Tarteeb.Importer.Models.Clients.Exceptions;
using Xeptions;

namespace Tarteeb.Importer.Service.ClientService
{
    internal class ClientServiceException
    {
        private delegate Task<Client> ReturningClientFunction();

        private Task<Client> TryCatch(ReturningClientFunction returningClientFunction)
        {
            try
            {
                return returningClientFunction();
            }
            catch (NullClientException nullClientException)
            {
                throw CreateValidationException(nullClientException);
            }
            catch (InvalidClientException invalidClientException)
            {
                throw CreateValidationException(invalidClientException);
            }
            //catch (DuplicateKeyException duplicateKeyException)
            //{
            //    var alreadyExistsClientException
            //        = new AlreadyExistsClientException(duplicateKeyException);
            //    throw CreateDependencyException(alreadyExistsClientException);
            //}
            catch (DbUpdateConcurrencyException dbUpdateConcurrencyException)
            {
                var lockedClientException = new LockedClientException(dbUpdateConcurrencyException);
                throw CreateClientDependencyException(lockedClientException);
            }

            catch (DbUpdateException dbUpdateException)
            {
                var failedStorageClientException
                = new FailedStorageClientException(dbUpdateException);
                throw CreateDependencyException(failedStorageClientException);
            }
            /* catch(Exception exception)
             {
                 var clientServiceException = new ClientServiceException(exception);
                 CreateClientServiceException(exception);
             }*/

        }



        private ClientServiceException CreateClientServiceException(Xeption xeption)
        {
            var clientServiceException
                = new ClientServiceException();

            return clientServiceException;
        }

        private FailedStorageClientException CreateDependencyException(LockedClientException locked)
        {
            var failedStorageClientException = new FailedStorageClientException(locked);
            return failedStorageClientException;
        }



        private ClientDependencyException CreateClientDependencyException(Xeption xeption)
        {
            var clientDependencyException
                = new ClientDependencyException(xeption);
            return clientDependencyException;
        }


        private ClientValidationException CreateValidationException(Xeption xeption)
        {
            var clientValidationException = new ClientValidationException();
            return clientValidationException;
        }


        private ClientDependencyValidationException CreateDependencyException(Xeption xeption)
        {
            var clientDependencyValidationException
                = new ClientDependencyValidationException(xeption);
            return clientDependencyValidationException;
        }
    }
}

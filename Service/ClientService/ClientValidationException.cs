using System.Collections;
using System.Text.RegularExpressions;
using Tarteeb.Importer.Models.Clients;
using Tarteeb.Importer.Models.Clients.Exceptions;
using Xeptions;

namespace Tarteeb.Importer.Service.ClientService
{
    internal class ClientValidationException : Xeption
    {

        //internal ClientValidationException(Xeption innerException)
        //    : base(message: "Client is invalid", innerException)
        //{ }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public dynamic IsInvalid(Guid id)
            =>
            new
            {
                Condition = id.Equals(default),
                Message = $"{nameof(id)} is required"
            };


        /// <summary>
        /// 
        /// </summary>
        /// <param name="dateTime"></param>
        /// <returns></returns>
        public dynamic IsAgeGreeterThan18(DateTimeOffset dateTime)
            =>
            new
            {
                Condition = (DateTimeOffset.Now.Day - dateTime.Day) / 365 >= 18,
                Message = "Age can't qualify the standart"
            };



        /// <summary>
        /// 
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public dynamic IsInvalid(string text)
            => new
            {
                Condition = string.IsNullOrWhiteSpace(text),
                Message = $"{nameof(text)} is required"
            };



        /// <summary>
        /// 
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        public dynamic IsInvalidEmail(string email)
            => new
            {
                Condition = Regex.IsMatch(email, "/^[a-zA-Z0-9.!#$%&'*+/=?^_`{|}~-]+@[a-zA-Z0-9-]+(?:\\.[a-zA-Z0-9-]+)*$"),
                Message = $"Email can't qualify"
            };




        /// <summary>
        /// 
        /// </summary>
        /// <param name="validations"></param>
        public void Validate(params (dynamic rule, string parameter)[] validations)
        {
            var invalidClientException = new InvalidClientException(new Exception());

            foreach ((dynamic rule, string parameter) in validations)
            {
                if (!rule.Condition)
                {
                    invalidClientException.UpsertDataList(
                        key: parameter,
                         value: rule.Message
                        );
                }
            }
            invalidClientException.ThrowIfContainsErrors();
        }



        /// <summary>
        /// 
        /// </summary>
        /// <param name="client"></param>
        /// <exception cref="NullClientException"></exception>
        public void ValidateClientToNull(Client client)
        {
            if (client is null)
            {
                throw new NullClientException(new Exception());
            }
        }



        public void ValidateClient(Client client)
        {
            try
            {
                var _clientValidation = new ClientValidationException();
                var invalidClientException = new InvalidClientException(new Exception());

                _clientValidation.Validate(
                                 (rule: _clientValidation.IsInvalid(client.Id), parameter: nameof(Client.Id)),
                                 (rule: _clientValidation.IsInvalid(client.FirstName), parameter: nameof(Client.FirstName)),
                                 (rule: _clientValidation.IsInvalid(client.LastName), parameter: nameof(Client.LastName)),
                                 (rule: _clientValidation.IsInvalidEmail(client.Email), parameter: nameof(Client.Email))
                                 );

                invalidClientException.ThrowIfContainsErrors();
            }

            catch (ArgumentNullException argumentNullException)
            {
                Console.WriteLine($"{argumentNullException.Message}");
            }
            catch (InvalidClientException invalidClientException)
            {
                Console.WriteLine(invalidClientException.Message);

                foreach (DictionaryEntry entry in invalidClientException.Data)
                {
                    string errorSummary = ((List<string>)entry.Value).
                        Select((value) => value).
                        Aggregate((current, next) => current + " - " + next);
                    Console.WriteLine(entry.Key + " - " + errorSummary);
                }
            }
        }



    }
}

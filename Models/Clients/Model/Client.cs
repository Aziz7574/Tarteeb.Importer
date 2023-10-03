namespace Tarteeb.Importer.Models.Clients.Model
{
    internal class Client
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string Email { get; set; }
    }
}

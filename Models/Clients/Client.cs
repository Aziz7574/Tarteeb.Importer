﻿namespace Tarteeb.Importer.Models.Clients
{
    internal class Client
    {
        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public DateTimeOffset BirthDate { get; set; }

        public string Email { get; set; }

        public Guid GroupId { get; set; }
    }
}

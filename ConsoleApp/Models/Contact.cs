using ConsoleApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp.Models
{
    public class Contact : IContact
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PhoneNumber { get; set; } = null!;
        public string StreetName { get; set; } = null!;
        public string City { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Address => $"{StreetName}, {PostalCode} {City}";

    }
}

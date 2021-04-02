using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.api.Entities
{
    public class Contact
    {
        public Contact(string firstName, string lastName)
        {
            FirstName = firstName;
            LastName = lastName;
        }

        public Guid Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Company { get; set; }

        public string Email { get; set; }

        public string PhoneNumber { get; set; }
    }
}

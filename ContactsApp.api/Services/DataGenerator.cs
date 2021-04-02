using Bogus;
using ContactsApp.api.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.api.Services
{
    public class DataGenerator
    {
        public List<Entities.Contact> GenerateContacts( int quantity)
        {
            var result = new Faker<Entities.Contact>()
            .RuleFor(x => x.Id, f => Guid.NewGuid())
            .RuleFor(x => x.FirstName, f => f.Person.FirstName)
            .RuleFor(x => x.LastName, f => f.Person.LastName)
            .RuleFor(x => x.Company, f => f.Company.CompanyName())
            .RuleFor(x => x.Email, f => f.Person.Email)
            .RuleFor(x => x.PhoneNumber, f => f.Person.Phone)


            .Generate(quantity);


            return null;
        }


    }
}

using ContactsApp.api.Data;
using ContactsApp.api.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.api.Services
{
    public class ContactServices
    {
        private readonly DataContext _dataContext;

        public ContactServices(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public List<Contact> GetAllContactsFromDataBase()
        {

            var result = _dataContext.Contacts.ToList();

            return result;
        }


        public Contact CreateContact(Contact request)
        {
            var contactResponse = new Contact(request.FirstName, request.LastName);

            contactResponse.Company = request.Company;
            contactResponse.Email = request.Email;
            contactResponse.PhoneNumber = request.PhoneNumber;

            _dataContext.Contacts.Add(contactResponse);
            _dataContext.SaveChanges();

            return contactResponse;
        }

        public string UpdateContact(Contact request)
        {
            Contact entity = _dataContext.Contacts.Where(x => x.Id == request.Id).FirstOrDefault();
            if (entity == null)
                return "No existe ese Id.";

            var modifiedEntity = new Contact(entity.FirstName, entity.LastName)
            {
                Company = entity.Company,
                Email = entity.Email,
                PhoneNumber = entity.PhoneNumber,
            };

            _dataContext.Contacts.Update(modifiedEntity);
            _dataContext.SaveChanges();

            return "Datos modificados";
        }

        public string DeleteContact(Guid id)
        {
            var entity = _dataContext.Contacts.Where(x => x.Id == id).FirstOrDefault();

            if (entity == null)
                return "No existe ese Id.";

            _dataContext.Contacts.Remove(entity);
            _dataContext.SaveChanges();

            return "Se borró con exito.";
        }


        public List<Contact> GetContactsByCompany(string searchCompany)
        {
            var listContactsByCompany = _dataContext.Contacts
                .Where(x => x.FirstName.Contains(searchCompany))
                .Distinct()
                .ToList();
            return listContactsByCompany;
        }
    }
}

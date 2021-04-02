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

        public string CreateContact()
        {
            var generator = new DataGenerator();

            var contact = generator.GenerateContacts(1).FirstOrDefault();

            _dataContext.Contacts.Add(contact);
            _dataContext.SaveChanges();

            return "Contacto creado.";

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

        //
        public List<Contact> GetContactsByCompany()
        {
            var listaCbC = _dataContext.Contacts
               
              .OrderBy(x => x.LastName)             
              .ThenBy(x => x.FirstName)
              .ToList();
                
            return listaCbC;
        }
    }
}

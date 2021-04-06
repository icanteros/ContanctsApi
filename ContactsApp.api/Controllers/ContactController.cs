using ContactsApp.api.Data;
using ContactsApp.api.Entities;
using ContactsApp.api.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContactsApp.api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ContactController : ControllerBase
    {

        private readonly DataContext _dataContext;

        public ContactController(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
                
     
        [HttpGet]
        public List<Contact> GetAllContactsList()
        {
            var service = new ContactServices(_dataContext);
            var result = service.GetAllContactsFromDataBase();

            return result;
        }

        [HttpPost]
        public Contact Post([FromBody] Contact request)
        {
            var service = new ContactServices(_dataContext);
            var contact = service.CreateContact(request);

            return contact;
        }

        [HttpPut]
        public string UpdatePerson([FromBody] Contact request)
        {
            var service = new ContactServices(_dataContext);

            var result = service.UpdateContact(request);

            return result;
        }

        [HttpDelete]
        public string DeleteContact(Guid id)
        {
            var service = new ContactServices(_dataContext);

            var result = service.DeleteContact(id);

            return result;
        }

        //intento de obtener una lista de contactos por empresa (te debo la paginación)
        [HttpGet("get-by-cc")]
        public List<Contact> GetContactsByCompany(string searchCompany)
        {
            ContactServices service = new ContactServices(_dataContext);

            List<Contact> result = service.GetContactsByCompany(searchCompany);

            return result;
        }
        


    }
}

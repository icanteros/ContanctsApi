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
    public class ContactControllers
    {

        [HttpGet]
        public List<Contact> GetAllContactsList()
        {
            var service = new ContactServices();
            var result = service.GetAllContactsFromDataBase();

            return result;
        }

    }
}

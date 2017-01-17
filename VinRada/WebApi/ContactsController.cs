using BLL;
using BLL.DTO;
using BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using VinRada.ViewModel;

namespace VinRada.WebApi
{
    public class ContactsController : ApiController
    {
        IContactsService contactsService;
        IMappingService mappingService;
        public ContactsController(IContactsService contactsService, IMappingService mappingService)
        {
            this.contactsService = contactsService;
            this.mappingService = mappingService;
        }

        [HttpPut]
        [ActionName("UpdateContacts")]
        public void UpdateContacts(ContactsViewModel model)
        {
            ContactDTO dto = mappingService.Map<ContactsViewModel, ContactDTO>(model);
            contactsService.UpdateContacts(dto);
        }

        [HttpGet]
        [ActionName("GetContacts")]
        public ContactsViewModel GetContacts()
        {
            ContactDTO dto = contactsService.GetContacts();
            ContactsViewModel model = mappingService.Map<ContactDTO, ContactsViewModel>(dto);
            return model;
        }
    }
}

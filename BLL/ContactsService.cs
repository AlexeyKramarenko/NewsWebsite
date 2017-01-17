using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ContactsService : IContactsService
    {
        IUnitOfWork Database;
        IMappingService mappingService;
        public ContactsService(IUnitOfWork Database, IMappingService mappingService)
        {
            this.Database = Database;
            this.mappingService = mappingService;
        }


        public ContactDTO GetContacts()
        {
            Contact contact = Database.Contacts.GetContacts();
            ContactDTO _contact = mappingService.Map<Contact, ContactDTO>(contact);
            return _contact;
        }

        public void UpdateContacts(ContactDTO contact)
        {
            Contact _contact = mappingService.Map<ContactDTO, Contact>(contact);
            Database.Contacts.SaveContacts(_contact);
            Database.Save();
        }
    }
}

using BLL;
using BLL.DTO;
using BLL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VinRada.ViewModel;

namespace VinRada
{
    public partial class Contacts : BasePage
    {
        [Inject]
        public IContactsService ContactsService { get; set; }
        [Inject]
        public IMappingService MappingService { get; set; }


        public ContactsViewModel GetContacts()
        {
            ContactDTO contacts = ContactsService.GetContacts();
            ContactsViewModel vm = MappingService.Map<ContactDTO, ContactsViewModel>(contacts);
            return vm;
        }
    }
}
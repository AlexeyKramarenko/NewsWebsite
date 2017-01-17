using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ContactsRepository : IContactsRepository
    {
        DBContext db;

        public ContactsRepository(DBContext db)
        {
            this.db = db;
        }
        public Contact GetContacts()
        {
            return db.Contacts.FirstOrDefault();
        }
        public void SaveContacts(Contact contact)
        {
            var obj = db.Contacts.FirstOrDefault();

            if (obj != null)
            {
                obj.Address = contact.Address;
                obj.Email = contact.Email;
                obj.PhoneNumber = contact.PhoneNumber;
            }
            else
                db.Entry(contact).State = System.Data.Entity.EntityState.Added;
        }
    }
}

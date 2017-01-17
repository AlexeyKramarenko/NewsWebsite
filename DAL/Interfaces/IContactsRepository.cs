using System.Collections.Generic;
using DAL.POCO;

namespace DAL
{
    public interface IContactsRepository
    {
        Contact GetContacts();

        void SaveContacts(Contact contact);
    }
}
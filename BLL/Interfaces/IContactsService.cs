

using BLL.DTO;

namespace BLL
{
    public interface IContactsService
    {
        ContactDTO GetContacts();
        void UpdateContacts(ContactDTO contact);
    }
}
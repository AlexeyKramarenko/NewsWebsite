
using BLL.DTO;
using DAL.POCO;

namespace BLL
{
    public interface IUserService
    {
        User GetUser(string username, string password);
    }
}
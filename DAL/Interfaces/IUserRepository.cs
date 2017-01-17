using DAL.POCO;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;

namespace DAL
{
    public interface IUserRepository
    {
        User GetUser(string username, string password);       
    }
}
using DAL;
using DAL.POCO;


namespace BLL
{
    public class UserService : IUserService
    {

        IUnitOfWork Database;

        public UserService(IUnitOfWork Database)
        {
            this.Database = Database;
        }
        public User GetUser(string username, string password)
        {
            return Database.Users.GetUser(username, password);
        }

    }
}

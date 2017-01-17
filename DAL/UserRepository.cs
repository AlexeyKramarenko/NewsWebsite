using DAL.POCO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.Owin.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserRepository : IUserRepository
    {
        UserStore<IdentityUser> userStore;
        UserManager<IdentityUser> userManager;
        RoleStore<IdentityRole> roleStore;
        RoleManager<IdentityRole> roleManager;
        DBContext db;
        public UserRepository(DBContext db)
        {
            this.db = db;
            userStore = new UserStore<IdentityUser>(db);
            userManager = new UserManager<IdentityUser>(userStore);
            roleStore = new RoleStore<IdentityRole>(db);
            roleManager = new RoleManager<IdentityRole>(roleStore);
        }
        public User GetUser(string username, string password)
        {
            var user = db.Users.Include("Role").FirstOrDefault(u => u.Name == username && u.Password == password);
            return user;
        }
      

    }
}

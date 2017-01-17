using DAL.POCO;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class DBContext : DbContext
    {
        public DBContext() : base("vinradaDB")
        {
            Database.SetInitializer(new DBInitializer());
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Article> Articles { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<MainPhoto> MainPhotos { get; set; }
        public DbSet<NewsEvent> NewsEvents { get; set; }
        public DbSet<Link> NewsLinks { get; set; }
        public DbSet<ImagesContent> ImagesContent { get; set; }
    }


    public class DBInitializer : DropCreateDatabaseIfModelChanges<DBContext>

    //public class DBInitializer : DropCreateDatabaseAlways<DBContext>
    {
        protected override void Seed(DBContext db)
        {
            db.Roles.Add(new Role { RoleId = 1, Name = "admin" });
            db.Roles.Add(new Role { RoleId = 2, Name = "user" });

            db.Users.Add(new User
            {
                Name = "admin",
                Password = "123123",
                UserId = 1,
                RoleId = 1
            });
            db.Users.Add(new User
            {
                Name = "tom",
                Password = "123456",
                UserId = 2,
                RoleId = 2
            });
            base.Seed(db);

        }
    }
}

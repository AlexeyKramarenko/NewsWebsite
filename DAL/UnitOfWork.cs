using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UnitOfWork : IUnitOfWork
    {
        DBContext db;
        IArticlesRepository articlesRepository = null;
        IContactsRepository contactsRepository = null;
        IMainInfoRepository mainInfoRepository = null;
        INewsRepository newsRepository = null;
        IUserRepository userRepository = null;

        public UnitOfWork()
        {
            db = new DBContext();
        }

        public IArticlesRepository Articles
        {
            get
            {
                if (articlesRepository == null)
                    articlesRepository = new ArticlesRepository(db);

                return articlesRepository;
            }
        }
        public IContactsRepository Contacts
        {
            get
            {
                if (contactsRepository == null)
                    contactsRepository = new ContactsRepository(db);

                return contactsRepository;
            }
        }
        public IMainInfoRepository MainInfo
        {
            get
            {
                if (mainInfoRepository == null)
                    mainInfoRepository = new MainInfoRepository(db);

                return mainInfoRepository;
            }
        }

        public INewsRepository News
        {
            get
            {
                if (newsRepository == null)
                    newsRepository = new NewsRepository(db);

                return newsRepository;
            }
        } 

        public IUserRepository Users
        {
            get
            {
                if (userRepository == null)
                    userRepository = new UserRepository(db);

                return userRepository;               
            }
        }
        private bool disposed = false;
        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public int Save()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                StringBuilder sb = new StringBuilder();

                foreach (var failure in ex.EntityValidationErrors)
                {
                    sb.AppendFormat("{0} failed validation\n", failure.Entry.Entity.GetType());
                    foreach (var error in failure.ValidationErrors)
                    {
                        sb.AppendFormat("- {0} : {1}", error.PropertyName, error.ErrorMessage);
                        sb.AppendLine();
                    }
                }

                throw new DbEntityValidationException(
                    "Entity Validation Failed - errors follow:\n" +
                    sb.ToString(), ex
                );
            }
        }
    }
}

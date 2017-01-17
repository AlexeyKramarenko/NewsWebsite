namespace DAL
{
    public interface IUnitOfWork
    {
        IArticlesRepository Articles { get; }
        IContactsRepository Contacts { get; }
        IMainInfoRepository MainInfo { get; }
        INewsRepository News { get; }
        IUserRepository Users { get; }

        void Dispose();
        void Dispose(bool disposing);
        int Save();
    }
}
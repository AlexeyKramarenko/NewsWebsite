using System.Collections.Generic;
using DAL.POCO;

namespace DAL
{
    public interface IMainInfoRepository
    {
        List<MainPhoto> GetMainPhotos();
        void AddMainPhoto(MainPhoto mainPhoto);
        void UpdateMainPhoto(MainPhoto mainPhoto);
        void DeleteMainPhoto(MainPhoto mainPhoto);
        MainPhoto GetImageById(int id);
        void DeletePhotos(int[] ids);
    }
}
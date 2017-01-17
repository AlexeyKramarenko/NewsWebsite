using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MainInfoRepository : IMainInfoRepository
    {
        DBContext db;
        public MainInfoRepository(DBContext db)
        {
            this.db = db;
        }

        public List<MainPhoto> GetMainPhotos()
        {
            return db.MainPhotos.ToList();
        }

        public void AddMainPhoto(MainPhoto mainPhoto)
        {
            db.Entry(mainPhoto).State = System.Data.Entity.EntityState.Added;
        }

        public void UpdateMainPhoto(MainPhoto mainPhoto)
        {
            db.Entry(mainPhoto).State = System.Data.Entity.EntityState.Modified;
        }

        public void DeleteMainPhoto(MainPhoto mainPhoto)
        {
            db.Entry(mainPhoto).State = System.Data.Entity.EntityState.Deleted;
        }

        public MainPhoto GetImageById(int id)
        {
            MainPhoto photo = db.MainPhotos.Find(id);
            return photo;
        }

        public void DeletePhotos(int[] ids)
        {           

            for (int i = 0; i < ids.Length; i++)
            {
                int photoId = ids[i];

                MainPhoto photoObj = db.MainPhotos.Find(photoId);

                if (photoObj != null)
                    db.Entry(photoObj).State = System.Data.Entity.EntityState.Deleted;
            }
        }
    }
}

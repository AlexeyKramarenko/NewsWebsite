using BLL.DTO;
using BLL.Interfaces;
using DAL;
using DAL.POCO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class MainInfoService : IMainInfoService
    {
        IUnitOfWork Database;
        IMappingService mappingService;
        public MainInfoService(IUnitOfWork Database, IMappingService mappingService)
        {
            this.Database = Database;
            this.mappingService = mappingService;
        }

        public void AddMainPhoto(MainPhotoDTO mainPhoto)
        {
            var photo = mappingService.Map<MainPhotoDTO, MainPhoto>(mainPhoto);
            Database.MainInfo.AddMainPhoto(photo);
            Database.Save();
        }

        public void AddMainPhotos(List<MainPhotoDTO> mainPhotos)
        {
            foreach (var photo in mainPhotos)
                Database.MainInfo.AddMainPhoto(mappingService.Map<MainPhotoDTO, MainPhoto>(photo));

            Database.Save();
        }

        public void DeleteMainPhoto(MainPhotoDTO mainPhoto)
        {
            var photo = mappingService.Map<MainPhotoDTO, MainPhoto>(mainPhoto);
            Database.MainInfo.DeleteMainPhoto(photo);
            Database.Save();
        }

        public void DeleteMainPhotos(List<MainPhotoDTO> mainPhotos)
        {
            foreach (var photo in mainPhotos)
                Database.MainInfo.DeleteMainPhoto(mappingService.Map<MainPhotoDTO, MainPhoto>(photo));

            Database.Save();
        }

        public void DeletePhotos(int[] ids)
        {
            Database.MainInfo.DeletePhotos(ids);
            Database.Save();
        }

        public MainPhotoDTO GetImageById(int id)
        {
            MainPhoto photo = Database.MainInfo.GetImageById(id);
            MainPhotoDTO dto = mappingService.Map<MainPhoto, MainPhotoDTO>(photo);
            return dto;
        }

        public List<MainPhotoDTO> GetMainPhotos()
        {
            List<MainPhoto> mainPhotos = Database.MainInfo.GetMainPhotos();
            List<MainPhotoDTO> mainPhotosDto = mainPhotos.Select(a => mappingService.Map<MainPhoto, MainPhotoDTO>(a)).ToList();
            return mainPhotosDto;
        }

        public void UpdateMainPhoto(MainPhotoDTO mainPhoto)
        {
            MainPhoto photo = mappingService.Map<MainPhotoDTO, MainPhoto>(mainPhoto);
            Database.MainInfo.UpdateMainPhoto(photo);
            Database.Save();
        }
    }
}

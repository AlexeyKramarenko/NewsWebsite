using System.Collections.Generic;

using BLL.DTO;

namespace BLL
{
    public interface IMainInfoService
    {
        List<MainPhotoDTO> GetMainPhotos();
        void AddMainPhoto(MainPhotoDTO mainPhoto);
        void AddMainPhotos(List<MainPhotoDTO> mainPhoto);
        void UpdateMainPhoto(MainPhotoDTO mainPhoto);
        void DeleteMainPhoto(MainPhotoDTO mainPhoto);
        void DeleteMainPhotos(List<MainPhotoDTO> mainPhotos);
        MainPhotoDTO GetImageById(int id);
        void DeletePhotos(int[] ids);
    }
}
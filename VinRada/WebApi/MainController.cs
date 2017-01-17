using BLL;
using BLL.DTO;
using BLL.Interfaces;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;
using System.Web.UI.WebControls;
using VinRada.ViewModel;

namespace VinRada.WebApi
{
    public class MainController : ApiController
    {
        IMainInfoService mainInfoService;
        IMappingService mappingService;
        string virtualTempImageDir = "~/Images/gallery/temp/";

        public MainController(IMainInfoService mainInfoService, IMappingService mappingService)
        {
            this.mainInfoService = mainInfoService;
            this.mappingService = mappingService;
        }
        [HttpGet]
        [ActionName("GetMainPhotos")]
        public List<MainPageViewModel> GetMainPhotos()
        {
            List<MainPhotoDTO> photos = mainInfoService.GetMainPhotos();
            List<MainPageViewModel> vm = photos.Select(a => mappingService.Map<MainPhotoDTO, MainPageViewModel>(a)).ToList();
            for (int i = 0; i < vm.Count; i++)
            {
                string rootFolder = "Images";
                int index = vm[i].Image.IndexOf(rootFolder);
                string virtualPath = vm[i].Image.Remove(0, index);
                vm[i].Image = Path.Combine("../", virtualPath);
            }
            return vm;
        }
        [HttpPost]
        [ActionName("AddMainPhoto")]
        public void AddMainPhoto(MainPageViewModel model)
        {
            MainPhotoDTO dto = mappingService.Map<MainPageViewModel, MainPhotoDTO>(model);
            mainInfoService.AddMainPhoto(dto);
        }
        

        [HttpPost]
        [ActionName("UploadImage")]
        public string UploadImage()
        {
            string[] formats = new string[] { "image/jpeg", "image/png" };

            HttpFileCollection files = HttpContext.Current.Request.Files;

            if (files.Count > 0)
            {
                HttpPostedFile file = files[0];

                if (file != null)
                {
                    if (formats.Contains(file.ContentType))
                    {
                        string fileName = Guid.NewGuid().ToString() + "_" + file.FileName;
                        string tempImagePath = HttpContext.Current.Server.MapPath(virtualTempImageDir) + fileName;
                        string imageUrl = virtualTempImageDir.Replace("~", "") + fileName;
                        file.SaveAs(tempImagePath);
                        return imageUrl;
                    }
                }
            }
            return null;
        }

        [HttpPost]
        [ActionName("SaveImages")]
        public void SaveImages(string[] imageUrls)
        {
            var list = new List<MainPhotoDTO>();

            #region Move files from temp to destination directory
            string virtualTargetImageDir = "~/Images/gallery/largeImages/";
            string targetDir = HttpContext.Current.Server.MapPath(virtualTargetImageDir);

            for (int i = 0; i < imageUrls.Length; i++)
            {
                string sourcePath = HttpContext.Current.Server.MapPath(imageUrls[i]);
                string targetPath = targetDir + Path.GetFileName(sourcePath);
                Directory.Move(sourcePath, targetPath);

                list.Add(new MainPhotoDTO
                {
                    Image = virtualTargetImageDir.Replace("~/", "") + Path.GetFileName(sourcePath)
                });
            }
            #endregion

            #region Clear temp directory
            string sourceDirectory = HttpContext.Current.Server.MapPath(virtualTempImageDir);
            var di = new DirectoryInfo(sourceDirectory);
            foreach (FileInfo file in di.GetFiles())
            {
                file.Delete();
            }
            #endregion

            // Save paths to database
            mainInfoService.AddMainPhotos(list);
        }
        [HttpDelete]
        [ActionName("DeletePhotos")]
        public void DeletePhotos([FromBody] JToken json)
        {
            var dictonary = json.ToObject<Dictionary<string, int[]>>();
            int[] ids = dictonary["jsonbody"];

            if (ids != null)
                mainInfoService.DeletePhotos(ids);
        }
    }
}

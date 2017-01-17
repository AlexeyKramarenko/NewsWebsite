using BLL;
using BLL.DTO;
using BLL.Interfaces;
using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using VinRada.ViewModel;

namespace VinRada
{
    public partial class Main : BasePage
    {
        [Inject]
        public IMainInfoService MainInfoService { get; set; }
        [Inject]
        public IMappingService MappingService { get; set; }


        public List<MainPageViewModel> GetMainPhotos()
        {
            List<MainPhotoDTO> photos = MainInfoService.GetMainPhotos();
            List<MainPageViewModel> photosVM = photos.Select(a => MappingService.Map<MainPhotoDTO, MainPageViewModel>(a)).ToList();
            return photosVM;
        }
    }
}
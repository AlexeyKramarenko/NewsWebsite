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
    public partial class News : BasePage
    {
        [Inject]
        public INewsService NewsService { get; set; }

        [Inject]
        public IMappingService MappingService { get; set; }


        public List<LinkViewModel> GetNewsLinks(int maximumRows, int startRowIndex, out int totalRowCount)
        {
            List<LinkDTO> links = NewsService.GetLinks(startRowIndex, maximumRows, out totalRowCount);

            List<LinkViewModel> linksVM = links.Select(a => MappingService.Map<LinkDTO, LinkViewModel>(a)).ToList();
            
            return linksVM;
        }
    }
}
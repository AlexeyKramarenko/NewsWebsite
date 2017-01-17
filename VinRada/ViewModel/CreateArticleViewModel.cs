using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace VinRada.ViewModel
{
    public class CreateArticleViewModel
    {
        //public CreateArticleViewModel()
        //{
        //    //must be initialized otherwise this property in json will be null
        //    //ImagesContent = new ImagesContentViewModel[];
        //}
        public string Title { get; set; }
        public string SelectedCategory { get; set; }
        public  ImagesContentViewModel[] ImagesContent { get; set; }
        public string TextContent { get; set; }        
        public string[] Categories { get; set; }

    }
}

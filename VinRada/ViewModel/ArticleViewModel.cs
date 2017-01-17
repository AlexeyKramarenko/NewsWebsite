using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;

namespace VinRada.ViewModel
{
    public class ArticleViewModel
    {
        public string ID { get; set; }
        public string Title { get; set; }        
        public string Category { get; set; }
        public List<ImagesContentViewModel> ImagesContent { get; set; }
        public string TextContent { get; set; }        
    }
}

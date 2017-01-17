using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
    public class ArticleDTO
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public List<ImagesContentDTO> ImagesContent { get; set; }
        public string TextContent { get; set; }
    }
}

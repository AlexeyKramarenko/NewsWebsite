using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.POCO
{
    public class Article
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string Category { get; set; }
        public List<ImagesContent> ImagesContent  { get; set; }
        public string TextContent  { get; set; }
    }
}

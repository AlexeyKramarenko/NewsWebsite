using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.POCO
{
    public class ImagesContent
    {
        [Key]
        public int ID { get; set; }
        public string Description { get; set; }
        public string ImageSource { get; set; }  


        [ForeignKey("Article")]
        public int ArticleID { get; set; }
        public Article Article { get; set; }

    }
}
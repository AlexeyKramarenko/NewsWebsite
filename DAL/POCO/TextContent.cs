using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DAL.POCO
{
    public class TextContent
    {
        [Key]
        public int ID { get; set; }
        public string Title { get; set; }
        public string ArticleContent { get; set; }


        [ForeignKey("Article")]
        public int ArticleID { get; set; }
        public Article Article { get; set; }
    }
}
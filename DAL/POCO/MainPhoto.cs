using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.POCO
{
    public class MainPhoto
    {
        [Key]
        public int ID { get; set; }
        public string Image { get; set; }
        public string ThumbnailImage { get; set; }
    }
}

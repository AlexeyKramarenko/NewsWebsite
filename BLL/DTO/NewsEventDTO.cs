using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.DTO
{
   public class NewsEventDTO
    {
        public int NewsID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }        
        public DateTime Date { get; set; }
    }
}

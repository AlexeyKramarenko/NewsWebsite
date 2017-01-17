using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VinRada.ViewModel
{
    [Serializable]
    public class ImagesContentViewModel
    {
        public string ImageSource { get; set; }
        public string Description { get; set; }

        public ImagesContentViewModel() { }
        public ImagesContentViewModel(string imageSource, string description)
        {
            this.ImageSource = imageSource;
            this.Description = description;
        }
    }
}

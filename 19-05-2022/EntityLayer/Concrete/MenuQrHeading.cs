using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class MenuQrHeading
    {

        [Key]
        public int MenuQrHeadingID { get; set; }

        public string HeadingName { get; set; }

        public string HeadingImage { get; set; }

        public string FirstContent { get; set; }
        public string SecondaryContent { get; set; }

        public string productPrice { get; set; }

        public int MenuQrCategoryID { get; set; }
        public virtual MenuQrCategory MenuQrCategory { get; set; }

       
    }
}

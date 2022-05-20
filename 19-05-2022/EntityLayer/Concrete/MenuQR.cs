using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class MenuQR
    {
        [Key]
        public int MenuQRID { get; set; }

        public string ınstagramlink { get; set; }
        public string facebooklink { get; set; }
        public string twitterlink { get; set; }
        public string contactNumber { get; set; }
        public string contactAddres { get; set; }


        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}

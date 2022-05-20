using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class MenuQrCategory
    {

        [Key]
        public int MenuQrCategoryID { get; set; }

        public string CategoryName { get; set; }

        public string CategoryImage { get; set; }


        public int UserID { get; set; }
        public virtual User User { get; set; }

       
        public ICollection<MenuQrHeading> menuQrHeadings { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class PetQR
    {
        [Key]
        public int PetQRID { get; set; }
        public String PetOwnerName { get; set; }
        public String PetOwnerSurName { get; set; }
        public string PetOwnerPhone { get; set; }

       

        public String PetName { get; set; }    
        public String PetImage { get; set; }    
        public int PetAge { get; set; }
        public string PetWarning { get; set; }
        public string PetWarning2 { get; set; }
        public string SpecialNote { get; set; }

        public int UserID { get; set; }
        public virtual User User { get; set; }
    }
}

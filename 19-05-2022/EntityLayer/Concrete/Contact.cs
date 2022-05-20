using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class Contact
    {
        [Key]
        public int ContactID { get; set; }

        public string Subjet { get; set; }
        public string Content { get; set; }

        public int UserID { get; set; } // NEYİNİ KULLANICAM
        public virtual User User { get; set; }  // TANIYORUM HERŞEYİNİ

    }
}

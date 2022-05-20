using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
   public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserSurname { get; set; }
        public string PhoneNumber { get; set; }
        public string UserSystemName { get; set; }
        public string UserPasswordOld { get; set; }
        public string UserPassword { get; set; }
        public string UserCrypt { get; set; }
        public string UserImage { get; set; }
        public string UserHash { get; set; }
        public string UserRole { get; set; }


        public ICollection<PetQR> petQRs { get; set; }
        public ICollection<MenuQR> MenuQRs { get; set; }
        public ICollection<Contact> contacts { get; set; } //BENİ TANISIN CONTACT
    }
}

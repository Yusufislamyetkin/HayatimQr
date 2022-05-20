using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Concrete
{
   public  class Context : DbContext
    {

        public DbSet<User> Users { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<PetQR> PetQRs { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        //Menu
        public DbSet<MenuQR> MenuQRs { get; set; }
        public DbSet<MenuQrHeading> MenuQrHeadings { get; set; }
        public DbSet<MenuQrCategory> MenuQrCategories { get; set; }

    }
}

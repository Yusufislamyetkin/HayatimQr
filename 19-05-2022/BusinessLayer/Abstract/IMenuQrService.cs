using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMenuQrService
    {
        void AddValue(MenuQR p);
        MenuQR GetByID(int id);
        void MenuQRDelete(MenuQR MenuQR);
        void MenuQRUpdate(MenuQR MenuQR);
    }
}

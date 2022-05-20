using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMenuQrHeadingService
    {
        void AddValue(MenuQrHeading p);
        MenuQrHeading GetByID(int id);
        void MenuQrHeadingDelete(MenuQrHeading MenuQrHeading);
        void MenuQrHeadingUpdate(MenuQrHeading MenuQrHeading);
    }
}

using BusinessLayer.Abstract;
using DataAccesLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Conctrete
{
    public class MenuQrManager : IMenuQrService
    {
        IMenuQrDal _menuQrDal;

        public MenuQrManager(IMenuQrDal menuQrDal)
        {
            _menuQrDal = menuQrDal;
        }

        public void AddValue(MenuQR p)
        {
            _menuQrDal.Insert(p);
        }

        public MenuQR GetByID(int id)
        {
            throw new NotImplementedException();
        }

        public void MenuQRDelete(MenuQR MenuQR)
        {
            _menuQrDal.Delete(MenuQR);
        }

        public void MenuQRUpdate(MenuQR MenuQR)
        {
            _menuQrDal.Update(MenuQR);
        }
    }
}

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
    public class MenuQrHeadingManager : IMenuQrHeadingService
    {
        IMenuQrHeadingDal _menuQrHeadingDal;

        public MenuQrHeadingManager(IMenuQrHeadingDal menuQrHeadingDal)
        {
            _menuQrHeadingDal = menuQrHeadingDal;
        }

        public void AddValue(MenuQrHeading p)
        {
            _menuQrHeadingDal.Insert(p);
        }

        public MenuQrHeading GetByID(int id)
        {
           return _menuQrHeadingDal.Get(x => x.MenuQrHeadingID == id);
        }

        public List<MenuQrHeading> GetByIDListWithCat(int id)
        {
           return  _menuQrHeadingDal.WhrList(x => x.MenuQrCategoryID == id);
        }

        public void MenuQrHeadingDelete(MenuQrHeading MenuQrHeading)
        {
            _menuQrHeadingDal.Delete(MenuQrHeading);
        }

        public void MenuQrHeadingUpdate(MenuQrHeading MenuQrHeading)
        {
            _menuQrHeadingDal.UpdateNew(MenuQrHeading,MenuQrHeading.MenuQrHeadingID);
        }
    }
}

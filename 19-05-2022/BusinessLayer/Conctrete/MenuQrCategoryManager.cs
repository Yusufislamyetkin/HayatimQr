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
    public class MenuQrCategoryManager : IMenuQrCategoryService
    {
        IMenuQrCategoryDal _menuQrCategoryDal;

        public MenuQrCategoryManager(IMenuQrCategoryDal menuQrCategoryDal)
        {
            _menuQrCategoryDal = menuQrCategoryDal;
        }

        public void AddValue(MenuQrCategory p)
        {
            _menuQrCategoryDal.Insert(p);
        }

        public MenuQrCategory GetByID(int id)
        {
            return _menuQrCategoryDal.Get(x => x.MenuQrCategoryID == id);
        }
        public List<MenuQrCategory> GetByUserID(int? id)
        {
           return _menuQrCategoryDal.WhrList(x => x.UserID == id);
        }
        public List<MenuQrCategory> GetByUserHash(string HashText)
        {
            return _menuQrCategoryDal.WhrList(x => x.User.UserHash == HashText);
        }


        public void MenuQrCategoryDelete(MenuQrCategory MenuQrCategory)
        {
            _menuQrCategoryDal.Delete(MenuQrCategory);
        }

        public void MenuQrCategoryUpdate(MenuQrCategory MenuQrCategory)
        {
            _menuQrCategoryDal.Update(MenuQrCategory);
        }

        public void MenuQrCategoryNewUpdate(MenuQrCategory MenuQrCategory,int id)
        {
            _menuQrCategoryDal.UpdateNew(MenuQrCategory,id);
        }
    }
}

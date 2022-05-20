using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IMenuQrCategoryService
    {
        void AddValue(MenuQrCategory p);
        MenuQrCategory GetByID(int id);
        List<MenuQrCategory> GetByUserID(int? id);
        void MenuQrCategoryDelete(MenuQrCategory MenuQrCategory);
        void MenuQrCategoryUpdate(MenuQrCategory MenuQrCategory);
    }
}

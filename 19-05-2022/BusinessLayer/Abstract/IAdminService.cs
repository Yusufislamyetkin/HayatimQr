using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IAdminService
    {
        void AddValue(Admin Admin);
        Admin GetByID(int id);

        void Delete(Admin Admin);
        void Update(Admin Admin);
    }
}

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
    public class AdminManager : IAdminService
    {
        IAdminDal _adminDal;

        public AdminManager(IAdminDal adminDal)
        {
            _adminDal = adminDal;
        }

        public void AddValue(Admin Admin)
        {
            _adminDal.Insert(Admin);
        }

        public void Delete(Admin Admin)
        {
            _adminDal.Delete(Admin);
        }

        public Admin GetByID(int id)
        {
           return _adminDal.Get(x => x.AdminID == id);
        }
        public Admin GetBySession(Admin admin)
        {
            return _adminDal.Get(X => X.AdminSystemName == admin.AdminSystemName && X.AdminPassword == admin.AdminPassword);
        }
        public void Update(Admin Admin)
        {
            _adminDal.Update(Admin);
        }
    }
}

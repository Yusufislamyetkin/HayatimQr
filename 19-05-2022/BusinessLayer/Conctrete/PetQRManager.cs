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
    public class PetQRManager : IPetQRService
    {
        IPetQRDal _ıpetQRDal;

        public PetQRManager(IPetQRDal ıpetQRDal)
        {
            _ıpetQRDal = ıpetQRDal;
        }

        public void AddValue(PetQR p)
        {
            _ıpetQRDal.Insert(p);
        }

        public PetQR GetByID(int id)
        {
            return _ıpetQRDal.Get(x => x.UserID == id);
        }

        public PetQR GetByIDHash(string id)
        {
            return _ıpetQRDal.Get(x => x.User.UserHash == id);
        }

        public void PetQRDelete(PetQR PetQR)
        {
            _ıpetQRDal.Delete(PetQR);
        }

        public void PetQRUpdate(PetQR PetQR)
        {
            _ıpetQRDal.Update(PetQR);
        }
    }
}

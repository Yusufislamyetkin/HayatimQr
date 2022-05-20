using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
   public interface IPetQRService
    {
      
        void AddValue(PetQR p);
        PetQR GetByID(int id);
        void PetQRDelete(PetQR PetQR);
        void PetQRUpdate(PetQR PetQR);
    }
}

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    interface IContactService
    {
        void AddValue(Contact Contact);
        Contact GetByID(int id);
       
        void Delete(Contact Contact);
        void Update(Contact Contact);
    }
}

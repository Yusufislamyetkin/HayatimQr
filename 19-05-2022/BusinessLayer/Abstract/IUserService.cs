using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
  public  interface IUserService
    {
        void AddValue(User p);
        User GetByID(int id);
        User GetBySession(User user);
        void Delete(User User);
        void Update(User User);
    }
}

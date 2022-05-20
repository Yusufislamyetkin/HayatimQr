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
    public class UserManager : IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        public void AddValue(User p)
        {
            _userDal.Insert(p);
        }

        public void Delete(User User)
        {
            _userDal.Delete(User);
        }

        public User GetByID(int id)
        {
           return _userDal.Get(x => x.UserID == id);
        }

        public User GetBySession(User user)
        {
            return _userDal.Get(X => X.UserSystemName == user.UserSystemName && X.UserPassword == user.UserPassword);
        }
     

        public void Update(User User)
        {
            _userDal.UpdateNew(User,User.UserID);
        }



        // Bildiğimiz systemname kullanıcısına  ait tüm satırı getirecek metod

        public User GetSessionValue(string SystemName)
        {
            return _userDal.Get(x => x.UserSystemName == SystemName);
        } 
    }
}

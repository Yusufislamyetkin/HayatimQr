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
    public class ContactManager : IContactService
    {
        IContactDal _contactDal;

        public ContactManager(IContactDal contactDal)
        {
            _contactDal = contactDal;
        }

        public void AddValue(Contact Contact)
        {
            _contactDal.Insert(Contact);
        }

        public void Delete(Contact Contact)
        {
            _contactDal.Delete(Contact);
        }

        public Contact GetByID(int id)
        {
            return _contactDal.Get(x => x.ContactID == id);
        }

        public List<Contact> GetByUserID(int id)
        {
            return _contactDal.WhrList(x => x.UserID == id);
        }


        public void Update(Contact Contact)
        {
            _contactDal.Update(Contact);
        }
    }
}

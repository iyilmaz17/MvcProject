using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IContactService
    {
        List<Contact> GetList();
        Contact GetByID(int id);
        void ContactAdd(Contact contact);
        void ContactUpdate(Contact contact);
        void ContactDelete(Contact contact);

    }
}

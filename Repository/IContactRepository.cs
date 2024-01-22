using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contacts_app.Models;

namespace contacts_app.Repository
{
    public interface IContactRepository
    {
        ContactModel Add(ContactModel contact);
        ContactModel Update(ContactModel contact);
        ContactModel Delete(ContactModel contact);
        List<ContactModel> FindAll();
        ContactModel FindById(int id);
    }
}
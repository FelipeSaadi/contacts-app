using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using contacts_app.Data;
using contacts_app.Models;

namespace contacts_app.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly AppDbContext _appDbContext;
        public ContactRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public ContactModel Add(ContactModel contact)
        {
            _appDbContext.Contacts.Add(contact);
            _appDbContext.SaveChanges();
            return contact;
        }
    }
}
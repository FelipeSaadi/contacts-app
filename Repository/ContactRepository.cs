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

        public List<ContactModel> FindAll()
        {
            return _appDbContext.Contacts.ToList();
        }

        public ContactModel FindById(int id)
        {
            return _appDbContext.Contacts.FirstOrDefault(contact => contact.Id == id);
        }

        public ContactModel Update(ContactModel contact)
        {
            ContactModel contactDb = FindById(contact.Id);

            if(contactDb == null) {
                throw new Exception("Houve um erro na atualização do contato");
            }
            
            contactDb.Name = contact.Name;
            contactDb.Email = contact.Email;
            contactDb.Phone = contact.Phone;

            _appDbContext.Contacts.Update(contactDb);
            _appDbContext.SaveChanges();

            return contactDb;
        }

        public ContactModel Delete(ContactModel contact) {
            ContactModel contactDb = FindById(contact.Id);

            if(contactDb == null) {
                throw new Exception("Erro ao deletar o contato");
            } 

            _appDbContext.Contacts.Remove(contactDb);
            _appDbContext.SaveChanges();

            return contactDb;
        }
    }
}
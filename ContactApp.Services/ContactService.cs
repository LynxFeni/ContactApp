using System;
using System.Collections.Generic;
using ContactApp.Models;
using ContactApp.Repository;

namespace ContactApp.Services
{
    public class ContactService : IContactService
    {
        private IRepository<Contacts> contactRepository;
        private readonly ContactDBContext context;

        public ContactService(ContactDBContext context)
        {
            this.context = context;
            this.contactRepository = new Repository<Contacts>(context);
        }
        public void DeleteContact(int contactId)
        {
            Contacts contact = contactRepository.Get(contactId);
            contactRepository.Remove(contact);
            contactRepository.SaveChanges();
        }

        public Contacts GetContactById(int contactId)
        {
            return contactRepository.Get(contactId);
        }

        public IEnumerable<Contacts> GetContacts()
        {
            return contactRepository.GetAll();
        }

        public void InsertNewContactDetails(Contacts item)
        {
            contactRepository.Insert(item);
        }

        public void UpdateExistingContact(Contacts item)
        {
            contactRepository.Update(item);
        }
    }
}

using ContactApp.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContactApp.Services
{
    public interface IContactService
    {
        IEnumerable<Contacts> GetContacts();
        Contacts GetContactById(int contactId);
        void InsertNewContactDetails(Contacts item);
        void UpdateExistingContact(Contacts item);
        void DeleteContact(int contactId);
    }
}

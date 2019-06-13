using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ContactApp.Models;
using ContactApp.Repository;
using ContactApp.Services;
using ContactApp.WebApi.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactApp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsAPIController : ControllerBase
    {
        private readonly IContactService contactService;
        private readonly HostingEnvironment _hostingEnvironment;
        public ContactsAPIController()
        {
            var context = new ContactDBContext();
            this.contactService = new ContactService(context);
        }
        [EnableCors("CorsPolicy")]
        [HttpGet]
        [Route("Contacts")]
        public JsonResult Contacts()
        {
            List<ContactViewModel> model = new List<ContactViewModel>();
            contactService.GetContacts().ToList().ForEach(u =>
            {
                ContactViewModel contactModel = new ContactViewModel
                {
                    ContactId = u.ContactId,
                    FirstName = u.FirstName,
                    LastName = u.LastName,
                    Email = u.Email,
                    Phone = u.Phone

                };
                model.Add(contactModel);
            });
            return new JsonResult(model);
        }
        [EnableCors("CorsPolicy")]
        [HttpPost]
        [Route("SaveContact")]
        public void SaveContact(ContactViewModel model)
        {
            Contacts contactEntity = contactService.GetContactById(model.ContactId);
            if(contactEntity == null)
            {
                Contacts contact = new Contacts
                {
                    ContactId=model.ContactId,
                    FirstName=model.FirstName,
                    LastName=model.LastName,
                    Email=model.Email,
                    Phone=model.Phone
                };
                contactService.InsertNewContactDetails(contact);
            }
            else
            {
                contactEntity.FirstName = model.FirstName;
                contactEntity.LastName = model.LastName;
                contactEntity.Email = model.Email;
                contactEntity.Phone = model.Phone;
                contactService.UpdateExistingContact(contactEntity);
            }
          
        }
        [EnableCors("CorsPolicy")]
        [HttpDelete]
        [Route("DeleteContact/{contactId}")]

        public void DeleteContact(int contactId)
        {
            contactService.DeleteContact(contactId);
        }
        
    }
}
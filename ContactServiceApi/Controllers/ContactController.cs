using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Microsoft.AspNetCore.Mvc;
using UtilityLibrary.Interfaces;

namespace ContactServiceApi.Controllers;

[Route("[controller]")]
public class ContactController : ControllerBase
{
    private readonly ILogger<ContactController> _logger;

    public ContactController(ILogger<ContactController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IResponseInformation<Contact[]> ListContacts()
    {
       IResponseInformation<Contact[]> responseInformation = BLContact.ListContacts();
       return responseInformation;
    }

    [HttpPost]
    public IResponseInformation AddContact(Contact contact)
    {
        IResponseInformation responseInformation = BLContact.AddContact(contact);
        return responseInformation;
    }

    [HttpPut]
    public IResponseInformation<Contact> EditContact(Contact contact)
    {
        IResponseInformation<Contact> responseInformation = BLContact.EditContact(contact);
        return responseInformation;
    }

    [HttpDelete("{contactId}")]
    public IResponseInformation DeleteContact(int contactId)
    {
        IResponseInformation responseInformation = BLContact.DeleteContact(new Contact(){ ContactId = contactId});
        return responseInformation;
    }
}

using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using ContactServiceGRPC.Helpers;
using Grpc.Core;
using UtilityLibrary.Interfaces;

namespace ContactServiceGRPC.Services;

public class ContactService : ContactServiceGRPC.ContactService.ContactServiceBase
{
    private readonly ILogger<ContactService> _logger;
    public ContactService(ILogger<ContactService> logger)
    {
        _logger = logger;
    }

    public override Task<ListContactResponse> ListContact(ListContactRequest request, ServerCallContext context)
    {
        IResponseInformation<Contact[]> responseInformation = BLContact.ListContacts();

        ListContactResponse listContactResponse = new ListContactResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };

        if (listContactResponse.Success && responseInformation.ResultItem is not null)
        {
            foreach (var contact in responseInformation.ResultItem)
            {
                listContactResponse.ResultItem.Add(ConvertHelper.ConvertContactToContactModel(contact));
            }
        }
        return Task.FromResult(listContactResponse);
    }

    public override Task<AddContactResponse> AddContact(AddContactRequest request, ServerCallContext context)
    {
        Contact contact = ConvertHelper.ConvertContactModelToContact(request.ContactModel);

        IResponseInformation responseInformation = BLContact.AddContact(contact);

        AddContactResponse addContactResponse = new AddContactResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(addContactResponse);
    }

    public override Task<EditContactResponse> EditContact(EditContactRequest request, ServerCallContext context)
    {
        Contact contact = ConvertHelper.ConvertContactModelToContact(request.ContactModel);

        IResponseInformation<Contact> responseInformation = BLContact.EditContact(contact);

        EditContactResponse editContactResponse = new EditContactResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(editContactResponse);
    }

    public override Task<DeleteContactResponse> DeleteContact(DeleteContactRequest request, ServerCallContext context)
    {
        Contact contact = ConvertHelper.ConvertContactModelToContact(request.ContactModel);

        IResponseInformation responseInformation = BLContact.DeleteContact(contact);

        DeleteContactResponse deleteContactResponse = new DeleteContactResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(deleteContactResponse);
    }
}
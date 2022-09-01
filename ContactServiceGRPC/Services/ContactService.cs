using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using ContactServiceGRPC.Helpers;
using Grpc.Core;
using UtilityLibrary.Interfaces;

namespace ContactServiceGRPC.Services;

public class ContactService: ContactServiceGRPC.ContactService.ContactServiceBase
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
}
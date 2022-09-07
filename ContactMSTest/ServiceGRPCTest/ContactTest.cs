using System.Linq;
using ContactServiceGRPC;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;
using Grpc.Net.Client;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactMSTest.ServiceGRPCTest;

[TestClass]
public class ContactTest
{
    private ContactModel contactModel = new ContactModel();

    //TODO: Implement transactions
    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    {

    }

    [ClassCleanup()]
    public static void ClassCleanup()
    {

    }

    [TestInitialize]
    public void MethodInit()
    {
        //Generate new random data person for each method
        Person person = RandomData.GeneratePerson<Person>();
        contactModel.Names = person.FirstName;
        contactModel.LastNames = person.LastName;
        contactModel.Pseudonymous = RandomData.GenerateWord(50);
        contactModel.Email = person.Email;
        contactModel.PhoneNumber = person.CellPhone;
        contactModel.Country = person.Country;
        contactModel.StreetDirection1 = person.Address1;
        contactModel.StreetDirection2 = person.Address2;
        contactModel.PostalCode = person.PostalCode;
        contactModel.City = person.City;
        contactModel.Birthday = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(person.BornOn.DateTime);
    }

    [TestMethod]
    public void ListContactTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var contactServiceClient = new ContactService.ContactServiceClient(channel);
        ListContactResponse listContactResponse = contactServiceClient.ListContact(new ListContactRequest());

        Assert.IsTrue(listContactResponse.Success, listContactResponse.Message);
    }

    [TestMethod]
    public void AddContactTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var contactServiceClient = new ContactService.ContactServiceClient(channel);
        AddContactRequest addContactRequest = new AddContactRequest();
        addContactRequest.ContactModel = contactModel;
        AddContactResponse addContactResponse = contactServiceClient.AddContact(addContactRequest);

        Assert.IsTrue(addContactResponse.Success, addContactResponse.Message);
    }

    [TestMethod]
    public void EditContactTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var contactServiceClient = new ContactService.ContactServiceClient(channel);

        ListContactResponse listContactResponse = contactServiceClient.ListContact(new ListContactRequest());
        ContactModel contactModelQuery = listContactResponse.ResultItem?.FirstOrDefault() ?? new ContactModel();
        contactModelQuery.Names = contactModel.Names;
        contactModelQuery.LastNames = contactModel.LastNames;
        contactModelQuery.Pseudonymous = contactModel.Pseudonymous;
        contactModelQuery.Email = contactModel.Email;
        contactModelQuery.PhoneNumber = contactModel.PhoneNumber;
        contactModelQuery.Country = contactModel.Country;
        contactModelQuery.StreetDirection1 = contactModel.StreetDirection1;
        contactModelQuery.StreetDirection2 = contactModel.StreetDirection2;
        contactModelQuery.PostalCode = contactModel.PostalCode;
        contactModelQuery.City = contactModel.City;
        contactModelQuery.Birthday = contactModel.Birthday;

        EditContactRequest editContactRequest = new EditContactRequest();
        editContactRequest.ContactModel = contactModelQuery;
        EditContactResponse editContactResponse = contactServiceClient.EditContact(editContactRequest);

        Assert.IsTrue(editContactResponse.Success, editContactResponse.Message);
    }

    [TestMethod]
    public void DeleteContactTest()
    {
        // The port number must match the port of the gRPC server.
        using var channel = GrpcChannel.ForAddress("https://localhost:7108");
        var contactServiceClient = new ContactService.ContactServiceClient(channel);

        ListContactResponse listContactResponse = contactServiceClient.ListContact(new ListContactRequest());
        ContactModel contactModelQuery = listContactResponse.ResultItem?.FirstOrDefault() ?? new ContactModel();

        DeleteContactRequest deleteContactRequest = new DeleteContactRequest();
        deleteContactRequest.ContactModel = contactModelQuery;
        DeleteContactResponse deleteContactResponse = contactServiceClient.DeleteContact(deleteContactRequest);

        Assert.IsTrue(deleteContactResponse.Success, deleteContactResponse.Message);
    }
}
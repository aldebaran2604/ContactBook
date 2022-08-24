using System.Linq;
using ContactPersistence.Models;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary;
using UtilityLibrary.Helpers;

namespace ContactMSTest.ServiceApiTest;

[TestClass]
public class ContactTest
{
    private Contact contact = new Contact();

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
        contact.Names = person.FirstName;
        contact.LastNames = person.LastName;
        contact.Pseudonymous = RandomData.GenerateWord(50);
        contact.Email = person.Email;
        contact.PhoneNumber = person.CellPhone;
        contact.Country = person.Country;
        contact.StreetDirection1 = person.Address1;
        contact.StreetDirection2 = person.Address2;
        contact.PostalCode = person.PostalCode;
        contact.City = person.City;
        contact.Birthday = person.BornOn.DateTime;
    }


    [TestMethod]
    public void ListContactTest()
    {
        ResponseInformation<Contact[]>? responseInformation = HttpClientApiHelper.Get<ResponseInformation<Contact[]>>("Contact");

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTest()
    {
        ResponseInformation? responseInformation = HttpClientApiHelper.Create<ResponseInformation, Contact>("Contact", contact);

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void EditContactTest()
    {
        ResponseInformation<Contact[]>? responseInformationList = HttpClientApiHelper.Get<ResponseInformation<Contact[]>>("Contact");

        //Search the last position to edit
        Contact contactQuery = responseInformationList?.ResultItem?.LastOrDefault() ?? new Contact();
        contactQuery.Names = contact.Names;
        contactQuery.LastNames = contact.LastNames;
        contactQuery.Pseudonymous = contact.Pseudonymous;
        contactQuery.CompanyName = contact.CompanyName;
        contactQuery.BusinessPositionID = contact.BusinessPositionID;
        contactQuery.BusinessPosition = contact.BusinessPosition;
        contactQuery.BusinessDepartmentId = contact.BusinessDepartmentId;
        contactQuery.BusinessDepartment = contact.BusinessDepartment;
        contactQuery.Email = contact.Email;
        contactQuery.Country = contact.Country;
        contactQuery.StreetDirection1 = contact.StreetDirection1;
        contactQuery.StreetDirection2 = contact.StreetDirection2;
        contactQuery.PostalCode = contact.PostalCode;
        contactQuery.City = contact.City;
        contactQuery.State = contact.State;
        contactQuery.Birthday = contact.Birthday;
        contactQuery.WebSite = contact.WebSite;
        contactQuery.Relationship = contact.Relationship;
        contactQuery.TypeRelationship = contact.TypeRelationship;
        contactQuery.Notes = contact.Notes;

        ResponseInformation<Contact>? responseInformation = HttpClientApiHelper.Update<ResponseInformation<Contact>, Contact>("Contact", contactQuery);

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void DeleteContactTest()
    {
        ResponseInformation<Contact[]>? responseInformationList = HttpClientApiHelper.Get<ResponseInformation<Contact[]>>("Contact");

        //Search the last position to delete
        Contact contactQuery = responseInformationList?.ResultItem?.LastOrDefault() ?? new Contact();

        ResponseInformation? responseInformation = HttpClientApiHelper.Delete<ResponseInformation>($"Contact/{contactQuery.ContactId}");

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}
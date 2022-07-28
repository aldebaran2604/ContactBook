using System.Linq;
using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using dotNetTips.Utility.Standard.Tester;
using dotNetTips.Utility.Standard.Tester.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary.Interfaces;

namespace ContactMSTest.PersistenceTests;

[TestClass]
public class ContactTest
{
    //TODO: Implement transactions
    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    {
        
    }
    
    [ClassCleanup()]
    public static void ClassCleanup()
    {
        
    }

    [TestMethod]
    public void ListaContactsTest()
    {
        IResponseInformation<Contact[]> responseInformation = BLContact.ListContacts();
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTest()
    {
        Person person = RandomData.GeneratePerson<Person>();
        
        Contact contact = new Contact()
        {
            Names = person.FirstName,
            LastNames = person.LastName,
            Pseudonymous = RandomData.GenerateWord(250),
            Email = person.Email,
            PhoneNumber = person.CellPhone,
            Country = person.Country,
            StreetDirection1 = person.Address1,
            StreetDirection2 = person.Address2,
            PostalCode = person.PostalCode,
            City = person.City,
            Birthday = person.BornOn.DateTime
        };
        IResponseInformation responseInformation = BLContact.AddContact(contact);
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTestWithExistingBusinessDepartment()
    {
        IResponseInformation<BusinessDepartment[]> responseInformation1 = BLBusinessDepartment.ListBusinessDepartment();
        BusinessDepartment? businessDepartment =  responseInformation1.ResultItem?.LastOrDefault();
        Contact contact = new Contact()
        {
            Names = "Luis Jose",
            LastNames = "Padilla Benitez",
            Pseudonymous = "Aldebaran",
            BusinessDepartmentId = businessDepartment?.BusinessDepartmentId
        };
        IResponseInformation responseInformation = BLContact.AddContact(contact);
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTestWithNewBusinessDepartment()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = "Purchase Department",
            Description = "By following a standard procedure of procurement, this department ensures the enterprise has appropriate and timely supply of all the required goods and services."
        };
        Contact contact = new Contact()
        {
            Names = "Luis Jose",
            LastNames = "Padilla Benitez",
            Pseudonymous = "Aldebaran",
            BusinessDepartment = businessDepartment
        };
        IResponseInformation responseInformation = BLContact.AddContact(contact);
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}

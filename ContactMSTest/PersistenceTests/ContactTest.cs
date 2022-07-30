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
        Person person = RandomData.GeneratePerson<Person>();
        contact.Names = person.FirstName;
        contact.LastNames = person.LastName;
        contact. Pseudonymous = RandomData.GenerateWord(50);
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
    public void ListaContactsTest()
    {
        //Get contact list
        IResponseInformation<Contact[]> responseInformation = BLContact.ListContacts();

        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTest()
    {
        //Save 
        IResponseInformation responseInformation = BLContact.AddContact(contact);

        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTestWithLastBusinessDepartmentOrPosition()
    {
        IResponseInformation<BusinessDepartment[]> listBusinessDepartment = BLBusinessDepartment.ListBusinessDepartment();
        BusinessDepartment? businessDepartment =  listBusinessDepartment.ResultItem?.LastOrDefault();
        
        IResponseInformation<BusinessPosition[]> listBusinessPosition = BLBusinessPosition.ListBusinessPosition();
        BusinessPosition? businessPosition = listBusinessPosition.ResultItem?.LastOrDefault();

        //Add Business Department id to contact
        contact.BusinessDepartmentId = businessDepartment?.BusinessDepartmentId;

        //Add Business Position id to contact
        contact.BusinessPositionID = businessPosition?.BusinessPositionId;
        
        IResponseInformation responseInformation = BLContact.AddContact(contact);

        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddContactTestWithNewBusinessDepartmentAndPosition()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = RandomData.GenerateWord(120),
            Description = RandomData.GenerateWord(250)
        };

        BusinessPosition businessPosition = new BusinessPosition()
        {
            Name = RandomData.GenerateWord(120),
            Description = RandomData.GenerateWord(250)
        };
        
        //Add new Business Department and related to contact
        contact.BusinessDepartment = businessDepartment;

        //Add new Business Position and related to contact
        contact.BusinessPosition = businessPosition;
        
        IResponseInformation responseInformation = BLContact.AddContact(contact);

        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
    
    [TestMethod]
    public void DeleteContactTest()
    {
        IResponseInformation<Contact[]> responseInformation = BLContact.ListContacts();
        Contact contactDelete = responseInformation.ResultItem?.FirstOrDefault() ?? new Contact();
        IResponseInformation responseInformationDelete = BLContact.DeleteContact(contactDelete);
        
        //Validate the response information
        Assert.IsTrue(responseInformationDelete.Success, responseInformationDelete.Message);
    }
}

using System.Linq;
using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
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
        Contact contact = new Contact()
        {
            Names = "Luis Jose",
            LastNames = "Padilla Benitez",
            Pseudonymous = "Aldebaran"
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

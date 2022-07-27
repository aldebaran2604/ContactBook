using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactPersistence.Models;
using ContactPersistence.BusinessLogic;
using UtilityLibrary.Interfaces;

namespace ContactMSTest.PersistenceTests;

[TestClass]
public class BusinessDepartmentTest
{
    [TestMethod]
    public void ListBusinessDepartmentTest()
    {
        IResponseInformation<BusinessDepartment[]> responseInformation = BLBusinessDepartment.ListBusinessDepartment();
        if(responseInformation.Failure)
        {
            Assert.Fail(responseInformation.Message);
        }
        else
        {
            Assert.IsTrue(responseInformation.Success, responseInformation.Message);
        }
    }

    [TestMethod]
    public void AddBusinessDepartmentTest()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = "Finance",
            Description = "The Finance Department is responsible for acquiring and utilizing money for financing the activities of the tourism business."
        };
        IResponseInformation responseInformation = BLBusinessDepartment.AddBusinessDepartment(businessDepartment);
        if(responseInformation.Failure)
        {
            Assert.Fail(responseInformation.Message);
        }
        else
        {
            Assert.IsTrue(responseInformation.Success, responseInformation.Message);
        }
    }

    [TestMethod]
    public void EditBusinessDepartmentTest()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            BusinessDepartmentId = 1,
            Name = "Human Resource",
            Description = "This department is responsible for recruiting skilled, and experienced manpower according to the positions at vacancies of different departments."
        };
        IResponseInformation<BusinessDepartment> responseInformation = BLBusinessDepartment.EditBusinessDepartment(businessDepartment);
        if(responseInformation.Failure)
        {
            Assert.Fail(responseInformation.Message);
        }
        else
        {
            Assert.IsTrue(responseInformation.Success, responseInformation.Message);
        }
    }

    [TestMethod]
    public void DeleteBusinessDepartmentTest()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            BusinessDepartmentId = 1
        };
        IResponseInformation responseInformation = BLBusinessDepartment.DeleteBusinessDepartment(businessDepartment);
        if(responseInformation.Failure)
        {
            Assert.Fail(responseInformation.Message);
        }
        else
        {
            Assert.IsTrue(responseInformation.Success, responseInformation.Message);
        }
    }
}
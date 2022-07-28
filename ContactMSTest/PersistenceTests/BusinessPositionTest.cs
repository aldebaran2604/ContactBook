using System;
using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary.Interfaces;

namespace ContactMSTest.PersistenceTests;

[TestClass]
public class BusinessPositionTest
{
    [ClassInitialize()]
    public static void ClassInit(TestContext context)
    {
        Console.WriteLine($"ClassInit - ClassInit");
    }
    
    [ClassCleanup()]
    public static void ClassCleanup()
    {
        Console.WriteLine($"ClassCleanup - ClassCleanup");
    }

    [TestMethod]
    public void ListBusinessPositionTest()
    {
        IResponseInformation<BusinessPosition[]> responseInformation = BLBusinessPosition.ListBusinessPosition();
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
    public void AddBusinessPositionTest()
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            Name = "Executive",
            Description = "The executive level often features a central executive in charge of an entire organization or large department within an organization."
        };
        IResponseInformation responseInformation = BLBusinessPosition.AddBusinessPosition(businessPosition);
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
    public void EditBusinessPositionTest()
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            BusinessPositionId = 1,
            Name = "Manager",
            Description = "Managers and supervisors make up many of the essential mid-level business roles within an organization."
        };
        IResponseInformation<BusinessPosition> responseInformation = BLBusinessPosition.EditBusinessPosition(businessPosition);
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
    public void DeleteBusinessPositionTest()
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            BusinessPositionId = 1
        };
        IResponseInformation responseInformation = BLBusinessPosition.DeleteBusinessPosition(businessPosition);
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

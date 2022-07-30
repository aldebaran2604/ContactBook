using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ContactPersistence.Models;
using ContactPersistence.BusinessLogic;
using UtilityLibrary.Interfaces;
using dotNetTips.Utility.Standard.Tester;

namespace ContactMSTest.PersistenceTests;

[TestClass]
public class BusinessDepartmentTest
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
    public void ListBusinessDepartmentTest()
    {
        //Get list of Business Department
        IResponseInformation<BusinessDepartment[]> responseInformation = BLBusinessDepartment.ListBusinessDepartment();
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddBusinessDepartmentTest()
    {
        //Create the new department with random data
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = RandomData.GenerateWord(150),
            Description = RandomData.GenerateWord(250)
        };

        //Saved the new department
        IResponseInformation responseInformation = BLBusinessDepartment.AddBusinessDepartment(businessDepartment);
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void EditBusinessDepartmentTest()
    {
        //Get list of Business Department
        IResponseInformation<BusinessDepartment[]> responseInformationList = BLBusinessDepartment.ListBusinessDepartment();
        
        //Search the last department to edit
        BusinessDepartment businessDepartment = responseInformationList.ResultItem?.LastOrDefault()?? new BusinessDepartment();
        businessDepartment.Name = RandomData.GenerateWord(150);
        businessDepartment.Description = RandomData.GenerateWord(250);

        //Passed the department with the new data to save
        IResponseInformation<BusinessDepartment> responseInformation = BLBusinessDepartment.EditBusinessDepartment(businessDepartment);
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void DeleteBusinessDepartmentTest()
    {
        //Get list of Business Department
        IResponseInformation<BusinessDepartment[]> responseInformationList = BLBusinessDepartment.ListBusinessDepartment();
        
        //Search the last department to delete
        BusinessDepartment businessDepartment = responseInformationList.ResultItem?.LastOrDefault()?? new BusinessDepartment();
        
        //Deleted the department
        IResponseInformation responseInformation = BLBusinessDepartment.DeleteBusinessDepartment(businessDepartment);
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}
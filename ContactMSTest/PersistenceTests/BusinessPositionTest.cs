using System.Linq;
using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary.Interfaces;
using dotNetTips.Utility.Standard.Tester;

namespace ContactMSTest.PersistenceTests;

[TestClass]
public class BusinessPositionTest
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
    public void ListBusinessPositionTest()
    {
        //Get list of Business Position
        IResponseInformation<BusinessPosition[]> responseInformation = BLBusinessPosition.ListBusinessPosition();
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddBusinessPositionTest()
    {
        //Create the new position with random data
        BusinessPosition businessPosition = new BusinessPosition()
        {
            Name = RandomData.GenerateWord(150),
            Description = RandomData.GenerateWord(250)
        };

        //Saved the new position
        IResponseInformation responseInformation = BLBusinessPosition.AddBusinessPosition(businessPosition);
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
    
    [TestMethod]
    public void EditBusinessPositionTest()
    {
        //Get list of Business Position
        IResponseInformation<BusinessPosition[]> responseInformationList = BLBusinessPosition.ListBusinessPosition();

        //Search the last position to edit
        BusinessPosition businessPosition = responseInformationList.ResultItem?.LastOrDefault() ?? new BusinessPosition();
        businessPosition.Name = RandomData.GenerateWord(150);
        businessPosition.Description = RandomData.GenerateWord(250);

        //Passed the position with the new data to save
        IResponseInformation<BusinessPosition> responseInformation = BLBusinessPosition.EditBusinessPosition(businessPosition);
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void DeleteBusinessPositionTest()
    {
        //Get list of Business Position
        IResponseInformation<BusinessPosition[]> responseInformationList = BLBusinessPosition.ListBusinessPosition();

        //Search the last position to delete
        BusinessPosition businessPosition = responseInformationList.ResultItem?.LastOrDefault() ?? new BusinessPosition();

        //Deleted the position
        IResponseInformation responseInformation = BLBusinessPosition.DeleteBusinessPosition(businessPosition);
        
        //Validate the response information
        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}

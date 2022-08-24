using System.Linq;
using ContactPersistence.Models;
using dotNetTips.Utility.Standard.Tester;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary;
using UtilityLibrary.Helpers;

namespace ContactMSTest.ServiceApiTest;

[TestClass]
public class BusinessPositionTest
{
    [TestMethod]
    public void ListBusinessPositionTest()
    {
        ResponseInformation<BusinessPosition[]>? responseInformation = HttpClientApiHelper.Get<ResponseInformation<BusinessPosition[]>>("BusinessPosition");

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddBusinessPositionTest()
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            Name = RandomData.GenerateWord(150),
            Description = RandomData.GenerateWord(250)
        };
        ResponseInformation? responseInformation = HttpClientApiHelper.Create<ResponseInformation, BusinessPosition>("BusinessPosition", businessPosition);

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void EditBusinessPositionTest()
    {
        ResponseInformation<BusinessPosition[]>? responseInformationList = HttpClientApiHelper.Get<ResponseInformation<BusinessPosition[]>>("BusinessPosition");

        //Search the last position to edit
        BusinessPosition businessPosition = responseInformationList?.ResultItem?.LastOrDefault() ?? new BusinessPosition();
        businessPosition.Name = RandomData.GenerateWord(150);
        businessPosition.Description = RandomData.GenerateWord(250);
        ResponseInformation<BusinessPosition>? responseInformation = HttpClientApiHelper.Update<ResponseInformation<BusinessPosition>, BusinessPosition>("BusinessPosition", businessPosition);

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void DeleteBusinessPositionTest()
    {
        ResponseInformation<BusinessPosition[]>? responseInformationList = HttpClientApiHelper.Get<ResponseInformation<BusinessPosition[]>>("BusinessPosition");

        //Search the last position to delete
        BusinessPosition businessPosition = responseInformationList?.ResultItem?.LastOrDefault() ?? new BusinessPosition();

        ResponseInformation? responseInformation = HttpClientApiHelper.Delete<ResponseInformation>($"BusinessPosition/{businessPosition.BusinessPositionId}");

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}
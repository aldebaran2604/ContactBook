using ContactPersistence.Models;
using dotNetTips.Utility.Standard.Tester;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary;
using UtilityLibrary.Helpers;
using System.Linq;

namespace ContactMSTest.ServiceApiTest;

[TestClass]
public class BusinessDepartmentTest
{
    [TestMethod]
    public void ListBusinessDepartmentTest()
    {
        ResponseInformation<BusinessDepartment[]>? responseInformation = HttpClientApiHelper.Get<ResponseInformation<BusinessDepartment[]>>("BusinessDepartment");

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void AddBusinessDepartmentTest()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = RandomData.GenerateWord(150),
            Description = RandomData.GenerateWord(250)
        };
        ResponseInformation? responseInformation = HttpClientApiHelper.Create<ResponseInformation, BusinessDepartment>("BusinessDepartment", businessDepartment);

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void EditBusinessDepartmentTest()
    {
        ResponseInformation<BusinessDepartment[]>? responseInformationList = HttpClientApiHelper.Get<ResponseInformation<BusinessDepartment[]>>("BusinessDepartment");

        //Search the last department to edit
        BusinessDepartment businessDepartment = responseInformationList?.ResultItem?.LastOrDefault() ?? new BusinessDepartment();
        businessDepartment.Name = RandomData.GenerateWord(150);
        businessDepartment.Description = RandomData.GenerateWord(250);
        ResponseInformation<BusinessDepartment>? responseInformation = HttpClientApiHelper.Update<ResponseInformation<BusinessDepartment>, BusinessDepartment>("BusinessDepartment", businessDepartment);

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }

    [TestMethod]
    public void DeleteBusinessDepartmentTest()
    {
        ResponseInformation<BusinessDepartment[]>? responseInformationList = HttpClientApiHelper.Get<ResponseInformation<BusinessDepartment[]>>("BusinessDepartment");

        //Search the last department to delete
        BusinessDepartment businessDepartment = responseInformationList?.ResultItem?.LastOrDefault() ?? new BusinessDepartment();

        ResponseInformation? responseInformation = HttpClientApiHelper.Delete<ResponseInformation>($"BusinessDepartment/{businessDepartment.BusinessDepartmentId}");

        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}
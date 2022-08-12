using ContactPersistence.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UtilityLibrary;
using UtilityLibrary.Helpers;

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
            Name = "BusinessDepartmentTest api 2",
            Description = "BusinessDepartmentTest api 2"
        };
        ResponseInformation? responseInformation = HttpClientApiHelper.Create<ResponseInformation, BusinessDepartment>("BusinessDepartment", businessDepartment);
        
        Assert.IsNotNull(responseInformation);

        Assert.IsTrue(responseInformation.Success, responseInformation.Message);
    }
}
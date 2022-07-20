using ContactPersistence.Models;
using ContactPersistence.BusinessLogic;

using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ContactMSTest.PersistenceTests;

[TestClass]
public class BusinessDepartmentTest
{
    [TestMethod]
    public void AddBusinessDepartmentTest()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = "Finance",
            Description = "The Finance Department is responsible for acquiring and utilizing money for financing the activities of the tourism business."
        };
        BLBusinessDepartment.AddBusinessDepartment(businessDepartment);
    }

    [TestMethod]
    public void EditBusinessDepartmentTest()
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            BusinessDepartmentId = 4,
            Name = "Human Resource",
            Description = "This department is responsible for recruiting skilled, and experienced manpower according to the positions at vacancies of different departments."
        };
        BLBusinessDepartment.EditBusinessDepartment(businessDepartment);
    }
}
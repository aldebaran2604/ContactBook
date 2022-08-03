using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Microsoft.AspNetCore.Mvc;
using UtilityLibrary.Interfaces;

namespace ContactServiceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessDepartmentController : ControllerBase
{
    private readonly ILogger<BusinessDepartmentController> _logger;

    public BusinessDepartmentController(ILogger<BusinessDepartmentController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IResponseInformation<BusinessDepartment[]> ListBusinessDepartment()
    {
        IResponseInformation<BusinessDepartment[]> responseInformation = BLBusinessDepartment.ListBusinessDepartment();
        return responseInformation;
    }

    [HttpPost]
    public IResponseInformation AddBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation responseInformation = BLBusinessDepartment.AddBusinessDepartment(businessDepartment);
        return responseInformation;
    }

    [HttpPut]
    public IResponseInformation<BusinessDepartment> EditBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation<BusinessDepartment> responseInformation = BLBusinessDepartment.EditBusinessDepartment(businessDepartment);
        return responseInformation;
    }

    [HttpDelete("{businessDepartmentId}")]
    public IResponseInformation DeleteBusinessDepartment(int businessDepartmentId)
    {
        IResponseInformation responseInformation = BLBusinessDepartment.DeleteBusinessDepartment(new BusinessDepartment() { BusinessDepartmentId = businessDepartmentId });
        return responseInformation;
    }
}

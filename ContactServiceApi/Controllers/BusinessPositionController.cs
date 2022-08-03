using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Microsoft.AspNetCore.Mvc;
using UtilityLibrary.Interfaces;

namespace ContactServiceApi.Controllers;

[ApiController]
[Route("[controller]")]
public class BusinessPositionController : ControllerBase
{
    private readonly ILogger<BusinessPositionController> _logger;

    public BusinessPositionController(ILogger<BusinessPositionController> logger)
    {
        _logger = logger;
    }

    [HttpGet]
    public IResponseInformation<BusinessPosition[]> ListBusinessPosition()
    {
        IResponseInformation<BusinessPosition[]> responseInformation = BLBusinessPosition.ListBusinessPosition();
        return responseInformation;
    }

    [HttpPost]
    public IResponseInformation AddBusinessPosition(BusinessPosition businessPosition)
    {
        IResponseInformation responseInformation = BLBusinessPosition.AddBusinessPosition(businessPosition);
        return responseInformation;
    }

    [HttpPut]
    public IResponseInformation<BusinessPosition> EditBusinessPosition(BusinessPosition businessPosition)
    {
        IResponseInformation<BusinessPosition> responseInformation = BLBusinessPosition.EditBusinessPosition(businessPosition);
        return responseInformation;
    }

    [HttpDelete("{businessPositionId}")]
    public IResponseInformation DeleteBusinessPosition(int businessPositionId)
    {
        IResponseInformation responseInformation = BLBusinessPosition.DeleteBusinessPosition(new BusinessPosition() { BusinessPositionId = businessPositionId });
        return responseInformation;
    }
}

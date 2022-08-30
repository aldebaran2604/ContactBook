using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Grpc.Core;
using UtilityLibrary.Interfaces;

namespace ContactServiceGRPC.Services;

public class BusinessPositionService : ContactServiceGRPC.BusinessPositionService.BusinessPositionServiceBase
{
    private readonly ILogger<BusinessPositionService> _logger;
    public BusinessPositionService(ILogger<BusinessPositionService> logger)
    {
        _logger = logger;
    }

    public override Task<ListBusinessPositionResponse> ListBusinessPosition(ListBusinessPositionRequest request, ServerCallContext context)
    {
        IResponseInformation<BusinessPosition[]> responseInformation = BLBusinessPosition.ListBusinessPosition();

        ListBusinessPositionResponse response = new ListBusinessPositionResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };

        if (responseInformation.Success && responseInformation.ResultItem is not null)
        {
            foreach (var department in responseInformation.ResultItem)
            {
                response.ResultItem.Add(new BusinessPositionModel()
                {
                    BusinessPositionId = department.BusinessPositionId,
                    Name = department.Name ?? string.Empty,
                    Description = department.Description ?? string.Empty
                });
            }
        }

        return Task.FromResult(response);
    }

    public override Task<AddBusinessPositionResponse> AddBusinessPosition(AddBusinessPositionRequest request, ServerCallContext context)
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            Name = request.BusinessPositionModel.Name,
            Description = request.BusinessPositionModel.Description
        };
        IResponseInformation responseInformation = BLBusinessPosition.AddBusinessPosition(businessPosition);
        AddBusinessPositionResponse addBusinessPositionResponse = new AddBusinessPositionResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(addBusinessPositionResponse);
    }

    public override Task<EditBusinessPositionResponse> EditBusinessPosition(EditBusinessPositionRequest request, ServerCallContext context)
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            BusinessPositionId = request.BusinessPositionModel.BusinessPositionId,
            Name = request.BusinessPositionModel.Name,
            Description = request.BusinessPositionModel.Description
        };
        IResponseInformation<BusinessPosition> responseInformation = BLBusinessPosition.EditBusinessPosition(businessPosition);
        EditBusinessPositionResponse editBusinessPositionResponse = new EditBusinessPositionResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(editBusinessPositionResponse);
    }

    public override Task<DeleteBusinessPositionResponse> DeleteBusinessPosition(DeleteBusinessPositionRequest request, ServerCallContext context)
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            BusinessPositionId = request.BusinessPositionModel.BusinessPositionId,
            Name = request.BusinessPositionModel.Name,
            Description = request.BusinessPositionModel.Description
        };
        IResponseInformation responseInformation = BLBusinessPosition.DeleteBusinessPosition(businessPosition);
        DeleteBusinessPositionResponse deleteBusinessPositionResponse = new DeleteBusinessPositionResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(deleteBusinessPositionResponse);
    }
}
using ContactPersistence.BusinessLogic;
using ContactPersistence.Models;
using Grpc.Core;
using UtilityLibrary.Interfaces;

namespace ContactServiceGRPC.Services;

public class BusinessDepartmentService : ContactServiceGRPC.BusinessDepartmentService.BusinessDepartmentServiceBase
{
    private readonly ILogger<BusinessDepartmentService> _logger;
    public BusinessDepartmentService(ILogger<BusinessDepartmentService> logger)
    {
        _logger = logger;
    }

    public override Task<ListBusinessDepartmentResponse> ListBusinessDepartment(ListBusinessDepartmentRequest request, ServerCallContext context)
    {
        IResponseInformation<BusinessDepartment[]> responseInformation = BLBusinessDepartment.ListBusinessDepartment();

        ListBusinessDepartmentResponse response = new ListBusinessDepartmentResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };

        if (responseInformation.Success && responseInformation.ResultItem is not null)
        {
            foreach (var department in responseInformation.ResultItem)
            {
                response.ResultItem.Add(new BusinessDepartmentModel()
                {
                    BusinessDepartmentId = department.BusinessDepartmentId,
                    Name = department.Name ?? string.Empty,
                    Description = department.Description ?? string.Empty
                });

            }
        }

        return Task.FromResult(response);
    }

    public override Task<AddBusinessDepartmentResponse> AddBusinessDepartment(AddBusinessDepartmentRequest request, ServerCallContext context)
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            Name = request.BusinessDepartmentModel.Name,
            Description = request.BusinessDepartmentModel.Description
        };
        IResponseInformation responseInformation = BLBusinessDepartment.AddBusinessDepartment(businessDepartment);

        AddBusinessDepartmentResponse addBusinessDepartmentResponse = new AddBusinessDepartmentResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(addBusinessDepartmentResponse);
    }

    public override Task<EditaBusinessDepartmentResponse> EditBusinessDepartment(EditBusinessDepartmentRequest request, ServerCallContext context)
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            BusinessDepartmentId = request.BusinessDepartmentModel.BusinessDepartmentId,
            Name = request.BusinessDepartmentModel.Name,
            Description = request.BusinessDepartmentModel.Description
        };
        IResponseInformation<BusinessDepartment> responseInformation = BLBusinessDepartment.EditBusinessDepartment(businessDepartment);

        EditaBusinessDepartmentResponse editaBusinessDepartmentResponse = new EditaBusinessDepartmentResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(editaBusinessDepartmentResponse);
    }

    public override Task<DeleteBusinessDepartmentResponse> DeleteBusinessDepartment(DeleteBusinessDepartmentRequest request, ServerCallContext context)
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            BusinessDepartmentId = request.BusinessDepartmentModel.BusinessDepartmentId
        };
        IResponseInformation responseInformation = BLBusinessDepartment.DeleteBusinessDepartment(businessDepartment);
        
        DeleteBusinessDepartmentResponse deleteBusinessDepartmentResponse = new DeleteBusinessDepartmentResponse()
        {
            Success = responseInformation.Success,
            Message = responseInformation.Message,
            Failure = responseInformation.Failure
        };
        return Task.FromResult(deleteBusinessDepartmentResponse);
    }
}

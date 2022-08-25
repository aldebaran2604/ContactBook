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
        ListBusinessDepartmentResponse response = new ListBusinessDepartmentResponse();
        IResponseInformation<BusinessDepartment[]> responseInformation = BLBusinessDepartment.ListBusinessDepartment();
        if (responseInformation.Success && responseInformation.ResultItem is not null)
        {
            foreach (var department in responseInformation.ResultItem)
            {
                response.ResultItem.Add(new BusinessDepartmentModel()
                {
                    BusinessDepartmentId = department.BusinessDepartmentId,
                    Name = department.Name,
                    Description = department.Description
                });

            }
        }
        return Task.FromResult(response);
    }
}

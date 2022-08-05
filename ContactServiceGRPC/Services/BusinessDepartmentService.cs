using Grpc.Core;

namespace ContactServiceGRPC.Services;

public class BusinessDepartmentService : ContactServiceGRPC.BusinessDepartment.BusinessDepartmentBase
{
    private readonly ILogger<BusinessDepartmentService> _logger;
    public BusinessDepartmentService(ILogger<BusinessDepartmentService> logger)
    {
        _logger = logger;
    }

    public override Task<ListBusinessDepartmentResponse> ListBusinessDepartment(ListBusinessDepartmentRequest request, ServerCallContext context)
    {
        ListBusinessDepartmentResponse response = new ListBusinessDepartmentResponse();
        response.ResponseInformation = new ResponseInformation();

        ResponseInformation responseInformation = new ResponseInformation();
        return Task.FromResult(new ListBusinessDepartmentResponse()
        {
            ResponseInformation = responseInformation
        });
    }
}

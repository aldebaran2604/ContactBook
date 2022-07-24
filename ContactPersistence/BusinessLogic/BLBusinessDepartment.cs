using UtilityLibrary.Interfaces;
using UtilityLibrary.Helpers;
using UtilityLibrary;
using ContactPersistence.Models;

namespace ContactPersistence.BusinessLogic;

public static class BLBusinessDepartment
{
    public static IResponseInformation AddBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if(businessDepartment is null) throw new ArgumentException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            context.Add(businessDepartment);
            context.SaveChanges();
            responseInformation.ConfigureSuccessResponseInformation("Se guardo con éxito el departamento.");
        }
        catch(Exception ex)
        {
            responseInformation.Success = false;
            responseInformation.Message = ex.Message;
        }
        return responseInformation;
    }

    public static IResponseInformation<BusinessDepartment> EditBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation<BusinessDepartment> responseInformation = new ResponseInformation<BusinessDepartment>();
        try
        {
            if(businessDepartment is null) throw new ArgumentException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            BusinessDepartment? businessDepartmentQuery = context.BusinessDepartments?.FirstOrDefault(bd => bd.BusinessDepartmentId == businessDepartment.BusinessDepartmentId);

            if(businessDepartmentQuery is not null)
            {
                businessDepartmentQuery.Name = businessDepartment.Name;
                businessDepartmentQuery.Description = businessDepartment.Description;

                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se guardo con éxito el departamento.", businessDepartmentQuery);
            }
        }
        catch(Exception ex)
        {
            responseInformation.Success = false;
            responseInformation.Message = ex.Message;
        }
        return responseInformation;
    }
}
using UtilityLibrary.Interfaces;
using UtilityLibrary.Helpers;
using UtilityLibrary;
using ContactPersistence.Models;

namespace ContactPersistence.BusinessLogic;

public static class BLBusinessDepartment
{
    public static IResponseInformation<BusinessDepartment[]> ListBusinessDepartment()
    {
        IResponseInformation<BusinessDepartment[]> responseInformation = new ResponseInformation<BusinessDepartment[]>();
        try
        {
            using ContactBookContext context = new ContactBookContext();
            BusinessDepartment[] businessDepartments = context.BusinessDepartments.ToArray() ?? Array.Empty<BusinessDepartment>();
            responseInformation.ConfigureSuccessResponseInformation("Se realizo la consulta con éxito.", businessDepartments);
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation AddBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if(businessDepartment is null) throw new ArgumentNullException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            context.BusinessDepartments.Add(businessDepartment);
            context.SaveChanges();
            responseInformation.ConfigureSuccessResponseInformation($"Se guardo con éxito el departamento.");
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation<BusinessDepartment> EditBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation<BusinessDepartment> responseInformation = new ResponseInformation<BusinessDepartment>();
        try
        {
            if(businessDepartment is null) throw new ArgumentNullException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            BusinessDepartment? businessDepartmentQuery = context.BusinessDepartments.FirstOrDefault(bd => bd.BusinessDepartmentId == businessDepartment.BusinessDepartmentId);

            if(businessDepartmentQuery is not null)
            {
                businessDepartmentQuery.Name = businessDepartment.Name;
                businessDepartmentQuery.Description = businessDepartment.Description;

                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se actualizo con éxito el departamento.", businessDepartmentQuery);
            }
            else
            {
                responseInformation.ConfigureFailureResponseInformation("No se encontró el departamento.");
            }
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation DeleteBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if(businessDepartment is null) throw new ArgumentNullException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            BusinessDepartment? businessDepartmentDelete = context.BusinessDepartments.FirstOrDefault(b => b.BusinessDepartmentId == businessDepartment.BusinessDepartmentId);
            if(businessDepartmentDelete is not null)
            {
                context.BusinessDepartments.Remove(businessDepartmentDelete);
                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se elimino el departamento con éxito.");
            }
            else
            {
                responseInformation.ConfigureFailureResponseInformation("No se encontró el departamento.");
            }
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }
}
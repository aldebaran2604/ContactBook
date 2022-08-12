using UtilityLibrary.Interfaces;
using UtilityLibrary.Helpers;
using UtilityLibrary;
using ContactPersistence.Models;

namespace ContactPersistence.BusinessLogic;

/// <summary>
/// Static class that exposes methods to query, add, edit, and delete departments
/// </summary>
public static class BLBusinessDepartment
{
    /// <summary>
    /// Get list of departments
    /// </summary>
    /// <returns>Error information and departments</returns>
    public static IResponseInformation<BusinessDepartment[]> ListBusinessDepartment()
    {
        IResponseInformation<BusinessDepartment[]> responseInformation = new ResponseInformation<BusinessDepartment[]>();
        try
        {
            using ContactBookContext context = new ContactBookContext();
            BusinessDepartment[] businessDepartments = context.BusinessDepartments.ToArray() ?? Array.Empty<BusinessDepartment>();
            responseInformation.ConfigureSuccess("Se realizo la consulta con éxito.", businessDepartments);
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Add new department
    /// </summary>
    /// <param name="businessDepartment">Data new department</param>
    /// <returns>Error information</returns>
    public static IResponseInformation AddBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (businessDepartment is null) throw new ArgumentNullException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            context.BusinessDepartments.Add(businessDepartment);
            context.SaveChanges();
            responseInformation.ConfigureSuccess($"Se guardo con éxito el departamento.");
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Edit an existing department
    /// </summary>
    /// <param name="businessDepartment">Data update department</param>
    /// <returns>Error information and department data</returns>
    public static IResponseInformation<BusinessDepartment> EditBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation<BusinessDepartment> responseInformation = new ResponseInformation<BusinessDepartment>();
        try
        {
            if (businessDepartment is null) throw new ArgumentNullException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            BusinessDepartment? businessDepartmentQuery = context.BusinessDepartments.FirstOrDefault(bd => bd.BusinessDepartmentId == businessDepartment.BusinessDepartmentId);

            if (businessDepartmentQuery is not null)
            {
                businessDepartmentQuery.Name = businessDepartment.Name;
                businessDepartmentQuery.Description = businessDepartment.Description;

                context.SaveChanges();
                responseInformation.ConfigureSuccess("Se actualizo con éxito el departamento.", businessDepartmentQuery);
            }
            else
            {
                responseInformation.ConfigureFailure("No se encontró el departamento.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Delete existing department
    /// </summary>
    /// <param name="businessDepartment">Data department</param>
    /// <returns>Error information</returns>
    public static IResponseInformation DeleteBusinessDepartment(BusinessDepartment businessDepartment)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (businessDepartment is null) throw new ArgumentNullException(nameof(businessDepartment));

            using ContactBookContext context = new ContactBookContext();

            BusinessDepartment? businessDepartmentDelete = context.BusinessDepartments.FirstOrDefault(b => b.BusinessDepartmentId == businessDepartment.BusinessDepartmentId);
            if (businessDepartmentDelete is not null)
            {
                context.BusinessDepartments.Remove(businessDepartmentDelete);
                context.SaveChanges();
                responseInformation.ConfigureSuccess("Se elimino el departamento con éxito.");
            }
            else
            {
                responseInformation.ConfigureFailure("No se encontró el departamento.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }
}
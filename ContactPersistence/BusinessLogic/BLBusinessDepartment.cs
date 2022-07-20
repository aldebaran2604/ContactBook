using ContactPersistence.Models;

namespace ContactPersistence.BusinessLogic;

public static class BLBusinessDepartment
{
    public static void AddBusinessDepartment(BusinessDepartment businessDepartment)
    {
        try
        {
            using ContactBookContext context = new ContactBookContext();

            context.Add(businessDepartment);
            context.SaveChanges();
        }
        catch(Exception ex)
        {
            _ = ex;
        }
    }

    public static void EditBusinessDepartment(BusinessDepartment businessDepartment)
    {
        try
        {
            using ContactBookContext context = new ContactBookContext();

            BusinessDepartment? businessDepartmentQuery = context.BusinessDepartments?.FirstOrDefault(bd => bd.BusinessDepartmentId == businessDepartment.BusinessDepartmentId);

            if(businessDepartmentQuery is not null)
            {
                businessDepartmentQuery.Name = businessDepartment.Name;
                businessDepartmentQuery.Description = businessDepartment.Description;

                context.SaveChanges();
            }
        }
        catch(Exception ex)
        {
            _ = ex;
        }
    }
}
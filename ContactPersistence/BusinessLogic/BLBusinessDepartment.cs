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
}
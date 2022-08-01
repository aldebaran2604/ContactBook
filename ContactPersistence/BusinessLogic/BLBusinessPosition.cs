using UtilityLibrary.Interfaces;
using UtilityLibrary.Helpers;
using UtilityLibrary;
using ContactPersistence.Models;

namespace ContactPersistence.BusinessLogic;

public static class BLBusinessPosition
{
    public static IResponseInformation<BusinessPosition[]> ListBusinessPosition()
    {
        IResponseInformation<BusinessPosition[]> responseInformation = new ResponseInformation<BusinessPosition[]>();
        try
        {
            using ContactBookContext context = new ContactBookContext();
            BusinessPosition[] businessPositions = context.BusinessPositions.ToArray() ?? Array.Empty<BusinessPosition>();
            responseInformation.ConfigureSuccessResponseInformation("Se realizo la consulta con éxito.", businessPositions);
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation AddBusinessPosition(BusinessPosition businessPosition)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (businessPosition is null) throw new ArgumentNullException(nameof(businessPosition));

            using ContactBookContext context = new ContactBookContext();

            context.BusinessPositions.Add(businessPosition);
            context.SaveChanges();
            responseInformation.ConfigureSuccessResponseInformation($"Se guardo con éxito la posición.");
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation<BusinessPosition> EditBusinessPosition(BusinessPosition businessPosition)
    {
        IResponseInformation<BusinessPosition> responseInformation = new ResponseInformation<BusinessPosition>();
        try
        {
            if (businessPosition is null) throw new ArgumentNullException(nameof(businessPosition));

            using ContactBookContext context = new ContactBookContext();

            BusinessPosition? businessPositionQuery = context.BusinessPositions.FirstOrDefault(bd => bd.BusinessPositionId == businessPosition.BusinessPositionId);

            if (businessPositionQuery is not null)
            {
                businessPositionQuery.Name = businessPosition.Name;
                businessPositionQuery.Description = businessPosition.Description;

                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se guardo con éxito la posición.", businessPositionQuery);
            }
            else
            {
                responseInformation.ConfigureFailureResponseInformation("No se encontró la posición.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation DeleteBusinessPosition(BusinessPosition businessPosition)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (businessPosition is null) throw new ArgumentNullException(nameof(businessPosition));

            using ContactBookContext context = new ContactBookContext();

            BusinessPosition? businessPositionDelete = context.BusinessPositions.FirstOrDefault(b => b.BusinessPositionId == businessPosition.BusinessPositionId);
            if (businessPositionDelete is not null)
            {
                context.BusinessPositions.Remove(businessPositionDelete);
                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se elimino la posición con éxito.");
            }
            else
            {
                responseInformation.ConfigureFailureResponseInformation("No se encontró la posición.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }
}

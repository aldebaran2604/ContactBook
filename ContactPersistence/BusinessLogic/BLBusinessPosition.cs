using UtilityLibrary.Interfaces;
using UtilityLibrary.Helpers;
using UtilityLibrary;
using ContactPersistence.Models;

namespace ContactPersistence.BusinessLogic;

/// <summary>
/// Static class that exposes methods to query, add, edit, and delete positions
/// </summary>
public static class BLBusinessPosition
{
    /// <summary>
    /// Get list of positions
    /// </summary>
    /// <returns>Error information and positions</returns>
    public static IResponseInformation<BusinessPosition[]> ListBusinessPosition()
    {
        IResponseInformation<BusinessPosition[]> responseInformation = new ResponseInformation<BusinessPosition[]>();
        try
        {
            using ContactBookContext context = new ContactBookContext();
            BusinessPosition[] businessPositions = context.BusinessPositions.ToArray() ?? Array.Empty<BusinessPosition>();
            responseInformation.ConfigureSuccess("Se realizo la consulta con éxito.", businessPositions);
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Add new position
    /// </summary>
    /// <param name="businessPosition">Data new position</param>
    /// <returns>Error information</returns>
    public static IResponseInformation AddBusinessPosition(BusinessPosition businessPosition)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (businessPosition is null) throw new ArgumentNullException(nameof(businessPosition));

            using ContactBookContext context = new ContactBookContext();

            context.BusinessPositions.Add(businessPosition);
            context.SaveChanges();
            responseInformation.ConfigureSuccess($"Se guardo con éxito la posición.");
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Edit an existing position
    /// </summary>
    /// <param name="businessPosition">Data update position</param>
    /// <returns>Error information and position data</returns>
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
                responseInformation.ConfigureSuccess("Se guardo con éxito la posición.", businessPositionQuery);
            }
            else
            {
                responseInformation.ConfigureFailure("No se encontró la posición.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Delete existing position
    /// </summary>
    /// <param name="businessPosition">Data position</param>
    /// <returns>Error information</returns>

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
                responseInformation.ConfigureSuccess("Se elimino la posición con éxito.");
            }
            else
            {
                responseInformation.ConfigureFailure("No se encontró la posición.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }
}

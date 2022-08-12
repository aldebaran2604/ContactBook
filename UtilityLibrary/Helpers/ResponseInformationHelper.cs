using UtilityLibrary.Interfaces;

namespace UtilityLibrary.Helpers;

/// <summary>
/// Helper to configure the ResponseInformation
/// </summary>
public static class ResponseInformationHelper
{
    public static void ConfigureSuccess(this IResponseInformation? responseInformation, string? message)
    {
        if(responseInformation is null) return;

        responseInformation.Success = true;
        responseInformation.Message = message;
    }

    public static void ConfigureSuccess<T>(this IResponseInformation<T>? responseInformation, string? message, T? resultItem)
    {
        if(responseInformation is null) return;

        responseInformation.ConfigureSuccess(message);
        responseInformation.ResultItem = resultItem;
    }

    public static void ConfigureFailure(this IResponseInformation? responseInformation, string message)
    {
        if(responseInformation is null) return;

        responseInformation.Success = false;
        responseInformation.Message = message;
    }

    public static void ConfigureFailure<T>(this IResponseInformation<T>? responseInformation, string message, T resultItem)
    {
        if(responseInformation is null) return;
        
        responseInformation.ConfigureFailure(message);
        responseInformation.ResultItem = resultItem;
    }
}

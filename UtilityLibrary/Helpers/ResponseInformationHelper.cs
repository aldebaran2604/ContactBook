using UtilityLibrary.Interfaces;

namespace UtilityLibrary.Helpers;

public static class ResponseInformationHelper
{
    public static void ConfigureSuccessResponseInformation(this IResponseInformation responseInformation, string? message)
    {
        responseInformation.Success = true;
        responseInformation.Message = message;
    }

    public static void ConfigureSuccessResponseInformation<T>(this IResponseInformation<T> responseInformation, string? message, T resultItem)
    {
        responseInformation.ConfigureSuccessResponseInformation(message);
        responseInformation.ResultItem = resultItem;
    }

    public static void ConfigureFailureResponseInformation(this IResponseInformation responseInformation, string? message)
    {
        responseInformation.Success = false;
        responseInformation.Message = message;
    }

    public static void ConfigureFailureResponseInformation<T>(this IResponseInformation<T> responseInformation, string? message, T? resultItem)
    {
        responseInformation.ConfigureFailureResponseInformation(message);
        responseInformation.ResultItem = resultItem;
    }
}

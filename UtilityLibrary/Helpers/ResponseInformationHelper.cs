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
        responseInformation.Success = true;
        responseInformation.Message = message;
        responseInformation.ResultItem = resultItem;
    }
}

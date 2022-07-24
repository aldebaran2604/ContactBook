using UtilityLibrary.Interfaces;

namespace UtilityLibrary;

/// <summary>
/// Class that contains information about the success or error and result item response
/// </summary>
public class ResponseInformation<T> : ResponseInformation,IResponseInformation<T>
{
    public T? ResultItem { get; set; }
}

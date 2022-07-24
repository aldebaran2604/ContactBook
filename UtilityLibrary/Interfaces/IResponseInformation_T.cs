namespace UtilityLibrary.Interfaces;

/// <summary>
/// Interface that contains properties with success or error and result item information.
/// </summary>
public interface IResponseInformation<T> : IResponseInformation
{
    T? ResultItem { get; set; }
}

namespace UtilityLibrary.Interfaces;

/// <summary>
/// Interface that contains properties with success or error information.
/// </summary>
public interface IResponseInformation
{
    bool Success { get; set; }

    string? Message { get; set; }

    bool Failure { get; }
}
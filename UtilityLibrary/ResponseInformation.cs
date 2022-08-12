using UtilityLibrary.Interfaces;

namespace UtilityLibrary;

/// <summary>
/// Class that contains information about the success or error response
/// </summary>
public class ResponseInformation : IResponseInformation
{
    #region Properties

    public bool Success { get; set; }

    public string? Message { get; set; }

    public bool Failure { get=> !Success; }
    
    #endregion

    #region Constructors

    public ResponseInformation()
    {
        Success = true;
    }

    public ResponseInformation(bool success, string? message)
    {
        Success = success;
        Message = message;
    }
    
    #endregion
}

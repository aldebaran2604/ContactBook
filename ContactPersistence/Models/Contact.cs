
namespace ContactPersistence.Models;

public class Contact
{
    public int ContactId { get; set; }
    public string? Names { get; set; }
    public string? LastNames { get; set; }
    public string? Pseudonymous { get; set; }
    public string? CompanyName { get; set; }
    public int? BusinessPositionID { get; set; }
    public BusinessPosition? BusinessPosition { get; set; }
    public int? BusinessDepartmentId { get; set; }
    public BusinessDepartment? BusinessDepartment { get; set; }
}
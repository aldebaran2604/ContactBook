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

    public string? Email { get; set; }

    public string? PhoneNumber { get; set; }

    public string? Country { get; set; }

    public string? StreetDirection1 { get; set; }

    public string? StreetDirection2 { get; set; }

    public string? PostalCode { get; set; }

    public string? City { get; set; }

    public string? State { get; set; }

    public DateTime? Birthday { get; set; }

    public string? WebSite { get; set; }

    public string? Relationship { get; set; }

    public string? TypeRelationship { get; set; }

    public string? Notes { get; set; }
}

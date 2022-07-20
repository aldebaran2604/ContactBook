
namespace ContactPersistence.Models;

public class BusinessDepartment
{
    public int BusinessDepartmentId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Contact>? Contacts { get; set; }
}
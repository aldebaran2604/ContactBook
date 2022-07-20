
namespace ContactPersistence.Models;

public class BusinessPosition
{
    public int BusinessPositionId { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public ICollection<Contact>? Contacts { get; set; }
}
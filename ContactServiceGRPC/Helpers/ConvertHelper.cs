using ContactPersistence.Models;

namespace ContactServiceGRPC.Helpers;

internal static class ConvertHelper
{
    internal static ContactModel ConvertContactToContactModel(Contact contact)
    {
        BusinessDepartmentModel? businessDepartmentModel = null;
        if (contact.BusinessDepartment is not null)
        {
            businessDepartmentModel = new BusinessDepartmentModel()
            {
                BusinessDepartmentId = contact.BusinessDepartment.BusinessDepartmentId,
                Name = contact.BusinessDepartment.Name,
                Description = contact.BusinessDepartment.Description
            };
        }
        BusinessPositionModel? businessPositionModel = null;
        if (contact.BusinessPosition is not null)
        {
            businessPositionModel = new BusinessPositionModel()
            {
                BusinessPositionId = contact.BusinessPosition.BusinessPositionId,
                Name = contact.BusinessPosition.Name,
                Description = contact.BusinessPosition.Description
            };
        }
        Google.Protobuf.WellKnownTypes.Timestamp? birthday = null;
        if (contact.Birthday is not null)
        {
            birthday = Google.Protobuf.WellKnownTypes.Timestamp.FromDateTime(contact.Birthday.Value);
        }
        ContactModel contactModel = new ContactModel()
        {
            ContactId = contact.ContactId,
            Names = contact.Names,
            LastNames = contact.LastNames,
            Pseudonymous = contact.Pseudonymous,
            CompanyName = contact.CompanyName,
            BusinessDepartmentId = contact.BusinessDepartmentId,
            BusinessDepartment = businessDepartmentModel,
            BusinessPositionID = contact.BusinessPositionID,
            BusinessPosition = businessPositionModel,
            Email = contact.Email,
            PhoneNumber = contact.PhoneNumber,
            Country = contact.Country,
            StreetDirection1 = contact.StreetDirection1,
            StreetDirection2 = contact.StreetDirection2,
            PostalCode = contact.PostalCode,
            City = contact.City,
            State = contact.State,
            Birthday = birthday,
            WebSite = contact.WebSite,
            Relationship = contact.Relationship,
            TypeRelationship = contact.TypeRelationship,
            Notes = contact.Notes
        };
        return contactModel;
    }
}
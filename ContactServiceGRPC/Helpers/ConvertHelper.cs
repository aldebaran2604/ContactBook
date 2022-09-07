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

    internal static Contact ConvertContactModelToContact(ContactModel contactModel)
    {
        BusinessDepartment? businessDepartment = null;
        if (contactModel.BusinessDepartment is not null)
        {
            businessDepartment = ConvertBusinessDepartmentModelToBusinessDepartment(contactModel.BusinessDepartment);
        }
        BusinessPosition? businessPosition = null;
        if (contactModel.BusinessPosition is not null)
        {
            businessPosition = ConvertBusinessPositionModelToBusinessPosition(contactModel.BusinessPosition);
        }
        DateTime? birthday = null;
        if (contactModel.Birthday is not null)
        {
            birthday = contactModel.Birthday.ToDateTime();
        }
        Contact contact = new Contact()
        {
            ContactId = contactModel.ContactId,
            Names = contactModel.Names,
            LastNames = contactModel.LastNames,
            Pseudonymous = contactModel.Pseudonymous,
            CompanyName = contactModel.CompanyName,
            BusinessDepartmentId = contactModel.BusinessDepartmentId,
            BusinessDepartment = businessDepartment,
            BusinessPositionID = contactModel.BusinessPositionID,
            BusinessPosition = businessPosition,
            Email = contactModel.Email,
            PhoneNumber = contactModel.PhoneNumber,
            Country = contactModel.Country,
            StreetDirection1 = contactModel.StreetDirection1,
            StreetDirection2 = contactModel.StreetDirection2,
            PostalCode = contactModel.PostalCode,
            City = contactModel.City,
            State = contactModel.State,
            Birthday = birthday,
            WebSite = contactModel.WebSite,
            Relationship = contactModel.Relationship,
            TypeRelationship = contactModel.TypeRelationship,
            Notes = contactModel.Notes
        };
        return contact;
    }

    internal static BusinessDepartment ConvertBusinessDepartmentModelToBusinessDepartment(BusinessDepartmentModel businessDepartmentModel)
    {
        BusinessDepartment businessDepartment = new BusinessDepartment()
        {
            BusinessDepartmentId = businessDepartmentModel.BusinessDepartmentId,
            Name = businessDepartmentModel.Name,
            Description = businessDepartmentModel.Description
        };

        return businessDepartment;
    }

    internal static BusinessPosition ConvertBusinessPositionModelToBusinessPosition(BusinessPositionModel businessPositionModel)
    {
        BusinessPosition businessPosition = new BusinessPosition()
        {
            BusinessPositionId = businessPositionModel.BusinessPositionId,
            Name = businessPositionModel.Name,
            Description = businessPositionModel.Description
        };

        return businessPosition;
    }
}
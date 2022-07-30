using ContactPersistence.Models;
using UtilityLibrary;
using UtilityLibrary.Helpers;
using UtilityLibrary.Interfaces;

namespace ContactPersistence.BusinessLogic;
public static class BLContact
{
    public static IResponseInformation<Contact[]> ListContacts()
    {
        IResponseInformation<Contact[]> responseInformation = new ResponseInformation<Contact[]>();
        try
        {
            using ContactBookContext context = new ContactBookContext();
            Contact[] contacts =  context.Contacts.ToArray() ?? Array.Empty<Contact>();
            responseInformation.ConfigureSuccessResponseInformation("Se realizo la consulta con éxito.", contacts);
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation AddContact(Contact contact)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if(contact is null) throw new ArgumentNullException(nameof(contact));
            
            using ContactBookContext context = new ContactBookContext();
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation<Contact> EditContact(Contact contact)
    {
        IResponseInformation<Contact> responseInformation = new ResponseInformation<Contact>();
        try
        {
            if(contact is null) throw new ArgumentNullException(nameof(contact));

            using ContactBookContext context = new ContactBookContext();
            Contact? contactQuery = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            if(contactQuery is not null)
            {
                contactQuery.Names = contact.Names;
                contactQuery.LastNames = contact.LastNames;
                contactQuery.Pseudonymous = contact.Pseudonymous;
                contactQuery.CompanyName = contact.CompanyName;
                contactQuery.BusinessPositionID = contact.BusinessPositionID;
                contactQuery.BusinessPosition = contact.BusinessPosition;
                contactQuery.BusinessDepartmentId = contact.BusinessDepartmentId;
                contactQuery.BusinessDepartment = contact.BusinessDepartment;
                contactQuery.Email = contact.Email;
                contactQuery.Country = contact.Country;
                contactQuery.StreetDirection1 = contact.StreetDirection1;
                contactQuery.StreetDirection2 = contact.StreetDirection2;
                contactQuery.PostalCode = contact.PostalCode;
                contactQuery.City = contact.City;
                contactQuery.State = contact.State;
                contactQuery.Birthday = contact.Birthday;
                contactQuery.WebSite = contact.WebSite;
                contactQuery.Relationship = contact.Relationship;
                contactQuery.TypeRelationship = contact.TypeRelationship;
                contactQuery.Notes = contact.Notes;

                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se actualizo con éxito el contacto.", contactQuery);
            }
            else
            {
                responseInformation.ConfigureFailureResponseInformation("No se encontró el contacto.");
            }
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }

    public static IResponseInformation DeleteContact(Contact contact)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if(contact is null) throw new ArgumentNullException(nameof(contact));

            using ContactBookContext context = new ContactBookContext();

            Contact? contactQuery = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            if(contactQuery is not null)
            {
                context.Contacts.Remove(contactQuery);
                context.SaveChanges();
                responseInformation.ConfigureSuccessResponseInformation("Se elimino el contacto con éxito.");
            }
            else
            {
                responseInformation.ConfigureFailureResponseInformation("No se encontró el contacto.");
            }
        }
        catch(Exception ex)
        {
            responseInformation.ConfigureFailureResponseInformation(ex.Message);
        }
        return responseInformation;
    }
}
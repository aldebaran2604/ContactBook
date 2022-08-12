using ContactPersistence.Models;
using UtilityLibrary;
using UtilityLibrary.Helpers;
using UtilityLibrary.Interfaces;

namespace ContactPersistence.BusinessLogic;

/// <summary>
/// Static class that exposes methods to query, add, edit, and delete contacts
/// </summary>
public static class BLContact
{
    /// <summary>
    /// Get list of contacts
    /// </summary>
    /// <returns>Error information and contacts</returns>
    public static IResponseInformation<Contact[]> ListContacts()
    {
        IResponseInformation<Contact[]> responseInformation = new ResponseInformation<Contact[]>();
        try
        {
            using ContactBookContext context = new ContactBookContext();
            Contact[] contacts = context.Contacts.ToArray() ?? Array.Empty<Contact>();
            responseInformation.ConfigureSuccess("Se realizo la consulta con éxito.", contacts);
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Add new contact
    /// </summary>
    /// <param name="contact">Data new contact</param>
    /// <returns>Error information</returns>
    public static IResponseInformation AddContact(Contact contact)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (contact is null) throw new ArgumentNullException(nameof(contact));

            using ContactBookContext context = new ContactBookContext();
            context.Contacts.Add(contact);
            context.SaveChanges();
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Edit an existing contact
    /// </summary>
    /// <param name="contact">Data update contact</param>
    /// <returns>Error information and contact data</returns>
    public static IResponseInformation<Contact> EditContact(Contact contact)
    {
        IResponseInformation<Contact> responseInformation = new ResponseInformation<Contact>();
        try
        {
            if (contact is null) throw new ArgumentNullException(nameof(contact));

            using ContactBookContext context = new ContactBookContext();
            Contact? contactQuery = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            if (contactQuery is not null)
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
                responseInformation.ConfigureSuccess("Se actualizo con éxito el contacto.", contactQuery);
            }
            else
            {
                responseInformation.ConfigureFailure("No se encontró el contacto.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }

    /// <summary>
    /// Delete existing contact
    /// </summary>
    /// <param name="contact">Data contact</param>
    /// <returns>Error information</returns>
    public static IResponseInformation DeleteContact(Contact contact)
    {
        IResponseInformation responseInformation = new ResponseInformation();
        try
        {
            if (contact is null) throw new ArgumentNullException(nameof(contact));

            using ContactBookContext context = new ContactBookContext();

            Contact? contactQuery = context.Contacts.FirstOrDefault(c => c.ContactId == contact.ContactId);
            if (contactQuery is not null)
            {
                context.Contacts.Remove(contactQuery);
                context.SaveChanges();
                responseInformation.ConfigureSuccess("Se elimino el contacto con éxito.");
            }
            else
            {
                responseInformation.ConfigureFailure("No se encontró el contacto.");
            }
        }
        catch (Exception ex)
        {
            responseInformation.ConfigureFailure(ex.Message);
        }
        return responseInformation;
    }
}

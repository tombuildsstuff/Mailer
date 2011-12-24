using System;
using System.Collections.Generic;
using System.Linq;
using Google.Contacts;
using Google.GData.Client;
using Contact = Mailer.Entities.Contact;
using GoogleContact = Google.Contacts.Contact;

namespace Mailer.Repositories.Google
{
    public class GoogleContactsRepository : IContactsRepository
    {
        private readonly RequestSettings _settings;
        public GoogleContactsRepository(AbstractContactsConfiguration credentials)
        {
            _settings = new RequestSettings(credentials.ApplicationName, credentials.Username, credentials.Password)
                            {
                                AutoPaging = true
                            };
        }

        public IEnumerable<Contact> GetAllInGroup(string groupId)
        {
            var contactRequest = new ContactsRequest(_settings);
            var googleContacts = contactRequest.GetContacts().Entries.Where(c => !c.Deleted && IsInGroup(c, groupId)).OrderBy(c => c.Name.FamilyName).ToList();
            return googleContacts.Select(ParseGoogleContact).Where(c => c != null).ToList();
        }

        public IEnumerable<Contact> GetAllInGroups(IEnumerable<string> groupIds)
        {
            var contactRequest = new ContactsRequest(_settings);
            var googleContacts = contactRequest.GetContacts().Entries.Where(c => !c.Deleted && groupIds.All(gid => IsInGroup(c, gid))).OrderBy(c => c.Name.FamilyName).ToList();
            return googleContacts.Select(ParseGoogleContact).Where(c => c != null).ToList();
        }

        public IEnumerable<Contact> GetAll()
        {
            var contactRequest = new ContactsRequest(_settings);
            var googleContacts = contactRequest.GetContacts().Entries.Where(c => !c.Deleted).OrderBy(c => c.Name.FamilyName).ToList();
            return googleContacts.Select(ParseGoogleContact).Where(c => c != null).ToList();
        }

        private static bool IsInGroup(GoogleContact contact, string groupId)
        {
            return contact.GroupMembership.Any(gm => gm.HRef == groupId);
        }

        private static Contact ParseGoogleContact(GoogleContact googleContact)
        {
            if (googleContact == null || googleContact.Deleted)
                return null;

            var contact = new Contact
            {
                Forename = googleContact.ContactEntry.Name.GivenName,
                Surname = googleContact.ContactEntry.Name.FamilyName,
            };

            DateTime date;
            if (DateTime.TryParse(googleContact.ContactEntry.Birthday, out date))
                contact.DateOfBirth = date;

            var gender = googleContact.ContactEntry.Websites.Where(c => c.Label == "Gender").FirstOrDefault();
            if (gender != null)
                contact.Gender = gender.Href.StartsWith("F", StringComparison.InvariantCultureIgnoreCase) ? Contact.Sex.Female : Contact.Sex.Male;

            return contact;
        }
    }
}
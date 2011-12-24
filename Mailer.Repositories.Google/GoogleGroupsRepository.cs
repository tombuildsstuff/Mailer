using System.Collections.Generic;
using System.Linq;
using Google.Contacts;
using Google.GData.Client;
using Group = Mailer.Entities.Group;
using GoogleGroup = Google.Contacts.Group;

namespace Mailer.Repositories.Google
{
    public class GoogleGroupsRepository : IGroupsRepository
    {
        private readonly RequestSettings _settings;
        public GoogleGroupsRepository(string applicationName, string email, string password)
        {
            _settings = new RequestSettings(applicationName, email, password) { AutoPaging = true };
        }

        public List<Group> GetAll()
        {
            var request = new ContactsRequest(_settings);
            var groups = request.GetGroups().Entries;
            return groups.Select(ParseGroup).ToList();
        }

        private static Group ParseGroup(GoogleGroup group)
        {
            return new Group
            {
                Id = group.AtomEntry.Id.AbsoluteUri,
                Name = group.Title
            };
        }
    }
}
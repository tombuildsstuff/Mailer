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
        public GoogleGroupsRepository(AbstractContactsConfiguration credentials)
        {
            _settings = new RequestSettings(credentials.ApplicationName, credentials.Username, credentials.Password)
                            {
                                AutoPaging = true
                            };
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
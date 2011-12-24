using System.Collections.Generic;
using Mailer.Entities;

namespace Mailer.Repositories
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetAllInGroup(string groupId);

        IEnumerable<Contact> GetAllInGroups(IEnumerable<string> groupIds);
        
        IEnumerable<Contact> GetAll();
    }
}
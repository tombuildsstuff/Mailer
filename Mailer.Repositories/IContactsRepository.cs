using System.Collections.Generic;
using Mailer.Entities;

namespace Mailer.Repositories
{
    public interface IContactsRepository
    {
        IEnumerable<Contact> GetAll();
    }
}
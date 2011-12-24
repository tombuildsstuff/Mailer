using System.Collections.Generic;
using Mailer.Entities;

namespace Mailer.Repositories
{
    public interface IGroupsRepository
    {
        List<Group> GetAll();
    }
}
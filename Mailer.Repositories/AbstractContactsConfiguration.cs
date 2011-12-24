using System.Collections.Generic;

namespace Mailer.Repositories
{
    public abstract class AbstractContactsConfiguration
    {
        public string ApplicationName { get; protected set; }

        public string Username { get; protected set; }

        public string Password { get; protected set; }

        public string MaleMessage { get; protected set; }

        public string FemaleMessage { get; protected set; }

        public IEnumerable<string> GroupsToMessage { get; protected set; }
    }
}
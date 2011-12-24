using System.Collections.Generic;
using System.Configuration;

namespace Mailer.Repositories.Google
{
    public class GoogleContactsConfiguration
    {
        public string GoogleUsername { get { return ConfigurationManager.AppSettings["GoogleUsername"]; } }

        public string GooglePassword { get { return ConfigurationManager.AppSettings["GooglePassword"]; } }

        public string MaleTextMessage { get { return ConfigurationManager.AppSettings["MaleTextMessage"]; } }

        public string FemaleTextMessage { get { return ConfigurationManager.AppSettings["FemaleTextMessage"]; } }

        public IEnumerable<string> GroupsToMessage { get { return ConfigurationManager.AppSettings["GroupsToMessage"].Split(','); } }
    }
}
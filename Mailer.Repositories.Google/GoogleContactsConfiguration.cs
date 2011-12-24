using System.Configuration;

namespace Mailer.Repositories.Google
{
    public class GoogleContactsConfiguration : AbstractContactsConfiguration
    {
        public GoogleContactsConfiguration()
        {
            Username = ConfigurationManager.AppSettings["GoogleUsername"];
            Password = ConfigurationManager.AppSettings["GooglePassword"];
            MaleMessage = ConfigurationManager.AppSettings["MaleTextMessage"];
            FemaleMessage = ConfigurationManager.AppSettings["FemaleTextMessage"];
            GroupsToMessage = ConfigurationManager.AppSettings["GroupsToMessage"].Split(',');
        }
    }
}
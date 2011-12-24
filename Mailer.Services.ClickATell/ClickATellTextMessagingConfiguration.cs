using System.Configuration;

namespace Mailer.Services.ClickATell
{
    public class ClickATellTextMessagingConfiguration : AbstractTextMessagingConfiguration
    {
        public ClickATellTextMessagingConfiguration()
        {
            Username = ConfigurationManager.AppSettings["ClickATellUser"];
            Password = ConfigurationManager.AppSettings["ClickATellPass"];
            ApiId = int.Parse(ConfigurationManager.AppSettings["ClickATellApiId"]);
            Sender = ConfigurationManager.AppSettings["ClickATellSender"];
        }
    }
}
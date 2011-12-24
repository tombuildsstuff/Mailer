using System.Configuration;

namespace Mailer.Services.ClickATell
{
    public class ClickATellTextMessagingConfiguration
    {
        public string Username { get { return ConfigurationManager.AppSettings["ClickATellUser"]; } }

        public string Password { get { return ConfigurationManager.AppSettings["ClickATellPass"]; } }

        public int ApiId { get { return int.Parse(ConfigurationManager.AppSettings["ClickATellApiId"]); } }

        public string Sender { get { return ConfigurationManager.AppSettings["ClickATellSender"]; } }
    }
}
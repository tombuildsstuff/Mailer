namespace Mailer.Services
{
    public abstract class AbstractTextMessagingConfiguration
    {
        public string Username { get; protected set; }

        public string Password { get; protected set; }

        public int ApiId { get; protected set; }

        public string Sender { get; protected set; }
    }
}
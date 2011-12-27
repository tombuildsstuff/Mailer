using Mailer.Entities;
using Mailer.Services;

namespace Mailer.Fakes.Nullables
{
    public class NullTextMessagingService : ITextMessagingService
    {
        public void Send(TextMessage message)
        {
        }
    }
}
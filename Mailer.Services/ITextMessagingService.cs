using Mailer.Entities;

namespace Mailer.Services
{
    public interface ITextMessagingService
    {
        void Send(TextMessage message);
    }
}
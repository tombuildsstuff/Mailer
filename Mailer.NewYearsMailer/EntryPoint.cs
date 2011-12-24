using Mailer.Entities;
using Mailer.Services.ClickATell;

namespace Mailer.NewYearsMailer
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var service = new ClickATellTextMessagingService(new ClickATellTextMessagingConfiguration());
            service.Send(new TextMessage
                             {
                                 Number = "447870350450",
                                 Message = "Hi"
                             });
        }
    }
}
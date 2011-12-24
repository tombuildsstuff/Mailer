using System;
using Mailer.Nullables;
using Mailer.Repositories;
using Mailer.Repositories.Google;
using Mailer.Services;
using Mailer.Services.ClickATell;
using Ninject;

namespace Mailer.NewYearsMailer
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var container = new StandardKernel();
            container.Bind<AbstractContactsConfiguration>().ToConstant(new GoogleContactsConfiguration());
            container.Bind<AbstractTextMessagingConfiguration>().ToConstant(new ClickATellTextMessagingConfiguration());
            container.Bind<IContactsRepository>().To<GoogleContactsRepository>();
            container.Bind<IGroupsRepository>().To<GoogleGroupsRepository>();
            container.Bind<AbstractTextMessagingConfiguration>().To<ClickATellTextMessagingConfiguration>();

            // TODO: logging
            // BUG: proper services
            container.Bind<ITextMessagingService>().To<NullTextMessagingService>();

            var mailer = container.Get<NewYearsMailer>();
            mailer.GoGoNewYearsMailer();
            Console.WriteLine();
        }
    }
}
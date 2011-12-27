using System.Reflection;
using Mailer.Fakes.Nullables;
using Mailer.Repositories;
using Mailer.Repositories.Google;
using Mailer.Services;
using Mailer.Services.ClickATell;
using Ninject;
using log4net;

namespace Mailer.Domain.DependencyInjection
{
    public static class NinjectContainer
    {
        public static IKernel GetContainer(string applicationName)
        {
            var container = new StandardKernel();
            container.Bind<ILog>().ToConstant(LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType));
            container.Bind<AbstractContactsConfiguration>().ToConstant(new GoogleContactsConfiguration(applicationName));
            container.Bind<AbstractTextMessagingConfiguration>().ToConstant(new ClickATellTextMessagingConfiguration());
            container.Bind<AbstractTextMessagingConfiguration>().To<ClickATellTextMessagingConfiguration>();
            container.Bind<IContactsRepository>().To<GoogleContactsRepository>();
            container.Bind<IGroupsRepository>().To<GoogleGroupsRepository>();

            // BUG: proper services
            container.Bind<ITextMessagingService>().To<NullTextMessagingService>();

            return container;
        }
    }
}
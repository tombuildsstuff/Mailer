using System.Reflection;
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
            container.Bind<IContactsRepository>().To<GoogleContactsRepository>();
            container.Bind<IGroupsRepository>().To<GoogleGroupsRepository>();
            container.Bind<ITextMessagingService>().To<ClickATellTextMessagingService>();

            return container;
        }
    }
}
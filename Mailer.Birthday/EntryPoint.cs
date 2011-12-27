using System;
using Mailer.Domain.DependencyInjection;
using Mailer.Domain.Helpers;
using Mailer.Domain.Mailers;
using Ninject;

namespace Mailer.Birthday
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                var container = NinjectContainer.GetContainer("Birthday Mailer");
                var mailer = container.Get<BirthdayMailer>();
                mailer.GoGoGo();
            }
            catch (Exception ex)
            {
                ExceptionHelpers.WriteExceptionToLog(ex);
            }
        }
    }
}
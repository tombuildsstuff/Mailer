﻿using System;
using Mailer.Domain.DependencyInjection;
using Mailer.Domain.Helpers;
using Ninject;

namespace Mailer.NewYearsMailer
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            try
            {
                var container = NinjectContainer.GetContainer("New Years Mailer");
                var mailer = container.Get<Domain.Mailers.NewYearsMailer>();
                mailer.GoGoGo();
            }
            catch (Exception ex)
            {
                ExceptionHelpers.WriteExceptionToLog(ex);
            }
        }
    }
}
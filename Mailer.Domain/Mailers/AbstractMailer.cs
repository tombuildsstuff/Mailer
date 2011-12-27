using System.Collections.Generic;
using System.Linq;
using Mailer.Entities;
using log4net;

namespace Mailer.Domain.Mailers
{
    public abstract class AbstractMailer
    {
        protected readonly ILog Log;
        protected AbstractMailer(ILog log)
        {
            Log = log;
        }

        public abstract void GoGoGo();

        public void SendToMales(TextMessaging sender, List<Contact> contacts, string message)
        {
            var males = contacts.Where(c => c.Gender == Contact.Sex.Male).ToList();
            WriteInfoToLog(string.Format("Now sending to {0} Males..", males.Count));
            foreach (var contact in males)
            {
                var successful = sender.SendTextMessageToContact(contact, message);
                WriteInfoToLog(string.Format("Sending to {0} - {1}", contact.FullName, successful ? "Successful" : "FAILED"));
            }
        }

        public void SendToFemales(TextMessaging sender, List<Contact> contacts, string message)
        {
            var females = contacts.Where(c => c.Gender == Contact.Sex.Female).ToList();
            WriteInfoToLog(string.Format("Now sending to {0} Females..", females.Count));
            foreach (var contact in females)
            {
                var successful = sender.SendTextMessageToContact(contact, message);
                WriteInfoToLog(string.Format("Sending to {0} - {1}", contact.FullName, successful ? "Successful" : "FAILED"));
            }
        }

        public void WriteWarningToLog(string message)
        {
            Log.Warn(message);
        }

        public void WriteInfoToLog(string message)
        {
            Log.Info(message);
        }
    }
}
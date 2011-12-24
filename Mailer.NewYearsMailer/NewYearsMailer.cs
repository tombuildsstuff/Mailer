using System.Diagnostics;
using System.Linq;
using Mailer.Domain;
using Mailer.Entities;
using Mailer.Repositories;
using Mailer.Services;

namespace Mailer.NewYearsMailer
{
    public class NewYearsMailer
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly ITextMessagingService _textMessagingService;
        private readonly AbstractContactsConfiguration _contactsConfiguration;
        public NewYearsMailer(IContactsRepository contactsRepository, ITextMessagingService textMessagingService, AbstractContactsConfiguration contactsConfiguration)
        {
            _contactsRepository = contactsRepository;
            _textMessagingService = textMessagingService;
            _contactsConfiguration = contactsConfiguration;
        }

        public void GoGoNewYearsMailer()
        {
            var contacts = _contactsRepository.GetAllInGroups(_contactsConfiguration.GroupsToMessage).ToList();
            var sender = new TextMessaging(_textMessagingService);

            var males = contacts.Where(c => c.Gender == Contact.Sex.Male).ToList();
            var females = contacts.Where(c => c.Gender == Contact.Sex.Female).ToList();

            WriteLine(string.Format("Now sending to {0} Males..", males.Count));
            foreach (var contact in males)
            {
                var successful = sender.SendTextMessageToContact(contact, _contactsConfiguration.MaleMessage);
                WriteLine(string.Format("Sending to {0} - {1}", contact.FullName, successful ? "Successful" : "FAILED"));
            }

            WriteLine(string.Format("Now sending to {0} Females..", females.Count));
            foreach (var contact in females)
            {
                var successful = sender.SendTextMessageToContact(contact, _contactsConfiguration.FemaleMessage);
                WriteLine(string.Format("Sending to {0} - {1}", contact.FullName, successful ? "Successful" : "FAILED"));
            }
        }

        private static void WriteLine(string line)
        {
            Debug.WriteLine(line);
            // TODO: string.Format("Sending to {0} - {1}", contact.FullName, successful ? "Successful" : "FAILED")
        }
    }
}
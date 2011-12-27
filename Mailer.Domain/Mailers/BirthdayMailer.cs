using System;
using System.Collections.Generic;
using System.Linq;
using Mailer.Domain.Helpers;
using Mailer.Entities;
using Mailer.Repositories;
using Mailer.Services;
using log4net;

namespace Mailer.Domain.Mailers
{
    public class BirthdayMailer : AbstractMailer
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IGroupsRepository _groupsRepository;
        private readonly ITextMessagingService _textMessagingService;
        private readonly AbstractContactsConfiguration _contactsConfiguration;

        public BirthdayMailer(IContactsRepository contactsRepository,
                              IGroupsRepository groupsRepository,
                              ITextMessagingService textMessagingService,
                              AbstractContactsConfiguration contactsConfiguration,
                              ILog log) : base(log)
        {
            _contactsRepository = contactsRepository;
            _groupsRepository = groupsRepository;
            _textMessagingService = textMessagingService;
            _contactsConfiguration = contactsConfiguration;
        }

        public override void GoGoGo()
        {
            var groupNames = _contactsConfiguration.GroupsToMessage;
            var groups = _groupsRepository.GetAll()
                                          .Where(g => groupNames.Any(gn => gn.Equals(g.Name, StringComparison.InvariantCultureIgnoreCase)))
                                          .Select(g => g.Id)
                                          .ToList();
            var contacts = GetContactsWithBirthdaysToday(_contactsRepository.GetAllInGroups(groups).ToList());
            var sender = new TextMessaging(_textMessagingService);

            SendToMales(sender, contacts, _contactsConfiguration.MaleMessage);
            SendToFemales(sender, contacts, _contactsConfiguration.FemaleMessage);
        }

        public List<Contact> GetContactsWithBirthdaysToday(List<Contact> contacts)
        {
            var today = DateTime.Now.ToStartOfDay();
            return contacts.Where(c => c.DateOfBirth.HasValue && c.DateOfBirth.Value.ToStartOfDay() == today).ToList();
        }
    }
}
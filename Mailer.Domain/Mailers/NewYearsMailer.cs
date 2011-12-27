using System;
using System.Linq;
using Mailer.Repositories;
using Mailer.Services;
using log4net;

namespace Mailer.Domain.Mailers
{
    public class NewYearsMailer : AbstractMailer
    {
        private readonly IContactsRepository _contactsRepository;
        private readonly IGroupsRepository _groupsRepository;
        private readonly ITextMessagingService _textMessagingService;
        private readonly AbstractContactsConfiguration _contactsConfiguration;

        public NewYearsMailer(IContactsRepository contactsRepository,
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
            var contacts = _contactsRepository.GetAllInGroups(groups).ToList();
            var sender = new TextMessaging(_textMessagingService);
            SendToMales(sender, contacts, _contactsConfiguration.MaleMessage);
            SendToFemales(sender, contacts, _contactsConfiguration.FemaleMessage);
        }
    }
}
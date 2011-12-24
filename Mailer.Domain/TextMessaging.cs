using System;
using System.Collections.Generic;
using System.Linq;
using Mailer.Entities;
using Mailer.Services;

namespace Mailer.Domain
{
    public class TextMessaging
    {
        private readonly ITextMessagingService _textingService;
        public TextMessaging(ITextMessagingService textingService)
        {
            _textingService = textingService;
        }

        public IEnumerable<bool> SendTextMessageToContacts(IEnumerable<Contact> contacts, string message)
        {
            return contacts.Select(c => SendTextMessageToContact(c, message)).ToList();
        }

        public bool SendTextMessageToContact(Contact contact, string message)
        {
            throw new NotImplementedException();
        }
    }
}
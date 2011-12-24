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
            try {
                var number = DetermineMobileNumber(contact.MobileNumber);
                var text = SwapOutPhrases(contact, message);
                var textMessage = new TextMessage(number, text);
                _textingService.Send(textMessage);
                return true;
            } catch (InvalidOperationException) {
                return false;
            }
        }

        public static string DetermineMobileNumber(string input)
        {
            if (string.IsNullOrWhiteSpace(input))
                throw new InvalidOperationException();

            var number = input.Replace(" ", "").Replace("+", "").Trim();
            return string.Format("44{0}", number.StartsWith("0") ? number.Substring(1) : number.StartsWith("44") ? number.Substring(2) : number);
        }

        public static string SwapOutPhrases(Contact contact, string input)
        {
            return input.Trim()
                        .Replace("[forename]", contact.Forename)
                        .Replace("[surname]", contact.Surname)
                        .Replace("[fullname]", contact.FullName)
                        .Replace("[year]", DateTime.Now.AddYears(1).Year.ToString());
        }
    }
}
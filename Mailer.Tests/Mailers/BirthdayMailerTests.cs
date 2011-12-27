using System;
using System.Collections.Generic;
using Mailer.Domain.Mailers;
using Mailer.Entities;
using NUnit.Framework;

namespace Mailer.Tests.Mailers
{
    [TestFixture]
    public class BirthdayMailerTests
    {
        [Test]
        [Ignore("Not Yet Implemented")]
        public void BirthdayMailerDoesSendMessagesToContactsInSelectedGroups()
        {
            
        }

        [Test]
        public void GetContactsWithBirthdaysTodayDoesReturnContactsWithBirthdaysToday()
        {
            var contacts = new List<Contact>
                               {
                                   new Contact { Forename = "Kermit", Surname = "Frog", Gender = Contact.Sex.Female, DateOfBirth = new DateTime(1974, 10, 13), MobileNumber = "+1555858414" },
                                   new Contact { Forename = "Miss", Surname = "Piggy", Gender = Contact.Sex.Female, DateOfBirth = new DateTime(1974, 10, 13), MobileNumber = "+1555858414" }
                               };
            var contactsWithBirthdaysToday = new[] { new Contact { Forename = "Some", Surname = "Character", Gender = Contact.Sex.Female, DateOfBirth = DateTime.Now, MobileNumber = "+1555858414" } };
            contacts.AddRange(contactsWithBirthdaysToday);

            var mailer = new BirthdayMailer(null, null, null, null, null);
            var result = mailer.GetContactsWithBirthdaysToday(contacts);
            Assert.AreEqual(contactsWithBirthdaysToday, result);
        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void BirthdayMailerDoesSendMaleMessageToMales()
        {
            
        }

        [Test]
        [Ignore("Not Yet Implemented")]
        public void BirthdayMailerDoesSendFemaleMessageToFemales()
        {
            
        }
    }
}
using System;
using Mailer.Domain;
using Mailer.Entities;
using Mailer.Tests.Fakes;
using NUnit.Framework;

namespace Mailer.Tests.Domain
{
    [TestFixture]
    public class TextMessagingTests
    {
        [Test]
        public void TextMessaging_DoesReportError_WhenFailedSending()
        {
            var service = new TextMessaging(new FakeTextMessagingService(false));
            Assert.False(service.SendTextMessageToContact(new Contact(), ""));
        }

        [Test]
        public void TextMessaging_DoesReturnTrue_WhenSentSuccessfully()
        {
            var contact = new Contact
                          {
                              Forename = "Some",
                              Surname = "User",
                              DateOfBirth = DateTime.Now.AddYears(-1),
                              MobileNumber = "447870150140",
                              Gender = Contact.Sex.Male
                          };
            var service = new TextMessaging(new FakeTextMessagingService(true));
            Assert.True(service.SendTextMessageToContact(contact, "this is some message"));
        }
    }
}
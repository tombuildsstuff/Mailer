using System;
using Mailer.Entities;
using Mailer.Services;

namespace Mailer.Tests.Fakes
{
    public class FakeTextMessagingService : ITextMessagingService
    {
        private readonly bool _sentSuccessfully;
        public FakeTextMessagingService(bool sentSuccessfully)
        {
            _sentSuccessfully = sentSuccessfully;
        }

        public void Send(TextMessage message)
        {
            if (!_sentSuccessfully)
                throw new InvalidOperationException();
        }
    }
}
using System;
using System.Web;
using EasyHttp.Http;
using Mailer.Entities;

namespace Mailer.Services.ClickATell
{
    public class ClickATellTextMessagingService : ITextMessagingService
    {
        private readonly string _user;
        private readonly string _password;
        private readonly int _apiId;
        private readonly string _sender;
        public ClickATellTextMessagingService(ClickATellTextMessagingConfiguration config)
        {
            _user = config.Username;
            _password = config.Password;
            _apiId = config.ApiId;
            _sender = config.Sender;
        }

        public void Send(TextMessage message)
        {
            if (!message.IsValid())
                throw new ArgumentException("Invalid Message");

            var http = new HttpClient { Request = { Accept = HttpContentTypes.ApplicationJson } };
            var url = string.Format("http://api.clickatell.com/http/sendmsg?user={0}&password={1}&api_id={2}&{3}&to={4}&text={5}",
                                    _user,
                                    _password,
                                    _apiId,
                                    string.IsNullOrWhiteSpace(_sender) ? null : string.Format("&from={0}", _sender),
                                    HttpUtility.UrlEncode(message.Number),
                                    HttpUtility.UrlEncode(message.Message));
            http.Get(url);
        }
    }
}
namespace Mailer.Repositories.Google
{
    public class GoogleAccountCredentials
    {
        public string ApplicationName { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public GoogleAccountCredentials(string application, string username, string password)
        {
            ApplicationName = application;
            Username = username;
            Password = password;
        }
    }
}
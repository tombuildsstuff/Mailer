using System;
using System.Linq;
using Mailer.Entities;
using Mailer.Repositories.Google;
using Mailer.Services.ClickATell;

namespace Mailer.NewYearsMailer
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var googleCredentials = new GoogleContactsConfiguration();
            //var repository = new LocalFileSystemContactsRepository("C:\\Development\\Contacts.csv");
            var credentials = new GoogleAccountCredentials("New Years Mailer", googleCredentials.GoogleUsername, googleCredentials.GooglePassword);
            var contactsRepository = new GoogleContactsRepository(credentials);
            var groupsRepository = new GoogleGroupsRepository(credentials);
            var groupId = groupsRepository.GetAll().Where(g => g.Name == "Friends").FirstOrDefault().Id;
            var contacts = contactsRepository.GetAllInGroup(groupId);
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.FullName);
            }
            Console.ReadLine();
        }
    }
}
using System;
using System.Linq;
using Mailer.Repositories.Google;
using Mailer.Repositories.LocalFileSystem;

namespace Mailer.NewYearsMailer
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            //var repository = new LocalFileSystemContactsRepository("C:\\Development\\Contacts.csv");
            var credentials = new GoogleAccountCredentials("New Years Mailer", "tom@XXXXXX.co.uk", "XXXXXX");
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
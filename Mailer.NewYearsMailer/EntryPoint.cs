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
            var contactsRepository = new GoogleContactsRepository("New Years Mailer", "tom@XXXXXX.co.uk", "XXXXXX");
            var groupsRepository = new GoogleGroupsRepository("New Years Mailer", "tom@XXXXXX.co.uk", "XXXXXX");
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
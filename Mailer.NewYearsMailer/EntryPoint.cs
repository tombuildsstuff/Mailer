using System;
using Mailer.Repositories.LocalFileSystem;

namespace Mailer.NewYearsMailer
{
    public class EntryPoint
    {
        public static void Main(string[] args)
        {
            var repository = new LocalFileSystemContactsRepository("C:\\Development\\Contacts.csv");
            var contacts = repository.GetAll();
            foreach (var contact in contacts)
            {
                Console.WriteLine(contact.FullName);
            }
            Console.ReadLine();
        }
    }
}
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Mailer.Entities;

namespace Mailer.Repositories.LocalFileSystem
{
    public class LocalFileSystemContactsRepository : IContactsRepository
    {
        private readonly string _filePath;
        public LocalFileSystemContactsRepository(string filePath)
        {
            _filePath = filePath;
        }

        public IEnumerable<Contact> GetAllInGroup(string groupId)
        {
            return GetAll(); // we don't have a definition for groups in this context
        }

        public IEnumerable<Contact> GetAllInGroups(IEnumerable<string> groupIds)
        {
            return GetAll(); // we don't have a definition for groups in this context
        }

        public IEnumerable<Contact> GetAll()
        {
            var lines = File.ReadAllLines(_filePath);
            var contacts = lines.Skip(1).Select(ParseLine).Where(l => l != null).ToList(); // ignore the first row (headers)
            return contacts;
        }

        private static Contact ParseLine(string line)
        {
            if (string.IsNullOrWhiteSpace(line))
                return null;

            var columns = line.Split(',');

            return new Contact
            {
                Forename = columns[0],
                Surname = columns[1],
                DateOfBirth = DateTime.Parse(columns[2]),
                Gender = columns[3].StartsWith("M", StringComparison.InvariantCultureIgnoreCase) ? Contact.Sex.Male : Contact.Sex.Female,
                MobileNumber = columns[4]
            };
        }
    }
}
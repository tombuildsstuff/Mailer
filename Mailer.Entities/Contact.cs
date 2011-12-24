using System;

namespace Mailer.Entities
{
    public class Contact
    {
        public string Forename { get; set; }

        public string Surname { get; set; }

        public Sex Gender { get; set; }

        public string MobileNumber { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", Forename, Surname); }
        }

        public enum Sex
        {
            Male,
            Female
        }
    }
}
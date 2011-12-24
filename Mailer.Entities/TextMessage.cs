namespace Mailer.Entities
{
    public class TextMessage
    {
        public string Number { get; set; }

        public string Message { get; set; }

        public bool IsValid()
        {
            return !string.IsNullOrWhiteSpace(Number) &&
                   !string.IsNullOrWhiteSpace(Message) &&
                   160 > Message.Length;
        }
    }
}
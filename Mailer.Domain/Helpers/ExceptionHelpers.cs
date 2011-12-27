using System;
using System.IO;
using System.Text;

namespace Mailer.Domain.Helpers
{
    public static class ExceptionHelpers
    {
        public static void WriteExceptionToLog(Exception ex)
        {
            var contents = new StringBuilder();
            contents.AppendLine(ex.Message);
            contents.AppendFormat(ex.StackTrace);
            File.WriteAllText(string.Format("ErrorLog-{0}.txt", DateTime.Now.Ticks), contents.ToString(), Encoding.UTF8);
        }
    }
}
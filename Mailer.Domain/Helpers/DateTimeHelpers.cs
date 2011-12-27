using System;

namespace Mailer.Domain.Helpers
{
    public static class DateTimeHelpers
    {
        public static DateTime ToStartOfDay(this DateTime date)
        {
            return new DateTime(date.Year, date.Month, date.Day, 0, 0, 0, 0);
        }
    }
}
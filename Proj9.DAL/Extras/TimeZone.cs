using System;

namespace Proj9.DAL.Extras
{
    public class TimeZone
    {
        public static DateTime GetLocalDateTime()
        {
            TimeZoneInfo infotime = TimeZoneInfo.FindSystemTimeZoneById("Pakistan Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(DateTime.UtcNow, infotime);
        }
        public static double GetCurrentTimeStamp()
        {
            var dateTime = GetLocalDateTime();
            dateTime = new DateTime(
                                    dateTime.Ticks - (dateTime.Ticks % TimeSpan.TicksPerSecond),
                                    dateTime.Kind
                                    );

            return (dateTime - new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc)).TotalSeconds;
        }
    }
}
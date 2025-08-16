namespace ProvaPub.Utils
{
    public static class DateUtil
    {        
        public static DateTime ConvertFromUTCToBrazilianTimeZone(DateTime date)
        {
            TimeZoneInfo timeZone = TimeZoneInfo.FindSystemTimeZoneById("E. South America Standard Time");
            return TimeZoneInfo.ConvertTimeFromUtc(date, timeZone);
        }
    }
}

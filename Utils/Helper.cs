namespace ProvaPub.Utils
{
    public class Helper
    {
        public virtual bool IsOutsideWorkingHoursDays()
        {
            if (DateTime.UtcNow.Hour < 8 || DateTime.UtcNow.Hour > 18 ||
                DateTime.UtcNow.DayOfWeek == DayOfWeek.Saturday ||
                DateTime.UtcNow.DayOfWeek == DayOfWeek.Sunday)
            {
                return true;
            }
            return false;
        }
    }
}

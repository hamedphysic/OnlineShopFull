using System.Globalization;


namespace PublicTools.Tools
{
    public static class Calendar
    {
     public static string DateToPersian(this DateTime date)
        {
            var persian = new PersianCalendar();
            return $"{persian.GetYear(date)}/{persian.GetMonth(date)}/{persian.GetDayOfMonth(date)} {date.TimeOfDay}";
        }
        
    }
}

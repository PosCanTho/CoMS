using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using CoMS.Resources;

namespace CoMS.Untils
{
    public class DateTimeFormater
    {
        /*Tính ra thời gian đã trôi qua*/
        public static string GetTimeAgo(DateTime dateTime)
        {
            var timeSpan = DateTime.Now - dateTime;

            if (timeSpan <= TimeSpan.FromSeconds(60))
                return string.Format("{0} " + StringResource.Seconds_ago, timeSpan.Seconds);

            if (timeSpan <= TimeSpan.FromMinutes(60))
                return timeSpan.Minutes > 1 ? String.Format("{0} " + StringResource.Minutes_ago, timeSpan.Minutes) : StringResource.About_a_minute_ago;

            if (timeSpan <= TimeSpan.FromHours(24))
                return timeSpan.Hours > 1 ? String.Format("{0} " + StringResource.Hours_ago, timeSpan.Hours) : StringResource.About_an_hour_ago;

            if (timeSpan <= TimeSpan.FromDays(30))
                return timeSpan.Days > 1 ? String.Format("{0} " + StringResource.Days_ago, timeSpan.Days) : StringResource.Yesterday;

            if (timeSpan <= TimeSpan.FromDays(365))
                return timeSpan.Days > 30 ? String.Format("{0} " + StringResource.Months_ago, timeSpan.Days / 30) : StringResource.About_a_month_ago;

            return timeSpan.Days > 365 ? String.Format("{0} " + StringResource.Years_ago, timeSpan.Days / 365) : StringResource.About_a_year_ago;
        }
        /*Kiểm tra nhiều hơn 1 ngày*/
        public static bool CheckMoreThanOneDay(DateTime date, DateTime laterDate)
        {
            var timeSpan = date - laterDate;
            if (timeSpan.Days > 0) return true;
            return false;
        }

        public static bool CheckIsToday(DateTime date)
        {
            var timeSpan = date - DateTime.Now;
            if (timeSpan.Days == 0) return true;
            return false;
        }
    }
}
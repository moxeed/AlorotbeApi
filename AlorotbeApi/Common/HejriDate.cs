using System;
using System.Globalization;

namespace Alorotbe.Api.Common
{
    /// <summary>
    /// Summary description for HejriDate
    /// </summary>
    public static class HejriDate
    {
        public static string[] DaysFa = { "یکشنبه", "دوشنبه", "سه شنبه", "چهارشنبه", "پنجشنبه", "جمعه", "شنبه" };
        public static string[] DaysEn = { "Sunday", "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday" };

        public static string GetDayOfWeek(int dt)
        {
            var per = new PersianCalendar();
            DateTime date = ConvertToDateTime(dt);
            return DaysFa[(int)per.GetDayOfWeek(date)];
        }

        public static string GetDayOfWeek(DateTime? dt)
        {
            if (dt is null) return "-";
            var per = new PersianCalendar();
            return DaysFa[(int)per.GetDayOfWeek(dt.Value)];
        }

        public static int GetDayOfWeekNum(DateTime? dt)
        {
            if (dt is null) return 0;
            var per = new PersianCalendar();
            return (int)per.GetDayOfWeek(dt.Value);
        }

        public static string Convert2Hejri(DateTime dt, string splitor)
        {

            var per = new PersianCalendar();
            int day = per.GetDayOfMonth(dt);
            int month = per.GetMonth(dt);
            int year = per.GetYear(dt);
            string date = year.ToString(CultureInfo.InvariantCulture) + splitor + month.ToString("00", CultureInfo.InvariantCulture) + splitor + day.ToString("00", CultureInfo.InvariantCulture);
            return date;
        }

        public static string NullAbleDatetimeToHejri(DateTime? dt)
        {
            if (dt == null)
                return "ثبت نشده";

            return Convert2Hejri(dt.Value, "/");
        }
        public static string Convert2HejriDateString(DateTime dt)
        {

            var per = new PersianCalendar();
            int day = per.GetDayOfMonth(dt);
            int month = per.GetMonth(dt);
            string monthname = "";
            int year = per.GetYear(dt);

            switch (month)
            {
                case 1:
                    monthname = "فروردین";
                    break;
                case 2:
                    monthname = "اردیبهشت";
                    break;
                case 3:
                    monthname = "خرداد";
                    break;
                case 4:
                    monthname = "تیر";
                    break;
                case 5:
                    monthname = "مرداد";
                    break;
                case 6:
                    monthname = "شهریور";
                    break;
                case 7:
                    monthname = "مهر";
                    break;
                case 8:
                    monthname = "آبان";
                    break;
                case 9:
                    monthname = "آذر";
                    break;
                case 10:
                    monthname = "دی";
                    break;
                case 11:
                    monthname = "بهمن";
                    break;
                case 12:
                    monthname = "اسفند";
                    break;
            }

            string date = day.ToString("00", CultureInfo.InvariantCulture) + " " + monthname + " " + year.ToString(CultureInfo.InvariantCulture);
            return date;
        }
        public static string Convert2HejriDateMonthday(int dt, bool addyear = false, bool addday = true)
        {

            int month = dt % 10000 / 100;
            int day = dt % 100;
            int year = dt / 10000;
            string monthname = "";

            switch (month)
            {
                case 1:
                    monthname = "فروردین";
                    break;
                case 2:
                    monthname = "اردیبهشت";
                    break;
                case 3:
                    monthname = "خرداد";
                    break;
                case 4:
                    monthname = "تیر";
                    break;
                case 5:
                    monthname = "مرداد";
                    break;
                case 6:
                    monthname = "شهریور";
                    break;
                case 7:
                    monthname = "مهر";
                    break;
                case 8:
                    monthname = "آبان";
                    break;
                case 9:
                    monthname = "آذر";
                    break;
                case 10:
                    monthname = "دی";
                    break;
                case 11:
                    monthname = "بهمن";
                    break;
                case 12:
                    monthname = "اسفند";
                    break;
            }
            string date = "";
            if (addday)
            {
                date = day.ToString(CultureInfo.InvariantCulture);
            }
            //string date = day.ToString(CultureInfo.InvariantCulture);
            date += monthname;
            if (addyear)
            {
                date += " " + year;
            }
            return date;
        }
        public static int Convert2Hejriyear(DateTime dt)
        {
            var per = new PersianCalendar();
            return per.GetYear(dt);
        }
        public static int[] Convert2Hejrarr(DateTime dt)
        {
            var date = new int[3];
            var per = new PersianCalendar();
            date[0] = per.GetYear(dt);
            date[1] = per.GetMonth(dt);
            date[2] = per.GetDayOfMonth(dt);
            return date;
        }
        public static int Convert2HejrarrNum(DateTime dt)
        {
            var per = new PersianCalendar();
            int day = per.GetDayOfMonth(dt);
            int month = per.GetMonth(dt);
            int year = per.GetYear(dt);
            return year * 10000 + month * 100 + day;
        }
        public static string Int2String(string x)
        {
            //string sx, y;
            //y = x.ToString();
            if (x.Length == 8)
            {
                string result = x.Substring(0, 4) + "/";
                result += x.Substring(4, 2) + "/";
                result += x.Substring(6, 2);
                return result;
            }
            else
            {
                return x;
            }
            //return x.Substring(8, 4) + "/" + x.Substring(4, 2) + "/" + x.Substring(2, 2);
            //return sx;
        }
        public static string[] Int2SArr(int x)
        {
            try
            {


                string[] date = new string[3];
                date[0] = x.ToString().Substring(0, 4);
                date[1] = x.ToString().Substring(4, 2);
                date[2] = x.ToString().Substring(6, 2);

                return date;
            }
            catch (Exception)
            {
                string[] date = new string[3];
                date[0] = "1360";
                date[1] = "01";
                date[2] = "01";
                return date;

            }
        }
        public static string GetMonthNow()
        {
            var per = new PersianCalendar();
            int month = per.GetMonth(DateTime.Now);

            return month.ToString("00");
        }
        public static string GetMonthNowStr()
        {
            var per = new PersianCalendar();
            int month = per.GetMonth(DateTime.Now);
            switch (month)
            {
                case 1:
                    return "فروردین";
                case 2:
                    return "اردیبهشت";
                case 3:
                    return "خرداد";
                case 4:
                    return "تیر";
                case 5:
                    return "مرداد";
                case 6:
                    return "شهریور";
                case 7:
                    return "مهر";
                case 8:
                    return "آبان";
                case 9:
                    return "آذر";
                case 10:
                    return "دی";
                case 11:
                    return "بهمن";
                case 12:
                    return "اسفند";
            }

            return "";
        }
        public static string GetDayNow()
        {
            var per = new PersianCalendar();
            int day = per.GetDayOfMonth(DateTime.Now);
            string result;
            if (day < 10)
                result = "0" + day.ToString();
            else
            {
                result = day.ToString();
            }
            return result;
        }

        public static DateTime ConvertToDateTime(int dt, bool enddate = false)
        {
            if (dt.ToString().Length != 8)
                return DateTime.Now;
            int month = dt % 10000 / 100;
            int day = dt % 100;
            int year = dt / 10000;
            var per = new PersianCalendar();
            if (enddate)
                return per.ToDateTime(year, month, day, 23, 59, 59, 0);
            return per.ToDateTime(year, month, day, 0, 0, 0, 0);
        }

        public static DateTime ConvertoDatetime(string hejri, char splitor, bool enddate = false)
        {
            if (string.IsNullOrEmpty(hejri))
                return DateTime.Now;
            var per = new PersianCalendar();
            string[] hejrarr = hejri.Split(splitor);
            if (enddate)
                return per.ToDateTime(int.Parse(hejrarr[0]), int.Parse(hejrarr[1]), int.Parse(hejrarr[2]), 23, 59, 59, 0);
            return per.ToDateTime(int.Parse(hejrarr[0]), int.Parse(hejrarr[1]), int.Parse(hejrarr[2]), 0, 0, 0, 0);
        }
        public static DateTime ConvertoDatetime(string hejri, int hour, int min, char splitor, bool enddate = true)
        {
            if (hour == -1)
                return ConvertoDatetime(hejri, splitor, enddate);
            if (string.IsNullOrEmpty(hejri))
                return DateTime.Now;
            var per = new PersianCalendar();
            string[] hejrarr = hejri.Split(splitor);
            if (enddate)
                return per.ToDateTime(int.Parse(hejrarr[0]), int.Parse(hejrarr[1]), int.Parse(hejrarr[2]), hour, min == -1 ? 59 : min, 59, 0);
            return per.ToDateTime(int.Parse(hejrarr[0]), int.Parse(hejrarr[1]), int.Parse(hejrarr[2]), hour, min == -1 ? 0 : min, 0, 0);
        }
        public static DateTime ConvertoDatetime(string hejriDate, string time, char splitorDate, char splitorTime)
        {
            var per = new PersianCalendar();
            string[] hejrarr = hejriDate.Split(splitorDate);
            string[] timearr = time.Split(splitorTime);
            return per.ToDateTime(int.Parse(hejrarr[0]), int.Parse(hejrarr[1]), int.Parse(hejrarr[2]), int.Parse(timearr[0]), int.Parse(timearr[1]), 0, 0);
        }
        public static DateTime ConvertEpochUnixTime2DateTime(string time, bool isGmt = false)
        {
            long itime;
            if (long.TryParse(time, out itime))
            {
                return ConvertEpochUnixTime2DateTime(itime, isGmt);
            }
            return DateTime.Now;
        }
        public static DateTime ConvertEpochUnixTime2DateTime(long time, bool isGmt = false)
        {
            DateTime start = new DateTime(1970, 01, 01, 0, 0, 0);
            var resdt = start.AddSeconds(time / 1000);
            resdt = resdt.AddMilliseconds(time % 1000);
            if (isGmt)
            {
                var hejriArr = Convert2Hejrarr(resdt);
                resdt = hejriArr[1] * 100 + hejriArr[2] < 631 ? resdt.AddHours(-4).AddMinutes(-30) : resdt.AddHours(-3).AddMinutes(-30);
            }
            return resdt;
        }

        public static long ConvertDateTime2UnixTime(DateTime dateTime)
        {
            var hejriArr = Convert2Hejrarr(dateTime);
            dateTime = hejriArr[1] * 100 + hejriArr[2] < 631 ? dateTime.AddHours(-4).AddMinutes(-30) : dateTime.AddHours(-3).AddMinutes(-30);
            return (long)(dateTime - new DateTime(1970, 1, 1)).TotalMilliseconds;
        }

        public static bool IsHejriValid(string hejri, char splitor)
        {
            try
            {
                ConvertoDatetime(hejri, 1, 1, splitor, true);
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }
        private static readonly DateTime Epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
        public static DateTime FromUnixTime(long unixTime)
        {
            return Epoch.AddSeconds(unixTime);
        }

        public static string ToHourMinute(TimeSpan time)
        {
            return time.Days * 24 + time.Hours + ":" + time.Minutes;
        }

        public static string ToHourMinute(TimeSpan? time)
        {
            if (time == null)
                return "ثبت نشده";

            return time?.Days * 24 + time?.Hours + ":" + time?.Minutes;
        }

        public static DateTime GetFirstOfCurrentPersianMonth()
        {
            var per = new PersianCalendar();
            return per.ToDateTime(per.GetYear(DateTime.Now), per.GetMonth(DateTime.Now), 1, 0, 0, 0, 0);
        }
    }
}
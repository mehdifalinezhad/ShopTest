using System;
using System.Collections.Generic;
using System.Data.SqlTypes;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace EndPoint.Admin.Utilities
{
    public static class Pub
    {
        public static string GetAnswerTitle(string answer)
        {
            switch (answer)
            {
                case "a":
                case "A":
                    return "خیلی زیاد";
                case "b":
                case "B":
                    return "زیاد";
                case "c":
                case "C":
                    return "متوسط";
                case "d":
                case "D":
                    return "کم";
                case "e":
                case "E":
                    return "اصلا";
                default:
                    return "بدون جواب";

            }


        }
      
   

        public static string ToPersionDate(this DateTime gregorianDate)
        {
            DateTime result;
            if (DateTime.TryParse(gregorianDate.ToString(), out result)) { 

            //DateTime d = DateTime.Parse(gregorianDate.ToString());
            PersianCalendar pc = new PersianCalendar();
            return string.Format("{0}/{1}/{2}", pc.GetYear(result), pc.GetMonth(result), pc.GetDayOfMonth(result));
        }
            return string.Empty;
        }


        public static string ToPersionDateTime(this DateTime gregorianDate)
        {
            DateTime result;
            if (gregorianDate == DateTime.MinValue || gregorianDate==SqlDateTime.MinValue.Value) return string.Empty;
            if (DateTime.TryParse(gregorianDate.ToString(), out result))
            {

                //DateTime d = DateTime.Parse(gregorianDate.ToString());
                PersianCalendar pc = new PersianCalendar();
                return string.Format("{0}/{1}/{2} {3}:{4}:{5}", pc.GetYear(result), pc.GetMonth(result), pc.GetDayOfMonth(result), result.Hour.ToString().PadLeft(2,'0'), result.Minute.ToString().PadLeft(2, '0'), result.Second.ToString().PadLeft(2, '0'));
            }
            return string.Empty;
        }


        public static DateTime ToGregorianDate(this string persianDate)
        {
            if (persianDate == null || persianDate == "")
            {
                return SqlDateTime.MaxValue.Value;
            }
            PersianCalendar pc = new PersianCalendar();
            persianDate= Regex.Replace(persianDate, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        public static DateTime ToGregorianDateFirstTime(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();
            persianDate = Regex.Replace(persianDate, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]),0,0,0, pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }

        public static DateTime ToGregorianDateLastTime(this string persianDate)
        {
            PersianCalendar pc = new PersianCalendar();
            persianDate = Regex.Replace(persianDate, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]),23,59,0, pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
        }
        public static string FirstDayOfYear()
        {
            DateTime dateTime = DateTime.Now;
            string pDateFrom = Pub.ToPersionDate(dateTime);
            string[] splitString = pDateFrom.Split('/');
            pDateFrom = splitString[0] + "/01/01";
            return pDateFrom;
        }
    public static DateTime MaxGregorianDate(this string persianDate)
        {
            if (persianDate == null || persianDate == "")
            {
                return SqlDateTime.MaxValue.Value;
            }
            PersianCalendar pc = new PersianCalendar();
        persianDate= Regex.Replace(persianDate, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            var persianDateSplitedParts = persianDate.Split('/');
        DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));
      
        }

        public static DateTime MinGregorianDate(this string persianDate)
        {
            if (persianDate == null || persianDate == "")
            {
                return SqlDateTime.MinValue.Value;
            }
            PersianCalendar pc = new PersianCalendar();
            persianDate = Regex.Replace(persianDate, "[۰-۹]", x => ((char)(x.Value[0] - '۰' + '0')).ToString());
            var persianDateSplitedParts = persianDate.Split('/');
            DateTime dateTime = new DateTime(int.Parse(persianDateSplitedParts[0]), int.Parse(persianDateSplitedParts[1]), int.Parse(persianDateSplitedParts[2]), pc);
            return DateTime.Parse(dateTime.ToString(CultureInfo.CreateSpecificCulture("en-US")));

        }




    }
}

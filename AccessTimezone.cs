using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimezoneLibrary
{
    public class AccessTimezone
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public Dictionary<string, Dictionary<string, int>> TimezoneDatas { get; set; } = InitTimezones();

        public static Dictionary<string, Dictionary<string, int>> InitTimezones()
        {
            Dictionary<string, Dictionary<string, int>> _TimezoneDatas = new Dictionary<string, Dictionary<string, int>>();
            foreach (EM_DayOfWeek dayOfWeek in Enum.GetValues(typeof(EM_DayOfWeek)))
            {
                _TimezoneDatas.Add(dayOfWeek.ToString(), new Dictionary<string, int>
                {
                    {"START_HOUR", 0 },
                    {"START_MINUTE", 0 },
                    {"END_HOUR", 23 },
                    {"END_MINUTE", 59 },
                });
            }
            return _TimezoneDatas;
        }

        public static string GetStartTime(AccessTimezone timeZoneData, EM_DayOfWeek dayOfWeek)
        {
            int startHour = timeZoneData.TimezoneDatas[dayOfWeek.ToString()]["START_HOUR"];
            int startMinute = timeZoneData.TimezoneDatas[dayOfWeek.ToString()]["START_MINUTE"];
            return startHour.ToString("00") + ":" + startMinute.ToString("00");
        }
        public static string GetEndTime(AccessTimezone timeZoneData, EM_DayOfWeek dayOfWeek)
        {
            int endHour = timeZoneData.TimezoneDatas[dayOfWeek.ToString()]["END_HOUR"];
            int endMinute = timeZoneData.TimezoneDatas[dayOfWeek.ToString()]["END_MINUTE"];
            return endHour.ToString("00") + ":" + endMinute.ToString("00");
        }

        public void SetValues(EM_DayOfWeek dayOfWeek, int startHour, int startMinute, int endHour, int endMinute)
        {
            this.TimezoneDatas[dayOfWeek.ToString()]["START_HOUR"] = startHour;
            this.TimezoneDatas[dayOfWeek.ToString()]["START_MINUTE"] = startMinute;
            this.TimezoneDatas[dayOfWeek.ToString()]["END_HOUR"] = endHour;
            this.TimezoneDatas[dayOfWeek.ToString()]["END_MINUTE"] = endMinute;
        }
    }
}

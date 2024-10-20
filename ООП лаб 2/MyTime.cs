//Інкапсуляція: Структура MyTimeStruct повинна бути перетворена в клас MyTime,
//оскільки класи краще підходять для моделювання поведінки об'єктів. Всі методи тепер належать класу MyTime.
//Поля hour, minute, second повинні бути інкапсульовані і доступні через властивості з методами перевірки.
// Методи більше не статичні і працюють з полями екземпляра класу.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_лаб_2   
{
    public class MyTime
    {
        private int hour;
        private int minute;
        private int second;

        public void TimeCheck(int h, int m, int s)
        {
            if (h < 0 || h > 23)
                throw new ArgumentException("Години не повинні бути відємними чи більшими за 23.");
            if (m < 0 || m > 59)
                throw new ArgumentException("Хвилини не повинні бути відємними чи більшими за 59.");
            if (s < 0 || s > 59)
                throw new ArgumentException("Секунди не повинні бути відємними чи більшими за 59.");
        }
        public int Hour
        {
            get { return hour; }
            set
            {
                if (value < 0 || value > 23) throw new ArgumentOutOfRangeException("Години повинні бути в межах від 0 до 23.");
                hour = value;
            }
        }

        public int Minute
        {
            get { return minute; }
            set
            {
                if (value < 0 || value > 59) throw new ArgumentOutOfRangeException("Хвилини повинні бути в межах від 0 до 59.");
                minute = value;
            }
        }

        public int Second
        {
            get { return second; }
            set
            {
                if (value < 0 || value > 59) throw new ArgumentOutOfRangeException("Секунди повинні бути в межах від 0 до 59.");
                second = value;
            }
        }

        public MyTime(int hour, int minute, int second)
        {
            TimeCheck(hour, minute, second);
            this.Hour = hour;
            this.Minute = minute;
            this.Second = second;
        }
        public int ToSecSinceMidnight()
        {
            return Hour * 3600 + Minute * 60 + Second;
        }

        public static MyTime FromSecSinceMidnight(int t)
        {
            int secPerDay = 60 * 60 * 24;
            t %= secPerDay;
            // приводимо t до проміжку, можливого в межах однієї доби,
            // враховуючи, що початкове значення t може бути й від’ємним
            if (t < 0)
                t += secPerDay;

            int hours = t / 3600;
            int minutes = (t / 60) % 60;
            int seconds = t % 60;

            return new MyTime(hours, minutes, seconds);
        }

        public MyTime AddOneSecond()
        {
            return AddSeconds(1);
        }

        public MyTime AddOneMinute()
        {
            return AddSeconds(60);
        }

        public MyTime AddOneHour()
        {
            return AddSeconds(3600);
        }

        public MyTime AddSeconds(int seconds)
        {
            int totalSeconds = ToSecSinceMidnight() + seconds;
            return FromSecSinceMidnight(totalSeconds);
        }

        public static int Difference(MyTime mt1, MyTime mt2)
        {
            return mt1.ToSecSinceMidnight() - mt2.ToSecSinceMidnight();
        }

        public static bool IsInRange(MyTime start, MyTime finish, MyTime t)
        {
            int startTimeInSeconds = start.ToSecSinceMidnight();
            int finishTimeInSeconds = finish.ToSecSinceMidnight();
            int tSeconds = t.ToSecSinceMidnight();

            if (startTimeInSeconds <= finishTimeInSeconds)
            {
                return startTimeInSeconds <= tSeconds && tSeconds <= finishTimeInSeconds;
            }
            else
            {
                return tSeconds >= startTimeInSeconds || tSeconds <= finishTimeInSeconds;
            }
        }

        public static string WhatLesson(MyTime t)
        {
            int[] thresholds = { 28800, 33600, 34800, 39600, 40800, 45600, 46800, 51600, 52800, 57600, 58200, 63000 };
            string[] lessons = {
                "«пари ще не почалися»",
                "«1-а пара»",
                "«перерва між 1-ю та 2-ю парами»",
                "«2-а пара»",
                "«перерва між 2-ю та 3-ю парами»",
                "«3-я пара»",
                "«перерва між 3-ю та 4-ю парами»",
                "«4-а пара»",
                "«перерва між 4-ю та 5-ю парами»",
                "«5-а пара»",
                "«перерва між 5-ю та 6-ю парами»",
                "«6-а пара»"
            };
            string afterClasses = "«пари вже скінчилися»";

            int seconds = t.ToSecSinceMidnight();
            int j = 0;

            while (j < thresholds.Length && seconds >= thresholds[j])
            {
                j++;
            }

            return j < lessons.Length ? lessons[j] : afterClasses;
        }

        public override string ToString()
        {
            return $"{hour}:{minute:D2}:{second:D2}";
        }
    }
}



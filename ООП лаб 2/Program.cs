using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ООП_лаб_2
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                MyTime time1 = new MyTime(23, 59, 59);
                MyTime time2 = new MyTime(14, 15, 0);
                MyTime time3 = new MyTime(11, 30, 0);

                Console.WriteLine("Час 1: " + time1);
                Console.WriteLine("Час 2: " + time2);
                Console.WriteLine("Час 3: " + time3);

                Console.WriteLine($"\nСекунд з початку доби для {time1}: {time1.ToSecSinceMidnight()}");
                Console.WriteLine($"Час 2 з секунд {time2.ToSecSinceMidnight()}: {new MyTime(0, 0, 0).AddSeconds(time2.ToSecSinceMidnight())}\n");

                MyTime time4 = time1.AddOneSecond();
                Console.WriteLine($"Час 4 (додана 1 секунда до {time1}): " + time4);

                MyTime time5 = time1.AddSeconds(2041);
                Console.WriteLine($"Час 5 (додано 2041 секунд до {time1}): " + time5);

                MyTime time6 = time2.AddOneMinute();
                Console.WriteLine($"Час 6 (додано 1 хвилин до {time2}): " + time6);

                MyTime time7 = time3.AddOneHour();
                Console.WriteLine($"Час 7 (додано 1 годину до {time3}): " + time7);

                int diff = MyTime.Difference(time1, time2);
                Console.WriteLine("\nРізниця між часом 1 і часом 2: " + diff + " секунд або " + MyTime.FromSecSinceMidnight(diff));

                bool isInRange = MyTime.IsInRange(time1, time2, time3);
                Console.WriteLine($"\nЧи належить час {time3} проміжку між {time1} та {time2}: " + isInRange);

                string lesson1 = MyTime.WhatLesson(time1);
                Console.WriteLine($"\nЧас: {time1} ({time1.ToSecSinceMidnight()}) " + lesson1);
                string lesson2 = MyTime.WhatLesson(time2);
                Console.WriteLine($"Час: {time2} ({time2.ToSecSinceMidnight()}) " + lesson2);
                string lesson3 = MyTime.WhatLesson(time3);
                Console.WriteLine($"Час: {time3} ({time3.ToSecSinceMidnight()}) " + lesson3);
            }
            catch (FormatException)
            {
                Console.WriteLine("Помилка: введено невірний формат числа. Будь ласка, введіть коректне число");
                return;
            }
            catch (ArgumentException ex)
            {
                Console.WriteLine($"Помилка: {ex.Message}");
                return;
            }
        }
    }
}
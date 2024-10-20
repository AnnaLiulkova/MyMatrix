using ООП_лаб_2;

namespace ООП_лаб_2.Tests
{
    [TestClass]
    public class ООП_лаб_2Test
    {
        [TestMethod]
        public void ConstructorValidTimeShouldCreateCorrectObject1()
        {
            var time = new MyTime(23, 59, 59);

            Assert.AreEqual(23, time.Hour);
            Assert.AreEqual(59, time.Minute);
            Assert.AreEqual(59, time.Second);
        }

        [TestMethod]
        public void ConstructorValidTimeShouldCreateCorrectObject2()
        {
            var time = new MyTime(20, 01, 23);

            Assert.AreEqual(20, time.Hour);
            Assert.AreEqual(01, time.Minute);
            Assert.AreEqual(23, time.Second);
        }

        [TestMethod]
        public void ConstructorInvalidHourShouldThrowArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new MyTime(25, 0, 0));
            Assert.AreEqual("Години не повинні бути відємними чи більшими за 23.", ex.Message);
        }

        [TestMethod]
        public void ConstructorInvalidMinuteShouldThrowArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new MyTime(23, 60, 0));
            Assert.AreEqual("Хвилини не повинні бути відємними чи більшими за 59.", ex.Message);
        }

        [TestMethod]
        public void ConstructorInvalidSecondShouldThrowArgumentException()
        {
            var ex = Assert.ThrowsException<ArgumentException>(() => new MyTime(23, 59, 60));
            Assert.AreEqual("Секунди не повинні бути відємними чи більшими за 59.", ex.Message);
        }

        [TestMethod]
        public void ToSecSinceMidnightValidTimeShouldReturnCorrectSeconds()
        {
            var time = new MyTime(14, 15, 0);

            int seconds = time.ToSecSinceMidnight();

            Assert.AreEqual(51300, seconds); // 14*3600 + 15*60 = 51300
        }

        [TestMethod]
        public void FromSecSinceMidnightValidSecondsShouldReturnCorrectTime()
        {
            var time = MyTime.FromSecSinceMidnight(51419);

            Assert.AreEqual(14, time.Hour);
            Assert.AreEqual(16, time.Minute);
            Assert.AreEqual(59, time.Second);
        }

        [TestMethod]
        public void AddOneSecond_ShouldIncreaseTimeByOneSecond()
        {
            var time = new MyTime(23, 59, 59);

            var newTime = time.AddOneSecond();

            Assert.AreEqual(0, newTime.Hour);
            Assert.AreEqual(0, newTime.Minute);
            Assert.AreEqual(0, newTime.Second);
        }

        [TestMethod]
        public void AddOneMinute_ShouldIncreaseTimeByOneMinute()
        {
            var time = new MyTime(14, 15, 0);

            var newTime = time.AddOneMinute();

            Assert.AreEqual(14, newTime.Hour);
            Assert.AreEqual(16, newTime.Minute);
            Assert.AreEqual(0, newTime.Second);
        }

        [TestMethod]
        public void AddOneHour_ShouldIncreaseTimeByOneHour()
        {
            var time = new MyTime(14, 15, 0);

            var newTime = time.AddOneHour();

            Assert.AreEqual(15, newTime.Hour);
            Assert.AreEqual(15, newTime.Minute);
            Assert.AreEqual(0, newTime.Second);
        }

        [TestMethod]
        public void Difference_ShouldReturnCorrectDifferenceInSeconds()
        {
            var time1 = new MyTime(23, 59, 59);
            var time2 = new MyTime(14, 15, 0);

            int diff = MyTime.Difference(time1, time2);

            Assert.AreEqual(35099, diff); // 23:59:59 - 14:15:00 
        }
        [TestMethod]
        public void IsInRange_TimeInRange_ShouldReturnTrue()
        {
            var start = new MyTime(14, 0, 0);
            var finish = new MyTime(16, 0, 0);
            var time = new MyTime(15, 0, 0);

            bool result = MyTime.IsInRange(start, finish, time);

            Assert.IsTrue(result);
        }

        [TestMethod]
        public void IsInRange_TimeOutOfRange_ShouldReturnFalse()
        {
            var start = new MyTime(14, 0, 0);
            var finish = new MyTime(16, 0, 0);
            var time = new MyTime(17, 0, 0);

            bool result = MyTime.IsInRange(start, finish, time);

            Assert.IsFalse(result);
        }
        [TestMethod]
        public void WhatLesson_ShouldReturnCorrectLesson()
        {
            var time = new MyTime(9, 0, 0);

            string lesson = MyTime.WhatLesson(time);

            Assert.AreEqual("«1-а пара»", lesson);
        }

        [TestMethod]
        public void WhatLesson_ShouldReturnCorrectLesson1()
        {
            var time = new MyTime(11, 0, 0); 

            string lesson = MyTime.WhatLesson(time);

            Assert.AreEqual("«перерва між 2-ю та 3-ю парами»", lesson);
        }
        [TestMethod]
        public void WhatLesson_ShouldReturnCorrectLesson2()
        {
            var time = new MyTime(11, 19, 59); 

            string lesson = MyTime.WhatLesson(time);

            Assert.AreEqual("«перерва між 2-ю та 3-ю парами»", lesson);
        }
        [TestMethod]
        public void WhatLesson_ShouldReturnCorrectLesson3()
        {
            var time = new MyTime(11, 20, 0); 

            string lesson = MyTime.WhatLesson(time);

            Assert.AreEqual("«3-я пара»", lesson);
        }
        [TestMethod]
        public void WhatLesson_ShouldReturnCorrectLesson4()
        {
            var time = new MyTime(17, 30, 0); 

            string lesson = MyTime.WhatLesson(time);

            Assert.AreEqual("«пари вже скінчилися»", lesson);
        }
    }
}
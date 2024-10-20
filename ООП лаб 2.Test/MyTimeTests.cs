using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MyTime;

namespace MyTime.Test
{
    [TestClass]
    public class MyTime
    {
        [TestMethod]
        public void ConstructorValidTimeShouldCreateCorrectObject()
        {
            // Arrange & Act
            var time = new MyTime(23, 59, 59);  

            // Assert
            Assert.AreEqual(23, time.Hour);
            Assert.AreEqual(59, time.Minute);
            Assert.AreEqual(59, time.Second);
        }


    }
}
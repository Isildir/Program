using System;
using NUnit.Framework;

namespace UnitTests
{
    [TestFixture]
    public class ProgramTests
    {
        [Test]
        [TestCase("2016/1/1", "2016.01.12")]
        [TestCase("2016.01.01", "2016.11.12")]
        [TestCase("1-01-2016", "8-12-2017")]
        public void CompareDatas_WhenCalled_ReturnsStringContainingSecondDate(string firstValue, string secondValue)
        {
            DateTime firstDate = DateTime.Parse(firstValue);
            DateTime secondDate = DateTime.Parse(secondValue);
            
            string result = Program.Program.CompareDates(firstDate, secondDate);
            
            Assert.That(result, Does.Contain(secondDate.ToShortDateString()).IgnoreCase);
        }

        [Test]
        [TestCase("01.01.2016", "01.01.2016")]
        [TestCase("1.11.2016", "12.01.2016")]
        public void CompareDatas_WhenCalled_ReturnsBadOrderValue(string firstValue, string secondValue)
        {
            DateTime firstDate = DateTime.Parse(firstValue);
            DateTime secondDate = DateTime.Parse(secondValue);
            
            string result = Program.Program.CompareDates(firstDate, secondDate);
            
            Assert.That(result, Is.EqualTo(Program.Program.BAD_ORDER).IgnoreCase);
        }
    }
}

using System;
using NUnit.Framework;

namespace Main
{
    [TestFixture]
    public class StringCalculatorTest
    {
        [Test]
        public void Add_EmptyString_ReturnsZero()
        {
            StringCalculator calculator = new StringCalculator();

            int results = calculator.Add("");

            Assert.AreEqual(0, results);
        }
        [TestCase("1",1)]
        [TestCase("20",20)]
        public void Add_Single_ReturnThatNumber(string number, int expected)
        {
            StringCalculator calculator = new StringCalculator();

            int results = calculator.Add(number);

            Assert.AreEqual(expected, results);
        }
    }
    public class StringCalculator
    {
       public int Add(string number)
       {
            if (number.Length == 0)
            {
                return 0;
            }
            return int.Parse(number);
       }
    }

    }

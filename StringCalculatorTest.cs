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
        [TestCase("5000",5000)]
        public void Add_Single_ReturnThatNumber(string number, int expected)
        {
            StringCalculator calculator = new StringCalculator();

            int results = calculator.Add(number);

            Assert.AreEqual(expected, results);
        }
        [TestCase("1,5000", 5001)]
        [TestCase("1,1",2)]
        public void Add_MultipleNumbers_ReturnSum(string number, int expected)
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
            String[] multiNumbers = number.Split(',');

            if (number.Length == 0)
            {
                return 0;
            }
            else if (number.Contains(","))
            {
                return int.Parse(multiNumbers[0]) + int.Parse(multiNumbers[1]);
            }
            return int.Parse(number);
       }
    }

    }

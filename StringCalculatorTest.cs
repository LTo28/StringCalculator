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

            double results = calculator.Add("");

            Assert.AreEqual(0, results);
        }
        [TestCase("1",1)]
        [TestCase("20",20)]
        [TestCase("5000",5000)]
        [TestCase("tytyt",0)]
        [TestCase("a",0)]
        public void Add_Single_ReturnThatNumber(string number, double expected)
        {
            StringCalculator calculator = new StringCalculator();

            double results = calculator.Add(number);

            Assert.AreEqual(expected, results);
        }
        [TestCase("1,5000", 5001)]
        [TestCase("1,1",2)]
        [TestCase("5,tytyt",5)]
        [TestCase("1,2,3,4,5,6,7,8,9,10,11,12",78)]
        [TestCase("2,4,6,8,10",30)]
        public void Add_MultipleNumbers_ReturnSum(string number, double expected)
        {
            StringCalculator calculator = new StringCalculator();

            double results = calculator.Add(number);

            Assert.AreEqual(expected, results);
        }
    }
    public class StringCalculator
    {
       public double Add(string number)
       {
            string[] numberArray = number.Split(',');
            double sum = 0;

            if (number.Length == 0 || Char.IsLetter(number,0))
            {
                return 0;
            }
            else if (numberArray.Length > 0)
            {
                for (int i = 0; i < numberArray.Length; i++)
                {
                    double num = 0;
                    bool valid = double.TryParse(numberArray[i], out num);
                    if (valid)
                    {
                        sum += num;
                    }
                }
            }
            return sum;
        }
    }
    }

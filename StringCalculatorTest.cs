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
        [TestCase("1,100", 101)]
        [TestCase("1,1",2)]
        [TestCase("5,tytyt",5)]
        [TestCase("1,2,3,4,5,6,7,8,9,10,11,12",78)]
        [TestCase("1\n2,3",6)]
        [TestCase("10,-5",5)]
        [TestCase("2,1000,6",8)]
        [TestCase("10,2000",10)]
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
            string[] numberArray = number.Split(new[] { "\n", ","}, StringSplitOptions.None);
            double sum = 0;

            if (number.Length == 0 || Char.IsLetter(number,0))
            {
                return 0;
            }
            else if (numberArray.Length > 1)
            {
                for (int i = 0; i < numberArray.Length; i++)
                {
                    double num1 = 0;
                    bool valid1 = double.TryParse(numberArray[i], out num1);
                    if (valid1 && num1 < 1000)
                    {
                        sum += num1;
                    }
                }
                return sum;
            }
            return int.Parse(number);
        }
    }
    }

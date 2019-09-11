using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;

namespace Main
{
    [TestFixture]
    public class StringCalculatorTest
    {
        StringCalculator calculator = new StringCalculator();

        [TestCase("",0)]
        public void Add_EmptyString_ReturnsZero(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("20", 20)]
        [TestCase("tytyt", 0)]
        public void Add_SingleNumber_ReturnsSum(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("1,100", 101)]
        [TestCase("10,50", 60)]
        [TestCase("5,tytyt",5)]
        public void Add_MultiNumber_ReturnsSum(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("1,2,3,4,5,6,7,8,9,10,11,12",78)]
        public void Add_ManyNumbers_ReturnsSum(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("1\n2,3",6)]
        public void Add_Supports_NewLine(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("2,1000,6",8)]
        [TestCase("10,1001", 10)]
        public void Add_Ignore_GreaterThan1000(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("//;\n2;5",7)]
        public void Add_Support_CustomChar(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("//[***]\n11***22***33", 66)]
        public void Add_Support_CustomDelimiter(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("//[*][!!][r9r]\n11r9r22*33!!44", 110)]
        public void Add_Support_MultiDelimiter(string number, double expected)
        {
            double results = calculator.Add(number);
            Assert.AreEqual(expected, results);
        }
        [TestCase("1,-2","-2")]
        [TestCase("1,-2,-3,-4","-2,-3,-4")]
        public void ThrowException_NegativeNumbers(string number, string expected)
        {
            var exception = Assert.Throws<Exception>(() => this.calculator.Add(number));
            Assert.AreEqual("Negatives not allowed: " + expected, exception.Message);
        }
    }
    public class StringCalculator
    {
       public double Add(string number)
       {
            string[] numberArray = number.Split(new[] { "/","***", "*", "r9r", "!", ";", "\n", "," }, StringSplitOptions.None);
            double sum = 0;
            for (int i = 0; i < numberArray.Length; i++)
            {
                double num = 0;
                var negative = new List<double>();
                bool valid = double.TryParse(numberArray[i], out num);
                if (num < 0)
                {
                    negative.Add(num);
                }
                if (negative.Any())
                {
                    throw new Exception("Negatives not allowed: " + string.Join(",", negative));
                }
                if (valid && num < 1000)
                {
                    sum += num;
                }
            }
            return sum;
        }
    }
}
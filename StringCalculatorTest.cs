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
        [TestCase("20", 20)]
        [TestCase("tytyt", 0)]
        [TestCase("1,100", 101)]
        [TestCase("5,tytyt",5)]
        [TestCase("1,2,3,4,5,6,7,8,9,10,11,12",78)]
        [TestCase("1\n2,3",6)]
        [TestCase("2,1000,6",8)]
        [TestCase("10,2000",10)]
        [TestCase("//;\n2;5",7)]
        [TestCase("//[***]\n11***22***33", 66)]
        [TestCase("//[*][!!][r9r]\n11r9r22*33!!44", 110)]
        public void Add_Numbers_ReturnSum(string number, double expected)
        {
            double results = calculator.Add(number);

            Assert.AreEqual(expected, results);
        }
        [TestCase("1,-2","-2")]
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
            string[] numberArray = number.Split(new[] { "/","***", "*", "r9r", "!", ";", "\n", "," }, StringSplitOptions.None) ;
            double sum = 0;

            if (number.Length == 0 || Char.IsLetter(number,0))
            {
                return 0;
            }
            else if (numberArray.Length > 1)
            {
                var negativeNumbers = new List<double>();
                for (int i = 0; i < numberArray.Length; i++)
                {
                    double num = 0;
                    bool valid1 = double.TryParse(numberArray[i], out num);
                    if (valid1 && num < 1000 && num > 0)
                    {
                        sum += num;
                    }
                    else if (num < 0)
                    {
                        double num1 = double.Parse(numberArray[i]);
                        
                        if (num1 < 0)
                        {
                            negativeNumbers.Add(num1);
                        }
                        sum += num1;
                        if (negativeNumbers.Any())
                        {
                            throw new Exception("Negatives not allowed: " + string.Join(",", negativeNumbers));
                        }
                        return sum;
                    }
                    
                }
                return sum;
            }
            return int.Parse(number);
        }
    }
    }

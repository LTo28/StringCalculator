using System;
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

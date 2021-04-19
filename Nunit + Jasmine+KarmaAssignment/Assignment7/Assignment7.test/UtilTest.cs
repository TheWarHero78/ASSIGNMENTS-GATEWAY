using Assignment7.Utils;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7.Tests
{
    [TestFixture]
 
    public class UtilTest
    {
        /// <summary>
        /// Test method for calculateDiscount using if else in nunit
        /// </summary>
        /// <param name="salesamt"></param>
        /// <param name="expectedDiscount"></param>
        [TestCase(1000,950)]
        [TestCase(2000, 1800)]
        [TestCase(5000, 2500)]
        [TestCase(999, 999)]     
        public void TestCalculateDiscount(double salesamt,double expectedDiscount)
        {
            Util u = new Util();
            double result = u.CalculateDiscount(salesamt);
            Assert.That(result == expectedDiscount);
            
        }


        /// <summary>
        /// Test method for checkIsColor using switch in nunit
        /// </summary>
        /// <param name="colorname"></param>
        /// <returns></returns>
        [TestCase("Blue", ExpectedResult =true)]
        [TestCase("Black", ExpectedResult = true)]
        [TestCase("Green", ExpectedResult = true)]
        [TestCase("x", ExpectedResult = false)]
        public bool TestCheckIsColor(String colorname)
        {
            Util u = new Util();
            return u.CheckIsColor(colorname);
        }


        /// <summary>
        /// Test method for GetMaxmimumMarks method
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="mark"></param>
        [TestCase(new int[] {10,20,30 }, 30)]
        public void TestGetMaximumMarks(int[] numbers,int mark)
        {
            Util u = new Util();
            double result = u.GetMaximumMarks(numbers);
            Assert.That(result == mark);
        }

      
        /// <summary>
        /// Test method for FindSum method
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="total"></param>
        [TestCase(new int[] { 10, 20, -30 }, 30)]
        public void TestFindSum(int[] numbers, int total)
        {
            Util u = new Util();
            double result = u.FindSum(numbers);
            Assert.That(result == total);
        }


        /// <summary>
        /// Test method to handle exception for calculateDiscount method
        /// </summary>
        /// <param name="salesamt"></param>
        /// <param name="expectedDiscount"></param>
        [TestCase(0, 0)]
        public void TestCalculateDiscountexception(double salesamt, double expectedDiscount)
        {
            Util u = new Util();
            Assert.That(() => u.CalculateDiscount(salesamt), Throws.TypeOf<ArgumentException>());
        }



        /// <summary>
        /// Test method to handle exception for checkIsColor method
        /// </summary>
        /// <param name="colorname"></param>
        [TestCase(null)]
        public void TestCheckIsColorexception(String colorname)
        {
            Util u = new Util();
            Assert.That(() => u.CheckIsColor(colorname), Throws.TypeOf<ArgumentNullException>());
        }


        /// <summary>
        /// Test method to handle exception for getMaximumMarks method
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="mark"></param>
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 91, 100, 101 }, 30)]
        public void TestgetMaximumMarksexception(int[] numbers, int mark)
        {
            Util u = new Util();
            Assert.That(() => u.GetMaximumMarks(numbers), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        /// <summary>
        ///  Test method to handle exception for findSum method
        /// </summary>
        /// <param name="numbers"></param>
        /// <param name="total"></param>
        [TestCase(new int[] { 10, 20, 30, 40, 50, 60, 70, 80, 91, 100, 101 }, 30)]
        public void TestFindSumexception(int[] numbers, int total)
        {
            Util u = new Util();
            Assert.That(() => u.FindSum(numbers), Throws.TypeOf<ArgumentOutOfRangeException>());
        }




    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Assignment7.Utils
{
    public class Util
    {
        /// <summary>
        /// If else method to calculate discounted price from given sales amount
        /// </summary>
        /// <param name="SalesAmnt"></param>
        /// <returns></returns>
        public double CalculateDiscount(double SalesAmnt)
        {
            double DiscountPrice;
            if (SalesAmnt == 0 || SalesAmnt < 0)
            {
                throw new ArgumentException(" Sales Amount should not be 'Zero/Negative'");
            }
            else if (SalesAmnt >= 1000 && SalesAmnt < 2000)
            {
                // 5% Discount  
                DiscountPrice = SalesAmnt - (SalesAmnt * 0.05);
            }
            else if (SalesAmnt >= 2000 && SalesAmnt < 5000)
            {
                // 10% Discount  
                DiscountPrice = SalesAmnt - (SalesAmnt * 0.1);
            }
            else if (SalesAmnt >= 5000 && SalesAmnt < 20000)
            {
                // 50% Discount  
                DiscountPrice = SalesAmnt - (SalesAmnt * 0.5);
            }
            else
            {
                // No Discount  
                DiscountPrice = SalesAmnt - 0.0;
            }
            return DiscountPrice;
        }

        /// <summary>
        /// Switch Method to check given color name is color or not
        /// </summary>
        /// <param name="color"></param>
        /// <returns></returns>
        public bool CheckIsColor(String color)
        {
            if (color == null)
            {
                throw new ArgumentNullException("Color cannot be null");
            }
            return color switch
            {
                "Blue" => true,
                "Green" => true,
                "Black" => true,
                _ => false,
            };
        }
        /// <summary>
        /// Using for each loop to get maximum marks out of an integer array
        /// </summary>
        /// <param name="marks"></param>
        /// <returns></returns>
        public int GetMaximumMarks(int[] marks)
        {
            if (marks.Length > 10)
            {
                throw new ArgumentOutOfRangeException("Cannot get maximum marks for more than 100 students");
            }
            int maxSoFar = marks[0];

            // for each loop
            foreach (int num in marks)
            {
                if (num > maxSoFar)
                {
                    maxSoFar = num;
                }
            }
            return maxSoFar;

        }

        /// <summary>
        /// For loop using to compute total of positive numbers in the array 
        /// </summary>
        /// <param name="numbers"></param>
        /// <returns></returns>
        public int FindSum(int[] numbers)
        {
            if (numbers.Length > 10)
            {
                throw new ArgumentOutOfRangeException("Cannot compute total of positive numbers s in the array for more than 10 numbers");
            }
            int total = 0;
            if (numbers.Length <= 10)
            {
                for (int count = 0; count < numbers.Length; count++)
                {
                    if (numbers[count] > 0)
                    {
                        total += numbers[count];
                    }
                }
            }
            return total;


        }
        
        /// <summary>
        /// While loop using to decrement number till 1
        /// </summary>
        /// <param name="x"></param>
        /// <returns></returns>
        public int GetOne(int x)
        {
            if (x<1)
            {
                throw new ArgumentException();
            }
            while (x > 1)
            {
                x--;
            }
            return x;
        }
    }
}

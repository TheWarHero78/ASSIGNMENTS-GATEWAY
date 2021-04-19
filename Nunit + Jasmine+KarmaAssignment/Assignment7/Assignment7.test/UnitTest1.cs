using Assignment7.Utils;
using NUnit.Framework;
using System;
using System.Threading.Tasks;

namespace Assignment7.test
{
    [TestFixture]
    public class Tests
    {
        [TestCase(1, 2, ExpectedResult = 3)]
        public async Task<int> TestAddAsync(int a, int b)
        {
            AsyncUtil obj = new AsyncUtil();
            return await obj.SumAsync(a, b);
        }

        [TestCase(1, 2, ExpectedResult = 2)]
        public async Task<int> TestMultiplyAsync(int a, int b)
        {
            AsyncUtil obj = new AsyncUtil();
            return await obj.MultiplyAsync(a, b);
        }

        [TestCase(100, ExpectedResult = 100)]
        public async Task<int> TestGetNumberAsync(int a)
        {
            AsyncUtil obj = new AsyncUtil();
            return await obj.GetNumberAsync(a);
        }

        [TestCase(10,1, ExpectedResult = 10)]
        public async Task<int> TestPowerAsync(int a,int b)
        {
            AsyncUtil obj = new AsyncUtil();
            return await obj.PowerAsync(a,b);
        }




        //Exception Handling for Test Methods

        [TestCase(0, 0)]
        public void TestAddAsyncException(int a, int b)
        {
            AsyncUtil obj = new AsyncUtil();
            Assert.ThrowsAsync<InvalidOperationException>(async () => await obj.SumAsync(a, b));
        }

        [TestCase(0, 0)]
        public void TestMultiplyAsyncException(int a, int b)
        {
            AsyncUtil obj = new AsyncUtil();
            Assert.ThrowsAsync<InvalidOperationException>(async () => await obj.MultiplyAsync(a, b));
        }

        [TestCase(10, 0)]
        public void TestDivideAsyncException(int a,int b)
        {
            AsyncUtil obj = new AsyncUtil();
            Assert.ThrowsAsync<DivideByZeroException>(async () => await obj.DivideAsync(a, b));      
        }

        [TestCase(-1)]
        public void TestGetNumberAsyncException(int a)
        {
            AsyncUtil obj = new AsyncUtil();
            Assert.ThrowsAsync<ArgumentException>(async () => await obj.GetNumberAsync(a));
        }

        [TestCase(0, 0)]
        public void TestPowerAsyncException(int a, int b)
        {
            AsyncUtil obj = new AsyncUtil();
            Assert.ThrowsAsync<InvalidOperationException>(async () => await obj.PowerAsync(a,b));            
        }


    }
}
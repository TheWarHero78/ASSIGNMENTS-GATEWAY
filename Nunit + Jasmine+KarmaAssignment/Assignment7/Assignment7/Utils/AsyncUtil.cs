using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Assignment7.Utils
{
    public class AsyncUtil
    {

        public async Task<int> SumAsync(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new InvalidOperationException();
            }
            return await Task.FromResult(a) + await Task.FromResult(b);
        }
        public async Task<int> MultiplyAsync(int a, int b)
        {
            if (a == 0 && b == 0)
            {
                throw new InvalidOperationException();
            }
            return await Task.FromResult(a) * await Task.FromResult(b);
        }
        public async Task<int> DivideAsync(int x, int y)
        {
            await Task.Delay(100);
            return x / y;
        }

        public async Task<int> PowerAsync(int x, int y)
        {
            if(x==0 && y == 0)
            {
                throw new InvalidOperationException();
            }
            await Task.Delay(100);
            return (int)Math.Pow(x,y);
        }

        public async Task<int> GetNumberAsync(int number)
        {
            await Task.Delay(100);
            if (number < 0)
            {
                throw new ArgumentException();
            }
            return number;
        }
    }
}

using MathNet.Numerics.Optimization;
using System;
using System.Collections.Generic;

class BasicExample
{

    class RectangleStacking
    {
        public int l, w, h, n;

        public RectangleStacking(int length, int width, int height, int count)
        {
            l = length;
            w = width;
            h = height;
            n = count;
        }

        // 方法用于寻找所有n的因数
        private List<int> FindFactors(int number)
        {
            List<int> factors = new List<int>();
            for (int i = 1; i <= Math.Sqrt(number); i++)
            {
                if (number % i == 0)
                {
                    factors.Add(i);
                    if (i != number / i)
                    {
                        factors.Add(number / i);
                    }
                }
            }
            return factors;
        }

        public void FindMinimumPerimeter()
        {
            int minPerimeter = int.MaxValue;
            int minL = 0;
            int minW = 0;
            int minH = 0;
            List<int> factors = FindFactors(n);

            // 穷举所有可能的x, y, z组合
            foreach (int x in factors)
            {
                foreach (int y in factors)
                {
                    int z = n / (x * y);
                    if (x * y * z == n)
                    {  // 确保x, y, z的乘积等于n
                        int L = x * l;
                        int W = y * w;
                        int H = z * h;
                        //长方体周长和
                        int perimeter = 4 * (L + W + H);
                        if (perimeter < minPerimeter)
                        {
                            minPerimeter = perimeter;
                            minL = L;
                            minW = W;
                            minH = H;
                        }
                    }
                }
            }

            Console.WriteLine("Minimum perimeter is: " + minPerimeter);
            Console.WriteLine("Minimum L W H is: " + $"{minL} {minW} {minH}");
        }
    }

    class Program
    {
        static void Main()
        {
            int l = 3; // 长方体的长度
            int w = 2; // 长方体的宽度
            int h = 1; // 长方体的高度
            int n = 20; // 长方体的数量

            RectangleStacking stacking = new RectangleStacking(l, w, h, n);
            stacking.FindMinimumPerimeter();
        }
    }

}

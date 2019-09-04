using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //冒泡排序
            int[] num = { 1, 65, 34, 67, 89, 32, 12 };
            BubbleSort(num);
            
            //递归  斐波那契数列
            Console.WriteLine(Fibonacci(19));

            //异步
            callMethod();
            Console.ReadKey(); //防止程序运行结束后关闭窗口
        }

        //冒泡排序
        #region
        public static void BubbleSort(int[] num)
        {
            for (int i = 0; i < num.Length-1; i++)
            {
                for (int j = num.Length-1; j > i; j--)
                {
                    if (num[j] < num[j - 1])
                    {
                        int tmp = num[j];
                        num[j] = num[j - 1];
                        num[j - 1] = tmp;
                    }
                }
            }
            for (int n = 0; n < num.Length; n++)
            {
                Console.WriteLine(num[n]);
            }            
        }
        #endregion

        //斐波那契数列 - 递归
        #region        
        private static int Fibonacci(int number)
        {
            if (number < 2) return number;
            return Fibonacci(number - 2) + Fibonacci(number - 1);
        }
        #endregion

        //异步
        #region
        public static async void callMethod()
        {
            Task<int> task = Method1();
            Method2();
            int count = await task;
            Method3(count);
        }

        public static async Task<int> Method1()
        {
            int count = 0;
            await Task.Run(() =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Console.WriteLine(" Method 1");
                    count += 1;
                }
            });
            return count;
        }

        public static void Method2()
        {
            for (int i = 0; i < 25; i++)
            {
                Console.WriteLine(" Method 2");
            }
        }

        public static void Method3(int count)
        {
            Console.WriteLine("Total count is " + count);
        }
        #endregion
    }
}

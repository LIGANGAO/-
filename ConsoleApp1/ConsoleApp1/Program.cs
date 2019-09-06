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
            //初始值
            int[] num = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };

            //冒泡排序
            BubbleSort(num);

            //选择排序
            SelectionSort(num);

            //插入排序
            InsertionSort(num);

            //希尔排序
            ShellSort(num);

            //快速排序
            quickSort(num, 0, num.Length - 1);

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

        //选择排序
        #region
        public static void SelectionSort(int[] num)
        {
            //int[] num = { 3, 44, 38, 5, 47, 15, 36, 26, 27, 2, 46, 4, 19, 50, 48 };
            for (int i = 0; i < num.Length -1; i++)
            {
               int index = i;
               for(int j = 1 + i; j < num.Length; j++)
               {
                   if(num[j] < num[index])
                   {
                       index = j;//保存最小元素的下标
                   }
               }
               //找到元素下标，与前一个元素交换
               int tmp = num[index];
               num[index] = num[i];
               num[i] = tmp;
            }
        }
        #endregion

        //插入排序
        #region
        public static void InsertionSort(int[] num)
        {
            for(int i = 0; i < num.Length; i++)
            {
                int insertValue = num[i];
                // 找到待插入数的前一个数的下标
                int insertIndex = i - 1;
                while (insertIndex >= 0 && insertValue < num[insertIndex])
                {
                    num[insertIndex + 1] = num[insertIndex];
                    insertIndex--;
                }
                num[insertIndex + 1] = insertValue;
            }
        }
        #endregion

        //希尔排序
        #region
        public static void ShellSort(int[] num)
        {
            for (int gap = num.Length / 2; gap > 0; gap /= 2)
            {
                // 对数组元素进行分组
                for (int i = gap; i < num.Length; i++)
                {
                    // 遍历各组中的元素
                    for (int j = i - gap; j >= 0; j -= gap)
                    {
                        // 交换元素
                        if (num[j] > num[j + gap])
                        {
                            int tmp = num[j];
                            num[j] = num[j + gap];
                            num[j + gap] = tmp;
                        }
                    }
                }
            }
        }
        #endregion

        //快速排序
        #region
        public static void quickSort(int[] num, int left, int right)
        {
            int l = left;// 左下标
            int r = right;// 右下标
            int pivot = num[(left + right) / 2];// 找到中间的值
                                                // 将比pivot小的值放在其左边，比pivot大的值放在其右边
            while (l < r)
            {
                // 在pivot左边寻找，直至找到大于等于pivot的值才退出
                while (num[l] < pivot)
                {
                    l += 1;// 将l右移一位
                }
                // 在pivot右边寻找，直至找到小于等于pivot的值才退出
                while (num[r] > pivot)
                {
                    r -= 1;// 将r左移一位
                }
                if (l >= r)
                {
                    // 左右下标重合，寻找完毕，退出循环
                    break;
                }
                // 交换元素
                int temp = num[l];
                num[l] = num[r];
                num[r] = temp;

                //倘若发现值相等的情况，则没有比较的必要，直接移动下标即可

                // 如果交换完后，发现arr[l]==pivot，此时应将r左移一位
                if (num[l] == pivot)
                {
                    r -= 1;
                }
                // 如果交换完后，发现arr[r]==pivot，此时应将l右移一位
                if (num[r] == pivot)
                {
                    l += 1;
                }
            }
            // 如果l==r，要把这两个下标错开，否则会出现无限递归，导致栈溢出的情况
            if (l == r)
            {
                l += 1;
                r -= 1;
            }
            // 向左递归
            if (left < r)
            {
                quickSort(num, left, r);
            }
            // 向右递归
            if (right > l)
            {
                quickSort(num, l, right);
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

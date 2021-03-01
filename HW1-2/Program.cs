using System;

namespace HW1_2
{
    class Program
    {
        //Вычислите асимптотическую сложность функции из примера ниже
        //Асимптотическая сложность алгоритма n^3 исходя из проверки на тестовых данных
        static void Main(string[] args)
        {
            int[] inputArr = { 1, 2, 3, 4, 5};
            StrangeSum(inputArr);
        }
        public static int StrangeSum(int[] inputArray)
        {
            int sum = 0;
            int iter = 0;
            for (int i = 0; i < inputArray.Length; i++)
            {
                for (int j = 0; j < inputArray.Length; j++)
                {
                    for (int k = 0; k < inputArray.Length; k++)
                    {
                        int y = 0;

                        if (j != 0)
                        {
                            y = k / j;
                        }

                        sum += inputArray[i] + i + k + j + y;
                        iter++;
                    }
                }
            }
            Console.WriteLine(iter);
            Console.WriteLine(sum);
            return sum;
        }
    }
}

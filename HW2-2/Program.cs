using System;

namespace HW2_2
{
    //Требуется написать функцию бинарного поиска, посчитать его асимптотическую сложность и проверить работоспособность функции.
    //O(n)=log(n)
    class Program
    {
        static void Main()
        {
            Console.WriteLine("Имеем отсортированный массив из 20 элементов");
            Random random = new Random();
            int[] array = new int[20];
            for(int i=0; i<20; i++)
            {
                array[i] = random.Next(1, 20);
            }
            Array.Sort(array);
            for(int i = 0; i < 20; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();
            Console.WriteLine("Ищем элемент со значением 10");
            int index = BinarySearch(array, 10);
            if (index >= 0) Console.WriteLine("Это элемент с индексом "+index);
            else Console.WriteLine("Такого элемента нет в массиве");
        }
        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
}

using System;

namespace HW1_3
{
    //Требуется реализовать рекурсивную версию и версию без рекурсии(через цикл).
    class Program
    {
        static void Main()
        {
            int[] numbers = { 0, 1, 2, 3, 10, 15 };
            int[] answers = { 0, 1, 1, 2, 55, 610 };
            Console.WriteLine("Проверка рекурсивного метода");
            for(int i=0; i<numbers.Length; i++)
            {
                int fib = FibonacciRecurs(numbers[i]);
                Console.WriteLine($"{numbers[i]} - {fib}");
                if(answers[i]==fib)
                {
                    Console.WriteLine("Верно");
                }
                else
                {
                    Console.WriteLine("Не верно");
                }
            }
            Console.WriteLine("Проверка метода без рекурсии");
            for (int i = 0; i < numbers.Length; i++)
            {
                int fib = Fibonacci(numbers[i]);
                Console.WriteLine($"{numbers[i]} - {fib}");
                if (answers[i] == fib)
                {
                    Console.WriteLine("Верно");
                }
                else
                {
                    Console.WriteLine("Не верно");
                }
            }
        }
        static int FibonacciRecurs(int number)
        {
            if (number == 1)
            {
                return 1;
            }
            else if (number == 0)
            {
                return 0;
            }
            else
            {
                return FibonacciRecurs(--number) + FibonacciRecurs(--number);
            }
        }
        static int Fibonacci(int number)
        {
            if (number == 0) return 0;
            if (number == 1) return 1;
            if(number>1)
            {
                int[] fibonacci = new int[number + 1];
                fibonacci[0] = 0;
                fibonacci[1] = 1;
                for(int i=2; i<fibonacci.Length;i++)
                {
                    fibonacci[i] = fibonacci[i - 1] + fibonacci[i - 2];
                }
                return fibonacci[number];
            }
            else
            {
                Console.WriteLine("Запрашиваемое число должно быть больше 1");
                return -1;
            }
        }
    }
}

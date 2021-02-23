using System;

namespace HW1_1
{
    class Program
    {
        static void Main()
        {
            int[] test_numbers = { 1, 5, 13, 15, 48, 59 };
            bool[] test_answers = { false, true, true, false, false, true };
            for (int i = 0; i < test_numbers.Length; i++)
            {
                if (test_answers[i] == IsPrimeNumber(test_numbers[i]))
                {
                    Console.WriteLine("Верно");
                }
                else
                {
                    Console.WriteLine("Не верно");
                }
            }
        }
        static bool IsPrimeNumber(int number)
        {
            if (number > 1)
            {
                int d = 0;
                for (int i = 2; i < number; i++)
                {
                    if (number % i == 0)
                        d++;
                }
                if (d == 0)
                {
                    Console.WriteLine($"Число {number} - простое");
                }
                else
                {
                    Console.WriteLine($"Число {number} - не простое");
                }
                return d == 0;
            }
            else
            {
                Console.WriteLine($"Число {number} - должно быть больше 1");
                return false;
            }
        }
    }
}

using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
using System.Collections.Generic;

//Протестируйте поиск строки в HashSet и в массиве
//Заполните массив и HashSet случайными строками, не менее 10 000 строк. Строки можно сгенерировать. 
//Потом выполните замер производительности проверки наличия строки в массиве и HashSet. Выложите код и результат замеров.


//BenchmarkDotNet = v0.12.1, OS = Windows 10.0.18363.1316(1909 / November2018Update / 19H2)
//AMD FX(tm)-8120, 1 CPU, 8 logical and 4 physical cores
//.NET Core SDK=5.0.102
//  [Host]     : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT[AttachedDebugger]
//  DefaultJob : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT


//|            Method |         Mean |      Error  |       StdDev  |
//|------------------ |-------------:| -----------:| -------------:|
//| SearchInArrayTest | 25,303.90 ns | 504.197 ns  | 1,198.278 ns  |
//| SearchInHashTest  | 56.53 ns     | 1.116 ns    | 1.146 ns      |
namespace HW4_1
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class SearchStrings
    {
        readonly string[] arrayString;
        readonly HashSet<string> hashSet;
        readonly Random random;
        public SearchStrings()
        {
            arrayString = new string[10000];
            hashSet = new HashSet<string>();
            random = new Random();
            GenerateStringsArray();
        }
        public void GenerateStringsArray()
        {
            string str;
            for(int i=0; i<arrayString.Length; i++)
            {
                if(i==5779)
                {
                    arrayString[i] = "ABCDEFG";
                    hashSet.Add("ABCDEFG");
                    continue;
                }
                do
                {
                    str = GenerateString();
                }
                while (hashSet.Contains(str));
                arrayString[i] = str;
                hashSet.Add(str);
            }
        }
        string GenerateString()
        {
            string str = "";
            int k = random.Next(30, 60);
            for (int i=0; i<k; i++)
            {
                str += (char)random.Next(65, 123);
            }
            return str;
        }
        private bool SearchInArray(string str)
        {
            for (int i = 0; i < arrayString.Length; i++)
            {
                if (arrayString[i].Equals(str))
                {
                    return true;
                }
            }
            return false;
        }
        [Benchmark]
        public void SearchInArrayTest()
        {
            SearchInArray("ABCDEFG");
        }
        private bool SearchInHash(string str) => hashSet.Contains(str);
        [Benchmark]
        public void SearchInHashTest()
        {
            SearchInHash("ABCDEFG");
        }
    }
}

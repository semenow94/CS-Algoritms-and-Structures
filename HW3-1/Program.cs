using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using System;
namespace HW3_1
{
//    BenchmarkDotNet=v0.12.1, OS=Windows 10.0.18363.1316 (1909/November2018Update/19H2)
//AMD FX(tm)-8120, 1 CPU, 8 logical and 4 physical cores
//.NET Core SDK = 5.0.102
//  [Host]     : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT[AttachedDebugger]
//  DefaultJob : .NET Core 3.1.11 (CoreCLR 4.700.20.56602, CoreFX 4.700.20.56604), X64 RyuJIT


//|                           Method |     Mean |    Error |   StdDev |
//|--------------------------------- |---------:|---------:|---------:|
//|        TestStandartDistanceClass | 12.68 ns | 0.290 ns | 0.356 ns |
//|       TestStandartDistanceStruct | 13.76 ns | 0.297 ns | 0.353 ns |
//| TestStandartDistanceStructDouble | 14.53 ns | 0.321 ns | 0.330 ns |
//|          TestShortDistanceStruct | 16.27 ns | 0.362 ns | 0.901 ns |
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
        }
    }
    public class BechmarkClass
    {
        readonly PointClass[] pointClasses;
        readonly PointStructDouble[] pointStruct_Doubles;
        readonly PointStructFloat[] pointStruct_Floats;
        public BechmarkClass()
        {
            Random random = new Random();
            int[] vs = new int[20]; // должно быть кратно 4
            for (int i = 0; i < vs.Length; i++) vs[i] = random.Next(0, 50);
            int length = vs.Length / 2;
            pointClasses = new PointClass[length];
            pointStruct_Doubles = new PointStructDouble[length];
            pointStruct_Floats = new PointStructFloat[length];
            for (int i = 0; i < length; i++)
            {
                pointClasses[i] = new PointClass() { X = vs[i * 2], Y = vs[i * 2 + 1] };
                pointStruct_Doubles[i] = new PointStructDouble() { X = vs[i * 2], Y = vs[i * 2 + 1] };
                pointStruct_Floats[i] = new PointStructFloat() { X = vs[i * 2], Y = vs[i * 2 + 1] };
            }
        }
        public float StandartDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public float StandartDistanceStruct(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public double StandartDistanceStructDouble(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public float ShortDistanceStruct(PointStructFloat pointOne, PointStructFloat pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }
        [Benchmark]
        public void TestStandartDistanceClass()
        {
            for (int i = 0; i < pointClasses.Length / 2; i++) StandartDistanceClass(pointClasses[i * 2], pointClasses[i * 2 + 1]);
        }
        [Benchmark]
        public void TestStandartDistanceStruct()
        {
            for (int i = 0; i < pointStruct_Floats.Length / 2; i++) StandartDistanceStruct(pointStruct_Floats[i * 2], pointStruct_Floats[i * 2 + 1]);
        }
        [Benchmark]
        public void TestStandartDistanceStructDouble()
        {
            for (int i = 0; i < pointStruct_Doubles.Length / 2; i++) StandartDistanceStructDouble(pointStruct_Doubles[i * 2], pointStruct_Doubles[i * 2 + 1]);
        }
        [Benchmark]
        public void TestShortDistanceStruct()
        {
            for (int i = 0; i < pointStruct_Floats.Length / 2; i++) ShortDistanceStruct(pointStruct_Floats[i * 2], pointStruct_Floats[i * 2 + 1]);
        }
    }
    public class PointClass
    {
        public float X;
        public float Y;
    }
    public struct PointStructFloat
    {
        public float X;
        public float Y;
    }
    public struct PointStructDouble
    {
        public double X;
        public double Y;
    }
}

using System;

namespace HW5_1
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Создаем дерево");
            BinTree binTree = new BinTree();
            binTree.AddItem(15);
            binTree.AddItem(13);
            binTree.AddItem(14);
            binTree.AddItem(12);
            binTree.AddItem(11);
            binTree.AddItem(18);
            binTree.AddItem(19);
            binTree.AddItem(17);
            binTree.AddItem(16);
            binTree.PrintTree();
            Console.WriteLine("Вывод BFS обхода");
            binTree.BfsPrint();
        }
    }
}

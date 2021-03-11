using System;
//Реализуйте DFS и BFS для дерева с выводом каждого шага в консоль.

//Создаем дерево
//|___15
//   |___18
//      |___19
//      |___17
//         |___16
//   |___13
//      |___14
//      |___12
//         |___11
//Вывод BFS обхода
//15 13 18 12 14 17 19 11 16
//Вывод DFS обхода
//15 13 12 11 14 18 17 16 19
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
            Console.WriteLine("Вывод DFS обхода");
            binTree.DfsPrint();
        }
    }
}

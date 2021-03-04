using System;

namespace HW2_1
{
    class Program
    {
        static void Main()
        {
            LinkedList list = new LinkedList();
            list.PrintList();
            Console.WriteLine("Заполняем лист 10 случайными значениями");
            Random random = new Random();
            for(int i=0;i<10;i++)
            {
                list.AddNode(random.Next(1, 20));
            }
            list.PrintList();
            Console.WriteLine("Возвращаем количество элементов");
            Console.WriteLine(list.GetCount());
            Console.WriteLine("Ищем элемент со значением 12");
            Node node = list.FindNode(12);
            if (node != null) Console.WriteLine("Элемент найден");
            else
            {
                for(int i=1; i<=20;i++)
                {
                    node = list.FindNode(i);
                    if (node != null) break;
                }
            }
            Console.WriteLine("Вставляем елемент со значением 21 после элемента со занчением "+node.Value);
            list.AddNodeAfter(node, 21);
            Node newnode = node.NextNode;
            list.PrintList();
            Console.WriteLine("Удаляем элемент с индексом 1");
            list.RemoveNode(1);
            list.PrintList();
            Console.WriteLine("Удаляем указанный элемент, в нашем случае со значением 21");
            list.RemoveNode(newnode);
            list.PrintList();
        }
        public class Node
        {
            public int Value { get; set; }
            public Node NextNode { get; set; }
            public Node PrevNode { get; set; }
        }
        public class LinkedList : ILinkedList
        {
            int count;
            Node first;
            Node end;
            public LinkedList()
            {
                count = 0;
            }
            public void AddNode(int value)
            {
                Node newNode = new Node() {Value = value};
                if (count!=0)
                {
                    newNode.PrevNode = end;
                    end.NextNode = newNode;
                }
                else
                {
                    first = newNode;
                }
                end = newNode;
                count++;
            }

            public void AddNodeAfter(Node node, int value)
            {
                if (Contains(node))
                {
                    if (node.NextNode != null)
                    {
                        Node newNode = new Node() { Value = value };
                        newNode.PrevNode = node;
                        newNode.NextNode = node.NextNode;
                        node.NextNode = newNode;
                    }
                    else AddNode(value);
                }
                else AddNode(value);
            }

            public bool Contains(Node searchNode)
            {
                bool flag = true;
                if (count != 0)
                {
                    Node node = first;
                    while(flag)
                    {
                        if (searchNode == node) return true;
                        else
                        {
                            if (node.NextNode != null) node = node.NextNode;
                            else flag = false;
                        }
                    }
                }
                return false;
            }

            public Node FindNode(int searchValue)
            {
                bool flag = true;
                Node node = first;
                if (count != 0)
                {
                    while(flag)
                    {
                        if (searchValue == node.Value) return node;
                        else
                        {
                            if (node.NextNode != null) node = node.NextNode;
                            else flag = false;
                        }
                    }
                }
                Console.WriteLine("Такого элемента нет");
                return null;
            }

            public int GetCount()
            {
                return count;
            }

            public void RemoveNode(int index)
            {
                if (index >= count) Console.WriteLine("Такого элемента не существует");
                else
                {
                    int listIndex = 0;
                    Node node = first;
                    while(true)
                    {
                        if (listIndex == index)
                        {
                            RemoveNode(node);
                            return;
                        }
                        else
                        {
                            node = node.NextNode;
                            listIndex++;
                        }
                    }
                }
            }

            public void RemoveNode(Node node)
            {
                if(Contains(node))
                {
                    if(node.NextNode!=null)
                    {
                        if (node.PrevNode != null)
                        {
                            node.NextNode.PrevNode = node.PrevNode;
                            node.PrevNode.NextNode = node.NextNode;
                        }
                        else
                        {
                            node.NextNode.PrevNode = null;
                            first = node.NextNode;
                        }
                    }
                    else
                    {
                        end = node.PrevNode;
                        node.PrevNode.NextNode = null;
                    }
                    count--;
                }
                else Console.WriteLine("Такого элемента нет в листе");
            }

            public void PrintList()
            {
                if(count!=0)
                {
                    Node node = first;
                    bool flag = true;
                    while(flag)
                    {
                        Console.Write(node.Value + " ");
                        if (node.NextNode == null) flag = false;
                        else node = node.NextNode;
                    }
                    Console.WriteLine();
                }
                else Console.WriteLine("Лист пустой");
            }
        }

        //Начальную и конечную ноду нужно хранить в самой реализации интерфейса
        public interface ILinkedList
        {
            int GetCount(); // возвращает количество элементов в списке
            void AddNode(int value);  // добавляет новый элемент списка
            void AddNodeAfter(Node node, int value); // добавляет новый элемент списка после определённого элемента
            void RemoveNode(int index); // удаляет элемент по порядковому номеру
            void RemoveNode(Node node); // удаляет указанный элемент
            Node FindNode(int searchValue); // ищет элемент по его значению
        }

    }
}

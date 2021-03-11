using System;
using System.Collections.Generic;
using System.Text;

namespace HW5_1
{
    public interface ITree
    {
        TreeNode GetRoot();
        void AddItem(int value); // добавить узел
        void RemoveItem(int value); // удалить узел по значению
        TreeNode GetNodeByValue(int value); //получить узел дерева по значению
        void PrintTree(); //вывести дерево в консоль
    }
    public class BinTree : ITree
    {
        public TreeNode root;
        public void AddItem(int value)
        {
            if (root == null)
            {
                root = new TreeNode(value, null);
                return;
            }
            bool flag = true;
            TreeNode par = root;
            while (flag)
            {
                if (value < par.Value)
                {
                    if (par.LeftChild == null)
                    {
                        par.LeftChild = new TreeNode(value, par);
                        flag = false;
                    }
                    else
                    {
                        par = par.LeftChild;
                        continue;
                    }
                }
                else //равные значения тоже попадают в эту ветку
                {
                    if (par.RightChild == null)
                    {
                        par.RightChild = new TreeNode(value, par);
                        flag = false;
                    }
                    else
                    {
                        par = par.RightChild;
                        continue;
                    }
                }
            }
        }
        public TreeNode GetNodeByValue(int value)
        {
            if (root != null)
            {
                bool flag = true;
                TreeNode treeNode = root;
                while (flag)
                {
                    if (treeNode.Value == value) return treeNode;
                    else
                    {
                        if (value > treeNode.Value && treeNode.RightChild != null) treeNode = treeNode.RightChild;
                        else if (treeNode.LeftChild != null) treeNode = treeNode.LeftChild;
                        else return null;
                    }
                }
                return null;
            }
            else return null;
        }

        public TreeNode GetRoot()
        {
            return root;
        }

        public void PrintTree()
        {
            if (root != null) PrintTree(root, 0);
            else Console.WriteLine("Дерево пустое");
        }
        void PrintTree(TreeNode treeNode, int stage)
        {
            string str = "";
            for (int i = 0; i < stage; i++)
            {
                str += "   ";
            }
            str += "|";
            str += "___" + treeNode.Value;
            Console.WriteLine(str);
            if (treeNode.RightChild != null) PrintTree(treeNode.RightChild, stage + 1);
            if (treeNode.LeftChild != null) PrintTree(treeNode.LeftChild, stage + 1);
        }
        void BranchToArray(List<int> list, TreeNode treeNode)
        {
            list.Add(treeNode.Value);
            if (treeNode.RightChild != null) BranchToArray(list, treeNode.RightChild);
            if (treeNode.LeftChild != null) BranchToArray(list, treeNode.LeftChild);
        }
        public void RemoveItem(int value)
        {
            TreeNode treeNode = GetNodeByValue(value);
            if (treeNode != null)
            {
                if (treeNode.Parent == null)
                {
                    if (treeNode.RightChild == null && treeNode.LeftChild == null) root = null;//удаление головного без потомков
                    else if (treeNode.RightChild != null && treeNode.LeftChild == null) //удаление головного с правым потомком
                    {
                        root = treeNode.RightChild;
                        treeNode.RightChild.Parent = null;
                    }
                    else if (treeNode.RightChild == null && treeNode.LeftChild != null)//удаление головного с левым потомком
                    {
                        root = treeNode.LeftChild;
                        treeNode.LeftChild.Parent = null;
                    }
                    else//удаление головного с двумя потомками
                    {
                        root = treeNode.RightChild;
                        treeNode.RightChild.Parent = null;
                        List<int> list = new List<int>();
                        BranchToArray(list, treeNode.LeftChild);
                        foreach (int i in list) AddItem(i);
                    }
                }
                else
                {
                    if (treeNode.RightChild == null && treeNode.LeftChild == null)//удаление листа
                    {
                        if (treeNode.Parent.Value > treeNode.Value) treeNode.Parent.LeftChild = null;
                        else treeNode.Parent.RightChild = null;
                    }
                    if (treeNode.RightChild == null && treeNode.LeftChild != null)//удаление узла с левым потомком
                    {
                        if (treeNode.Parent.Value > treeNode.Value) treeNode.Parent.LeftChild = treeNode.LeftChild;
                        else treeNode.Parent.RightChild = treeNode.LeftChild;
                        treeNode.LeftChild.Parent = treeNode.Parent;
                    }
                    if (treeNode.RightChild != null && treeNode.LeftChild == null)//удаление узла с правым потомком
                    {
                        if (treeNode.Parent.Value > treeNode.Value) treeNode.Parent.LeftChild = treeNode.RightChild;
                        else treeNode.Parent.RightChild = treeNode.RightChild;
                        treeNode.RightChild.Parent = treeNode.Parent;
                    }
                    if (treeNode.RightChild != null && treeNode.LeftChild != null)//удаление узла с двумя потомками
                    {
                        if (treeNode.Parent.Value > treeNode.Value) treeNode.Parent.LeftChild = treeNode.RightChild;
                        else treeNode.Parent.RightChild = treeNode.RightChild;
                        treeNode.RightChild.Parent = treeNode.Parent;
                        List<int> list = new List<int>();
                        BranchToArray(list, treeNode.LeftChild);
                        foreach (int i in list) AddItem(i);
                    }
                }
            }
            else Console.WriteLine("Такой ноды нет");
        }
        public void BfsPrint()
        {
            if(root==null)
            {
                Console.WriteLine("Дерево пустое");
                return;
            }
            Queue<TreeNode> nodes = new Queue<TreeNode>();
            TreeNode treeNode;
            nodes.Enqueue(root);
            while(nodes.Count>0)
            {
                treeNode = nodes.Dequeue();
                Console.Write(treeNode.Value+" ");
                if (treeNode.LeftChild != null) nodes.Enqueue(treeNode.LeftChild);
                if (treeNode.RightChild != null) nodes.Enqueue(treeNode.RightChild);
            }
            Console.WriteLine();
        }
    }
    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode LeftChild { get; set; }
        public TreeNode RightChild { get; set; }
        public TreeNode Parent { get; set; }
        public TreeNode(int value, TreeNode parent)
        {
            Value = value;
            Parent = parent;
        }
    }
}

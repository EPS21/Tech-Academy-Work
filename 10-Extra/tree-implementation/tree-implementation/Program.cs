using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tree_implementation
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("This is a program to implement and see tree structures");
            Console.ReadKey();
        }

        class Node
        {
            public string Name;
            public Node[] children;
        }

        class Tree
        {
            public Node root;
        }
        
        void inOrderTraversal(Tree node)
        {
            if (node != null)
            {
                inOrderTraversal(node.left);
                visit(node);
                inOrderTraversal(node.right);
            }
        }
        

    }


}
